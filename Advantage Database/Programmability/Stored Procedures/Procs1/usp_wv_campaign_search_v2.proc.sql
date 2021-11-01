if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_campaign_search_v2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_campaign_search_v2]
GO

/****** Object:  StoredProcedure [dbo].[usp_wv_campaign_search_v2]    Script Date: 6/12/2019 10:15:56 AM ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO





/***************************************************************************************
 declare @totalRows int
 exec usp_wv_campaign_search_v2 'lpathmann','','','','','',0,null,null,0,15,@TotalRows=@totalRows OUTPUT
 print @totalRows

****************************************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_campaign_search_v2] 
    @UserID			VARCHAR(100),
    @OfficeCode		VARCHAR(4),
    @ClientCode		VARCHAR(6),
    @DivisionCode	VARCHAR(6),
    @ProductCode	VARCHAR(6),
	@CmpCode		VARCHAR(6),
	@InclClosed		INTEGER,
	@FromDate		DATE = null,
	@ToDate			DATE = null,
	@skip int = 0,
	@take int = 0,
	@TotalRows int out

AS
	If @OfficeCode IS NULL 
		set @OfficeCode = ''
	If @ClientCode IS NULL 
		set @ClientCode = ''	
	If	@DivisionCode IS NULL 
		set @DivisionCode = '' 	
	If	@ProductCode  IS NULL 
		set @ProductCode = ''
	If	@CmpCode  IS NULL 
		set @CmpCode = ''

	DECLARE @Restrictions 	Int
	DECLARE		@sql 		nvarchar(4000),
				@sql_from 	nvarchar(4000),
				@sql_where 	nvarchar(4000),
				@InclClosedStr varchar(1),
				@paramlist nvarchar(4000),
				@start_rec int = 0,
				@end_rec int = 0

	DECLARE @EMP_CODE AS VARCHAR(6)
	DECLARE @COUNT AS INTEGER

	if @SKIP > 0
	BEGIN
		SET @START_REC = @SKIP + 1;
		SET @END_REC = @SKIP + @TAKE ;
	END
	ELSE
	BEGIN
		SET @START_REC = @SKIP;
		SET @END_REC = @TAKE;
	END

	SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)
	print @EMP_CODE
	SELECT @COUNT = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

	if @InclClosed IS NULL Or @InclClosed = 0
		set @InclClosedStr = '0'
	Else
		set @InclClosedStr = '1'

	set @Restrictions = 0
	--If @DivisionCode <> '' And @ProductCode <> ''
		Select @Restrictions = Count(*) 
		FROM SEC_CLIENT
		WHERE UPPER(USER_ID) = UPPER(@UserID)


	SET @sql = ';WITH DataCTE AS ( SELECT 
					Code,
					Name,
					ClientCode,
					DivisionCode,
					DivisionName,
					ProductCode,
					ID,
					StartDate,
					EndDate,
					ClientName,
					OfficeCode,
					OfficeName,
					ROW_NUMBER() OVER (ORDER BY CMP_IDENTIFIER DESC) AS RowNumber
					'
	SET @sql_from = ' FROM (SELECT DISTINCT CMP_CODE Code,
						CMP_NAME Name,
						CAMPAIGN.CL_CODE ClientCode,
						CAMPAIGN.DIV_CODE DivisionCode,
						DIVISION.DIV_NAME DivisionName,
						CAMPAIGN.PRD_CODE ProductCode,
						CMP_IDENTIFIER ID,
						CMP_BEG_DATE StartDate,
						CMP_END_DATE EndDate,
						CLIENT.CL_NAME ClientName,
						CAMPAIGN.OFFICE_CODE OfficeCode,
						OFFICE.OFFICE_NAME OfficeName, 
						CMP_IDENTIFIER
						FROM CAMPAIGN 
					LEFT JOIN OFFICE on OFFICE.OFFICE_CODE = CAMPAIGN.OFFICE_CODE 
					LEFT JOIN CLIENT on CLIENT.CL_CODE = CAMPAIGN.CL_CODE
					LEFT JOIN DIVISION ON DIVISION.DIV_CODE = CAMPAIGN.DIV_CODE AND DIVISION.CL_CODE = CAMPAIGN.CL_CODE
					'

	If @COUNT > 0
		SET @sql_from = @sql_from + 'LEFT JOIN PRODUCT ON CAMPAIGN.CL_CODE = PRODUCT.CL_CODE AND ( CAMPAIGN.DIV_CODE = PRODUCT.DIV_CODE OR CAMPAIGN.DIV_CODE IS NULL )	AND ( CAMPAIGN.PRD_CODE = PRODUCT.PRD_CODE OR CAMPAIGN.PRD_CODE IS NULL )
									 INNER JOIN EMP_OFFICE ON PRODUCT.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE	AND EMP_OFFICE.EMP_CODE = @EMP_CODE
		'
	else 
		set @sql_from = @sql_from + 'LEFT JOIN PRODUCT ON CAMPAIGN.CL_CODE = PRODUCT.CL_CODE AND CAMPAIGN.DIV_CODE = PRODUCT.DIV_CODE AND CAMPAIGN.PRD_CODE = PRODUCT.PRD_CODE
		'

	SET @sql_where = ' WHERE 1=1 '

	if @Restrictions > 0	
		Begin
		  SET @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON CAMPAIGN.CL_CODE = SEC_CLIENT.CL_CODE 
							AND ( CAMPAIGN.DIV_CODE = SEC_CLIENT.DIV_CODE OR CAMPAIGN.DIV_CODE IS NULL )
							AND ( CAMPAIGN.PRD_CODE = SEC_CLIENT.PRD_CODE OR CAMPAIGN.PRD_CODE IS NULL )'
	  		 
		  SET @sql_where = @sql_where + ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
		End

	If @OfficeCode  <> ''
		SET @sql_where = @sql_where + ' AND CAMPAIGN.OFFICE_CODE = @OfficeCode '

	If @ClientCode  <> ''
		SET @sql_where = @sql_where + ' AND CAMPAIGN.CL_CODE = @ClientCode '

	If @DivisionCode <> ''
		SET @sql_where = @sql_where + ' AND CAMPAIGN.DIV_CODE = @DivisionCode '

	If @ProductCode  <> ''
		SET @sql_where = @sql_where + ' AND CAMPAIGN.PRD_CODE = @ProductCode '
	
	If @CmpCode  <> ''
		SET @sql_where = @sql_where + ' AND CAMPAIGN.CMP_CODE = @CmpCode '
	
	If @InclClosedStr = '0' 
		SET @sql_where = @sql_where + ' AND (CAMPAIGN.CMP_CLOSED = 0 OR CAMPAIGN.CMP_CLOSED IS NULL) '

	IF @FromDate is not null and @ToDate is not null
		SET @sql_where = @sql_where + ' AND CMP_BEG_DATE BETWEEN @FromDate AND @ToDate '

	IF @FromDate is null and @ToDate is not null
		SET @sql_where = @sql_where + ' AND CMP_BEG_DATE BETWEEN ''1900-01-01'' AND @ToDate '

	IF @FromDate is not null and @ToDate is null
		SET @sql_where = @sql_where + ' AND CMP_BEG_DATE BETWEEN @FromDate AND ''2079-06-06'''


	SET @sql = @sql + @sql_from + @sql_where

	SET @sql = @sql + ') a)					SELECT DISTINCT
		 Code,Name,ClientCode,DivisionCode,DivisionName,ProductCode,ID,StartDate,EndDate,ClientName,OfficeCode,OfficeName, (Select count(RowNumber) from DataCTE) as Totalrows FROM DataCTE
					WHERE 
						RowNumber BETWEEN @START_REC AND @END_REC
					'

	--set @sql = @sql + ' ORDER BY CMP_IDENTIFIER DESC'

	PRINT(@sql)
	--EXEC(@sql)

	create table #temp(
		Code varchar(6) null,
		Name varchar(128) null,
		ClientCode varchar(6)  COLLATE SQL_Latin1_General_CP1_CS_AS null,
		DivisionCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS null,
		DivisionName varchar(40) null,
		ProductCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS null,
		ID int null,
		StartDate DateTime null,
		EndDate dateTime null,
		ClientName varchar(40) null,
		OfficeCode varchar(6) null,
		OfficeName varchar(40) null,
		--ProductName varchar(40) null,
		TotalRows int null
	)

	SET @paramlist = '@UserID VarChar(100),@OfficeCode VarChar(6),@ClientCode VarChar(6),@DivisionCode VarChar(6),@ProductCode Varchar(6),@CmpCode Varchar(6),@FromDate datetime, @ToDate datetime,@EMP_CODE AS VARCHAR(6),@START_REC Int,@END_REC int'
	insert into #temp EXEC sp_executesql @sql, @paramlist, @UserID, @OfficeCode, @ClientCode, @DivisionCode, @ProductCode, @CmpCode, @FromDate, @ToDate, @EMP_CODE, @START_REC, @END_REC

	select top 1 @TotalRows = TotalRows from #temp

	select DISTINCT Code,
		Name,
		ClientCode,
		DivisionCode,
		DivisionName,
		ProductCode,
		ID,
		StartDate,
		EndDate,
		ClientName,
		OfficeCode,
		OfficeName,
		PRODUCT.PRD_DESCRIPTION ProductName 
			 from #temp
			 LEFT JOIN PRODUCT on #temp.ClientCode = PRODUCT.CL_CODE AND ( #temp.DivisionCode = PRODUCT.DIV_CODE)	AND ( #temp.ProductCode = PRODUCT.PRD_CODE)
			 order by ID DESC

	drop table #temp


GO


GRANT EXECUTE ON [dbo].[usp_wv_campaign_search_v2] TO PUBLIC
GO


