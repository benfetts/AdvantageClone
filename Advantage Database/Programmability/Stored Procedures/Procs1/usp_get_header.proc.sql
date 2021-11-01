

/*****************************************************************
Webvantage
This Stored Procedure gets the header by location ID
******************************************************************/
CREATE PROCEDURE [dbo].[usp_get_header] 
@Location varchar(6)
AS

SET ANSI_NULLS OFF


SELECT dbo.udf_get_header(@Location )


