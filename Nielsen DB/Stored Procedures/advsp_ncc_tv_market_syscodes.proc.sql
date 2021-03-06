CREATE PROCEDURE advsp_ncc_tv_market_syscodes
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
	@NIELSEN_MARKET_NUM IS NULL
OR 
	(@NIELSEN_MARKET_NUM IS NOT NULL AND NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM)
ORDER BY 3,2
GO

GRANT EXEC ON advsp_ncc_tv_market_syscodes TO PUBLIC
GO