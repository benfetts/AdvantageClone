﻿
CREATE PROCEDURE [dbo].[usp_wv_EVENT_GEN_GET_DETAILS] 
	@EVENT_GEN_ID AS INTEGER
AS

    SELECT     
        EVENT_GEN_ID, 
        EVENT_GEN_LABEL, 
        EVENT_GEN_DESC_LONG, 
        TYPE, 
        START_DATE, 
        END_DATE, 
        START_TIME, 
        END_TIME, 
        OCCUR, 
        DAY_INCREMENT, 
        DAYS, 
        QTY_HOURS, 
        ISNULL(QTY_TYPE,1) AS QTY_TYPE, --DEFAULT TO 1 = HOURS
        ALL_DAY, 
        JOB_NUMBER, 
        JOB_COMPONENT_NBR, 
        EST_NUMBER, 
        EST_COMPONENT_NBR, 
        EST_QUOTE_NUMBER, 
        EVENT_GEN.FNC_CODE, 
        AD_NUMBER, 
        CREATE_DATE, 
        CREATE_USER, 
        GENERATE_DATE, 
        GENERATE_USER, 
        FUNCTIONS.FNC_DESCRIPTION, 
        AD_NUMBER.AD_NBR_DESC,
		EVENT_GEN.EVENT_TYPE_ID
    FROM         
        EVENT_GEN WITH (NOLOCK) LEFT OUTER JOIN
        AD_NUMBER WITH (NOLOCK) ON EVENT_GEN.AD_NUMBER = AD_NUMBER.AD_NBR LEFT OUTER JOIN
        [FUNCTIONS] WITH (NOLOCK) ON EVENT_GEN.FNC_CODE = FUNCTIONS.FNC_CODE
    WHERE     
        (EVENT_GEN_ID = @EVENT_GEN_ID);

