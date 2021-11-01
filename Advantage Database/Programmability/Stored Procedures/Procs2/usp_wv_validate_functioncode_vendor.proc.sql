if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_validate_functioncode_vendor]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_validate_functioncode_vendor]
GO


CREATE PROCEDURE [dbo].[usp_wv_validate_functioncode_vendor]
@FuncCode VARCHAR(10)
AS

	IF EXISTS(
	    SELECT FNC_CODE
	    FROM FUNCTIONS 
	    WHERE FNC_CODE = @FuncCode
	    AND ( FNC_INACTIVE IS NULL OR FNC_INACTIVE = 0 ) AND FNC_TYPE = 'V'
	)
		SELECT 1
	ELSE
		SELECT 0

