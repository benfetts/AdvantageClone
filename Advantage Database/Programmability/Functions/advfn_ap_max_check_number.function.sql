
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advfn_ap_max_check_number]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[advfn_ap_max_check_number]
GO

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[advfn_ap_max_check_number] (@ap_id int, @check_date datetime)

-- ====================================================================================================      
-- Funtion to return the maximum check number for an AP invoice   
-- #00 12/18/14 - original
-- ====================================================================================================   
      
RETURNS varchar(50)

AS
BEGIN
	DECLARE @voucher_number varchar(50)

	SELECT 
		@voucher_number = MAX(p.AP_CHK_NBR)
	FROM dbo.AP_PMT_HIST AS p
	WHERE p.AP_ID = @ap_id
		AND p.AP_CHK_DATE = @check_date

	RETURN @voucher_number

END

GO



