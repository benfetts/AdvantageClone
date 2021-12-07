'Imports Kendo.Mvc.Extensions
'Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Web.Mvc
Imports Webvantage.ViewModels
Imports System.Web.Routing
Imports System.Xml
Imports System.Threading
Imports System.IO
Imports System.Text
Imports MvcCodeRouting.Web.Mvc
Imports System.Data.SqlClient
Imports Webvantage.cGlobals

Namespace Controllers.Dashboard

    <Serializable()>
    Public Class EmployeeUtilizationController
        Inherits MVCControllerBase

#Region " Constants "


#End Region

#Region " Enum "

#End Region

#Region " Variables "


#End Region

#Region " Properties "



#End Region

#Region " Initialize "


#End Region

#Region " Razor Views "

        Public Function Index(ByVal EUFilter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter) As ActionResult

            Dim Employee As cEmployee = Nothing

            Employee = New cEmployee(Me.SecuritySession.ConnectionString)

            If MiscFN.IsClientPortal Then
                ViewBag.IsClientPortal = True
                'EUFilter.IsClientPortal = True
            Else
                ViewBag.IsClientPortal = False
                ViewBag.EmployeeName = Employee.GetName(Me.SecuritySession.User.EmployeeCode)
                ViewBag.DefaultEmpCode = Me.SecuritySession.User.EmployeeCode
            End If

            ViewBag.Year1 = Date.Now.Year - 2
            ViewBag.Year2 = Date.Now.Year - 1
            ViewBag.Year3 = Date.Now.Year

            ViewBag.BackgroundColor = GetUserBackgroundColor(Me.SecuritySession.UserName)
            ViewBag.HasAccessToTimesheet = Me.HasAccessToTimesheet()

            Return View()

        End Function
        Public Function _UtilizationGrid() As ActionResult

            Return PartialView()

        End Function
        Public Function _UtilizationFilter() As ActionResult

            Return PartialView()

        End Function

#End Region

#Region " API "

