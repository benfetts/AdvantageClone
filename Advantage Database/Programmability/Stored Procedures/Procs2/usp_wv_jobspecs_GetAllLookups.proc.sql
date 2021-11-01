

CREATE PROCEDURE [dbo].[usp_wv_jobspecs_GetAllLookups]
	--@JOB_NUMBER INT,
    --@JOB_COMPONENT_NBR INT
AS


/* Unioned all lookups relating to job specs*/

	SELECT 
		DISTINCT STATUS_CODE AS code,
		ISNULL(STATUS_DESC, '') AS [description],
		'Status' AS ItemCode,
		'Status Code' AS SHORT_DESC
	FROM
		STATUS
	WHERE
		ACTIVE = 1 OR ACTIVE IS NULL
UNION
	SELECT
		DISTINCT REGION_CODE AS code,
		ISNULL(REGION_DESC, '') AS [description],
		'Region' AS ItemCode,
		'Region Code' AS SHORT_DESC
	FROM
		REGION
	WHERE
		(ACTIVE = 1 OR ACTIVE IS NULL)
UNION
	SELECT 
		DISTINCT VN_CODE AS code,
		ISNULL(VN_NAME, '') AS [description],
		'Vendor' AS ItemCode,
		'Vendor' AS SHORT_DESC
	FROM
		VENDOR
	WHERE
		(VN_ACTIVE_FLAG = 1 OR VN_ACTIVE_FLAG IS NULL)
UNION
	SELECT 
		DISTINCT SIZE_CODE AS code,
		ISNULL(SIZE_DESC, '') AS [description],
		'AdSize' AS ItemCode,
		'AdSize' AS SHORT_DESC
	FROM
		AD_SIZE
	WHERE
		(INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL)

	

