CREATE PROCEDURE [dbo].[advsp_cost_rate_update_load_indirect_time] 
	@StartDate datetime, 
	@EndDate datetime,
	@EmployeeCode varchar(6)
AS
BEGIN
	
	SET NOCOUNT ON
	
	SELECT 
		[EmployeeTimeID] = ETN.ET_ID, 
		[EmployeeTimeDetailID] = ETN.ET_DTL_ID, 
		[EmployeeCode] = ET.EMP_CODE, 
		[Date] = ET.EMP_DATE,
		[Hours] = ETN.EMP_HOURS,
		[Category] = ETN.CATEGORY
	FROM 
		dbo.EMP_TIME_NP AS ETN INNER JOIN 
		dbo.EMP_TIME AS ET ON ET.ET_ID = ETN.ET_ID
	WHERE 
		EMP_DATE >= @StartDate AND 
		EMP_DATE <= @EndDate AND
		1 = CASE WHEN ISNULL(@EmployeeCode, '') = '' THEN 1
				 ELSE CASE WHEN @EmployeeCode = ET.EMP_CODE THEN 1 ELSE 0 END END
	
END
GO