CREATE PROCEDURE [dbo].[advsp_comscore_tv_purge_cached_books]

AS

DELETE dbo.COMSCORE_CACHE_DETAIL 
WHERE COMSCORE_CACHE_HEADER_ID IN (
	SELECT COMSCORE_CACHE_HEADER_ID 
	FROM dbo.COMSCORE_CACHE_HEADER 
	WHERE DATEDIFF(DAY, LAST_ACCESSED, getdate()) > 90
)

DELETE dbo.COMSCORE_CACHE_HEADER 
WHERE DATEDIFF(DAY, LAST_ACCESSED, getdate()) > 90

GO