#Region " Get "
        <HttpGet>
        Public Function GetUserViewSettings(ApplicationName As String) As JsonResult

            'objects
            Dim ViewSettings As List(Of AdvantageFramework.Dashboard.Classes.EmployeeUtilizationUserViewSetting) = Nothing
            Dim ErrorMessage As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                ViewSettings = AdvantageFramework.Dashboard.GetUserViewSettings(DbContext, Me.SecuritySession.UserCode, ApplicationName)

            End Using

            Return MaxJson(ViewSettings, JsonRequestBehavior.AllowGet)

        End Function

        Public Function GroupSecuritySettings() As JsonResult

            Dim SecuritySettings As List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerUserViewSetting) = Nothing
            SecuritySettings = New List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerUserViewSetting)

            Dim setting As AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerUserViewSetting
            setting = New AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerUserViewSetting

            setting.SettingName = "ShowAllAssignments"
            setting.SettingValue = IIf(LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.AlertInbox_ShowAllAssignments) = 0, False, True)

            SecuritySettings.Add(setting)


            setting = New AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerUserViewSetting

            setting.SettingName = "ShowUnassignedAssignments"
            setting.SettingValue = IIf(LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.AlertInbox_ShowUnassignedAssignments) = 0, False, True)

            SecuritySettings.Add(setting)


            setting = New AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerUserViewSetting

            setting.SettingName = "AllowTaskEdit"
            setting.SettingValue = IIf(LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit) = 0, False, True)

            SecuritySettings.Add(setting)

            Return MaxJson(SecuritySettings, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetUtilizationData(ByVal EUFilter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter) As JsonResult

            'Objects
            Dim EmpUtilization As New AdvantageFramework.Dashboard.Classes.EmployeeUtilization
            Dim ErrorMessage As String = ""

            If String.IsNullOrWhiteSpace(Me.CurrentQueryString.UserCode) = False Then

                EUFilter.UserCode = Me.CurrentQueryString.UserCode

            Else

                EUFilter.UserCode = Me.SecuritySession.UserCode

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                EmpUtilization.Items = AdvantageFramework.Dashboard.LoadEmployeeUtilization(DbContext, EUFilter, ErrorMessage)

            End Using

            'SetAssignToLinkAddress(EmpUtilization.Items)

            Return MaxJson(EmpUtilization.Items, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetEmployeeDefault() As JsonResult

            'objects
            Dim EmployeeCode As String = Me.SecuritySession.User.EmployeeCode
            Return Json(EmployeeCode, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetGridColumnVisibilitySettings(GridView As String) As JsonResult

            Dim UserColumn As New List(Of String)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                'UserColumn = AdvantageFramework.Web.Presentation.Controls.getusGetUserColumnList(Session("ConnString"), GridName, Session("UserCode"))

                UserColumn = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT GRID_COLUMN.NAME FROM GRID WITH(NOLOCK) INNER JOIN GRID_COLUMN WITH(NOLOCK) ON GRID.GRID_ID = GRID_COLUMN.GRID_ID " &
                                                                                          "INNER JOIN GRID_COLUMN_SETTING WITH(NOLOCK) ON GRID.GRID_ID = GRID_COLUMN_SETTING.GRID_ID AND GRID_COLUMN.GRID_COLUMN_ID = GRID_COLUMN_SETTING.GRID_COLUMN_ID " &
                                                                                          "WHERE (GRID_COLUMN_SETTING.IS_VISIBLE = 0) AND (GRID.NAME = '{0}') AND (GRID_COLUMN_SETTING.USER_CODE = '{1}');", GridView, Session("UserCode"))).ToList()


            End Using

            Return MaxJson(UserColumn, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetGridColumnSettings(GridName As String) As JsonResult

            Dim UserColumn As New List(Of AdvantageFramework.Dashboard.Classes.EmployeeUtilizationGridColumnSetting)
            Dim ErrorMessage As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                UserColumn = AdvantageFramework.Dashboard.GetEmployeeManagerUserColumnSettings(DbContext, GridName, Me.SecuritySession.UserCode)

                If UserColumn IsNot Nothing AndAlso Me.HasAccessToTimesheet = False Then

                    Dim TimeColumns As New Generic.List(Of String)

                    TimeColumns.Add("AddTime")
                    TimeColumns.Add("Stopwatch")

                    UserColumn = (From Entity In UserColumn
                                  Where TimeColumns.Contains(Entity.ColumnName) = False).ToList

                End If

            End Using

            Return MaxJson(UserColumn, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetDateDiffAndWeekendStatus(DateValue As String) As JsonResult

            Dim DateDetail As AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerDateItem = Nothing

            Dim ErrorMessage As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                DateDetail = AdvantageFramework.AlertSystem.GetDateDiffAndWeekendStatus(DbContext, DateValue, Me.SecuritySession.UserCode)

            End Using

            Return MaxJson(DateDetail, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetPriorities() As JsonResult

            'objects
            Dim Priority As IEnumerable = Nothing
            Dim EnumType As System.Type = GetType(cAlerts.Priority)
            Dim Values As System.Array = System.Enum.GetValues(EnumType)

            'get the values and descriptions
            Priority = (From item In Values
                        Select New With {.Value = CType(item, Int32),
                                         .Description = GetAbbrevation(CType(item, Int32))
                                      }).ToList



            Return MaxJson(Priority, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetCategories() As JsonResult

            Dim Categories As Generic.List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerCategory) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Categories = DbContext.Database.SqlQuery(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerCategory)(
                                                    "SELECT DISTINCT ALERT_DESC AS CategoryName, ALERT_DESC AS CategoryValue FROM ALERT_CATEGORY ORDER BY ALERT_DESC;").ToList


            End Using

            Return MaxJson(Categories, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetRoles() As JsonResult

            'objects
            Dim RolesList As Generic.IEnumerable(Of Object) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                RolesList = (From Role In AdvantageFramework.Database.Procedures.Role.LoadAllActive(DbContext)
                             Select Role.Code,
                                            Role.Description).ToList

            End Using

            Return MaxJson(RolesList, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetDepartments() As JsonResult

            'objects
            Dim DepartmentTeamsList As Generic.IEnumerable(Of Object) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                DepartmentTeamsList = (From DepartmentTeam In AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext)
                                       Select DepartmentTeam.Code,
                                            DepartmentTeam.Description).ToList

                'the following can be used to load all departments, not just the active ones
                'DepartmentTeamsList = (From DepartmentTeam In AdvantageFramework.Database.Procedures.DepartmentTeam.Load(DbContext)
                '                       Select DepartmentTeam.Code,
                '                            DepartmentTeam.Description).ToList

            End Using

            Return MaxJson(DepartmentTeamsList, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetFolders() As JsonResult

            'objects
            Dim Folders As IEnumerable = Nothing
            Dim EnumType As System.Type = GetType(cAlerts.AAManagerFolders)
            Dim Values As System.Array = System.Enum.GetValues(EnumType)

            Folders = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(cAlerts.AAManagerFolders)).ToList

            'get the values and descriptions
            'Folders = (From item In Values
            '           Select New With {.Value = CType(item, Int32),
            '                             .Description = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(cAlerts.AAManagerFolders), CType(item, Int32))
            '                          }).ToList

            Folders = (From item In Folders
                       Select New With {.Value = item.Code,
                                         .Description = item.Description
                                      }).ToList

            Return MaxJson(Folders, JsonRequestBehavior.AllowGet)

        End Function

#End Region
#Region " Post "
        Public Function SaveColumnSetting(ByVal GridName As String, ByVal Column As String, ShowHide As Boolean) As JsonResult

            Dim save As Boolean = True
            Dim colName As String = ""

            Try
                Select Case Column
                    Case "EmployeeOffice"
                        colName = "EmployeeOffice"
                    Case "EmployeeOfficeName"
                        colName = "EmployeeOfficeName"
                    Case "EmployeeDepartment"
                        colName = "EmployeeDepartment"
                    Case "EmployeeDepartmentName"
                        colName = "EmployeeDepartmentName"
                    Case "EmployeeCode"
                        colName = "EmployeeCode"
                    Case "EmployeeName"
                        colName = "EmployeeName"
                    Case "RequiredHours"
                        colName = "RequiredHours"
                    Case "BillableHours"
                        colName = "BillableHours"
                    Case "NonBillableHours"
                        colName = "NonBillableHours"
                    Case "NewBusinessHours"
                        colName = "NewBusinessHours"
                    Case "OOOHours"
                        colName = "OOOHours"
                    Case "TotalHours"
                        colName = "TotalHours"
                    Case "BillableHoursPercent"
                        colName = "BillableHoursPercent"
                    Case "BillablePercentGoal"
                        colName = "BillablePercentGoal"
                    Case "BillableVariance"
                        colName = "BillableVariance"
                    Case "NonBillableHoursPercent"
                        colName = "NonBillableHoursPercent"
                    Case "NewBusinessPercent"
                        colName = "NewBusinessPercent"
                    Case "OOOPercent"
                        colName = "OOOPercent"
                    Case "TotalUtilization"
                        colName = "TotalUtilization"
                    Case "DirectHoursGoal"
                        colName = "DirectHoursGoal"
                    Case "AgencyHours"
                        colName = "AgencyHours"
                    Case "TotalDirectHours"
                        colName = "TotalDirectHours"
                    Case "NonDirectHours"
                        colName = "NonDirectHours"
                    Case "Variance"
                        colName = "Variance"
                    Case "PercentDirect"
                        colName = "PercentDirect"
                    Case "PercentNonDirect"
                        colName = "PercentNonDirect"
                    Case "PercentOfDirectHoursGoal"
                        colName = "PercentOfDirectHoursGoal"
                    Case "PercentOfBillableHoursGoal"
                        colName = "PercentOfBillableHoursGoal"
                    Case "BillablePercentGoal"
                        colName = "BillablePercentGoal"
                End Select

                AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(Session("ConnString"), Session("UserCode"), GridName, colName, ShowHide)
            Catch ex As Exception
                save = False
            End Try


            Return MaxJson(New With {.Success = save})

        End Function
        <HttpPost>
        Public Function ProcessGridColumnWidthChange(ByVal GridName As String, ByVal EmployeeUtilizationColumns As List(Of AdvantageFramework.Dashboard.Classes.EmployeeUtilizationGridColumnUpdates)) _
                                                 As JsonResult

            'Objects
            Dim Saved As Boolean = False
            Dim Message As String = Nothing
            Dim ErrorMessage As String = Nothing

            Dim pGridName As System.Data.SqlClient.SqlParameter = Nothing
            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pColumnWidth As System.Data.SqlClient.SqlParameter = Nothing
            Dim pColumnName As System.Data.SqlClient.SqlParameter = Nothing

            If EmployeeUtilizationColumns IsNot Nothing Then

                For Each Item As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationGridColumnUpdates In EmployeeUtilizationColumns

                    Try

                        Using myconn As New SqlConnection(Me.SecuritySession.ConnectionString)

                            Dim mycommand As New SqlCommand()
                            With mycommand
                                .CommandType = CommandType.StoredProcedure
                                .CommandText = "usp_wv_EmployeeUtilizationUpdateColumnWidthSettings"
                                .Connection = myconn
                            End With

                            pGridName = New System.Data.SqlClient.SqlParameter("@GRID_NAME", SqlDbType.VarChar, 100)
                            pUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                            pColumnWidth = New System.Data.SqlClient.SqlParameter("@NEW_COLUMN_WIDTH", SqlDbType.Int)
                            pColumnName = New System.Data.SqlClient.SqlParameter("@COLUMN_NAME", SqlDbType.VarChar, 100)

                            pGridName.Value = GridName
                            pUserCode.Value = Session("UserCode")
                            pColumnWidth.Value = Item.ColumnWidth
                            pColumnName.Value = Item.ColumnName

                            mycommand.Parameters.Add(pGridName)
                            mycommand.Parameters.Add(pUserCode)
                            mycommand.Parameters.Add(pColumnWidth)
                            mycommand.Parameters.Add(pColumnName)

                            myconn.Open()

                            mycommand.ExecuteNonQuery()

                        End Using

                    Catch ex As Exception

                        ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                        Saved = False

                    End Try

                Next

                ErrorMessage = ""
                Saved = True
            End If

            Return MaxJson(New With {.Success = Saved, .Message = ErrorMessage})
        End Function
        <HttpPost>
        Public Function ProcessGridColumnReorder(ByVal GridName As String, ByVal EmployeeUtilizationColumns As List(Of AdvantageFramework.Dashboard.Classes.EmployeeUtilizationGridColumnUpdates)) _
                                                 As JsonResult

            'Objects
            Dim Saved As Boolean = False
            Dim Message As String = Nothing
            Dim ErrorMessage As String = Nothing

            Dim pGridName As System.Data.SqlClient.SqlParameter = Nothing
            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pColumnID As System.Data.SqlClient.SqlParameter = Nothing
            Dim pColumnName As System.Data.SqlClient.SqlParameter = Nothing

            If EmployeeUtilizationColumns IsNot Nothing Then

                For Each Item As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationGridColumnUpdates In EmployeeUtilizationColumns

                    Try

                        Using myconn As New SqlConnection(Me.SecuritySession.ConnectionString)

                            Dim mycommand As New SqlCommand()
                            With mycommand
                                .CommandType = CommandType.StoredProcedure
                                .CommandText = "usp_wv_EmployeeUtilizationUpdateColumnOrderSettings"
                                .Connection = myconn
                            End With

                            pGridName = New System.Data.SqlClient.SqlParameter("@GRID_NAME", SqlDbType.VarChar, 100)
                            pUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                            pColumnID = New System.Data.SqlClient.SqlParameter("@NEW_COLUMN_ORDER_ID", SqlDbType.Int)
                            pColumnName = New System.Data.SqlClient.SqlParameter("@COLUMN_NAME", SqlDbType.VarChar, 100)

                            pGridName.Value = GridName
                            pUserCode.Value = Session("UserCode")
                            pColumnID.Value = Item.ColumnID
                            pColumnName.Value = Item.ColumnName

                            mycommand.Parameters.Add(pGridName)
                            mycommand.Parameters.Add(pUserCode)
                            mycommand.Parameters.Add(pColumnID)
                            mycommand.Parameters.Add(pColumnName)

                            myconn.Open()

                            mycommand.ExecuteNonQuery()

                        End Using

                    Catch ex As Exception

                        ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                        Saved = False

                    End Try

                Next

                ErrorMessage = ""
                Saved = True
            End If

            Return MaxJson(New With {.Success = Saved, .Message = ErrorMessage})
        End Function
        <HttpPost>
        Public Function ResetGridColumnWidths(ByVal GridName As String) As JsonResult

            'Objects
            Dim Saved As Boolean = False
            Dim Message As String = Nothing
            Dim ErrorMessage As String = Nothing

            Dim pGridName As System.Data.SqlClient.SqlParameter = Nothing
            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing

            Try

                Using myconn As New SqlConnection(Me.SecuritySession.ConnectionString)

                    Dim mycommand As New SqlCommand()
                    With mycommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_AAMResetColumnWidthSettings"
                        .Connection = myconn
                    End With

                    pGridName = New System.Data.SqlClient.SqlParameter("@GRID_NAME", SqlDbType.VarChar, 100)
                    pUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)

                    pGridName.Value = GridName
                    pUserCode.Value = Session("UserCode")

                    mycommand.Parameters.Add(pGridName)
                    mycommand.Parameters.Add(pUserCode)

                    myconn.Open()

                    mycommand.ExecuteNonQuery()

                End Using


            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Saved = False
            End Try

            ErrorMessage = ""
            Saved = True

            Return MaxJson(New With {.Success = Saved, .Message = ErrorMessage})
        End Function
        <HttpPost>
        Public Function ResetGridColumnOrder(ByVal GridName As String) As JsonResult

            'Objects
            Dim Saved As Boolean = False
            Dim Message As String = Nothing
            Dim ErrorMessage As String = Nothing

            Dim pGridName As System.Data.SqlClient.SqlParameter = Nothing
            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing

            Try

                Using myconn As New SqlConnection(Me.SecuritySession.ConnectionString)

                    Dim mycommand As New SqlCommand()
                    With mycommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_AAMResetColumnOrderSettings"
                        .Connection = myconn
                    End With

                    pGridName = New System.Data.SqlClient.SqlParameter("@GRID_NAME", SqlDbType.VarChar, 100)
                    pUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)

                    pGridName.Value = GridName
                    pUserCode.Value = Session("UserCode")

                    mycommand.Parameters.Add(pGridName)
                    mycommand.Parameters.Add(pUserCode)

                    myconn.Open()

                    mycommand.ExecuteNonQuery()

                End Using


            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Saved = False
            End Try

            ErrorMessage = ""
            Saved = True

            Return MaxJson(New With {.Success = Saved, .Message = ErrorMessage})
        End Function
        <HttpPost>
        Public Function UpdateUserViewSettings(ByVal UserSettings As List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerUserViewSetting),
                                               ByVal ApplicationName As String) _
                                                 As JsonResult
            'Objects
            Dim Saved As Boolean = False
            Dim Message As String = Nothing
            Dim ErrorMessage As String = Nothing

            Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ApplicationNameSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim SettingNameSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim SettingValueSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            If UserSettings IsNot Nothing Then

                For Each Item As AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerUserViewSetting In UserSettings

                    Try

                        Using myconn As New SqlConnection(Me.SecuritySession.ConnectionString)

                            Dim mycommand As New SqlCommand()
                            With mycommand
                                .CommandType = CommandType.StoredProcedure
                                .CommandText = "usp_wv_AAMUpdateUserViewSettings"
                                .Connection = myconn
                            End With

                            UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                            ApplicationNameSqlParameter = New System.Data.SqlClient.SqlParameter("@APPLICATION_NAME", SqlDbType.VarChar, 200)
                            SettingNameSqlParameter = New System.Data.SqlClient.SqlParameter("@SETTING_NAME", SqlDbType.VarChar, 200)
                            SettingValueSqlParameter = New System.Data.SqlClient.SqlParameter("@SETTING_VALUE", SqlDbType.VarChar, 200)

                            UserCodeSqlParameter.Value = Me.Session("UserCode")
                            ApplicationNameSqlParameter.Value = ApplicationName
                            SettingNameSqlParameter.Value = Item.SettingName

                            If Item.SettingValue = Nothing Then
                                Item.SettingValue = ""
                            End If

                            SettingValueSqlParameter.Value = Item.SettingValue

                            mycommand.Parameters.Add(UserCodeSqlParameter)
                            mycommand.Parameters.Add(ApplicationNameSqlParameter)
                            mycommand.Parameters.Add(SettingNameSqlParameter)
                            mycommand.Parameters.Add(SettingValueSqlParameter)

                            myconn.Open()

                            mycommand.ExecuteNonQuery()

                        End Using

                    Catch ex As Exception

                        ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                        Saved = False

                    End Try

                Next

                ErrorMessage = ""
                Saved = True
            End If

            Return MaxJson(New With {.Success = Saved, .Message = ErrorMessage})
        End Function
        <HttpPost>
        Public Function UpdateCardSortAlerts(ByVal AlertID As Integer, ByVal NewPosition As Integer, ByVal EmployeeCode As String)

            'Objects
            Dim Saved As Boolean = False
            Dim Message As String = Nothing
            Dim ErrorMessage As String = Nothing

            Dim pEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pAlertID As System.Data.SqlClient.SqlParameter = Nothing
            Dim pNewPosition As System.Data.SqlClient.SqlParameter = Nothing

            Try

                Using MyConn As New SqlConnection(Me.SecuritySession.ConnectionString)

                    Dim MyCommand As New SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "advsp_card_user_sort_alerts"
                        .Connection = MyConn
                    End With

                    pEmployeeCode = New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                    pAlertID = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
                    pNewPosition = New SqlParameter("@NEW_POSITION", SqlDbType.Int)

                    pEmployeeCode.Value = EmployeeCode
                    pAlertID.Value = AlertID
                    pNewPosition.Value = NewPosition

                    MyCommand.Parameters.Add(pEmployeeCode)
                    MyCommand.Parameters.Add(pAlertID)
                    MyCommand.Parameters.Add(pNewPosition)

                    MyConn.Open()

                    MyCommand.ExecuteNonQuery()

                End Using

            Catch ex As Exception

                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Saved = False

            End Try

            ErrorMessage = ""
            Saved = True

            Return MaxJson(New With {.Success = Saved, .Message = ErrorMessage})
        End Function
        <HttpPost>
        Public Function UpdateCardSortAssignments(ByVal EmployeeCode As String, ByVal AlertID As Integer, ByVal NewPosition As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal TaskSequenceNumber As Integer) As JsonResult

            'Objects
            Dim Saved As Boolean = False
            Dim Message As String = Nothing
            Dim ErrorMessage As String = Nothing

            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pAlertID As System.Data.SqlClient.SqlParameter = Nothing
            Dim pJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim pJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim pTaskSequenceNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim pNewPosition As System.Data.SqlClient.SqlParameter = Nothing

            Try

                Using MyConn As New SqlConnection(Me.SecuritySession.ConnectionString)

                    Dim MyCommand As New SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "advsp_card_user_sort_assignments"
                        .Connection = MyConn
                    End With

                    pUserCode = New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                    pEmployeeCode = New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                    pAlertID = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
                    pJobNumber = New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                    pJobComponentNumber = New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                    pTaskSequenceNumber = New SqlParameter("@TASK_SEQ_NBR", SqlDbType.SmallInt)
                    pNewPosition = New SqlParameter("@NEW_POSITION", SqlDbType.Int)

                    pUserCode.Value = Session("UserCode")
                    pEmployeeCode.Value = EmployeeCode
                    pAlertID.Value = AlertID
                    pJobNumber.Value = JobNumber
                    pJobComponentNumber.Value = JobComponentNumber
                    pTaskSequenceNumber.Value = TaskSequenceNumber
                    pNewPosition.Value = NewPosition

                    MyCommand.Parameters.Add(pUserCode)
                    MyCommand.Parameters.Add(pEmployeeCode)
                    MyCommand.Parameters.Add(pAlertID)
                    MyCommand.Parameters.Add(pJobNumber)
                    MyCommand.Parameters.Add(pJobComponentNumber)
                    MyCommand.Parameters.Add(pTaskSequenceNumber)
                    MyCommand.Parameters.Add(pNewPosition)

                    MyConn.Open()

                    MyCommand.ExecuteNonQuery()

                End Using

            Catch ex As Exception

                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Saved = False

            End Try

            ErrorMessage = ""
            Saved = True

            Return MaxJson(New With {.Success = Saved, .Message = ErrorMessage})
        End Function
        <HttpPost>
        Public Function ProcessDataGridUpdates(ByVal AlertGridData As List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerGridUpdates)) As JsonResult

            'Objects
            Dim Saved As Boolean = False
            Dim Message As String = Nothing
            Dim ErrorMessage As String = Nothing

            Dim pAlertID As System.Data.SqlClient.SqlParameter = Nothing
            Dim pAlertCategoryID As System.Data.SqlClient.SqlParameter = Nothing
            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim pStartDateDirty As System.Data.SqlClient.SqlParameter = Nothing
            Dim pDueDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim pDueDateDirty As System.Data.SqlClient.SqlParameter = Nothing
            Dim pPriority As System.Data.SqlClient.SqlParameter = Nothing
            Dim pPriorityDirty As System.Data.SqlClient.SqlParameter = Nothing

            If AlertGridData IsNot Nothing Then

                For Each Item As AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerGridUpdates In AlertGridData

                    Try

                        Using MyConn As New SqlConnection(Me.SecuritySession.ConnectionString)

                            Dim MyCommand As New SqlCommand()
                            With MyCommand
                                .CommandType = CommandType.StoredProcedure
                                .CommandText = "usp_wv_AAM_Update_Grid_Records"
                                .Connection = MyConn
                            End With

                            pAlertID = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.VarChar, 10)
                            pAlertCategoryID = New System.Data.SqlClient.SqlParameter("@ALERT_CATEGORY_ID", SqlDbType.VarChar, 10)
                            pUserCode = New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                            pStartDate = New SqlParameter("@START_DATE", SqlDbType.VarChar, 10)
                            pStartDateDirty = New SqlParameter("@START_DATE_DIRTY", SqlDbType.Bit)
                            pDueDate = New SqlParameter("@DUE_DATE", SqlDbType.VarChar, 10)
                            pDueDateDirty = New SqlParameter("@DUE_DATE_DIRTY", SqlDbType.Bit)
                            pPriority = New SqlParameter("@PRIORITY", SqlDbType.VarChar, 5)
                            pPriorityDirty = New SqlParameter("@PRIORITY_DIRTY", SqlDbType.Bit)

                            pAlertID.Value = Item.AlertID
                            pAlertCategoryID.Value = Item.AlertCategoryID
                            pUserCode.Value = Me.SecuritySession.UserCode
                            pStartDate.Value = Item.StartDate
                            pStartDateDirty.Value = Item.StartDateDirty
                            pDueDate.Value = Item.DueDate
                            pDueDateDirty.Value = Item.DueDateDirty
                            pPriority.Value = Item.Priority
                            pPriorityDirty.Value = Item.PriorityDirty

                            MyCommand.Parameters.Add(pAlertID)
                            MyCommand.Parameters.Add(pAlertCategoryID)
                            MyCommand.Parameters.Add(pUserCode)
                            MyCommand.Parameters.Add(pStartDate)
                            MyCommand.Parameters.Add(pStartDateDirty)
                            MyCommand.Parameters.Add(pDueDate)
                            MyCommand.Parameters.Add(pDueDateDirty)
                            MyCommand.Parameters.Add(pPriority)
                            MyCommand.Parameters.Add(pPriorityDirty)

                            MyConn.Open()

                            MyCommand.ExecuteNonQuery()

                        End Using

                    Catch ex As Exception

                        ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                        Saved = False

                    End Try

                Next

                ErrorMessage = ""
                Saved = True
            End If

            Return MaxJson(New With {.Success = Saved, .Message = ErrorMessage})
        End Function
        <HttpPost>
        Public Function BookmarkEmployeeUtilization(Month As String, Year As String, GridSize As Integer) As JsonResult

            'objects
            Dim Bookmark As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark = Nothing
            Dim BookmarkMethods As AdvantageFramework.Web.Presentation.Bookmarks.Methods = Nothing
            Dim Saved As Boolean = False
            Dim Message As String = Nothing
            Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
            Dim Description As String = Nothing
            Dim StartDateLogic As String = Nothing
            Dim EndDateLogic As String = Nothing

            BookmarkMethods = New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
            Bookmark = New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark

            QueryString = New AdvantageFramework.Web.QueryString

            QueryString.Page = "Dashboard/EmployeeUtilization"
            QueryString.Add("bm", "1")
            QueryString.Add("pg", "dept")
            QueryString.Add("year", Year)
            QueryString.Add("month", Month)
            QueryString.Add("aamgs", GridSize)

            Description = "Employee Utilization Dashboard" + " (" + Month + "/" + Year + ")"

            Bookmark.Description = Description
            Bookmark.BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_EmployeeUtilizationDashboard
            Bookmark.UserCode = Me.SecuritySession.UserCode

            Bookmark.Name = String.Format("{0}", "Employee Utilization Dashboard")
            Bookmark.PageURL = QueryString.ToString(True)

            Saved = BookmarkMethods.SaveBookmark(Bookmark, Message)



            Return MaxJson(New With {.Success = Saved, .Message = Message})

        End Function

        Private Function MarkTempComplete(JobNumber As String, JobComponentNumber As String,
                                            TaskSequenceNumber As String) As Boolean

            'Objects
            Dim MarkedTempCompleteFlag As Boolean = False
            'Dim AutoAlertTaskEmployees As Boolean = False
            'Dim AgencySettings As AdvantageFramework.Web.AgencySettings.Methods
            'Dim DatatableTaskSeqNbrThatWereMadeActive As New DataTable

            Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Using dbcontext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    MarkedTempCompleteFlag = AdvantageFramework.ProjectSchedule.MarkTempComplete(dbcontext, SecurityDbContext, JobNumber, JobComponentNumber, TaskSequenceNumber,
                                                Session("empcode"), CType(Now, DateTime), False)

                    'AgencySettings = New AdvantageFramework.Web.AgencySettings.Methods(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                    'AutoAlertTaskEmployees = AgencySettings.GetValue(AdvantageFramework.Agency.Settings.TRF_NXT_TSK_AUTO_EML, "") = "1"

                    'If AutoAlertTaskEmployees = True Then

                    '    If Not DatatableTaskSeqNbrThatWereMadeActive Is Nothing AndAlso DatatableTaskSeqNbrThatWereMadeActive.Rows.Count > 0 Then

                    '        Dim ThisSeqNbr As Integer = 0
                    '        Dim cEmp As New Webvantage.cEmployee(Me.SecuritySession.ConnectionString)
                    '        Dim EmpCodeString As String = ""
                    '        Dim NewAlertId As Integer = 0

                    '        For ActiveRows As Integer = 0 To DatatableTaskSeqNbrThatWereMadeActive.Rows.Count - 1

                    '            ThisSeqNbr = CType(DatatableTaskSeqNbrThatWereMadeActive.Rows(ActiveRows)("SEQ_NBR"), Integer)
                    '            NewAlertId = AdvantageFramework.ProjectSchedule.CreateTaskAlert(DbContext, JobNumber, JobComponentNumber, ThisSeqNbr, Session("EmpCode"), EmpCodeString)

                    '            If NewAlertId > 0 Then
                    '                Dim EmailObject As New EmailSessionObject(Me.SecuritySession.ConnectionString,
                    '                                                              Session("UserCode"),
                    '                                                              Me.SecuritySession,
                    '                                                              Session("WebvantageURL"),
                    '                                                              Session("ClientPortalURL"))
                    '                With EmailObject

                    '                    .AlertId = NewAlertId
                    '                    .Subject = "[Alert Updated]"
                    '                    .EmployeeCodesToSendEmailTo = EmpCodeString
                    '                    .IsClientPortal = MiscFN.IsClientPortal
                    '                    .IncludeOriginator = False

                    '                End With

                    '                EmailObject.SendEmailOnSeparateThread()

                    '            End If

                    '            EmpCodeString = ""
                    '            NewAlertId = 0

                    '        Next

                    '    End If

                    'End If


                End Using

            End Using

            Return MarkedTempCompleteFlag

        End Function

        <HttpPost>
        Public Function ProcessTempComplete(AlertID As String, IsTaskTempComplete As Boolean, JobNumber As Integer, JobComponentNumber As Integer,
                                            TaskSequenceNumber As Integer)
            Dim Saved As Boolean = False
            Dim Message As String = Nothing
            Dim FullyCompleteTask As Integer = 0
            Dim MarkTempCompleteFlag As Boolean = False
            Dim OperationFlag As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    If IsTaskTempComplete Then

                        'Unmark
                        OperationFlag = AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, SecurityDbContext, JobNumber, JobComponentNumber, TaskSequenceNumber,
                                                                            Session("EmpCode"), Nothing)

                        Message = ""
                        Saved = True

                    Else

                        FullyCompleteTask = CType(AdvantageFramework.ProjectSchedule.CompleteTaskInsteadOfTempCompleteSetting(DbContext), Integer)

                        Select Case FullyCompleteTask

                            Case AdvantageFramework.ProjectSchedule.Methods.LookupSettingsOptions.Yes
                                'MarkNoPrompt
                                MarkTempCompleteFlag = MarkTempComplete(JobNumber, JobComponentNumber, TaskSequenceNumber)

                                If MarkTempCompleteFlag Then

                                    OperationFlag = AdvantageFramework.ProjectSchedule.CompleteTaskInsteadOfTempComplete(DbContext, JobNumber, JobComponentNumber, TaskSequenceNumber,
                                                                                                         Session("EmpCode"), MiscFN.IsClientPortal)

                                    Message = ""

                                Else
                                    Message = "Unable To temp complete this item, please contact support."
                                End If

                            Case AdvantageFramework.ProjectSchedule.Methods.LookupSettingsOptions.Prompt
                                'MarkWithPrompt
                                MarkTempCompleteFlag = MarkTempComplete(JobNumber, JobComponentNumber, TaskSequenceNumber)

                                If MarkTempCompleteFlag Then
                                    OperationFlag = AdvantageFramework.ProjectSchedule.CompleteTaskInsteadOfTempComplete(DbContext, JobNumber, JobComponentNumber, TaskSequenceNumber,
                                                                                                        Session("EmpCode"), MiscFN.IsClientPortal)

                                    Message = "Task will be completed If you were the last employee To temp complete"
                                Else
                                    Message = "Unable To temp complete this item, please contact support."
                                End If

                            Case AdvantageFramework.ProjectSchedule.Methods.LookupSettingsOptions.No
                                'Mark
                                MarkTempCompleteFlag = MarkTempComplete(JobNumber, JobComponentNumber, TaskSequenceNumber)

                                Message = ""
                        End Select

                        Saved = True

                    End If

                End Using

            End Using

            Return MaxJson(New With {.Success = Saved, .Message = Message})
        End Function
        <HttpPost>
        Public Function CompleteTempComplete(AssignedEmployee As String, Role As String, ProjectManager As String, Office As String, TaskStatus As String,
                                             SearchCriteria As String, AlertID As String) As JsonResult

            'Objects
            Dim CompletedTasks As Generic.List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerJobDetail) = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False
            Dim ResponseMessage As String = ""
            Dim HttpContext As Object = Nothing
            Dim AutoAlertTaskEmployees As Boolean = False
            Dim Schedule As New cSchedule(Session("ConnString"), Session("UserCode"))
            Dim DatatableTaskSeqNbrThatWereMadeActive As DataTable = Nothing

            Dim AgencySettings As New AdvantageFramework.Web.AgencySettings.Methods(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode, HttpContext)

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    CompletedTasks = AdvantageFramework.AlertSystem.CompleteTempComplete(DbContext, Me.SecuritySession.UserCode, AssignedEmployee,
                                                            Role, ProjectManager, Office, TaskStatus, SearchCriteria, AlertID)

                    If Not CompletedTasks Is Nothing AndAlso CompletedTasks.Count > 0 Then
                        AutoAlertTaskEmployees = AgencySettings.GetValue(AdvantageFramework.Agency.Settings.TRF_NXT_TSK_AUTO_EML, "") = "1"

                        For Each Task In CompletedTasks

                            DatatableTaskSeqNbrThatWereMadeActive = New DataTable
                            DatatableTaskSeqNbrThatWereMadeActive = Schedule.SetNextTaskActive(Task.JobNumber, Task.JobComponentNumber, Task.TaskSequenceNumber)

                            Schedule.AutoUpdateTrafficCode(Task.JobNumber, Task.JobComponentNumber)

                            If AutoAlertTaskEmployees = True Then
                                If Not DatatableTaskSeqNbrThatWereMadeActive Is Nothing AndAlso DatatableTaskSeqNbrThatWereMadeActive.Rows.Count > 0 Then

                                    Using DbContextNewActiveTasks = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                                        Dim CurrentSequenceNumber As Integer = 0
                                        Dim cEmp As New Webvantage.cEmployee(Me.SecuritySession.ConnectionString)
                                        Dim EmpCodeString As String = ""
                                        Dim NewAlertId As Integer = 0

                                        For ActiveRow As Integer = 0 To DatatableTaskSeqNbrThatWereMadeActive.Rows.Count - 1

                                            CurrentSequenceNumber = CType(DatatableTaskSeqNbrThatWereMadeActive.Rows(ActiveRow)("SEQ_NBR"), Integer)

                                            NewAlertId = AdvantageFramework.ProjectSchedule.CreateTaskAlert(DbContextNewActiveTasks, Task.JobNumber, Task.JobComponentNumber, CurrentSequenceNumber, Session("EmpCode"), EmpCodeString)

                                            If NewAlertId > 0 Then
                                                Dim EmailObject As New EmailSessionObject(Me.SecuritySession.ConnectionString,
                                                                                      Me.SecuritySession.UserCode, Me.SecuritySession,
                                                                                      Session("WebvantageURL"), Session("ClientPortalURL"))

                                                With EmailObject

                                                    .AlertId = NewAlertId
                                                    .Subject = "[Alert Updated]"
                                                    .EmployeeCodesToSendEmailTo = EmpCodeString
                                                    .IsClientPortal = MiscFN.IsClientPortal
                                                    .IncludeOriginator = False

                                                End With

                                                EmailObject.SendEmailOnSeparateThread()

                                            End If

                                            EmpCodeString = ""
                                            NewAlertId = 0

                                        Next

                                    End Using

                                End If

                            End If

                            DatatableTaskSeqNbrThatWereMadeActive = Nothing

                        Next

                    End If

                End Using

            Catch ex As Exception
                Saved = False
                ResponseMessage = ex.Message
            End Try

            Return MaxJson(New With {.Success = Saved, .Message = ResponseMessage})

        End Function

        <HttpPost>
        Public Function ProcessComplete(AlertID As Integer, SprintID As String) As JsonResult

            'Objects
            Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim CompleteResult As AdvantageFramework.AlertSystem.CompleteAssignmentResult = Nothing
            Dim Saved As Boolean = False
            Dim ThisSprintId As Integer = Nothing
            Dim ResponseMessage As String = Nothing
            Dim ShowDialog As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                ResponseMessage = ""
                AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                If AlertID > 0 Then

                    Dim PromptForFullCompleteTask As Boolean = False
                    Dim PromptForTempCompleteTask As Boolean = False
                    Dim s As String = String.Empty

                    Try

                        ThisSprintId = CType(SprintID, Integer)

                    Catch ex As Exception

                        ThisSprintId = 0

                    End Try

                    If AlertEntity.AlertCategory.Description <> "Task" Then

                        CompleteResult = AdvantageFramework.AlertSystem.CompleteAssignment(DbContext, AlertEntity, Session("EmpCode"), Me.SecuritySession.UserCode, Nothing, Nothing)

                        If CompleteResult.Success = True Then

                            AdvantageFramework.AlertSystem.CheckForTaskPrompts(DbContext, Me.SecuritySession, AlertEntity, PromptForFullCompleteTask, PromptForTempCompleteTask, s)

                            If PromptForFullCompleteTask = True Then

                                ResponseMessage = "Task will be completed If you were the last employee To temp complete."

                            ElseIf PromptForTempCompleteTask = True Then

                                Dim QueryString As New AdvantageFramework.Web.QueryString
                                With QueryString

                                    .Page = "TrafficSchedule_ConfirmCompleteAlert.aspx"
                                    .AlertID = AlertID
                                    .Add("complete", 1)
                                    .Add("IsTempComplete", 1)

                                    ResponseMessage = QueryString.ToString()
                                    ShowDialog = True

                                End With

                            Else

                                'Me.RadGridAlertInbox.Rebind()
                                'Me.RefreshAlertWindows(False, True, False, False)

                            End If

                            Saved = True
                        Else
                            Saved = False
                            ResponseMessage = "Unable To complete task, please contact support."
                        End If

                    Else

                        Dim TempCompleted As Boolean = False
                        Dim ShowFullyCompletePrompt As Boolean = False
                        Dim _Controller As AdvantageFramework.Controller.Desktop.AlertController = Nothing
                        Dim Alert As AdvantageFramework.DTO.Desktop.Alert = Nothing

                        _Controller = New AdvantageFramework.Controller.Desktop.AlertController(Me.SecuritySession)

                        Alert = _Controller.LoadAlert(AlertID, 0, 0, ThisSprintId)

                        TempCompleted = _Controller.TempComplete(Alert, ShowFullyCompletePrompt)

                        If TempCompleted = True Then

                            If ShowFullyCompletePrompt = True Then

                                ResponseMessage = "Task will be completed If you were the last employee To temp complete."

                            End If
                            Saved = True

                        Else

                            Saved = False
                            ResponseMessage = "Unable To temp complete task, please contact support."

                        End If

                    End If

                End If

            End Using

            Return MaxJson(New With {.Success = Saved, .Message = ResponseMessage, .ShowDialog = ShowDialog})

        End Function
        <HttpPost>
        Public Function DismissComplete(AlertIDs As List(Of Integer)) As JsonResult

            'Objects
            Dim Saved As Boolean = True
            Dim ResponseMessage As String = Nothing
            Dim PromptForFullCompleteTask As Boolean = False
            Dim PromptForTempCompleteTask As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                ResponseMessage = ""

                If AlertIDs.Count > 0 Then

                    For Each Alert In AlertIDs
                        If AdvantageFramework.AlertSystem.DismissAlert(DbContext, Alert, Session("EmpCode"), Session("UserCode"), Session("UserID"), False,
                                                                           PromptForFullCompleteTask, PromptForTempCompleteTask, ErrorMessage) = True Then

                            Saved = True
                            ResponseMessage = ""

                            'End If
                        Else

                            If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                Saved = True
                                ResponseMessage = "AlertID: " + Alert.ToString + " : " + ErrorMessage

                                'Exit For

                            End If

                        End If

                    Next

                End If

            End Using

            Return MaxJson(New With {.Success = Saved, .Message = ResponseMessage})
        End Function

        <HttpPost>
        Public Function DeleteAlert(ByVal AlertID As Integer) As JsonResult

            Dim Saved As Boolean = False
            Dim ResponseMessage As String = ""
            Dim ShowDialog As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim DocumentIDs As Integer()

                    DocumentIDs = (From Entity In DbContext.AlertAttachments
                                   Where Entity.AlertID = AlertID
                                   Select Entity.DocumentID).ToArray()

                    If DocumentIDs IsNot Nothing AndAlso DocumentIDs.Count > 0 Then

                        Dim documentRepositiory As New DocumentRepository(Me.SecuritySession.ConnectionString)
                        Dim Document As AdvantageFramework.Database.Entities.Document

                        For Each DocumentID As Integer In DocumentIDs

                            Document = Nothing
                            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                            If Document IsNot Nothing Then

                                If documentRepositiory.DeleteDocument(0, Document.FileSystemFileName) = True Then

                                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM ALERT_ATTACHMENT WITH(ROWLOCK) WHERE ALERT_ID = {0} AND DOCUMENT_ID = {1};", AlertID, Document.ID))

                                    If AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Document) = True Then

                                    End If

                                End If

                            End If

                        Next

                    End If

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM ALERT_RCPT WITH(ROWLOCK) WHERE ALERT_ID = {0};DELETE FROM ALERT_RCPT_DISMISSED WITH(ROWLOCK) WHERE ALERT_ID = {0};DELETE FROM ALERT WITH(ROWLOCK) WHERE ALERT_ID = {0};", AlertID))

                End Using

                Saved = True

                Return MaxJson(New With {.Success = Saved, .Message = ResponseMessage, .ShowDialog = ShowDialog})

            Catch ex As Exception

                ResponseMessage = ex.Message.ToString()

                Saved = False

                Return MaxJson(New With {.Success = Saved, .Message = ResponseMessage, .ShowDialog = ShowDialog})

            End Try

        End Function

        <HttpPost>
        Public Function StopWatchStart(AlertID As Integer, JobNumber As Integer, JobComponentNumber As Integer, TaskSequenceNumber As Integer) As JsonResult

            'Objects
            Dim Started As Boolean = False
            Dim ResponseMessage As String = Nothing
            Dim ShowDialog As Boolean = False
            Dim ErrorMessage As String = Nothing

            ErrorMessage = ""

            If AdvantageFramework.Timesheet.StopwatchStart(Session("ConnString"), Session("UserCode"), Session("EmpCode"), JobNumber, JobComponentNumber, TaskSequenceNumber, AlertID, ErrorMessage) = True Then

                Started = True

            Else

                Started = False

            End If

            Return MaxJson(New With {.OpenStopWatch = Started, .ErrorMessage = ErrorMessage})
        End Function

