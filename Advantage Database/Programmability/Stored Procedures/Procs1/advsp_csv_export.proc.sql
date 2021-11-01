
-- Version 5

CREATE PROCEDURE [dbo].[advsp_csv_export]
	@vendor_data			bit,												-- 0 = exclude, 1 = include 
	@tv_order_data			bit,												-- 0 = exclude, 1 = include
	@rad_order_data			bit,												-- 0 = exclude, 1 = include
	@news_order_data		bit,												-- 0 = exclude, 1 = include
	@ooh_order_data			bit,												-- 0 = exclude, 1 = include
	@mag_order_data			bit,												-- 0 = exclude, 1 = include
	@inet_order_data		bit,												-- 0 = exclude, 1 = include
	@prod_po_data			bit,												-- 0 = exclude, 1 = include
	@acct_pay_data			bit,												-- 0 = exclude, 1 = include
	@ap_pmt_hist_data		bit,												-- 0 = exclude, 1 = include
	@job_data				bit,												-- 0 = exclude, 1 = include
	@vn_category_in			varchar(20),										-- comma separated list of vendor types (nullable)
	@cli_list				varchar(2000),										-- comma separated list of client codes with null campaigns (nullable)
	@cmp_list				varchar(2000),										-- comma separated list of campaign identifiers (nullable)
	@create_date_start		smalldatetime,										-- pass date in 'yyyy-mm-dd' format; optional
	@create_date_end		smalldatetime, 										-- pass date in 'yyyy-mm-dd' format; optional
	@modified_date_start	smalldatetime,										-- pass date in 'yyyy-mm-dd' format; optional
	@modified_date_end		smalldatetime, 										-- pass date in 'yyyy-mm-dd' format; optional
	@inc_col_titles			bit,												-- column titles; 0 = exclude, 1 = include
	@ret_val				integer OUTPUT 
AS

SET NOCOUNT ON

-- Create tables to use lists of data that can be shared between export table group (clients, campaigns, orders, etc.)
CREATE TABLE #csv_output ( 
	csv_row_id		integer NOT NULL, 
	is_title		bit, 
	tablename		varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	csv_row_data	text COLLATE SQL_Latin1_General_CP1_CS_AS 
)

ALTER TABLE #csv_output ADD CONSTRAINT pk_csv_output PRIMARY KEY ( csv_row_id, tablename )

CREATE TABLE #cli_list ( CL_CODE varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS PRIMARY KEY )
CREATE TABLE #cmp_list ( CMP_ID integer PRIMARY KEY )
CREATE TABLE #order_list ( ORDER_NBR integer NOT NULL PRIMARY KEY )
CREATE TABLE #order_line_list ( ORDER_NBR integer NOT NULL, LINE_NBR integer NOT NULL, REV_NBR integer NOT NULL, SEQ_NBR integer NOT NULL )
CREATE TABLE #order_bcast_list ( ORDER_NBR integer NOT NULL, REV_NBR integer NOT NULL ) 
CREATE TABLE #po_list ( PO_NUMBER integer NOT NULL PRIMARY KEY )
CREATE TABLE #po_list_2 ( PO_NUMBER integer NOT NULL PRIMARY KEY )
CREATE TABLE #job_list ( JOB_NUMBER integer NOT NULL PRIMARY KEY )
CREATE TABLE #comp_list ( JOB_NUMBER integer NOT NULL, JOB_COMPONENT_NBR integer NOT NULL )
CREATE TABLE #ap_list ( AP_ID integer NOT NULL, AP_SEQ smallint NOT NULL )
CREATE TABLE #ap_list_2 ( AP_ID integer NOT NULL, AP_SEQ smallint NOT NULL )
CREATE TABLE #ap_check ( CHECK_NBR integer NOT NULL, CHECK_SEQ smallint NOT NULL )
CREATE TABLE #ap_check_2 ( CHECK_NBR integer NOT NULL, CHECK_SEQ smallint NOT NULL )

DECLARE @sql_where varchar(1000)
DECLARE @cnt bigint

IF ( @cli_list IS NOT NULL )
	INSERT INTO #cli_list( CL_CODE ) SELECT vstr FROM dbo.fn_charlist_to_table2( @cli_list )

IF ( @cmp_list IS NOT NULL )	
	INSERT INTO #cmp_list( CMP_ID ) SELECT [number] FROM dbo.fn_intlist_to_table( @cmp_list )

