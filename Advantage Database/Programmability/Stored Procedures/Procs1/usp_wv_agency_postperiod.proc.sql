﻿

























CREATE PROCEDURE [dbo].[usp_wv_agency_postperiod] 
@PostPeriod as integer OUTPUT
AS

SELECT @PostPeriod = TS_PPERIOD_CHK FROM AGENCY

























