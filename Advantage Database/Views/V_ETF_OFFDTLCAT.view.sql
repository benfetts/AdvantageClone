CREATE VIEW [dbo].[V_ETF_OFFDTLCAT]

AS

	SELECT 
		[EmployeeTimeForecastID] = OFFDTLCAT.ETF_ID,
		[EmployeeTimeForecastOfficeDetailID] = OFFDTLCAT.ETF_OFFDTL_ID,
		[EmployeeTimeForecastOfficeDetailIndirectCategoryID] = OFFDTLCAT.ETF_OFFDTLCAT_ID,
		[IndirectCategoryCode] = OFFDTLCAT.CATEGORY,
		[IndirectCategory] = IC.[DESCRIPTION]
	FROM 
		dbo.ETF_OFFDTLCAT OFFDTLCAT INNER JOIN
		dbo.TIME_CATEGORY IC ON IC.CATEGORY = OFFDTLCAT.CATEGORY
		
GO