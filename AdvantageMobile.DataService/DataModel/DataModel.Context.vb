﻿'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Core.Objects
Imports System.Data.Entity.Core.Objects.DataClasses
Imports System.Data.Entity.Infrastructure
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Linq

Partial Public Class DataEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=DataEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Property Clients() As DbSet(Of Client)
    Public Property Divisions() As DbSet(Of Division)
    Public Property Offices() As DbSet(Of Office)
    Public Property Products() As DbSet(Of Product)
    Public Property DepartmentTeams() As DbSet(Of DepartmentTeam)
    Public Property Functions() As DbSet(Of [Function])
    Public Property Employees() As DbSet(Of Employee)
    Public Property EmployeeTimes() As DbSet(Of EmployeeTime)
    Public Property EmployeeTimeDetails() As DbSet(Of EmployeeTimeDetail)
    Public Property EmployeeTimeComments() As DbSet(Of EmployeeTimeComment)
    Public Property EmployeeTimeIndirects() As DbSet(Of EmployeeTimeIndirect)
    Public Property JobComponents() As DbSet(Of JobComponent)
    Public Property JobLogs() As DbSet(Of JobLog)
    Public Property JobTraffics() As DbSet(Of JobTraffic)
    Public Property JobTrafficDetails() As DbSet(Of JobTrafficDetail)
    Public Property JobTrafficDetailEmployees() As DbSet(Of JobTrafficDetailEmployee)
    Public Property TimeCategories() As DbSet(Of TimeCategory)
    Public Property TimeCategoryTypes() As DbSet(Of TimeCategoryType)
    Public Property Alerts() As DbSet(Of Alert)
    Public Property AlertComments() As DbSet(Of AlertComment)
    Public Property AlertRecipients() As DbSet(Of AlertRecipient)
    Public Property DismissedAlertRecipients() As DbSet(Of DismissedAlertRecipient)
    Public Property SecurityUsers() As DbSet(Of SecurityUser)
    Public Property SecurityPermissions() As DbSet(Of SecurityPermission)
    Public Property SecurityGroupPermissions() As DbSet(Of SecurityGroupPermission)
    Public Property EmployeePictures() As DbSet(Of EmployeePicture)
    Public Property EmployeeTimeTemplates() As DbSet(Of EmployeeTimeTemplate)
    Public Property SecurityClients() As DbSet(Of SecurityClient)
    Public Property PostPeriods() As DbSet(Of PostPeriod)
    Public Property Agencies() As DbSet(Of Agency)
    Public Property SecurityUserSettings() As DbSet(Of SecurityUserSetting)
    Public Property EmployeeTimesheetFunctions() As DbSet(Of EmployeeTimesheetFunction)
    Public Property EmployeeDepartmentTeams() As DbSet(Of EmployeeDepartmentTeam)
    Public Property AlertAttachments() As DbSet(Of AlertAttachment)
    Public Property Documents() As DbSet(Of Document)
    Public Property AlertGroups() As DbSet(Of AlertGroup)
    Public Property AlertAssignmentTemplateDepartmentTeams() As DbSet(Of AlertAssignmentTemplateDepartmentTeam)
    Public Property AlertAssignmentEmailGroups() As DbSet(Of AlertAssignmentEmailGroup)
    Public Property AlertAssignmentTemplateEmployees() As DbSet(Of AlertAssignmentTemplateEmployee)
    Public Property AlertAssignmentTemplates() As DbSet(Of AlertAssignmentTemplate)
    Public Property AlertAssignmentTemplateRoles() As DbSet(Of AlertAssignmentTemplateRole)
    Public Property AlertAssignmentTemplateStates() As DbSet(Of AlertAssignmentTemplateState)
    Public Property AlertAssignmentStates() As DbSet(Of AlertAssignmentState)
    Public Property AlertTypes() As DbSet(Of AlertType)
    Public Property ExpenseDetailDocuments() As DbSet(Of ExpenseDetailDocument)
    Public Property ExpenseDocuments() As DbSet(Of ExpenseDocument)
    Public Property ExpenseDetails() As DbSet(Of ExpenseDetail)
    Public Property Expenses() As DbSet(Of Expense)
    Public Property SecurityLicenses() As DbSet(Of SecurityLicense)

    Public Overridable Function SaveTimeEntry(et_id As Nullable(Of Integer), etd_id As Nullable(Of Integer), emp_code As String, emp_date As Nullable(Of Date), fnc_cat As String, emp_hrs As Nullable(Of Decimal), job_nbr As Nullable(Of Integer), job_cmp_nbr As Nullable(Of Short), dp_tm As String, start_time As String, end_time As String, prodCat As String, uSER_CODE As String, comments As String, taskCode As String, error_text As ObjectParameter, cREATE_DATE As Nullable(Of Date), aLERT_ID As Nullable(Of Integer), aLLOW_DUPLICATE As Nullable(Of Boolean)) As ObjectResult(Of String)
        Dim et_idParameter As ObjectParameter = If(et_id.HasValue, New ObjectParameter("et_id", et_id), New ObjectParameter("et_id", GetType(Integer)))

        Dim etd_idParameter As ObjectParameter = If(etd_id.HasValue, New ObjectParameter("etd_id", etd_id), New ObjectParameter("etd_id", GetType(Integer)))

        Dim emp_codeParameter As ObjectParameter = If(emp_code IsNot Nothing, New ObjectParameter("emp_code", emp_code), New ObjectParameter("emp_code", GetType(String)))

        Dim emp_dateParameter As ObjectParameter = If(emp_date.HasValue, New ObjectParameter("emp_date", emp_date), New ObjectParameter("emp_date", GetType(Date)))

        Dim fnc_catParameter As ObjectParameter = If(fnc_cat IsNot Nothing, New ObjectParameter("fnc_cat", fnc_cat), New ObjectParameter("fnc_cat", GetType(String)))

        Dim emp_hrsParameter As ObjectParameter = If(emp_hrs.HasValue, New ObjectParameter("emp_hrs", emp_hrs), New ObjectParameter("emp_hrs", GetType(Decimal)))

        Dim job_nbrParameter As ObjectParameter = If(job_nbr.HasValue, New ObjectParameter("job_nbr", job_nbr), New ObjectParameter("job_nbr", GetType(Integer)))

        Dim job_cmp_nbrParameter As ObjectParameter = If(job_cmp_nbr.HasValue, New ObjectParameter("job_cmp_nbr", job_cmp_nbr), New ObjectParameter("job_cmp_nbr", GetType(Short)))

        Dim dp_tmParameter As ObjectParameter = If(dp_tm IsNot Nothing, New ObjectParameter("dp_tm", dp_tm), New ObjectParameter("dp_tm", GetType(String)))

        Dim start_timeParameter As ObjectParameter = If(start_time IsNot Nothing, New ObjectParameter("start_time", start_time), New ObjectParameter("start_time", GetType(String)))

        Dim end_timeParameter As ObjectParameter = If(end_time IsNot Nothing, New ObjectParameter("end_time", end_time), New ObjectParameter("end_time", GetType(String)))

        Dim prodCatParameter As ObjectParameter = If(prodCat IsNot Nothing, New ObjectParameter("ProdCat", prodCat), New ObjectParameter("ProdCat", GetType(String)))

        Dim uSER_CODEParameter As ObjectParameter = If(uSER_CODE IsNot Nothing, New ObjectParameter("USER_CODE", uSER_CODE), New ObjectParameter("USER_CODE", GetType(String)))

        Dim commentsParameter As ObjectParameter = If(comments IsNot Nothing, New ObjectParameter("comments", comments), New ObjectParameter("comments", GetType(String)))

        Dim taskCodeParameter As ObjectParameter = If(taskCode IsNot Nothing, New ObjectParameter("taskCode", taskCode), New ObjectParameter("taskCode", GetType(String)))

        Dim cREATE_DATEParameter As ObjectParameter = If(cREATE_DATE.HasValue, New ObjectParameter("CREATE_DATE", cREATE_DATE), New ObjectParameter("CREATE_DATE", GetType(Date)))

        Dim aLERT_IDParameter As ObjectParameter = If(aLERT_ID.HasValue, New ObjectParameter("ALERT_ID", aLERT_ID), New ObjectParameter("ALERT_ID", GetType(Integer)))

        Dim aLLOW_DUPLICATEParameter As ObjectParameter = If(aLLOW_DUPLICATE.HasValue, New ObjectParameter("ALLOW_DUPLICATE", aLLOW_DUPLICATE), New ObjectParameter("ALLOW_DUPLICATE", GetType(Boolean)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("SaveTimeEntry", et_idParameter, etd_idParameter, emp_codeParameter, emp_dateParameter, fnc_catParameter, emp_hrsParameter, job_nbrParameter, job_cmp_nbrParameter, dp_tmParameter, start_timeParameter, end_timeParameter, prodCatParameter, uSER_CODEParameter, commentsParameter, taskCodeParameter, error_text, cREATE_DATEParameter, aLERT_IDParameter, aLLOW_DUPLICATEParameter)
    End Function

    <EdmFunction("DataEntities", "GetTimeEntry")>
    Public Overridable Function GetTimeEntry(employeeCode As String, startDate As Nullable(Of Date), endDate As Nullable(Of Date), sortColumn As String, userCode As String, employeeTimeID As Nullable(Of Integer), employeeTimeDetailID As Nullable(Of Integer)) As IQueryable(Of TimeEntry)
        Dim employeeCodeParameter As ObjectParameter = If(employeeCode IsNot Nothing, New ObjectParameter("EmployeeCode", employeeCode), New ObjectParameter("EmployeeCode", GetType(String)))

        Dim startDateParameter As ObjectParameter = If(startDate.HasValue, New ObjectParameter("StartDate", startDate), New ObjectParameter("StartDate", GetType(Date)))

        Dim endDateParameter As ObjectParameter = If(endDate.HasValue, New ObjectParameter("EndDate", endDate), New ObjectParameter("EndDate", GetType(Date)))

        Dim sortColumnParameter As ObjectParameter = If(sortColumn IsNot Nothing, New ObjectParameter("SortColumn", sortColumn), New ObjectParameter("SortColumn", GetType(String)))

        Dim userCodeParameter As ObjectParameter = If(userCode IsNot Nothing, New ObjectParameter("UserCode", userCode), New ObjectParameter("UserCode", GetType(String)))

        Dim employeeTimeIDParameter As ObjectParameter = If(employeeTimeID.HasValue, New ObjectParameter("EmployeeTimeID", employeeTimeID), New ObjectParameter("EmployeeTimeID", GetType(Integer)))

        Dim employeeTimeDetailIDParameter As ObjectParameter = If(employeeTimeDetailID.HasValue, New ObjectParameter("EmployeeTimeDetailID", employeeTimeDetailID), New ObjectParameter("EmployeeTimeDetailID", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.CreateQuery(Of TimeEntry)("[DataEntities].[GetTimeEntry](@EmployeeCode, @StartDate, @EndDate, @SortColumn, @UserCode, @EmployeeTimeID, @EmployeeTimeDetailID)", employeeCodeParameter, startDateParameter, endDateParameter, sortColumnParameter, userCodeParameter, employeeTimeIDParameter, employeeTimeDetailIDParameter)
    End Function

    Public Overridable Function GetProjects(aE As String, cdp_selection As String, start_date As String, end_date As String, closed_jobs As String, userID As String, empCode As String, myProjects As String, eXCLUDE_JOBS_WITH_COMPLETED_SCHEDULES As Nullable(Of Boolean), pAGE_IDX As Nullable(Of Integer), pAGE_SIZE As Nullable(Of Integer), aS_COUNT As Nullable(Of Boolean)) As ObjectResult(Of ProjectViewpoint)
        Dim aEParameter As ObjectParameter = If(aE IsNot Nothing, New ObjectParameter("AE", aE), New ObjectParameter("AE", GetType(String)))

        Dim cdp_selectionParameter As ObjectParameter = If(cdp_selection IsNot Nothing, New ObjectParameter("cdp_selection", cdp_selection), New ObjectParameter("cdp_selection", GetType(String)))

        Dim start_dateParameter As ObjectParameter = If(start_date IsNot Nothing, New ObjectParameter("start_date", start_date), New ObjectParameter("start_date", GetType(String)))

        Dim end_dateParameter As ObjectParameter = If(end_date IsNot Nothing, New ObjectParameter("end_date", end_date), New ObjectParameter("end_date", GetType(String)))

        Dim closed_jobsParameter As ObjectParameter = If(closed_jobs IsNot Nothing, New ObjectParameter("closed_jobs", closed_jobs), New ObjectParameter("closed_jobs", GetType(String)))

        Dim userIDParameter As ObjectParameter = If(userID IsNot Nothing, New ObjectParameter("UserID", userID), New ObjectParameter("UserID", GetType(String)))

        Dim empCodeParameter As ObjectParameter = If(empCode IsNot Nothing, New ObjectParameter("EmpCode", empCode), New ObjectParameter("EmpCode", GetType(String)))

        Dim myProjectsParameter As ObjectParameter = If(myProjects IsNot Nothing, New ObjectParameter("myProjects", myProjects), New ObjectParameter("myProjects", GetType(String)))

        Dim eXCLUDE_JOBS_WITH_COMPLETED_SCHEDULESParameter As ObjectParameter = If(eXCLUDE_JOBS_WITH_COMPLETED_SCHEDULES.HasValue, New ObjectParameter("EXCLUDE_JOBS_WITH_COMPLETED_SCHEDULES", eXCLUDE_JOBS_WITH_COMPLETED_SCHEDULES), New ObjectParameter("EXCLUDE_JOBS_WITH_COMPLETED_SCHEDULES", GetType(Boolean)))

        Dim pAGE_IDXParameter As ObjectParameter = If(pAGE_IDX.HasValue, New ObjectParameter("PAGE_IDX", pAGE_IDX), New ObjectParameter("PAGE_IDX", GetType(Integer)))

        Dim pAGE_SIZEParameter As ObjectParameter = If(pAGE_SIZE.HasValue, New ObjectParameter("PAGE_SIZE", pAGE_SIZE), New ObjectParameter("PAGE_SIZE", GetType(Integer)))

        Dim aS_COUNTParameter As ObjectParameter = If(aS_COUNT.HasValue, New ObjectParameter("AS_COUNT", aS_COUNT), New ObjectParameter("AS_COUNT", GetType(Boolean)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of ProjectViewpoint)("GetProjects", aEParameter, cdp_selectionParameter, start_dateParameter, end_dateParameter, closed_jobsParameter, userIDParameter, empCodeParameter, myProjectsParameter, eXCLUDE_JOBS_WITH_COMPLETED_SCHEDULESParameter, pAGE_IDXParameter, pAGE_SIZEParameter, aS_COUNTParameter)
    End Function

    Public Overridable Function GetMyTasks(userID As String, empCode As String, startDate As Nullable(Of Date), taskStatus As String, taskShow As String, search As String, cP As Nullable(Of Integer), cPID As Nullable(Of Integer)) As ObjectResult(Of MyTask)
        Dim userIDParameter As ObjectParameter = If(userID IsNot Nothing, New ObjectParameter("UserID", userID), New ObjectParameter("UserID", GetType(String)))

        Dim empCodeParameter As ObjectParameter = If(empCode IsNot Nothing, New ObjectParameter("EmpCode", empCode), New ObjectParameter("EmpCode", GetType(String)))

        Dim startDateParameter As ObjectParameter = If(startDate.HasValue, New ObjectParameter("StartDate", startDate), New ObjectParameter("StartDate", GetType(Date)))

        Dim taskStatusParameter As ObjectParameter = If(taskStatus IsNot Nothing, New ObjectParameter("TaskStatus", taskStatus), New ObjectParameter("TaskStatus", GetType(String)))

        Dim taskShowParameter As ObjectParameter = If(taskShow IsNot Nothing, New ObjectParameter("TaskShow", taskShow), New ObjectParameter("TaskShow", GetType(String)))

        Dim searchParameter As ObjectParameter = If(search IsNot Nothing, New ObjectParameter("Search", search), New ObjectParameter("Search", GetType(String)))

        Dim cPParameter As ObjectParameter = If(cP.HasValue, New ObjectParameter("CP", cP), New ObjectParameter("CP", GetType(Integer)))

        Dim cPIDParameter As ObjectParameter = If(cPID.HasValue, New ObjectParameter("CPID", cPID), New ObjectParameter("CPID", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of MyTask)("GetMyTasks", userIDParameter, empCodeParameter, startDateParameter, taskStatusParameter, taskShowParameter, searchParameter, cPParameter, cPIDParameter)
    End Function

    Public Overridable Function GetTimeTemplates(eMP_CODE As String, uSER_CODE As String) As ObjectResult(Of TimeTemplate)
        Dim eMP_CODEParameter As ObjectParameter = If(eMP_CODE IsNot Nothing, New ObjectParameter("EMP_CODE", eMP_CODE), New ObjectParameter("EMP_CODE", GetType(String)))

        Dim uSER_CODEParameter As ObjectParameter = If(uSER_CODE IsNot Nothing, New ObjectParameter("USER_CODE", uSER_CODE), New ObjectParameter("USER_CODE", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of TimeTemplate)("GetTimeTemplates", eMP_CODEParameter, uSER_CODEParameter)
    End Function

    Public Overridable Function GetTimeSummaries(eMP_CODE As String, gROUP_TYPE As Nullable(Of Short), eNTER_DATE As Nullable(Of Date)) As ObjectResult(Of TimeSummary)
        Dim eMP_CODEParameter As ObjectParameter = If(eMP_CODE IsNot Nothing, New ObjectParameter("EMP_CODE", eMP_CODE), New ObjectParameter("EMP_CODE", GetType(String)))

        Dim gROUP_TYPEParameter As ObjectParameter = If(gROUP_TYPE.HasValue, New ObjectParameter("GROUP_TYPE", gROUP_TYPE), New ObjectParameter("GROUP_TYPE", GetType(Short)))

        Dim eNTER_DATEParameter As ObjectParameter = If(eNTER_DATE.HasValue, New ObjectParameter("ENTER_DATE", eNTER_DATE), New ObjectParameter("ENTER_DATE", GetType(Date)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of TimeSummary)("GetTimeSummaries", eMP_CODEParameter, gROUP_TYPEParameter, eNTER_DATEParameter)
    End Function

    Public Overridable Function SaveAlertAssignment(uSER_CODE As String, aLERT_ID As Nullable(Of Integer), eMP_CODE As String, cOMMENT_TYPE As Nullable(Of Integer), aLERT_STATE_ID As Nullable(Of Integer), aLRT_NOTIFY_HDR_ID As Nullable(Of Integer), aLERT_COMMENT As String, iS_UNASSIGNED As Nullable(Of Byte), sAVE_UNASSIGNED As Nullable(Of Byte), iS_NEW_ASSIGNMENT As Nullable(Of Byte)) As ObjectResult(Of Nullable(Of Boolean))
        Dim uSER_CODEParameter As ObjectParameter = If(uSER_CODE IsNot Nothing, New ObjectParameter("USER_CODE", uSER_CODE), New ObjectParameter("USER_CODE", GetType(String)))

        Dim aLERT_IDParameter As ObjectParameter = If(aLERT_ID.HasValue, New ObjectParameter("ALERT_ID", aLERT_ID), New ObjectParameter("ALERT_ID", GetType(Integer)))

        Dim eMP_CODEParameter As ObjectParameter = If(eMP_CODE IsNot Nothing, New ObjectParameter("EMP_CODE", eMP_CODE), New ObjectParameter("EMP_CODE", GetType(String)))

        Dim cOMMENT_TYPEParameter As ObjectParameter = If(cOMMENT_TYPE.HasValue, New ObjectParameter("COMMENT_TYPE", cOMMENT_TYPE), New ObjectParameter("COMMENT_TYPE", GetType(Integer)))

        Dim aLERT_STATE_IDParameter As ObjectParameter = If(aLERT_STATE_ID.HasValue, New ObjectParameter("ALERT_STATE_ID", aLERT_STATE_ID), New ObjectParameter("ALERT_STATE_ID", GetType(Integer)))

        Dim aLRT_NOTIFY_HDR_IDParameter As ObjectParameter = If(aLRT_NOTIFY_HDR_ID.HasValue, New ObjectParameter("ALRT_NOTIFY_HDR_ID", aLRT_NOTIFY_HDR_ID), New ObjectParameter("ALRT_NOTIFY_HDR_ID", GetType(Integer)))

        Dim aLERT_COMMENTParameter As ObjectParameter = If(aLERT_COMMENT IsNot Nothing, New ObjectParameter("ALERT_COMMENT", aLERT_COMMENT), New ObjectParameter("ALERT_COMMENT", GetType(String)))

        Dim iS_UNASSIGNEDParameter As ObjectParameter = If(iS_UNASSIGNED.HasValue, New ObjectParameter("IS_UNASSIGNED", iS_UNASSIGNED), New ObjectParameter("IS_UNASSIGNED", GetType(Byte)))

        Dim sAVE_UNASSIGNEDParameter As ObjectParameter = If(sAVE_UNASSIGNED.HasValue, New ObjectParameter("SAVE_UNASSIGNED", sAVE_UNASSIGNED), New ObjectParameter("SAVE_UNASSIGNED", GetType(Byte)))

        Dim iS_NEW_ASSIGNMENTParameter As ObjectParameter = If(iS_NEW_ASSIGNMENT.HasValue, New ObjectParameter("IS_NEW_ASSIGNMENT", iS_NEW_ASSIGNMENT), New ObjectParameter("IS_NEW_ASSIGNMENT", GetType(Byte)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of Nullable(Of Boolean))("SaveAlertAssignment", uSER_CODEParameter, aLERT_IDParameter, eMP_CODEParameter, cOMMENT_TYPEParameter, aLERT_STATE_IDParameter, aLRT_NOTIFY_HDR_IDParameter, aLERT_COMMENTParameter, iS_UNASSIGNEDParameter, sAVE_UNASSIGNEDParameter, iS_NEW_ASSIGNMENTParameter)
    End Function

    Public Overridable Function GetRecipients(cL_CODE As String, dIV_CODE As String, pRD_CODE As String, jOB_NUMBER As Nullable(Of Integer), jOB_COMPONENT_NBR As Nullable(Of Short), cMP_IDENTIFIER As Nullable(Of Integer), cLIENT_PORTAL_USER_ID As Nullable(Of Integer), aLERT_ID As Nullable(Of Integer), uSER_CODE As String, iS_REVIEWERS As Nullable(Of Boolean), eMAIL_GR_CODE As String) As ObjectResult(Of EmailRecipients)
        Dim cL_CODEParameter As ObjectParameter = If(cL_CODE IsNot Nothing, New ObjectParameter("CL_CODE", cL_CODE), New ObjectParameter("CL_CODE", GetType(String)))

        Dim dIV_CODEParameter As ObjectParameter = If(dIV_CODE IsNot Nothing, New ObjectParameter("DIV_CODE", dIV_CODE), New ObjectParameter("DIV_CODE", GetType(String)))

        Dim pRD_CODEParameter As ObjectParameter = If(pRD_CODE IsNot Nothing, New ObjectParameter("PRD_CODE", pRD_CODE), New ObjectParameter("PRD_CODE", GetType(String)))

        Dim jOB_NUMBERParameter As ObjectParameter = If(jOB_NUMBER.HasValue, New ObjectParameter("JOB_NUMBER", jOB_NUMBER), New ObjectParameter("JOB_NUMBER", GetType(Integer)))

        Dim jOB_COMPONENT_NBRParameter As ObjectParameter = If(jOB_COMPONENT_NBR.HasValue, New ObjectParameter("JOB_COMPONENT_NBR", jOB_COMPONENT_NBR), New ObjectParameter("JOB_COMPONENT_NBR", GetType(Short)))

        Dim cMP_IDENTIFIERParameter As ObjectParameter = If(cMP_IDENTIFIER.HasValue, New ObjectParameter("CMP_IDENTIFIER", cMP_IDENTIFIER), New ObjectParameter("CMP_IDENTIFIER", GetType(Integer)))

        Dim cLIENT_PORTAL_USER_IDParameter As ObjectParameter = If(cLIENT_PORTAL_USER_ID.HasValue, New ObjectParameter("CLIENT_PORTAL_USER_ID", cLIENT_PORTAL_USER_ID), New ObjectParameter("CLIENT_PORTAL_USER_ID", GetType(Integer)))

        Dim aLERT_IDParameter As ObjectParameter = If(aLERT_ID.HasValue, New ObjectParameter("ALERT_ID", aLERT_ID), New ObjectParameter("ALERT_ID", GetType(Integer)))

        Dim uSER_CODEParameter As ObjectParameter = If(uSER_CODE IsNot Nothing, New ObjectParameter("USER_CODE", uSER_CODE), New ObjectParameter("USER_CODE", GetType(String)))

        Dim iS_REVIEWERSParameter As ObjectParameter = If(iS_REVIEWERS.HasValue, New ObjectParameter("IS_REVIEWERS", iS_REVIEWERS), New ObjectParameter("IS_REVIEWERS", GetType(Boolean)))

        Dim eMAIL_GR_CODEParameter As ObjectParameter = If(eMAIL_GR_CODE IsNot Nothing, New ObjectParameter("EMAIL_GR_CODE", eMAIL_GR_CODE), New ObjectParameter("EMAIL_GR_CODE", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of EmailRecipients)("GetRecipients", cL_CODEParameter, dIV_CODEParameter, pRD_CODEParameter, jOB_NUMBERParameter, jOB_COMPONENT_NBRParameter, cMP_IDENTIFIERParameter, cLIENT_PORTAL_USER_IDParameter, aLERT_IDParameter, uSER_CODEParameter, iS_REVIEWERSParameter, eMAIL_GR_CODEParameter)
    End Function

    Public Overridable Function GetAlertAttachments(aLERT_ID As Nullable(Of Integer), eMP_CODE As String, oFFSET As Nullable(Of Decimal)) As ObjectResult(Of AlertAttachmentsList)
        Dim aLERT_IDParameter As ObjectParameter = If(aLERT_ID.HasValue, New ObjectParameter("ALERT_ID", aLERT_ID), New ObjectParameter("ALERT_ID", GetType(Integer)))

        Dim eMP_CODEParameter As ObjectParameter = If(eMP_CODE IsNot Nothing, New ObjectParameter("EMP_CODE", eMP_CODE), New ObjectParameter("EMP_CODE", GetType(String)))

        Dim oFFSETParameter As ObjectParameter = If(oFFSET.HasValue, New ObjectParameter("OFFSET", oFFSET), New ObjectParameter("OFFSET", GetType(Decimal)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of AlertAttachmentsList)("GetAlertAttachments", aLERT_IDParameter, eMP_CODEParameter, oFFSETParameter)
    End Function

    Public Overridable Function GetAlertRecipients(aLERT_ID As Nullable(Of Integer)) As ObjectResult(Of AlertRecipientsList)
        Dim aLERT_IDParameter As ObjectParameter = If(aLERT_ID.HasValue, New ObjectParameter("ALERT_ID", aLERT_ID), New ObjectParameter("ALERT_ID", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of AlertRecipientsList)("GetAlertRecipients", aLERT_IDParameter)
    End Function

    Public Overridable Function GetAlertComments(aLERT_ID As Nullable(Of Integer), eMP_CODE As String, oFFSET As Nullable(Of Decimal), hIDE_SYSTEM_COMMENTS As Nullable(Of Boolean)) As ObjectResult(Of AlertCommentsList)
        Dim aLERT_IDParameter As ObjectParameter = If(aLERT_ID.HasValue, New ObjectParameter("ALERT_ID", aLERT_ID), New ObjectParameter("ALERT_ID", GetType(Integer)))

        Dim eMP_CODEParameter As ObjectParameter = If(eMP_CODE IsNot Nothing, New ObjectParameter("EMP_CODE", eMP_CODE), New ObjectParameter("EMP_CODE", GetType(String)))

        Dim oFFSETParameter As ObjectParameter = If(oFFSET.HasValue, New ObjectParameter("OFFSET", oFFSET), New ObjectParameter("OFFSET", GetType(Decimal)))

        Dim hIDE_SYSTEM_COMMENTSParameter As ObjectParameter = If(hIDE_SYSTEM_COMMENTS.HasValue, New ObjectParameter("HIDE_SYSTEM_COMMENTS", hIDE_SYSTEM_COMMENTS), New ObjectParameter("HIDE_SYSTEM_COMMENTS", GetType(Boolean)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of AlertCommentsList)("GetAlertComments", aLERT_IDParameter, eMP_CODEParameter, oFFSETParameter, hIDE_SYSTEM_COMMENTSParameter)
    End Function

    Public Overridable Function GetCalendarItems(userID As String, empCode As String, officeCode As String, clientCode As String, divCode As String, prodCode As String, jobNumber As String, jobComp As String, rOLES As String, startDate As Nullable(Of Date), endDate As Nullable(Of Date), taskStatus As String, excludeTempComplete As String, milestonesOnly As String, manager As String, grpLevel As String, type As String, showTasks As Nullable(Of Short), showDuration As Nullable(Of Short), show_Events As Nullable(Of Short), show_Event_Tasks As Nullable(Of Short), dEPTS As String, tRF_CODE As String, cP As Nullable(Of Integer), cPID As Nullable(Of Integer), funcRoles As String, showAssignments As Nullable(Of Short), includeUnassigned As Nullable(Of Boolean)) As ObjectResult(Of CalendarItem)
        Dim userIDParameter As ObjectParameter = If(userID IsNot Nothing, New ObjectParameter("UserID", userID), New ObjectParameter("UserID", GetType(String)))

        Dim empCodeParameter As ObjectParameter = If(empCode IsNot Nothing, New ObjectParameter("EmpCode", empCode), New ObjectParameter("EmpCode", GetType(String)))

        Dim officeCodeParameter As ObjectParameter = If(officeCode IsNot Nothing, New ObjectParameter("OfficeCode", officeCode), New ObjectParameter("OfficeCode", GetType(String)))

        Dim clientCodeParameter As ObjectParameter = If(clientCode IsNot Nothing, New ObjectParameter("ClientCode", clientCode), New ObjectParameter("ClientCode", GetType(String)))

        Dim divCodeParameter As ObjectParameter = If(divCode IsNot Nothing, New ObjectParameter("DivCode", divCode), New ObjectParameter("DivCode", GetType(String)))

        Dim prodCodeParameter As ObjectParameter = If(prodCode IsNot Nothing, New ObjectParameter("ProdCode", prodCode), New ObjectParameter("ProdCode", GetType(String)))

        Dim jobNumberParameter As ObjectParameter = If(jobNumber IsNot Nothing, New ObjectParameter("JobNumber", jobNumber), New ObjectParameter("JobNumber", GetType(String)))

        Dim jobCompParameter As ObjectParameter = If(jobComp IsNot Nothing, New ObjectParameter("JobComp", jobComp), New ObjectParameter("JobComp", GetType(String)))

        Dim rOLESParameter As ObjectParameter = If(rOLES IsNot Nothing, New ObjectParameter("ROLES", rOLES), New ObjectParameter("ROLES", GetType(String)))

        Dim startDateParameter As ObjectParameter = If(startDate.HasValue, New ObjectParameter("StartDate", startDate), New ObjectParameter("StartDate", GetType(Date)))

        Dim endDateParameter As ObjectParameter = If(endDate.HasValue, New ObjectParameter("EndDate", endDate), New ObjectParameter("EndDate", GetType(Date)))

        Dim taskStatusParameter As ObjectParameter = If(taskStatus IsNot Nothing, New ObjectParameter("TaskStatus", taskStatus), New ObjectParameter("TaskStatus", GetType(String)))

        Dim excludeTempCompleteParameter As ObjectParameter = If(excludeTempComplete IsNot Nothing, New ObjectParameter("ExcludeTempComplete", excludeTempComplete), New ObjectParameter("ExcludeTempComplete", GetType(String)))

        Dim milestonesOnlyParameter As ObjectParameter = If(milestonesOnly IsNot Nothing, New ObjectParameter("MilestonesOnly", milestonesOnly), New ObjectParameter("MilestonesOnly", GetType(String)))

        Dim managerParameter As ObjectParameter = If(manager IsNot Nothing, New ObjectParameter("Manager", manager), New ObjectParameter("Manager", GetType(String)))

        Dim grpLevelParameter As ObjectParameter = If(grpLevel IsNot Nothing, New ObjectParameter("GrpLevel", grpLevel), New ObjectParameter("GrpLevel", GetType(String)))

        Dim typeParameter As ObjectParameter = If(type IsNot Nothing, New ObjectParameter("Type", type), New ObjectParameter("Type", GetType(String)))

        Dim showTasksParameter As ObjectParameter = If(showTasks.HasValue, New ObjectParameter("ShowTasks", showTasks), New ObjectParameter("ShowTasks", GetType(Short)))

        Dim showDurationParameter As ObjectParameter = If(showDuration.HasValue, New ObjectParameter("ShowDuration", showDuration), New ObjectParameter("ShowDuration", GetType(Short)))

        Dim show_EventsParameter As ObjectParameter = If(show_Events.HasValue, New ObjectParameter("Show_Events", show_Events), New ObjectParameter("Show_Events", GetType(Short)))

        Dim show_Event_TasksParameter As ObjectParameter = If(show_Event_Tasks.HasValue, New ObjectParameter("Show_Event_Tasks", show_Event_Tasks), New ObjectParameter("Show_Event_Tasks", GetType(Short)))

        Dim dEPTSParameter As ObjectParameter = If(dEPTS IsNot Nothing, New ObjectParameter("DEPTS", dEPTS), New ObjectParameter("DEPTS", GetType(String)))

        Dim tRF_CODEParameter As ObjectParameter = If(tRF_CODE IsNot Nothing, New ObjectParameter("TRF_CODE", tRF_CODE), New ObjectParameter("TRF_CODE", GetType(String)))

        Dim cPParameter As ObjectParameter = If(cP.HasValue, New ObjectParameter("CP", cP), New ObjectParameter("CP", GetType(Integer)))

        Dim cPIDParameter As ObjectParameter = If(cPID.HasValue, New ObjectParameter("CPID", cPID), New ObjectParameter("CPID", GetType(Integer)))

        Dim funcRolesParameter As ObjectParameter = If(funcRoles IsNot Nothing, New ObjectParameter("FuncRoles", funcRoles), New ObjectParameter("FuncRoles", GetType(String)))

        Dim showAssignmentsParameter As ObjectParameter = If(showAssignments.HasValue, New ObjectParameter("ShowAssignments", showAssignments), New ObjectParameter("ShowAssignments", GetType(Short)))

        Dim includeUnassignedParameter As ObjectParameter = If(includeUnassigned.HasValue, New ObjectParameter("IncludeUnassigned", includeUnassigned), New ObjectParameter("IncludeUnassigned", GetType(Boolean)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of CalendarItem)("GetCalendarItems", userIDParameter, empCodeParameter, officeCodeParameter, clientCodeParameter, divCodeParameter, prodCodeParameter, jobNumberParameter, jobCompParameter, rOLESParameter, startDateParameter, endDateParameter, taskStatusParameter, excludeTempCompleteParameter, milestonesOnlyParameter, managerParameter, grpLevelParameter, typeParameter, showTasksParameter, showDurationParameter, show_EventsParameter, show_Event_TasksParameter, dEPTSParameter, tRF_CODEParameter, cPParameter, cPIDParameter, funcRolesParameter, showAssignmentsParameter, includeUnassignedParameter)
    End Function

    Public Overridable Function DeleteTimeEntry(et_id As Nullable(Of Integer), etd_id As Nullable(Of Integer), time_type As String, error_text As ObjectParameter) As Integer
        Dim et_idParameter As ObjectParameter = If(et_id.HasValue, New ObjectParameter("et_id", et_id), New ObjectParameter("et_id", GetType(Integer)))

        Dim etd_idParameter As ObjectParameter = If(etd_id.HasValue, New ObjectParameter("etd_id", etd_id), New ObjectParameter("etd_id", GetType(Integer)))

        Dim time_typeParameter As ObjectParameter = If(time_type IsNot Nothing, New ObjectParameter("time_type", time_type), New ObjectParameter("time_type", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("DeleteTimeEntry", et_idParameter, etd_idParameter, time_typeParameter, error_text)
    End Function

    Public Overridable Function SearchTimesheetJobs(sEARCH_STRING As String, uSER_CODE As String) As ObjectResult(Of SimpleJob)
        Dim sEARCH_STRINGParameter As ObjectParameter = If(sEARCH_STRING IsNot Nothing, New ObjectParameter("SEARCH_STRING", sEARCH_STRING), New ObjectParameter("SEARCH_STRING", GetType(String)))

        Dim uSER_CODEParameter As ObjectParameter = If(uSER_CODE IsNot Nothing, New ObjectParameter("USER_CODE", uSER_CODE), New ObjectParameter("USER_CODE", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of SimpleJob)("SearchTimesheetJobs", sEARCH_STRINGParameter, uSER_CODEParameter)
    End Function

    <EdmFunction("DataEntities", "advtf_alert_recipient_get")>
    Public Overridable Function advtf_alert_recipient_get(aLERT_ID As Nullable(Of Integer)) As IQueryable(Of advtf_alert_recipient_get_Result)
        Dim aLERT_IDParameter As ObjectParameter = If(aLERT_ID.HasValue, New ObjectParameter("ALERT_ID", aLERT_ID), New ObjectParameter("ALERT_ID", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.CreateQuery(Of advtf_alert_recipient_get_Result)("[DataEntities].[advtf_alert_recipient_get](@ALERT_ID)", aLERT_IDParameter)
    End Function

End Class
