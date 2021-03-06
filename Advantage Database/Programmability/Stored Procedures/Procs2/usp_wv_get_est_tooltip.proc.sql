
/*****************************************************************
Webvantage
This Stored Procedure get Task Details By Date, 
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_get_est_tooltip] 
@JobNum Varchar(6),
@JobComp Varchar(6)

WITH RECOMPILE

AS

DECLARE @sql 		varchar(6000)
DECLARE @sql_from 	varchar(4000)
DECLARE @sql_where 	varchar(4000)
DECLARE @CT INT
DECLARE @CT_INT INT

SELECT @CT =  COUNT(*)
FROM ESTIMATE_APPROVAL 
WHERE  ESTIMATE_APPROVAL.JOB_NUMBER =  @JobNum  And ESTIMATE_APPROVAL.JOB_COMPONENT_NBR =  @JobComp

SELECT @CT_INT =  COUNT(*)
FROM ESTIMATE_INT_APPR 
WHERE  ESTIMATE_INT_APPR.JOB_NUMBER =  @JobNum  And ESTIMATE_INT_APPR.JOB_COMPONENT_NBR =  @JobComp

IF @CT > 0 OR @CT_INT > 0
	set @sql = 'SELECT ESTIMATE_REV.EST_QUOTE_NBR,  ESTIMATE_REV.EST_REV_NBR, ISNULL(ESTIMATE_REV.JOB_QTY,0), '
ELSE
	set @sql = 'SELECT NULL, NULL, NULL, '


set @sql_from = ' FROM ESTIMATE_REV 
   INNER JOIN JOB_COMPONENT ON JOB_COMPONENT.ESTIMATE_NUMBER = ESTIMATE_REV.ESTIMATE_NUMBER
     	AND JOB_COMPONENT.EST_COMPONENT_NBR = ESTIMATE_REV.EST_COMPONENT_NBR '

set @sql_where = ' WHERE JOB_COMPONENT.JOB_NUMBER = '+ @JobNum + ' And JOB_COMPONENT.JOB_COMPONENT_NBR = ' + @JobComp

IF @CT > 0 
	BEGIN
	set @sql = @sql + 'ESTIMATE_APPROVAL.EST_APPR_BY,  ESTIMATE_APPROVAL.EST_APPR_DATE, '
	
	set @sql_from = @sql_from + ' INNER JOIN ESTIMATE_APPROVAL ON ESTIMATE_REV.ESTIMATE_NUMBER = ESTIMATE_APPROVAL.ESTIMATE_NUMBER 
     	AND ESTIMATE_REV.EST_COMPONENT_NBR = ESTIMATE_APPROVAL.EST_COMPONENT_NBR 
       	AND ESTIMATE_REV.EST_QUOTE_NBR = ESTIMATE_APPROVAL.EST_QUOTE_NBR 
       	AND ESTIMATE_REV.EST_REV_NBR = ESTIMATE_APPROVAL.EST_REVISION_NBR  '
	END
ELSE
	set @sql = @sql + '''N/A'',  NULL, '
	

set @sql = @sql + ' ESTIMATE_REV.ESTIMATE_NUMBER, ESTIMATE_REV.EST_COMPONENT_NBR, '
 	
 IF @CT_INT > 0 
	BEGIN
	set @sql = @sql + 'ESTIMATE_INT_APPR.EST_APPR_BY,  ESTIMATE_INT_APPR.EST_APPR_DATE '
	
	set @sql_from = @sql_from + ' INNER JOIN ESTIMATE_INT_APPR ON ESTIMATE_REV.ESTIMATE_NUMBER = ESTIMATE_INT_APPR.ESTIMATE_NUMBER 
   	AND ESTIMATE_REV.EST_COMPONENT_NBR = ESTIMATE_INT_APPR.EST_COMPONENT_NBR  
 	AND ESTIMATE_REV.EST_QUOTE_NBR = ESTIMATE_INT_APPR.EST_QUOTE_NBR 
 	AND ESTIMATE_REV.EST_REV_NBR = ESTIMATE_INT_APPR.EST_REVISION_NBR '
	END
ELSE
	set @sql = @sql + '''N/A'',  NULL '


set @sql = @sql + @sql_from + @sql_where

--print(@sql)
EXEC (@sql)


SET QUOTED_IDENTIFIER ON 
