﻿





















CREATE PROCEDURE [dbo].[usp_wv_job_required_complexity] 
@ClientCode VarChar(6)
AS

Declare @ThisReturn as integer

Select @ThisReturn = COMPLEX_CODE_R 
FROM AGENCY

Select @ThisReturn = COMPLEX_CODE_R 
From CLIENT
Where CL_CODE = @ClientCode
AND REQ_FLDS = 1

Select @ThisReturn





















