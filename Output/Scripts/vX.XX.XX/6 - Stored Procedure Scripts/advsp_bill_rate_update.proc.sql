CREATE PROCEDURE [dbo].[advsp_bill_rate_update] ( 
	@date_from smalldatetime, 
	@date_to smalldatetime, 
	@null_flag bit,
	@job_number integer,
	@job_component_nbr smallint,
	@cl_code varchar(6),
	@div_code varchar(6),
	@prd_code varchar(6),
	@user_id varchar(100),
	@ret_val smallint OUTPUT 
)
AS

SET NOCOUNT ON

CREATE TABLE #rate_update ( 
	rate_update_id		integer identity (1,1) NOT NULL, 
	ET_ID				integer NOT NULL,
	SEQ_NBR				smallint NOT NULL,
	JOB_NUMBER			integer NOT NULL,
	JOB_COMPONENT_NBR	smallint NOT NULL,
	EMP_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	EMP_DATE			smalldatetime NULL,
	FNC_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	CL_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	DIV_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	PRD_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	SC_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EMP_HOURS			decimal(7,2) NULL,
	ET_DTL_ID			integer NULL,
	ADJ_COMMENTS		text NULL,
  CONSTRAINT PK_rate_update PRIMARY KEY CLUSTERED( rate_update_id )
)

DECLARE @sql_update varchar(4000), @sql_select varchar(4000), @level_desc varchar(254), @adj_comments varchar(4000)
DECLARE @et_id integer, @seq_nbr smallint
DECLARE @emp_code varchar(6), @emp_date smalldatetime, @fnc_code varchar(6), @sc_code varchar(6), @tax_code varchar(4)
DECLARE @tax_comm smallint, @tax_comm_only smallint, @tax_resale smallint, @total_bill decimal(18,2), @comm_amt decimal(18,2)
DECLARE @state_tax decimal(18,2), @county_tax decimal(18,2), @city_tax decimal(18,2), @line_total decimal(18,2)
DECLARE @bill_rate decimal(10,3), @comm_pct decimal(9,3), @tax_flag smallint, @comm_flag smallint, @nonbill_flag smallint
DECLARE @state_pct decimal(9,4), @county_pct decimal(9,4), @city_pct decimal(9,4), @emp_hours decimal(7,2)
DECLARE @rate_level smallint, @tax_level smallint, @tax_comm_flags_level smallint, @fee_time_flag smallint

SET @ret_val = 0
SET @sql_select = ''
SET @sql_update = ''
	
IF ( @ret_val = 0 )
	IF ( @date_from IS NULL ) SET @ret_val = -1	

IF ( @ret_val = 0 )	
	IF ( @date_to IS NULL ) SET @ret_val = -2	
	
IF ( @ret_val = 0 )	
	IF ( @date_from > @date_to ) SET @ret_val = -3	

