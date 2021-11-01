IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_hosted_ncc_tv_market_syscodes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_hosted_ncc_tv_market_syscodes]
GO

CREATE PROCEDURE advsp_hosted_ncc_tv_market_syscodes
	@CLIENT_CODE varchar(6),
	@NIELSEN_MARKET_NUM int
AS

SELECT
	[ID] = b.NCC_TV_SYSCODE_ID,
	[Syscode] = b.SYSCODE,
	[Provider] = a.MVPD,
	[SystemName] = b.SYSTEM_NAME,
	[Description] = CAST(b.SYSCODE as varchar) + ' - ' + b.SYSTEM_NAME
FROM [dbo].[NCC_TV_SYSCODE] b
	INNER JOIN [NCC_TV_MVPD] a on b.NCC_TV_MVPD_ID = a.NCC_TV_MVPD_ID 
WHERE
	1 = (SELECT 1 FROM [dbo].[CLIENT] WHERE CODE = @CLIENT_CODE AND IS_NCC_SUBSCRIBED = 1)
AND
	(
		@NIELSEN_MARKET_NUM IS NULL
	OR 
		(@NIELSEN_MARKET_NUM IS NOT NULL AND NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM)
	)
ORDER BY 3,2
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[advsp_hosted_ncc_tv_market_syscodes] TO PUBLIC;
GO

