using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace AdvantageFramework.Core.BLogic.Controllers.AlertSystem
{
    public partial class AlertController //: AdvantageFramework.Controller.BaseController
    {

        //#region  Constants 

        //private const string _AppVarApplication = "ALERT_VIEW";

        //#endregion

        //#region  Enum 

        //public enum AppVars
        //{
        //    CloseAfterCommentOrReAssign,
        //    WidgetLayout,
        //    ShowHideSystemComments,
        //    DetailsExpanded,
        //    ShowChecklistsOnCards,
        //    UploadDocumentManager
        //}

        //#endregion

        //#region  Variables 



        //#endregion

        //#region  Properties 



        //#endregion

        //#region  Methods 

        //#region  Proofing/Imaging 
        //public byte[] GetThumbnailBytes(AdvantageFramework.Core.Database.DbContext DbContext, byte[] FullImageBytes, ref string ErrorMessage)
        //{
        //    byte[] GetThumbnailBytesRet = default;
        //    int TargetMax = 100;
        //    Image FullImage = default;
        //    Image ThumbnailImage = default;
        //    byte[] ThumbnailBytes = null;
        //    int FullImageHeight = 0;
        //    int FullImageWidth = 0;
        //    int ThumbnailImageHeight = 0;
        //    int ThumbnailImageWidth = 0;
        //    decimal ScaleFactor = 0m;
        //    if (FullImageBytes is object)
        //    {
        //        FullImage = ByteArrayToImage(FullImageBytes, ref ErrorMessage);
        //        if (FullImage is object)
        //        {
        //            FullImageHeight = FullImage.Height;
        //            FullImageWidth = FullImage.Width;
        //            if (FullImageHeight > TargetMax || FullImageWidth > TargetMax)
        //            {
        //                if (FullImageHeight > FullImageWidth)
        //                {
        //                    ScaleFactor = (decimal)(FullImageHeight / (double)TargetMax);
        //                }
        //                else
        //                {
        //                    ScaleFactor = (decimal)(FullImageWidth / (double)TargetMax);
        //                }

        //                ThumbnailImageHeight = Conversions.ToInteger(FullImageHeight * ScaleFactor);
        //                ThumbnailImageWidth = Conversions.ToInteger(FullImageWidth * ScaleFactor);
        //            }

        //            try
        //            {
        //                ThumbnailImage = FullImage.GetThumbnailImage(ThumbnailImageWidth, ThumbnailImageHeight, default, new IntPtr());
        //            }
        //            catch (Exception ex)
        //            {
        //                ErrorMessage = AdvantageFramework.Core.StringUtilities.Methods.FullErrorToString(ex);
        //                ThumbnailBytes = null;
        //            }

        //            GetThumbnailBytesRet = ImageToByteArray(ThumbnailImage, ref ErrorMessage);
        //        }
        //    }

        //    return ThumbnailBytes;
        //}

        //#region  Private 

        //public byte[] ImageToByteArray(Image TheImage, ref string ErrorMessage)
        //{
        //    try
        //    {
        //        using (var MemoryStream = new MemoryStream())
        //        {
        //            TheImage.Save(MemoryStream, TheImage.RawFormat);
        //            return MemoryStream.ToArray();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorMessage = AdvantageFramework.Core.StringUtilities.Methods.FullErrorToString(ex);
        //        return null;
        //    }
        //}

        //public Image ByteArrayToImage(byte[] ByteArrayIn, ref string ErrorMessage)
        //{
        //    try
        //    {
        //        using (var MemoryStream = new MemoryStream(ByteArrayIn))
        //        {
        //            return Image.FromStream(MemoryStream);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorMessage = AdvantageFramework.Core.StringUtilities.Methods.FullErrorToString(ex);
        //        return default;
        //    }
        //}

        //public static byte[] ImgToByteConverter(Image TheImage, ref string ErrorMessage)
        //{
        //    try
        //    {
        //        var ImageConverter = new ImageConverter();
        //        return (byte[])ImageConverter.ConvertTo(TheImage, typeof(byte[]));
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorMessage = AdvantageFramework.Core.StringUtilities.Methods.FullErrorToString(ex);
        //        return null;
        //    }
        //}

        //#endregion

        //#endregion

        //#region  Inbox/Dashboard 
        //// Public Function LoadAlerts(ByVal DbContext As AdvantageFramework.Core.Database.DbContext,
        //// ByVal EmployeeCode As String,
        //// ByVal InboxType As String,
        //// ByVal FilterLevel As String,
        //// ByVal OfficeCode As String,
        //// ByVal ClCode As String,
        //// ByVal DivCode As String,
        //// ByVal PrdCode As String,
        //// ByVal CmpIdentifier As String,
        //// ByVal CmpCode As String,
        //// ByVal JobNumber As Integer,
        //// ByVal JobComponentNbr As Integer,
        //// ByVal AlertTypeId As String,
        //// ByVal AlertCategoryId As String,
        //// ByVal StartDate As String,
        //// ByVal EndDate As String,
        //// ByVal AlertLevel As String,
        //// ByVal VnCode As String,
        //// ByVal EstimateNumber As Integer,
        //// ByVal EstComponentNbr As Integer,
        //// ByVal TaskCode As String,
        //// ByVal TaskDescription As String,
        //// ByVal ATBNumber As Integer,
        //// ByVal ShowAssignmentType As String,
        //// ByVal AlrtNotifyHdrId As Integer,
        //// ByVal AlertNotifyName As String,
        //// ByVal IncludeCompletedAssignments As Boolean,
        //// ByVal IsJobAlertsPage As Boolean,
        //// ByVal AlertAssignmentSeqNbr As Integer,
        //// ByVal GroupBy As String,
        //// ByVal SearchCriteria As String,
        //// ByVal AccountExecutiveCode As String,
        //// ByVal ManagerCode As String,
        //// ByVal StateId As Integer,
        //// ByVal RecordsToReturn As Integer,
        //// ByVal IsCount As Boolean,
        //// ByRef RecordCount As Integer,
        //// ByVal IncludeReviews As Boolean,
        //// ByVal IncludeBoardLevel As Boolean,
        //// ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert)

        //// Dim Alerts As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert) = Nothing
        //// Dim DataTable As System.Data.DataTable = Nothing

        //// Try

        //// DataTable = AdvantageFramework.AlertSystem.LoadAlertsAsDataTable(DbContext,
        //// EmployeeCode,
        //// EmployeeCode,
        //// InboxType,
        //// FilterLevel,
        //// OfficeCode,
        //// ClCode,
        //// DivCode,
        //// PrdCode,
        //// CmpIdentifier,
        //// CmpCode,
        //// JobNumber,
        //// JobComponentNbr,
        //// AlertTypeId,
        //// AlertCategoryId,
        //// StartDate,
        //// EndDate,
        //// AlertLevel,
        //// VnCode,
        //// EstimateNumber,
        //// EstComponentNbr,
        //// TaskCode,
        //// TaskDescription,
        //// ATBNumber,
        //// ShowAssignmentType,
        //// AlrtNotifyHdrId,
        //// AlertNotifyName,
        //// IncludeCompletedAssignments,
        //// IsJobAlertsPage,
        //// AlertAssignmentSeqNbr,
        //// GroupBy,
        //// SearchCriteria,
        //// AccountExecutiveCode,
        //// ManagerCode,
        //// StateId,
        //// RecordsToReturn,
        //// IsCount,
        //// RecordCount,
        //// IncludeReviews,
        //// IncludeBoardLevel,
        //// ErrorMessage)

        //// If DataTable IsNot Nothing AndAlso DataTable.Rows.Count > 0 Then

        //// Alerts = DataTable.Rows.OfType(Of DataRow).ToList.Select(Function(dr) AdvantageFramework.DTO.Desktop.Alert.FromMainAlertQuery(dr, GroupBy)).ToList

        //// End If

        //// Catch ex As Exception
        //// ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
        //// Alerts = Nothing
        //// End Try

        //// Return Alerts

        //// End Function
        ////public List<AdvantageFramework.DTO.Desktop.Alert> LoadAlertsCP(AdvantageFramework.Core.Database.DbContext DbContext, int CPID, string InboxType, string FilterLevel, string OfficeCode, string ClCode, string DivCode, string PrdCode, string CmpIdentifier, string CmpCode, int JobNumber, int JobComponentNbr, string AlertTypeId, string AlertCategoryId, string StartDate, string EndDate, string AlertLevel, string VnCode, int EstimateNumber, int EstComponentNbr, string TaskCode, string TaskDescription, int ATBNumber, string ShowAssignmentType, int AlrtNotifyHdrId, string AlertNotifyName, bool IncludeCompletedAssignments, bool IsJobAlertsPage, int AlertAssignmentSeqNbr, string GroupBy, string SearchCriteria, string AccountExecutiveCode, string ManagerCode, int StateId, int RecordsToReturn, bool IsCount, ref int RecordCount, bool IncludeReviews, bool IncludeBoardLevel, ref string ErrorMessage)
        ////{
        ////    List<AdvantageFramework.DTO.Desktop.Alert> Alerts = null;
        ////    System.Data.DataTable DataTable = null;
        ////    try
        ////    {
        ////        DataTable = AdvantageFramework.Core.AlertSystem.Methods.LoadAlertsCPAsDatable(DbContext, CPID, InboxType, FilterLevel, OfficeCode, ClCode, DivCode, PrdCode, CmpIdentifier, CmpCode, JobNumber, JobComponentNbr, AlertTypeId, AlertCategoryId, StartDate, EndDate, AlertLevel, VnCode, EstimateNumber, EstComponentNbr, TaskCode, TaskDescription, ShowAssignmentType, AlrtNotifyHdrId, AlertNotifyName, IncludeCompletedAssignments, IsJobAlertsPage, AlertAssignmentSeqNbr, GroupBy, SearchCriteria, RecordsToReturn, IsCount, RecordCount, IncludeReviews, ErrorMessage);
        ////        if (DataTable is object && DataTable.Rows.Count > 0)
        ////        {
        ////            Alerts = DataTable.Rows.OfType<DataRow>().ToList.Select(dr => AdvantageFramework.DTO.Desktop.Alert.FromMainAlertQuery(dr, GroupBy)).ToList;
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex);
        ////        Alerts = null;
        ////    }

        ////    return Alerts;
        ////}

        //public List<AdvantageFramework.DTO.Desktop.Alert> LoadAlerts(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeCode, string TaskStartToday, string TaskOnlyStartDue, string TaskStatus, string DefaultSort)
        //{
        //    List<AdvantageFramework.DTO.Desktop.Alert> LoadAlertsRet = default;
        //    List<AdvantageFramework.DTO.Desktop.Alert> Alerts = null;
        //    string Status = "";
        //    decimal Offset = 0.0m;
        //    System.Data.SqlClient.SqlParameter EmployeeCodeSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter StartDateAsOfTodaySqlParameter = null;
        //    System.Data.SqlClient.SqlParameter StartAndDueDateNotNullSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter TaskStatusSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter GroupBySqlParameter = null;
        //    System.Data.SqlClient.SqlParameter IncludeBacklogSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter GetNotificationCountOnlySqlParameter = null;
        //    System.Data.SqlClient.SqlParameter OffsetSqlParameter = null;
        //    if (TaskStatus == "Projected")
        //    {
        //        Status = "P";
        //    }
        //    else if (TaskStatus == "Active")
        //    {
        //        Status = "A";
        //    }

        //    Offset = AdvantageFramework.Core.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, EmployeeCode);
        //    EmployeeCodeSqlParameter = new System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6);
        //    StartDateAsOfTodaySqlParameter = new System.Data.SqlClient.SqlParameter("@START_DATE_AS_OF_TODAY", SqlDbType.Bit);
        //    StartAndDueDateNotNullSqlParameter = new System.Data.SqlClient.SqlParameter("@START_AND_DUE_DATE_NOT_NULL", SqlDbType.Bit);
        //    TaskStatusSqlParameter = new System.Data.SqlClient.SqlParameter("@TASK_STATUS", SqlDbType.Char);
        //    GroupBySqlParameter = new System.Data.SqlClient.SqlParameter("@GROUP_BY", SqlDbType.VarChar, 20);
        //    IncludeBacklogSqlParameter = new System.Data.SqlClient.SqlParameter("@INCLUDE_BACKLOG", SqlDbType.Bit);
        //    GetNotificationCountOnlySqlParameter = new System.Data.SqlClient.SqlParameter("@GET_NOTIFICATION_COUNT_ONLY", SqlDbType.Bit);
        //    OffsetSqlParameter = new System.Data.SqlClient.SqlParameter("@OFFSET", SqlDbType.Decimal);
        //    EmployeeCodeSqlParameter.Value = EmployeeCode;
        //    StartDateAsOfTodaySqlParameter.Value = TaskStartToday == "True";
        //    StartAndDueDateNotNullSqlParameter.Value = TaskOnlyStartDue == "True";
        //    TaskStatusSqlParameter.Value = Status;
        //    GroupBySqlParameter.Value = DefaultSort;
        //    IncludeBacklogSqlParameter.Value = false;
        //    GetNotificationCountOnlySqlParameter.Value = false;
        //    OffsetSqlParameter.Value = Offset;
        //    Alerts = DbContext.Database.SqlQuery<AdvantageFramework.DTO.Desktop.Alert>(string.Format("EXEC [dbo].[usp_wv_dto_dashboard_alert] @EMP_CODE, @START_DATE_AS_OF_TODAY, @START_AND_DUE_DATE_NOT_NULL, @TASK_STATUS, @GROUP_BY, @INCLUDE_BACKLOG, @GET_NOTIFICATION_COUNT_ONLY, @OFFSET;"), EmployeeCodeSqlParameter, StartDateAsOfTodaySqlParameter, StartAndDueDateNotNullSqlParameter, TaskStatusSqlParameter, GroupBySqlParameter, IncludeBacklogSqlParameter, GetNotificationCountOnlySqlParameter, OffsetSqlParameter).ToList;
        //    if (DefaultSort == "PRIORITY")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.PriorityLevel).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "DUE_DATE_ASC")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.DueDate).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "DUE_DATE")
        //    {
        //        Alerts = Alerts.OrderByDescending(A => A.DueDate).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "VER_BLD")
        //    {
        //        Alerts = Alerts.OrderByDescending(A => A.Version).ThenBy(A => A.Build).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "LAST_UPD")
        //    {
        //        Alerts = Alerts.OrderByDescending(A => A.LastUpdatedDateTime).ThenBy(A => A.CardSequenceNumber).ToList;
        //    }
        //    else if (DefaultSort == "NEW_UNREAD")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.GroupKey).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "CAT")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.AlertCategoryDescription).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "STATE")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.AlertStateName).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "C")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.ClientName).ThenBy(A => A.DivisionCode).ThenBy(A => A.ProductCode).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "CD")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.DivisionName).ThenBy(A => A.ProductCode).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "CDP")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.ProductName).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "CDPJ")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.GroupKey).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "CDPJC")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.GroupKey).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "TS")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.GroupKey).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else
        //    {
        //        Alerts = Alerts.OrderBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }

        //    LoadAlertsRet = Alerts;
        //    return LoadAlertsRet;
        //}

        //public List<AdvantageFramework.DTO.Desktop.Alert> LoadAlertsCPNew(AdvantageFramework.Core.Database.DbContext DbContext, string CP_ID, string TaskStartToday, string TaskOnlyStartDue, string TaskStatus, string DefaultSort)
        //{
        //    List<AdvantageFramework.DTO.Desktop.Alert> LoadAlertsCPNewRet = default;
        //    List<AdvantageFramework.DTO.Desktop.Alert> Alerts = null;
        //    string Status = "";
        //    decimal Offset = 0.0m;
        //    System.Data.SqlClient.SqlParameter EmployeeCodeSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter StartDateAsOfTodaySqlParameter = null;
        //    System.Data.SqlClient.SqlParameter StartAndDueDateNotNullSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter TaskStatusSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter GroupBySqlParameter = null;
        //    System.Data.SqlClient.SqlParameter IncludeBacklogSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter GetNotificationCountOnlySqlParameter = null;
        //    System.Data.SqlClient.SqlParameter OffsetSqlParameter = null;
        //    if (TaskStatus == "Projected")
        //    {
        //        Status = "P";
        //    }
        //    else if (TaskStatus == "Active")
        //    {
        //        Status = "A";
        //    }

        //    Offset = 0m; // AdvantageFramework.Core.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, EmployeeCode)
        //    EmployeeCodeSqlParameter = new System.Data.SqlClient.SqlParameter("@CP_ID", SqlDbType.VarChar, 6);
        //    StartDateAsOfTodaySqlParameter = new System.Data.SqlClient.SqlParameter("@START_DATE_AS_OF_TODAY", SqlDbType.Bit);
        //    StartAndDueDateNotNullSqlParameter = new System.Data.SqlClient.SqlParameter("@START_AND_DUE_DATE_NOT_NULL", SqlDbType.Bit);
        //    TaskStatusSqlParameter = new System.Data.SqlClient.SqlParameter("@TASK_STATUS", SqlDbType.Char);
        //    GroupBySqlParameter = new System.Data.SqlClient.SqlParameter("@GROUP_BY", SqlDbType.VarChar, 20);
        //    IncludeBacklogSqlParameter = new System.Data.SqlClient.SqlParameter("@INCLUDE_BACKLOG", SqlDbType.Bit);
        //    GetNotificationCountOnlySqlParameter = new System.Data.SqlClient.SqlParameter("@GET_NOTIFICATION_COUNT_ONLY", SqlDbType.Bit);
        //    OffsetSqlParameter = new System.Data.SqlClient.SqlParameter("@OFFSET", SqlDbType.Decimal);
        //    EmployeeCodeSqlParameter.Value = CP_ID;
        //    StartDateAsOfTodaySqlParameter.Value = TaskStartToday == "True";
        //    StartAndDueDateNotNullSqlParameter.Value = TaskOnlyStartDue == "True";
        //    TaskStatusSqlParameter.Value = Status;
        //    GroupBySqlParameter.Value = DefaultSort;
        //    IncludeBacklogSqlParameter.Value = false;
        //    GetNotificationCountOnlySqlParameter.Value = false;
        //    OffsetSqlParameter.Value = Offset;
        //    Alerts = DbContext.Database.SqlQuery<AdvantageFramework.DTO.Desktop.Alert>(string.Format("EXEC [dbo].[usp_cp_dto_dashboard_alert] @CP_ID, @START_DATE_AS_OF_TODAY, @START_AND_DUE_DATE_NOT_NULL, @TASK_STATUS, @GROUP_BY, @INCLUDE_BACKLOG, @GET_NOTIFICATION_COUNT_ONLY, @OFFSET;"), EmployeeCodeSqlParameter, StartDateAsOfTodaySqlParameter, StartAndDueDateNotNullSqlParameter, TaskStatusSqlParameter, GroupBySqlParameter, IncludeBacklogSqlParameter, GetNotificationCountOnlySqlParameter, OffsetSqlParameter).ToList;
        //    if (DefaultSort == "PRIORITY")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.PriorityLevel).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "DUE_DATE_ASC")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.DueDate).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "DUE_DATE")
        //    {
        //        Alerts = Alerts.OrderByDescending(A => A.DueDate).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "VER_BLD")
        //    {
        //        Alerts = Alerts.OrderByDescending(A => A.Version).ThenBy(A => A.Build).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "LAST_UPD")
        //    {
        //        Alerts = Alerts.OrderByDescending(A => A.LastUpdatedDateTime).ThenBy(A => A.CardSequenceNumber).ToList;
        //    }
        //    else if (DefaultSort == "NEW_UNREAD")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.GroupKey).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "CAT")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.AlertCategoryDescription).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "STATE")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.AlertStateName).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "C")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.ClientName).ThenBy(A => A.DivisionCode).ThenBy(A => A.ProductCode).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "CD")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.DivisionName).ThenBy(A => A.ProductCode).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "CDP")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.ProductName).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "CDPJ")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.GroupKey).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "CDPJC")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.GroupKey).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else if (DefaultSort == "TS")
        //    {
        //        Alerts = Alerts.OrderBy(A => A.GroupKey).ThenBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }
        //    else
        //    {
        //        Alerts = Alerts.OrderBy(A => A.CardSequenceNumber).ThenByDescending(A => A.LastUpdatedDateTime).ToList;
        //    }

        //    LoadAlertsCPNewRet = Alerts;
        //    return LoadAlertsCPNewRet;
        //}

        //#endregion

        //#region  ALERT NOTIFICATIONS 

        //public int LoadNotificationCount()
        //{
        //    int Count = 0;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Count = LoadNotificationCount(DbContext);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Count = 0;
        //    }

        //    return Count;
        //}

        //public int LoadNotificationCount(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    int Count = 0;
        //    try
        //    {

        //        // Count = (From Entity In DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.Alert)(String.Format("exec dbo.usp_wv_dto_dashboard_alert '{0}', @GET_NOTIFICATION_COUNT_ONLY = 1", Session.User.EmployeeCode)).ToList
        //        // Where Entity.ReadAlert Is Nothing OrElse Entity.ReadAlert = 0).Count

        //        Count = (from Entity in DbContext.Database.SqlQuery<AdvantageFramework.DTO.Desktop.Alert>(string.Format("exec dbo.usp_wv_dto_dashboard_alert '{0}', @GET_NOTIFICATION_COUNT_ONLY = 1", Session.User.EmployeeCode)).ToList
        //                 where (Entity.ReadAlert is null || Entity.ReadAlert == 0) && (Entity.IsProof is null || Entity.IsProof == false)
        //                 select Entity).Count;
        //    }
        //    catch (Exception ex)
        //    {
        //        Count = 0;
        //    }

        //    return Count;
        //}

        //public List<AdvantageFramework.ViewModels.Desktop.AlertNotification> LoadNotifications()
        //{
        //    List<AdvantageFramework.ViewModels.Desktop.AlertNotification> Notifications = null;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Notifications = LoadNotifications(DbContext);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Notifications = null;
        //    }

        //    if (Notifications is null)
        //        Notifications = new List<ViewModels.Desktop.AlertNotification>();
        //    return Notifications;
        //}

        //public List<AdvantageFramework.ViewModels.Desktop.AlertNotification> LoadNotifications(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    List<AdvantageFramework.ViewModels.Desktop.AlertNotification> Notifications = null;
        //    List<AdvantageFramework.DTO.Desktop.Alert> Alerts = null;
        //    string Status = "";
        //    decimal Offset = 0.0m;
        //    Offset = AdvantageFramework.Core.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, this.Session.User.EmployeeCode);
        //    Alerts = DbContext.Database.SqlQuery<AdvantageFramework.DTO.Desktop.Alert>(string.Format("exec dbo.usp_wv_dto_dashboard_alert '{0}', {1}, {2}, '{3}', '{4}', @INCLUDE_BACKLOG = 1, @OFFSET = {5}", this.Session.User.EmployeeCode, 0, 0, Status, "", Offset)).ToList;
        //    try
        //    {

        //        // Notifications = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.Desktop.AlertNotification)(String.Format("EXEC [dbo].[advsp_alert_notifications] '{0}', NULL;", Me.Session.User.EmployeeCode)).ToList
        //        if (Alerts is object)
        //        {
        //            Notifications = (from Entity in Alerts
        //                             where (object)(Entity.ReadAlert is null) || Operators.ConditionalCompareObjectEqual(Entity.ReadAlert, 0, false)
        //                             orderby Entity.LastUpdatedDateTime descending
        //                             select new AdvantageFramework.ViewModels.Desktop.AlertNotification()
        //                             {
        //                                 AlertID = Entity.ID,
        //                                 LastUpdated = Entity.LastUpdatedDateTime,
        //                                 Generated = Entity.GeneratedDate,
        //                                 Priority = Entity.PriorityLevel,
        //                                 ShortSubject = Entity.Subject,
        //                                 Subject = Entity.Subject,
        //                                 IsAssignment = Entity.IsAlertAssignment,
        //                                 JobNumber = Entity.JobNumber,
        //                                 JobComponentNumber = Entity.JobComponentNumber,
        //                                 SequenceNumber = Entity.TaskSequenceNumber,
        //                                 IsConceptShareReview = Entity.IsCSReview,
        //                                 ConceptShareProjectID = Entity.CSProjectID,
        //                                 ConceptShareReviewID = Entity.CSReviewID,
        //                                 AssignedEmployeeCode = Entity.AssignedEmployeeCode,
        //                                 CurrentNotify = true,
        //                                 IsWorkItem = Entity.IsWorkItem,
        //                                 SprintID = Entity.SprintID,
        //                                 LastUpdatedFullName = Entity.LastUpdatedFullName,
        //                                 LastUpdatedEmployeeCode = Entity.EmployeeCode,
        //                                 AlertCategoryDescription = Entity.AlertCategoryDescription
        //                             }).ToList;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Notifications = null;
        //    }
        //    finally
        //    {
        //        if (Notifications is null)
        //            Notifications = new List<AdvantageFramework.ViewModels.Desktop.AlertNotification>();
        //    }

        //    return Notifications;
        //}

        //public bool AlertNotificationMarkAllAsRead(string EmployeeCode)
        //{
        //    bool Success = true;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            DbContext.Database.ExecuteSqlCommand(string.Format("UPDATE ALERT_RCPT SET READ_ALERT = 1 WHERE EMP_CODE = '{0}' AND (READ_ALERT IS NULL OR READ_ALERT = 0);" + "UPDATE JOB_TRAFFIC_DET_EMPS SET READ_ALERT = 1 WHERE EMP_CODE = '{0}' AND (READ_ALERT IS NULL OR READ_ALERT = 0);", EmployeeCode));
        //            Success = true;
        //            // Dim Notifications As Generic.List(Of AdvantageFramework.ViewModels.Desktop.AlertNotification) = Nothing

        //            // Notifications = LoadNotifications(DbContext)

        //            // If Notifications IsNot Nothing Then

        //            // Dim PromptForFullCompleteTask As Boolean = False
        //            // Dim PromptForTempCompleteTask As Boolean = False
        //            // Dim ErrorMessage As String = String.Empty
        //            // Dim AlertRecipient As AdvantageFramework.Core.Database.Entities.AlertRecipient = Nothing
        //            // Dim JobComponentTaskEmployee As AdvantageFramework.Core.Database.Entities.JobComponentTaskEmployee = Nothing

        //            // For Each Notif As AdvantageFramework.ViewModels.Desktop.AlertNotification In Notifications

        //            // AlertRecipient = Nothing

        //            // Try

        //            // AlertRecipient = AdvantageFramework.Core.Database.Procedures.AlertRecipient.LoadByAlertIDAndEmployeeCode(DbContext, Notif.AlertID, EmployeeCode)

        //            // Catch ex As Exception
        //            // AlertRecipient = Nothing
        //            // End Try

        //            // If AlertRecipient IsNot Nothing Then

        //            // AlertRecipient.HasBeenRead = 1

        //            // If AdvantageFramework.Core.Database.Procedures.AlertRecipient.Update(DbContext, AlertRecipient) = True Then

        //            // Success = True

        //            // End If

        //            // Else

        //            // JobComponentTaskEmployee = Nothing

        //            // Try

        //            // JobComponentTaskEmployee = AdvantageFramework.Core.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeqEmp(DbContext, Notif.JobNumber, Notif.JobComponentNumber, Notif.SequenceNumber, EmployeeCode)

        //            // Catch ex As Exception
        //            // JobComponentTaskEmployee = Nothing
        //            // End Try

        //            // If JobComponentTaskEmployee IsNot Nothing Then

        //            // JobComponentTaskEmployee.ReadAlert = 1

        //            // If AdvantageFramework.Core.Database.Procedures.JobComponentTaskEmployee.Update(DbContext, JobComponentTaskEmployee) = True Then

        //            // Success = True

        //            // End If

        //            // End If

        //            // End If

        //            // Next

        //            // End If

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Success = false;
        //    }

        //    return Success;
        //}

        //public bool AlertNotificationDismissAllAlerts(string EmployeeCode)
        //{
        //    bool HasAlertDismissed = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            List<AdvantageFramework.DTO.Desktop.Alert> Alerts = null;
        //            Alerts = LoadAlerts(DbContext, EmployeeCode, "", "", "", "");
        //            if (Alerts is object && Alerts.Count > 0)
        //            {
        //                Alerts = Alerts.Where(F => Operators.ConditionalCompareObjectEqual(F.IsAlertCC, true, false) && ((object)(F.ReadAlert is null) || Operators.ConditionalCompareObjectEqual(F.ReadAlert, 0, false))).ToList;
        //                if (Alerts is object && Alerts.Count > 0)
        //                {
        //                    bool PromptForFullCompleteTask = false;
        //                    bool PromptForTempCompleteTask = false;
        //                    string ErrorMessage = string.Empty;
        //                    foreach (AdvantageFramework.DTO.Desktop.Alert Alert in Alerts)
        //                    {
        //                        try
        //                        {
        //                            AdvantageFramework.AlertSystem.DismissAlert(DbContext, Alert.ID, EmployeeCode, this.Session.UserCode, 0, false, PromptForFullCompleteTask, PromptForTempCompleteTask, ErrorMessage);
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        HasAlertDismissed = false;
        //    }

        //    return HasAlertDismissed;
        //}

        //#endregion

        //#region  New Assignment 

        //public AdvantageFramework.DTO.Desktop.Alert InitNewAssignment()
        //{
        //    var Alert = new AdvantageFramework.DTO.Desktop.Alert();
        //    return Alert;
        //}

        //public List<AdvantageFramework.ProjectSchedule.Classes.ScheduleTask> GetScheduleTasks(AdvantageFramework.Core.Database.DbContext DbContext, int JobNumber, short JobComponentNumber)
        //{
        //    List<AdvantageFramework.ProjectSchedule.Classes.ScheduleTask> ScheduleTaskList = null;
        //    try
        //    {
        //        ScheduleTaskList = AdvantageFramework.ProjectSchedule.GetScheduleTasks(DbContext, JobNumber, JobComponentNumber, "", DbContext.UserCode, "", "", "", true, false, false, "", "no_filter", false, false, false, false);
        //    }
        //    catch (Exception ex)
        //    {
        //        ScheduleTaskList = null;
        //    }
        //    finally
        //    {
        //        if (ScheduleTaskList is null)
        //            ScheduleTaskList = new List<AdvantageFramework.ProjectSchedule.Classes.ScheduleTask>();
        //    }

        //    return ScheduleTaskList;
        //}

        //#endregion
        //public bool UpdateAssignmentsCDP(AdvantageFramework.Core.Database.DbContext DbContext, string ClientCode, string DivisionCode, string ProductCode, int JobNumber, short JobComponentNumber, ref string ErrorMessage)
        //{
        //    bool Success = true;
        //    try
        //    {
        //        var SqlParameterClientCode = new System.Data.SqlClient.SqlParameter("@CL_CODE", SqlDbType.VarChar, 6);
        //        var SqlParameterDivisionCode = new System.Data.SqlClient.SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6);
        //        var SqlParameterProductCode = new System.Data.SqlClient.SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6);
        //        var SqlParameterJobNumber = new System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int);
        //        // Dim SqlParameterJobComponentNumber As New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)

        //        SqlParameterClientCode.Value = ClientCode;
        //        SqlParameterDivisionCode.Value = DivisionCode;
        //        SqlParameterProductCode.Value = ProductCode;
        //        SqlParameterJobNumber.Value = JobNumber;
        //        // SqlParameterJobComponentNumber.Value = JobComponentNumber

        //        // DbContext.Database.ExecuteSqlCommand("UPDATE ALERT WITH(ROWLOCK) SET CL_CODE = @CL_CODE, DIV_CODE = @DIV_CODE, PRD_CODE = @PRD_CODE WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;",
        //        // SqlParameterClientCode,
        //        // SqlParameterDivisionCode,
        //        // SqlParameterProductCode,
        //        // SqlParameterJobNumber,
        //        // SqlParameterJobComponentNumber)

        //        DbContext.Database.ExecuteSqlCommand("UPDATE ALERT WITH(ROWLOCK) SET CL_CODE = @CL_CODE, DIV_CODE = @DIV_CODE, PRD_CODE = @PRD_CODE WHERE JOB_NUMBER = @JOB_NUMBER;", SqlParameterClientCode, SqlParameterDivisionCode, SqlParameterProductCode, SqlParameterJobNumber);
        //    }
        //    catch (Exception ex)
        //    {
        //        Success = false;
        //        ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex);
        //    }

        //    return Success;
        //}

        //public AlertController(AdvantageFramework.Security.Session Session) : base(Session)
        //{
        //}

        //public bool EmailExternalReviewers(int AlertID, int DocumentID, int ProofingExternalReviewerID, ref List<string> ErrorMessages)
        //{
        //    bool Success = true;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        using (var SecurityDbContext = new AdvantageFramework.Security.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            try
        //            {
        //                if (AdvantageFramework.Proofing.SendExternalReviewerEmail(this.Session, DbContext, SecurityDbContext, Proofing.Methods.ExternalReviewerEmailAction.SendForReview, AlertID, DocumentID, ProofingExternalReviewerID, ErrorMessages) == true)
        //                {
        //                    Success = true;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                ErrorMessages.Add(AdvantageFramework.StringUtilities.FullErrorToString(ex));
        //                Success = false;
        //            }
        //        }
        //    }

        //    return Success;
        //}

        //public bool AddExternalReviewerToAssignment(int AlertID, int ProofingExternalReviewerID, ref string ErrorMessage)
        //{
        //    bool Success = true;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        try
        //        {
        //            DbContext.Database.ExecuteSqlCommand(string.Format("EXEC [dbo].[advsp_proofing_add_external_reviewer_to_assignment] {0}, {1};", AlertID, ProofingExternalReviewerID));
        //        }
        //        catch (Exception ex)
        //        {
        //            Success = false;
        //        }
        //    }

        //    return Success;
        //}

        //public bool RemoveExternalReviewerFromAssignment(int AlertID, int ProofingExternalReviewerID, ref string ErrorMessage)
        //{
        //    bool Success = true;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        try
        //        {
        //            DbContext.Database.ExecuteSqlCommand(string.Format("EXEC [dbo].[advsp_proofing_remove_external_reviewer_from_assignment] {0}, {1};", AlertID, ProofingExternalReviewerID));
        //        }
        //        catch (Exception ex)
        //        {
        //            Success = false;
        //        }
        //    }

        //    return Success;
        //}

        //public bool RemoveExistingExternalReviewer(int AlertID, int ProofingExternalReviewerID, ref string ErrorMessage)
        //{
        //    bool Removed = true;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Removed = false;
        //        ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex);
        //    }

        //    return Removed;
        //}

        //public AdvantageFramework.Core.Database.Entities.ProofingExternalReviewer SaveExternalReviewer(int AlertID, string Name, string Email, ref string ErrorMessage)
        //{
        //    bool Saved = false;
        //    AdvantageFramework.Core.Database.Entities.ProofingExternalReviewer ProofingExternalReviewer = default;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            AdvantageFramework.Core.Database.Entities.Alert Alert = default;
        //            Alert = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID);
        //            if (Alert is object)
        //            {
        //                ProofingExternalReviewer = new Database.Entities.ProofingExternalReviewer();
        //                ProofingExternalReviewer.Name = Name;
        //                ProofingExternalReviewer.Email = Email;
        //                ProofingExternalReviewer.ClientCode = Alert.ClientCode;
        //                ProofingExternalReviewer.DivisionCode = Alert.DivisionCode;
        //                ProofingExternalReviewer.ProductCode = Alert.ProductCode;
        //                ProofingExternalReviewer.JobNumber = Alert.JobNumber;
        //                ProofingExternalReviewer.JobComponentNumber = Alert.JobComponentNumber;
        //                ProofingExternalReviewer.AddedByUserCode = this.Session.UserCode;
        //                ProofingExternalReviewer.AddedDate = DateTime.Now;
        //                ProofingExternalReviewer.IsActive = true;
        //                Saved = AdvantageFramework.Core.Database.Procedures.ProofingExternalReviewer.Insert(DbContext, ProofingExternalReviewer);
        //                if (Saved == true)
        //                {
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Saved = false;
        //        ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex);
        //        ProofingExternalReviewer = default;
        //    }

        //    return ProofingExternalReviewer;
        //}

        //public bool UploadURL(string AlertID, string Title, string URL, bool UploadDocumentManager, ref string ErrorMessage)
        //{
        //    bool Success = true;
        //    AdvantageFramework.Core.Database.Entities.Alert Alert = default;
        //    AdvantageFramework.Core.Database.Entities.Document Document = default;
        //    AdvantageFramework.Core.Database.Entities.AlertAttachment AlertAttachment = default;
        //    bool SavedToAttachment = false;
        //    var RightNow = DateTime.Now;
        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(URL) == false)
        //        {
        //            if (URL.ToLower().StartsWith("http://") == false && URL.ToLower().StartsWith("https://") == false)
        //            {
        //                URL = "http://" + URL;
        //            }

        //            if (AdvantageFramework.StringUtilities.IsValidURL(URL) == true)
        //            {
        //                if (string.IsNullOrWhiteSpace(Title) == true)
        //                {
        //                    Title = URL;
        //                }

        //                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //                {
        //                    Alert = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID);
        //                    if (Alert is object)
        //                    {
        //                        Document = new Database.Entities.Document();
        //                        Document.FileName = Title;
        //                        Document.FileSystemFileName = URL;
        //                        Document.MIMEType = "URL";
        //                        Document.DocumentTypeID = 6;
        //                        Document.UploadedDate = RightNow;
        //                        if (AdvantageFramework.Core.Database.Procedures.Document.Insert(DbContext, Document) == true)
        //                        {
        //                            AlertAttachment = new Database.Entities.AlertAttachment();
        //                            AlertAttachment.AlertID = Alert.ID;
        //                            AlertAttachment.DocumentID = Document.ID;
        //                            AlertAttachment.HasEmailBeenSent = false;
        //                            AlertAttachment.GeneratedDate = RightNow;
        //                            AlertAttachment.UserCode = this.Session.UserCode;
        //                            SavedToAttachment = AdvantageFramework.Core.Database.Procedures.AlertAttachment.Insert(DbContext, AlertAttachment);
        //                            if (SavedToAttachment == true)
        //                            {
        //                                if (UploadDocumentManager == true)
        //                                {
        //                                    using (var DataContext = new AdvantageFramework.Core.Database.DataContext(this.Session.ConnectionString, this.Session.UserCode))
        //                                    {
        //                                        AddRepositoryReference(DataContext, Alert, Document.ID, ref ErrorMessage);
        //                                    }
        //                                }
        //                            }
        //                            else
        //                            {
        //                                Success = false;
        //                                ErrorMessage = "Failed to save to assignment";
        //                                AdvantageFramework.Core.Database.Procedures.Document.Delete(DbContext, Document);
        //                            }
        //                        }
        //                        else
        //                        {
        //                            Success = false;
        //                            ErrorMessage = "Failed to save URL";
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                Success = false;
        //                ErrorMessage = "Invalid URL.";
        //            }
        //        }
        //        else
        //        {
        //            Success = false;
        //            ErrorMessage = "No URL.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Success = false;
        //        ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex);
        //    }

        //    return Success;
        //}

        //private bool AddRepositoryReference(AdvantageFramework.Core.Database.DataContext DataContext, AdvantageFramework.Core.Database.Entities.Alert Alert, int DocumentID, ref string ErrorMessage)
        //{
        //    bool Added = false;
        //    try
        //    {
        //        if (Alert is object && DocumentID > 0)
        //        {
        //            switch (Alert.AlertLevel.Trim().ToUpper())
        //            {
        //                case "OF":
        //                    {
        //                        if (string.IsNullOrWhiteSpace(Alert.OfficeCode) == false)
        //                        {
        //                            using (var DbContext = new AdvantageFramework.Core.Database.DbContext(DataContext.Connection.ConnectionString, DataContext.UserCode))
        //                            {
        //                                var OfficeDocument = new AdvantageFramework.Core.Database.Entities.OfficeDocument();
        //                                OfficeDocument.DocumentID = DocumentID;
        //                                OfficeDocument.OfficeCode = Alert.OfficeCode;
        //                                if (AdvantageFramework.Core.Database.Procedures.OfficeDocument.Insert(DbContext, OfficeDocument) == false)
        //                                {
        //                                    Added = false;
        //                                    ErrorMessage = "Failed to save to office.";
        //                                }
        //                            }
        //                        }

        //                        break;
        //                    }

        //                case "CL":
        //                    {
        //                        if (string.IsNullOrWhiteSpace(Alert.ClientCode) == false)
        //                        {
        //                            var ClientDocument = new AdvantageFramework.Core.Database.Entities.ClientDocument();
        //                            ClientDocument.DocumentID = DocumentID;
        //                            ClientDocument.ClientCode = Alert.ClientCode;
        //                            if (AdvantageFramework.Core.Database.Procedures.ClientDocument.Insert(DataContext, ClientDocument) == false)
        //                            {
        //                                Added = false;
        //                                ErrorMessage = "Failed to save to client";
        //                            }
        //                        }

        //                        break;
        //                    }

        //                case "DIV":
        //                    {
        //                        if (string.IsNullOrWhiteSpace(Alert.ClientCode) == false && string.IsNullOrWhiteSpace(Alert.DivisionCode) == false)
        //                        {
        //                            var DivisionDocument = new AdvantageFramework.Core.Database.Entities.DivisionDocument();
        //                            DivisionDocument.DocumentID = DocumentID;
        //                            DivisionDocument.ClientCode = Alert.ClientCode;
        //                            DivisionDocument.DivisionCode = Alert.DivisionCode;
        //                            if (AdvantageFramework.Core.Database.Procedures.DivisionDocument.Insert(DataContext, DivisionDocument) == false)
        //                            {
        //                                Added = false;
        //                                ErrorMessage = "Failed to save to division";
        //                            }
        //                        }

        //                        break;
        //                    }

        //                case "PRD":
        //                    {
        //                        if (string.IsNullOrWhiteSpace(Alert.ClientCode) == false && string.IsNullOrWhiteSpace(Alert.DivisionCode) == false && string.IsNullOrWhiteSpace(Alert.ProductCode) == false)
        //                        {
        //                            var ProductDocument = new AdvantageFramework.Core.Database.Entities.ProductDocument();
        //                            ProductDocument.DocumentID = DocumentID;
        //                            ProductDocument.ClientCode = Alert.ClientCode;
        //                            ProductDocument.DivisionCode = Alert.DivisionCode;
        //                            ProductDocument.ProductCode = Alert.ProductCode;
        //                            if (AdvantageFramework.Core.Database.Procedures.ProductDocument.Insert(DataContext, ProductDocument) == false)
        //                            {
        //                                Added = false;
        //                                ErrorMessage = "Failed to save to product";
        //                            }
        //                        }

        //                        break;
        //                    }

        //                case "JO":
        //                    {
        //                        if (Alert.JobNumber is object && Alert.JobNumber > 0)
        //                        {
        //                            AdvantageFramework.Core.Database.Entities.JobDocument JobDocument = default;
        //                            JobDocument = new Database.Entities.JobDocument();
        //                            JobDocument.DocumentID = DocumentID;
        //                            JobDocument.JobNumber = Alert.JobNumber;
        //                            if (AdvantageFramework.Core.Database.Procedures.JobDocument.Insert(DataContext, JobDocument) == false)
        //                            {
        //                                Added = false;
        //                                ErrorMessage = "Failed to save to component";
        //                            }
        //                        }

        //                        break;
        //                    }

        //                case "JC":
        //                    {
        //                        if (Alert.JobNumber is object && Alert.JobComponentNumber is object && Alert.JobNumber > 0 && Alert.JobComponentNumber > 0)
        //                        {
        //                            AdvantageFramework.Core.Database.Entities.JobComponentDocument JobComponentDocument = default;
        //                            JobComponentDocument = new Database.Entities.JobComponentDocument();
        //                            JobComponentDocument.DocumentID = DocumentID;
        //                            JobComponentDocument.JobNumber = Alert.JobNumber;
        //                            JobComponentDocument.JobComponentNumber = Alert.JobComponentNumber;
        //                            if (AdvantageFramework.Core.Database.Procedures.JobComponentDocument.Insert(DataContext, JobComponentDocument) == false)
        //                            {
        //                                Added = false;
        //                                ErrorMessage = "Failed to save to component";
        //                            }
        //                        }

        //                        break;
        //                    }

        //                case "BRD":
        //                case "PST":
        //                    {
        //                        if (Alert.JobNumber is object && Alert.JobComponentNumber is object && Alert.TaskSequenceNumber is object && Alert.JobNumber > 0 && Alert.JobComponentNumber > 0 && Alert.TaskSequenceNumber > -1)
        //                        {
        //                            AdvantageFramework.Core.Database.Entities.JobComponentTaskDocument JobComponentTaskDocument = default;
        //                            JobComponentTaskDocument = new Database.Entities.JobComponentTaskDocument();
        //                            JobComponentTaskDocument.DocumentID = DocumentID;
        //                            JobComponentTaskDocument.JobNumber = Alert.JobNumber;
        //                            JobComponentTaskDocument.JobComponentNumber = Alert.JobComponentNumber;
        //                            JobComponentTaskDocument.SequenceNumber = Alert.TaskSequenceNumber;
        //                            if (AdvantageFramework.Core.Database.Procedures.JobComponentTaskDocument.Insert(DataContext, JobComponentTaskDocument) == false)
        //                            {
        //                                Added = false;
        //                                ErrorMessage = "Failed to save to component";
        //                            }
        //                        }

        //                        break;
        //                    }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex);
        //        Added = false;
        //    }

        //    return Added;
        //}

        //public bool AddAutoComment(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, string EmployeeCode, int CommentType, int AlertTemplateID, int AlertStateID)
        //{
        //    var Added = default(bool);
        //    try
        //    {
        //        DbContext.Database.ExecuteSqlCommand(string.Format("EXEC [dbo].[usp_wv_ALERT_NOTIFY_AUTO_COMMENT] '{0}', {1}, '{2}', {3}, {4}, {5};", DbContext.UserCode, AlertID, EmployeeCode, CommentType, AlertStateID, AlertTemplateID));
        //    }
        //    catch (Exception ex)
        //    {
        //        Added = false;
        //    }

        //    return Added;
        //}

        //public string GetDefaultSubjectType()
        //{
        //    string DefaultSubjectType = string.Empty;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            DefaultSubjectType = DbContext.Database.SqlQuery<string>(string.Format("SELECT CAST(ISNULL(AGY_SETTINGS_VALUE, '') AS VARCHAR) FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'ALRT_ASSGN_DFLT_SUB';")).SingleOrDefault;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        DefaultSubjectType = string.Empty;
        //    }

        //    return DefaultSubjectType;
        //}

        //public AdvantageFramework.ViewModels.Desktop.AlertView LoadAlertView(int AlertID, int CDPContactID = 0, decimal Offset = 0m, int SprintID = 0, bool IsClientPortal = false)
        //{

        //    // objects
        //    AdvantageFramework.ViewModels.Desktop.AlertView AlertView = default;
        //    AdvantageFramework.DTO.Desktop.Alert Alert = default;
        //    string ErrorMessage = string.Empty;
        //    AlertView = new AdvantageFramework.ViewModels.Desktop.AlertView();
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        Alert = LoadAlert(DbContext, AlertID, CDPContactID, Offset, SprintID, IsClientPortal);
        //    }

        //    AlertView.Alert = Alert;
        //    return AlertView;
        //}

        //public AdvantageFramework.DTO.Desktop.Alert LoadAlert(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, int CDPContactID = 0, decimal Offset = 0m, int SprintID = 0, bool IsClientPortal = false)
        //{

        //    // objects
        //    AdvantageFramework.DTO.Desktop.Alert Alert = default;
        //    System.Data.SqlClient.SqlParameter AlertIDSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter EmployeeCodeSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter CDPContactIDSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter OffsetSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter SprintIDSqlParameter = null;
        //    AlertIDSqlParameter = new System.Data.SqlClient.SqlParameter("AlertID", AlertID);
        //    if (IsClientPortal == true)
        //    {
        //        EmployeeCodeSqlParameter = new System.Data.SqlClient.SqlParameter("EmployeeCode", "");
        //    }
        //    else
        //    {
        //        EmployeeCodeSqlParameter = new System.Data.SqlClient.SqlParameter("EmployeeCode", this.Session.User.EmployeeCode);
        //    }

        //    CDPContactIDSqlParameter = new System.Data.SqlClient.SqlParameter("CDPContactID", CDPContactID);
        //    OffsetSqlParameter = new System.Data.SqlClient.SqlParameter("Offset", Offset);
        //    SprintIDSqlParameter = new System.Data.SqlClient.SqlParameter("SprintID", SprintID);
        //    try
        //    {
        //        Alert = DbContext.Database.SqlQuery<AdvantageFramework.DTO.Desktop.Alert>("EXEC [dbo].[advsp_alert_get] @AlertID, @EmployeeCode, @CDPContactID, @Offset, @SprintID", AlertIDSqlParameter, EmployeeCodeSqlParameter, CDPContactIDSqlParameter, OffsetSqlParameter, SprintIDSqlParameter).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        Alert = default;
        //    }

        //    // 'Moved into the advsp_alert_get proc
        //    // Try

        //    // If Alert IsNot Nothing Then

        //    // If Alert.AlertLevel = "BRD" OrElse Alert.AlertLevel = "PST" Then

        //    // AdvantageFramework.ProjectSchedule.MarkTaskRead(DbContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, Me.Session.User.EmployeeCode)

        //    // End If

        //    // End If

        //    // Catch ex As Exception
        //    // End Try

        //    return Alert;
        //}

        //public AdvantageFramework.ViewModels.Desktop.AlertSettingsViewModel LoadAlertSettings()
        //{
        //    var AlertSettings = new AdvantageFramework.ViewModels.Desktop.AlertSettingsViewModel();
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        LoadAppVars(DbContext, ref AlertSettings.AutoClose, ref AlertSettings.WidgetLayout, ref AlertSettings.HideSystemComments, ref AlertSettings.DetailsExpanded, ref AlertSettings.ShowChecklistsOnCards, ref AlertSettings.UploadDocumentManager);
        //    }

        //    return AlertSettings;
        //}

        //public AdvantageFramework.DTO.Desktop.Alert LoadAlert(int AlertID, int CDPContactID = 0, decimal Offset = 0m, int SprintID = 0)
        //{
        //    AdvantageFramework.DTO.Desktop.Alert LoadAlertRet = default;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        LoadAlertRet = LoadAlert(DbContext, AlertID, CDPContactID, Offset, SprintID);
        //    }

        //    return LoadAlertRet;
        //}

        //public bool SaveAssignment(AdvantageFramework.DTO.Desktop.Alert Alert)
        //{
        //    bool SaveAssignmentRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.Alert AlertEntity = default;
        //    AdvantageFramework.Core.Database.Entities.JobComponentTask JobComponentTask = default;
        //    AdvantageFramework.Core.Database.Entities.SprintDetail SprintDetail = default;
        //    AdvantageFramework.Core.Database.Entities.BoardDetail CurrentBoardDetail = default;
        //    AdvantageFramework.Core.Database.Entities.BoardDetail NewBoardDetail = default;
        //    List<AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard> TaskAssignmentCards = null;
        //    bool HasVersion = false;
        //    int OldVersionID = default;
        //    int SelectedVersionID = default;
        //    int OldBuildID = default;
        //    int SelectedBuildID = default;
        //    bool Saved = false;
        //    int? SprintDetailSequenceNumber = default;
        //    bool IsChangingColumns = false;
        //    int CurrentAlertBoardStateID = 0;
        //    int CurrentBoardColumnID = 0;
        //    int NewBoardColumnID = 0;
        //    bool IsCompleting = false;
        //    bool StartDueChanged = false;
        //    bool HoursChanged = false;
        //    bool UpdateSprint = false;
        //    bool UpdateDays = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            AlertEntity = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID);
        //            if (AlertEntity is object)
        //            {
        //                if ((AlertEntity.AssignmentCompleted is null || AlertEntity.AssignmentCompleted == false) && Alert.CompletedDate is object)
        //                {
        //                    IsCompleting = true;
        //                }

        //                if (AlertEntity.BoardStateID != Alert.BoardStateID && UpdateSprint == false)
        //                    UpdateSprint = true;
        //                if (AlertEntity.BoardStateID is object)
        //                    CurrentAlertBoardStateID = AlertEntity.BoardStateID;
        //                if (AlertEntity.Subject != Alert.Subject && UpdateSprint == false)
        //                    UpdateSprint = true;
        //                AlertEntity.Subject = Alert.Subject;
        //                AlertEntity.Body = string.IsNullOrWhiteSpace(Alert.EmailBody) == true ? "" : Alert.EmailBody;
        //                AlertEntity.EmailBody = string.IsNullOrWhiteSpace(Alert.EmailBody) == true ? "" : Alert.EmailBody;
        //                if (AlertEntity.PriorityLevel != Alert.PriorityLevel && UpdateSprint == false)
        //                    UpdateSprint = true;
        //                AlertEntity.PriorityLevel = Alert.PriorityLevel;
        //                try
        //                {
        //                    if (AlertEntity.StartDate != Alert.StartDate || AlertEntity.DueDate != Alert.DueDate)
        //                    {
        //                        StartDueChanged = true;
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                }

        //                try
        //                {
        //                    if (Alert.IsTask)
        //                    {
        //                        if (Alert.JobHours is object & Alert.HoursAllowed is object && AlertEntity.HoursAllowed is null)
        //                        {
        //                            HoursChanged = true;
        //                        }
        //                        else if (Alert.JobHours is null & Alert.HoursAllowed is null && AlertEntity.HoursAllowed is object)
        //                        {
        //                            HoursChanged = true;
        //                        }
        //                        else if (Alert.JobHours is object & Alert.HoursAllowed is object && AlertEntity.HoursAllowed is object)
        //                        {
        //                            if (Alert.HoursAllowed != AlertEntity.HoursAllowed)
        //                            {
        //                                HoursChanged = true;
        //                            }
        //                        }
        //                    }
        //                    else if (Alert.HoursAllowed is object && AlertEntity.HoursAllowed is null)
        //                    {
        //                        HoursChanged = true;
        //                    }
        //                    else if (Alert.HoursAllowed is null && AlertEntity.HoursAllowed is object)
        //                    {
        //                        HoursChanged = true;
        //                    }
        //                    else if (Alert.HoursAllowed is object && AlertEntity.HoursAllowed is object)
        //                    {
        //                        if (Alert.HoursAllowed != AlertEntity.HoursAllowed)
        //                        {
        //                            HoursChanged = true;
        //                        }
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                }

        //                if (HoursChanged == true)
        //                {
        //                    AlertEntity.HoursAllowed = Alert.HoursAllowed;
        //                }

        //                if (Alert.IsTask && (AlertEntity.StartDate != Alert.StartDate || AlertEntity.DueDate != Alert.DueDate))
        //                {
        //                    UpdateDays = true;
        //                }

        //                if (AlertEntity.StartDate != Alert.StartDate && UpdateSprint == false)
        //                    UpdateSprint = true;
        //                AlertEntity.StartDate = Alert.StartDate;
        //                if (AlertEntity.DueDate != Alert.DueDate && UpdateSprint == false)
        //                    UpdateSprint = true;
        //                AlertEntity.DueDate = Alert.DueDate;
        //                if (AlertEntity.TimeDue != Alert.TimeDue && UpdateSprint == false)
        //                    UpdateSprint = true;
        //                AlertEntity.TimeDue = Alert.TimeDue;
        //                AlertEntity.AlertCategoryID = Alert.AlertCategoryID;
        //                if (Alert.BoardStateID is object && Alert.BoardStateID <= 0)
        //                    Alert.BoardStateID = null;
        //                if (AlertEntity.BoardStateID != Alert.BoardStateID && UpdateSprint == false)
        //                    UpdateSprint = true;
        //                AlertEntity.BoardStateID = Alert.BoardStateID;
        //                if (AlertEntity.BoardStateID is null || AlertEntity.BoardStateID == -1)
        //                    AlertEntity.BacklogSequenceNumber = null;
        //                AlertEntity.IsDraft = false;
        //                if (!AlertEntity.TaskSequenceNumber.HasValue)
        //                    AlertEntity.HoursAllowed = Alert.HoursAllowed;

        //                // If Alert.BoardHeaderID Is Nothing Then Alert.BoardHeaderID = 0
        //                // If Alert.BoardStateID Is Nothing Then Alert.BoardStateID = 0
        //                // If AlertEntity.BoardStateID Is Nothing Then Alert.BoardStateID = 0

        //                if (AlertEntity.BoardStateID is object && AlertEntity.BoardStateID > 0)
        //                {
        //                    if (Alert.SprintID is null)
        //                        Alert.SprintID = 0;
        //                    try
        //                    {
        //                        if (Alert.SprintID is object && Alert.SprintID > 0)
        //                        {
        //                            SprintDetail = (from SprintDtl in AdvantageFramework.Core.Database.Procedures.SprintDetail.LoadBySprintID(DbContext, Alert.SprintID)
        //                                            where SprintDtl.AlertID == Alert.ID
        //                                            select SprintDtl).FirstOrDefault;
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        SprintDetail = default;
        //                    }

        //                    if (SprintDetail is null)
        //                    {
        //                        try
        //                        {
        //                            SprintDetail = AdvantageFramework.Core.Database.Procedures.SprintDetail.LoadBySprintIDAlertID(DbContext, Alert.SprintID, Alert.ID);
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            SprintDetail = default;
        //                        }
        //                    }

        //                    if (Alert.BoardHeaderID is object && Alert.BoardHeaderID > 0 && Alert.BoardStateID is object && Alert.BoardStateID > 0)
        //                    {
        //                        NewBoardDetail = AdvantageFramework.Core.Database.Procedures.BoardDetail.LoadByBoardHeaderIDandStateID(DbContext, Alert.BoardHeaderID, Alert.BoardStateID);
        //                    }

        //                    if (CurrentAlertBoardStateID > 0)
        //                    {
        //                        CurrentBoardDetail = AdvantageFramework.Core.Database.Procedures.BoardDetail.LoadByBoardHeaderIDandStateID(DbContext, Alert.BoardHeaderID, CurrentAlertBoardStateID);
        //                    }

        //                    if (SprintDetail is null && Alert.SprintID is object && Alert.SprintID > 0)
        //                    {
        //                        if (AlertEntity.BoardStateID is object && AlertEntity.BoardStateID > 0)
        //                        {
        //                            SprintDetail = new Database.Entities.SprintDetail();
        //                            SprintDetail.SprintHeaderID = Alert.SprintID;
        //                            SprintDetail.AlertID = Alert.ID;
        //                            AdvantageFramework.Core.Database.Procedures.SprintDetail.Insert(DbContext, SprintDetail);
        //                        }
        //                    }

        //                    if (SprintDetail is object && Alert.BoardStateID is null)
        //                    {
        //                        if (AdvantageFramework.Core.Database.Procedures.SprintDetail.Delete(DbContext, SprintDetail))
        //                        {
        //                            SprintDetail = default;
        //                        }
        //                    }

        //                    if (CurrentBoardDetail is object)
        //                        CurrentBoardColumnID = CurrentBoardDetail.BoardColumnID;
        //                    if (NewBoardDetail is object)
        //                        NewBoardColumnID = NewBoardDetail.BoardColumnID;
        //                    if (NewBoardColumnID != CurrentBoardColumnID)
        //                        IsChangingColumns = true;
        //                    if (IsChangingColumns)
        //                    {
        //                        if (NewBoardDetail is object)
        //                        {
        //                            TaskAssignmentCards = AdvantageFramework.ProjectManagement.Agile.LoadBoardTaskAssignmentCards(DbContext, Alert.SprintID, Session.UserCode, AdvantageFramework.ProjectManagement.Agile.Methods.BacklogSort.None).ToList;
        //                            try
        //                            {
        //                                SprintDetailSequenceNumber = (int?)Operators.AddObject((from Item in TaskAssignmentCards
        //                                                                                        where Operators.ConditionalCompareObjectEqual(Item.BoardColumnID, NewBoardColumnID, false) && !Operators.ConditionalCompareObjectEqual(Item.AlertID, Alert.ID, false)
        //                                                                                        select Item.SequenceNumber.GetValueOrDefault((object)0)).Max(), 1);
        //                            }
        //                            catch (Exception ex)
        //                            {
        //                            }
        //                        }

        //                        try
        //                        {
        //                            if (SprintDetailSequenceNumber == 0 == true)
        //                                SprintDetailSequenceNumber = default;
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            SprintDetailSequenceNumber = default;
        //                        }
        //                    }

        //                    if (SprintDetail is object)
        //                    {
        //                        if (IsChangingColumns == true && SprintDetail.SequenceNumber is null)
        //                        {
        //                            SprintDetail.SequenceNumber = SprintDetailSequenceNumber;
        //                        }

        //                        if (SprintDetail.AlertID is object && SprintDetail.AlertID > 0)
        //                        {
        //                            if (IsChangingColumns)
        //                            {
        //                                AdvantageFramework.ProjectManagement.Agile.MoveBoardItem(this.Session, Alert.BoardStateID, SprintDetail, CurrentBoardColumnID);
        //                            }
        //                        }

        //                        AdvantageFramework.Core.Database.Procedures.SprintDetail.Update(DbContext, SprintDetail);
        //                    }
        //                }
        //                else
        //                {
        //                    try
        //                    {
        //                        if (Alert.SprintID is object && Alert.SprintID > 0)
        //                        {
        //                            SprintDetail = (from SprintDtl in AdvantageFramework.Core.Database.Procedures.SprintDetail.LoadBySprintID(DbContext, Alert.SprintID)
        //                                            where SprintDtl.AlertID == Alert.ID
        //                                            select SprintDtl).FirstOrDefault;
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        SprintDetail = default;
        //                    }

        //                    if (SprintDetail is null)
        //                    {
        //                        try
        //                        {
        //                            SprintDetail = AdvantageFramework.Core.Database.Procedures.SprintDetail.LoadBySprintIDAlertID(DbContext, Alert.SprintID, Alert.ID);
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            SprintDetail = default;
        //                        }
        //                    }

        //                    if (AdvantageFramework.Core.Database.Procedures.SprintDetail.Delete(DbContext, SprintDetail))
        //                    {
        //                        SprintDetail = default;
        //                    }
        //                }

        //                if (!string.IsNullOrWhiteSpace(Alert.Version) && Information.IsNumeric(Alert.Version))
        //                    SelectedVersionID = Alert.Version;
        //                if (!string.IsNullOrWhiteSpace(AlertEntity.Version) && Information.IsNumeric(AlertEntity.Version))
        //                    OldVersionID = AlertEntity.Version;
        //                if (OldVersionID != SelectedVersionID)
        //                {
        //                    if (SelectedVersionID > 0)
        //                    {
        //                        AlertEntity.Version = SelectedVersionID.ToString();
        //                    }
        //                    else
        //                    {
        //                        AlertEntity.Version = "";
        //                    }
        //                }

        //                if (OldVersionID > 0 || SelectedVersionID > 0)
        //                {
        //                    HasVersion = true;
        //                }

        //                if (HasVersion)
        //                {
        //                    if (!string.IsNullOrWhiteSpace(Alert.Build) && Information.IsNumeric(Alert.Build))
        //                    {
        //                        SelectedBuildID = Alert.Build;
        //                    }

        //                    if (!string.IsNullOrWhiteSpace(AlertEntity.Build) && Information.IsNumeric(AlertEntity.Build))
        //                    {
        //                        OldBuildID = AlertEntity.Build;
        //                    }

        //                    if (OldBuildID != SelectedBuildID)
        //                    {
        //                        if (SelectedBuildID > 0)
        //                        {
        //                            AlertEntity.Build = SelectedBuildID.ToString();
        //                        }
        //                        else
        //                        {
        //                            AlertEntity.Build = "";
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    AlertEntity.Build = "";
        //                }

        //                if (HoursChanged == true)
        //                {
        //                    UpdateRecipientHours(DbContext, AlertEntity.ID, AlertEntity.HoursAllowed, "");
        //                }

        //                Saved = AdvantageFramework.Core.Database.Procedures.Alert.Update(DbContext, AlertEntity);
        //                if (Saved == true)
        //                {
        //                    if (Alert.IsWorkItem == true && Alert.TaskSequenceNumber.HasValue && Alert.AlertLevel == "BRD")
        //                    {
        //                        JobComponentTask = AdvantageFramework.Core.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, AlertEntity.JobNumber, AlertEntity.JobComponentNumber, AlertEntity.TaskSequenceNumber);
        //                        if (JobComponentTask is object)
        //                        {
        //                            if (JobComponentTask.CompletedDate is null && Alert.CompletedDate is object)
        //                            {
        //                                IsCompleting = true;
        //                            }

        //                            if (string.IsNullOrWhiteSpace(Alert.TaskFunctionComment) == false)
        //                            {
        //                                JobComponentTask.Comment = Alert.TaskFunctionComment;
        //                            }
        //                            else
        //                            {
        //                                JobComponentTask.Comment = null;
        //                            }

        //                            JobComponentTask.StartDate = Alert.StartDate;
        //                            JobComponentTask.DueDate = Alert.DueDate;
        //                            JobComponentTask.DueTime = Alert.TimeDue;
        //                            if (UpdateDays == true)
        //                            {
        //                                try
        //                                {
        //                                    int daysdiff = 0;
        //                                    int wkenddays = 0;
        //                                    daysdiff = Conversions.ToDate(Alert.DueDate).Date.Subtract(Conversions.ToDate(Alert.StartDate).Date).Days;
        //                                    for (int i = 1, loopTo = daysdiff; i <= loopTo; i++)
        //                                    {
        //                                        if (Conversions.ToDate(Alert.StartDate).Date.AddDays(i).DayOfWeek == DayOfWeek.Sunday)
        //                                        {
        //                                            wkenddays += 1;
        //                                        }

        //                                        if (Conversions.ToDate(Alert.StartDate).Date.AddDays(i).DayOfWeek == DayOfWeek.Saturday)
        //                                        {
        //                                            wkenddays += 1;
        //                                        }
        //                                    }

        //                                    JobComponentTask.Days = daysdiff + 1 - wkenddays;
        //                                }
        //                                catch (Exception ex)
        //                                {
        //                                }
        //                            }

        //                            if (IsCompleting == false)
        //                            {
        //                                JobComponentTask.CompletedDate = Alert.CompletedDate;
        //                            }

        //                            JobComponentTask.StatusCode = Alert.TaskStatusCode;
        //                            if (AdvantageFramework.Core.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask) == true)
        //                            {
        //                                if (IsCompleting == true)
        //                                {
        //                                    if (this.CompleteAlert(AlertEntity).Success == true)
        //                                    {
        //                                        if (AdvantageFramework.ProjectSchedule.CompleteTask(DbContext, JobComponentTask, this.Session.User.EmployeeCode, false) == true)
        //                                        {
        //                                            JobComponentTask.CompletedDate = Alert.CompletedDate;
        //                                            AdvantageFramework.Core.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask);
        //                                        }
        //                                    }

        //                                    UpdateSprint = true;
        //                                }
        //                            }
        //                        }
        //                    }

        //                    // If Alert.IsWorkItem = True Then

        //                    // Dim StateChanged As Boolean = False
        //                    // Dim AssigneesChanged As Boolean = False

        //                    // AdvantageFramework.AlertSystem.AssignmentHasAssignmentChanges(DbContext, Alert, AlertEntity, StateChanged, AssigneesChanged)

        //                    // End If

        //                }

        //                if (StartDueChanged == true)
        //                {
        //                    var BackgroundWork = new AdvantageFramework.ProjectManagement.Agile.Classes.WorkItemAsync(this.Session);
        //                    BackgroundWork.AlertID = Alert.ID;
        //                    BackgroundWork.CheckSprintEmployeeRecordsWithCheck();
        //                }

        //                AdvantageFramework.Controller.ProjectManagement.AgileController.AddSprintEmployeeRecords(DbContext, Alert.ID);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Saved = false;
        //    }
        //    finally
        //    {
        //        SaveAssignmentRet = Saved;
        //    }

        //    return SaveAssignmentRet;
        //}

        //public bool CreateAssignment(AdvantageFramework.DTO.Desktop.Alert Alert, bool TakeOutOfDraftStatus, bool UploadToRepository, bool UploadToProofHQ, [Optional, DefaultParameterValue("")] ref string Message)
        //{
        //    bool CreateAssignmentRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.Alert AlertEntity = default;
        //    var Errors = new List<string>();
        //    AdvantageFramework.Core.Database.Entities.JobComponentTask JobComponentTask = default;
        //    AdvantageFramework.Core.Database.Entities.Task Task = default;
        //    AdvantageFramework.Core.Database.Entities.SprintDetail SprintDetail = default;
        //    bool Created = false;
        //    bool IsBoardTask = false;
        //    bool IsNewAssignment = false;
        //    bool IsRouted = false;
        //    string DocumentErrorMessage = string.Empty;
        //    // Dim AlertTemplate As AdvantageFramework.Core.Database.Entities.AlertAssignmentTemplate = Nothing
        //    bool MultiRouteTemplate = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            if (string.IsNullOrWhiteSpace(Alert.Subject))
        //            {
        //                Errors.Add("Please enter a subject.");
        //            }

        //            if (Alert.StartDate.HasValue && Alert.DueDate.HasValue)
        //            {
        //                if (Alert.StartDate.Value.Date > Alert.DueDate.Value.Date)
        //                {
        //                    Errors.Add("Due date is before start date.");
        //                }
        //            }

        //            if (Alert.AlertTypeID <= 0)
        //            {
        //                Errors.Add("Please select a type.");
        //            }

        //            if (Alert.JobNumber.GetValueOrDefault(0) > 0 && Alert.JobComponentNumber.GetValueOrDefault(0) > 0 && Alert.AlertCategoryID == 71)
        //            {
        //                if (AdvantageFramework.Core.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, Alert.JobNumber, Alert.JobComponentNumber) is null)
        //                {
        //                    Errors.Add("Cannot add task because the schedule has not been created.");
        //                }
        //            }

        //            if (Errors.Count == 0)
        //            {
        //                IsBoardTask = IsBoardTaskAlert(Alert.AlertCategoryID);
        //                if (!IsBoardTask)
        //                {
        //                    if (Alert.ID > 0)
        //                    {
        //                        AlertEntity = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID);
        //                    }
        //                    else
        //                    {
        //                        AlertEntity = new AdvantageFramework.Core.Database.Entities.Alert();
        //                        IsNewAssignment = true;
        //                    }

        //                    if (Alert.AlertAssignmentTemplateID is object && Alert.AlertAssignmentTemplateID > 0 && Alert.AlertStateID is object && Alert.AlertStateID > 0)
        //                    {
        //                        IsRouted = true;
        //                        AlertEntity.AlertAssignmentTemplateID = Alert.AlertAssignmentTemplateID;
        //                        AlertEntity.AlertStateID = Alert.AlertStateID;
        //                    }

        //                    if (AlertEntity is object)
        //                    {
        //                        if (!string.IsNullOrWhiteSpace(Alert.OfficeCode))
        //                            AlertEntity.OfficeCode = Alert.OfficeCode;
        //                        if (!string.IsNullOrWhiteSpace(Alert.ClientCode))
        //                            AlertEntity.ClientCode = Alert.ClientCode;
        //                        if (!string.IsNullOrWhiteSpace(Alert.DivisionCode))
        //                            AlertEntity.DivisionCode = Alert.DivisionCode;
        //                        if (!string.IsNullOrWhiteSpace(Alert.ProductCode))
        //                            AlertEntity.ProductCode = Alert.ProductCode;
        //                        if (Alert.JobNumber.GetValueOrDefault(0) > 0)
        //                        {
        //                            AlertEntity.JobNumber = Alert.JobNumber;
        //                            if (Alert.JobComponentNumber.GetValueOrDefault(0) > 0)
        //                                AlertEntity.JobComponentNumber = Alert.JobComponentNumber;
        //                            if (Alert.TaskSequenceNumber.GetValueOrDefault(-1) > -1)
        //                                AlertEntity.TaskSequenceNumber = Alert.TaskSequenceNumber;
        //                            if (string.IsNullOrWhiteSpace(AlertEntity.OfficeCode) || string.IsNullOrWhiteSpace(AlertEntity.ClientCode) || string.IsNullOrWhiteSpace(AlertEntity.DivisionCode) || string.IsNullOrWhiteSpace(AlertEntity.ProductCode))
        //                            {
        //                                {
        //                                    var withBlock = AdvantageFramework.Core.Database.Procedures.Job.LoadByJobNumber(DbContext, AlertEntity.JobNumber);
        //                                    AlertEntity.OfficeCode = withBlock.OfficeCode;
        //                                    AlertEntity.ClientCode = withBlock.ClientCode;
        //                                    AlertEntity.DivisionCode = withBlock.DivisionCode;
        //                                    AlertEntity.ProductCode = withBlock.ProductCode;
        //                                }
        //                            }
        //                        }

        //                        if (!string.IsNullOrWhiteSpace(Alert.Version) && Information.IsNumeric(Alert.Version))
        //                        {
        //                            if (LoadSoftwareVersionsByJobComponent(AlertEntity.JobNumber.GetValueOrDefault(0), AlertEntity.JobComponentNumber.GetValueOrDefault(0), AlertEntity.Version).Where(jv => Operators.ConditionalCompareObjectEqual(jv.ID, Alert.Version, false)).Any)
        //                            {
        //                                AlertEntity.Version = Alert.Version;
        //                                if (LoadSoftwareBuildsByVersion(AlertEntity.Version).Where(sb => Operators.ConditionalCompareObjectEqual(sb.ID, Alert.Build, false)).Any)
        //                                {
        //                                    AlertEntity.Build = Alert.Build;
        //                                }
        //                            }
        //                        }

        //                        AlertEntity.AlertTypeID = Alert.AlertTypeID;
        //                        AlertEntity.AlertCategoryID = Alert.AlertCategoryID;
        //                        AlertEntity.Subject = Alert.Subject;
        //                        AlertEntity.HoursAllowed = Alert.HoursAllowed;
        //                        AlertEntity.Body = Alert.EmailBody;
        //                        AlertEntity.EmailBody = Alert.EmailBody;
        //                        AlertEntity.AssignedEmployeeEmployeeCode = null;
        //                        AlertEntity.AssignedEmployeeFullName = null;
        //                        if (Alert.StartDate.HasValue)
        //                            AlertEntity.StartDate = Alert.StartDate.Value.Date;
        //                        if (Alert.DueDate.HasValue)
        //                            AlertEntity.DueDate = Alert.DueDate.Value.Date;
        //                        if (!string.IsNullOrWhiteSpace(Alert.TimeDue))
        //                            AlertEntity.TimeDue = Alert.TimeDue;
        //                        AlertEntity.IsWorkItem = Alert.IsWorkItem;
        //                        if (Alert.SprintID is object && Alert.SprintID > 0)
        //                            TakeOutOfDraftStatus = true;
        //                        AlertEntity.IsDraft = false;
        //                    }
        //                }
        //                else
        //                {
        //                    JobComponentTask = new AdvantageFramework.Core.Database.Entities.JobComponentTask();
        //                    JobComponentTask.JobNumber = Alert.JobNumber;
        //                    JobComponentTask.JobComponentNumber = Alert.JobComponentNumber;
        //                    JobComponentTask.Hours = Alert.HoursAllowed;
        //                    JobComponentTask.CompletedDate = Alert.CompletedDate;
        //                    if (!string.IsNullOrWhiteSpace(Alert.TimeDue))
        //                    {
        //                        JobComponentTask.DueTime = Alert.TimeDue;
        //                    }

        //                    if (Alert.StartDate.HasValue)
        //                    {
        //                        JobComponentTask.StartDate = Alert.StartDate.Value.Date;
        //                    }

        //                    if (Alert.DueDate.HasValue)
        //                    {
        //                        JobComponentTask.DueDate = Alert.DueDate.Value.Date;
        //                    }

        //                    if (!string.IsNullOrWhiteSpace(Alert.TaskCode))
        //                    {
        //                        Task = AdvantageFramework.Core.Database.Procedures.Task.LoadByTaskCode(DbContext, Alert.TaskCode);
        //                    }

        //                    if (Task is object)
        //                    {
        //                        JobComponentTask.TaskCode = Task.Code;
        //                        JobComponentTask.Description = Task.Description;
        //                        JobComponentTask.FuctionCode = Task.FunctionCode;
        //                    }
        //                    else
        //                    {
        //                        JobComponentTask.Description = Alert.Subject;
        //                    }

        //                    if (AdvantageFramework.Core.Database.Procedures.JobComponentTask.Insert(DbContext, JobComponentTask))
        //                    {
        //                        AlertEntity = (from Item in AdvantageFramework.Core.Database.Procedures.Alert.Load(DbContext)
        //                                       where Item.JobNumber == JobComponentTask.JobNumber && Item.JobComponentNumber == JobComponentTask.JobComponentNumber && Item.TaskSequenceNumber == JobComponentTask.SequenceNumber
        //                                       select Item).SingleOrDefault;
        //                    }
        //                }

        //                if (AlertEntity is object)
        //                {
        //                    AlertEntity.BoardStateID = Alert.BoardStateID;
        //                    AlertEntity.GeneratedDate = DateAndTime.Now;
        //                    AlertEntity.LastUpdated = DateAndTime.Now;
        //                    AlertEntity.UserCode = Session.UserCode;
        //                    AlertEntity.LastUpdatedUserCode = Session.UserCode;
        //                    AlertEntity.LastUpdatedFullName = Session.EmployeeName;
        //                    AlertEntity.PriorityLevel = Alert.PriorityLevel;
        //                    AlertEntity.AlertLevel = Alert.AlertLevel;
        //                    AlertEntity.EmployeeCode = this.Session.User.EmployeeCode;
        //                    AlertEntity.HoursAllowed = Alert.HoursAllowed;
        //                    if (JobComponentTask is object)
        //                    {
        //                        AlertEntity.Body = Alert.EmailBody;
        //                        AlertEntity.EmailBody = Alert.EmailBody;
        //                    }

        //                    if (AlertEntity.ID > 0 || IsBoardTask == true)
        //                    {
        //                        Created = AdvantageFramework.Core.Database.Procedures.Alert.Update(DbContext, AlertEntity);
        //                    }
        //                    else
        //                    {
        //                        if (AlertEntity.IsWorkItem.GetValueOrDefault(false) == true && AlertEntity.JobNumber.GetValueOrDefault(0) > 0 && AlertEntity.JobComponentNumber.GetValueOrDefault(0) > 0)
        //                        {
        //                            AlertEntity.AlertSequenceNumber = DbContext.Database.SqlQuery<int>(string.Format("SELECT (ISNULL(MAX(ALERT_SEQ_NBR),0) + 1) FROM ALERT WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1};", AlertEntity.JobNumber, AlertEntity.JobComponentNumber)).SingleOrDefault;
        //                        }

        //                        Created = AdvantageFramework.Core.Database.Procedures.Alert.Insert(DbContext, AlertEntity);
        //                    }
        //                }

        //                if (Created == true)
        //                {
        //                    try
        //                    {
        //                        if (AlertEntity.AlertAssignmentTemplateID is object && AlertEntity.AlertAssignmentTemplateID > 0 && AlertEntity.AlertStateID is object && AlertEntity.AlertStateID > 0)
        //                        {
        //                            string ErrorMessage = string.Empty;
        //                            if (AdvantageFramework.AlertSystem.SaveTemplateToAssignment(DbContext, AlertEntity.ID, AlertEntity.AlertAssignmentTemplateID, ErrorMessage) == false)
        //                            {
        //                                Errors.Add(ErrorMessage);
        //                            }
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                    }

        //                    Alert.ID = AlertEntity.ID;
        //                    if (Alert.UploadedFiles is object && Alert.UploadedFiles.Count > 0)
        //                    {
        //                        SaveAttachments(AlertEntity, Alert.UploadedFiles, UploadToRepository, UploadToProofHQ, DocumentErrorMessage, default);
        //                        if (string.IsNullOrWhiteSpace(DocumentErrorMessage) == false)
        //                        {
        //                            Errors.Add(DocumentErrorMessage);
        //                        }
        //                    }

        //                    if (Alert.LinkedDocuments is object && Alert.LinkedDocuments.Count > 0)
        //                    {
        //                        foreach (var LinkedDocumentID in Alert.LinkedDocuments)
        //                            AddAlertAttachment(AlertEntity.ID, LinkedDocumentID);
        //                    }

        //                    if (Alert.BoardStateID is object && Alert.BoardStateID > 0)
        //                    {
        //                        if (Alert.SprintID is object && Alert.SprintID > 0)
        //                        {
        //                            try
        //                            {
        //                                SprintDetail = AdvantageFramework.Core.Database.Procedures.SprintDetail.LoadBySprintIDAlertID(DbContext, Alert.SprintID, AlertEntity.ID);
        //                            }
        //                            catch (Exception ex)
        //                            {
        //                                SprintDetail = default;
        //                            }
        //                        }

        //                        if (SprintDetail is null && Alert.BoardStateID is object && Alert.BoardStateID > 0)
        //                        {
        //                            SprintDetail = new Database.Entities.SprintDetail();
        //                            SprintDetail.SprintHeaderID = Alert.SprintID;
        //                            SprintDetail.AlertID = AlertEntity.ID;
        //                            try
        //                            {
        //                                SprintDetail.SequenceNumber = (from Item in AdvantageFramework.Core.Database.Procedures.SprintDetail.LoadBySprintID(DbContext, SprintDetail.SprintHeaderID)
        //                                                               where Item.SequenceNumber is object
        //                                                               select Item.SequenceNumber).Max + 1;
        //                            }
        //                            catch (Exception ex)
        //                            {
        //                                SprintDetail.SequenceNumber = null;
        //                            }

        //                            if (AdvantageFramework.Core.Database.Procedures.SprintDetail.Insert(DbContext, SprintDetail))
        //                            {
        //                                AdvantageFramework.ProjectManagement.Agile.MoveBoardItem(this.Session, Alert.BoardStateID, SprintDetail, -1);
        //                            }
        //                        }
        //                        else if (AdvantageFramework.ProjectManagement.Agile.MoveBoardItem(this.Session, Alert.BoardStateID, SprintDetail, -1))
        //                        {
        //                            if (Alert.BoardStateID is null || Alert.BoardStateID <= 0)
        //                            {
        //                                if (AdvantageFramework.Core.Database.Procedures.SprintDetail.Delete(DbContext, SprintDetail))
        //                                {
        //                                    SprintDetail = default;
        //                                }
        //                            }
        //                        }
        //                    }

        //                    if (Alert.Assignees is object && Alert.Assignees.Count > 0)
        //                    {
        //                        if (IsRouted == false)
        //                        {
        //                            foreach (var AssigneeEmployeeCode in Alert.Assignees)
        //                                AdvantageFramework.AlertSystem.AddAssignee(DbContext, this.Session, AlertEntity, AssigneeEmployeeCode, default, default);
        //                        }
        //                        else
        //                        {
        //                            AdvantageFramework.AlertSystem.ProcessAssignees(DbContext, Alert, Alert.Assignees.ToList, true, Message);
        //                        }

        //                        if (AlertEntity.HoursAllowed is object)
        //                        {
        //                            UpdateRecipientHours(DbContext, AlertEntity.ID, AlertEntity.HoursAllowed, "");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        AddUnAssignedComment(DbContext, AlertEntity, "");
        //                    }

        //                    if (Alert.Recipients is object && Alert.Recipients.Count > 0)
        //                    {
        //                        foreach (var RecipientEmployeeCode in Alert.Recipients)
        //                        {
        //                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(RecipientEmployeeCode.StartsWith("CC|"), false, false)))
        //                            {
        //                                AddRecipient(DbContext, AlertEntity, RecipientEmployeeCode, "");
        //                            }
        //                            else
        //                            {
        //                                AddClientContactRecipient(DbContext, AlertEntity, Conversions.ToInteger(RecipientEmployeeCode.Replace("CC|", "")));
        //                            }
        //                        }
        //                    }

        //                    // If IsNewAssignment = True AndAlso IsRouted = True AndAlso MultiRouteTemplate = False Then

        //                    // Try

        //                    // 'AddAutoComment(DbContext, AlertEntity.ID, AlertEntity.AssignedEmployeeEmployeeCode, 0, AlertEntity.AlertAssignmentTemplateID, AlertEntity.AlertStateID)
        //                    // Dim Comment As AdvantageFramework.Core.Database.Entities.AlertComment = Nothing
        //                    // Dim AlertState As AdvantageFramework.Core.Database.Entities.AlertState = Nothing
        //                    // Dim MyDate As DateTime = Now

        //                    // Comment = New Database.Entities.AlertComment
        //                    // AlertState = AdvantageFramework.Core.Database.Procedures.AlertState.LoadByAlertStateID(DbContext, AlertEntity.AlertStateID)

        //                    // If AlertState IsNot Nothing Then

        //                    // Comment.AlertID = AlertEntity.ID
        //                    // Comment.UserCode = DbContext.UserCode
        //                    // Comment.GeneratedDate = MyDate
        //                    // Comment.AlertAssignmentTemplateID = AlertEntity.AlertAssignmentTemplateID
        //                    // Comment.AlertStateID = AlertEntity.AlertStateID

        //                    // If String.IsNullOrWhiteSpace(AlertEntity.AssignedEmployeeEmployeeCode) = False Then

        //                    // Comment.AssignedEmployeeCode = AlertEntity.AssignedEmployeeEmployeeCode
        //                    // Comment.Comment = String.Format("{0} | {1} |", AlertState.Name.ToUpper, AlertEntity.AssignedEmployeeFullName)

        //                    // Else

        //                    // Comment.Comment = String.Format("{0} | {1} |", AlertState.Name.ToUpper, "Unassigned")

        //                    // End If

        //                    // Comment.HasEmailBeenSent = False
        //                    // Comment.CustodyStart = MyDate

        //                    // End If

        //                    // 'Hack...assign info won't save??!!?!?!?!?!?!
        //                    // If AdvantageFramework.Core.Database.Procedures.AlertComment.Insert(DbContext, Comment) = True Then

        //                    // Try

        //                    // DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE ALERT_COMMENT SET ALRT_NOTIFY_HDR_ID = {0}, ALERT_STATE_ID = {1} WHERE COMMENT_ID = {2};",
        //                    // AlertEntity.AlertAssignmentTemplateID, AlertEntity.AlertStateID, Comment.ID))

        //                    // Catch ex As Exception
        //                    // End Try

        //                    // End If

        //                    // Catch ex As Exception
        //                    // End Try

        //                    // End If

        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Created = false;
        //        Errors.Add("There was a problem creating the alert. Please contact software support.");
        //    }
        //    finally
        //    {
        //        if (Errors.Count > 0)
        //            Message = string.Join(Constants.vbNewLine, Errors);
        //        CreateAssignmentRet = Created;
        //    }

        //    return CreateAssignmentRet;
        //}

        //public List<AdvantageFramework.DTO.Desktop.AlertComment> LoadAlertComments(int AlertID, int DocumentID, bool HideSystemComments, bool IsClientPortal)
        //{

        //    // objects
        //    List<AdvantageFramework.DTO.Desktop.AlertComment> AllComments = null;
        //    List<AdvantageFramework.DTO.Desktop.AlertComment> AlertComments = null;
        //    System.Data.SqlClient.SqlParameter AlertIDSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter DocumentIDSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter EmployeeCodeSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter OffsetSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter HideSystemCommentsSqlParameter = null;
        //    decimal Offset = 0m;
        //    AlertIDSqlParameter = new System.Data.SqlClient.SqlParameter("AlertID", AlertID);
        //    DocumentIDSqlParameter = new System.Data.SqlClient.SqlParameter("DocumentID", DocumentID);
        //    HideSystemCommentsSqlParameter = new System.Data.SqlClient.SqlParameter("HideSystemComments", HideSystemComments);
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        if (IsClientPortal == true)
        //        {
        //            EmployeeCodeSqlParameter = new System.Data.SqlClient.SqlParameter("EmployeeCode", "");
        //            Offset = AdvantageFramework.Core.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, string.Empty);
        //        }
        //        else
        //        {
        //            EmployeeCodeSqlParameter = new System.Data.SqlClient.SqlParameter("EmployeeCode", this.Session.User.EmployeeCode);
        //            Offset = AdvantageFramework.Core.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, this.Session.User.EmployeeCode);
        //        }

        //        try
        //        {
        //            OffsetSqlParameter = new System.Data.SqlClient.SqlParameter("Offset", Offset);
        //            AllComments = DbContext.Database.SqlQuery<AdvantageFramework.DTO.Desktop.AlertComment>("EXEC [dbo].[dbo].[advsp_alert_load_comments] @AlertID, @DocumentID, @EmployeeCode, @Offset, @HideSystemComments;", AlertIDSqlParameter, DocumentIDSqlParameter, EmployeeCodeSqlParameter, OffsetSqlParameter, HideSystemCommentsSqlParameter).ToList;
        //        }
        //        catch (Exception ex)
        //        {
        //            AllComments = null;
        //        }
        //    }

        //    if (AllComments is object)
        //    {
        //        AlertComments = (from Entity in AllComments
        //                         where Operators.ConditionalCompareObjectEqual(Entity.ParentID, 0, false)
        //                         select Entity).OrderByDescending(x => x.GeneratedDate).OrderByDescending(x => x.CommentID).ToList();
        //        if (AlertComments is object)
        //        {
        //            foreach (DTO.Desktop.AlertComment Comment in AlertComments)
        //                FindAndAddChildren(ref Comment, AllComments);
        //        }
        //    }

        //    return AlertComments;
        //}

        //private bool FindAndAddChildren(ref DTO.Desktop.AlertComment Parent, List<DTO.Desktop.AlertComment> AllComments)
        //{
        //    bool HasChildren = false;
        //    int CommentID = Parent.CommentID;
        //    List<DTO.Desktop.AlertComment> Children = null;
        //    try
        //    {
        //        Children = (from Entity in AllComments
        //                    where Operators.ConditionalCompareObjectEqual(Entity.ParentID, CommentID, false)
        //                    select Entity).OrderBy(x => x.GeneratedDate).ThenBy(x => x.CommentID).ToList();
        //        if (Children is object && Children.Count > 0)
        //        {
        //            HasChildren = true;
        //            if (Parent.Replies is null)
        //            {
        //                Parent.Replies = new List<DTO.Desktop.AlertComment>();
        //            }

        //            foreach (DTO.Desktop.AlertComment Child in Children)
        //            {
        //                Parent.Replies.Add(Child);
        //                FindAndAddChildren(ref Child, AllComments);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        HasChildren = false;
        //    }

        //    return HasChildren;
        //}

        public bool AddAlertMentions(Web.QueryString qs,int AlertID, string[] Mention, int SubjectMention)
        {
            bool Added = false;
            System.Data.SqlClient.SqlParameter [] paramList = new System.Data.SqlClient.SqlParameter[6];
            paramList[0] = new System.Data.SqlClient.SqlParameter("@ALERT_ID", System.Data.SqlDbType.Int);
            paramList[1] = new System.Data.SqlClient.SqlParameter("@EMP_CODE", System.Data.SqlDbType.VarChar, 6);
            paramList[2] = new System.Data.SqlClient.SqlParameter("@DESCRIPTION_MENTION", System.Data.SqlDbType.Int);
            paramList[3] = new System.Data.SqlClient.SqlParameter("@USER_CODE", System.Data.SqlDbType.VarChar, 6);
            paramList[0].Value = AlertID;
            paramList[2].Value = SubjectMention;
            paramList[3].Value = qs.UserCode;
            try
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(qs.ConnectionString, qs.UserCode))
                {
                    foreach (string Employee in Mention)
                    {
                        paramList[1].Value = Employee;
                        // SOOOOO wrong but we can fix later
                        DbContext.ExecuteNonQuery("EXEC [dbo].[usp_wv_ALERT_ADD_MENTION] " + AlertID + ", "+ Employee + ", " + SubjectMention + ", " + qs.UserCode + ";");
                    }
                }

                Added = true;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                Added = false;
            }

            return Added;
        }

        //public bool AddAlertComment(int AlertID, int? CommentID, string Comment, int? ClientContactID, string DocumentList)
        //{
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        return AdvantageFramework.AlertSystem.AddAlertComment(DbContext, AlertID, CommentID, Comment, ClientContactID, DocumentList);
        //    }


        //    // 'objects
        //    // Dim AlertComment As AdvantageFramework.Core.Database.Entities.AlertComment = Nothing
        //    // Dim Added As Boolean = False
        //    // Dim LastAlertComment As AdvantageFramework.Core.Database.Entities.AlertComment = Nothing

        //    // AlertComment = New Database.Entities.AlertComment

        //    // AlertComment.AlertID = AlertID
        //    // AlertComment.Comment = Comment
        //    // AlertComment.UserCode = Me.Session.UserCode
        //    // AlertComment.GeneratedDate = Now
        //    // AlertComment.HasEmailBeenSent = False
        //    // AlertComment.ClientContactID = ClientContactID
        //    // AlertComment.ParentID = CommentID

        //    // Using DbContext = New AdvantageFramework.Core.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        //    // If AdvantageFramework.Core.Database.Procedures.AlertComment.Insert(DbContext, AlertComment) Then

        //    // Added = True

        //    // AdvantageFramework.AlertSystem.UndismissCCsByAlertID(DbContext, AlertID)

        //    // If Not String.IsNullOrWhiteSpace(DocumentList) Then

        //    // DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ALERT_COMMENT] SET DOCUMENT_LIST = '{0}' WHERE COMMENT_ID = {1} AND ALERT_ID = {2}", DocumentList, AlertComment.ID, AlertComment.AlertID))

        //    // End If

        //    // End If

        //    // End Using

        //    // Return Added

        //}

        public List<AdvantageFramework.Core.Database.Classes.AlertRecipient> LoadAlertRecipients(Web.QueryString qs,int AlertID)
        {

            // objects
            List<AdvantageFramework.Core.Database.Classes.AlertRecipient> AlertRecipients = null;
            using (var DbContext = new AdvantageFramework.Core.Database.DbContext(qs.ConnectionString, qs.UserCode))
            {
                AlertRecipients = LoadAlertRecipients(DbContext, AlertID);
            }

            return AlertRecipients;
        }

        public List<AdvantageFramework.Core.Database.Classes.AlertRecipient> LoadAlertRecipients(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID)
        {

            // objects
            List<AdvantageFramework.Core.Database.Classes.AlertRecipient> AlertRecipients = null;
            try
            {
                AlertRecipients = AdvantageFramework.Core.BLogic.AlertSystem.Methods.LoadAlertRecipients(DbContext, AlertID);
            }
            catch (Exception ex)
            {
            }

            return AlertRecipients;
        }

        //public AlertHours LoadAlertHours(int AlertID)
        //{
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        return LoadAlertHours(DbContext, AlertID);
        //    }
        //}

        //public AlertHours LoadAlertHours(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID)
        //{
        //    AlertHours Hours = null;
        //    try
        //    {
        //        Hours = DbContext.Database.SqlQuery<AlertHours>(string.Format("EXEC [dbo].[advsp_alert_get_hours] {0};", AlertID)).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        Hours = null;
        //    }

        //    if (Hours is object)
        //    {
        //        Hours.HasWeeklyHours = AdvantageFramework.AlertSystem.AlertHasWeeklyHours(DbContext, AlertID);
        //    }
        //    else
        //    {
        //        Hours = new AlertHours();
        //    }

        //    return Hours;
        //}

        //public bool UpdateRecipientHours(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, decimal HoursAllowed, string EmployeeCode)
        //{
        //    bool Updated = false;
        //    System.Data.SqlClient.SqlParameter AlertIDSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter HoursSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter EmployeeCodeSqlParameter = null;
        //    AlertIDSqlParameter = new System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int);
        //    HoursSqlParameter = new System.Data.SqlClient.SqlParameter("@HRS_ALLOWED", SqlDbType.Decimal);
        //    EmployeeCodeSqlParameter = new System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6);
        //    AlertIDSqlParameter.Value = AlertID;
        //    HoursSqlParameter.Value = HoursAllowed;
        //    if (string.IsNullOrWhiteSpace(EmployeeCode) == true)
        //    {
        //        EmployeeCodeSqlParameter.Value = DBNull.Value;
        //    }
        //    else
        //    {
        //        EmployeeCodeSqlParameter.Value = EmployeeCode;
        //    }

        //    try
        //    {
        //        DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_alert_update_recipient_hours] @ALERT_ID, @HRS_ALLOWED, @EMP_CODE;", AlertIDSqlParameter, HoursSqlParameter, EmployeeCodeSqlParameter);
        //        Updated = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Updated = false;
        //    }

        //    if (Updated == true && string.IsNullOrWhiteSpace(EmployeeCode) == true)
        //    {
        //        DbContext.Database.ExecuteSqlCommand("UPDATE ALERT WITH(ROWLOCK) SET HRS_ALLOWED = @HRS_ALLOWED WHERE ALERT_ID = @ALERT_ID;", HoursSqlParameter, AlertIDSqlParameter);
        //    }

        //    return Updated;
        //}

        //public bool IsMyAssignment(int AlertID, string EmployeeCode)
        //{
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        return IsMyAssignment(DbContext, AlertID, EmployeeCode);
        //    }
        //}

        //public bool IsMyAssignment(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, string EmployeeCode)
        //{
        //    bool MyAssignment = false;
        //    try
        //    {
        //        MyAssignment = DbContext.Database.SqlQuery<bool>(string.Format("EXEC [dbo].[advsp_alert_is_my_assignment] {0}, '{1}';", AlertID, EmployeeCode)).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        MyAssignment = false;
        //    }

        //    return MyAssignment;
        //}

        //public string LoadTaskDescription(int JobNumber, short JobComponentNumber, short TaskSequenceNumber)
        //{
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        return LoadTaskDescription(DbContext, JobNumber, JobComponentNumber, TaskSequenceNumber);
        //    }
        //}

        //public string LoadTaskDescription(AdvantageFramework.Core.Database.DbContext DbContext, int JobNumber, short JobComponentNumber, short TaskSequenceNumber)
        //{
        //    string Description = string.Empty;
        //    try
        //    {
        //        Description = DbContext.Database.SqlQuery<string>(string.Format("SELECT FNC_COMMENTS FROM JOB_TRAFFIC_DET WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2};", JobNumber, JobComponentNumber, TaskSequenceNumber)).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        Description = string.Empty;
        //    }

        //    return Description;
        //}

        //public string LoadAlertBody(int AlertID)
        //{
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        return LoadAlertBody(DbContext, AlertID);
        //    }
        //}

        //public string LoadAlertBody(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID)
        //{
        //    string Description = string.Empty;
        //    SimpleAlertBody SimpleAlertBody = null;
        //    try
        //    {
        //        SimpleAlertBody = DbContext.Database.SqlQuery<SimpleAlertBody>(string.Format("SELECT [AlertTypeID] = ALERT_TYPE_ID, [AlertCategoryID] = ALERT_CAT_ID, [Description] = COALESCE(BODY_HTML, BODY, '') FROM ALERT WITH (NOLOCK) WHERE ALERT_ID = {0};", AlertID)).SingleOrDefault;
        //        if (SimpleAlertBody is object)
        //        {
        //            if (SimpleAlertBody.AlertTypeID == 3 || SimpleAlertBody.AlertTypeID == 8)
        //            {
        //                AdvantageFramework.Core.Database.Entities.Agency Agency = default;
        //                Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
        //                if (Agency is object)
        //                {
        //                    AdvantageFramework.AlertSystem.ExternalLinkToInternalLink(SimpleAlertBody.Description, Agency);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        SimpleAlertBody = null;
        //    }

        //    return SimpleAlertBody.Description;
        //}

        //[Serializable()]
        //public partial class SimpleAlertBody
        //{
        //    public int AlertTypeID { get; set; }
        //    public int AlertCategoryID { get; set; }
        //    public string Description { get; set; }

        //    public SimpleAlertBody()
        //    {
        //    }
        //}

        //public List<AdvantageFramework.DTO.Desktop.AlertAttachment> LoadAlertAttachments(AdvantageFramework.Security.Session SecuritySession, int AlertID, decimal Offset, bool IsClientPortal)
        //{
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        return LoadAlertAttachments(SecuritySession, DbContext, AlertID, Offset, IsClientPortal);
        //    }
        //}

        //public List<AdvantageFramework.DTO.Desktop.AlertAttachment> LoadAlertAttachments(AdvantageFramework.Security.Session SecuritySession, AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, decimal Offset, bool IsClientPortal)
        //{

        //    // objects
        //    List<AdvantageFramework.DTO.Desktop.AlertAttachment> AlertAttachments = null;
        //    System.Data.SqlClient.SqlParameter AlertIDSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter EmployeeCodeSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter OffsetSqlParameter = null;
        //    AdvantageFramework.Core.Database.Entities.Alert Alert = default;
        //    try
        //    {
        //        Alert = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID);
        //    }
        //    catch (Exception ex)
        //    {
        //        Alert = default;
        //    }

        //    if (Alert is object)
        //    {
        //        AlertIDSqlParameter = new System.Data.SqlClient.SqlParameter("AlertID", AlertID);
        //        if (IsClientPortal == false)
        //        {
        //            EmployeeCodeSqlParameter = new System.Data.SqlClient.SqlParameter("EmployeeCode", this.Session.User.EmployeeCode);
        //        }
        //        else
        //        {
        //            EmployeeCodeSqlParameter = new System.Data.SqlClient.SqlParameter("EmployeeCode", "");
        //        }

        //        OffsetSqlParameter = new System.Data.SqlClient.SqlParameter("Offset", Offset);
        //        try
        //        {
        //            AlertAttachments = DbContext.Database.SqlQuery<AdvantageFramework.DTO.Desktop.AlertAttachment>("EXEC [dbo].[advsp_alert_attachments_get] @AlertID, @EmployeeCode, @Offset", AlertIDSqlParameter, EmployeeCodeSqlParameter, OffsetSqlParameter).ToList;
        //            foreach (AdvantageFramework.DTO.Desktop.AlertAttachment Attachment in AlertAttachments)
        //            {
        //                if (Attachment.ThumbnailSource is object)
        //                {
        //                    Attachment.Thumbnail = string.Format("data:{0};base64,{1}", Attachment.MIMEType.ToLower, Convert.ToBase64String(Attachment.ThumbnailSource));
        //                }
        //                else
        //                {
        //                    Attachment.Thumbnail = null;
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            AlertAttachments = null;
        //        }

        //        if (AlertAttachments is object)
        //        {
        //            LoadAttachmentDisplayData(SecuritySession, Alert, AlertAttachments);
        //        }
        //    }

        //    return AlertAttachments;
        //}

        //public void LoadAttachmentDisplayData(List<AdvantageFramework.DTO.Desktop.Document> Documents)
        //{
        //    foreach (var Document in Documents)
        //        LoadFileDisplayData(Document.FileName, Document.FileSize, Document.MIMEType, ref Document.CssClass, ref Document.FileTypeLabel, ref Document.FileType, ref Document.AllowComments, ref Document.FileSizeDisplay);
        //}

        //public void LoadAttachmentDisplayData(AdvantageFramework.Security.Session SecuritySession, AdvantageFramework.Core.Database.Entities.Alert Alert, List<AdvantageFramework.DTO.Desktop.AlertAttachment> AlertAttachments)
        //{
        //    string ErrorMessage = string.Empty;
        //    foreach (var AlertAttachment in AlertAttachments)
        //    {
        //        if (Alert.AlertCategoryID == 79)
        //        {
        //            AlertAttachment.ProofingURL = AdvantageFramework.Proofing.GetProofingURL(SecuritySession, Alert.ID, AlertAttachment.DocumentID, 0, ErrorMessage);
        //        }

        //        LoadFileDisplayData(AlertAttachment.FileName, AlertAttachment.FileSize, AlertAttachment.MIMEType, ref AlertAttachment.CssClass, ref AlertAttachment.FileTypeLabel, ref AlertAttachment.FileType, ref AlertAttachment.AllowComments, ref AlertAttachment.FileSizeDisplay);
        //    }
        //}

        //private void LoadFileDisplayData(string FileName, int FileSize, string MIMEType, ref string CssClass, ref string FileTypeLabel, ref string FileType, ref bool AllowComments, ref string FileSizeDisplay)
        //{
        //    switch (MIMEType ?? "")
        //    {
        //        case "application/msword":
        //        case "application/vnd.openxmlformats-officedocument.word":
        //        case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
        //            {
        //                CssClass = "document-ms-word";
        //                FileTypeLabel = "W";
        //                FileType = "Microsoft Word";
        //                AllowComments = false;
        //                break;
        //            }

        //        case "application/mspowerpoint":
        //        case "application/vnd.ms-powerpoint":
        //            {
        //                CssClass = "document-ms-powerpoint";
        //                FileTypeLabel = "PP";
        //                FileType = "Microsoft Powerpoint";
        //                break;
        //            }

        //        case "application/msproject":
        //        case "application/vnd.ms-msproject":
        //            {
        //                CssClass = "document-ms-project";
        //                FileTypeLabel = "PR";
        //                FileType = "Microsoft Project";
        //                break;
        //            }

        //        case "application/pdf":
        //            {
        //                CssClass = "document-adobe-pdf";
        //                FileTypeLabel = "PDF";
        //                FileType = "Adobe PDF";
        //                AllowComments = true;
        //                break;
        //            }

        //        case "application/msexcel":
        //        case "application/vnd.ms-excel":
        //        case "application/vnd.openxmlformats-officedocument.spre":
        //            {
        //                CssClass = "document-ms-excel";
        //                FileTypeLabel = "XL";
        //                FileType = "Microsoft Excel";
        //                AllowComments = true;
        //                break;
        //            }

        //        case "image/bmp":
        //            {
        //                CssClass = "document-image";
        //                FileTypeLabel = "BMP";
        //                FileType = "Bitmap Image";
        //                AllowComments = true;
        //                break;
        //            }

        //        case "image/gif":
        //            {
        //                CssClass = "document-image";
        //                FileTypeLabel = "GIF";
        //                FileType = "Gif Image";
        //                AllowComments = true;
        //                break;
        //            }

        //        case "image/jpeg":
        //        case "image/pjpeg":
        //            {
        //                CssClass = "document-image";
        //                FileTypeLabel = "JPG";
        //                FileType = "Jpeg Image";
        //                AllowComments = true;
        //                break;
        //            }

        //        case "image/x-png":
        //        case "image/png":
        //            {
        //                CssClass = "document-image";
        //                FileTypeLabel = "PNG";
        //                FileType = "Png Image";
        //                AllowComments = true;
        //                break;
        //            }

        //        case "image/tiff":
        //            {
        //                CssClass = "document-image";
        //                FileTypeLabel = "TIF";
        //                FileType = "Tiff Image";
        //                AllowComments = true;
        //                break;
        //            }

        //        case "text/plain":
        //            {
        //                CssClass = "document-text";
        //                FileTypeLabel = "TXT";
        //                FileType = "Text file";
        //                break;
        //            }

        //        case "image/x-photoshop":
        //            {
        //                CssClass = "document-adobe-photoshop";
        //                FileTypeLabel = "PSD";
        //                FileType = "Adobe Photoshop";
        //                break;
        //            }

        //        case "application/illustrator":
        //            {
        //                CssClass = "document-adobe-illustrator";
        //                FileTypeLabel = "AI";
        //                FileType = "Adobe Illustrator";
        //                break;
        //            }

        //        case "URL":
        //            {
        //                CssClass = "document-url";
        //                FileTypeLabel = "URL";
        //                FileType = "URL hyperlink";
        //                break;
        //            }

        //        case "application/x-zip-compressed":
        //        case "application/zip":
        //            {
        //                CssClass = "document-zip";
        //                FileTypeLabel = "ZIP";
        //                FileType = "Zip file";
        //                break;
        //            }

        //        case "application/vnd.ms-outlook":
        //            {
        //                CssClass = "document-ms-outlook";
        //                FileTypeLabel = "O";
        //                FileType = "Microsoft Outlook";
        //                AllowComments = true;
        //                break;
        //            }

        //        default:
        //            {
        //                CssClass = "standard-grey";
        //                if (!string.IsNullOrWhiteSpace(FileName))
        //                {
        //                    if (FileName.ToUpper().Contains(".MSG"))
        //                    {
        //                        CssClass = "document-ms-outlook";
        //                        FileTypeLabel = "MSG";
        //                        FileType = "Microsoft Outlook";
        //                        AllowComments = true;
        //                    }
        //                    else if (FileName.ToUpper().Contains(".DOC"))
        //                    {
        //                        CssClass = "document-ms-word";
        //                        FileTypeLabel = "W";
        //                        FileType = "Microsoft Word";
        //                        AllowComments = false;
        //                    }
        //                    else if (FileName.ToUpper().Contains(".XL"))
        //                    {
        //                        CssClass = "document-ms-excel";
        //                        FileTypeLabel = "XL";
        //                        FileType = "Microsoft Excel";
        //                        AllowComments = true;
        //                    }
        //                    else if (FileName.Contains("."))
        //                    {
        //                        try
        //                        {
        //                            string[] ar;
        //                            ar = FileName.Split(".");
        //                            if (ar is object & ar.Length > 0)
        //                            {
        //                                FileTypeLabel = ar[ar.Length - 1].ToString().ToUpper();
        //                                FileType = FileTypeLabel + " file";
        //                                if (FileTypeLabel.Length > 3)
        //                                {
        //                                    FileTypeLabel = FileTypeLabel.Substring(0, 3);
        //                                }
        //                            }
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            FileTypeLabel = "DOC";
        //                            FileType = "Document";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        FileTypeLabel = "DOC";
        //                        FileType = "Document";
        //                    }
        //                }

        //                break;
        //            }
        //    }

        //    if (FileSize > 0)
        //    {
        //        FileSize = (int)Math.Round(FileSize / 1024d);
        //        switch (FileSize)
        //        {
        //            case var @case when @case < 1:
        //                {
        //                    FileSizeDisplay = "< 1K";
        //                    break;
        //                }

        //            case var case1 when 0 <= case1 && case1 <= 1023:
        //                {
        //                    FileSizeDisplay = FileSize.ToString("#,###") + " KB";
        //                    break;
        //                }

        //            case var case2 when case2 >= 1024:
        //                {
        //                    FileSizeDisplay = (FileSize / 1024d).ToString("#,###") + " MB";
        //                    break;
        //                }
        //        }
        //    }
        //}

        //public bool UploadAttachmentToProofHQ(int AttachmentID)
        //{
        //    bool UploadAttachmentToProofHQRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.Agency Agency = default;
        //    AdvantageFramework.Core.Database.Entities.AlertAttachment AlertAttachment = default;
        //    AdvantageFramework.Core.Database.Entities.Document Document = default;
        //    int[] DocumentIDs = null;
        //    List<AdvantageFramework.Core.Database.Entities.Document> Documents = null;
        //    AdvantageFramework.Core.Database.Entities.Document ParentDocument = default;
        //    int ParentProofHQFileID = 0;
        //    byte[] ByteFile = null;
        //    bool ProofHQUploaded = false;
        //    string ProofHQUrl = "";
        //    int ProofHQFileID = 0;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            using (var DataContext = new AdvantageFramework.Core.Database.DataContext(this.Session.ConnectionString, this.Session.UserCode))
        //            {
        //                AlertAttachment = AdvantageFramework.Core.Database.Procedures.AlertAttachment.LoadByAlertAttachmentID(DbContext, AttachmentID);
        //                if (AlertAttachment is object)
        //                {
        //                    Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
        //                    if (Agency is object && AlertAttachment is object)
        //                    {
        //                        Document = AdvantageFramework.Core.Database.Procedures.Document.LoadByDocumentID(DbContext, AlertAttachment.DocumentID);
        //                        if (Document is object)
        //                        {
        //                            try
        //                            {
        //                                DocumentIDs = AdvantageFramework.Core.Database.Procedures.AlertAttachment.LoadByAlertID(DbContext, AlertAttachment.AlertID).Where(Entity => !Operators.ConditionalCompareObjectEqual(Entity.DocumentID, Document.ID, false)).Select(Entity => Entity.DocumentID).ToArray;
        //                            }
        //                            catch (Exception ex)
        //                            {
        //                                DocumentIDs = null;
        //                            }

        //                            if (DocumentIDs is object)
        //                            {
        //                                try
        //                                {
        //                                    Documents = (from Entity in AdvantageFramework.Core.Database.Procedures.Document.Load(DbContext).ToList
        //                                                 where DocumentIDs.Any(DocID => DocID == Entity.ID) && Entity.FileName == Document.FileName
        //                                                 select Entity).ToList();
        //                                }
        //                                catch (Exception ex)
        //                                {
        //                                    Documents = null;
        //                                }

        //                                if (Documents is object)
        //                                {
        //                                    try
        //                                    {
        //                                        ParentDocument = Documents.Where(Entity => Operators.ConditionalCompareObjectGreater(Entity.ProofHQFileID.GetValueOrDefault((object)0), 0, false)).OrderBy(Entity => Entity.ID).FirstOrDefault;
        //                                    }
        //                                    catch (Exception ex)
        //                                    {
        //                                        ParentDocument = default;
        //                                    }

        //                                    if (ParentDocument is object)
        //                                    {
        //                                        ParentProofHQFileID = ParentDocument.ProofHQFileID.GetValueOrDefault(0);
        //                                    }
        //                                }
        //                            }

        //                            if (AdvantageFramework.FileSystem.Download(Agency, Document, ByteFile))
        //                            {
        //                                if (ParentProofHQFileID > 0)
        //                                {
        //                                    ProofHQUploaded = AdvantageFramework.ProofHQ.UploadNewVersion(DbContext, DataContext, this.Session.User.EmployeeCode, ByteFile, ParentProofHQFileID, Document.FileName, Document.FileName, "", "", 0, ProofHQUrl, ProofHQFileID);
        //                                }
        //                                else
        //                                {
        //                                    ProofHQUploaded = AdvantageFramework.ProofHQ.UploadFile(DbContext, DataContext, this.Session.User.EmployeeCode, ByteFile, Document.FileName, Document.FileName, "", "", 0, ProofHQUrl, ProofHQFileID);
        //                                }

        //                                if (ProofHQUploaded)
        //                                {
        //                                    Document.ProofHQUrl = ProofHQUrl;
        //                                    Document.ProofHQFileID = ProofHQFileID;
        //                                    AdvantageFramework.Core.Database.Procedures.Document.Update(DbContext, Document);
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ProofHQUploaded = false;
        //    }
        //    finally
        //    {
        //        UploadAttachmentToProofHQRet = ProofHQUploaded;
        //    }

        //    return UploadAttachmentToProofHQRet;
        //}

        //public List<AdvantageFramework.DTO.Desktop.Alert.SoftwareVersion> LoadSoftwareVersionsByJobComponent(int JobNumber, short JobComponentNumber, int VersionID)
        //{

        //    // objects
        //    List<AdvantageFramework.DTO.Desktop.Alert.SoftwareVersion> SoftwareVersions = null;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        SoftwareVersions = DbContext.Database.SqlQuery<AdvantageFramework.DTO.Desktop.Alert.SoftwareVersion>(string.Format("EXEC [dbo].[advsp_alert_load_software_version_by_job] {0}, {1}, {2};", JobNumber, JobComponentNumber, VersionID)).ToList;
        //    }

        //    return SoftwareVersions;
        //}

        //public List<AdvantageFramework.DTO.Desktop.Alert.SoftwareBuild> LoadSoftwareBuildsByVersion(int VersionID)
        //{

        //    // objects
        //    List<AdvantageFramework.DTO.Desktop.Alert.SoftwareBuild> SoftwareBuilds = null;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        SoftwareBuilds = DbContext.Database.SqlQuery<AdvantageFramework.DTO.Desktop.Alert.SoftwareBuild>(string.Format("EXEC [dbo].[advsp_alert_load_software_build_by_version] {0};", VersionID)).ToList;
        //    }

        //    return SoftwareBuilds;
        //}

        //public List<AdvantageFramework.DTO.Desktop.Alert.AlertState> LoadAlertStates()
        //{

        //    // objects
        //    List<AdvantageFramework.DTO.Desktop.Alert.AlertState> AlertStates = null;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        AlertStates = DbContext.Database.SqlQuery<AdvantageFramework.DTO.Desktop.Alert.AlertState>(string.Format("EXEC [dbo].[advsp_alert_load_active_states]")).ToList;
        //    }

        //    return AlertStates;
        //}

        //public List<AdvantageFramework.DTO.Desktop.Alert.AlertTemplateState> LoadAlertTemplateStates(int AlertTemplateID)
        //{
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        return LoadAlertTemplateStates(DbContext, AlertTemplateID);
        //    }
        //}

        //public List<AdvantageFramework.DTO.Desktop.Alert.AlertTemplateState> LoadAlertTemplateStates(AdvantageFramework.Core.Database.DbContext DbContext, int AlertTemplateID)
        //{

        //    // objects
        //    List<AdvantageFramework.DTO.Desktop.Alert.AlertTemplateState> AlertTemplateStates = null;
        //    System.Data.SqlClient.SqlParameter AlertTemplateIDParameter = null;
        //    AlertTemplateIDParameter = new System.Data.SqlClient.SqlParameter("AlertTemplateID", AlertTemplateID);
        //    AlertTemplateStates = DbContext.Database.SqlQuery<AdvantageFramework.DTO.Desktop.Alert.AlertTemplateState>("exec [dbo].[advsp_alert_template_states_get] @AlertTemplateID", AlertTemplateIDParameter).ToList;
        //    return AlertTemplateStates;
        //}

        //public List<AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee> LoadCurrentAlertTemplateStateEmployees(int AlertID)
        //{
        //    return _LoadAlertTemplateStateEmployees(AlertID, 0, 0, false, "", false);
        //}

        //public AdvantageFramework.ViewModels.Desktop.AlertAssignmentViewModel GetAssignmentTemplate(int AlertID, int DocumentID, bool AllEmployees, ref string ErrorMessage)
        //{
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        return AdvantageFramework.AlertSystem.GetAssignmentTemplate(DbContext, AlertID, DocumentID, AllEmployees, ErrorMessage);
        //    }
        //}

        //public List<AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee> LoadAlertTemplateStateEmployees(int AlertID, int AlertTemplateID, int AlertStateID, bool ShowAll, string IncludeEmployeeCode, bool ConceptShareOnly)
        //{
        //    return _LoadAlertTemplateStateEmployees(AlertID, AlertTemplateID, AlertStateID, ShowAll, IncludeEmployeeCode, ConceptShareOnly);
        //}

        //public List<AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee> _LoadAlertTemplateStateEmployees(int AlertID, int AlertTemplateID, int AlertStateID, bool ShowAll, string IncludeEmployeeCode, bool ConceptShareOnly)
        //{
        //    List<AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee> AlertTemplateStateEmployees = null;
        //    try
        //    {

        //        // objects
        //        System.Data.SqlClient.SqlParameter AlertIDParameter = null;
        //        System.Data.SqlClient.SqlParameter AlertTemplateIDParameter = null;
        //        System.Data.SqlClient.SqlParameter AlertStateIDParameter = null;
        //        System.Data.SqlClient.SqlParameter ShowAllParameter = null;
        //        System.Data.SqlClient.SqlParameter IncludeEmployeeParameter = null;
        //        System.Data.SqlClient.SqlParameter ConceptShareOnlyParameter = null;
        //        if (string.IsNullOrWhiteSpace(IncludeEmployeeCode))
        //        {
        //            IncludeEmployeeCode = "";
        //        }

        //        if (!string.IsNullOrWhiteSpace(IncludeEmployeeCode))
        //        {
        //            if (IncludeEmployeeCode.ToLower() == "unassigned")
        //            {
        //                IncludeEmployeeCode = "";
        //            }
        //        }

        //        if (AlertID == 0)
        //        {
        //            AlertIDParameter = new System.Data.SqlClient.SqlParameter("ALERT_ID", DBNull.Value);
        //        }
        //        else
        //        {
        //            AlertIDParameter = new System.Data.SqlClient.SqlParameter("ALERT_ID", AlertID);
        //        }

        //        if (AlertTemplateID == 0)
        //        {
        //            AlertTemplateIDParameter = new System.Data.SqlClient.SqlParameter("ALRT_NOTIFY_HDR_ID", DBNull.Value);
        //        }
        //        else
        //        {
        //            AlertTemplateIDParameter = new System.Data.SqlClient.SqlParameter("ALRT_NOTIFY_HDR_ID", AlertTemplateID);
        //        }

        //        if (AlertStateID == 0)
        //        {
        //            AlertStateIDParameter = new System.Data.SqlClient.SqlParameter("ALERT_STATE_ID", DBNull.Value);
        //        }
        //        else
        //        {
        //            AlertStateIDParameter = new System.Data.SqlClient.SqlParameter("ALERT_STATE_ID", AlertStateID);
        //        }

        //        ShowAllParameter = new System.Data.SqlClient.SqlParameter("SHOW_ALL", ShowAll);
        //        IncludeEmployeeParameter = new System.Data.SqlClient.SqlParameter("INCLUDE_EMP", IncludeEmployeeCode);
        //        ConceptShareOnlyParameter = new System.Data.SqlClient.SqlParameter("CS_ONLY", ConceptShareOnly);
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            AlertTemplateStateEmployees = DbContext.Database.SqlQuery<AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee>("EXEC [dbo].[advsp_alert_template_states_employees_get] @ALERT_ID, @ALRT_NOTIFY_HDR_ID, @ALERT_STATE_ID, @SHOW_ALL, @INCLUDE_EMP, @CS_ONLY;", AlertIDParameter, AlertTemplateIDParameter, AlertStateIDParameter, ShowAllParameter, IncludeEmployeeParameter, ConceptShareOnlyParameter).ToList;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AlertTemplateStateEmployees = null;
        //    }

        //    // Dim Unassigned As New AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee

        //    // Unassigned.Code = "unassigned"
        //    // Unassigned.Name = "[Unassigned]"

        //    if (AlertTemplateStateEmployees is null)
        //        AlertTemplateStateEmployees = new List<DTO.Desktop.Alert.AlertTemplateStateEmployee>();

        //    // AlertTemplateStateEmployees.Insert(0, Unassigned)

        //    return AlertTemplateStateEmployees;
        //}

        //public List<AdvantageFramework.DTO.Desktop.Alert.AlertCategory> LoadAlertCategories()
        //{
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        return LoadAlertCategories(DbContext);
        //    }
        //}

        //public List<AdvantageFramework.DTO.Desktop.Alert.AlertCategory> LoadAlertCategories(AdvantageFramework.Core.Database.DbContext DbContext)
        //{

        //    // objects
        //    List<AdvantageFramework.DTO.Desktop.Alert.AlertCategory> AlertCategories = null;
        //    AlertCategories = (from Item in DbContext.AlertCategories
        //                       where Item.AlertTypeID == 6 && new[] { 28, 29, 30, 31 }.Contains(Item.ID) == false
        //                       let SortOrder = Item.ID >= 70 ? 1 : 2
        //                       orderby SortOrder, Item.Description
        //                       select new AdvantageFramework.DTO.Desktop.Alert.AlertCategory() { ID = Item.ID, AlertTypeID = Item.AlertTypeID, Description = Item.Description }).ToList;
        //    return AlertCategories;
        //}

        //public List<AdvantageFramework.DTO.Desktop.Alert.AlertCategory> LoadAlertCategories(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.DTO.Desktop.Alert Alert)
        //{

        //    // objects
        //    List<AdvantageFramework.DTO.Desktop.Alert.AlertCategory> AlertCategories = null;
        //    AlertCategories = LoadAlertCategories(DbContext);
        //    if (Alert.AlertCategoryID != 71) // Task
        //    {
        //        AlertCategories = AlertCategories.Where(ac => Operators.ConditionalCompareObjectNotEqual(ac.ID, 71, false)).ToList;
        //    }

        //    if (Alert.SprintID.GetValueOrDefault(0) <= 0)
        //    {
        //        AlertCategories = AlertCategories.Where(ac => Operators.ConditionalCompareObjectNotEqual(ac.ID, 70, false) && Operators.ConditionalCompareObjectNotEqual(ac.ID, 71, false)).ToList;
        //    }

        //    return AlertCategories;
        //}

        //public List<AdvantageFramework.DTO.Desktop.Alert.AlertState> LoadAvailableEmployees()
        //{

        //    // objects
        //    List<AdvantageFramework.DTO.Desktop.Alert.AlertState> AlertStates = null;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        AlertStates = (from Item in AdvantageFramework.Core.Database.Procedures.AlertState.LoadAllActive(DbContext)
        //                       orderby Item.SortOrder ascending
        //                       select Item).ToList.Select(item => new AdvantageFramework.DTO.Desktop.Alert.AlertState(item)).ToList;
        //    }

        //    return AlertStates;
        //}

        //public List<AdvantageFramework.DTO.Desktop.Alert.BoardState> LoadBoardStates(int BoardHeaderID)
        //{
        //    List<AdvantageFramework.DTO.Desktop.Alert.BoardState> LoadBoardStatesRet = default;

        //    // objects
        //    List<AdvantageFramework.DTO.Desktop.Alert.BoardState> BoardStates = null;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        LoadBoardStatesRet = LoadBoardStates(DbContext, BoardHeaderID);
        //    }

        //    return LoadBoardStatesRet;
        //}

        //public List<AdvantageFramework.DTO.Desktop.Alert.BoardState> LoadBoardStates(AdvantageFramework.Core.Database.DbContext DbContext, int BoardHeaderID)
        //{
        //    List<AdvantageFramework.DTO.Desktop.Alert.BoardState> LoadBoardStatesRet = default;

        //    // objects
        //    List<AdvantageFramework.DTO.Desktop.Alert.BoardState> BoardStates = null;
        //    BoardStates = (from BoardDetail in AdvantageFramework.Core.Database.Procedures.BoardDetail.LoadWithState(DbContext, BoardHeaderID)
        //                   join BoardColumn in AdvantageFramework.Core.Database.Procedures.BoardColumn.LoadByBoardID(DbContext, BoardHeaderID) on BoardDetail.BoardColumnID equals BoardColumn.ID
        //                   orderby BoardColumn.SequenceNumber ascending, BoardDetail.AlertState.Name ascending
        //                   select new AdvantageFramework.DTO.Desktop.Alert.BoardState()
        //                   {
        //                       ID = BoardDetail.AlertStateID,
        //                       Name = BoardDetail.AlertState.Name,
        //                       SequenceNumber = BoardDetail.SequenceNumber,
        //                       BoardDetailID = BoardDetail.ID,
        //                       BoardColumnID = BoardDetail.BoardColumnID,
        //                       BoardColumnName = BoardColumn.Name,
        //                       BoardColumnSequenceNumber = BoardColumn.SequenceNumber
        //                   }).OrderBy(bs => bs.BoardColumnSequenceNumber).ThenBy(bs => bs.SequenceNumber).ThenBy(bs => bs.BoardDetailID).ToList;
        //    LoadBoardStatesRet = BoardStates;
        //    return LoadBoardStatesRet;
        //}

        //public bool AddRecipient(int AlertID, string EmployeeCode)
        //{
        //    bool AddRecipientRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.Alert Alert = default;
        //    bool Added = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Alert = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID);
        //            if (Alert is object)
        //            {
        //                Added = Conversions.ToBoolean(AddRecipient(DbContext, Alert, EmployeeCode, ""));
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Added = false;
        //    }
        //    finally
        //    {
        //        AddRecipientRet = Added;
        //    }

        //    return AddRecipientRet;
        //}

        //public object AddRecipient(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Alert Alert, string EmployeeCode, string Comment)
        //{
        //    object AddRecipientRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Views.Employee Employee = default;
        //    AdvantageFramework.Core.Database.Entities.AlertRecipient AlertRecipient = default;
        //    AdvantageFramework.Core.Database.Entities.AlertRecipientDismissed AlertRecipientDismissed = default;
        //    bool Added = false;
        //    try
        //    {
        //        Employee = AdvantageFramework.Core.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode);
        //        if (Employee is object)
        //        {
        //            AlertRecipient = (from Item in AdvantageFramework.Core.Database.Procedures.AlertRecipient.LoadByAlertID(DbContext, Alert.ID)
        //                              where Item.EmployeeCode == EmployeeCode && Item.IsCurrentNotify != 1
        //                              select Item).SingleOrDefault;
        //            AlertRecipientDismissed = (from Item in AdvantageFramework.Core.Database.Procedures.AlertRecipientDismissed.LoadByAlertID(DbContext, Alert.ID)
        //                                       where Item.EmployeeCode == EmployeeCode && Item.IsCurrentNotify != 1
        //                                       select Item).SingleOrDefault;
        //            Added = AdvantageFramework.AlertSystem.AddAssigneeOrRecipient(DbContext, Alert, Employee, Alert.AlertAssignmentTemplateID, Alert.AlertStateID, AlertRecipient, AlertRecipientDismissed, false, Comment);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Added = false;
        //    }
        //    finally
        //    {
        //        AddRecipientRet = Added;
        //    }

        //    return AddRecipientRet;
        //}

        //public bool DeleteRecipient(int AlertID, string EmployeeCode)
        //{
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        return AdvantageFramework.AlertSystem.DeleteRecipient(DbContext, AlertID, EmployeeCode);
        //    }
        //}

        //public bool DeleteClientContact(int AlertID, int ClientContactID)
        //{
        //    bool Deleted = false;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        AdvantageFramework.Core.Database.Entities.ClientPortalAlertRecipient ClientPortalAlertRecipient = default;
        //        AdvantageFramework.Core.Database.Entities.ClientPortalAlertRecipientDismissed ClientPortalAlertRecipientDismissed = default;
        //        ClientPortalAlertRecipient = AdvantageFramework.Core.Database.Procedures.ClientPortalAlertRecipient.LoadByAlertIDAndContactID(DbContext, AlertID, ClientContactID);
        //        ClientPortalAlertRecipientDismissed = AdvantageFramework.Core.Database.Procedures.ClientPortalAlertRecipientDismissed.LoadByAlertIDAndContactID(DbContext, AlertID, ClientContactID);
        //        if (ClientPortalAlertRecipient is object)
        //        {
        //            Deleted = AdvantageFramework.Core.Database.Procedures.ClientPortalAlertRecipient.Delete(DbContext, ClientPortalAlertRecipient);
        //        }

        //        if (ClientPortalAlertRecipientDismissed is object)
        //        {
        //            Deleted = AdvantageFramework.Core.Database.Procedures.ClientPortalAlertRecipientDismissed.Delete(DbContext, ClientPortalAlertRecipientDismissed);
        //        }
        //    }

        //    return Deleted;
        //}

        //public bool AddClientContactRecipient(int AlertID, int ClientContactID)
        //{
        //    bool AddClientContactRecipientRet = default;
        //    AdvantageFramework.Core.Database.Entities.Alert Alert = default;
        //    bool Added = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Alert = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID);
        //            if (Alert is object)
        //            {
        //                Added = Conversions.ToBoolean(AddClientContactRecipient(DbContext, Alert, ClientContactID));
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Added = false;
        //    }
        //    finally
        //    {
        //        AddClientContactRecipientRet = Added;
        //    }

        //    return AddClientContactRecipientRet;
        //}

        //public object AddClientContactRecipient(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Alert Alert, int ClientContactID)
        //{
        //    object AddClientContactRecipientRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.ClientContact ClientContact = default;
        //    AdvantageFramework.Core.Database.Entities.ClientPortalAlertRecipient ClientPortalAlertRecipient = default;
        //    AdvantageFramework.Core.Database.Entities.ClientPortalAlertRecipientDismissed ClientPortalAlertRecipientDismissed = default;
        //    bool Added = false;
        //    try
        //    {
        //        ClientContact = AdvantageFramework.Core.Database.Procedures.ClientContact.LoadByContactID(DbContext, ClientContactID);
        //        if (ClientContact is object)
        //        {
        //            ClientPortalAlertRecipient = AdvantageFramework.Core.Database.Procedures.ClientPortalAlertRecipient.LoadByAlertIDAndContactID(DbContext, Alert.ID, ClientContactID);
        //            ClientPortalAlertRecipientDismissed = AdvantageFramework.Core.Database.Procedures.ClientPortalAlertRecipientDismissed.LoadByAlertIDAndContactID(DbContext, Alert.ID, ClientContactID);
        //            Added = AddClientContactAlertRecipient(DbContext, Alert, ClientContact, ClientPortalAlertRecipient, ClientPortalAlertRecipientDismissed, false);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Added = false;
        //    }
        //    finally
        //    {
        //        AddClientContactRecipientRet = Added;
        //    }

        //    return AddClientContactRecipientRet;
        //}

        //private bool AddClientContactAlertRecipient(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Alert Alert, AdvantageFramework.Core.Database.Entities.ClientContact ClientContact, AdvantageFramework.Core.Database.Entities.ClientPortalAlertRecipient ClientPortalAlertRecipient, AdvantageFramework.Core.Database.Entities.ClientPortalAlertRecipientDismissed ClientPortalAlertRecipientDismissed, bool IsAssignment)
        //{
        //    bool AddClientContactAlertRecipientRet = default;

        //    // objects
        //    bool Added = false;
        //    bool IsNew = false;
        //    string UserEmployeeCode = string.Empty;
        //    bool IsRoutedAssignment = false;
        //    bool IsTask = false;
        //    try
        //    {
        //        if (ClientContact is object)
        //        {
        //            if (Alert is object)
        //            {
        //                try
        //                {
        //                    if (Alert.AlertLevel == "BRD" || Alert.AlertLevel == "PST")
        //                    {
        //                        IsTask = true;
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    IsTask = false;
        //                }
        //            }

        //            if (ClientPortalAlertRecipient is null)
        //            {
        //                IsNew = true;
        //                ClientPortalAlertRecipient = new AdvantageFramework.Core.Database.Entities.ClientPortalAlertRecipient();
        //                ClientPortalAlertRecipient.DbContext = DbContext;
        //                ClientPortalAlertRecipient.ClientContactID = ClientContact.ContactID;
        //                ClientPortalAlertRecipient.AlertID = Alert.ID;
        //                if (ClientContact.GetEmails is object && ClientContact.GetEmails == 1)
        //                {
        //                    ClientPortalAlertRecipient.EmailAddress = ClientContact.EmailAddress;
        //                }

        //                if (ClientPortalAlertRecipientDismissed is object)
        //                {
        //                }
        //                else
        //                {
        //                    ClientPortalAlertRecipient.IsNewAlert = 1;
        //                }
        //            }
        //            else
        //            {
        //                ClientPortalAlertRecipient.IsNewAlert = null;
        //            }

        //            if (IsNew)
        //            {
        //                Added = AdvantageFramework.Core.Database.Procedures.ClientPortalAlertRecipient.Insert(DbContext, ClientPortalAlertRecipient);
        //                if (Added && ClientPortalAlertRecipientDismissed is object)
        //                {
        //                    AdvantageFramework.Core.Database.Procedures.ClientPortalAlertRecipientDismissed.Delete(DbContext, ClientPortalAlertRecipientDismissed);
        //                }
        //            }
        //            else
        //            {
        //                Added = AdvantageFramework.Core.Database.Procedures.ClientPortalAlertRecipient.Update(DbContext, ClientPortalAlertRecipient);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Added = false;
        //    }
        //    finally
        //    {
        //        AddClientContactAlertRecipientRet = Added;
        //    }

        //    return AddClientContactAlertRecipientRet;
        //}

        //public bool SendAssignment(ref AdvantageFramework.DTO.Desktop.Alert Alert, ref bool StateChanged, ref bool AssigneesChanged, bool AddUpdatedComment, ref string Message)
        //{
        //    bool SendAssignmentRet = default;

        //    // objects
        //    bool Sent = false;
        //    List<string> Errors = null;
        //    List<AdvantageFramework.DTO.Desktop.AlertRecipient> AlertRecipients = null;
        //    string ErrorMessage = string.Empty;
        //    try
        //    {
        //        Errors = new List<string>();
        //        if (Alert is object && Alert.IsWorkItem == true)
        //        {
        //            if (Alert.AlertAssignmentTemplateID.GetValueOrDefault(0) > 0 && Alert.AlertStateID.GetValueOrDefault(0) <= 0)
        //            {
        //                Errors.Add("Please select a State.");
        //            }

        //            if (Errors.Count == 0)
        //            {
        //                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //                {
        //                    if (Errors.Count == 0)
        //                    {
        //                        AdvantageFramework.AlertSystem.AssignmentHasAssignmentChanges(DbContext, Alert, StateChanged, AssigneesChanged);
        //                        if (Alert.Assignees is object)
        //                        {
        //                            Sent = AdvantageFramework.AlertSystem.ProcessAssignees(DbContext, Alert, Alert.Assignees.ToList, AddUpdatedComment, ErrorMessage);
        //                        }
        //                        else
        //                        {
        //                            var EmptyList = new List<string>();
        //                            Sent = AdvantageFramework.AlertSystem.ProcessAssignees(DbContext, Alert, EmptyList, AddUpdatedComment, ErrorMessage);
        //                        }
        //                    }

        //                    AdvantageFramework.Controller.ProjectManagement.AgileController.AddSprintEmployeeRecords(DbContext, Alert.ID);
        //                }
        //            }
        //            else
        //            {
        //                Message = string.Join(" ", Errors);
        //            }
        //        }
        //        else
        //        {
        //            Sent = true;
        //            Message = string.Empty;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Sent = false;
        //    }
        //    finally
        //    {
        //        if (!Sent && string.IsNullOrWhiteSpace(Message))
        //        {
        //            Message = "There was a problem sending the assignment. Please contact software support.";
        //        }

        //        SendAssignmentRet = Sent;
        //    }

        //    return SendAssignmentRet;
        //}

        //public bool AddUnAssignedComment(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Alert Alert, string SendAssignmentComment)
        //{
        //    bool Added = false;
        //    string StateName = string.Empty;
        //    var Comment = new AdvantageFramework.Core.Database.Entities.AlertComment();
        //    var RightNow = DateAndTime.Now;
        //    try
        //    {
        //        Comment.AlertID = Alert.ID;
        //        Comment.UserCode = DbContext.UserCode;
        //        Comment.GeneratedDate = RightNow;
        //        Comment.HasEmailBeenSent = false;
        //        try
        //        {
        //            if (Alert.AlertStateID is object && Alert.AlertStateID > 0)
        //            {
        //                StateName = DbContext.Database.SqlQuery<string>(string.Format("SELECT ALERT_STATE_NAME FROM ALERT_STATES WITH(NOLOCK) WHERE ALERT_STATE_ID = {0};", Alert.AlertStateID)).SingleOrDefault;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            StateName = string.Empty;
        //        }

        //        if (string.IsNullOrWhiteSpace(StateName) == false && Alert.AlertAssignmentTemplateID is object && Alert.AlertAssignmentTemplateID > 0 && Alert.AlertStateID is object && Alert.AlertStateID > 0)
        //        {
        //            Comment.Comment = string.Format("{0} | {1} | {2}", StateName.ToUpper(), "UNASSIGNED", SendAssignmentComment);
        //            Comment.AlertAssignmentTemplateID = Alert.AlertAssignmentTemplateID;
        //            Comment.AlertStateID = Alert.AlertStateID;
        //        }
        //        else
        //        {
        //            Comment.Comment = string.Format("{0} | {1}", "UNASSIGNED", SendAssignmentComment);
        //        }

        //        Added = AdvantageFramework.Core.Database.Procedures.AlertComment.Insert(DbContext, Comment);
        //    }
        //    catch (Exception ex)
        //    {
        //        Added = false;
        //    }

        //    return Added;
        //}

        //private bool AssigneeIsInCurrentState(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, string EmployeeCode)
        //{
        //    bool IsInCurrentState = false;
        //    System.Data.SqlClient.SqlParameter AlertIDSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter EmployeeCodeSqlParameter = null;
        //    AlertIDSqlParameter = new System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int);
        //    EmployeeCodeSqlParameter = new System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6);
        //    AlertIDSqlParameter.Value = AlertID;
        //    EmployeeCodeSqlParameter.Value = EmployeeCode;
        //    try
        //    {
        //        IsInCurrentState = DbContext.Database.SqlQuery<bool>("EXEC [dbo].[advsp_alert_assignee_is_in_current_state] @ALERT_ID, @EMP_CODE;", AlertIDSqlParameter, EmployeeCodeSqlParameter).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        IsInCurrentState = false;
        //    }

        //    return IsInCurrentState;
        //}

        //private bool ClearNonCurrentState(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID)
        //{
        //    bool StateCleared = false;
        //    System.Data.SqlClient.SqlParameter AlertIDSqlParameter = null;
        //    AlertIDSqlParameter = new System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int);
        //    AlertIDSqlParameter.Value = AlertID;
        //    try
        //    {
        //        StateCleared = DbContext.Database.SqlQuery<bool>("EXEC [dbo].[advsp_alert_clear_noncurrent_state] @ALERT_ID;", AlertIDSqlParameter).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        StateCleared = false;
        //    }

        //    return StateCleared;
        //}
        //// '''Private Function SendAssignmentComment(ByVal DbContext As AdvantageFramework.Core.Database.DbContext,
        //// '''                                       ByVal EmployeeCode As String,
        //// '''                                       ByVal CommentDate As DateTime,
        //// '''                                       ByVal Message As String) As Boolean

        //// '''    Dim Sent As Boolean = False
        //// '''    Dim AlertComment As New AdvantageFramework.Core.Database.Entities.AlertComment




        //// '''    Return Sent

        //// '''End Function
        //private bool AssigneeHasCommentAtCurrentState(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, string EmployeeCode)
        //{
        //    bool HasComment = false;
        //    System.Data.SqlClient.SqlParameter AlertIDSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter EmployeeCodeSqlParameter = null;
        //    AlertIDSqlParameter = new System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int);
        //    EmployeeCodeSqlParameter = new System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6);
        //    AlertIDSqlParameter.Value = AlertID;
        //    EmployeeCodeSqlParameter.Value = EmployeeCode;
        //    try
        //    {
        //        HasComment = DbContext.Database.SqlQuery<bool>("EXEC [dbo].[advsp_alert_assignee_has_current_state_comment] @ALERT_ID, @EMP_CODE;", AlertIDSqlParameter, EmployeeCodeSqlParameter).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        HasComment = false;
        //    }

        //    return HasComment;
        //}

        //public bool SaveNotifyAssignmentAlertRecipient(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, string EmployeeCode, int CommentType, int AlertStateID, int AlertNotifyHeaderID, string AlertComment, bool SaveUnassigned, bool IsNewAssignment, string ErrorMessage = "")
        //{
        //    return AdvantageFramework.AlertSystem.SaveNotifyAssignmentAlertRecipient(DbContext, AlertID, EmployeeCode, CommentType, AlertStateID, AlertNotifyHeaderID, AlertComment, SaveUnassigned, IsNewAssignment, ErrorMessage);
        //}

        //public bool DoesAlertHaveBoard(int AlertID)
        //{
        //    bool HasBoard = false;
        //    if (AlertID > 0)
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            try
        //            {
        //                HasBoard = DbContext.Database.SqlQuery<bool>(string.Format("SELECT [dbo].[advfn_alert_has_board]({0});", AlertID)).SingleOrDefault;
        //            }
        //            catch (Exception ex)
        //            {
        //                HasBoard = false;
        //            }
        //        }
        //    }

        //    return HasBoard;
        //}

        //public bool DismissAlert(AdvantageFramework.DTO.Desktop.Alert Alert)
        //{

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.Alert AlertEntity = default;
        //    bool Dismissed = false;
        //    bool ForceAssignmentComplete = false;
        //    string ErrorMessage = "";
        //    bool IsConceptShareReview = false;
        //    bool Update = true;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        AlertEntity = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID);
        //        try
        //        {
        //            if (AlertEntity.IsConceptShareReview is object && AlertEntity.IsConceptShareReview == true)
        //            {
        //                IsConceptShareReview = true;
        //                if (AlertEntity.AlertAssignmentTemplateID is null && AlertEntity.AlertStateID is null)
        //                {
        //                    AdvantageFramework.Core.Database.Entities.AlertRecipient Recipient = default;
        //                    Recipient = AdvantageFramework.Core.Database.Procedures.AlertRecipient.LoadByAlertIDAndEmployeeCode(DbContext, AlertEntity.ID, this.Session.User.EmployeeCode);
        //                    if (Recipient is object && Recipient.IsCurrentNotify is object && Recipient.IsCurrentNotify == 1)
        //                    {
        //                        Recipient.IsCurrentNotify = null;
        //                        AdvantageFramework.Core.Database.Procedures.AlertRecipient.Update(DbContext, Recipient);
        //                        ForceAssignmentComplete = false;
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            ForceAssignmentComplete = false;
        //        }

        //        if (AlertEntity is object && Update == true)
        //        {

        //            // If AlertEntity.IsWorkItem IsNot Nothing AndAlso AlertEntity.IsWorkItem = True Then

        //            // Dismissed = AdvantageFramework.AlertSystem.CompleteAssignment(DbContext, AlertEntity, Session.User.EmployeeCode, Session.UserCode, ErrorMessage)

        //            // Else

        //            Dismissed = AdvantageFramework.AlertSystem.DismissAlert(DbContext, Alert.ID, Session.User.EmployeeCode, Session.UserCode, 0, false, false, false, ErrorMessage);

        //            // End If

        //        }
        //    }

        //    return Dismissed;
        //}

        //public bool DismissAlertAAManager(int AlertID)
        //{

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.Alert AlertEntity = default;
        //    bool Dismissed = false;
        //    bool ForceAssignmentComplete = false;
        //    string ErrorMessage = "";
        //    bool IsConceptShareReview = false;
        //    bool Update = true;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        AlertEntity = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID);
        //        try
        //        {
        //            if (AlertEntity.IsConceptShareReview is object && AlertEntity.IsConceptShareReview == true)
        //            {
        //                IsConceptShareReview = true;
        //                if (AlertEntity.AlertAssignmentTemplateID is null && AlertEntity.AlertStateID is null)
        //                {
        //                    AdvantageFramework.Core.Database.Entities.AlertRecipient Recipient = default;
        //                    Recipient = AdvantageFramework.Core.Database.Procedures.AlertRecipient.LoadByAlertIDAndEmployeeCode(DbContext, AlertEntity.ID, this.Session.User.EmployeeCode);
        //                    if (Recipient is object && Recipient.IsCurrentNotify is object && Recipient.IsCurrentNotify == 1)
        //                    {
        //                        Recipient.IsCurrentNotify = null;
        //                        AdvantageFramework.Core.Database.Procedures.AlertRecipient.Update(DbContext, Recipient);
        //                        ForceAssignmentComplete = false;
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            ForceAssignmentComplete = false;
        //        }

        //        if (AlertEntity is object && Update == true)
        //        {

        //            // If AlertEntity.IsWorkItem IsNot Nothing AndAlso AlertEntity.IsWorkItem = True Then

        //            // Dismissed = AdvantageFramework.AlertSystem.CompleteAssignment(DbContext, AlertEntity, Session.User.EmployeeCode, Session.UserCode, ErrorMessage)

        //            // Else

        //            Dismissed = AdvantageFramework.AlertSystem.DismissAlert(DbContext, AlertID, Session.User.EmployeeCode, Session.UserCode, 0, false, false, false, ErrorMessage);

        //            // End If

        //        }
        //    }

        //    return Dismissed;
        //}

        //public bool DismissAlertCP(AdvantageFramework.DTO.Desktop.Alert Alert)
        //{

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.Alert AlertEntity = default;
        //    bool Dismissed = false;
        //    bool ForceAssignmentComplete = false;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        AlertEntity = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID);
        //        if (AlertEntity is object)
        //        {
        //            Dismissed = AdvantageFramework.AlertSystem.DismissAlert(DbContext, Alert.ID, "", Session.UserCode, Session.ClientPortalUser.ClientContactID, false, false, false, "");
        //        }
        //    }

        //    return Dismissed;
        //}

        //public bool DismissAlertComplete(AdvantageFramework.DTO.Desktop.Alert Alert)
        //{

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.Alert AlertEntity = default;
        //    bool Dismissed = false;
        //    string ErrorMessage = "";
        //    AdvantageFramework.AlertSystem.CompleteAssignmentResult CompleteResult = default;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        AlertEntity = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID);
        //        if (AlertEntity is object)
        //        {
        //            if (AlertEntity.IsWorkItem is object && AlertEntity.IsWorkItem == true)
        //            {
        //                CompleteResult = AdvantageFramework.AlertSystem.CompleteAssignment(DbContext, AlertEntity, Session.User.EmployeeCode, Session.UserCode, default, default);
        //                if (CompleteResult is object)
        //                    Dismissed = CompleteResult.Success;
        //            }
        //            else
        //            {
        //                Dismissed = AdvantageFramework.AlertSystem.DismissAlert(DbContext, Alert.ID, Session.User.EmployeeCode, Session.UserCode, 0, true, false, false, ErrorMessage);
        //            }
        //        }
        //    }

        //    return Dismissed;
        //}

        //public bool DismissAlertCompleteAAManager(int AlertID)
        //{

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.Alert AlertEntity = default;
        //    bool Dismissed = false;
        //    string ErrorMessage = "";
        //    AdvantageFramework.AlertSystem.CompleteAssignmentResult CompleteResult = default;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        AlertEntity = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID);
        //        if (AlertEntity is object)
        //        {
        //            if (AlertEntity.IsWorkItem is object && AlertEntity.IsWorkItem == true)
        //            {
        //                CompleteResult = AdvantageFramework.AlertSystem.CompleteAssignment(DbContext, AlertEntity, Session.User.EmployeeCode, Session.UserCode, default, default);
        //                if (CompleteResult is object)
        //                    Dismissed = CompleteResult.Success;
        //            }
        //            else
        //            {
        //                Dismissed = AdvantageFramework.AlertSystem.DismissAlert(DbContext, AlertID, Session.User.EmployeeCode, Session.UserCode, 0, true, false, false, ErrorMessage);
        //            }
        //        }
        //    }

        //    return Dismissed;
        //}

        //public bool UnDismissAlert(AdvantageFramework.DTO.Desktop.Alert Alert)
        //{

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.Alert AlertEntity = default;
        //    bool UnDismissed = false;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        AlertEntity = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID);
        //        if (AlertEntity is object)
        //        {
        //            UnDismissed = AdvantageFramework.AlertSystem.UnDismissAlert(DbContext, AlertEntity, this.Session.User.EmployeeCode, this.Session.UserCode);
        //        }
        //    }

        //    return UnDismissed;
        //}

        //public bool DoesJobHaveSchedule(int JobNumber, short JobComponentNumber)
        //{
        //    bool HasSchedule = false;
        //    if (JobNumber > 0 && JobComponentNumber > 0)
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            try
        //            {
        //                AdvantageFramework.Core.Database.Entities.JobTraffic Schedule = default;
        //                Schedule = AdvantageFramework.Core.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber);
        //                HasSchedule = Schedule is object;
        //            }
        //            catch (Exception ex)
        //            {
        //                HasSchedule = false;
        //            }
        //        }
        //    }

        //    return HasSchedule;
        //}

        //public bool ReopenAlert(AdvantageFramework.DTO.Desktop.Alert Alert)
        //{

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.Alert AlertEntity = default;
        //    bool Reopened = false;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        AlertEntity = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID);
        //        if (AlertEntity is object)
        //        {
        //            Reopened = ReopenAlert(DbContext, AlertEntity);
        //        }
        //    }

        //    return Reopened;
        //}

        //public bool ReopenAlert(AdvantageFramework.Core.Database.Entities.Alert Alert)
        //{

        //    // objects
        //    bool Reopened = false;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        Reopened = ReopenAlert(DbContext, Alert);
        //    }

        //    return Reopened;
        //}

        //public bool ReopenAlert(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Alert Alert)
        //{
        //    bool ReopenAlertRet = default;

        //    // objects
        //    bool AlertIsRealAssignment = false;
        //    bool Reopened = false;
        //    try
        //    {
        //        Alert.AssignmentCompleted = false;
        //        AlertIsRealAssignment = IsAlertRealAssignment(Alert);
        //        if (Alert.AlertLevel == "BRD")
        //        {
        //            DbContext.Database.ExecuteSqlCommand(string.Format("EXEC [dbo].[advsp_alert_auto_comment] {0}, '{1}', NULL, 1, 1;", Alert.ID, Session.UserCode));
        //            AdvantageFramework.ProjectSchedule.UnCompleteBoardTask(DbContext, Session.UserCode, Alert.ID, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber);
        //        }
        //        else if (Alert.IsWorkItem is object && Alert.IsWorkItem == true)
        //        {
        //            AdvantageFramework.AlertSystem.UnCompleteAssignment(DbContext, Alert, Session.User.EmployeeCode, Session.UserCode);
        //        }

        //        Reopened = AdvantageFramework.Core.Database.Procedures.Alert.Update(DbContext, Alert);
        //    }
        //    catch (Exception ex)
        //    {
        //        Reopened = false;
        //    }
        //    finally
        //    {
        //        ReopenAlertRet = Reopened;
        //    }

        //    return ReopenAlertRet;
        //}

        //public bool UnTempComplete(AdvantageFramework.DTO.Desktop.Alert Alert)
        //{
        //    bool TempCompleted = false;
        //    bool ShowFullyCompletePrompt = false;
        //    TempCompleted = TempComplete(Alert, ref ShowFullyCompletePrompt);
        //    return !TempCompleted;
        //}

        //public bool TempComplete(AdvantageFramework.DTO.Desktop.Alert Alert, ref bool ShowPrompt)
        //{
        //    bool TempCompleted = false;
        //    if (Alert is object && Alert.JobNumber is object && Alert.JobComponentNumber is object && Alert.TaskSequenceNumber is object)
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            AdvantageFramework.ProjectSchedule.LookupSettingsOptions FullyCompleteTask = Conversions.ToInteger(AdvantageFramework.ProjectSchedule.CompleteTaskInsteadOfTempCompleteSetting(DbContext));
        //            var Psc = new AdvantageFramework.Controller.ProjectManagement.ProjectScheduleController(this.Session);
        //            switch (FullyCompleteTask)
        //            {
        //                case var @case when @case == AdvantageFramework.ProjectSchedule.Methods.LookupSettingsOptions.Yes:
        //                    {
        //                        if (Psc.MarkTaskTempComplete(Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, this.Session.User.EmployeeCode, TempCompleted) == true)
        //                        {
        //                            if (AdvantageFramework.ProjectSchedule.CompleteTaskInsteadOfTempComplete(DbContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, this.Session.User.EmployeeCode, false))
        //                            {
        //                            }
        //                        }

        //                        break;
        //                    }

        //                case var case1 when case1 == AdvantageFramework.ProjectSchedule.Methods.LookupSettingsOptions.Prompt:
        //                    {
        //                        if (Psc.MarkTaskTempComplete(Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, this.Session.User.EmployeeCode, TempCompleted) == true)
        //                        {
        //                            if (AdvantageFramework.ProjectSchedule.CompleteTaskInsteadOfTempComplete(DbContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, this.Session.User.EmployeeCode, false))
        //                            {
        //                            }
        //                        }

        //                        ShowPrompt = true;
        //                        break;
        //                    }

        //                case var case2 when case2 == AdvantageFramework.ProjectSchedule.Methods.LookupSettingsOptions.No:
        //                    {
        //                        Psc.MarkTaskTempComplete(Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, this.Session.User.EmployeeCode, TempCompleted);
        //                        break;
        //                    }
        //            }
        //        }
        //    }

        //    return TempCompleted;
        //}

        //public AdvantageFramework.AlertSystem.CompleteAssignmentResult CompleteProof(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, string EmployeeCode)
        //{
        //    var Result = new AdvantageFramework.AlertSystem.CompleteAssignmentResult();
        //    try
        //    {
        //        DbContext.Database.ExecuteSqlCommand(string.Format("EXEC [dbo].[advsp_proofing_complete] '{0}', {1}, '{2}';", Session.UserCode, AlertID, EmployeeCode));
        //        Result.Success = true;
        //        Result.AssignmentFullyCompleted = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Result.Message = AdvantageFramework.StringUtilities.FullErrorToString(ex);
        //        Result.Success = false;
        //    }

        //    return Result;
        //}

        //public AdvantageFramework.AlertSystem.CompleteAssignmentResult CompleteAlert(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.DTO.Desktop.Alert Alert, ref bool StateChanged, ref bool AssigneesChanged)
        //{

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.Alert AlertEntity = default;
        //    AdvantageFramework.AlertSystem.CompleteAssignmentResult CompleteResult = default;
        //    AlertEntity = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID);
        //    if (AlertEntity is object)
        //    {
        //        CompleteResult = CompleteAlert(DbContext, AlertEntity);
        //        if (CompleteResult.Success == true)
        //        {
        //            AlertEntity = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID);
        //            if (AlertEntity is object)
        //            {
        //                AdvantageFramework.AlertSystem.AssignmentHasAssignmentChanges(DbContext, Alert, AlertEntity, StateChanged, AssigneesChanged);
        //            }
        //        }
        //    }

        //    return CompleteResult;
        //}

        //public AdvantageFramework.AlertSystem.CompleteAssignmentResult CompleteAlert(AdvantageFramework.Core.Database.Entities.Alert Alert)
        //{
        //    AdvantageFramework.AlertSystem.CompleteAssignmentResult CompleteResult = default;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        CompleteResult = CompleteAlert(DbContext, Alert);
        //    }

        //    return CompleteResult;
        //}

        //public AdvantageFramework.AlertSystem.CompleteAssignmentResult CompleteAlert(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Alert Alert)
        //{

        //    // objects
        //    bool AlertIsRealAssignment = false;
        //    bool Completed = false;
        //    bool IsTask = false;
        //    string ErrorMessage = "";
        //    AdvantageFramework.AlertSystem.CompleteAssignmentResult CompleteResult = default;
        //    try
        //    {
        //        AlertIsRealAssignment = IsAlertRealAssignment(Alert);
        //        try
        //        {
        //            if (AlertIsRealAssignment || Alert.IsWorkItem.GetValueOrDefault(false) == true)
        //            {
        //                if (Alert.AlertLevel == "PST")
        //                {

        //                    // Old path for temp complete stuff until cleaned up
        //                    Completed = AdvantageFramework.AlertSystem.DismissAlert(DbContext, Alert.ID, Session.User.EmployeeCode, Session.UserCode, 0, true, false, false, ErrorMessage);
        //                }
        //                else
        //                {
        //                    CompleteResult = AdvantageFramework.AlertSystem.CompleteAssignment(DbContext, Alert, Session.User.EmployeeCode, Session.UserCode, default, default);
        //                }

        //                // Refresh
        //                Alert = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID);
        //            }
        //            else
        //            {

        //                // AdvantageFramework.AlertSystem.CreateCompletedChangedComment(DbContext, Alert, Session.User.EmployeeCode)

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Completed = false;
        //            ErrorMessage = ex.Message.ToString();
        //        }

        //        if (AssignmentStillHasAssignees(DbContext, Alert.ID) == false)
        //        {

        //            // Alert.AssignmentCompleted = True

        //            if (Alert.AlertLevel == "BRD")
        //            {
        //                IsTask = true;
        //                AdvantageFramework.ProjectSchedule.CompleteTask(DbContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, Session.User.EmployeeCode, false);
        //                DbContext.Database.ExecuteSqlCommand(string.Format("EXEC [dbo].[advsp_alert_auto_comment] {0}, '{1}', NULL, 1, 0;", Alert.ID, Session.UserCode));

        //                // AdvantageFramework.ProjectManagement.Agile.ClearAllocatedHours(DbContext, Alert.JobNumber, Alert.JobComponentNumber,
        //                // Alert.TaskSequenceNumber, Session.User.EmployeeCode, False)

        //            }

        //            Completed = AdvantageFramework.Core.Database.Procedures.Alert.Update(DbContext, Alert);
        //            if (Completed == true && IsTask == false)
        //            {

        //                // AdvantageFramework.ProjectManagement.Agile.ClearAllocatedHours(DbContext, Alert.ID, Session.User.EmployeeCode, False)

        //            }
        //        }
        //        else
        //        {
        //            Completed = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Completed = false;
        //        ErrorMessage = ex.Message.ToString();
        //    }
        //    finally
        //    {
        //    }

        //    if (CompleteResult is null)
        //    {
        //        CompleteResult = new AdvantageFramework.AlertSystem.CompleteAssignmentResult();
        //        if (Completed == false)
        //        {
        //            CompleteResult.Success = false;
        //            if (string.IsNullOrWhiteSpace(ErrorMessage) == false)
        //            {
        //                CompleteResult.Message = ErrorMessage;
        //            }
        //        }
        //    }

        //    return CompleteResult;
        //}

        //private bool AssignmentStillHasAssignees(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID)
        //{
        //    return AdvantageFramework.AlertSystem.AssignmentStillHasAssignees(DbContext, AlertID);
        //}

        //private bool IsAlertRealAssignment(AdvantageFramework.Core.Database.Entities.Alert Alert)
        //{
        //    return AdvantageFramework.AlertSystem.IsAlertRealAssignment(Alert);
        //}

        //private bool IsBoardTaskAlert(AdvantageFramework.Core.Database.Entities.Alert Alert)
        //{
        //    return AdvantageFramework.AlertSystem.IsBoardTaskAlert(Alert);
        //}

        //private bool IsBoardTaskAlert(int AlertCategoryID)
        //{
        //    return AdvantageFramework.AlertSystem.IsBoardTaskAlert(AlertCategoryID);
        //}

        //public bool RemoveRecipient(int AlertID, string EmployeeCode)
        //{
        //    bool RemoveRecipientRet = default;

        //    // objects
        //    bool Removed = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Removed = Conversions.ToBoolean(RemoveRecipient(DbContext, AlertID, EmployeeCode));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Removed = false;
        //    }
        //    finally
        //    {
        //        RemoveRecipientRet = Removed;
        //    }

        //    return RemoveRecipientRet;
        //}

        //public object RemoveRecipient(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, string EmployeeCode)
        //{
        //    object RemoveRecipientRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AlertRecipient AlertRecipient = default;
        //    AdvantageFramework.Core.Database.Entities.AlertRecipientDismissed AlertRecipientDismissed = default;
        //    bool Removed = false;
        //    try
        //    {
        //        AlertRecipient = (from Item in AdvantageFramework.Core.Database.Procedures.AlertRecipient.LoadByAlertID(DbContext, AlertID)
        //                          where Item.EmployeeCode == EmployeeCode
        //                          select Item).SingleOrDefault;
        //        if (AlertRecipient is object)
        //        {
        //            DbContext.Entry(AlertRecipient).State = Entity.EntityState.Deleted;
        //        }

        //        AlertRecipientDismissed = (from Item in AdvantageFramework.Core.Database.Procedures.AlertRecipientDismissed.LoadByAlertID(DbContext, AlertID)
        //                                   where Item.EmployeeCode == EmployeeCode
        //                                   select Item).SingleOrDefault;
        //        if (AlertRecipientDismissed is object)
        //        {
        //            DbContext.Entry(AlertRecipientDismissed).State = Entity.EntityState.Deleted;
        //        }

        //        DbContext.SaveChanges();
        //        Removed = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Removed = false;
        //    }
        //    finally
        //    {
        //        RemoveRecipientRet = Removed;
        //    }

        //    return RemoveRecipientRet;
        //}

        //#region  Attachments 
        //public bool DeleteAttachment(AdvantageFramework.DTO.Desktop.AlertAttachment Attachment)
        //{
        //    bool DeleteAttachmentRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AlertAttachment AlertAttachment = default;
        //    AdvantageFramework.Core.Database.Entities.JobComponentTaskDocument TaskDocument = default;
        //    bool Deleted = false;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        if (Attachment.IsTaskDocument == false)
        //        {
        //            AlertAttachment = AdvantageFramework.Core.Database.Procedures.AlertAttachment.LoadByAlertAttachmentID(DbContext, Attachment.ID);
        //            if (AlertAttachment is object)
        //            {
        //                Deleted = DeleteAttachment(DbContext, AlertAttachment);
        //            }
        //        }
        //        else // Special path for tasks (ask Adam)
        //        {
        //            using (var DataContext = new AdvantageFramework.Core.Database.DataContext(this.Session.ConnectionString, this.Session.UserCode))
        //            {
        //                TaskDocument = AdvantageFramework.Core.Database.Procedures.JobComponentTaskDocument.LoadByDocumentID(DataContext, Attachment.DocumentID);
        //                if (TaskDocument is object)
        //                {
        //                    Deleted = DeleteTaskDocument(DbContext, DataContext, TaskDocument);
        //                }
        //            }
        //        }
        //    }

        //    DeleteAttachmentRet = Deleted;
        //    return DeleteAttachmentRet;
        //}

        //public bool DeleteAttachment(AdvantageFramework.Core.Database.Entities.AlertAttachment Attachment)
        //{
        //    bool DeleteAttachmentRet = default;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        DeleteAttachmentRet = DeleteAttachment(DbContext, Attachment);
        //    }

        //    return DeleteAttachmentRet;
        //}

        //public bool DeleteAttachment(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.AlertAttachment AlertAttachment)
        //{
        //    bool DeleteAttachmentRet = default;

        //    // objects
        //    bool Deleted = false;
        //    AdvantageFramework.Core.Database.Entities.Document Document = default;
        //    bool DeleteFromRepository = false;
        //    AdvantageFramework.Core.Database.Entities.Agency Agency = default;
        //    try
        //    {
        //        Document = AdvantageFramework.Core.Database.Procedures.Document.LoadByDocumentID(DbContext, AlertAttachment.DocumentID);
        //        if (Document is object)
        //        {
        //            if (Document.FileSystemFileName.StartsWith("a_")) // Only delete from repository if attachment was not uploaded to doc mgr level
        //            {
        //                DeleteFromRepository = true;
        //            }

        //            if (DeleteFromRepository == true)
        //            {
        //                Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
        //                AdvantageFramework.FileSystem.Delete(Agency, Document.FileSystemFileName);
        //            }

        //            if (AdvantageFramework.Core.Database.Procedures.AlertAttachment.Delete(DbContext, AlertAttachment))
        //            {
        //                AdvantageFramework.Core.Database.Procedures.Document.Delete(DbContext, Document);
        //                Deleted = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Deleted = true;
        //    }
        //    finally
        //    {
        //        DeleteAttachmentRet = Deleted;
        //    }

        //    return DeleteAttachmentRet;
        //}

        //public bool DeleteTaskDocument(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.DataContext DataContext, AdvantageFramework.Core.Database.Entities.JobComponentTaskDocument TaskDocument)
        //{
        //    bool DeleteTaskDocumentRet = default;

        //    // objects
        //    bool Deleted = false;
        //    AdvantageFramework.Core.Database.Entities.Document Document = default;
        //    bool DeleteFromRepository = false;
        //    AdvantageFramework.Core.Database.Entities.Agency Agency = default;
        //    try
        //    {
        //        Document = AdvantageFramework.Core.Database.Procedures.Document.LoadByDocumentID(DbContext, TaskDocument.DocumentID);
        //        if (Document is object)
        //        {
        //            if (Document.FileSystemFileName.StartsWith("a_"))
        //            {
        //                DeleteFromRepository = true;
        //            }

        //            if (DeleteFromRepository == true)
        //            {
        //                Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
        //                AdvantageFramework.FileSystem.Delete(Agency, Document.FileSystemFileName);
        //            }

        //            // delete task doc regardless if found in repository...
        //            if (AdvantageFramework.Core.Database.Procedures.JobComponentTaskDocument.Delete(DataContext, TaskDocument))
        //            {
        //                Deleted = true;

        //                // For Each DocumentAlertAttachment In AdvantageFramework.Core.Database.Procedures.JobComponentTaskDocument.LoadByDocumentID(DataContext, TaskDocument.DocumentID)

        //                // AdvantageFramework.Core.Database.Procedures.JobComponentTaskDocument.Delete(DbContext, DocumentAlertAttachment)

        //                // Next

        //                AdvantageFramework.Core.Database.Procedures.Document.Delete(DbContext, Document);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Deleted = true;
        //    }
        //    finally
        //    {
        //        DeleteTaskDocumentRet = Deleted;
        //    }

        //    return DeleteTaskDocumentRet;
        //}

        //public bool AddAlertAttachment(int AlertID, int DocumentID)
        //{

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AlertAttachment AlertAttachment = default;
        //    bool Added = false;
        //    if (DocumentID > 0)
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Added = AddAlertAttachment(DbContext, AlertID, DocumentID);
        //        }
        //    }

        //    return Added;
        //}

        //public bool AddAlertAttachment(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, int DocumentID)
        //{
        //    return AdvantageFramework.DocumentManager.AddAlertAttachment(DbContext, AlertID, DocumentID);
        //}

        //public bool SaveAttachments(int AlertID, IEnumerable<string> Files, bool UploadToRepository, bool UploadToProofHQ, ref string ErrorMessage, ref List<AdvantageFramework.Core.Database.Entities.Document> Documents)
        //{

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.Alert Alert = default;
        //    bool Saved = false;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        Alert = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID);
        //        if (Alert is object)
        //        {
        //            Saved = SaveAttachments(Alert, Files, UploadToRepository, UploadToProofHQ, ErrorMessage, Documents);
        //            if (Saved == true && Alert.AlertCategoryID == 79)
        //            {
        //                try
        //                {

        //                    // DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_proofing_get_approvals_list] {0};", AlertID))
        //                    AdvantageFramework.Proofing.ResetStatus(DbContext, AlertID, ErrorMessage);
        //                }
        //                catch (Exception ex)
        //                {
        //                }
        //            }
        //        }
        //    }

        //    return Saved;
        //}

        //public int GetUploadDelay()
        //{
        //    int DelayMilliseconds = 0;
        //    try
        //    {
        //        if (System.Web.Configuration.WebConfigurationManager.AppSettings.Get("UploadDelay") is object && Information.IsNumeric(System.Web.Configuration.WebConfigurationManager.AppSettings.Get("UploadDelay")) == true)
        //        {
        //            DelayMilliseconds = Conversions.ToInteger(System.Web.Configuration.WebConfigurationManager.AppSettings.Get("UploadDelay"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        DelayMilliseconds = 0;
        //    }

        //    return DelayMilliseconds;
        //}

        //public bool SaveAttachments(AdvantageFramework.Core.Database.Entities.Alert Alert, IEnumerable<string> Files, bool UploadToRepository, bool UploadToProofHQ, ref string ErrorMessage, ref List<AdvantageFramework.Core.Database.Entities.Document> Documents)
        //{
        //    bool SaveAttachmentsRet = default;

        //    // objects
        //    FileInfo FileInfo = null;
        //    bool IsValidFile = true;
        //    string Prefix = null;
        //    string RepositoryFileName = "";
        //    AdvantageFramework.Core.Database.Entities.Agency Agency = default;
        //    AdvantageFramework.FileSystem.DocumentSource DocumentSource = FileSystem.DocumentSource.Alert;
        //    AdvantageFramework.Core.Database.Entities.Document Document = default;
        //    string ProofHQUrl = "";
        //    int ProofHQFileID = 0;
        //    bool Saved = false;
        //    string RepositoryErrorMessage = string.Empty;
        //    int DelayMilliseconds = GetUploadDelay();
        //    int LastDocumentID = 0;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            using (var DataContext = new AdvantageFramework.Core.Database.DataContext(this.Session.ConnectionString, this.Session.UserCode))
        //            {
        //                Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
        //                Documents = new List<Database.Entities.Document>();
        //                foreach (var FullFileName in Files)
        //                {
        //                    RepositoryFileName = "";
        //                    RepositoryErrorMessage = "";
        //                    IsValidFile = true;
        //                    if (File.Exists(FullFileName))
        //                    {
        //                        FileInfo = new FileInfo(FullFileName);
        //                        if (FileInfo.Length > 0L)
        //                        {
        //                            AdvantageFramework.FileSystem.CheckRepositoryConstraints(DbContext, FullFileName, IsValidFile, RepositoryErrorMessage);
        //                            if (IsValidFile)
        //                            {
        //                                if (UploadToRepository)
        //                                {
        //                                    DocumentSource = FileSystem.DocumentSource.DocumentUpload;
        //                                }
        //                                else
        //                                {
        //                                    DocumentSource = FileSystem.DocumentSource.Alert;
        //                                }

        //                                if (AdvantageFramework.FileSystem.Add(Agency, FullFileName, "", "", this.Session.UserCode, "New Alert", "Attached Doc", DocumentSource, FileName: RepositoryFileName))
        //                                {
        //                                    if (!string.IsNullOrWhiteSpace(RepositoryFileName))
        //                                    {
        //                                        Document = new Database.Entities.Document();
        //                                        Document.FileSystemFileName = RepositoryFileName;
        //                                        Document.FileName = FileInfo.Name;
        //                                        Document.Description = null;
        //                                        Document.Keywords = null;
        //                                        Document.MIMEType = AdvantageFramework.FileSystem.GetMIMEType(FileInfo);
        //                                        Document.UploadedDate = DateAndTime.Now;
        //                                        Document.UserCode = this.Session.UserCode;
        //                                        Document.FileSize = FileInfo.Length;
        //                                        Document.IsPrivate = null;
        //                                        Document.DocumentTypeID = 2; // file
        //                                        try
        //                                        {
        //                                            if (Alert.AlertCategoryID == 79)
        //                                            {
        //                                                Document.VersionNumber = DbContext.Database.SqlQuery<int>(string.Format("SELECT ISNULL(MAX(ISNULL(VERSION_NUMBER, 0)) + 1, 1) FROM DOCUMENTS D WITH(NOLOCK) INNER JOIN ALERT_ATTACHMENT AA WITH(NOLOCK) ON D.DOCUMENT_ID = AA.DOCUMENT_ID WHERE AA.ALERT_ID = {0};", Alert.ID)).SingleOrDefault;
        //                                            }
        //                                        }
        //                                        catch (Exception ex)
        //                                        {
        //                                        }

        //                                        if (string.IsNullOrWhiteSpace(Document.MIMEType) == true || Document.MIMEType.Contains("unknown") == true)
        //                                        {
        //                                            Document.MIMEType = AdvantageFramework.FileSystem.GetMIMETypeByExtension(AdvantageFramework.StringUtilities.ParseLastDot(Document.FileName));
        //                                        }

        //                                        try
        //                                        {
        //                                            Document.ID = (from Entity in AdvantageFramework.Core.Database.Procedures.Document.Load(DbContext)
        //                                                           select Entity.ID).Max + 1;
        //                                        }
        //                                        catch (Exception ex)
        //                                        {
        //                                            Document.ID = 1;
        //                                        }

        //                                        if (AdvantageFramework.Core.Database.Procedures.Document.Insert(DbContext, Document))
        //                                        {
        //                                            if (Document.FileName.ToLower.EndsWith("png") || Document.FileName.ToLower.EndsWith("bmp") || Document.FileName.ToLower.EndsWith("tiff") || Document.FileName.ToLower.EndsWith("gif") || Document.FileName.ToLower.EndsWith("jpeg") || Document.FileName.ToLower.EndsWith("jpg"))
        //                                            {
        //                                                AdvantageFramework.DocumentManager.UpdateDocumentThumbnail(DbContext, Agency, Document.ID, default);
        //                                            }

        //                                            Documents.Add(Document);
        //                                            Saved = AddAlertAttachment(Alert.ID, Document.ID);
        //                                            if (Saved)
        //                                            {
        //                                                try
        //                                                {
        //                                                    DbContext.Database.ExecuteSqlCommand(string.Format("[dbo].[advsp_proofing_add_upload_comment] '{0}', {1}, {2};", this.Session.UserCode, Alert.ID, Document.ID));
        //                                                }
        //                                                catch (Exception ex)
        //                                                {
        //                                                }
        //                                            }

        //                                            if (UploadToRepository)
        //                                            {
        //                                                try
        //                                                {
        //                                                    switch (Alert.AlertLevel)
        //                                                    {
        //                                                        case "OF":
        //                                                            {
        //                                                                AdvantageFramework.DocumentManager.AddOfficeDocument(DbContext, Alert.OfficeCode, Document.ID);
        //                                                                break;
        //                                                            }

        //                                                        case "CL":
        //                                                            {
        //                                                                AdvantageFramework.DocumentManager.AddClientDocument(DataContext, Alert.ClientCode, Document.ID);
        //                                                                break;
        //                                                            }

        //                                                        case "DI":
        //                                                            {
        //                                                                AdvantageFramework.DocumentManager.AddDivisionDocument(DataContext, Alert.ClientCode, Alert.DivisionCode, Document.ID);
        //                                                                break;
        //                                                            }

        //                                                        case "PR":
        //                                                        case "PRD":
        //                                                            {
        //                                                                AdvantageFramework.DocumentManager.AddProductDocument(DataContext, Alert.ClientCode, Alert.DivisionCode, Alert.ProductCode, Document.ID);
        //                                                                break;
        //                                                            }

        //                                                        case "JO":
        //                                                            {
        //                                                                AdvantageFramework.DocumentManager.AddJobDocument(DataContext, Alert.JobNumber, Document.ID);
        //                                                                break;
        //                                                            }

        //                                                        case "JC":
        //                                                        case "ES":
        //                                                        case "EST":
        //                                                            {
        //                                                                AdvantageFramework.DocumentManager.AddJobComponentDocument(DataContext, Alert.JobNumber, Alert.JobComponentNumber, Document.ID);
        //                                                                break;
        //                                                            }

        //                                                        case "PST":
        //                                                        case "BRD":
        //                                                            {
        //                                                                AdvantageFramework.DocumentManager.AddTaskDocument(DataContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, Document.ID);
        //                                                                break;
        //                                                            }
        //                                                    }

        //                                                    if (UploadToProofHQ)
        //                                                    {
        //                                                        byte[] ByteFile = null;
        //                                                        ProofHQUrl = string.Empty;
        //                                                        ProofHQFileID = 0;
        //                                                        if (AdvantageFramework.FileSystem.Download(Agency, Document, ByteFile))
        //                                                        {
        //                                                            if (AdvantageFramework.ProofHQ.UploadFile(DbContext, DataContext, this.Session.User.EmployeeCode, ByteFile, Document.FileName, Document.FileName, "", "", 0, ProofHQUrl, ProofHQFileID))
        //                                                            {
        //                                                                if (string.IsNullOrWhiteSpace(ProofHQUrl) == false)
        //                                                                {
        //                                                                    Document.ProofHQUrl = ProofHQUrl;
        //                                                                    AdvantageFramework.Core.Database.Procedures.Document.Update(DbContext, Document);
        //                                                                }
        //                                                            }
        //                                                        }
        //                                                    }
        //                                                }
        //                                                catch (Exception ex)
        //                                                {
        //                                                }
        //                                            }
        //                                        }
        //                                        else if (string.IsNullOrWhiteSpace(ErrorMessage))
        //                                        {
        //                                            ErrorMessage = FileInfo.Name + " - failed adding file to database.";
        //                                        }
        //                                        else
        //                                        {
        //                                            ErrorMessage += FileInfo.Name + " - failed adding file to database.";
        //                                        }
        //                                    }
        //                                }
        //                                else if (string.IsNullOrWhiteSpace(ErrorMessage))
        //                                {
        //                                    ErrorMessage = FileInfo.Name + " - failed adding file to document repository (FileSystem).";
        //                                }
        //                                else
        //                                {
        //                                    ErrorMessage += FileInfo.Name + " - failed adding file to document repository (FileSystem).";
        //                                }
        //                            }
        //                            else if (string.IsNullOrWhiteSpace(ErrorMessage))
        //                            {
        //                                ErrorMessage = FileInfo.Name + " - " + RepositoryErrorMessage;
        //                            }
        //                            else
        //                            {
        //                                ErrorMessage += FileInfo.Name + " - " + RepositoryErrorMessage;
        //                            }
        //                        }
        //                        else if (string.IsNullOrWhiteSpace(ErrorMessage))
        //                        {
        //                            ErrorMessage = FileInfo.Name + " - cannot upload because it is empty.";
        //                        }
        //                        else
        //                        {
        //                            ErrorMessage += FileInfo.Name + " - cannot upload because it is empty.";
        //                        }
        //                    }
        //                    else if (string.IsNullOrWhiteSpace(ErrorMessage))
        //                    {
        //                        ErrorMessage = global::My.Computer.FileSystem.GetName(FullFileName) + " - Does not exist.";
        //                    }
        //                    else
        //                    {
        //                        ErrorMessage += Environment.NewLine + global::My.Computer.FileSystem.GetName(FullFileName) + " - Does not exist.";
        //                    }

        //                    try
        //                    {
        //                        if (DelayMilliseconds > 0)
        //                        {
        //                            System.Threading.Thread.Sleep(Conversions.ToInteger(System.Web.Configuration.WebConfigurationManager.AppSettings.Get("UploadDelay")));
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Saved = false;
        //    }
        //    finally
        //    {
        //        SaveAttachmentsRet = Saved;
        //    }

        //    return SaveAttachmentsRet;
        //}

        //public bool SaveAttachment(int AlertID, string FileName, bool UploadToRepository, bool UploadToProofHQ, ref string ErrorMessage)
        //{
        //    bool SaveAttachmentRet = default;
        //    List<AdvantageFramework.Core.Database.Entities.Document> argDocuments = null;
        //    SaveAttachmentRet = SaveAttachments(AlertID, new[] { FileName }, UploadToRepository, UploadToProofHQ, ref ErrorMessage, ref argDocuments);
        //    return SaveAttachmentRet;
        //}

        //public bool SaveAttachment(AdvantageFramework.Core.Database.Entities.Alert Alert, string FileName, bool UploadToRepository, bool UploadToProofHQ, ref string ErrorMessage)
        //{
        //    bool SaveAttachmentRet = default;
        //    SaveAttachmentRet = SaveAttachments(Alert, new[] { FileName }, UploadToRepository, UploadToProofHQ, ErrorMessage, default);
        //    return SaveAttachmentRet;
        //}

        //#endregion

        //public List<AdvantageFramework.DTO.Desktop.AlertRecipient> NotifyAlertRecipientsOfChanges(int AlertID)
        //{
        //    List<AdvantageFramework.DTO.Desktop.AlertRecipient> NotifyAlertRecipientsOfChangesRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.Alert Alert = default;
        //    List<AdvantageFramework.DTO.Desktop.AlertRecipient> AlertRecipients = null;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //    {
        //        Alert = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID);
        //        if (Alert is object)
        //        {
        //            AlertRecipients = NotifyAlertRecipientsOfChanges(DbContext, Alert);
        //        }
        //    }

        //    NotifyAlertRecipientsOfChangesRet = AlertRecipients;
        //    return NotifyAlertRecipientsOfChangesRet;
        //}

        //public List<AdvantageFramework.DTO.Desktop.AlertRecipient> NotifyAlertRecipientsOfChanges(AdvantageFramework.DTO.Desktop.Alert Alert)
        //{
        //    List<AdvantageFramework.DTO.Desktop.AlertRecipient> NotifyAlertRecipientsOfChangesRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.Alert AlertEntity = default;
        //    List<AdvantageFramework.DTO.Desktop.AlertRecipient> AlertRecipients = null;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //    {
        //        AlertEntity = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID);
        //        if (AlertEntity is object)
        //        {
        //            AlertRecipients = NotifyAlertRecipientsOfChanges(DbContext, AlertEntity);
        //        }
        //    }

        //    NotifyAlertRecipientsOfChangesRet = AlertRecipients;
        //    return NotifyAlertRecipientsOfChangesRet;
        //}

        //public List<AdvantageFramework.DTO.Desktop.AlertRecipient> NotifyAlertRecipientsOfChanges(AdvantageFramework.Core.Database.Entities.Alert Alert)
        //{
        //    List<AdvantageFramework.DTO.Desktop.AlertRecipient> NotifyAlertRecipientsOfChangesRet = default;

        //    // objects
        //    List<AdvantageFramework.DTO.Desktop.AlertRecipient> AlertRecipients = null;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //    {
        //        AlertRecipients = NotifyAlertRecipientsOfChanges(DbContext, Alert);
        //    }

        //    NotifyAlertRecipientsOfChangesRet = AlertRecipients;
        //    return NotifyAlertRecipientsOfChangesRet;
        //}

        //public List<AdvantageFramework.DTO.Desktop.AlertRecipient> NotifyAlertRecipientsOfChanges(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Alert Alert)
        //{
        //    List<AdvantageFramework.DTO.Desktop.AlertRecipient> NotifyAlertRecipientsOfChangesRet = default;

        //    // objects
        //    List<AdvantageFramework.Core.Database.Entities.AlertRecipientDismissed> AlertRecipientDismissedList = null;
        //    List<AdvantageFramework.Core.Database.Entities.AlertRecipient> AlertRecipientList = null;
        //    List<AdvantageFramework.DTO.Desktop.AlertRecipient> AlertRecipients = null;
        //    AdvantageFramework.Core.Database.Entities.Alert AlertEntity = default;
        //    AdvantageFramework.Core.Database.Views.Employee Employee = default;
        //    bool Add = false;
        //    try
        //    {
        //        AlertRecipientList = AdvantageFramework.Core.Database.Procedures.AlertRecipient.LoadByAlertID(DbContext, Alert.ID).ToList;
        //        if (AlertRecipientList is object && AlertRecipientList.Count > 0)
        //        {
        //            foreach (var AlertRecipient in AlertRecipientList)
        //            {
        //                Add = false;
        //                if (AlertRecipient.IsCurrentRecipient.GetValueOrDefault(0) == 0 || AlertRecipient.IsCurrentNotify.GetValueOrDefault(0) == 1)
        //                {
        //                    Employee = AdvantageFramework.Core.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, AlertRecipient.EmployeeCode);
        //                    if (AlertRecipient.IsCurrentNotify.GetValueOrDefault(0) == 1)
        //                    {
        //                        if ((Alert.AlertAssignmentTemplateID is null || Alert.AlertAssignmentTemplateID == 0) && (Alert.AlertStateID is null || Alert.AlertStateID == 0))
        //                        {
        //                            Add = true; // Non routed
        //                        }

        //                        if (AlertRecipient.AlertTemplateID == Alert.AlertAssignmentTemplateID && AlertRecipient.AlertStateID == Alert.AlertStateID)
        //                        {
        //                            Add = true; // Routed;  make sure it only includes "current" assignees and not former assignees.
        //                        }

        //                        if (Add == true)
        //                        {
        //                            AdvantageFramework.AlertSystem.AddAssignee(DbContext, Alert, Employee, Alert.AlertAssignmentTemplateID, Alert.AlertStateID, AlertRecipient, default, "");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        AdvantageFramework.AlertSystem.AddRecipient(DbContext, Alert, Employee.Code, "");
        //                    }
        //                }
        //            }
        //        }

        //        AlertRecipientDismissedList = AdvantageFramework.Core.Database.Procedures.AlertRecipientDismissed.LoadByAlertID(DbContext, Alert.ID).ToList;
        //        if (AlertRecipientDismissedList is object && AlertRecipientDismissedList.Count > 0)
        //        {
        //            foreach (var AlertRecipientDismissed in AlertRecipientDismissedList)
        //            {
        //                if (AlertRecipientDismissed.IsCurrentRecipient.GetValueOrDefault(0) == 0 || AlertRecipientDismissed.IsCurrentNotify.GetValueOrDefault(0) == 1)
        //                {
        //                    Employee = AdvantageFramework.Core.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, AlertRecipientDismissed.EmployeeCode);
        //                    if (AlertRecipientDismissed.IsCurrentNotify.GetValueOrDefault(0) == 1)
        //                    {
        //                        AdvantageFramework.AlertSystem.AddAssignee(DbContext, Alert, Employee, Alert.AlertAssignmentTemplateID, Alert.AlertStateID, default, AlertRecipientDismissed, "");
        //                    }
        //                    else
        //                    {
        //                        AddRecipient(DbContext, Alert, Employee.Code, "");
        //                    }
        //                }
        //            }
        //        }

        //        try
        //        {
        //            if (Alert.AlertLevel == "BRD")
        //            {
        //                AdvantageFramework.ProjectSchedule.MarkTaskNotReadForAllExcept(DbContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, this.Session.User.EmployeeCode);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //        }

        //        AlertRecipients = LoadAlertRecipients(DbContext, Alert.ID);
        //    }
        //    catch (Exception ex)
        //    {
        //        AlertRecipients = null;
        //    }
        //    finally
        //    {
        //        NotifyAlertRecipientsOfChangesRet = AlertRecipients;
        //    }

        //    return NotifyAlertRecipientsOfChangesRet;
        //}

        //public void LoadAppVars(AdvantageFramework.Core.Database.DbContext DbContext, ref bool AutoClose, ref string[] WidgetLayout, ref bool HideSystemComments, ref bool DetailsExpanded, ref bool ShowChecklistsOnCards, ref bool UploadDocumentManager)
        //{

        //    // objects
        //    List<AdvantageFramework.Core.Database.Entities.AppVars> AppVars = null;
        //    AppVars = GetAppVars(DbContext);
        //    AutoClose = GetAutoClose(AppVars);
        //    WidgetLayout = GetWidgetLayout(AppVars);
        //    HideSystemComments = GetShowHideSystemComments(AppVars);
        //    DetailsExpanded = GetDetailsExpanded(AppVars);
        //    ShowChecklistsOnCards = GetShowChecklistsOnCards(AppVars);
        //    UploadDocumentManager = GetUploadDocumentManager(AppVars);
        //}

        //public void LoadAppVars(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.ViewModels.Desktop.AlertView AlertView)
        //{
        //    LoadAppVars(DbContext, ref AlertView.AutoClose, ref AlertView.WidgetLayout, ref AlertView.HideSystemComments, ref AlertView.DetailsExpanded, ref AlertView.ShowChecklistsOnCards, ref AlertView.UploadDocumentManager);
        //}

        //public bool SetShowHideSystemComments(bool Hide)
        //{
        //    bool SetShowHideSystemCommentsRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool Success = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Success = SetShowHideSystemComments(DbContext, Hide);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Success = false;
        //    }
        //    finally
        //    {
        //        SetShowHideSystemCommentsRet = Success;
        //    }

        //    return SetShowHideSystemCommentsRet;
        //}

        //public bool SetShowHideSystemComments(AdvantageFramework.Core.Database.DbContext DbContext, bool Hide)
        //{
        //    bool SetShowHideSystemCommentsRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool Success = false;
        //    try
        //    {
        //        AppVar = GetShowHideSystemCommentsVariable(DbContext);
        //        if (AppVar is object)
        //        {
        //            AppVar.Value = Hide.ToString();
        //            if (AppVar.ID > 0)
        //            {
        //                Success = AdvantageFramework.Core.Database.Procedures.AppVars.Update(DbContext, AppVar);
        //            }
        //            else
        //            {
        //                Success = AdvantageFramework.Core.Database.Procedures.AppVars.Insert(DbContext, AppVar);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Success = false;
        //    }
        //    finally
        //    {
        //        SetShowHideSystemCommentsRet = Success;
        //    }

        //    return SetShowHideSystemCommentsRet;
        //}

        //public bool GetShowHideSystemComments()
        //{
        //    bool GetShowHideSystemCommentsRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool Hide = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Hide = GetShowHideSystemComments(DbContext);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Hide = false;
        //    }
        //    finally
        //    {
        //        GetShowHideSystemCommentsRet = Hide;
        //    }

        //    return GetShowHideSystemCommentsRet;
        //}

        //public bool GetShowHideSystemComments(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    bool GetShowHideSystemCommentsRet = default;

        //    // objects
        //    bool Hide = false;
        //    try
        //    {
        //        Hide = GetShowHideSystemComments(GetAppVars(DbContext));
        //    }
        //    catch (Exception ex)
        //    {
        //        Hide = false;
        //    }
        //    finally
        //    {
        //        GetShowHideSystemCommentsRet = Hide;
        //    }

        //    return GetShowHideSystemCommentsRet;
        //}

        //private bool GetShowHideSystemComments(List<AdvantageFramework.Core.Database.Entities.AppVars> AllAppVars)
        //{
        //    bool GetShowHideSystemCommentsRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool Hide = false;
        //    try
        //    {
        //        AppVar = GetShowHideSystemCommentsVariable(AllAppVars);
        //        if (AppVar is object)
        //        {
        //            Hide = AppVar.Value;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Hide = false;
        //    }
        //    finally
        //    {
        //        GetShowHideSystemCommentsRet = Hide;
        //    }

        //    return GetShowHideSystemCommentsRet;
        //}

        //private AdvantageFramework.Core.Database.Entities.AppVars GetShowHideSystemCommentsVariable(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    AdvantageFramework.Core.Database.Entities.AppVars GetShowHideSystemCommentsVariableRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    try
        //    {
        //        AppVar = GetShowHideSystemCommentsVariable(GetAppVars(DbContext));
        //    }
        //    catch (Exception ex)
        //    {
        //        AppVar = default;
        //    }
        //    finally
        //    {
        //        GetShowHideSystemCommentsVariableRet = AppVar;
        //    }

        //    return GetShowHideSystemCommentsVariableRet;
        //}

        //private AdvantageFramework.Core.Database.Entities.AppVars GetShowHideSystemCommentsVariable(List<AdvantageFramework.Core.Database.Entities.AppVars> AllAppVars)
        //{
        //    AdvantageFramework.Core.Database.Entities.AppVars GetShowHideSystemCommentsVariableRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    var Name = AppVars.ShowHideSystemComments;
        //    try
        //    {
        //        AppVar = GetAppVar(AllAppVars, Name);
        //        if (AppVar is null)
        //        {
        //            AppVar = new Database.Entities.AppVars();
        //            AppVar.Name = Name.ToString();
        //            AppVar.Application = _AppVarApplication;
        //            AppVar.UserCode = this.Session.UserCode;
        //            AppVar.Value = false.ToString();
        //        }

        //        AppVar.Type = "Boolean";
        //        AppVar.Group = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        AppVar = default;
        //    }
        //    finally
        //    {
        //        GetShowHideSystemCommentsVariableRet = AppVar;
        //    }

        //    return GetShowHideSystemCommentsVariableRet;
        //}

        //public bool SetAutoClose(bool AutoClose)
        //{
        //    bool SetAutoCloseRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool Success = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Success = SetAutoClose(DbContext, AutoClose);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Success = false;
        //    }
        //    finally
        //    {
        //        SetAutoCloseRet = Success;
        //    }

        //    return SetAutoCloseRet;
        //}

        //public bool SetAutoClose(AdvantageFramework.Core.Database.DbContext DbContext, bool AutoClose)
        //{
        //    bool SetAutoCloseRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool Success = false;
        //    try
        //    {
        //        AppVar = GetAutoCloseVariable(DbContext);
        //        if (AppVar is object)
        //        {
        //            AppVar.Value = AutoClose.ToString();
        //            if (AppVar.ID > 0)
        //            {
        //                Success = AdvantageFramework.Core.Database.Procedures.AppVars.Update(DbContext, AppVar);
        //            }
        //            else
        //            {
        //                Success = AdvantageFramework.Core.Database.Procedures.AppVars.Insert(DbContext, AppVar);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Success = false;
        //    }
        //    finally
        //    {
        //        SetAutoCloseRet = Success;
        //    }

        //    return SetAutoCloseRet;
        //}

        //public bool GetAutoClose()
        //{
        //    bool GetAutoCloseRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool AutoClose = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            AutoClose = GetAutoClose(DbContext);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AutoClose = false;
        //    }
        //    finally
        //    {
        //        GetAutoCloseRet = AutoClose;
        //    }

        //    return GetAutoCloseRet;
        //}

        //public bool GetAutoClose(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    bool GetAutoCloseRet = default;

        //    // objects
        //    bool AutoClose = false;
        //    try
        //    {
        //        AutoClose = GetAutoClose(GetAppVars(DbContext));
        //    }
        //    catch (Exception ex)
        //    {
        //        AutoClose = false;
        //    }
        //    finally
        //    {
        //        GetAutoCloseRet = AutoClose;
        //    }

        //    return GetAutoCloseRet;
        //}

        //private bool GetAutoClose(List<AdvantageFramework.Core.Database.Entities.AppVars> AllAppVars)
        //{
        //    bool GetAutoCloseRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool AutoClose = false;
        //    try
        //    {
        //        AppVar = GetAutoCloseVariable(AllAppVars);
        //        if (AppVar is object)
        //        {
        //            AutoClose = AppVar.Value;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AutoClose = false;
        //    }
        //    finally
        //    {
        //        GetAutoCloseRet = AutoClose;
        //    }

        //    return GetAutoCloseRet;
        //}

        //private AdvantageFramework.Core.Database.Entities.AppVars GetAutoCloseVariable(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    AdvantageFramework.Core.Database.Entities.AppVars GetAutoCloseVariableRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    try
        //    {
        //        AppVar = GetAutoCloseVariable(GetAppVars(DbContext));
        //    }
        //    catch (Exception ex)
        //    {
        //        AppVar = default;
        //    }
        //    finally
        //    {
        //        GetAutoCloseVariableRet = AppVar;
        //    }

        //    return GetAutoCloseVariableRet;
        //}

        //private AdvantageFramework.Core.Database.Entities.AppVars GetAutoCloseVariable(List<AdvantageFramework.Core.Database.Entities.AppVars> AllAppVars)
        //{
        //    AdvantageFramework.Core.Database.Entities.AppVars GetAutoCloseVariableRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    var Name = AppVars.CloseAfterCommentOrReAssign;
        //    try
        //    {
        //        AppVar = GetAppVar(AllAppVars, Name);
        //        if (AppVar is null)
        //        {
        //            AppVar = new Database.Entities.AppVars();
        //            AppVar.Name = Name.ToString();
        //            AppVar.Application = _AppVarApplication;
        //            AppVar.UserCode = this.Session.UserCode;
        //            AppVar.Value = false.ToString();
        //        }

        //        AppVar.Type = "Boolean";
        //        AppVar.Group = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        AppVar = default;
        //    }
        //    finally
        //    {
        //        GetAutoCloseVariableRet = AppVar;
        //    }

        //    return GetAutoCloseVariableRet;
        //}

        //public bool SetShowChecklistsOnCards(bool ShowChecklistsOnCards)
        //{
        //    bool SetShowChecklistsOnCardsRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool Success = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Success = SetShowChecklistsOnCards(DbContext, ShowChecklistsOnCards);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Success = false;
        //    }
        //    finally
        //    {
        //        SetShowChecklistsOnCardsRet = Success;
        //    }

        //    return SetShowChecklistsOnCardsRet;
        //}

        //public bool SetShowChecklistsOnCards(AdvantageFramework.Core.Database.DbContext DbContext, bool ShowChecklistsOnCards)
        //{
        //    bool SetShowChecklistsOnCardsRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool Success = false;
        //    try
        //    {
        //        AppVar = GetGetShowChecklistsOnCardsVariable(DbContext);
        //        if (AppVar is object)
        //        {
        //            AppVar.Value = ShowChecklistsOnCards.ToString();
        //            if (AppVar.ID > 0)
        //            {
        //                Success = AdvantageFramework.Core.Database.Procedures.AppVars.Update(DbContext, AppVar);
        //            }
        //            else
        //            {
        //                Success = AdvantageFramework.Core.Database.Procedures.AppVars.Insert(DbContext, AppVar);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Success = false;
        //    }
        //    finally
        //    {
        //        SetShowChecklistsOnCardsRet = Success;
        //    }

        //    return SetShowChecklistsOnCardsRet;
        //}

        //public bool GetShowChecklistsOnCards()
        //{
        //    bool GetShowChecklistsOnCardsRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool AutoClose = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            AutoClose = GetShowChecklistsOnCards(DbContext);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AutoClose = false;
        //    }
        //    finally
        //    {
        //        GetShowChecklistsOnCardsRet = AutoClose;
        //    }

        //    return GetShowChecklistsOnCardsRet;
        //}

        //public bool GetShowChecklistsOnCards(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    bool GetShowChecklistsOnCardsRet = default;

        //    // objects
        //    bool AutoClose = false;
        //    try
        //    {
        //        AutoClose = GetShowChecklistsOnCards(GetAppVars(DbContext));
        //    }
        //    catch (Exception ex)
        //    {
        //        AutoClose = false;
        //    }
        //    finally
        //    {
        //        GetShowChecklistsOnCardsRet = AutoClose;
        //    }

        //    return GetShowChecklistsOnCardsRet;
        //}

        //private bool GetShowChecklistsOnCards(List<AdvantageFramework.Core.Database.Entities.AppVars> AllAppVars)
        //{
        //    bool GetShowChecklistsOnCardsRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool ShowChecklistsOnCards = false;
        //    try
        //    {
        //        AppVar = GetGetShowChecklistsOnCardsVariable(AllAppVars);
        //        if (AppVar is object)
        //        {
        //            ShowChecklistsOnCards = AppVar.Value;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowChecklistsOnCards = false;
        //    }
        //    finally
        //    {
        //        GetShowChecklistsOnCardsRet = ShowChecklistsOnCards;
        //    }

        //    return GetShowChecklistsOnCardsRet;
        //}

        //private AdvantageFramework.Core.Database.Entities.AppVars GetGetShowChecklistsOnCardsVariable(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    AdvantageFramework.Core.Database.Entities.AppVars GetGetShowChecklistsOnCardsVariableRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    try
        //    {
        //        AppVar = GetGetShowChecklistsOnCardsVariable(GetAppVars(DbContext));
        //    }
        //    catch (Exception ex)
        //    {
        //        AppVar = default;
        //    }
        //    finally
        //    {
        //        GetGetShowChecklistsOnCardsVariableRet = AppVar;
        //    }

        //    return GetGetShowChecklistsOnCardsVariableRet;
        //}

        //private AdvantageFramework.Core.Database.Entities.AppVars GetGetShowChecklistsOnCardsVariable(List<AdvantageFramework.Core.Database.Entities.AppVars> AllAppVars)
        //{
        //    AdvantageFramework.Core.Database.Entities.AppVars GetGetShowChecklistsOnCardsVariableRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    var Name = AppVars.ShowChecklistsOnCards;
        //    try
        //    {
        //        AppVar = GetAppVar(AllAppVars, Name);
        //        if (AppVar is null)
        //        {
        //            AppVar = new Database.Entities.AppVars();
        //            AppVar.Name = Name.ToString();
        //            AppVar.Application = _AppVarApplication;
        //            AppVar.UserCode = this.Session.UserCode;
        //            AppVar.Value = false.ToString();
        //        }

        //        AppVar.Type = "Boolean";
        //        AppVar.Group = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        AppVar = default;
        //    }
        //    finally
        //    {
        //        GetGetShowChecklistsOnCardsVariableRet = AppVar;
        //    }

        //    return GetGetShowChecklistsOnCardsVariableRet;
        //}

        //public bool SetUploadDocumentManager(bool Upload)
        //{
        //    bool SetUploadDocumentManagerRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool Success = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Success = SetUploadDocumentManager(DbContext, Upload);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Success = false;
        //    }
        //    finally
        //    {
        //        SetUploadDocumentManagerRet = Success;
        //    }

        //    return SetUploadDocumentManagerRet;
        //}

        //public bool SetUploadDocumentManager(AdvantageFramework.Core.Database.DbContext DbContext, bool Upload)
        //{
        //    bool SetUploadDocumentManagerRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool Success = false;
        //    try
        //    {
        //        AppVar = GetUploadDocumentManagerVariable(DbContext);
        //        if (AppVar is object)
        //        {
        //            AppVar.Value = Upload.ToString();
        //            if (AppVar.ID > 0)
        //            {
        //                Success = AdvantageFramework.Core.Database.Procedures.AppVars.Update(DbContext, AppVar);
        //            }
        //            else
        //            {
        //                Success = AdvantageFramework.Core.Database.Procedures.AppVars.Insert(DbContext, AppVar);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Success = false;
        //    }
        //    finally
        //    {
        //        SetUploadDocumentManagerRet = Success;
        //    }

        //    return SetUploadDocumentManagerRet;
        //}

        //public bool GetUploadDocumentManager()
        //{
        //    bool GetUploadDocumentManagerRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool Upload = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Upload = GetUploadDocumentManager(DbContext);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Upload = false;
        //    }
        //    finally
        //    {
        //        GetUploadDocumentManagerRet = Upload;
        //    }

        //    return GetUploadDocumentManagerRet;
        //}

        //public bool GetUploadDocumentManager(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    bool GetUploadDocumentManagerRet = default;

        //    // objects
        //    bool Upload = false;
        //    try
        //    {
        //        Upload = GetUploadDocumentManager(GetAppVars(DbContext));
        //    }
        //    catch (Exception ex)
        //    {
        //        Upload = false;
        //    }
        //    finally
        //    {
        //        GetUploadDocumentManagerRet = Upload;
        //    }

        //    return GetUploadDocumentManagerRet;
        //}

        //private bool GetUploadDocumentManager(List<AdvantageFramework.Core.Database.Entities.AppVars> AllAppVars)
        //{
        //    bool GetUploadDocumentManagerRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool Upload = false;
        //    try
        //    {
        //        AppVar = GetUploadDocumentManagerVariable(AllAppVars);
        //        if (AppVar is object)
        //        {
        //            Upload = AppVar.Value;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Upload = false;
        //    }
        //    finally
        //    {
        //        GetUploadDocumentManagerRet = Upload;
        //    }

        //    return GetUploadDocumentManagerRet;
        //}

        //private AdvantageFramework.Core.Database.Entities.AppVars GetUploadDocumentManagerVariable(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    AdvantageFramework.Core.Database.Entities.AppVars GetUploadDocumentManagerVariableRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    try
        //    {
        //        AppVar = GetUploadDocumentManagerVariable(GetAppVars(DbContext));
        //    }
        //    catch (Exception ex)
        //    {
        //        AppVar = default;
        //    }
        //    finally
        //    {
        //        GetUploadDocumentManagerVariableRet = AppVar;
        //    }

        //    return GetUploadDocumentManagerVariableRet;
        //}

        //private AdvantageFramework.Core.Database.Entities.AppVars GetUploadDocumentManagerVariable(List<AdvantageFramework.Core.Database.Entities.AppVars> AllAppVars)
        //{
        //    AdvantageFramework.Core.Database.Entities.AppVars GetUploadDocumentManagerVariableRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    var Name = AppVars.UploadDocumentManager;
        //    try
        //    {
        //        AppVar = GetAppVar(AllAppVars, Name);
        //        if (AppVar is null)
        //        {
        //            AppVar = new Database.Entities.AppVars();
        //            AppVar.Name = Name.ToString();
        //            AppVar.Application = _AppVarApplication;
        //            AppVar.UserCode = this.Session.UserCode;
        //            AppVar.Value = false.ToString();
        //        }

        //        AppVar.Type = "Boolean";
        //        AppVar.Group = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        AppVar = default;
        //    }
        //    finally
        //    {
        //        GetUploadDocumentManagerVariableRet = AppVar;
        //    }

        //    return GetUploadDocumentManagerVariableRet;
        //}

        //public bool SetDetailsExpanded(bool Expanded)
        //{
        //    bool SetDetailsExpandedRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool Success = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Success = SetDetailsExpanded(DbContext, Expanded);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Success = false;
        //    }
        //    finally
        //    {
        //        SetDetailsExpandedRet = Success;
        //    }

        //    return SetDetailsExpandedRet;
        //}

        //public bool SetDetailsExpanded(AdvantageFramework.Core.Database.DbContext DbContext, bool Expanded)
        //{
        //    bool SetDetailsExpandedRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool Success = false;
        //    try
        //    {
        //        AppVar = GetDetailsExpandedVariable(DbContext);
        //        if (AppVar is object)
        //        {
        //            AppVar.Value = Expanded.ToString();
        //            if (AppVar.ID > 0)
        //            {
        //                Success = AdvantageFramework.Core.Database.Procedures.AppVars.Update(DbContext, AppVar);
        //            }
        //            else
        //            {
        //                Success = AdvantageFramework.Core.Database.Procedures.AppVars.Insert(DbContext, AppVar);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Success = false;
        //    }
        //    finally
        //    {
        //        SetDetailsExpandedRet = Success;
        //    }

        //    return SetDetailsExpandedRet;
        //}

        //public bool GetDetailsExpanded()
        //{
        //    bool GetDetailsExpandedRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool Expanded = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Expanded = GetDetailsExpanded(DbContext);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Expanded = false;
        //    }
        //    finally
        //    {
        //        GetDetailsExpandedRet = Expanded;
        //    }

        //    return GetDetailsExpandedRet;
        //}

        //public bool GetDetailsExpanded(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    bool GetDetailsExpandedRet = default;

        //    // objects
        //    bool Expanded = false;
        //    try
        //    {
        //        Expanded = GetDetailsExpanded(GetAppVars(DbContext));
        //    }
        //    catch (Exception ex)
        //    {
        //        Expanded = false;
        //    }
        //    finally
        //    {
        //        GetDetailsExpandedRet = Expanded;
        //    }

        //    return GetDetailsExpandedRet;
        //}

        //private bool GetDetailsExpanded(List<AdvantageFramework.Core.Database.Entities.AppVars> AllAppVars)
        //{
        //    bool GetDetailsExpandedRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool Expanded = false;
        //    try
        //    {
        //        AppVar = GetDetailsExpandedVariable(AllAppVars);
        //        if (AppVar is object)
        //        {
        //            Expanded = AppVar.Value;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Expanded = false;
        //    }
        //    finally
        //    {
        //        GetDetailsExpandedRet = Expanded;
        //    }

        //    return GetDetailsExpandedRet;
        //}

        //private AdvantageFramework.Core.Database.Entities.AppVars GetDetailsExpandedVariable(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    AdvantageFramework.Core.Database.Entities.AppVars GetDetailsExpandedVariableRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    try
        //    {
        //        AppVar = GetDetailsExpandedVariable(GetAppVars(DbContext));
        //    }
        //    catch (Exception ex)
        //    {
        //        AppVar = default;
        //    }
        //    finally
        //    {
        //        GetDetailsExpandedVariableRet = AppVar;
        //    }

        //    return GetDetailsExpandedVariableRet;
        //}

        //private AdvantageFramework.Core.Database.Entities.AppVars GetDetailsExpandedVariable(List<AdvantageFramework.Core.Database.Entities.AppVars> AllAppVars)
        //{
        //    AdvantageFramework.Core.Database.Entities.AppVars GetDetailsExpandedVariableRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    var Name = AppVars.DetailsExpanded;
        //    try
        //    {
        //        AppVar = GetAppVar(AllAppVars, Name);
        //        if (AppVar is null)
        //        {
        //            AppVar = new Database.Entities.AppVars();
        //            AppVar.Name = Name.ToString();
        //            AppVar.Application = _AppVarApplication;
        //            AppVar.UserCode = this.Session.UserCode;
        //            AppVar.Value = true.ToString();
        //        }

        //        AppVar.Type = "Boolean";
        //        AppVar.Group = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        AppVar = default;
        //    }
        //    finally
        //    {
        //        GetDetailsExpandedVariableRet = AppVar;
        //    }

        //    return GetDetailsExpandedVariableRet;
        //}

        //public bool SetWidgetLayout(string[] WidgetLayout)
        //{
        //    bool SetWidgetLayoutRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool Success = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Success = SetWidgetLayout(DbContext, WidgetLayout);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Success = false;
        //    }
        //    finally
        //    {
        //        SetWidgetLayoutRet = Success;
        //    }

        //    return SetWidgetLayoutRet;
        //}

        //public bool SetWidgetLayout(AdvantageFramework.Core.Database.DbContext DbContext, string[] WidgetLayout)
        //{
        //    bool SetWidgetLayoutRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    bool Success = false;
        //    try
        //    {
        //        AppVar = GetWidgetLayoutVariable(DbContext);
        //        if (AppVar is object)
        //        {
        //            AppVar.Value = string.Join(",", WidgetLayout);
        //            if (AppVar.ID > 0)
        //            {
        //                Success = AdvantageFramework.Core.Database.Procedures.AppVars.Update(DbContext, AppVar);
        //            }
        //            else
        //            {
        //                Success = AdvantageFramework.Core.Database.Procedures.AppVars.Insert(DbContext, AppVar);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Success = false;
        //    }
        //    finally
        //    {
        //        SetWidgetLayoutRet = Success;
        //    }

        //    return SetWidgetLayoutRet;
        //}

        //public string[] GetWidgetLayout()
        //{
        //    string[] GetWidgetLayoutRet = default;

        //    // objects
        //    string[] WidgetLayout = null;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            WidgetLayout = GetWidgetLayout(DbContext);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WidgetLayout = null;
        //    }
        //    finally
        //    {
        //        GetWidgetLayoutRet = WidgetLayout;
        //    }

        //    return GetWidgetLayoutRet;
        //}

        //public string[] GetWidgetLayout(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    string[] GetWidgetLayoutRet = default;

        //    // objects
        //    string[] WidgetLayout = null;
        //    try
        //    {
        //        WidgetLayout = GetWidgetLayout(GetAppVars(DbContext));
        //    }
        //    catch (Exception ex)
        //    {
        //        WidgetLayout = null;
        //    }
        //    finally
        //    {
        //        GetWidgetLayoutRet = WidgetLayout;
        //    }

        //    return GetWidgetLayoutRet;
        //}

        //private string[] GetWidgetLayout(List<AdvantageFramework.Core.Database.Entities.AppVars> AllAppVars)
        //{
        //    string[] GetWidgetLayoutRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    string[] WidgetLayout = null;
        //    try
        //    {
        //        AppVar = GetWidgetLayoutVariable(AllAppVars);
        //        if (AppVar is object)
        //        {
        //            WidgetLayout = AppVar.Value.Split(",");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WidgetLayout = null;
        //    }
        //    finally
        //    {
        //        GetWidgetLayoutRet = WidgetLayout;
        //    }

        //    return GetWidgetLayoutRet;
        //}

        //private AdvantageFramework.Core.Database.Entities.AppVars GetWidgetLayoutVariable(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    AdvantageFramework.Core.Database.Entities.AppVars GetWidgetLayoutVariableRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    try
        //    {
        //        AppVar = GetWidgetLayoutVariable(GetAppVars(DbContext));
        //    }
        //    catch (Exception ex)
        //    {
        //        AppVar = default;
        //    }
        //    finally
        //    {
        //        GetWidgetLayoutVariableRet = AppVar;
        //    }

        //    return GetWidgetLayoutVariableRet;
        //}

        //private AdvantageFramework.Core.Database.Entities.AppVars GetWidgetLayoutVariable(List<AdvantageFramework.Core.Database.Entities.AppVars> AllAppVars)
        //{
        //    AdvantageFramework.Core.Database.Entities.AppVars GetWidgetLayoutVariableRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    try
        //    {
        //        AppVar = GetAppVar(AllAppVars, AppVars.WidgetLayout);
        //        if (AppVar is null)
        //        {
        //            AppVar = new Database.Entities.AppVars();
        //            AppVar.Name = AppVars.WidgetLayout.ToString();
        //            AppVar.Application = _AppVarApplication;
        //            AppVar.UserCode = this.Session.UserCode;
        //        }

        //        if (string.IsNullOrWhiteSpace(AppVar.Value))
        //        {
        //            AppVar.Value = "hours,comments,assignment";
        //        }

        //        AppVar.Type = "String";
        //        AppVar.Group = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        AppVar = default;
        //    }
        //    finally
        //    {
        //        GetWidgetLayoutVariableRet = AppVar;
        //    }

        //    return GetWidgetLayoutVariableRet;
        //}

        //public bool LinkExistingDocuments(int AlertID, int[] DocumentIDs)
        //{
        //    bool LinkExistingDocumentsRet = default;

        //    // objects
        //    bool Linked = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            foreach (var DocumentID in DocumentIDs.Where(ID => ID > 0).Distinct().ToList())
        //            {
        //                if (!AdvantageFramework.Core.Database.Procedures.AlertAttachment.LoadByAlertID(DbContext, AlertID).Where(alert => Operators.ConditionalCompareObjectEqual(alert.DocumentID, DocumentID, false)).Any)
        //                {
        //                    if (AddAlertAttachment(DbContext, AlertID, DocumentID))
        //                    {
        //                        Linked = true;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Linked = false;
        //    }
        //    finally
        //    {
        //        LinkExistingDocumentsRet = Linked;
        //    }

        //    return LinkExistingDocumentsRet;
        //}

        //private List<AdvantageFramework.Core.Database.Entities.AppVars> GetAppVars(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    return AdvantageFramework.Core.Database.Procedures.AppVars.LoadByApplicationName(DbContext, this.Session.UserCode, _AppVarApplication).ToList;
        //}

        //private AdvantageFramework.Core.Database.Entities.AppVars GetAppVar(AdvantageFramework.Core.Database.DbContext DbContext, AppVars AppVarKey)
        //{
        //    AdvantageFramework.Core.Database.Entities.AppVars GetAppVarRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    try
        //    {
        //        AppVar = GetAppVar(GetAppVars(DbContext), AppVarKey);
        //    }
        //    catch (Exception ex)
        //    {
        //        AppVar = default;
        //    }

        //    GetAppVarRet = AppVar;
        //    return GetAppVarRet;
        //}

        //private AdvantageFramework.Core.Database.Entities.AppVars GetAppVar(List<AdvantageFramework.Core.Database.Entities.AppVars> AllAppVars, AppVars AppVarKey)
        //{
        //    AdvantageFramework.Core.Database.Entities.AppVars GetAppVarRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.AppVars AppVar = default;
        //    string AppVarName = "";
        //    try
        //    {
        //        AppVarName = AppVarKey.ToString();
        //        AppVar = AllAppVars.Where(var => Operators.ConditionalCompareObjectEqual(var.Name, AppVarName, false)).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        AppVar = default;
        //    }

        //    GetAppVarRet = AppVar;
        //    return GetAppVarRet;
        //}

        //public bool ChangeBoardState(AdvantageFramework.DTO.Desktop.Alert Alert, int NewStateID)
        //{
        //    bool Changed = false;
        //    if (Alert is object && Alert.IsWorkItem == true && Alert.BoardID is object && Alert.SprintID is object)
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            AdvantageFramework.Core.Database.Entities.SprintDetail SprintDetail = default;
        //            int CurrentBoardColumnID = 0;
        //            bool SprintDetailCreated = false;
        //            SprintDetail = AdvantageFramework.Core.Database.Procedures.SprintDetail.LoadByAlertID(DbContext, Alert.ID);
        //            if (Alert.BoardStateID is object)
        //            {
        //                CurrentBoardColumnID = Alert.BoardStateID;
        //            }

        //            if (SprintDetail is null)
        //            {
        //                CurrentBoardColumnID = -1; // Backlog
        //            }

        //            if (Alert.IsCompleted == true)
        //            {
        //                CurrentBoardColumnID = -2; // Completed
        //            }

        //            if (SprintDetail is null)
        //            {
        //                SprintDetail = AdvantageFramework.Core.Database.Procedures.SprintDetail.LoadBySprintIDAlertID(DbContext, Alert.SprintID, Alert.ID);
        //                if (SprintDetail is null)
        //                {
        //                    SprintDetail = new Database.Entities.SprintDetail();
        //                    SprintDetail.SprintHeaderID = Alert.SprintID;
        //                    SprintDetail.AlertID = Alert.ID;
        //                    if (AdvantageFramework.Core.Database.Procedures.SprintDetail.Insert(DbContext, SprintDetail) == true)
        //                    {
        //                        SprintDetailCreated = true;
        //                    }
        //                }
        //            }

        //            if (SprintDetail is object)
        //            {
        //                Changed = AdvantageFramework.ProjectManagement.Agile.MoveBoardItem(this.Session, NewStateID, SprintDetail, CurrentBoardColumnID);
        //            }
        //        }
        //    }

        //    return Changed;
        //}

        //public List<AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader> GetCheckLists(int AlertID)
        //{
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        return _GetChecklists(DbContext, AlertID);
        //    }
        //}

        //private List<AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader> _GetChecklists(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID)
        //{

        //    // objects
        //    List<AdvantageFramework.Core.Database.Entities.ChecklistHeader> ChecklistHeaders = null;
        //    List<AdvantageFramework.Core.Database.Entities.ChecklistDetail> ChecklistDetails = null;
        //    List<AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader> ChecklistHeaderList = null;
        //    AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader ChecklistHdr = default;
        //    ChecklistHeaders = AdvantageFramework.Core.Database.Procedures.ChecklistHeader.LoadByAlertID(DbContext, AlertID).ToList;
        //    if (ChecklistHeaders is object && ChecklistHeaders.Count > 0)
        //    {
        //        ChecklistHeaderList = new List<DTO.Desktop.Alert.ChecklistHeader>();
        //        foreach (var ChecklistHeader in ChecklistHeaders)
        //        {
        //            ChecklistHdr = DTO.Desktop.Alert.ChecklistHeader.FromEntity(ChecklistHeader);
        //            ChecklistHdr.ChecklistItems = (from Item in AdvantageFramework.Core.Database.Procedures.ChecklistDetail.LoadByChecklistID(DbContext, ChecklistHdr.ID).ToList
        //                                           select AdvantageFramework.DTO.Desktop.Alert.ChecklistDetail.FromEntity(Item)).ToList;
        //            if (ChecklistHeaderList is null)
        //            {
        //                ChecklistHeaderList = new List<DTO.Desktop.Alert.ChecklistHeader>();
        //            }

        //            ChecklistHeaderList.Add(ChecklistHdr);
        //        }
        //    }

        //    return ChecklistHeaderList;
        //}

        //public bool CreateChecklist(int AlertID, AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader Checklist, bool IsClientPortal = false)
        //{
        //    bool CreateChecklistRet = default;

        //    // objects
        //    bool Created = false;
        //    AdvantageFramework.Core.Database.Entities.ChecklistHeader ChecklistHeader = default;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            if (this.CreateChecklistHeader(DbContext, AlertID, Checklist, IsClientPortal))
        //            {
        //                if (Checklist.ChecklistItems is object && Checklist.ChecklistItems.Count > 0)
        //                {
        //                    foreach (var ChecklistItem in Checklist.ChecklistItems)
        //                        this.CreateChecklistDetail(DbContext, Checklist.ID, ChecklistItem);
        //                }

        //                Created = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Created = false;
        //    }
        //    finally
        //    {
        //        CreateChecklistRet = Created;
        //    }

        //    return CreateChecklistRet;
        //}

        //public bool UpdateChecklistTitle(int ChecklistID, string Title)
        //{
        //    bool UpdateChecklistTitleRet = default;
        //    bool Updated = false;
        //    AdvantageFramework.Core.Database.Entities.ChecklistHeader ChecklistHeader = default;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            ChecklistHeader = AdvantageFramework.Core.Database.Procedures.ChecklistHeader.LoadByID(DbContext, ChecklistID);
        //            if (ChecklistHeader is object)
        //            {
        //                ChecklistHeader.Description = Title;
        //                Updated = AdvantageFramework.Core.Database.Procedures.ChecklistHeader.Update(DbContext, ChecklistHeader);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Updated = false;
        //    }
        //    finally
        //    {
        //        UpdateChecklistTitleRet = Updated;
        //    }

        //    return UpdateChecklistTitleRet;
        //}

        //public bool CreateChecklistItem(AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader Checklist, AdvantageFramework.DTO.Desktop.Alert.ChecklistDetail ChecklistDetail, bool IsClientPortal = false)
        //{
        //    bool CreateChecklistItemRet = default;

        //    // objects
        //    bool Created = false;
        //    AdvantageFramework.Core.Database.Entities.ChecklistHeader ChecklistHeader = default;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Created = this.CreateChecklistDetail(DbContext, Checklist.ID, ChecklistDetail, IsClientPortal);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Created = false;
        //    }
        //    finally
        //    {
        //        CreateChecklistItemRet = Created;
        //    }

        //    return CreateChecklistItemRet;
        //}

        //public bool UpdateChecklist(AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader ChecklistHeader)
        //{
        //    bool UpdateChecklistRet = default;

        //    // objects
        //    bool Updated = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Updated = this.UpdateChecklist(DbContext, ChecklistHeader);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Updated = false;
        //    }
        //    finally
        //    {
        //        UpdateChecklistRet = Updated;
        //    }

        //    return UpdateChecklistRet;
        //}

        //public bool UpdateChecklistItem(AdvantageFramework.DTO.Desktop.Alert.ChecklistDetail ChecklistDetail, bool IsClientPortal = false)
        //{
        //    bool UpdateChecklistItemRet = default;

        //    // objects
        //    bool Updated = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Updated = this.UpdateChecklistDetail(DbContext, ChecklistDetail, IsClientPortal);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Updated = false;
        //    }
        //    finally
        //    {
        //        UpdateChecklistItemRet = Updated;
        //    }

        //    return UpdateChecklistItemRet;
        //}

        //public bool DeleteChecklist(AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader ChecklistHeader)
        //{
        //    bool DeleteChecklistRet = default;

        //    // objects
        //    bool Deleted = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Deleted = this.DeleteChecklist(DbContext, ChecklistHeader);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Deleted = false;
        //    }
        //    finally
        //    {
        //        DeleteChecklistRet = Deleted;
        //    }

        //    return DeleteChecklistRet;
        //}

        //public bool DeleteChecklistItem(AdvantageFramework.DTO.Desktop.Alert.ChecklistDetail ChecklistDetail)
        //{
        //    bool DeleteChecklistItemRet = default;

        //    // objects
        //    bool Deleted = false;
        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            Deleted = this.DeleteChecklistDetail(DbContext, ChecklistDetail);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Deleted = false;
        //    }
        //    finally
        //    {
        //        DeleteChecklistItemRet = Deleted;
        //    }

        //    return DeleteChecklistItemRet;
        //}

        //private bool CreateChecklistHeader(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader Checklist, bool IsClientPortal = false)
        //{
        //    bool CreateChecklistHeaderRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.ChecklistHeader ChecklistHeader = default;
        //    bool Added = false;
        //    try
        //    {
        //        ChecklistHeader = new AdvantageFramework.Core.Database.Entities.ChecklistHeader();
        //        ChecklistHeader.AlertID = AlertID;
        //        if (IsClientPortal == true)
        //        {
        //            ChecklistHeader.CreatedBy = this.Session.ClientPortalUser.ClientContactID.ToString;
        //        }
        //        else
        //        {
        //            ChecklistHeader.CreatedBy = this.Session.User.EmployeeCode;
        //        }

        //        ChecklistHeader.CreatedDate = DateTime.Today;
        //        ChecklistHeader.Description = Checklist.Description;
        //        if (AdvantageFramework.Core.Database.Procedures.ChecklistHeader.Insert(DbContext, ChecklistHeader))
        //        {
        //            Checklist.ID = ChecklistHeader.ID;
        //            Added = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Added = false;
        //    }
        //    finally
        //    {
        //        CreateChecklistHeaderRet = Added;
        //    }

        //    return CreateChecklistHeaderRet;
        //}

        //private bool CreateChecklistDetail(AdvantageFramework.Core.Database.DbContext DbContext, int ChecklistID, AdvantageFramework.DTO.Desktop.Alert.ChecklistDetail ChecklistItem, bool IsClientPortal = false)
        //{
        //    bool CreateChecklistDetailRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.ChecklistDetail ChecklistDetail = default;
        //    bool Added = false;
        //    try
        //    {
        //        ChecklistDetail = new AdvantageFramework.Core.Database.Entities.ChecklistDetail();
        //        ChecklistDetail.ChecklistID = ChecklistID;
        //        ChecklistDetail.Description = ChecklistItem.Description;
        //        ChecklistDetail.IsChecked = ChecklistItem.IsChecked;
        //        ChecklistDetail.SortOrder = ChecklistItem.SortOrder;
        //        if (IsClientPortal == true)
        //        {
        //            ChecklistDetail.CreatedBy = this.Session.ClientPortalUser.ClientContactID.ToString;
        //        }
        //        else
        //        {
        //            ChecklistDetail.CreatedBy = this.Session.User.EmployeeCode;
        //        }

        //        ChecklistDetail.CreatedDate = DateTime.Today;
        //        if (AdvantageFramework.Core.Database.Procedures.ChecklistDetail.Insert(DbContext, ChecklistDetail))
        //        {
        //            Added = true;
        //            ChecklistItem.ID = ChecklistDetail.ID;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Added = false;
        //    }
        //    finally
        //    {
        //        CreateChecklistDetailRet = Added;
        //    }

        //    return CreateChecklistDetailRet;
        //}

        //private bool UpdateChecklist(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader Checklist)
        //{
        //    bool UpdateChecklistRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.ChecklistHeader ChecklistHeader = default;
        //    bool Updated = false;
        //    try
        //    {
        //        ChecklistHeader = AdvantageFramework.Core.Database.Procedures.ChecklistHeader.LoadByID(DbContext, Checklist.ID);
        //        if (ChecklistHeader is object)
        //        {
        //            ChecklistHeader.Description = Checklist.Description;
        //            Updated = AdvantageFramework.Core.Database.Procedures.ChecklistHeader.Update(DbContext, ChecklistHeader);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Updated = false;
        //    }
        //    finally
        //    {
        //        UpdateChecklistRet = Updated;
        //    }

        //    return UpdateChecklistRet;
        //}

        //private bool UpdateChecklistDetail(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.DTO.Desktop.Alert.ChecklistDetail ChecklistItem, bool IsClientPortal = false)
        //{
        //    bool UpdateChecklistDetailRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.ChecklistDetail ChecklistDetail = default;
        //    bool Updated = false;
        //    try
        //    {
        //        ChecklistDetail = AdvantageFramework.Core.Database.Procedures.ChecklistDetail.LoadByID(DbContext, ChecklistItem.ID);
        //        if (ChecklistDetail is object)
        //        {
        //            ChecklistDetail.Description = ChecklistItem.Description;
        //            ChecklistDetail.IsChecked = ChecklistItem.IsChecked;
        //            if (IsClientPortal == true)
        //            {
        //                ChecklistDetail.ModifiedBy = this.Session.ClientPortalUser.ClientContactID.ToString;
        //            }
        //            else
        //            {
        //                ChecklistDetail.ModifiedBy = this.Session.User.EmployeeCode;
        //            }

        //            ChecklistDetail.ModifiedDate = DateTime.Today;
        //            Updated = AdvantageFramework.Core.Database.Procedures.ChecklistDetail.Update(DbContext, ChecklistDetail);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Updated = false;
        //    }
        //    finally
        //    {
        //        UpdateChecklistDetailRet = Updated;
        //    }

        //    return UpdateChecklistDetailRet;
        //}

        //private bool DeleteChecklist(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader Checklist)
        //{
        //    bool DeleteChecklistRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.ChecklistHeader ChecklistHeader = default;
        //    bool Deleted = false;
        //    try
        //    {
        //        ChecklistHeader = AdvantageFramework.Core.Database.Procedures.ChecklistHeader.LoadByID(DbContext, Checklist.ID);
        //        if (ChecklistHeader is object)
        //        {
        //            Deleted = AdvantageFramework.Core.Database.Procedures.ChecklistHeader.Delete(DbContext, ChecklistHeader);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Deleted = false;
        //    }
        //    finally
        //    {
        //        DeleteChecklistRet = Deleted;
        //    }

        //    return DeleteChecklistRet;
        //}

        //private bool DeleteChecklistDetail(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.DTO.Desktop.Alert.ChecklistDetail ChecklistItem)
        //{
        //    bool DeleteChecklistDetailRet = default;

        //    // objects
        //    AdvantageFramework.Core.Database.Entities.ChecklistDetail ChecklistDetail = default;
        //    bool Deleted = false;
        //    try
        //    {
        //        ChecklistDetail = AdvantageFramework.Core.Database.Procedures.ChecklistDetail.LoadByID(DbContext, ChecklistItem.ID);
        //        if (ChecklistDetail is object)
        //        {
        //            Deleted = AdvantageFramework.Core.Database.Procedures.ChecklistDetail.Delete(DbContext, ChecklistDetail);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Deleted = false;
        //    }
        //    finally
        //    {
        //        DeleteChecklistDetailRet = Deleted;
        //    }

        //    return DeleteChecklistDetailRet;
        //}

        //public List<AdvantageFramework.DTO.JobComponent> LoadCopyAndTransferJobs(int AlertID, int? SprintID)
        //{
        //    AdvantageFramework.Core.Database.Entities.Alert Alert = default;
        //    List<AdvantageFramework.DTO.JobComponent> JobComponents = null;
        //    bool AllJobs = false;
        //    if (SprintID is null)
        //        SprintID = 0;
        //    JobComponents = AdvantageFramework.ProjectManagement.Agile.LoadSprintJobComponents(this.Session, 0, AlertID, AdvantageFramework.ProjectManagement.Agile.Methods.JobComponentLookupObjectLevel.Component);
        //    return JobComponents;
        //}

        //public bool TransferAlert(int AlertID, int JobNumber, short JobComponentNumber, int BoardID, int BoardSprintID, int BoardStateID)
        //{
        //    bool Transferred = false;
        //    AdvantageFramework.Core.Database.Entities.Alert Alert = default;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        Alert = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID);
        //        Transferred = AdvantageFramework.AlertSystem.TransferAlert(DbContext, Alert, JobNumber, JobComponentNumber, BoardID, BoardSprintID, BoardStateID);
        //        if (Transferred == true)
        //        {
        //            if (BoardStateID > 0 && Alert.BoardStateID != BoardStateID)
        //            {
        //                Alert = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID);
        //                Alert.BoardStateID = BoardStateID;
        //                AdvantageFramework.Core.Database.Procedures.Alert.Update(DbContext, Alert);
        //            }

        //            NotifyAlertRecipientsOfChanges(DbContext, Alert);
        //        }
        //    }

        //    return Transferred;
        //}

        //public int CopyAlert(AdvantageFramework.Security.Session SecuritySession, AdvantageFramework.DTO.Desktop.Alert Alert, bool CopyComments, bool CopyAttachments)
        //{
        //    int NewAlertID = 0;
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //    {
        //        if (Alert.AlertAssignmentTemplateID is null)
        //            Alert.AlertAssignmentTemplateID = 0;
        //        if (Alert.AlertStateID is null)
        //            Alert.AlertStateID = 0;
        //        if (Alert.BoardID is null)
        //            Alert.BoardID = 0;
        //        if (Alert.SprintID is null)
        //            Alert.SprintID = 0;
        //        if (Alert.BoardStateID is null)
        //            Alert.BoardStateID = 0;
        //        NewAlertID = AdvantageFramework.AlertSystem.CopyAlert(DbContext, Alert.ID, Alert.JobNumber, Alert.JobComponentNumber, Alert.AlertAssignmentTemplateID, Alert.AlertStateID, Alert.AssignedEmployeeCode, Alert.BoardID, Alert.SprintID, Alert.BoardStateID, CopyComments, CopyAttachments, Alert, SecuritySession);
        //    }

        //    return NewAlertID;
        //}

        //public bool IsNoTaskBoard(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID)
        //{
        //    bool IsOnNoTaskBoard = false;
        //    try
        //    {
        //        AdvantageFramework.Core.Database.Entities.Alert Alert = default;
        //        Alert = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID);
        //        if (Alert is object)
        //        {
        //            if (Alert.AlertCategoryID == 71)
        //            {
        //                IsOnNoTaskBoard = JobIsNoTaskBoard(DbContext, Alert.JobNumber, Alert.JobComponentNumber);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        IsOnNoTaskBoard = false;
        //    }

        //    return IsOnNoTaskBoard;
        //}

        //public bool JobIsNoTaskBoard(AdvantageFramework.Core.Database.DbContext DbContext, int JobNumber, short JobComponentNumber)
        //{
        //    bool IsOnNoTaskBoard = false;
        //    try
        //    {
        //        List<AdvantageFramework.Core.Database.Entities.Board> Boards = null;
        //        AdvantageFramework.Core.Database.Entities.BoardHeader BoardHeader = default;
        //        List<int?> BoardHeaderIDs = null;
        //        Boards = AdvantageFramework.Core.Database.Procedures.Board.LoadByJobAndComponent(DbContext, JobNumber, JobComponentNumber).ToList();
        //        if (Boards is object && Boards.Count > 0)
        //        {
        //            BoardHeaderIDs = (from Entity in Boards
        //                              select Entity.BoardHeaderID).Distinct().ToList();
        //            if (BoardHeaderIDs is object && BoardHeaderIDs.Count > 0)
        //            {
        //                foreach (int BoardHeaderID in BoardHeaderIDs)
        //                {
        //                    BoardHeader = default;
        //                    BoardHeader = AdvantageFramework.Core.Database.Procedures.BoardHeader.LoadByBoardID(DbContext, BoardHeaderID);
        //                    if (BoardHeader is object)
        //                    {
        //                        if (BoardHeader.ExcludeTasks is object && BoardHeader.ExcludeTasks == true)
        //                        {
        //                            IsOnNoTaskBoard = true;
        //                            break;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        IsOnNoTaskBoard = false;
        //    }

        //    return IsOnNoTaskBoard;
        //}

        //public ViewModels.ProjectManagement.Agile.AvailableBoardInfo CheckForBoard(int JobNumber, short JobComponentNumber)
        //{
        //    var BoardInfo = new ViewModels.ProjectManagement.Agile.AvailableBoardInfo();
        //    bool HasActiveBoard = false;
        //    bool HasSprint = false;
        //    List<AdvantageFramework.Core.Database.Entities.Board> JobSpecificBoards = null;
        //    List<AdvantageFramework.Core.Database.Entities.Board> AllJobsBoards = null;
        //    var AvailableBoards = new List<AdvantageFramework.Core.Database.Entities.Board>();
        //    var DisplayBoards = new List<AdvantageFramework.Core.Database.Entities.Board>();
        //    if (JobNumber > 0 && JobComponentNumber > 0)
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode))
        //        {
        //            JobSpecificBoards = (from Entity in AdvantageFramework.Core.Database.Procedures.Board.LoadByJobAndComponent(DbContext, JobNumber, JobComponentNumber)
        //                                 where Entity.IsActive is null || Entity.IsActive == true
        //                                 select Entity).ToList;
        //            if (JobSpecificBoards is object && JobSpecificBoards.Count > 0)
        //            {
        //                foreach (var Board in JobSpecificBoards)
        //                    AvailableBoards.Add(Board);
        //            }

        //            AllJobsBoards = (from Entity in AdvantageFramework.Core.Database.Procedures.Board.LoadAllJobsBoards(DbContext)
        //                             where Entity.IsActive is null || Entity.IsActive == true
        //                             select Entity).ToList;
        //            if (AllJobsBoards is object && AllJobsBoards.Count > 0)
        //            {
        //                foreach (var Board in AllJobsBoards)
        //                    AvailableBoards.Add(Board);
        //            }

        //            if (AvailableBoards is object && AvailableBoards.Count > 0)
        //            {
        //                HasActiveBoard = true;
        //                List<AdvantageFramework.Core.Database.Entities.SprintHeader> Sprints = null;
        //                foreach (AdvantageFramework.Core.Database.Entities.Board Board in AvailableBoards)
        //                {
        //                    Sprints = AdvantageFramework.Core.Database.Procedures.SprintHeader.LoadByBoardID(DbContext, Board.ID).ToList;
        //                    if (Sprints is object && Sprints.Count > 0)
        //                    {
        //                        foreach (AdvantageFramework.Core.Database.Entities.SprintHeader Sprint in Sprints)
        //                        {
        //                            if (Sprint.IsComplete is null || Sprint.IsComplete == false)
        //                            {
        //                                if (HasSprint == false)
        //                                    HasSprint = true;
        //                                DisplayBoards.Add(Board);
        //                                break;
        //                            }
        //                        }
        //                    }

        //                    Sprints = null;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        HasActiveBoard = false;
        //        HasSprint = false;
        //    }

        //    if (DisplayBoards is null || DisplayBoards.Count == 0)
        //    {
        //        HasActiveBoard = false;
        //        HasSprint = false;
        //    }

        //    if (HasActiveBoard == true && HasSprint == true)
        //    {
        //        BoardInfo.DisplayBoards = DisplayBoards;
        //        if (DisplayBoards.Count == 1)
        //        {
        //            BoardIDChanged(DisplayBoards[0].ID, 0);
        //        }
        //        else if (DisplayBoards.Count > 1)
        //        {

        //            // Dim PleaseSelect As New AdvantageFramework.Core.Database.Entities.Board

        //            // PleaseSelect.BoardHeaderID = 0
        //            // PleaseSelect.Name = "[Please select]"

        //            // DisplayBoards.Insert(0, PleaseSelect)

        //        }

        //        BoardInfo.HasActiveBoard = true;
        //    }
        //    else
        //    {
        //        BoardInfo.HasActiveBoard = false;
        //    }

        //    return BoardInfo;
        //}

        //public ViewModels.ProjectManagement.Agile.AvailableBoardInfo BoardIDChanged(int BoardID, int SprintID)
        //{
        //    var BoardInfo = new ViewModels.ProjectManagement.Agile.AvailableBoardInfo();
        //    var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode);
        //    AdvantageFramework.Core.Database.Entities.Board Board = default;
        //    List<AdvantageFramework.Core.Database.Entities.SprintHeader> Sprints = null;
        //    List<AdvantageFramework.Core.Database.Entities.AlertState> States = null;
        //    Board = AdvantageFramework.Core.Database.Procedures.Board.LoadByBoardID(DbContext, BoardID);
        //    if (Board is object)
        //    {
        //        BoardInfo.DisplayBoards.Add(Board);
        //        Sprints = AdvantageFramework.Core.Database.Procedures.SprintHeader.LoadByBoardID(DbContext, BoardID).ToList;
        //        if (Sprints is object && Sprints.Count > 0)
        //        {
        //            foreach (AdvantageFramework.Core.Database.Entities.SprintHeader Sprint in Sprints)
        //            {
        //                if (Sprint.IsComplete is null || Sprint.IsComplete == false)
        //                {
        //                    if (Sprint.IsActive is object && Sprint.IsActive == true)
        //                    {
        //                        BoardInfo.ActiveSprintID = Sprint.ID;
        //                    }

        //                    BoardInfo.Sprints.Add(Sprint);
        //                }
        //            }
        //        }

        //        if (SprintID > 0)
        //        {
        //            States = (from ALS in DbContext.GetQuery < AdvantageFramework.Core.Database.Entities.AlertState >
        //                      join BD in DbContext.GetQuery < AdvantageFramework.Core.Database.Entities.BoardDetail > on ALS.ID equals BD.AlertStateID
        //                      join BH in DbContext.GetQuery < AdvantageFramework.Core.Database.Entities.BoardHeader > on BH.ID equals BD.BoardHeaderID
        //                      join B in DbContext.GetQuery < AdvantageFramework.Core.Database.Entities.Board > on B.BoardHeaderID equals BH.ID
        //                      join SH in DbContext.GetQuery < AdvantageFramework.Core.Database.Entities.SprintHeader > on SH.BoardID equals B.ID
        //                      where BD.BoardHeaderID == Board.BoardHeaderID & (ALS.IsActive is null | ALS.IsActive == true) & SH.ID == SprintID
        //                      orderby BD.SequenceNumber
        //                      select ALS).ToList;
        //            if (States is object)
        //            {
        //                BoardInfo.States = States;
        //            }

        //            if (BoardInfo.States is null)
        //                BoardInfo.States = new List<Database.Entities.AlertState>();
        //            var BacklogState = new AdvantageFramework.Core.Database.Entities.AlertState();
        //            BacklogState.ID = -1;
        //            BacklogState.Name = "[Backlog]";
        //            BoardInfo.States.Insert(0, BacklogState);
        //        }
        //    }

        //    return BoardInfo;
        //}

        //[Serializable()]
        //public partial class BoardSelectData
        //{
        //    public int ID { get; set; } = 0;
        //    public string Name { get; set; } = string.Empty;
        //    public bool ActiveOrSelected { get; set; } = false;

        //    public BoardSelectData()
        //    {
        //    }
        //}

        //[Serializable()]
        //public partial class AlertHours
        //{
        //    public int? AlertID { get; set; } = 0;
        //    public DateTime? StartDate { get; set; } = default;
        //    public DateTime? DueDate { get; set; } = default;
        //    public decimal? HoursAllowed { get; set; } = 0.00d;
        //    public decimal? HoursPosted { get; set; } = 0.00d;
        //    public decimal? HoursAllocated { get; set; } = 0.00d;
        //    public decimal? HoursBalance { get; set; } = 0.00d;
        //    public decimal? HoursAllocatedBalance { get; set; } = 0.00d;
        //    public bool? HasCalculatedHours { get; set; } = false;
        //    public bool? HasWeeklyHours { get; set; } = false;

        //    public AlertHours()
        //    {
        //    }
        //}

        //[Serializable()]
        //public partial class SimpleSelectList
        //{
        //    public string Code { get; set; } = string.Empty;
        //    public string Name { get; set; } = string.Empty;

        //    public SimpleSelectList()
        //    {
        //    }
        //}

        //public List<AdvantageFramework.Core.Database.Entities.SprintHeader> GetBoardSprints(int BoardID)
        //{
        //    List<AdvantageFramework.Core.Database.Entities.SprintHeader> GetBoardSprintsRet = default;
        //    var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode);

        //    // Using DbContext = New AdvantageFramework.Core.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        //    GetBoardSprintsRet = (from Entity in AdvantageFramework.Core.Database.Procedures.SprintHeader.LoadByBoardID(DbContext, BoardID)
        //                          where Entity.IsComplete is null | Entity.IsComplete == false
        //                          select Entity).ToList;
        //    return GetBoardSprintsRet;

        //    // End Using

        //}
        //// Public Function GetBoardSprintStates(ByVal SprintID As Integer) As Generic.List(Of AdvantageFramework.Core.Database.Entities.AlertState)

        //// Dim States As Generic.List(Of AdvantageFramework.Core.Database.Entities.AlertState) = Nothing

        //// Dim DbContext As New AdvantageFramework.Core.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        //// Dim BoardHeaderID As Integer = 0

        //// 'Using DbContext = New AdvantageFramework.Core.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        //// Try

        //// Dim SQL As String = String.Format("SELECT TOP 1 ISNULL(BH.ID, 0) FROM SPRINT_HDR SH INNER JOIN BOARD B ON SH.BOARD_ID = B.ID INNER JOIN BOARD_HDR BH ON B.BOARD_HDR_ID = BH.ID WHERE SH.ID = {0};", SprintID)

        //// BoardHeaderID = DbContext.Database.SqlQuery(Of Integer)(SQL).SingleOrDefault

        //// Catch ex As Exception
        //// BoardHeaderID = 0
        //// End Try

        //// If BoardHeaderID > 0 Then

        //// 'States = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Core.Database.Entities.AlertState)
        //// '          'Join BD In DbContext.GetQuery(Of AdvantageFramework.Core.Database.Entities.BoardDetail) On Entity.ID Equals BD.AlertStateID
        //// '          'Where BD.BoardHeaderID = BoardHeaderID And (Entity.IsActive Is Nothing Or Entity.IsActive = True)
        //// '          'Order By BD.SequenceNumber
        //// '          Select Entity).ToList

        //// End If

        //// 'End Using

        //// If States Is Nothing Then States = New List(Of Database.Entities.AlertState)

        //// Return States

        //// End Function
        //public List<BoardSelectData> GetBoardSprintStates(int SprintID)
        //{
        //    List<BoardSelectData> GetBoardSprintStatesRet = default;
        //    string SQL = "SELECT ALS.ALERT_STATE_ID AS ID, ALS.ALERT_STATE_NAME AS Name " + "FROM SPRINT_HDR SH " + "INNER JOIN BOARD B ON SH.BOARD_ID = B.ID " + "INNER JOIN BOARD_HDR BH ON B.BOARD_HDR_ID = BH.ID " + "INNER JOIN BOARD_DTL BD ON BH.ID = BD.BOARD_HDR_ID " + "INNER JOIN ALERT_STATES ALS ON BD.ALERT_STATE_ID = ALS.ALERT_STATE_ID " + "WHERE SH.ID = {0} " + "ORDER BY BD.SEQ_NBR;";
        //    var DbContext = new AdvantageFramework.Core.Database.DbContext(this.Session.ConnectionString, this.Session.UserCode);
        //    // Using DbContext = New AdvantageFramework.Core.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        //    GetBoardSprintStatesRet = DbContext.Database.SqlQuery<BoardSelectData>(string.Format(SQL, SprintID)).ToList;
        //    return GetBoardSprintStatesRet;

        //    // End Using

        //}

        //public bool CanAddTimeToJob(int JobNumber, short JobComponentNumber, ref string Message)
        //{
        //    bool _CanAddTimeToJob = false;
        //    if (JobNumber > 0 && JobComponentNumber > 0)
        //    {
        //        if (AdvantageFramework.Timesheet.JobCompIsEditable(this.Session.ConnectionString, JobNumber, JobComponentNumber) == false)
        //        {
        //            Message = "Job/Component Process Control does not allow access.";
        //        }
        //        else
        //        {
        //            _CanAddTimeToJob = true;
        //        }
        //    }
        //    else
        //    {
        //        Message = "Invalid job/component";
        //    }

        //    return _CanAddTimeToJob;
        //}

        //public List<AdvantageFramework.DTO.Maintenance.General.Settings.Setting> GetJobVersionDefaults()
        //{
        //    List<AdvantageFramework.DTO.Maintenance.General.Settings.Setting> Defaults = new List<DTO.Maintenance.General.Settings.Setting>();
        //    using (var DataContext = new AdvantageFramework.Core.Database.DataContext(Session.ConnectionString, Session.UserCode))
        //    {
        //        AdvantageFramework.Core.Database.Entities.Setting Setting = default;
        //        Defaults = (from Entity in AdvantageFramework.Core.Database.Procedures.Setting.LoadBySettingModuleID(DataContext, 2)
        //                    where Entity.SettingModuleTabID == 0
        //                    select DTO.Maintenance.General.Settings.Setting.FromEntity(Entity)).ToList;
        //    }

        //    return Defaults;
        //}

        //#endregion

    }
}
