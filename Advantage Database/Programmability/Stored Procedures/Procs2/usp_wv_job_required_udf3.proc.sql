﻿





















CREATE PROCEDURE [dbo].[usp_wv_job_required_udf3] 
@ClientCode VarChar(4)
AS

Declare @ThisReturn as integer

Select @ThisReturn = JOB_LOG_UDV3_R
FROM AGENCY

Select @ThisReturn = JOB_LOG_UDV3_R
From CLIENT
Where CL_CODE = @ClientCode
AND REQ_FLDS = 1

Select @ThisReturn




















