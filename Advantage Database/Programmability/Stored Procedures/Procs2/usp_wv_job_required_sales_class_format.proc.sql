




















CREATE PROCEDURE [dbo].[usp_wv_job_required_sales_class_format] 
@ClientCode VarChar(6)
AS

Declare @ThisReturn as integer

Select @ThisReturn = FORMAT_SC_CODE_R 
FROM AGENCY

Select @ThisReturn = FORMAT_SC_CODE_R
From CLIENT
Where CL_CODE = @ClientCode
AND REQ_FLDS = 1

Select @ThisReturn




















