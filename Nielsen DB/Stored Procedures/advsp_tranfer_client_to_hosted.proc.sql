CREATE PROC advsp_tranfer_client_to_hosted
AS

BEGIN TRAN

DELETE NIELSENHOSTED.dbo.CLIENT_ORDER_STATE
DELETE NIELSENHOSTED.dbo.CLIENT_ORDER_MARKET 
DELETE NIELSENHOSTED.dbo.CLIENT_ORDER
DELETE NIELSENHOSTED.dbo.CLIENT

SET IDENTITY_INSERT NIELSENHOSTED.dbo.CLIENT ON

INSERT INTO NIELSENHOSTED.dbo.CLIENT (CLIENT_ID, CODE, CLIENT_NAME, IS_INACTIVE, IS_NCC_SUBSCRIBED, FUSION_METERED_MARKETS, FUSION_DIARY_MARKETS)
SELECT CLIENT_ID, CODE, CLIENT_NAME, IS_INACTIVE, IS_NCC_SUBSCRIBED, FUSION_METERED_MARKETS, FUSION_DIARY_MARKETS
FROM dbo.CLIENT

SET IDENTITY_INSERT NIELSENHOSTED.dbo.CLIENT OFF

SET IDENTITY_INSERT NIELSENHOSTED.dbo.CLIENT_ORDER ON

INSERT INTO NIELSENHOSTED.dbo.CLIENT_ORDER (CLIENT_ORDER_ID, CLIENT_ID, ORDER_TYPE, ORDER_NUMBER, ORDER_DATETIME, LAST_CHANGED_DATETIME, START_YEAR, END_YEAR, ORDER_DURATION, REPORT, ALL_MARKETS, CLIENT_ALIAS, IS_SUSPENDED, CUME, ALL_STATES, ETHNICITY, IS_OLYMPIC)
SELECT CLIENT_ORDER_ID, CLIENT_ID, ORDER_TYPE, ORDER_NUMBER, ORDER_DATETIME, LAST_CHANGED_DATETIME, START_YEAR, END_YEAR, ORDER_DURATION, REPORT, ALL_MARKETS, CLIENT_ALIAS, IS_SUSPENDED, CUME, ALL_STATES, ETHNICITY, IS_OLYMPIC
FROM dbo.CLIENT_ORDER

SET IDENTITY_INSERT NIELSENHOSTED.dbo.CLIENT_ORDER OFF

SET IDENTITY_INSERT NIELSENHOSTED.dbo.CLIENT_ORDER_MARKET ON

INSERT INTO NIELSENHOSTED.dbo.CLIENT_ORDER_MARKET (CLIENT_ORDER_MARKET_ID, CLIENT_ORDER_ID, MARKET_NUMBER, SEPTEMBER, OCTOBER, NOVEMBER, DECEMBER, JANUARY, FEBRUARY, MARCH, APRIL, MAY, JUNE, JULY, AUGUST, 
	WINTER_QUARTERLY, SPRING_QUARTERLY, SUMMER_QUARTERLY, FALL_QUARTERLY, CUME)
SELECT CLIENT_ORDER_MARKET_ID, CLIENT_ORDER_ID, MARKET_NUMBER, SEPTEMBER, OCTOBER, NOVEMBER, DECEMBER, JANUARY, FEBRUARY, MARCH, APRIL, MAY, JUNE, JULY, AUGUST,
	WINTER_QUARTERLY, SPRING_QUARTERLY, SUMMER_QUARTERLY, FALL_QUARTERLY, CUME
FROM dbo.CLIENT_ORDER_MARKET

SET IDENTITY_INSERT NIELSENHOSTED.dbo.CLIENT_ORDER_MARKET OFF

SET IDENTITY_INSERT NIELSENHOSTED.dbo.CLIENT_ORDER_STATE ON

INSERT INTO NIELSENHOSTED.dbo.CLIENT_ORDER_STATE ( CLIENT_ORDER_STATE_ID, CLIENT_ORDER_ID, [STATE] )
SELECT CLIENT_ORDER_STATE_ID, CLIENT_ORDER_ID, [STATE]
FROM dbo.CLIENT_ORDER_STATE

SET IDENTITY_INSERT NIELSENHOSTED.dbo.CLIENT_ORDER_STATE OFF

COMMIT TRAN
GO

GRANT EXEC ON advsp_tranfer_client_to_hosted TO PUBLIC
GO