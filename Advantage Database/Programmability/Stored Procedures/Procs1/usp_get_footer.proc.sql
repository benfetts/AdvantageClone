

CREATE PROCEDURE [dbo].[usp_get_footer] 
@Location VarChar(6)

AS


SET ANSI_NULLS OFF


SELECT dbo.udf_get_footer(@Location )



