IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[advsp_comscore_get_new_market_number]' ) AND OBJECTPROPERTY( id, N'IsProcedure' ) = 1 )
	DROP PROCEDURE [dbo].[advsp_comscore_get_new_market_number]
GO

CREATE PROCEDURE [dbo].[advsp_comscore_get_new_market_number]
	@COMSCORE_MARKET_NUMBER smallint
AS

SELECT COMSCORE_NEW_MARKET_NUMBER FROM MARKET WHERE COMSCORE_MARKET_NUMBER = @COMSCORE_MARKET_NUMBER

GO