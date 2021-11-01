IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[advsp_revise_order_header]') AND OBJECTPROPERTY( id, N'IsProcedure' ) = 1 )
	DROP PROCEDURE [dbo].[advsp_revise_order_header]
GO

CREATE PROCEDURE [dbo].[advsp_revise_order_header] 
@user_id varchar(100), @action varchar(10), @order_type varchar(2), @ret_val integer OUTPUT, @ret_val_s varchar(max) OUTPUT, 
--all
@order_nbr int,
@order_desc varchar(40),
@cl_code varchar(6),
@div_code varchar(6),
@prd_code varchar(6),
@office_code varchar(4),
@cmp_code varchar(6),
@media_type varchar(6),
@vn_code varchar(6),
@vr_code varchar(4),
@vr_code2 varchar(4),
@client_po varchar(25),
@client_ref varchar(60),
@status varchar(3),
@order_date smalldatetime,
@buyer varchar(40),
@order_comment varchar(MAX),
@house_comment varchar(254),
@pub_station smallint,
@rep1 smallint,
@rep2 smallint,
@bill_coop_code varchar(6),
@ord_process_contrl smallint,
@market_code varchar(10),
@start_date smalldatetime,
@end_date smalldatetime,
@units varchar(2),
@nbr_of_units int,
@net_gross smallint,
@create_date smalldatetime,
--@user_id varchar(100),
@cancelled smallint,
@cancelled_by varchar(100),
@cancelled_date smalldatetime,
@modified_by varchar(100),
@modified_date smalldatetime,
@modified_comments varchar(254),
@revised_flag smallint,
@link_id int,
@reconcile_flag smallint,
@cmp_identifier int,
@printed smallint,
@order_accepted smallint,
@fiscal_period_code varchar(6),
@locked varchar(1),
@locked_by varchar(100),
@bcc_id int,
@is_quote int,
@buyer_emp_code varchar(6) = NULL
--@complete int = NULL

AS

/*
***********************************************************************************************************
PJH 10/13/15 - Campaign Code will get Camp ID, Rep1 & 2 will default if not provided
PJH 10/13/15 - House Comment will contain Import Order ID info, MailTo Vendor will default
PJH 12/01/15 - SET @create_date = @modified_date
PJH 02/08/16 - Do not default Pub/Station mail-to here... pass in from calling proc
PJH 06/10/16 - @revised_flag based on existing Order/Line
PJH 12/30/16 - added @buyer_emp_code
MJC 01/16/17 - update BUYER_EMP_CODE when updating order
PJH 02/10/17 - update BUYER_EMP_CODE when inserting order
***********************************************************************************************************
*/

DECLARE @sql varchar(500), @param_def varchar(500), @error_msg_w varchar(200)
DECLARE @rr_msg_w varchar(100), @goto_id varchar(50), @s_temp varchar(250)
DECLARE @max_order_nbr smallint, @ok smallint, @table_prefix varchar(50)

DECLARE	@ErMessage varchar(max),
					@ErSeverity int,
					@ErState int

BEGIN TRY

--SAVE TRAN TH1

/** DEBUG **/
--SET @error_msg_w = 'TEST ERROR'
--UPDATE AGENCY SET ZIP = ABS(ZIP)
--GOTO ERROR_MSG

SET @ret_val = 0

IF @order_type =  'IN'
	SET @table_prefix = 'INTERNET'
IF @order_type =  'OD'
	SET @table_prefix = 'OUTDOOR'
IF @order_type =  'NP'
	SET @table_prefix = 'NEWSPAPER'
IF @order_type =  'MA'
	SET @table_prefix = 'MAGAZINE'		
IF @order_type =  'RA'
	SET @table_prefix = 'RADIO'
IF @order_type =  'TV'
	SET @table_prefix = 'TV'

SET @status = COALESCE(@is_quote, 0)

IF @buyer_emp_code IS NOT NULL BEGIN
	SELECT @buyer = EMP_FML
	FROM MEDIA_BUYER A JOIN V_ACTIVE_EMPLOYEE B ON A.EMP_CODE = B.EMP_CODE  
	WHERE A.EMP_CODE = @buyer_emp_code;
END	

/* @action = 'NEW' or 'UPDATE' */	

