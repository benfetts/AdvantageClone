





















/*
ST, 20060619:
	Was double checking this sproc looking for markup insert, and found the first select statement had a hard coded "18" in it
*/


CREATE PROCEDURE [dbo].[usp_wv_job_component_new]
@JobNumber Integer, 
@JobCompNumber SmallInt,
@EMP_CODE varchar(6),
@JOB_COMP_DESC varchar(60)
AS

Declare 
@ProdMarkup Decimal(11,2),
@DefaultEmailGroup Varchar(50)

Select @ProdMarkup = PRD_PROD_MARKUP, @DefaultEmailGroup = EMAIL_GR_CODE
From PRODUCT
	Inner Join JOB_LOG
	On PRODUCT.CL_CODE = JOB_LOG.CL_CODE
	AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE
	AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE
Where JOB_LOG.JOB_NUMBER = @JobNumber


INSERT INTO [dbo].[JOB_COMPONENT] (
	[JOB_NUMBER],
	[JOB_COMPONENT_NBR],
	[EMP_CODE],
	[JOB_COMP_DESC],
	[JOB_SPEC_TYPE], 
	[JOB_PROCESS_CONTRL],
	[JOB_COMP_DATE], 
	[JOB_MARKUP_PCT],
	[EMAIL_GR_CODE]
) 

VALUES (
	@JobNumber,
	@JobCompNumber,
	@EMP_CODE,
	@JOB_COMP_DESC,
	0,1,
	Convert(Varchar(10) , GetDate(), 101),
	@ProdMarkup,
	@DefaultEmailGroup
)

Select JOB_COMP_DATE, JOB_MARKUP_PCT from JOB_COMPONENT
Where JOB_NUMBER = @JobNumber
AND JOB_COMPONENT_NBR = @JobCompNumber





















