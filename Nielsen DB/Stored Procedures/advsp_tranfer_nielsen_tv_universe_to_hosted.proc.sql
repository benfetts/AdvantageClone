CREATE PROC [dbo].[advsp_tranfer_nielsen_tv_universe_to_hosted]
AS

BEGIN TRAN

SET IDENTITY_INSERT NIELSENHOSTED.dbo.NIELSEN_TV_UNIVERSE ON

INSERT INTO NIELSENHOSTED.dbo.NIELSEN_TV_UNIVERSE ( NIELSEN_TV_UNIVERSE_ID, NIELSEN_MARKET_NUM, [YEAR], [MONTH], IS_METERED_MARKET, METROA_HOUSEHOLD_UE, METROB_HOUSEHOLD_UE, HOUSEHOLD_UE, 
CHILDREN_2TO5_UE, CHILDREN_6TO11_UE, MALES_12TO14_UE, MALES_15TO17_UE, MALES_18TO20_UE, MALES_21TO24_UE, MALES_25TO34_UE, MALES_35TO49_UE, MALES_50TO54_UE, MALES_55TO64_UE,MALES_65PLUS_UE,
FEMALES_12TO14_UE, FEMALES_15TO17_UE, FEMALES_18TO20_UE, FEMALES_21TO24_UE, FEMALES_25TO34_UE, FEMALES_35TO49_UE, FEMALES_50TO54_UE, FEMALES_55TO64_UE, FEMALES_65PLUS_UE, 
WORKING_WOMEN_UE, SURVEY_START_DATE, SURVEY_END_DATE, [REPORTING_SERVICE], [EXCLUSION], [ETHNICITY])
SELECT NIELSEN_TV_UNIVERSE_ID, NIELSEN_MARKET_NUM, [YEAR], [MONTH], IS_METERED_MARKET, METROA_HOUSEHOLD_UE, METROB_HOUSEHOLD_UE, HOUSEHOLD_UE, 
CHILDREN_2TO5_UE, CHILDREN_6TO11_UE, MALES_12TO14_UE, MALES_15TO17_UE, MALES_18TO20_UE, MALES_21TO24_UE, MALES_25TO34_UE, MALES_35TO49_UE, MALES_50TO54_UE, MALES_55TO64_UE,MALES_65PLUS_UE,
FEMALES_12TO14_UE, FEMALES_15TO17_UE, FEMALES_18TO20_UE, FEMALES_21TO24_UE, FEMALES_25TO34_UE, FEMALES_35TO49_UE, FEMALES_50TO54_UE, FEMALES_55TO64_UE, FEMALES_65PLUS_UE, 
WORKING_WOMEN_UE, SURVEY_START_DATE, SURVEY_END_DATE, [REPORTING_SERVICE], [EXCLUSION], [ETHNICITY]
FROM NIELSENDATASTORE.dbo.NIELSEN_TV_UNIVERSE
WHERE NIELSEN_TV_UNIVERSE_ID NOT IN (SELECT NIELSEN_TV_UNIVERSE_ID FROM NIELSENHOSTED.dbo.NIELSEN_TV_UNIVERSE)

SET IDENTITY_INSERT NIELSENHOSTED.dbo.NIELSEN_TV_UNIVERSE OFF

COMMIT TRAN

GO
