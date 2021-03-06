
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advfn_ar_max_check_number]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[advfn_ar_max_check_number]
GO

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[advfn_ar_max_check_number] (@invoice_number int, @check_date datetime)

-- ====================================================================================================      
-- Funtion to return the maximum check number for an AR invoice   
-- #00 12/20/14 - original
-- ====================================================================================================   
      
RETURNS varchar(50)

AS
BEGIN
	DECLARE @check_number varchar(50)

	SELECT 
		@check_number = MAX(c.CR_CHECK_NBR)
	FROM dbo.CR_CLIENT AS c
	JOIN dbo.CR_CLIENT_DTL AS d
		ON c.REC_ID = d.REC_ID
		AND c.SEQ_NBR = d.SEQ_NBR
	WHERE d.AR_INV_NBR = @invoice_number
		AND c.CR_CHECK_DATE = @check_date

	RETURN @check_number

END

GO