IF @action = 'UPDATE' BEGIN
	IF COALESCE(@order_nbr, 0) = 0 BEGIN
		IF COALESCE(@link_id, 0) <> 0 BEGIN
			IF @order_type =  'NP' 
				SELECT @order_nbr = [ORDER_NBR] FROM NEWSPAPER_HEADER WHERE [LINK_ID] = @link_id
			ELSE IF @order_type =  'MA' 
				SELECT @order_nbr = [ORDER_NBR] FROM MAGAZINE_HEADER WHERE [LINK_ID] = @link_id
			ELSE IF @order_type =  'IN' 
				SELECT @order_nbr = [ORDER_NBR] FROM INTERNET_HEADER WHERE [LINK_ID] = @link_id
			ELSE IF @order_type =  'OD' 
				SELECT @order_nbr = [ORDER_NBR] FROM OUTDOOR_HEADER WHERE [LINK_ID] = @link_id
			ELSE IF @order_type =  'TV' 
				SELECT @order_nbr = [ORDER_NBR] FROM TV_HDR WHERE [LINK_ID] = @link_id
			ELSE IF @order_type =  'RA' 
				SELECT @order_nbr = [ORDER_NBR] FROM RADIO_HDR WHERE [LINK_ID] = @link_id

			IF COALESCE(@order_nbr, 0) = 0 BEGIN
				SET @error_msg_w = 'Unable to identify the existing Order Number with the Link ID.'
				GOTO ERROR_MSG	
			END			
		END
	END
	ELSE BEGIN
		IF @order_type =  'NP' 
			SELECT @ok = (SELECT 1 FROM NEWSPAPER_HEADER WHERE ORDER_NBR = @order_nbr AND MEDIA_TYPE = @media_type)
		ELSE IF @order_type =  'MA' 
			SELECT @ok = (SELECT 1 FROM MAGAZINE_HEADER WHERE ORDER_NBR = @order_nbr AND MEDIA_TYPE = @media_type)
		ELSE IF @order_type =  'IN' 
			SELECT @ok = (SELECT 1 FROM INTERNET_HEADER WHERE ORDER_NBR = @order_nbr AND MEDIA_TYPE = @media_type)
		ELSE IF @order_type =  'OD' 
			SELECT @ok = (SELECT 1 FROM OUTDOOR_HEADER WHERE ORDER_NBR = @order_nbr AND MEDIA_TYPE = @media_type)
		ELSE IF @order_type =  'TV' 
			SELECT @ok = (SELECT 1 FROM TV_HDR WHERE ORDER_NBR = @order_nbr AND MEDIA_TYPE = @media_type)
		ELSE IF @order_type =  'RA' 
			SELECT @ok = (SELECT 1 FROM RADIO_HDR WHERE ORDER_NBR = @order_nbr AND MEDIA_TYPE = @media_type)

		IF @ok <> 1 BEGIN
			SET @error_msg_w = 'Invalid Order Number supplied for an Update process.'
		GOTO ERROR_MSG	
END
	END
END

--SELECT 'BEGIN'

SELECT @ok = (SELECT 1 FROM SALES_CLASS WHERE SC_CODE = @media_type)
IF @ok <> 1 BEGIN
	SET @error_msg_w = 'Invalid Sales Class Code.'
	GOTO ERROR_MSG	
END

SELECT @ok = (SELECT 1 FROM VENDOR WHERE VN_CODE = @vn_code)
IF @ok <> 1 BEGIN
	SET @error_msg_w = 'Invalid Vendor Code.'
	GOTO ERROR_MSG	
END

IF @order_date IS NOT NULL
	IF ISDATE(@order_date) = 1 AND (@order_date BETWEEN '01/01/2005' AND '01/01/2079')
		SET @error_msg_w = 'Good Order Date.'
	ELSE BEGIN
		SET @error_msg_w = 'Invalid Order Date.'
		GOTO ERROR_MSG	
	END
ELSE
	SET @order_date = GETDATE()
	
IF @order_desc IS NULL BEGIN
	SET @error_msg_w = 'Missing Order Description.'
	GOTO ERROR_MSG	
END

IF @cmp_identifier IS NULL BEGIN
	SELECT @cmp_identifier = CMP_IDENTIFIER
	  FROM CAMPAIGN
	 WHERE CL_CODE = @cl_code
	   AND ( DIV_CODE = @div_code OR DIV_CODE IS NULL )
	   AND ( PRD_CODE = @prd_code OR PRD_CODE IS NULL )
	   AND CMP_CODE = @cmp_code
END

--SELECT @cmp_identifier '@cmp_identifier', @cmp_code '@cmp_code', @cl_code '@cl_code', @div_code '@div_code', @prd_code '@prd_code'  /* DEBUG */
	
SET @modified_date = GETDATE() -- CURDATE()
SET @create_date = @modified_date

--SELECT @order_nbr '@order_nbr', @status ' @status', @action '@action'

