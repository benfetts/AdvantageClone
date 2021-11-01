'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Employee
    Public Property Code As String
    Public Property DepartmentTeamCode As String
    Public Property LastName As String
    Public Property FirstName As String
    Public Property MiddleInitial As String
    Public Property EMP_COST_RATE As Nullable(Of Decimal)
    Public Property Address1 As String
    Public Property Address2 As String
    Public Property EMP_ALPHA_SORT As String
    Public Property City As String
    Public Property Country As String
    Public Property County As String
    Public Property EMP_PAY_TO_ADDR1 As String
    Public Property EMP_PAY_TO_ADDR2 As String
    Public Property EMP_PAY_TO_CITY As String
    Public Property EMP_PAY_TO_COUNTRY As String
    Public Property EMP_PAY_TO_COUNTY As String
    Public Property EMP_PAY_TO_STATE As String
    Public Property EMP_PAY_TO_ZIP As String
    Public Property PhoneNumber As String
    Public Property State As String
    Public Property Zip As String
    Public Property EMP_DATE As Nullable(Of Date)
    Public Property TerminatedDate As Nullable(Of Date)
    Public Property BirthDay As Nullable(Of Date)
    Public Property EMP_LAST_INCREASE As Nullable(Of Date)
    Public Property EMP_NEXT_REVIEW As Nullable(Of Date)
    Public Property EMP_ANNUAL_SALARY As Nullable(Of Decimal)
    Public Property EMP_MONTHLY_SALARY As Nullable(Of Decimal)
    Public Property Email As String
    Public Property MonthHoursGoal As Nullable(Of Decimal)
    Public Property OfficeCode As String
    Public Property SupervisorEmployeeCode As String
    Public Property VAC_HRS As Nullable(Of Decimal)
    Public Property VAC_FROM_DATE As Nullable(Of Date)
    Public Property VAC_TO_DATE As Nullable(Of Date)
    Public Property SICK_HRS As Nullable(Of Decimal)
    Public Property SICK_FROM_DATE As Nullable(Of Date)
    Public Property SICK_TO_DATE As Nullable(Of Date)
    Public Property StandardWorkdays As Nullable(Of Decimal)
    Public Property EmployeeWorkdays As String
    Public Property EMP_TIME_ALERT As Nullable(Of Short)
    Public Property SMTP_SERVER As String
    Public Property EMAIL_PWD As String
    Public Property MondayHours As Nullable(Of Decimal)
    Public Property TuesdayHours As Nullable(Of Decimal)
    Public Property WednesdayHours As Nullable(Of Decimal)
    Public Property ThursdayHours As Nullable(Of Decimal)
    Public Property FridayHours As Nullable(Of Decimal)
    Public Property SaturdayHours As Nullable(Of Decimal)
    Public Property SundayHours As Nullable(Of Decimal)
    Public Property ALERT_EMAIL As Nullable(Of Short)
    Public Property FREELANCE As Nullable(Of Short)
    Public Property PERS_HRS As Nullable(Of Decimal)
    Public Property PERS_FROM_DATE As Nullable(Of Date)
    Public Property PERS_TO_DATE As Nullable(Of Date)
    Public Property DefaultFunctionCode As String
    Public Property PO_LIMIT As Nullable(Of Decimal)
    Public Property EMP_ACCOUNT_NBR As String
    Public Property EMP_PHONE_WORK As String
    Public Property EMP_PHONE_CELL As String
    Public Property EMP_PHONE_ALT As String
    Public Property EMP_PHONE_WORK_EXT As String
    Public Property STD_ANNUAL_HRS As Nullable(Of Decimal)
    Public Property VN_CODE_EXP As String
    Public Property CC_NUMBER As String
    Public Property CC_DESC As String
    Public Property CC_GL_ACCOUNT As String
    Public Property EXP_APPR_REQ As Nullable(Of Short)
    Public Property MISSING_TIME As Nullable(Of Short)
    Public Property WEEKLY_TIME As Nullable(Of Short)
    Public Property SIGNATURE_PATH As String
    Public Property STATUS As Nullable(Of Short)
    Public Property DIRECT_HRS_PER As Nullable(Of Decimal)
    Public Property DEF_TRF_ROLE As String
    Public Property EMP_COMMENT As String
    Public Property EMPLOYEE_TITLE_ID As Nullable(Of Integer)
    Public Property PO_APPR_RULE_CODE As String
    Public Property PO_GL_SELECTION As Nullable(Of Short)
    Public Property PO_GL_LIMIT_BY_OFFICE As Nullable(Of Short)
    Public Property SENIORITY As Nullable(Of Short)
    Public Property EMP_START_TIME As Nullable(Of Date)
    Public Property EMP_END_TIME As Nullable(Of Date)
    Public Property EMP_START_TIME_MON As Nullable(Of Date)
    Public Property EMP_END_TIME_MON As Nullable(Of Date)
    Public Property EMP_START_TIME_TUE As Nullable(Of Date)
    Public Property EMP_END_TIME_TUE As Nullable(Of Date)
    Public Property EMP_START_TIME_WED As Nullable(Of Date)
    Public Property EMP_END_TIME_WED As Nullable(Of Date)
    Public Property EMP_START_TIME_THU As Nullable(Of Date)
    Public Property EMP_END_TIME_THU As Nullable(Of Date)
    Public Property EMP_START_TIME_FRI As Nullable(Of Date)
    Public Property EMP_END_TIME_FRI As Nullable(Of Date)
    Public Property EMP_START_TIME_SAT As Nullable(Of Date)
    Public Property EMP_END_TIME_SAT As Nullable(Of Date)
    Public Property EMP_START_TIME_SUN As Nullable(Of Date)
    Public Property EMP_END_TIME_SUN As Nullable(Of Date)
    Public Property EMAIL_USERNAME As String
    Public Property EMAIL_REPLY_TO As String
    Public Property EMP_SIG As Byte()
    Public Property WV_TMPLT_HDR_ID As Nullable(Of Integer)
    Public Property ALT_COST_RATE As Nullable(Of Decimal)
    Public Property ALT_DATE_FRM As Nullable(Of Date)
    Public Property ALT_DATE_TO As Nullable(Of Date)
    Public Property CREATED_BY As String
    Public Property CREATED_DATE As Nullable(Of Date)
    Public Property LAST_MODIFIED_BY As String
    Public Property LAST_MODIFIED_DATE As Nullable(Of Date)
    Public Property METHOD As String
    Public Property EXP_RPT_APPROVER As String
    Public Property VAC_TIME_RULE_ID As Nullable(Of Integer)
    Public Property SICK_TIME_RULE_ID As Nullable(Of Integer)
    Public Property PERS_TIME_RULE_ID As Nullable(Of Integer)
    Public Property EMP_TITLE As String
    Public Property TimesheetApprovalFlag As Nullable(Of Boolean)
    Public Property IS_ACTIVE_FREELANCE As Boolean
    Public Property SUGAR_USERNAME As String
    Public Property SUGAR_PASSWORD As String
    Public Property PROOFHQ_PASSWORD As String
    Public Property PROOFHQ_USERNAME As String
    Public Property EMP_BILL_RATE As Nullable(Of Decimal)
    Public Property IS_API_USER As String
    Public Property GOOGLE_TOKEN As String
    Public Property ADOBE_SIGNATURE_FILE As Byte()
    Public Property ADOBE_SIGNATURE_FILE_PASSWORD As String
    Public Property VCC_PASSWORD As String
    Public Property VCC_USERNAME As String
    Public Property EMP_OMIT_MISSING As Nullable(Of Short)
    Public Property IGNORE_CALENDAR_SYNC As Boolean
    Public Property TIME_ZONE_ID As String
    Public Property CS_PASSWORD As String
    Public Property CS_USERID As Nullable(Of Integer)
    Public Property CULTURE_CODE As String
    Public Property CAL_TIME_TYPE As Nullable(Of Short)
    Public Property CAL_TIME_EMAIL As String
    Public Property CAL_TIME_USERNAME As String
    Public Property CAL_TIME_PASSWORD As String
    Public Property CAL_TIME_HOST As String
    Public Property CAL_TIME_PORT As Nullable(Of Integer)
    Public Property CAL_TIME_SSL As Nullable(Of Boolean)
    Public Property EMP_OTHER_INFO As String

End Class
