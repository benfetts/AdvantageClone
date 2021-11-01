CREATE FUNCTION [dbo].[advfn_get_media_traffic_document_list](
	@MEDIA_TRAFFIC_DETAIL_ID int
) RETURNS varchar(max)
AS
BEGIN

declare @Documents varchar(MAX); 

select @Documents = COALESCE(@Documents + ',', '') + CAST(D.[FILENAME] as varchar)
FROM dbo.MEDIA_TRAFFIC_DETAIL_DOCUMENT MTDD
	INNER JOIN dbo.DOCUMENTS D ON MTDD.DOCUMENT_ID = D.DOCUMENT_ID AND MTDD.MEDIA_TRAFFIC_DETAIL_ID = @MEDIA_TRAFFIC_DETAIL_ID

RETURN @Documents
END
