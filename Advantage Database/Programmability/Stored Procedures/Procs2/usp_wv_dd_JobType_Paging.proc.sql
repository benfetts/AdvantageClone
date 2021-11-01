if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dd_JobType_Paging]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dd_JobType_Paging]
GO

/****** Object:  StoredProcedure [dbo].[usp_wv_dd_JobType_Paging]    Script Date: 6/25/2019 2:06:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/*
	declare @totalRows int
	exec usp_wv_dd_JobType_Paging '','Bro',0,31,@TotalRows=@totalRows OUTPUT
	print @totalRows
*/

CREATE procedure [dbo].[usp_wv_dd_JobType_Paging](
			@SalesClassCode VARCHAR(6) = '',
			@Text varchar(100) = '',
			@Skip INT = 0,
			@Take INT = 0,
			@TotalRows int out
)
as 
	declare @StartRec int,
			@EndRec int

	if @Skip > 0
	BEGIN
		SET @StartRec = @SKIP;
		SET @EndRec = @SKIP + @TAKE - 1;
	END
	ELSE
	BEGIN
		SET @StartRec = @SKIP;
		SET @EndRec = @TAKE;
	END

	set @SalesClassCode = nullif(@SalesClassCode,'')

	set @TotalRows = (select count(*) from JOB_TYPE where 
		(INACTIVE_FLAG = 0 or INACTIVE_FLAG IS NULL) AND 
		(@SalesClassCode is null OR SC_CODE = @SalesClassCode or SC_CODE is null) AND 
		LOWER(JT_DESC) + ' (' + LOWER(JT_CODE) + ')' LIKE  '%' + REPLACE(LOWER(@Text),'''','''''') + '%' )

	;with cte  As
	(select JT_CODE Code, JT_DESC Name, ROW_NUMBER()  OVER (ORDER BY JOB_TYPE.JT_DESC) RowNumber from JOB_TYPE where 
		(INACTIVE_FLAG = 0 or INACTIVE_FLAG IS NULL) AND 
		(@SalesClassCode is null OR SC_CODE = @SalesClassCode  or SC_CODE is null) AND 
		LOWER(JT_DESC) + ' (' + LOWER(JT_CODE) + ')' LIKE  '%' + REPLACE(LOWER(@Text),'''','''''') + '%') 
	select Code, Name from cte where
			(RowNumber >= @StartRec and RowNumber <= @EndRec) or @Take = 0


GO



GRANT EXECUTE ON [dbo].[usp_wv_dd_JobType_Paging] TO PUBLIC
GO



		