IF ( @vendor_data = 1 )
BEGIN
	-- [VENDOR]
	SET @sql_where = ''
	IF ( @vn_category_in > '' )
		SET @sql_where = 'WHERE CHARINDEX( UPPER( VN_CATEGORY ), ''' + @vn_category_in + ''' ) > 0'
		
	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'VENDOR', @inc_col_titles, @sql_where, @ret_val OUTPUT
END


IF ( @tv_order_data = 1 )
BEGIN
	-- [TV_HEADER] 
	SET @sql_where = ''
	IF ( @create_date_start > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND CREATE_DATE >= ''' + CONVERT( varchar(10), @create_date_start, 101 ) + ''' ' 

	IF ( @create_date_end > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND CREATE_DATE <= ''' + CONVERT( varchar(10), @create_date_end, 101 ) + ''' '
	
	-- Updated to support the list of clients with null campaigns
		
	--IF ( @cli_list IS NOT NULL )
	--BEGIN
	--	SET @sql_where = @sql_where + 'AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ) '
	--END
		
	--IF ( @cmp_list IS NOT NULL )	
	--BEGIN
	--	SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) '
	--END	
			
	IF ( @cmp_list IS NOT NULL )	
	BEGIN
		IF ( @cli_list IS NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) '
		END
		
		IF ( @cli_list IS NOT NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND ( CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) OR ( CMP_IDENTIFIER IS NULL AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ))) '
		END
	END

	IF ( @cmp_list IS NULL )
	BEGIN
		IF ( @cli_list IS NOT NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IS NULL AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ) '
		END	
	END

	IF ( @sql_where <> '' )
		SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )
		
	INSERT INTO #order_bcast_list ( ORDER_NBR, REV_NBR ) 
		EXECUTE ( 'SELECT DISTINCT ORDER_NBR, REV_NBR FROM dbo.TV_HEADER ' + @sql_where )

	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'TV_HEADER', @inc_col_titles, @sql_where, @ret_val OUTPUT

	-- [TV_DETAIL1]
	SET @sql_where = ''
	SET @sql_where = 'WHERE ORDER_NBR IN ( SELECT DISTINCT ORDER_NBR FROM #order_bcast_list ) ' + @sql_where
	
	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'TV_DETAIL1', @inc_col_titles, @sql_where, @ret_val OUTPUT

	-- [TV_DETAIL2]
	SET @sql_where = ''
	SET @sql_where = 'WHERE ORDER_NBR IN ( SELECT DISTINCT ORDER_NBR FROM #order_bcast_list ) ' + @sql_where
	
	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'TV_DETAIL2', @inc_col_titles, @sql_where, @ret_val OUTPUT
	
END


IF ( @rad_order_data = 1 )
BEGIN
	-- [RADIO_HEADER]
	SET @sql_where = ''
	IF ( @create_date_start > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND CREATE_DATE >= ''' + CONVERT( varchar(10), @create_date_start, 101 ) + ''' ' 

	IF ( @create_date_end > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND CREATE_DATE <= ''' + CONVERT( varchar(10), @create_date_end, 101 ) + ''' '
		
	-- Updated to support the list of clients with null campaigns
		
	--IF ( @cli_list IS NOT NULL )
	--BEGIN
	--	SET @sql_where = @sql_where + 'AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ) '
	--END
		
	--IF ( @cmp_list IS NOT NULL )	
	--BEGIN
	--	SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) '
	--END

	IF ( @cmp_list IS NOT NULL )	
	BEGIN
		IF ( @cli_list IS NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) '
		END
		
		IF ( @cli_list IS NOT NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND ( CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) OR ( CMP_IDENTIFIER IS NULL AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ))) '
		END
	END

	IF ( @cmp_list IS NULL )
	BEGIN
		IF ( @cli_list IS NOT NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IS NULL AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ) '
		END	
	END

	IF ( @sql_where <> '' )
		SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )
		
	INSERT INTO #order_bcast_list ( ORDER_NBR, REV_NBR ) 
		EXECUTE ( 'SELECT DISTINCT ORDER_NBR, REV_NBR FROM dbo.RADIO_HEADER ' + @sql_where )

	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'RADIO_HEADER', @inc_col_titles, @sql_where, @ret_val OUTPUT

	-- [RADIO_DETAIL1]
	SET @sql_where = ''
	SET @sql_where = 'WHERE ORDER_NBR IN ( SELECT DISTINCT ORDER_NBR FROM #order_bcast_list ) ' + @sql_where
	
	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'RADIO_DETAIL1', @inc_col_titles, @sql_where, @ret_val OUTPUT

	-- [RADIO_DETAIL2]
	SET @sql_where = ''
	SET @sql_where = 'WHERE ORDER_NBR IN ( SELECT DISTINCT ORDER_NBR FROM #order_bcast_list ) ' + @sql_where
	
	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'RADIO_DETAIL2', @inc_col_titles, @sql_where, @ret_val OUTPUT
	
END


IF ( @news_order_data = 1 )
BEGIN
	-- [NEWSPAPER_HEADER]
	SET @sql_where = ''
	IF ( @create_date_start > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND CREATE_DATE >= ''' + CONVERT( varchar(10), @create_date_start, 101 ) + ''' ' 

	IF ( @create_date_end > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND CREATE_DATE <= ''' + CONVERT( varchar(10), @create_date_end, 101 ) + ''' '
		
	--IF ( @modified_date_start > '1900-01-01' )
	--	SET @sql_where = @sql_where + 'AND MODIFIED_DATE >= ''' + CONVERT( varchar(10), @modified_date_start, 101 ) + ''' '

	--IF ( @modified_date_end > '1900-01-01' )
	--	SET @sql_where = @sql_where + 'AND MODIFIED_DATE <= ''' + CONVERT( varchar(10), @modified_date_end, 101 ) + ''' '
	
	IF ( @modified_date_start > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND ((MODIFIED_DATE IS NULL) OR (MODIFIED_DATE >= ''' + CONVERT( varchar(10), @modified_date_start, 101 ) + ''')) '

	IF ( @modified_date_end > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND ((MODIFIED_DATE IS NULL) OR (MODIFIED_DATE <= ''' + CONVERT( varchar(10), @modified_date_end, 101 ) + ''')) '
		
	-- Updated to support the list of clients with null campaigns	
		
	--IF ( @cli_list IS NOT NULL )
	--	SET @sql_where = @sql_where + 'AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ) '
		
	--IF ( @cmp_list IS NOT NULL )	
	--	SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) '

	IF ( @cmp_list IS NOT NULL )	
	BEGIN
		IF ( @cli_list IS NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) '
		END
		
		IF ( @cli_list IS NOT NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND ( CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) OR ( CMP_IDENTIFIER IS NULL AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ))) '
		END
	END

	IF ( @cmp_list IS NULL )
	BEGIN
		IF ( @cli_list IS NOT NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IS NULL AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ) '
		END	
	END

	IF ( @sql_where <> '' )
		SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )
		
	INSERT INTO #order_list ( ORDER_NBR ) 
		EXECUTE ( 'SELECT DISTINCT ORDER_NBR FROM dbo.NEWSPAPER_HEADER ' + @sql_where )
			
	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)			
		EXECUTE dbo.advsp_csv_table_dump 'NEWSPAPER_HEADER', @inc_col_titles, @sql_where, @ret_val OUTPUT
		
	-- [NEWSPAPER_DETAIL]
	SET @sql_where = ''
	--IF ( @modified_date_start > '1900-01-01' )
	--	SET @sql_where = @sql_where + 'AND MODIFIED_DATE >= ''' + CONVERT( varchar(10), @modified_date_start, 101 ) + ''' '

	--IF ( @modified_date_end > '1900-01-01' )
	--	SET @sql_where = @sql_where + 'AND MODIFIED_DATE <= ''' + CONVERT( varchar(10), @modified_date_end, 101 ) + ''' '
				
	IF ( @modified_date_start > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND ((MODIFIED_DATE IS NULL) OR (MODIFIED_DATE >= ''' + CONVERT( varchar(10), @modified_date_start, 101 ) + ''')) '

	IF ( @modified_date_end > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND ((MODIFIED_DATE IS NULL) OR (MODIFIED_DATE <= ''' + CONVERT( varchar(10), @modified_date_end, 101 ) + ''')) '
		
	SET @sql_where = 'WHERE ORDER_NBR IN ( SELECT ORDER_NBR FROM #order_list ) ' + @sql_where		
	
	INSERT INTO #order_line_list ( ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR ) 
		EXECUTE ( 'SELECT DISTINCT ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR FROM dbo.NEWSPAPER_DETAIL ' + @sql_where )

	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'NEWSPAPER_DETAIL', @inc_col_titles, @sql_where, @ret_val OUTPUT

	-- [NEWSPAPER_COMMENTS]
	SET @sql_where = ''
	SET @sql_where = @sql_where + 'WHERE EXISTS ( SELECT * FROM #order_line_list WHERE NEWSPAPER_COMMENTS.ORDER_NBR = #order_line_list.ORDER_NBR '
	SET @sql_where = @sql_where + '					 AND NEWSPAPER_COMMENTS.LINE_NBR = #order_line_list.LINE_NBR ) '
	
	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'NEWSPAPER_COMMENTS', @inc_col_titles, @sql_where, @ret_val OUTPUT

END


IF ( @ooh_order_data = 1 )
BEGIN
	-- [OUTDOOR_HEADER]
	SET @sql_where = ''
	IF ( @create_date_start > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND CREATE_DATE >= ''' + CONVERT( varchar(10), @create_date_start, 101 ) + ''' ' 

	IF ( @create_date_end > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND CREATE_DATE <= ''' + CONVERT( varchar(10), @create_date_end, 101 ) + ''' '
		
	--IF ( @modified_date_start > '1900-01-01' )
	--	SET @sql_where = @sql_where + 'AND MODIFIED_DATE >= ''' + CONVERT( varchar(10), @modified_date_start, 101 ) + ''' '

	--IF ( @modified_date_end > '1900-01-01' )
	--	SET @sql_where = @sql_where + 'AND MODIFIED_DATE <= ''' + CONVERT( varchar(10), @modified_date_end, 101 ) + ''' '
		
	IF ( @modified_date_start > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND ((MODIFIED_DATE IS NULL) OR (MODIFIED_DATE >= ''' + CONVERT( varchar(10), @modified_date_start, 101 ) + ''')) '

	IF ( @modified_date_end > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND ((MODIFIED_DATE IS NULL) OR (MODIFIED_DATE <= ''' + CONVERT( varchar(10), @modified_date_end, 101 ) + ''')) '		

	-- Updated to support the list of clients with null campaigns
		
	--IF ( @cli_list IS NOT NULL )
	--	SET @sql_where = @sql_where + 'AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ) '
		
	--IF ( @cmp_list IS NOT NULL )	
	--	SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) '

	IF ( @cmp_list IS NOT NULL )	
	BEGIN
		IF ( @cli_list IS NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) '
		END
		
		IF ( @cli_list IS NOT NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND ( CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) OR ( CMP_IDENTIFIER IS NULL AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ))) '
		END
	END

	IF ( @cmp_list IS NULL )
	BEGIN
		IF ( @cli_list IS NOT NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IS NULL AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ) '
		END	
	END

	IF ( @sql_where <> '' )
		SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )
		
	INSERT INTO #order_list ( ORDER_NBR ) 
		EXECUTE ( 'SELECT DISTINCT ORDER_NBR FROM dbo.OUTDOOR_HEADER ' + @sql_where )
			
	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)			
		EXECUTE dbo.advsp_csv_table_dump 'OUTDOOR_HEADER', @inc_col_titles, @sql_where, @ret_val OUTPUT
		
	-- [OUTDOOR_DETAIL]
	SET @sql_where = ''
	--IF ( @modified_date_start > '1900-01-01' )
	--	SET @sql_where = @sql_where + 'AND MODIFIED_DATE >= ''' + CONVERT( varchar(10), @modified_date_start, 101 ) + ''' '

	--IF ( @modified_date_end > '1900-01-01' )
	--	SET @sql_where = @sql_where + 'AND MODIFIED_DATE <= ''' + CONVERT( varchar(10), @modified_date_end, 101 ) + ''' '

	IF ( @modified_date_start > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND ((MODIFIED_DATE IS NULL) OR (MODIFIED_DATE >= ''' + CONVERT( varchar(10), @modified_date_start, 101 ) + ''')) '

	IF ( @modified_date_end > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND ((MODIFIED_DATE IS NULL) OR (MODIFIED_DATE <= ''' + CONVERT( varchar(10), @modified_date_end, 101 ) + ''')) '

	SET @sql_where = 'WHERE ORDER_NBR IN ( SELECT ORDER_NBR FROM #order_list ) ' + @sql_where		
	
	INSERT INTO #order_line_list ( ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR ) 
		EXECUTE ( 'SELECT DISTINCT ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR FROM dbo.OUTDOOR_DETAIL ' + @sql_where )

	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'OUTDOOR_DETAIL', @inc_col_titles, @sql_where, @ret_val OUTPUT

	-- [OUTDOOR_COMMENTS]
	SET @sql_where = ''
	SET @sql_where = @sql_where + 'WHERE EXISTS ( SELECT * FROM #order_line_list WHERE OUTDOOR_COMMENTS.ORDER_NBR = #order_line_list.ORDER_NBR '
	SET @sql_where = @sql_where + '					 AND OUTDOOR_COMMENTS.LINE_NBR = #order_line_list.LINE_NBR ) '

	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'OUTDOOR_COMMENTS', @inc_col_titles, @sql_where, @ret_val OUTPUT

END


IF ( @mag_order_data = 1 )
BEGIN
	-- [MAGAZINE_HEADER]
	SET @sql_where = ''
	IF ( @create_date_start > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND CREATE_DATE >= ''' + CONVERT( varchar(10), @create_date_start, 101 ) + ''' ' 

	IF ( @create_date_end > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND CREATE_DATE <= ''' + CONVERT( varchar(10), @create_date_end, 101 ) + ''' '
		
	--IF ( @modified_date_start > '1900-01-01' )
	--	SET @sql_where = @sql_where + 'AND MODIFIED_DATE >= ''' + CONVERT( varchar(10), @modified_date_start, 101 ) + ''' '

	--IF ( @modified_date_end > '1900-01-01' )
	--	SET @sql_where = @sql_where + 'AND MODIFIED_DATE <= ''' + CONVERT( varchar(10), @modified_date_end, 101 ) + ''' '
		
	IF ( @modified_date_start > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND ((MODIFIED_DATE IS NULL) OR (MODIFIED_DATE >= ''' + CONVERT( varchar(10), @modified_date_start, 101 ) + ''')) '

	IF ( @modified_date_end > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND ((MODIFIED_DATE IS NULL) OR (MODIFIED_DATE <= ''' + CONVERT( varchar(10), @modified_date_end, 101 ) + ''')) '
	
	-- Updated to support the list of clients with null campaigns		
		
	--IF ( @cli_list IS NOT NULL )
	--	SET @sql_where = @sql_where + 'AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ) '
		
	--IF ( @cmp_list IS NOT NULL )	
	--	SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) '

	IF ( @cmp_list IS NOT NULL )	
	BEGIN
		IF ( @cli_list IS NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) '
		END
		
		IF ( @cli_list IS NOT NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND ( CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) OR ( CMP_IDENTIFIER IS NULL AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ))) '
		END
	END

	IF ( @cmp_list IS NULL )
	BEGIN
		IF ( @cli_list IS NOT NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IS NULL AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ) '
		END	
	END

	IF ( @sql_where <> '' )
		SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )
		
	INSERT INTO #order_list ( ORDER_NBR ) 
		EXECUTE ( 'SELECT DISTINCT ORDER_NBR FROM dbo.MAGAZINE_HEADER ' + @sql_where )
			
	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)			
		EXECUTE dbo.advsp_csv_table_dump 'MAGAZINE_HEADER', @inc_col_titles, @sql_where, @ret_val OUTPUT
		
	-- [MAGAZINE_DETAIL]
	SET @sql_where = ''
	--IF ( @modified_date_start > '1900-01-01' )
	--	SET @sql_where = @sql_where + 'AND MODIFIED_DATE >= ''' + CONVERT( varchar(10), @modified_date_start, 101 ) + ''' '

	--IF ( @modified_date_end > '1900-01-01' )
	--	SET @sql_where = @sql_where + 'AND MODIFIED_DATE <= ''' + CONVERT( varchar(10), @modified_date_end, 101 ) + ''' '

	IF ( @modified_date_start > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND ((MODIFIED_DATE IS NULL) OR (MODIFIED_DATE >= ''' + CONVERT( varchar(10), @modified_date_start, 101 ) + ''')) '

	IF ( @modified_date_end > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND ((MODIFIED_DATE IS NULL) OR (MODIFIED_DATE <= ''' + CONVERT( varchar(10), @modified_date_end, 101 ) + ''')) '
		
	SET @sql_where = 'WHERE ORDER_NBR IN ( SELECT ORDER_NBR FROM #order_list ) ' + @sql_where		
	
	INSERT INTO #order_line_list ( ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR ) 
		EXECUTE ( 'SELECT DISTINCT ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR FROM dbo.MAGAZINE_DETAIL ' + @sql_where )

	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'MAGAZINE_DETAIL', @inc_col_titles, @sql_where, @ret_val OUTPUT

	-- [MAGAZINE_COMMENTS]
	SET @sql_where = ''
	SET @sql_where = @sql_where + 'WHERE EXISTS ( SELECT * FROM #order_line_list WHERE MAGAZINE_COMMENTS.ORDER_NBR = #order_line_list.ORDER_NBR '
	SET @sql_where = @sql_where + '					 AND MAGAZINE_COMMENTS.LINE_NBR = #order_line_list.LINE_NBR ) '

	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'MAGAZINE_COMMENTS', @inc_col_titles, @sql_where, @ret_val OUTPUT

END


IF ( @inet_order_data = 1 )
BEGIN
	-- [INTERNET_HEADER]
	SET @sql_where = ''
	IF ( @create_date_start > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND CREATE_DATE >= ''' + CONVERT( varchar(10), @create_date_start, 101 ) + ''' ' 

	IF ( @create_date_end > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND CREATE_DATE <= ''' + CONVERT( varchar(10), @create_date_end, 101 ) + ''' '
		
	--IF ( @modified_date_start > '1900-01-01' )
	--	SET @sql_where = @sql_where + 'AND MODIFIED_DATE >= ''' + CONVERT( varchar(10), @modified_date_start, 101 ) + ''' '

	--IF ( @modified_date_end > '1900-01-01' )
	--	SET @sql_where = @sql_where + 'AND MODIFIED_DATE <= ''' + CONVERT( varchar(10), @modified_date_end, 101 ) + ''' '

	IF ( @modified_date_start > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND ((MODIFIED_DATE IS NULL) OR (MODIFIED_DATE >= ''' + CONVERT( varchar(10), @modified_date_start, 101 ) + ''')) '

	IF ( @modified_date_end > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND ((MODIFIED_DATE IS NULL) OR (MODIFIED_DATE <= ''' + CONVERT( varchar(10), @modified_date_end, 101 ) + ''')) '

	-- Updated to support the list of clients with null campaigns
			
	--IF ( @cli_list IS NOT NULL )
	--	SET @sql_where = @sql_where + 'AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ) '
		
	--IF ( @cmp_list IS NOT NULL )	
	--	SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) '
	
	IF ( @cmp_list IS NOT NULL )	
	BEGIN
		IF ( @cli_list IS NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) '
		END
		
		IF ( @cli_list IS NOT NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND ( CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) OR ( CMP_IDENTIFIER IS NULL AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ))) '
		END
	END

	IF ( @cmp_list IS NULL )
	BEGIN
		IF ( @cli_list IS NOT NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IS NULL AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ) '
		END	
	END
	
	IF ( @sql_where <> '' )
		SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )
		
	INSERT INTO #order_list ( ORDER_NBR ) 
		EXECUTE ( 'SELECT DISTINCT ORDER_NBR FROM dbo.INTERNET_HEADER ' + @sql_where )
			
	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)			
		EXECUTE dbo.advsp_csv_table_dump 'INTERNET_HEADER', @inc_col_titles, @sql_where, @ret_val OUTPUT
		
	-- [INTERNET_DETAIL]
	SET @sql_where = ''
	--IF ( @modified_date_start > '1900-01-01' )
	--	SET @sql_where = @sql_where + 'AND MODIFIED_DATE >= ''' + CONVERT( varchar(10), @modified_date_start, 101 ) + ''' '

	--IF ( @modified_date_end > '1900-01-01' )
	--	SET @sql_where = @sql_where + 'AND MODIFIED_DATE <= ''' + CONVERT( varchar(10), @modified_date_end, 101 ) + ''' '
		
	IF ( @modified_date_start > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND ((MODIFIED_DATE IS NULL) OR (MODIFIED_DATE >= ''' + CONVERT( varchar(10), @modified_date_start, 101 ) + ''')) '

	IF ( @modified_date_end > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND ((MODIFIED_DATE IS NULL) OR (MODIFIED_DATE <= ''' + CONVERT( varchar(10), @modified_date_end, 101 ) + ''')) '		
		
	SET @sql_where = 'WHERE ORDER_NBR IN ( SELECT ORDER_NBR FROM #order_list ) ' + @sql_where		
	
	INSERT INTO #order_line_list ( ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR ) 
		EXECUTE ( 'SELECT DISTINCT ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR FROM dbo.INTERNET_DETAIL ' + @sql_where )

	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'INTERNET_DETAIL', @inc_col_titles, @sql_where, @ret_val OUTPUT

	-- [INTERNET_COMMENTS]
	SET @sql_where = ''
	SET @sql_where = @sql_where + 'WHERE EXISTS ( SELECT * FROM #order_line_list WHERE INTERNET_COMMENTS.ORDER_NBR = #order_line_list.ORDER_NBR '
	SET @sql_where = @sql_where + '					 AND INTERNET_COMMENTS.LINE_NBR = #order_line_list.LINE_NBR ) '

	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'INTERNET_COMMENTS', @inc_col_titles, @sql_where, @ret_val OUTPUT
	
END


IF ( @job_data = 1 )
BEGIN
	-- [JOB_LOG]
	SET @sql_where = ''
	IF ( @create_date_start > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND CREATE_DATE >= ''' + CONVERT( varchar(10), @create_date_start, 101 ) + ''' '
			
	IF ( @create_date_end > '1900-01-01' )		
		SET @sql_where = @sql_where + 'AND CREATE_DATE <= ''' + CONVERT( varchar(10), @create_date_end, 101 ) + ''' '

	-- Updated to support the list of clients with null campaigns
		
	--IF ( @cli_list IS NOT NULL )
	--	SET @sql_where = @sql_where + 'AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ) '
		
	--IF ( @cmp_list IS NOT NULL )	
	--	SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) '

	IF ( @cmp_list IS NOT NULL )	
	BEGIN
		IF ( @cli_list IS NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) '
		END
		
		IF ( @cli_list IS NOT NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND ( CMP_IDENTIFIER IN ( SELECT CMP_ID FROM #cmp_list ) OR ( CMP_IDENTIFIER IS NULL AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ))) '
		END
	END

	IF ( @cmp_list IS NULL )
	BEGIN
		IF ( @cli_list IS NOT NULL )	
		BEGIN
			SET @sql_where = @sql_where + 'AND CMP_IDENTIFIER IS NULL AND CL_CODE IN ( SELECT CL_CODE FROM #cli_list ) '
		END	
	END

	IF ( @sql_where <> '' )
		SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )

	INSERT INTO #job_list ( JOB_NUMBER ) 
		EXECUTE ( 'SELECT DISTINCT JOB_NUMBER FROM dbo.JOB_LOG ' + @sql_where )
		
	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)		
		EXECUTE dbo.advsp_csv_table_dump 'JOB_LOG', @inc_col_titles, @sql_where, @ret_val OUTPUT		

	-- [JOB_COMPONENT]
	SET @sql_where = ''
	SET @sql_where = 'WHERE JOB_NUMBER IN ( SELECT JOB_NUMBER FROM #job_list ) ' + @sql_where
	
	INSERT INTO #comp_list ( JOB_NUMBER, JOB_COMPONENT_NBR ) 
		EXECUTE ( 'SELECT DISTINCT JOB_NUMBER, JOB_COMPONENT_NBR FROM dbo.JOB_COMPONENT ' + @sql_where )
	
	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'JOB_COMPONENT', @inc_col_titles, @sql_where, @ret_val OUTPUT

END


IF ( @prod_po_data = 1 )
BEGIN
	-- [PURCHASE_ORDER] 
	SET @sql_where = ''
	IF ( @create_date_start > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND PO_CREATE_DATE >= ''' + CONVERT( varchar(10), @create_date_start, 101 ) + ''' '
			
	IF ( @create_date_end > '1900-01-01' )		
		SET @sql_where = @sql_where + 'AND PO_CREATE_DATE <= ''' + CONVERT( varchar(10), @create_date_end, 101 ) + ''' '

	IF ( @sql_where <> '' )
		SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )

	INSERT INTO #po_list ( PO_NUMBER ) 
		EXECUTE ( 'SELECT DISTINCT PO_NUMBER FROM dbo.PURCHASE_ORDER ' + @sql_where )
		
	SELECT @cnt = COUNT(*) FROM #po_list
	PRINT 'po_list #' + convert(varchar, @cnt)
	
	--INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)		
	--	EXECUTE dbo.advsp_csv_table_dump 'PURCHASE_ORDER', @inc_col_titles, @sql_where, @ret_val OUTPUT		

	-- [PURCHASE_ORDER_DET]
	SET @sql_where = ''
	SET @sql_where = @sql_where + 'AND PO_NUMBER IN ( SELECT PO_NUMBER FROM #po_list ) '
	SET @sql_where = @sql_where + 'AND EXISTS ( SELECT * FROM #comp_list WHERE PURCHASE_ORDER_DET.JOB_NUMBER = #comp_list.JOB_NUMBER '
	SET @sql_where = @sql_where + '					 AND PURCHASE_ORDER_DET.JOB_COMPONENT_NBR = #comp_list.JOB_COMPONENT_NBR ) '

	IF ( @sql_where <> '' )
		SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )
	
	INSERT INTO #po_list_2 ( PO_NUMBER ) 
	EXECUTE ( 'SELECT DISTINCT PO_NUMBER FROM dbo.PURCHASE_ORDER_DET ' + @sql_where )
	
	SELECT @cnt = COUNT(*) FROM #po_list_2
	PRINT 'po_list_2 #' + convert(varchar, @cnt)
	
	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'PURCHASE_ORDER_DET', @inc_col_titles, @sql_where, @ret_val OUTPUT

	-- [PURCHASE_ORDER] 
	SET @sql_where = ''
	SET @sql_where = @sql_where + 'AND PO_NUMBER IN ( SELECT PO_NUMBER FROM #po_list_2 ) '
	
	SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )
	
	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)		
		EXECUTE dbo.advsp_csv_table_dump 'PURCHASE_ORDER', @inc_col_titles, @sql_where, @ret_val OUTPUT		

END


IF ( @acct_pay_data = 1 )
BEGIN
	-- [AP_HEADER] 
	SET @sql_where = ''
	IF ( @create_date_start > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND CREATE_DATE >= ''' + CONVERT( varchar(10), @create_date_start, 101 ) + ''' ' 

	IF ( @create_date_end > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND CREATE_DATE <= ''' + CONVERT( varchar(10), @create_date_end, 101 ) + ''' '
		
	--IF ( @modified_date_start > '1900-01-01' )
	--	SET @sql_where = @sql_where + 'AND MODIFY_DATE >= ''' + CONVERT( varchar(10), @modified_date_start, 101 ) + ''' '

	--IF ( @modified_date_end > '1900-01-01' )
	--	SET @sql_where = @sql_where + 'AND MODIFY_DATE <= ''' + CONVERT( varchar(10), @modified_date_end, 101 ) + ''' '		
		
	IF ( @modified_date_start > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND ((MODIFY_DATE IS NULL) OR (MODIFY_DATE >= ''' + CONVERT( varchar(10), @modified_date_start, 101 ) + ''')) '

	IF ( @modified_date_end > '1900-01-01' )
		SET @sql_where = @sql_where + 'AND ((MODIFY_DATE IS NULL) OR (MODIFY_DATE <= ''' + CONVERT( varchar(10), @modified_date_end, 101 ) + ''')) '
		
	IF ( @sql_where <> '' )
		SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )

	INSERT INTO #ap_list ( AP_ID, AP_SEQ ) 
		EXECUTE ( 'SELECT DISTINCT AP_ID, AP_SEQ FROM dbo.AP_HEADER ' + @sql_where )

	SELECT @cnt = COUNT(*) FROM #ap_list
	PRINT 'ap_list #' + convert(varchar, @cnt)
	
	--- start - for testing
	
	--INSERT INTO [dbo].[AP_LIST] ( AP_ID, AP_SEQ )
	--	EXECUTE ( 'SELECT * FROM #ap_list' )

	--SELECT @cnt = COUNT(*) FROM [dbo].[AP_LIST]
	--PRINT 'dbo.ap_list #' + convert(varchar, @cnt)
				
	--SELECT @cnt = COUNT(*) FROM #order_line_list
	--PRINT 'order_line_list #' + convert(varchar, @cnt)				
				
	--INSERT INTO [dbo].[ORDER_LINE_LIST] ( ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR ) 
	--	EXECUTE ( 'SELECT * FROM #order_line_list ' )

	--SELECT @cnt = COUNT(*) FROM [dbo].[ORDER_LINE_LIST]
	--PRINT 'dbo.order_line_list #' + convert(varchar, @cnt)

	--- end - for testing
	
	--INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)		
	--	EXECUTE dbo.advsp_csv_table_dump 'AP_HEADER', @inc_col_titles, @sql_where, @ret_val OUTPUT		

	-- [AP_INTERNET]
	IF ( @inet_order_data = 1 )
	BEGIN
		SET @sql_where = ''
		SET @sql_where = @sql_where + 'AND EXISTS ( SELECT * FROM #order_line_list WHERE AP_INTERNET.ORDER_NBR = #order_line_list.ORDER_NBR '
		SET @sql_where = @sql_where + '					 AND AP_INTERNET.ORDER_LINE_NBR = #order_line_list.LINE_NBR ) '
		--SET @sql_where = @sql_where + '					 AND AP_INTERNET.REV_NBR = #order_line_list.REV_NBR '
		--SET @sql_where = @sql_where + '					 AND AP_INTERNET.SEQ_NBR = #order_line_list.SEQ_NBR ) '
		SET @sql_where = @sql_where + 'AND EXISTS ( SELECT * FROM #ap_list WHERE AP_INTERNET.AP_ID = #ap_list.AP_ID '
		SET @sql_where = @sql_where + '					 AND AP_INTERNET.AP_SEQ = #ap_list.AP_SEQ ) '

		IF ( @sql_where <> '' )
			SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )

		INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
			EXECUTE dbo.advsp_csv_table_dump 'AP_INTERNET', @inc_col_titles, @sql_where, @ret_val OUTPUT		
			
		INSERT INTO #ap_list_2 ( AP_ID, AP_SEQ ) 
			EXECUTE ( 'SELECT AP_ID, AP_SEQ FROM AP_INTERNET ' + @sql_where )
		
		--SELECT @cnt = COUNT(*) FROM #ap_list_2
		--PRINT 'ap_list_2 #' + convert(varchar, @cnt)
		
	END

	-- [AP_MAGAZINE]
	IF ( @mag_order_data = 1 )
	BEGIN
		SET @sql_where = ''
		SET @sql_where = @sql_where + 'AND EXISTS ( SELECT * FROM #order_line_list WHERE AP_MAGAZINE.ORDER_NBR = #order_line_list.ORDER_NBR '
		SET @sql_where = @sql_where + '					 AND AP_MAGAZINE.ORDER_LINE_NBR = #order_line_list.LINE_NBR ) '
		--SET @sql_where = @sql_where + '					 AND AP_MAGAZINE.REV_NBR = #order_line_list.REV_NBR '
		--SET @sql_where = @sql_where + '					 AND AP_MAGAZINE.SEQ_NBR = #order_line_list.SEQ_NBR ) '
		SET @sql_where = @sql_where + 'AND EXISTS ( SELECT * FROM #ap_list WHERE AP_MAGAZINE.AP_ID = #ap_list.AP_ID '
		SET @sql_where = @sql_where + '					 AND AP_MAGAZINE.AP_SEQ = #ap_list.AP_SEQ ) '

		IF ( @sql_where <> '' )
			SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )

		INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
			EXECUTE dbo.advsp_csv_table_dump 'AP_MAGAZINE', @inc_col_titles, @sql_where, @ret_val OUTPUT
				
		INSERT INTO #ap_list_2 ( AP_ID, AP_SEQ ) 
			EXECUTE ( 'SELECT AP_ID, AP_SEQ FROM AP_MAGAZINE ' + @sql_where )	

		--SELECT @cnt = COUNT(*) FROM #ap_list_2
		--PRINT 'ap_list_2 #' + convert(varchar, @cnt)

	END

	-- [AP_NEWSPAPER]
	IF ( @news_order_data = 1 )
	BEGIN
		SET @sql_where = ''
		SET @sql_where = @sql_where + 'AND EXISTS ( SELECT * FROM #order_line_list WHERE AP_NEWSPAPER.ORDER_NBR = #order_line_list.ORDER_NBR '
		SET @sql_where = @sql_where + '					 AND AP_NEWSPAPER.ORDER_LINE_NBR = #order_line_list.LINE_NBR ) '
		--SET @sql_where = @sql_where + '					 AND AP_NEWSPAPER.REV_NBR = #order_line_list.REV_NBR '
		--SET @sql_where = @sql_where + '					 AND AP_NEWSPAPER.SEQ_NBR = #order_line_list.SEQ_NBR ) '
		SET @sql_where = @sql_where + 'AND EXISTS ( SELECT * FROM #ap_list WHERE AP_NEWSPAPER.AP_ID = #ap_list.AP_ID '
		SET @sql_where = @sql_where + '					 AND AP_NEWSPAPER.AP_SEQ = #ap_list.AP_SEQ ) '

		IF ( @sql_where <> '' )
			SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )

		INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
			EXECUTE dbo.advsp_csv_table_dump 'AP_NEWSPAPER', @inc_col_titles, @sql_where, @ret_val OUTPUT
					
		INSERT INTO #ap_list_2 ( AP_ID, AP_SEQ ) 
			EXECUTE ( 'SELECT AP_ID, AP_SEQ FROM AP_NEWSPAPER ' + @sql_where )

		--SELECT @cnt = COUNT(*) FROM #ap_list_2
		--PRINT 'ap_list_2 #' + convert(varchar, @cnt)

	END

	-- [AP_TV]
	IF ( @tv_order_data = 1 )
	BEGIN
		SET @sql_where = ''
		SET @sql_where = @sql_where + 'AND EXISTS ( SELECT * FROM #order_bcast_list WHERE AP_TV.ORDER_NBR = #order_bcast_list.ORDER_NBR '
		SET @sql_where = @sql_where + '					 AND AP_TV.REV_NBR = #order_bcast_list.REV_NBR ) '
		SET @sql_where = @sql_where + 'AND EXISTS ( SELECT * FROM #ap_list WHERE AP_TV.AP_ID = #ap_list.AP_ID '
		SET @sql_where = @sql_where + '					 AND AP_TV.AP_SEQ = #ap_list.AP_SEQ ) '

		IF ( @sql_where <> '' )
			SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )

		INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
			EXECUTE dbo.advsp_csv_table_dump 'AP_TV', @inc_col_titles, @sql_where, @ret_val OUTPUT
			
		INSERT INTO #ap_list_2 ( AP_ID, AP_SEQ ) 
			EXECUTE ( 'SELECT AP_ID, AP_SEQ FROM AP_TV ' + @sql_where )	

		--SELECT @cnt = COUNT(*) FROM #ap_list_2
		--PRINT 'ap_list_2 #' + convert(varchar, @cnt)

	END			

	-- [AP_RADIO]
	IF ( @rad_order_data = 1 )
	BEGIN
		SET @sql_where = ''
		SET @sql_where = @sql_where + 'AND EXISTS ( SELECT * FROM #order_bcast_list WHERE AP_RADIO.ORDER_NBR = #order_bcast_list.ORDER_NBR '
		SET @sql_where = @sql_where + '					 AND AP_RADIO.REV_NBR = #order_bcast_list.REV_NBR ) '
		SET @sql_where = @sql_where + 'AND EXISTS ( SELECT * FROM #ap_list WHERE AP_RADIO.AP_ID = #ap_list.AP_ID '
		SET @sql_where = @sql_where + '					 AND AP_RADIO.AP_SEQ = #ap_list.AP_SEQ ) '

		IF ( @sql_where <> '' )
			SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )

		INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
			EXECUTE dbo.advsp_csv_table_dump 'AP_RADIO', @inc_col_titles, @sql_where, @ret_val OUTPUT
			
		INSERT INTO #ap_list_2 ( AP_ID, AP_SEQ ) 
			EXECUTE ( 'SELECT AP_ID, AP_SEQ FROM AP_RADIO ' + @sql_where )

		--SELECT @cnt = COUNT(*) FROM #ap_list_2
		--PRINT 'ap_list_2 #' + convert(varchar, @cnt)

	END
	
	-- [AP_OUTDOOR]
	IF ( @ooh_order_data = 1 )
	BEGIN
		SET @sql_where = ''
		SET @sql_where = @sql_where + 'AND EXISTS ( SELECT * FROM #order_line_list WHERE AP_OUTDOOR.ORDER_NBR = #order_line_list.ORDER_NBR '
		SET @sql_where = @sql_where + '					 AND AP_OUTDOOR.ORDER_LINE_NBR = #order_line_list.LINE_NBR ) '
		--SET @sql_where = @sql_where + '					 AND AP_OUTDOOR.REV_NBR = #order_line_list.REV_NBR '
		--SET @sql_where = @sql_where + '					 AND AP_OUTDOOR.SEQ_NBR = #order_line_list.SEQ_NBR ) '
		SET @sql_where = @sql_where + 'AND EXISTS ( SELECT * FROM #ap_list WHERE AP_OUTDOOR.AP_ID = #ap_list.AP_ID '
		SET @sql_where = @sql_where + '					 AND AP_OUTDOOR.AP_SEQ = #ap_list.AP_SEQ ) '

		IF ( @sql_where <> '' )
			SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )

		INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
			EXECUTE dbo.advsp_csv_table_dump 'AP_OUTDOOR', @inc_col_titles, @sql_where, @ret_val OUTPUT
			
		INSERT INTO #ap_list_2 ( AP_ID, AP_SEQ ) 
			EXECUTE ( 'SELECT AP_ID, AP_SEQ FROM AP_OUTDOOR ' + @sql_where )	

		--SELECT @cnt = COUNT(*) FROM #ap_list_2
		--PRINT 'ap_list_2 #' + convert(varchar, @cnt)

	END			

	-- [AP_PRODUCTION]
	IF ( @job_data = 1 )
	BEGIN
		SET @sql_where = ''
		SET @sql_where = @sql_where + 'AND EXISTS ( SELECT * FROM #comp_list WHERE AP_PRODUCTION.JOB_NUMBER = #comp_list.JOB_NUMBER '
		SET @sql_where = @sql_where + '					 AND AP_PRODUCTION.JOB_COMPONENT_NBR = #comp_list.JOB_COMPONENT_NBR ) '
		SET @sql_where = @sql_where + 'AND EXISTS ( SELECT * FROM #ap_list WHERE AP_PRODUCTION.AP_ID = #ap_list.AP_ID '
		SET @sql_where = @sql_where + '					 AND AP_PRODUCTION.AP_SEQ = #ap_list.AP_SEQ ) '

		IF ( @sql_where <> '' )
			SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )

		INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
			EXECUTE dbo.advsp_csv_table_dump 'AP_PRODUCTION', @inc_col_titles, @sql_where, @ret_val OUTPUT	
			
		INSERT INTO #ap_list_2 ( AP_ID, AP_SEQ ) 
			EXECUTE ( 'SELECT AP_ID, AP_SEQ FROM AP_PRODUCTION ' + @sql_where )	

		--SELECT @cnt = COUNT(*) FROM #ap_list_2
		--PRINT 'ap_list_2 #' + convert(varchar, @cnt)

	END
	
	-- [AP_GL_DIST]		
	SET @sql_where = ''
	SET @sql_where = @sql_where + 'AND EXISTS ( SELECT * FROM #ap_list WHERE AP_GL_DIST.AP_ID = #ap_list.AP_ID '
	SET @sql_where = @sql_where + '					 AND AP_GL_DIST.AP_SEQ = #ap_list.AP_SEQ ) '

	IF ( @sql_where <> '' )
		SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )

	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'AP_GL_DIST', @inc_col_titles, @sql_where, @ret_val OUTPUT	

	INSERT INTO #ap_list_2 ( AP_ID, AP_SEQ ) 
		EXECUTE ( 'SELECT AP_ID, AP_SEQ FROM AP_GL_DIST ' + @sql_where )	
	
	SELECT @cnt = COUNT(*) FROM #ap_list_2
	PRINT 'ap_list_2 #' + convert(varchar, @cnt)
				
	--[AP_HEADER]
	SET @sql_where = ''
	SET @sql_where = @sql_where + 'AND EXISTS ( SELECT * FROM #ap_list_2 WHERE AP_HEADER.AP_ID = #ap_list_2.AP_ID '
	SET @sql_where = @sql_where + '					 AND AP_HEADER.AP_SEQ = #ap_list_2.AP_SEQ ) '
	
	IF ( @sql_where <> '' )
	SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )

	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)		
		EXECUTE dbo.advsp_csv_table_dump 'AP_HEADER', @inc_col_titles, @sql_where, @ret_val OUTPUT				

END


IF ( @ap_pmt_hist_data = 1 )
BEGIN
	-- [AP_PMT_HIST]
	SET @sql_where = ''
	
	IF ( @acct_pay_data = 1 )
	BEGIN
		SET @sql_where = @sql_where + 'AND EXISTS ( SELECT * FROM #ap_list_2 WHERE AP_PMT_HIST.AP_ID = #ap_list_2.AP_ID '
		SET @sql_where = @sql_where + '					 AND AP_PMT_HIST.AP_SEQ = #ap_list_2.AP_SEQ ) '
	END
	
	IF ( @sql_where <> '' )
		SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )

	INSERT INTO #ap_check ( CHECK_NBR, CHECK_SEQ )
		EXECUTE ( 'SELECT DISTINCT AP_CHK_NBR, CHK_SEQ FROM dbo.AP_PMT_HIST ' + @sql_where )

	SELECT @cnt = COUNT(*) FROM #ap_check
	PRINT 'ap_check #' + convert(varchar, @cnt)

	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'AP_PMT_HIST', @inc_col_titles, @sql_where, @ret_val OUTPUT	
		
	-- [CHECK_REGISTER]
	SET @sql_where = ''
	SET @sql_where = @sql_where + 'AND EXISTS ( SELECT * FROM #ap_check WHERE CHECK_REGISTER.CHECK_NBR = #ap_check.CHECK_NBR '
	SET @sql_where = @sql_where + '					 AND CHECK_REGISTER.CHK_SEQ = #ap_check.CHECK_SEQ ) '

	IF ( @sql_where <> '' )
		SET @sql_where = 'WHERE ' + SUBSTRING( @sql_where, 5, LEN( @sql_where ) - 4 )

	INSERT INTO #ap_check_2 ( CHECK_NBR, CHECK_SEQ )
		EXECUTE ( 'SELECT DISTINCT CHECK_NBR, CHK_SEQ FROM dbo.CHECK_REGISTER ' + @sql_where )

	SELECT @cnt = COUNT(*) FROM #ap_check_2
	PRINT 'ap_check_2 #' + convert(varchar, @cnt)

	INSERT INTO #csv_output	( csv_row_id, is_title, tablename, csv_row_data	)
		EXECUTE dbo.advsp_csv_table_dump 'CHECK_REGISTER', @inc_col_titles, @sql_where, @ret_val OUTPUT	
		
END

-- This section is temporary and just for testing the output files
--IF ( @temp_output_folder <> '' )
--BEGIN
--	DECLARE @sql varchar(8000), @tablename varchar(50)

--	DECLARE output_rows CURSOR FOR 
--	SELECT DISTINCT tablename FROM #csv_output FOR READ ONLY
	  
--	OPEN output_rows 
--	FETCH NEXT FROM output_rows INTO @tablename
--	WHILE ( @@FETCH_STATUS = 0 )
--	BEGIN
--		SELECT @sql = 'bcp "SELECT csv_row_data FROM #csv_output WHERE tablename = ''' + @tablename + '''"'
--		SELECT @sql = @sql + ' queryout "' + @temp_output_folder + @tablename + '.csv" -c -t, -T'
--		EXECUTE master..xp_cmdshell @sql
--		PRINT @sql
--		FETCH NEXT FROM output_rows INTO @tablename
--	END
--	CLOSE output_rows
--	DEALLOCATE output_rows	
--END
-- END temp section

SELECT
		TableName = tablename,
		CSVRowData = csv_row_data
  FROM #csv_output ORDER BY tablename ASC, is_title DESC, csv_row_id ASC 
