
CREATE PROCEDURE [dbo].[usp_wv_Get_Alert_DefaultGroup] 

@Client VarChar(6),
@Division VarChar(6),
@Product VarChar(6),
@JobNumber Int,
@JobComponent int
 
AS

Declare @EmailGroup as varchar(150)

SET NOCOUNT ON

--Select @EmailGroup = EMAIL_GR_CODE From PRODUCT
--Where CL_CODE = @Client and 
--DIV_CODE = @Division and
--PRD_CODE = @Product

Select @EmailGroup = ISNULL(EMAIL_GR_CODE,'') From JOB_COMPONENT
Where JOB_NUMBER = @JobNumber and 
JOB_COMPONENT_NBR = @JobComponent

Select EmailGroup = @EmailGroup