IF @action = 'NEW' BEGIN
	--SET @pub_station = 1 /* Mail To Vendor by default */ /* PJH 02/08/16 - Do not default Pub/Station mail-to here... pass in from calling proc */
	IF @order_type =  'NP'

		INSERT INTO [dbo].[NEWSPAPER_HEADER]
				   ([ORDER_NBR]			--x
				   ,[ORDER_DESC]			--*x
				   ,[CL_CODE]				--*x
				   ,[DIV_CODE]				--*x
				   ,[PRD_CODE]				--*x
				   ,[OFFICE_CODE]			--x
				   ,[CMP_CODE]				--*
				   ,[MEDIA_TYPE]			--*x
				   ,[VN_CODE]				--*x
				   ,[VR_CODE]				--*
				   ,[VR_CODE2]				--*
				   ,[CLIENT_PO]				--*
				   ,[CLIENT_REF]
				   ,[STATUS]
				   ,[ORDER_DATE]			--x
				   ,[BUYER]					--*
				   ,[ORDER_COMMENT]	--*
				   ,[HOUSE_COMMENT]
				   ,[PUB]
				   ,[REP1]
				   ,[REP2]
				   ,[BILL_COOP_CODE]
				   ,[ORD_PROCESS_CONTRL]
				   ,[MARKET_CODE]		--*
				   --,[START_DATE]
				   --,[END_DATE]
				   ,[UNITS]						--x
				   ,[NBR_OF_UNITS]
				   ,[NET_GROSS]			--*x
				   ,[CREATE_DATE]			--x
				   ,[USER_ID]					--x
				   ,[CANCELLED]
				   ,[CANCELLED_BY]
				   ,[CANCELLED_DATE]
				   ,[MODIFIED_BY]			--x
				   ,[MODIFIED_DATE]		--x
				   ,[MODIFIED_COMMENTS]
				   ,[REVISED_FLAG]
				   ,[LINK_ID]					--*
				   ,[RECONCILE_FLAG]
				   ,[CMP_IDENTIFIER]
				   ,[PRINTED]
				   ,[ORDER_ACCEPTED]
				   ,[FISCAL_PERIOD_CODE]
				   ,[LOCKED]
				   ,[LOCKED_BY]
				   ,[BUYER_EMP_CODE] ) /* PJH 02/10/17 */
			 VALUES
				   (@order_nbr
				   ,@order_desc
				   ,@cl_code
				   ,@div_code
				   ,@prd_code
				   ,@office_code
				   ,@cmp_code
				   ,@media_type
				   ,@vn_code
				   ,@vr_code
				   ,@vr_code2
				   ,@client_po
				   ,@client_ref
				   ,@status
				   ,@order_date
				   ,@buyer
				   ,@order_comment
				   ,@house_comment
				   ,@pub_station
				   ,@rep1
				   ,@rep2
				   ,@bill_coop_code
				   ,1
				   ,@market_code
				   --,@start_date
				   --,@end_date
				   ,@units
				   ,@nbr_of_units
				   ,@net_gross
				   ,@create_date
				   ,@user_id
				   ,@cancelled
				   ,@cancelled_by
				   ,@cancelled_date
				   ,@modified_by
				   ,@modified_date
				   ,@modified_comments
				   ,@revised_flag
				   ,@link_id
				   ,@reconcile_flag
				   ,@cmp_identifier
				   ,@printed
				   ,@order_accepted
				   ,@fiscal_period_code
				   ,@locked
				   ,@locked_by
				   ,@buyer_emp_code  ) /* PJH 02/10/17 */
	ELSE IF @order_type =  'MA'
		INSERT INTO [dbo].[MAGAZINE_HEADER]
				   ([ORDER_NBR]			--x
				   ,[ORDER_DESC]			--*x
				   ,[CL_CODE]				--*x
				   ,[DIV_CODE]				--*x
				   ,[PRD_CODE]				--*x
				   ,[OFFICE_CODE]			--x
				   ,[CMP_CODE]				--*
				   ,[MEDIA_TYPE]			--*x
				   ,[VN_CODE]				--*x
				   ,[VR_CODE]				--*
				   ,[VR_CODE2]				--*
				   ,[CLIENT_PO]				--*
				   ,[CLIENT_REF]
				   ,[STATUS]
				   ,[ORDER_DATE]			--x
				   ,[BUYER]					--*
				   ,[ORDER_COMMENT]	--*
				   ,[HOUSE_COMMENT]
				   ,[PUB]
				   ,[REP1]
				   ,[REP2]
				   ,[BILL_COOP_CODE]
				   ,[ORD_PROCESS_CONTRL]
				   ,[MARKET_CODE]		--*
				   ,[START_DATE]
				   ,[END_DATE]
				   ,[UNITS]						--x
				   ,[NBR_OF_UNITS]
				   ,[NET_GROSS]			--*x
				   ,[CREATE_DATE]			--x
				   ,[USER_ID]					--x
				   ,[CANCELLED]
				   ,[CANCELLED_BY]
				   ,[CANCELLED_DATE]
				   ,[MODIFIED_BY]			--x
				   ,[MODIFIED_DATE]		--x
				   ,[MODIFIED_COMMENTS]
				   ,[REVISED_FLAG]
				   ,[LINK_ID]					--*
				   ,[RECONCILE_FLAG]
				   ,[CMP_IDENTIFIER]
				   ,[PRINTED]
				   --,[START_DATE]
				   --,[END_DATE]
				   ,[ORDER_ACCEPTED]
				   ,[FISCAL_PERIOD_CODE]
				   ,[LOCKED]
				   ,[LOCKED_BY]
				   ,[BUYER_EMP_CODE] ) /* PJH 02/10/17 */
			 VALUES
				   (@order_nbr
				   ,@order_desc
				   ,@cl_code
				   ,@div_code
				   ,@prd_code
				   ,@office_code
				   ,@cmp_code
				   ,@media_type
				   ,@vn_code
				   ,@vr_code
				   ,@vr_code2
				   ,@client_po
				   ,@client_ref
				   ,@status
				   ,@order_date
				   ,@buyer
				   ,@order_comment
				   ,@house_comment
				   ,@pub_station
				   ,@rep1
				   ,@rep2
				   ,@bill_coop_code
				   ,1
				   ,@market_code
				   ,@start_date
				   ,@end_date
				   ,@units
				   ,@nbr_of_units
				   ,@net_gross
				   ,@create_date
				   ,@user_id
				   ,@cancelled
				   ,@cancelled_by
				   ,@cancelled_date
				   ,@modified_by
				   ,@modified_date
				   ,@modified_comments
				   ,@revised_flag
				   ,@link_id
				   ,@reconcile_flag
				   ,@cmp_identifier
				   ,@printed
				   --,@start_date
				   --,@end_date
				   ,@order_accepted
				   ,@fiscal_period_code
				   ,@locked
				   ,@locked_by
				   ,@buyer_emp_code  ) /* PJH 02/10/17 */
	ELSE IF @order_type =  'IN'
		INSERT INTO [dbo].[INTERNET_HEADER]
				   ([ORDER_NBR]
				   ,[ORDER_DESC]
				   ,[CL_CODE]
				   ,[DIV_CODE]
				   ,[PRD_CODE]
				   ,[OFFICE_CODE]
				   ,[CMP_CODE]
				   ,[MEDIA_TYPE]
				   ,[VN_CODE]
				   ,[VR_CODE]
				   ,[VR_CODE2]
				   ,[CLIENT_PO]
				   ,[CLIENT_REF]
				   ,[STATUS]
				   ,[ORDER_DATE]
				   ,[BUYER]
				   ,[ORDER_COMMENT]
				   ,[HOUSE_COMMENT]
				   ,[PUB]
				   ,[REP1]
				   ,[REP2]
				   ,[BILL_COOP_CODE]
				   ,[ORD_PROCESS_CONTRL]
				   ,[MARKET_CODE]
				   ,[UNITS]
				   ,[NET_GROSS]
				   ,[CREATE_DATE]
				   ,[USER_ID]
				   ,[CANCELLED]
				   ,[CANCELLED_BY]
				   ,[CANCELLED_DATE]
				   ,[MODIFIED_BY]
				   ,[MODIFIED_DATE]
				   ,[MODIFIED_COMMENTS]
				   ,[REVISED_FLAG]
				   ,[LINK_ID]
				   ,[RECONCILE_FLAG]
				   ,[CMP_IDENTIFIER]
				   ,[PRINTED]
				   --,[START_DATE]
				   --,[END_DATE]
				   ,[ORDER_ACCEPTED]
				   ,[FISCAL_PERIOD_CODE]
				   ,[LOCKED]
				   ,[LOCKED_BY]
				   ,[BUYER_EMP_CODE] ) /* PJH 02/10/17 */
			 VALUES
				   (@order_nbr
				   ,@order_desc
				   ,@cl_code
				   ,@div_code
				   ,@prd_code
				   ,@office_code
				   ,@cmp_code
				   ,@media_type
				   ,@vn_code
				   ,@vr_code
				   ,@vr_code2
				   ,@client_po
				   ,@client_ref
				   ,@status
				   ,@order_date
				   ,@buyer
				   ,@order_comment
				   ,@house_comment
				   ,@pub_station
				   ,@rep1
				   ,@rep2
				   ,@bill_coop_code
				   ,1
				   ,@market_code
				   ,@units
				   ,@net_gross
				   ,@create_date
				   ,@user_id
				   ,@cancelled
				   ,@cancelled_by
				   ,@cancelled_date
				   ,@modified_by
				   ,@modified_date
				   ,@modified_comments
				   ,@revised_flag
				   ,@link_id
				   ,@reconcile_flag
				   ,@cmp_identifier
				   ,@printed
				   --,@start_date
				   --,@end_date
				   ,@order_accepted
				   ,@fiscal_period_code
				   ,@locked
				   ,@locked_by
				   ,@buyer_emp_code  ) /* PJH 02/10/17 */
	ELSE IF @order_type =  'OD'
		INSERT INTO [dbo].[OUTDOOR_HEADER]
				   ([ORDER_NBR]
				   ,[ORDER_DESC]
				   ,[CL_CODE]
				   ,[DIV_CODE]
				   ,[PRD_CODE]
				   ,[OFFICE_CODE]
				   ,[CMP_CODE]
				   ,[MEDIA_TYPE]
				   ,[VN_CODE]
				   ,[VR_CODE]
				   ,[VR_CODE2]
				   ,[CLIENT_PO]
				   ,[CLIENT_REF]
				   ,[STATUS]
				   ,[ORDER_DATE]
				   ,[BUYER]
				   ,[ORDER_COMMENT]
				   ,[HOUSE_COMMENT]
				   ,[PUB]
				   ,[REP1]
				   ,[REP2]
				   ,[BILL_COOP_CODE]
				   ,[ORD_PROCESS_CONTRL]
				   ,[MARKET_CODE]
				   ,[UNITS]
				   ,[NET_GROSS]
				   ,[CREATE_DATE]
				   ,[USER_ID]
				   ,[CANCELLED]
				   ,[CANCELLED_BY]
				   ,[CANCELLED_DATE]
				   ,[MODIFIED_BY]
				   ,[MODIFIED_DATE]
				   ,[MODIFIED_COMMENTS]
				   ,[REVISED_FLAG]
				   ,[LINK_ID]
				   ,[RECONCILE_FLAG]
				   ,[CMP_IDENTIFIER]
				   ,[PRINTED]
				   --,[START_DATE]
				   --,[END_DATE]
				   ,[ORDER_ACCEPTED]
				   ,[FISCAL_PERIOD_CODE]
				   ,[LOCKED]
				   ,[LOCKED_BY]
				   ,[BUYER_EMP_CODE] ) /* PJH 02/10/17 */
			 VALUES
				   (@order_nbr
				   ,@order_desc
				   ,@cl_code
				   ,@div_code
				   ,@prd_code
				   ,@office_code
				   ,@cmp_code
				   ,@media_type
				   ,@vn_code
				   ,@vr_code
				   ,@vr_code2
				   ,@client_po
				   ,@client_ref
				   ,@status
				   ,@order_date
				   ,@buyer
				   ,@order_comment
				   ,@house_comment
				   ,@pub_station
				   ,@rep1
				   ,@rep2
				   ,@bill_coop_code
				   ,1
				   ,@market_code
				   ,@units
				   ,@net_gross
				   ,@create_date
				   ,@user_id
				   ,@cancelled
				   ,@cancelled_by
				   ,@cancelled_date
				   ,@modified_by
				   ,@modified_date
				   ,@modified_comments
				   ,@revised_flag
				   ,@link_id
				   ,@reconcile_flag
				   ,@cmp_identifier
				   ,@printed
				   --,@start_date
				   --,@end_date
				   ,@order_accepted
				   ,@fiscal_period_code
				   ,@locked
				   ,@locked_by
				   ,@buyer_emp_code  ) /* PJH 02/10/17 */
	ELSE IF @order_type =  'TV'
		INSERT INTO [dbo].[TV_HDR]
				   ([ORDER_NBR]
				   ,[ORDER_DESC]
				   ,[CL_CODE]
				   ,[DIV_CODE]
				   ,[PRD_CODE]
				   ,[OFFICE_CODE]
				   ,[CMP_CODE]
				   ,[MEDIA_TYPE]
				   ,[VN_CODE]
				   ,[VR_CODE]
				   ,[VR_CODE2]
				   ,[CLIENT_PO]
				   ,[CLIENT_REF]
				   ,[STATUS]
				   ,[ORDER_DATE]
				   ,[BUYER]
				   ,[ORDER_COMMENT]
				   ,[HOUSE_COMMENT]
				   ,[STATION]
				   ,[REP1]
				   ,[REP2]
				   ,[BILL_COOP_CODE]
				   ,[ORD_PROCESS_CONTRL]
				   ,[MARKET_CODE]
				   ,[UNITS]
				   ,[NET_GROSS]
				   ,[CREATE_DATE]
				   ,[USER_ID]
				   ,[CANCELLED]
				   ,[CANCELLED_BY]
				   ,[CANCELLED_DATE]
				   ,[MODIFIED_BY]
				   ,[MODIFIED_DATE]
				   ,[MODIFIED_COMMENTS]
				   ,[REVISED_FLAG]
				   ,[LINK_ID]
				   ,[RECONCILE_FLAG]
				   ,[CMP_IDENTIFIER]
				   ,[PRINTED]
				   --,[START_DATE]
				   --,[END_DATE]
				   ,[ORDER_ACCEPTED]
				   ,[FISCAL_PERIOD_CODE]
				   ,[LOCKED]
				   ,[LOCKED_BY]
				   ,[BUYER_EMP_CODE] ) /* PJH 02/10/17 */
			 VALUES
				   (@order_nbr
				   ,@order_desc
				   ,@cl_code
				   ,@div_code
				   ,@prd_code
				   ,@office_code
				   ,@cmp_code
				   ,@media_type
				   ,@vn_code
				   ,@vr_code
				   ,@vr_code2
				   ,@client_po
				   ,@client_ref
				   ,@status
				   ,@order_date
				   ,@buyer
				   ,@order_comment
				   ,@house_comment
				   ,@pub_station
				   ,@rep1
				   ,@rep2
				   ,@bill_coop_code
				   ,1
				   ,@market_code
				   ,@units
				   ,@net_gross
				   ,@create_date
				   ,@user_id
				   ,@cancelled
				   ,@cancelled_by
				   ,@cancelled_date
				   ,@modified_by
				   ,@modified_date
				   ,@modified_comments
				   ,@revised_flag
				   ,@link_id
				   ,@reconcile_flag
				   ,@cmp_identifier
				   ,@printed
				   --,@start_date
				   --,@end_date
				   ,@order_accepted
				   ,@fiscal_period_code
				   ,@locked
				   ,@locked_by
				   ,@buyer_emp_code  ) /* PJH 02/10/17 */
	ELSE IF @order_type =  'RA'
		INSERT INTO [dbo].[RADIO_HDR]
				   ([ORDER_NBR]
				   ,[ORDER_DESC]
				   ,[CL_CODE]
				   ,[DIV_CODE]
				   ,[PRD_CODE]
				   ,[OFFICE_CODE]
				   ,[CMP_CODE]
				   ,[MEDIA_TYPE]
				   ,[VN_CODE]
				   ,[VR_CODE]
				   ,[VR_CODE2]
				   ,[CLIENT_PO]
				   ,[CLIENT_REF]
				   ,[STATUS]
				   ,[ORDER_DATE]
				   ,[BUYER]
				   ,[ORDER_COMMENT]
				   ,[HOUSE_COMMENT]
				   ,[STATION]
				   ,[REP1]
				   ,[REP2]
				   ,[BILL_COOP_CODE]
				   ,[ORD_PROCESS_CONTRL]
				   ,[MARKET_CODE]
				   ,[UNITS]
				   ,[NET_GROSS]
				   ,[CREATE_DATE]
				   ,[USER_ID]
				   ,[CANCELLED]
				   ,[CANCELLED_BY]
				   ,[CANCELLED_DATE]
				   ,[MODIFIED_BY]
				   ,[MODIFIED_DATE]
				   ,[MODIFIED_COMMENTS]
				   ,[REVISED_FLAG]
				   ,[LINK_ID]
				   ,[RECONCILE_FLAG]
				   ,[CMP_IDENTIFIER]
				   ,[PRINTED]
				   --,[START_DATE]
				   --,[END_DATE]
				   ,[ORDER_ACCEPTED]
				   ,[FISCAL_PERIOD_CODE]
				   ,[LOCKED]
				   ,[LOCKED_BY]
				   ,[BUYER_EMP_CODE] ) /* PJH 02/10/17 */
			 VALUES
				   (@order_nbr
				   ,@order_desc
				   ,@cl_code
				   ,@div_code
				   ,@prd_code
				   ,@office_code
				   ,@cmp_code
				   ,@media_type
				   ,@vn_code
				   ,@vr_code
				   ,@vr_code2
				   ,@client_po
				   ,@client_ref
				   ,@status
				   ,@order_date
				   ,@buyer
				   ,@order_comment
				   ,@house_comment
				   ,@pub_station
				   ,@rep1
				   ,@rep2
				   ,@bill_coop_code
				   ,1
				   ,@market_code
				   ,@units
				   ,@net_gross
				   ,@create_date
				   ,@user_id
				   ,@cancelled
				   ,@cancelled_by
				   ,@cancelled_date
				   ,@modified_by
				   ,@modified_date
				   ,@modified_comments
				   ,@revised_flag
				   ,@link_id
				   ,@reconcile_flag
				   ,@cmp_identifier
				   ,@printed
				   --,@start_date
				   --,@end_date
				   ,@order_accepted
				   ,@fiscal_period_code
				   ,@locked
				   ,@locked_by
				   ,@buyer_emp_code  ) /* PJH 02/10/17 */
