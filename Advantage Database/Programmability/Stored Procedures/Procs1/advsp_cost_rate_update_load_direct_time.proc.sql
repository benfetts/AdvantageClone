CREATE PROCEDURE [dbo].[advsp_cost_rate_update_load_direct_time] 
	@StartDate datetime, 
	@EndDate datetime,
	@EmployeeCode varchar(6)
AS
BEGIN
	
	SET NOCOUNT ON
	
	SELECT 
		[EmployeeTimeID] = ETD.ET_ID, 
		[EmployeeTimeDetailID] = ETD.ET_DTL_ID, 
		[EmployeeCode] = ET.EMP_CODE, 
		[Date] = ET.EMP_DATE,
		[Hours] = ETD.EMP_HOURS
	FROM 
		dbo.EMP_TIME_DTL AS ETD INNER JOIN 
		dbo.EMP_TIME AS ET ON ET.ET_ID = ETD.ET_ID
	WHERE 
		ET.EMP_DATE >= @StartDate AND 
		ET.EMP_DATE <= @EndDate AND
		1 = CASE WHEN ISNULL(@EmployeeCode, '') = '' THEN 1
				 ELSE CASE WHEN @EmployeeCode = ET.EMP_CODE THEN 1 ELSE 0 END END
	
END
GO