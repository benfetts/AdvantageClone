IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_api_get_tv_audience]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_api_get_tv_audience]
GO

CREATE PROC [dbo].[advsp_api_get_tv_audience]
	@book_id bigint,
	@audience_id bigint
AS

select
	ID = NIELSEN_TV_AUDIENCE_ID,
	NielsenTVBookID = NIELSEN_TV_BOOK_ID,
	StationCode = STATION_CODE,
	AudienceDatetime = AUDIENCE_DATETIME,
	IsExcluded = IS_EXCLUDED,
	MetroAHousehold = METROA_HOUSEHOLD_AUD,
	MetroBHousehold = METROB_HOUSEHOLD_AUD,
	Household = HOUSEHOLD_AUD,
	Children2to5 = CHILDREN_2TO5_AUD,
	Children6to11 = CHILDREN_6TO11_AUD,
	Males12to14 = MALES_12TO14_AUD,
	Males15to17 = MALES_15TO17_AUD,
	Males18to20 = MALES_18TO20_AUD,
	Males21to24 = MALES_21TO24_AUD,
	Males25to34 = MALES_25TO34_AUD,
	Males35to49 = MALES_35TO49_AUD,
	Males50to54 = MALES_50TO54_AUD,
	Males55to64 = MALES_55TO64_AUD,
	Males65Plus = MALES_65PLUS_AUD,
	Females12to14 = FEMALES_12TO14_AUD,
	Females15to17 = FEMALES_15TO17_AUD,
	Females18to20 = FEMALES_18TO20_AUD,
	Females21to24 = FEMALES_21TO24_AUD,
	Females25to34 = FEMALES_25TO34_AUD,
	Females35to49 = FEMALES_35TO49_AUD,
	Females50to54 = FEMALES_50TO54_AUD,
	Females55to64 = FEMALES_55TO64_AUD,
	Females65Plus = FEMALES_65PLUS_AUD,
	WorkingWomen = WORKING_WOMEN_AUD
from dbo.NIELSEN_TV_AUDIENCE with (INDEX(NIELSEN_TV_AUDIENCE_UNIQUE))
where NIELSEN_TV_BOOK_ID = @book_id
AND NIELSEN_TV_AUDIENCE_ID > @audience_id
ORDER BY NIELSEN_TV_AUDIENCE_ID
GO

GRANT EXEC ON [advsp_api_get_tv_audience] TO PUBLIC
GO