#End Region

#End Region

#Region " Private "
        'Private Function UserViewSettings(ByRef AlertFilter As AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerFilter)

        '    'objects
        '    Dim ViewSettings As List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerUserViewSetting) = Nothing
        '    Dim ErrorMessage As String = ""

        '    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

        '        ViewSettings = AdvantageFramework.AlertSystem.GetUserViewSettings(DbContext, Me.SecuritySession.UserCode, "ALERT_INBOX")

        '    End Using

        '    For Each item As AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerUserViewSetting In ViewSettings
        '        Select Case item.SettingName
        '            Case "AAM_SearchCriteria"
        '                AlertFilter.SearchCriteria = item.SettingValue
        '            Case "AAM_InboxType"
        '                AlertFilter.InboxType = item.SettingValue
        '            Case "AAM_ShowAssignmentType"
        '                AlertFilter.ShowAssignmentType = item.SettingValue
        '            Case "AAM_GroupBy"
        '                AlertFilter.GroupBy = item.SettingValue
        '            Case "AAM_ShowOnlyTempCompetedTasks"
        '                AlertFilter.ShowOnlyTempCompletedTasks = item.SettingValue
        '            Case "AAM_JJIncludeCompleted"
        '                AlertFilter.IncludeCompletedAssignments = item.SettingValue
        '        End Select

        '    Next

        'End Function
        Private Function GetAssignmentTypeDescription(AssignmentType As String)
            Select Case AssignmentType
                Case "myalertsandassignments"
                    Return "My Assignments & Alerts"
                Case "myalerts"
                    Return "My Alerts"
                Case "myalertassignments"
                    Return "My Assignments"
                Case "allalertassignments"
                    Return "All Assignments"
                Case "unassigned"
                    Return "Unassigned"
                Case Else
                    Return "N/A"
            End Select
        End Function

        Private Function GetInboxDescription(InboxType As String)
            Select Case InboxType
                Case "inbox"
                    Return "Current"
                Case "dismissed"
                    Return "Dismissed/Completed"
                Case "all"
                    Return "All"
                Case "drafts"
                    Return "Drafts"
                Case "tasks"
                    Return "Tasks"
                Case Else
                    Return "Inbox"
            End Select
        End Function


        Private Function GetAbbrevation(ByVal value As Integer)
            Select Case value
                Case 1
                    Return "HH"
                Case 2
                    Return "H"
                Case 3
                    Return "--"
                Case 4
                    Return "L"
                Case 5
                    Return "LL"
                Case Else
                    Return "--"
            End Select
        End Function

        Private Function GetUserBackgroundColor(UserCode As String) As String

            'Objects
            Dim BackgroundColor As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    BackgroundColor = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 VARIABLE_VALUE FROM APP_VARS WHERE USERID = '{0}' AND APPLICATION = 'MY_SETTINGS' AND VARIABLE_NAME = 'SMPL_BG_COLOR';", UserCode)).SingleOrDefault

                Catch ex As Exception

                    BackgroundColor = String.Empty

                End Try

            End Using

            Return BackgroundColor

        End Function
        Private Function SetAssignToLinkAddress(ByRef AAManagerItems As List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerItem))

            'Objects
            Dim AssignedToToolTip As String = Nothing
            Dim AssignedToLink As String = Nothing
            Dim IsClientPortal As Boolean = False
            Dim AlertStateName As String = Nothing
            Dim FromJobJacket As Boolean = False
            Dim QueryStringBuilder As AdvantageFramework.Web.QueryString = Nothing

            IsClientPortal = MiscFN.IsClientPortal()
            FromJobJacket = IsFromJobJacket()

            For Each Item In AAManagerItems
                Try

                    If Item.AssignedTo IsNot Nothing Then

                        If Item.AssignedTo.Trim() <> "" Then

                            Select Case Item.AssignedTo.Trim().ToLower()
                                Case "unassigned"

                                    AssignedToToolTip = "Assignment is unassigned."

                                Case "completed"

                                    AssignedToToolTip = "Assignment is completed."

                                Case Else

                                    AssignedToToolTip = "Currently assigned to:  " & Item.AssignedTo & "."

                            End Select

                            If IsClientPortal = False Then

                                QueryStringBuilder = New AdvantageFramework.Web.QueryString

                                AssignedToToolTip &= "  Click to change."

                                If Item.AlertStateName IsNot Nothing Then

                                    AlertStateName = Item.AlertStateName

                                End If

                                If Item.Subject = "Copy and Layout Approval Final" Then
                                    Item.Subject = Item.Subject
                                End If

                                If (Item.AssignedTo = "Unassigned" Or Item.AssignedTo = "Completed") And AlertStateName = "" Then

                                    With QueryStringBuilder

                                        .Page = "Desktop_AlertView"
                                        .Add("AlertID", Item.AlertID)

                                        If Item.SprintID IsNot Nothing Then
                                            .Add("SprintID", Item.SprintID)
                                        End If

                                        If FromJobJacket = True Then
                                            .Add("OpenedFrom", 1)
                                        End If
                                    End With

                                    AssignedToLink = QueryStringBuilder.ToString(True)

                                Else
                                    If IsTask(Item.Category) = True Then
                                        With QueryStringBuilder

                                            .Page = "TrafficSchedule_TaskEmployees.aspx"
                                            .AlertID = Item.AlertID
                                            .JobNumber = Item.JobNumber
                                            .JobComponentNumber = Item.ComponentNumber
                                            .TaskSequenceNumber = Item.TaskSequenceNumber
                                            .Add("From", "pb")
                                            .Add("AlertID", Item.AlertID)

                                        End With

                                        AssignedToLink = QueryStringBuilder.ToString(True)

                                    Else
                                        With QueryStringBuilder

                                            .Page = "Desktop_Reassign"
                                            .AlertID = Item.AlertID
                                            .Add("AlertID", Item.AlertID)

                                        End With

                                        AssignedToLink = QueryStringBuilder.ToString(True)

                                    End If

                                End If

                                QueryStringBuilder = Nothing

                            End If



                        End If
                    Else
                        Item.AssignedTo = ""
                    End If

                    Try

                        If Item.IsWorkItem = True AndAlso Item.IsRouted = False Then

                            AssignedToLink = ""

                        End If

                        If Item.IsStandardAlert = True Then

                            AssignedToLink = ""

                        End If

                    Catch ex As Exception

                    End Try

                    If AssignedToLink = "" Then

                        AssignedToToolTip = ""

                    End If

                Catch ex As Exception

                End Try

                Item.AssignedToLinkAddress = AssignedToLink
                Item.AssignedToTitle = AssignedToToolTip

                AssignedToToolTip = AssignedToLink
            Next
        End Function
        Private Function IsFromJobJacket() As Boolean
            Dim FromJobNumber As Integer = 0
            Dim FromJobComponentNumber As Integer = 0
            Dim FromApp As Integer = 0

            Try
                If Not Request.QueryString("f") Is Nothing Then
                    FromApp = MiscFN.SourceApp_FromInt(Request.QueryString("f"))
                End If
            Catch ex As Exception
                FromApp = MiscFN.Source_App.Alert
            End Try

            Try
                If Not Request.QueryString("j") Is Nothing Then

                    FromJobNumber = CType(Request.QueryString("j"), Integer)

                End If
            Catch ex As Exception
                FromJobNumber = 0
            End Try
            Try
                If Not Request.QueryString("jc") Is Nothing Then

                    FromJobComponentNumber = CType(Request.QueryString("jc"), Integer)

                End If
            Catch ex As Exception
                FromJobComponentNumber = 0
            End Try

            If (FromJobNumber > 0 And FromJobComponentNumber > 0) OrElse FromApp = MiscFN.Source_App.JobJacket OrElse Me.CurrentQueryString.IsJobDashboard Then

                IsFromJobJacket = True
                'NS removed: AppVarApplication = cAppVars.Application.JOB_INBOX

            Else

                IsFromJobJacket = False

            End If
        End Function
        Private Function IsTask(Category As String) As Boolean

            If Category IsNot Nothing Then

                If Category = "Task" Then

                    IsTask = True

                End If

            Else

                IsTask = False

            End If

        End Function

#End Region

#Region " Classes "


#End Region

    End Class

End Namespace

