


CREATE VIEW [dbo].[CP_MEDIA_CALENDAR]
AS
SELECT     '' AS TYPE, '' AS EST_ACT, '' AS OFFICE_CODE, 0 AS ORDER_NBR, '' AS ORDER_DESC, '' AS MEDIA_TYPE, '' AS CL_CODE, '' AS DIV_CODE, 
                      '' AS PRD_CODDE, 0 AS CMP_IDENTIFIER, '' AS CMP_CODE, '' AS CMP_NAME, '' AS VN_CODE, '' AS VN_NAME, '' AS BUYER, '' AS CLIENT_PO, 
                      '' AS MARKET_CODE, '' AS MARKET_DESC, 0 AS ORDER_ACCEPTED, 0 AS LINE_NBR, 0 AS ACTIVE_REV, '' AS FLIGHT_DATES, { fn NOW() 
                      } AS START_DATE, { fn NOW() } AS END_DATE, '' AS MEDIA_MONTH, '' AS MEDIA_YEAR, { fn NOW() } AS CLOSE_DATE, { fn NOW() 
                      } AS MATL_CLOSE_DATE, { fn NOW() } AS EXT_MATL_DATE, '' AS SIZE, 0.0000001 AS PRINT_COLUMNS, 0.0000001 AS PRINT_INCHES, 
                      0.0000001 AS PRINT_LINES, '' AS AD_NUMBER, '' AS HEADLINE, '' AS INTERNET_TYPE, '' AS OUTDOOR_TYPE, '' AS MATERIAL, '' AS EDITION_ISSUE,
                       '' AS SECTION, '' AS START_TIME, '' AS END_TIME, '' AS LENGTH, '' AS TAG, '' AS PROGRAMMING, '' AS MATL_NOTES, '' AS REMARKS, 
                      0 AS JOB_NUMBER, 0 AS JOB_COMPONENT_NBR, '' AS PRODUCTION_SIZE, 0 AS EST_NBR, 0 AS EST_LINE_NBR, 0 AS EST_REV_NBR, 
                      0.01 AS LINE_TOTAL, 0.01 AS COST_PER, 0.01 AS IMPRESSIONS, 0 AS LINE_CANCELLED, '' AS CL_NAME, '' AS DIV_NAME, '' AS PRD_DESCRIPTION, 
                      0 AS REV_NBR, { fn NOW() } AS MAT_COMP



