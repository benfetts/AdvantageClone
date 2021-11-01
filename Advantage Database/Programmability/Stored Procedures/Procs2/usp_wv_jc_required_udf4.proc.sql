





















CREATE PROCEDURE [dbo].[usp_wv_jc_required_udf4] 
@ClientCode VarChar(4)
AS

Declare @ThisReturn as integer

Select @ThisReturn = JOB_CMP_UDV4_R
FROM AGENCY

Select @ThisReturn = JOB_CMP_UDV4_R
From CLIENT
Where CL_CODE = @ClientCode
AND REQ_FLDS = 1

Select @ThisReturn




