END
ELSE BEGIN /* UPDATE */
	IF @order_type =  'NP'
		UPDATE [dbo].[NEWSPAPER_HEADER]
		SET	    [ORDER_DESC]			= @order_desc
			   ,[CMP_CODE]				= @cmp_code
			   ,[CMP_IDENTIFIER]		= @cmp_identifier
			   ,[VR_CODE]				= @vr_code
			   ,[VR_CODE2]				= @vr_code2
			   ,[CLIENT_PO]				= @client_po
			   ,[STATUS]				= @status
			   ,[ORDER_DATE]			= @order_date
			   ,[BUYER]					= @buyer
			   ,[ORDER_COMMENT]			= @order_comment
			   ,[HOUSE_COMMENT]			= @house_comment
			   ,[PUB]					= @pub_station
			   ,[REP1]					= @rep1
			   ,[REP2]					= @rep2
			   ,[BILL_COOP_CODE]		= @bill_coop_code
			   ,[ORD_PROCESS_CONTRL]	= @ord_process_contrl
			   ,[MARKET_CODE]			= @market_code
			   ,[UNITS]					= @units
			   ,[NET_GROSS]				= @net_gross
			   ,[MODIFIED_BY]			= @user_id
			   ,[MODIFIED_DATE]			= @modified_date
			   ,[MODIFIED_COMMENTS]		= @modified_comments
			   ,[REVISED_FLAG]		= @revised_flag  /* PJH 06/10/16 */
			   ,[BUYER_EMP_CODE]		= @buyer_emp_code  /* MJC 01/16/17 */
			   ,[CLIENT_REF]			= @client_ref /* PJH 05/16/19 */
			   ,[FISCAL_PERIOD_CODE]	= @fiscal_period_code
		WHERE [ORDER_NBR] = @order_nbr
	ELSE IF @order_type =  'MA'
		UPDATE [dbo].[MAGAZINE_HEADER]
		SET	    [ORDER_DESC]			= @order_desc
			   ,[CMP_CODE]				= @cmp_code
			   ,[CMP_IDENTIFIER]		= @cmp_identifier
			   ,[VR_CODE]				= @vr_code
			   ,[VR_CODE2]				= @vr_code2
			   ,[CLIENT_PO]				= @client_po
			   ,[STATUS]				= @status
			   ,[ORDER_DATE]			= @order_date
			   ,[BUYER]					= @buyer
			   ,[ORDER_COMMENT]			= @order_comment
			   ,[HOUSE_COMMENT]			= @house_comment
			   ,[PUB]					= @pub_station
			   ,[REP1]					= @rep1
			   ,[REP2]					= @rep2
			   ,[BILL_COOP_CODE]		= @bill_coop_code
			   ,[ORD_PROCESS_CONTRL]	= @ord_process_contrl
			   ,[MARKET_CODE]			= @market_code
			   ,[UNITS]					= @units
			   ,[NET_GROSS]				= @net_gross
			   ,[MODIFIED_BY]			= @user_id
			   ,[MODIFIED_DATE]			= @modified_date
			   ,[MODIFIED_COMMENTS]		= @modified_comments
			   ,[REVISED_FLAG]		= @revised_flag  /* PJH 06/10/16 */
			   ,[BUYER_EMP_CODE]		= @buyer_emp_code  /* MJC 01/16/17 */
			   ,[CLIENT_REF]			= @client_ref /* PJH 05/16/19 */
			   ,[FISCAL_PERIOD_CODE]	= @fiscal_period_code
		WHERE [ORDER_NBR] = @order_nbr
	ELSE IF @order_type =  'IN'
		UPDATE [dbo].[INTERNET_HEADER]
		SET	    [ORDER_DESC]			= @order_desc
			   ,[CMP_CODE]				= @cmp_code
			   ,[CMP_IDENTIFIER]		= @cmp_identifier
			   ,[VR_CODE]				= @vr_code
			   ,[VR_CODE2]				= @vr_code2
			   ,[CLIENT_PO]				= @client_po
			   ,[STATUS]				= @status
			   ,[ORDER_DATE]			= @order_date
			   ,[BUYER]					= @buyer
			   ,[ORDER_COMMENT]			= @order_comment
			   ,[HOUSE_COMMENT]			= @house_comment
			   ,[PUB]					= @pub_station
			   ,[REP1]					= @rep1
			   ,[REP2]					= @rep2
			   ,[BILL_COOP_CODE]		= @bill_coop_code
			   ,[ORD_PROCESS_CONTRL]	= @ord_process_contrl
			   ,[MARKET_CODE]			= @market_code
			   ,[UNITS]					= @units
			   ,[NET_GROSS]				= @net_gross
			   ,[MODIFIED_BY]			= @user_id
			   ,[MODIFIED_DATE]			= @modified_date
			   ,[MODIFIED_COMMENTS]		= @modified_comments
			   ,[REVISED_FLAG]		= @revised_flag  /* PJH 06/10/16 */
			   ,[BUYER_EMP_CODE]		= @buyer_emp_code  /* MJC 01/16/17 */
			   ,[CLIENT_REF]			= @client_ref /* PJH 05/16/19 */
			   ,[FISCAL_PERIOD_CODE]	= @fiscal_period_code
		WHERE [ORDER_NBR] = @order_nbr
	ELSE IF @order_type =  'OD'
		UPDATE [dbo].[OUTDOOR_HEADER]
		SET	    [ORDER_DESC]			= @order_desc
			   ,[CMP_CODE]				= @cmp_code
			   ,[CMP_IDENTIFIER]		= @cmp_identifier
			   ,[VR_CODE]				= @vr_code
			   ,[VR_CODE2]				= @vr_code2
			   ,[CLIENT_PO]				= @client_po
			   ,[STATUS]				= @status
			   ,[ORDER_DATE]			= @order_date
			   ,[BUYER]					= @buyer
			   ,[ORDER_COMMENT]			= @order_comment
			   ,[HOUSE_COMMENT]			= @house_comment
			   ,[PUB]					= @pub_station
			   ,[REP1]					= @rep1
			   ,[REP2]					= @rep2
			   ,[BILL_COOP_CODE]		= @bill_coop_code
			   ,[ORD_PROCESS_CONTRL]	= @ord_process_contrl
			   ,[MARKET_CODE]			= @market_code
			   ,[UNITS]					= @units
			   ,[NET_GROSS]				= @net_gross
			   ,[MODIFIED_BY]			= @user_id
			   ,[MODIFIED_DATE]			= @modified_date
			   ,[MODIFIED_COMMENTS]		= @modified_comments
			   ,[REVISED_FLAG]		= @revised_flag  /* PJH 06/10/16 */
			   ,[BUYER_EMP_CODE]		= @buyer_emp_code  /* MJC 01/16/17 */
			   ,[CLIENT_REF]			= @client_ref /* PJH 05/16/19 */
			   ,[FISCAL_PERIOD_CODE]	= @fiscal_period_code
		WHERE [ORDER_NBR] = @order_nbr
	ELSE IF @order_type =  'TV'
		UPDATE [dbo].[TV_HDR]
		SET	    [ORDER_DESC]			= @order_desc
			   ,[CMP_CODE]				= @cmp_code
			   ,[CMP_IDENTIFIER]		= @cmp_identifier
			   ,[VR_CODE]				= @vr_code
			   ,[VR_CODE2]				= @vr_code2
			   ,[CLIENT_PO]				= @client_po
			   ,[STATUS]				= @status
			   ,[ORDER_DATE]			= @order_date
			   ,[BUYER]					= @buyer
			   ,[ORDER_COMMENT]			= @order_comment
			   ,[HOUSE_COMMENT]			= @house_comment
			   ,[STATION]				= @pub_station
			   ,[REP1]					= @rep1
			   ,[REP2]					= @rep2
			   ,[BILL_COOP_CODE]		= @bill_coop_code
			   ,[ORD_PROCESS_CONTRL]	= @ord_process_contrl
			   ,[MARKET_CODE]			= @market_code
			   ,[UNITS]					= @units
			   ,[NET_GROSS]				= @net_gross
			   ,[MODIFIED_BY]			= @user_id
			   ,[MODIFIED_DATE]			= @modified_date
			   ,[MODIFIED_COMMENTS]		= @modified_comments
			   ,[REVISED_FLAG]		= @revised_flag  /* PJH 06/10/16 */
			   ,[BUYER_EMP_CODE]		= @buyer_emp_code  /* MJC 01/16/17 */
			   ,[CLIENT_REF]			= @client_ref /* PJH 05/16/19 */
			   ,[FISCAL_PERIOD_CODE]	= @fiscal_period_code
		WHERE [ORDER_NBR] = @order_nbr
	ELSE IF @order_type =  'RA'
		UPDATE [dbo].[RADIO_HDR]
		SET	    [ORDER_DESC]			= @order_desc
			   ,[CMP_CODE]				= @cmp_code
			   ,[CMP_IDENTIFIER]		= @cmp_identifier
			   ,[VR_CODE]				= @vr_code
			   ,[VR_CODE2]				= @vr_code2
			   ,[CLIENT_PO]				= @client_po
			   ,[STATUS]				= @status
			   ,[ORDER_DATE]			= @order_date
			   ,[BUYER]					= @buyer
			   ,[ORDER_COMMENT]			= @order_comment
			   ,[HOUSE_COMMENT]			= @house_comment
			   ,[STATION]				= @pub_station
			   ,[REP1]					= @rep1
			   ,[REP2]					= @rep2
			   ,[BILL_COOP_CODE]		= @bill_coop_code
			   ,[ORD_PROCESS_CONTRL]	= @ord_process_contrl
			   ,[MARKET_CODE]			= @market_code
			   ,[UNITS]					= @units
			   ,[NET_GROSS]				= @net_gross
			   ,[MODIFIED_BY]			= @user_id
			   ,[MODIFIED_DATE]			= @modified_date
			   ,[MODIFIED_COMMENTS]		= @modified_comments
			   ,[REVISED_FLAG]		= @revised_flag  /* PJH 06/10/16 */
			   ,[BUYER_EMP_CODE]		= @buyer_emp_code  /* MJC 01/16/17 */
			   ,[CLIENT_REF]			= @client_ref /* PJH 05/16/19 */
			   ,[FISCAL_PERIOD_CODE]	= @fiscal_period_code
		WHERE [ORDER_NBR] = @order_nbr