IF ( @ret_val = 0 )
BEGIN
	SET @sql_select = @sql_select + '		 INSERT INTO #rate_update ( '
	SET @sql_select = @sql_select + '				ET_ID, SEQ_NBR, JOB_NUMBER, JOB_COMPONENT_NBR, '
	SET @sql_select = @sql_select + '		 		EMP_CODE, EMP_DATE, FNC_CODE, CL_CODE, DIV_CODE, '
	SET @sql_select = @sql_select + '		 		PRD_CODE, SC_CODE, EMP_HOURS, ET_DTL_ID, ADJ_COMMENTS ) '
	SET @sql_select = @sql_select + '		 SELECT etd.ET_ID, etd.SEQ_NBR, etd.JOB_NUMBER, etd.JOB_COMPONENT_NBR, '
	SET @sql_select = @sql_select + '				et.EMP_CODE, et.EMP_DATE, etd.FNC_CODE, jl.CL_CODE, jl.DIV_CODE, '
	SET @sql_select = @sql_select + '				jl.PRD_CODE, jl.SC_CODE, etd.EMP_HOURS, etd.ET_DTL_ID, etd.ADJ_COMMENTS '
	SET @sql_select = @sql_select + '		   FROM dbo.EMP_TIME et '
	SET @sql_select = @sql_select + '	 INNER JOIN dbo.EMP_TIME_DTL etd '
	SET @sql_select = @sql_select + '			 ON et.ET_ID = etd.ET_ID '
	SET @sql_select = @sql_select + '	 INNER JOIN dbo.JOB_LOG jl '
	SET @sql_select = @sql_select + '			 ON etd.JOB_NUMBER = jl.JOB_NUMBER '
	SET @sql_select = @sql_select + '		  WHERE ( etd.AR_INV_NBR IS NULL ) '
	SET @sql_select = @sql_select + '			AND ( etd.BILLING_USER IS NULL ) '
	SET @sql_select = @sql_select + '			AND ( et.EMP_DATE >= ''' + CONVERT( varchar(10), @date_from, 101 ) + ''' ) '
	SET @sql_select = @sql_select + '			AND ( et.EMP_DATE <= ''' + CONVERT( varchar(10), @date_to, 101 ) + ''' ) '

	IF ( @null_flag = 1 )
		SET @sql_select = @sql_select + '			AND ( etd.EMP_BILL_RATE IS NULL OR etd.EMP_BILL_RATE = 0 ) '
	
	IF ( @job_number > 0 )
	BEGIN
		SET @sql_select = @sql_select + '			AND ( etd.JOB_NUMBER = ' + CAST( @job_number AS varchar(8)) + ' ) '
		IF ( @job_component_nbr > 0 )
			SET @sql_select = @sql_select + '			AND ( etd.JOB_COMPONENT_NBR = ' + CAST( @job_component_nbr AS varchar(3)) + ' ) '
	END	

	IF ( @cl_code IS NOT NULL )
	BEGIN
		SET @sql_select = @sql_select + '			AND ( jl.CL_CODE = ''' + @cl_code + ''' ) '
		IF ( @div_code IS NOT NULL )
			SET @sql_select = @sql_select + '			AND ( jl.DIV_CODE = ''' + @div_code + ''' ) '
			IF ( @prd_code IS NOT NULL )
				SET @sql_select = @sql_select + '			AND ( jl.PRD_CODE = ''' + @prd_code + ''' ) '
	END	
	
	EXECUTE ( @sql_select )
	SET @ret_val = @@ERROR
	--SELECT @sql_select
	--SELECT * FROM #rate_update

END

IF ( @ret_val = 0 )
BEGIN

	DECLARE rate_update_cursor CURSOR FOR
	 SELECT ET_ID, SEQ_NBR, EMP_CODE, EMP_DATE, FNC_CODE, ADJ_COMMENTS, 
			CL_CODE, DIV_CODE, PRD_CODE, SC_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, EMP_HOURS
	   FROM #rate_update 
   ORDER BY ET_ID ASC
	  FOR READ ONLY

	OPEN rate_update_cursor
	FETCH NEXT FROM rate_update_cursor 
		INTO @et_id, @seq_nbr, @emp_code, @emp_date, @fnc_code, @adj_comments, @cl_code, @div_code, @prd_code, @sc_code, @job_number, @job_component_nbr, @emp_hours

	WHILE ( @@FETCH_STATUS = 0 AND @ret_val = 0 )
	BEGIN

			 SELECT @bill_rate = gbr.BILLING_RATE,
					@rate_level = gbr.RATE_LEVEL,
					@tax_code = gbr.TAX_CODE, 
					@comm_pct = gbr.COMM,
					@tax_level = gbr.TAX_LEVEL, 
					@tax_comm = gbr.TAX_COMM, 
					@nonbill_flag = gbr.NOBILL_FLAG,
					@fee_time_flag = gbr.FEE_TIME_FLAG,
					@tax_comm_only = gbr.TAX_COMM_ONLY, 
					@tax_comm_flags_level = gbr.TAX_COMM_FLAGS_LEVEL, 
					@tax_resale = tax.TAX_RESALE,
					@state_pct = COALESCE( tax.TAX_STATE_PERCENT, 0.000 ), 
					@county_pct = COALESCE( tax.TAX_COUNTY_PERCENT, 0.000 ), 
					@city_pct = COALESCE( tax.TAX_CITY_PERCENT, 0.000 )
			   FROM dbo.advtf_get_billing_rate( 
					@emp_code, @emp_date, @fnc_code, @cl_code, @div_code, @prd_code, @sc_code, 'E', @job_number, @job_component_nbr, default ) gbr
	LEFT OUTER JOIN dbo.SALES_TAX tax WITH ( NOLOCK )
				 ON ( gbr.TAX_CODE = tax.TAX_CODE )
			 
		IF ( @tax_code IS NOT NULL )
			SET @tax_flag = 1
		ELSE
			SET @tax_flag = 0
			 
		IF ( @comm_pct = 0.000 )
			SET @comm_flag = 0
		ELSE
			SET @comm_flag = 1	
				 
		IF ( @bill_rate IS NOT NULL )
		BEGIN
			IF ( @rate_level = 9999 )
				SET @level_desc = 'Approved Estimate'
			ELSE
				SELECT @level_desc = LEVEL_DESC FROM dbo.BILL_RATE_PREC WHERE PRECEDENCE = @rate_level
		END
		
		SET @total_bill = COALESCE( ROUND( @bill_rate * @emp_hours, 2 ), 0.00 )
		
		IF ( @comm_flag = 1 )
			SET @comm_amt = COALESCE( ROUND(( @total_bill * @comm_pct / 100 ), 2 ), 0.00 )
		ELSE
			SET @comm_amt = 0.00	
			
		IF ( @tax_flag = 1 )
		BEGIN
			IF ( @tax_comm_only = 1 )
			BEGIN
				SET @state_tax = dbo.advfn_calc_prod_resale( 0, @comm_amt, @state_pct )
				SET @county_tax = dbo.advfn_calc_prod_resale( 0, @comm_amt, @county_pct )
				SET @city_tax = dbo.advfn_calc_prod_resale( 0, @comm_amt, @city_pct )
			END
			ELSE
			BEGIN
				IF ( @tax_comm = 1 )
				BEGIN
					SET @state_tax = dbo.advfn_calc_prod_resale( @total_bill, @comm_amt, @state_pct )
					SET @county_tax = dbo.advfn_calc_prod_resale( @total_bill, @comm_amt, @county_pct )
					SET @city_tax = dbo.advfn_calc_prod_resale( @total_bill, @comm_amt, @city_pct )
				END
				ELSE
				BEGIN
					SET @state_tax = dbo.advfn_calc_prod_resale( @total_bill, 0, @state_pct )
					SET @county_tax = dbo.advfn_calc_prod_resale( @total_bill, 0, @county_pct )
					SET @city_tax = dbo.advfn_calc_prod_resale( @total_bill, 0, @city_pct )
				END
			END
		END		
		ELSE
		BEGIN
			SET @state_tax = 0.00
			SET @county_tax = 0.00
			SET @city_tax = 0.00
		END
		
		SET @state_tax = COALESCE( @state_tax, 0.00 )
		SET @county_tax = COALESCE( @county_tax, 0.00 )	
		SET @city_tax = COALESCE( @city_tax, 0.00 )
		SET @line_total = COALESCE( @total_bill + @comm_amt + @state_tax + @county_tax + @city_tax, 0.00 )
		
		SET @adj_comments = COALESCE( @adj_comments + CHAR(13), '' ) + 'Updated on ' + CONVERT( varchar(10), getdate( ), 101 ) + ' by user ' + @user_id

		 UPDATE dbo.EMP_TIME_DTL
			SET	TOTAL_BILL = @total_bill,
				EMP_BILL_RATE = @bill_rate,
				EMP_NON_BILL_FLAG = @nonbill_flag,
				FEE_TIME = @fee_time_flag,
				EMP_RATE_FROM = @level_desc,
				EMP_COMM_PCT = @comm_pct,		
				EXT_MARKUP_AMT = @comm_amt,
				TAX_CODE = @tax_code,
				TAX_STATE_PCT = @state_pct, 
				TAX_COUNTY_PCT = @county_pct,
				TAX_CITY_PCT = @city_pct,
				TAX_COMM = @tax_comm, 
				TAX_COMM_ONLY = @tax_comm_only, 
				EXT_STATE_RESALE = @state_tax,
				EXT_COUNTY_RESALE = @county_tax,
				EXT_CITY_RESALE = @city_tax,
				LINE_TOTAL = @line_total,
				ADJ_COMMENTS = @adj_comments
		  WHERE ET_ID = @et_id
			AND SEQ_NBR = @seq_nbr
			AND AR_INV_NBR IS NULL
			
		SET @ret_val = @@ERROR

		FETCH NEXT FROM rate_update_cursor 
			INTO @et_id, @seq_nbr, @emp_code, @emp_date, @fnc_code, @adj_comments, @cl_code, @div_code, @prd_code, @sc_code, @job_number, @job_component_nbr, @emp_hours
			 
	END
	
	CLOSE rate_update_cursor
	DEALLOCATE rate_update_cursor
END

GO