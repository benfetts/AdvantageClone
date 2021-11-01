CREATE PROCEDURE [dbo].[advsp_media_manager_load_vendor_collected_details]
	@OrderNumberLineNumbers varchar(max)
AS

BEGIN

	SELECT
		MediaType = h.MEDIA_TYPE,
		OrderNumber = cci.ORDER_NBR,
		LineNumber = cci.LINE_NBR,
		RevisionNumber = cci.REV_NBR,
		IsQuote = cci.IS_QUOTE,
		OrderDescription = h.ORDER_DESC,
		--QTY (column Not In table yet)
		--Rate (column Not In table yet)
		GrossAmount = cci.GROSS_AMT,
		CommissionPercent = cci.COMISSION_PCT,
		NetAmount = cci.NET_AMOUNT,
		Notes = cci.NOTES,
		AuthorizedBy = cci.AUTHORIZED_BY,
		AuthorizedByName = cci.AUTHORIZED_BY_NAME,
		CreatedDate = cci.CREATED_DATE,
		ModifiedDate = cci.MODIFIED_DATE,
		Comments = cci.COMMENTS,
		ID = cci.COLLECTED_COST_INFO_ID
	FROM dbo.COLLECTED_COST_INFO cci
		LEFT OUTER JOIN (
						SELECT ORDER_DESC, ORDER_NBR, 'Internet' AS MEDIA_TYPE FROM dbo.INTERNET_HEADER
						UNION
						SELECT ORDER_DESC, ORDER_NBR, 'Magazine' AS MEDIA_TYPE FROM dbo.MAGAZINE_HEADER
						UNION
						SELECT ORDER_DESC, ORDER_NBR, 'Newspaper' AS MEDIA_TYPE FROM dbo.NEWSPAPER_HEADER
						UNION
						SELECT ORDER_DESC, ORDER_NBR, 'Out of Home' AS MEDIA_TYPE FROM dbo.OUTDOOR_HEADER
						UNION
						SELECT ORDER_DESC, ORDER_NBR, 'Radio' AS MEDIA_TYPE FROM dbo.RADIO_HDR
						UNION
						SELECT ORDER_DESC, ORDER_NBR, 'TV' AS MEDIA_TYPE FROM dbo.TV_HDR
						) h ON cci.ORDER_NBR = h.ORDER_NBR 
	WHERE
		 CAST(cci.ORDER_NBR AS varchar(20)) + '|' + CAST(cci.LINE_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@OrderNumberLineNumbers, ','))
		
END
GO