END	

--IF @@TRANCOUNT > 0 BEGIN
--	SELECT 'HEADER COMMIT', @@TRANCOUNT '@@TRANCOUNT'
--	--COMMIT TRAN TH1
--END

/**************************** THE END **********************************************************************************/	
GOTO ENDIT		   
           
/**************************** ERROR PROCESSING ************************************************************************/	
	ERROR_MSG:
		BEGIN
		
			--ROLLBACK TRAN			
			--SELECT @error_msg_w as ErrorMessage;
			
			SELECT 'HEADER ERROR CONTROL'  /* DEBUG */	
			
			RAISERROR (@error_msg_w,
			 16,
			 1 )    
			
		END

	ENDIT: --Do Nothing
		SET @ret_val_s = 'No Error from Hdr'

END TRY 

/*************************** END TRY ***********************************************************************************/

BEGIN CATCH


	IF @@TRANCOUNT > 0 BEGIN
		SELECT 'HEADER ERROR ROLLBACK'  /* DEBUG */	
		--ROLLBACK TRAN TH1
	END
	
	--ERROR_NUMBER() as ErrorNumber,
	--SELECT ERROR_MESSAGE() as ErrorMessage;
	   
	SELECT 	@ErMessage = ERROR_MESSAGE(),
					@ErSeverity = ERROR_SEVERITY(),
					@ErState = ERROR_STATE();
	
	SELECT 	@ErMessage 'ERROR_MESSAGE',	@ErSeverity 'ERROR_SEVERITY', @ErState 'ERROR_SATE'   /* DEBUG */	
	
	SET @ret_val = -1
	SET @ret_val_s = @ErMessage

END CATCH

RETURN
GO


