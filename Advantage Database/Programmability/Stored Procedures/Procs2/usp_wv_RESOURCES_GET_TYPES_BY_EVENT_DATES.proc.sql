
CREATE PROCEDURE [dbo].[usp_wv_RESOURCES_GET_TYPES_BY_EVENT_DATES] /*WITH ENCRYPTION*/
@START_DATE SMALLDATETIME,
@END_DATE SMALLDATETIME
AS
/*=========== QUERY ===========*/
	SET @START_DATE = CONVERT(
			DATETIME,
			CONVERT(CHAR(10), DATEPART(yyyy, @START_DATE), 101) 
			+
			'-' +
			CONVERT(CHAR(10), DATEPART(mm, @START_DATE), 101) +
			'-' +
			CONVERT(CHAR(10), DATEPART(dd, @START_DATE), 101) +
			' 00:00:00'
		);
	
	SET @END_DATE = CONVERT(
			DATETIME,
			CONVERT(CHAR(10), DATEPART(yyyy, @END_DATE), 101) 
			+
			'-' +
			CONVERT(CHAR(10), DATEPART(mm, @END_DATE), 101) +
			'-' +
			CONVERT(CHAR(10), DATEPART(dd, @END_DATE), 101) +
			' 23:59:00'
		);


	--DECLARE @REC_COUNT INT

	--SELECT     @REC_COUNT = COUNT(1)
	--FROM         RESOURCE_TYPE INNER JOIN
	--					  RESOURCE ON RESOURCE_TYPE.RESOURCE_TYPE_CODE = RESOURCE.RESOURCE_TYPE_CODE INNER JOIN
	--					  EVENT ON RESOURCE.RESOURCE_CODE = EVENT.RESOURCE_CODE
	--WHERE EVENT.EVENT_DATE BETWEEN @START_DATE AND @END_DATE;

	--SET @REC_COUNT = ISNULL(@REC_COUNT,0);

	--IF @REC_COUNT > 0 
	--	BEGIN
	--		SELECT     DISTINCT RESOURCE_TYPE.RESOURCE_TYPE_CODE, RESOURCE_TYPE.RESOURCE_TYPE_DESC
	--		FROM         RESOURCE_TYPE INNER JOIN
	--							  RESOURCE ON RESOURCE_TYPE.RESOURCE_TYPE_CODE = RESOURCE.RESOURCE_TYPE_CODE INNER JOIN
	--							  EVENT ON RESOURCE.RESOURCE_CODE = EVENT.RESOURCE_CODE
	--		WHERE EVENT.EVENT_DATE BETWEEN @START_DATE AND @END_DATE                     
	--		ORDER BY RESOURCE_TYPE.RESOURCE_TYPE_CODE;
	--	END
	--ELSE
	--	BEGIN
			SELECT     DISTINCT RESOURCE_TYPE.RESOURCE_TYPE_CODE, RESOURCE_TYPE.RESOURCE_TYPE_DESC
			FROM         RESOURCE_TYPE WHERE INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0
			ORDER BY RESOURCE_TYPE.RESOURCE_TYPE_CODE;
		--END


/*=========== QUERY ===========*/
