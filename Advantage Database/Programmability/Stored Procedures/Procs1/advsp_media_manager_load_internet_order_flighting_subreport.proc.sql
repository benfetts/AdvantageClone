CREATE PROCEDURE [dbo].[advsp_media_manager_load_internet_order_flighting_subreport]
	@OrderNumber int,
	@PackageName varchar(60),
	@SizeCode varchar(6)
AS

--select *
--FROM dbo.INTERNET_PACKAGE_DETAIL 

--declare @OrderNumber int,
--		@PackageName varchar(60)

--set @OrderNumber = 737
--set @PackageName = 'Pkg Mike'

IF @PackageName IS NOT NULL BEGIN
	SELECT
		[StartDate] = [START_DATE],
		[EndDate] = END_DATE,
		[Units] = GUARANTEED_IMPRESS,
		[Rate] = COST_RATE,
		[Cost] = LINE_TOTAL
	FROM 
		--(SELECT DISTINCT ORDER_NBR, LINE_NBR, REV_NBR
		--FROM dbo.INTERNET_PACKAGE_DETAIL 
		--WHERE ORDER_NBR = @OrderNumber
		--) ipd
		dbo.INTERNET_DETAIL id --ON ipd.ORDER_NBR = id.ORDER_NBR AND ipd.LINE_NBR = id.LINE_NBR AND ipd.REV_NBR = id.REV_NBR AND id.ACTIVE_REV = 1
	WHERE
		id.ORDER_NBR = @OrderNumber 
	AND id.PLACEMENT_2 = @PackageName 
	AND id.ACTIVE_REV = 1
	ORDER BY 1
END ELSE BEGIN
	SELECT
		[StartDate] = [START_DATE],
		[EndDate] = END_DATE,
		[Units] = GUARANTEED_IMPRESS,
		[Rate] = COST_RATE,
		[Cost] = LINE_TOTAL
	FROM 
		(SELECT DISTINCT ORDER_NBR, LINE_NBR, REV_NBR, AD_SIZE_CODE
		FROM dbo.INTERNET_PACKAGE_DETAIL 
		WHERE ORDER_NBR = @OrderNumber
		) ipd
		INNER JOIN dbo.INTERNET_DETAIL id ON ipd.ORDER_NBR = id.ORDER_NBR AND ipd.LINE_NBR = id.LINE_NBR AND ipd.REV_NBR = id.REV_NBR AND id.ACTIVE_REV = 1 AND ipd.AD_SIZE_CODE = @SizeCode
	WHERE
		id.ORDER_NBR = @OrderNumber 
	AND NULLIF(id.PLACEMENT_2, '') IS NULL
	AND id.ACTIVE_REV = 1
	ORDER BY 1
END

