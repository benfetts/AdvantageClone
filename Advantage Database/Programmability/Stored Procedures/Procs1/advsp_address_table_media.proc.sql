

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_address_table_media]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_address_table_media]
GO

SET ANSI_NULLS ON
GO

SET ANSI_PADDING OFF
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_address_table_media] @one_time tinyint, @address_flag_overide tinyint = 3, 
	@list_option tinyint, @list varchar(max), @std_vs_cus tinyint, @user_code varchar(100)
	
-- advsp_address_table v660 =======================================================
-- #00 09/09/19 - Copied from [] (version #03) 
-- Note: the only difference from production is populating table #ar_client_codes
-- #01 09/23/09 - Corrected code, not executing properly
-- #02 03/03/11 - replaced CL_ATTENTION with CL_MATTENTION for client level addresses
-- #03 07/27/11 - redim @ar_inv_list varchar(4000) to @ar_inv_list varchar(max)
-- #04 09/28/11 - added data extractions from RADIO_HDR and TV_HDR for new bcst
-- #05 06/12/13 - modified to use AR_FUNCTION for draft invoices
-- #06 07/31/14 - modified #ar_client_codes to correctly filter list based on BILLING_USER - see ar_address_table (735-1311)

-- @one_time: 0=No, 1=Yes
-- @address_flag_overide: (overide value if @one_time=1, see below for possible values)
-- @address_flag_overide: 1=Client Address, 2=Division Address, 3=Product Address, 4=Product Contact Address
-- @list_option: 0=AR Invoice List, 1=Billing User List
-- @list: concatenated string of values based on @list_option
-- @std_vs_cus: 0=Standard, 1=Custom
-- @user_code: user id to extract ORDER_NBR's from MEDIA_RPT_ORDERS
-- Note: @name_overide: not used, always set to (1) for no overide, included for consistency with production

AS
SET NOCOUNT ON

-- Identify the current Advantage user
DECLARE @user_id varchar(100)

IF ISNULL(@user_code, '') > '' BEGIN
	SET @user_id = UPPER(@user_code)
END
ELSE BEGIN
	SET @user_id = ''
	--SELECT @user_id = UPPER(dbo.78())
END

--SELECT @user_id

DECLARE @name_overide tinyint
SET @name_overide = 1			--set to no overide

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================--Creates address table
CREATE TABLE #Address_Table(
	[Client]					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Division]					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Product]					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Product Contact]			varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Cl Name]					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Dv Name]					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Pr Name]					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Address1]					varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Address2]					varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[City]						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[State]						varchar(15) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Zip]						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Attn]						varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Flag]						tinyint null,
	[County]					varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Country]					varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[ContactID]					smallint null)

-- ==========================================================
-- SECONDARY TABLES
-- ==========================================================
-- Temp table #media_orders - stores table of orders to be processed
CREATE TABLE #media_orders(
	[USER_ID]				varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR				int NULL,
	ORDER_TYPE				varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #media_orders
SELECT [USER_ID], ORDER_NBR, ORDER_TYPE
FROM dbo.MEDIA_RPT_ORDERS AS rd
WHERE UPPER(rd.[USER_ID]) = UPPER(@user_code)
--SELECT * FROM #media_orders--------------------------------

-- Temp table #order_type-------------------------------------
CREATE TABLE #order_type(ORDER_TYPE varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #order_type
SELECT DISTINCT ORDER_TYPE 
FROM #media_orders
--SELECT * FROM #order_type

-- Temp table to store client codes and address flag overide
CREATE TABLE #ar_client_codes(
	CL_CODE 						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ADDRESS_FLAG					tinyint,
	NAME_OVERIDE					tinyint)

-- ==========================================================
-- EXTRACTION ROUTINES
-- ==========================================================
-- Populate temp table #ar_client_codes
IF @list_option = 0		--AR Invoice List--------------------
	BEGIN
		INSERT INTO #ar_client_codes	
		SELECT DISTINCT 
			ar.CL_CODE,
			CASE @one_time
				WHEN 1 THEN @address_flag_overide
				ELSE dbo.fn_client_code_to_address_flag_media(ar.CL_CODE)
			END,
			@name_overide												
		FROM dbo.ACCT_REC ar
		JOIN fn_intlist_to_table(@list) l 
			ON ar.AR_INV_NBR = l.number
	END
ELSE					--Billing User List------------------- #05
	BEGIN
		INSERT INTO #ar_client_codes
		SELECT DISTINCT 
			f.CL_CODE,
			CASE @one_time
				WHEN 1 THEN @address_flag_overide
				ELSE dbo.fn_client_code_to_address_flag_media(f.CL_CODE)
			END,
			@name_overide
		FROM dbo.AR_FUNCTION AS f
		--WHERE f.BILLING_USER = @user_id										--#06
		JOIN fn_charlist_to_table2(@list) bu									--#06
			ON f.BILLING_USER COLLATE SQL_Latin1_General_CP1_CS_AS = bu.vstr	--#06
	END
--SELECT * FROM #ar_Client_Codes

-- Populate the main data table
-- Inserts all CDP addresses into #Address table for @client (given that an invoice can span multiple divisions and products)
INSERT INTO #Address_Table
	  SELECT DISTINCT
				cl.CL_CODE, 
				dv.DIV_CODE,
				pr.PRD_CODE,
				'ZZ' AS [Product Contact],
				[Cl Name] = CASE ac.NAME_OVERIDE
									WHEN 0 THEN cl.CL_NAME
									WHEN 1 THEN	cl.CL_NAME
									WHEN 2 THEN	dv.DIV_NAME
									WHEN 3 THEN	pr.PRD_DESCRIPTION
				END,
				[Dv Name] = CASE
									WHEN (cl.CL_NAME = dv.DIV_NAME) THEN NULL
									ELSE dv.DIV_NAME
				END,	
				[Pr Name] = CASE
									WHEN (dv.DIV_NAME = pr.PRD_DESCRIPTION) THEN NULL
									ELSE pr.PRD_DESCRIPTION
				END,
				[Address1] = CASE ac.ADDRESS_FLAG
									WHEN 1 THEN cl.CL_BADDRESS1
                                    WHEN 2 THEN dv.DIV_BADDRESS1
                                    WHEN 3 THEN pr.PRD_BILL_ADDRESS1
                                    WHEN 4 THEN pr.PRD_BILL_ADDRESS1
				END,
				[Address2] = CASE ac.ADDRESS_FLAG
									WHEN 1 THEN cl.CL_BADDRESS2
                                    WHEN 2 THEN dv.DIV_BADDRESS2
                                    WHEN 3 THEN pr.PRD_BILL_ADDRESS2
                                    WHEN 4 THEN pr.PRD_BILL_ADDRESS2
				END,
				[City] = CASE ac.ADDRESS_FLAG
									WHEN 1 THEN cl.CL_BCITY
                                    WHEN 2 THEN dv.DIV_BCITY
                                    WHEN 3 THEN pr.PRD_BILL_CITY
                                    WHEN 4 THEN pr.PRD_BILL_CITY
				END,
				[State] = CASE ac.ADDRESS_FLAG		
									WHEN 1 THEN cl.CL_BSTATE
									WHEN 2 THEN dv.DIV_BSTATE
									WHEN 3 THEN pr.PRD_BILL_STATE
									WHEN 4 THEN pr.PRD_BILL_STATE
				END,
				[Zip] = CASE ac.ADDRESS_FLAG		
									WHEN 1 THEN cl.CL_BZIP
									WHEN 2 THEN dv.DIV_BZIP
									WHEN 3 THEN pr.PRD_BILL_ZIP
									WHEN 4 THEN pr.PRD_BILL_ZIP
				END,
				[Attn] = CASE ac.ADDRESS_FLAG	
									WHEN 1 THEN cl.CL_MATTENTION
									WHEN 2 THEN dv.DIV_ATTENTION
									WHEN 3 THEN pr.PRD_ATTENTION
									WHEN 4 THEN pr.PRD_ATTENTION
				END,
				ac.ADDRESS_FLAG,
				[County] = CASE ac.ADDRESS_FLAG	
									WHEN 1 THEN cl.CL_BCOUNTY
									WHEN 2 THEN dv.DIV_BCOUNTY
									WHEN 3 THEN pr.PRD_BILL_COUNTY
									WHEN 4 THEN pr.PRD_BILL_COUNTY
				END,
				[Country] = CASE ac.ADDRESS_FLAG	
									WHEN 1 THEN cl.CL_BCOUNTRY
									WHEN 2 THEN dv.DIV_BCOUNTRY
									WHEN 3 THEN pr.PRD_BILL_COUNTRY
									WHEN 4 THEN pr.PRD_BILL_COUNTRY
				END,
				0	
 		FROM dbo.CLIENT AS cl
		JOIN #ar_client_codes ac
			ON cl.CL_CODE = ac.CL_CODE  
		JOIN dbo.DIVISION AS dv
			ON ( cl.CL_CODE = dv.CL_CODE )
		JOIN dbo.PRODUCT AS pr
			ON ( dv.DIV_CODE = pr.DIV_CODE )  
			AND ( dv.CL_CODE = pr.CL_CODE )

-- Inserts a record into address table for NULL [PRD_CODE] for @Client and @Division
--@Product IS NULL
BEGIN
INSERT INTO #Address_Table
	SELECT DISTINCT
			cl.CL_CODE,		
			dv.DIV_CODE,
			'ZZ' AS [Product],
			'ZZ' AS [Product Contact],
			[Cl Name] = CASE ac.NAME_OVERIDE
									WHEN 0 THEN cl.CL_NAME
									WHEN 1 THEN	cl.CL_NAME
									WHEN 2 THEN	dv.DIV_NAME
									WHEN 3 THEN	pr.PRD_DESCRIPTION
				END,
			[Dv Name] = CASE
									WHEN (cl.CL_NAME = dv.DIV_NAME) THEN NULL
									ELSE dv.DIV_NAME
				END,
			NULL AS [Pr Name],
				[Address1] = CASE
									WHEN ( ac.ADDRESS_FLAG = 1 ) THEN cl.CL_BADDRESS1
                                    WHEN ( ac.ADDRESS_FLAG = 2 ) THEN dv.DIV_BADDRESS1
                                    WHEN ( ac.ADDRESS_FLAG = 3 ) THEN dv.DIV_BADDRESS1
                                    WHEN ( ac.ADDRESS_FLAG = 4 ) THEN dv.DIV_BADDRESS1
				END,
				[Address2] = CASE
									WHEN ( ac.ADDRESS_FLAG = 1 ) THEN cl.CL_BADDRESS2
                                    WHEN ( ac.ADDRESS_FLAG = 2 ) THEN dv.DIV_BADDRESS2
                                    WHEN ( ac.ADDRESS_FLAG = 3 ) THEN dv.DIV_BADDRESS2
                                    WHEN ( ac.ADDRESS_FLAG = 4 ) THEN dv.DIV_BADDRESS2
				END,
				[City] = CASE
									WHEN ( ac.ADDRESS_FLAG = 1 ) THEN cl.CL_BCITY
                                    WHEN ( ac.ADDRESS_FLAG = 2 ) THEN dv.DIV_BCITY
                                    WHEN ( ac.ADDRESS_FLAG = 3 ) THEN dv.DIV_BCITY
                                    WHEN ( ac.ADDRESS_FLAG = 4 ) THEN dv.DIV_BCITY
				END,
				[State] = CASE		
									WHEN ( ac.ADDRESS_FLAG = 1 ) THEN cl.CL_BSTATE
									WHEN ( ac.ADDRESS_FLAG = 2 ) THEN dv.DIV_BSTATE
									WHEN ( ac.ADDRESS_FLAG = 3 ) THEN dv.DIV_BSTATE
									WHEN ( ac.ADDRESS_FLAG = 4 ) THEN dv.DIV_BSTATE
				END,
				[Zip] = CASE		
									WHEN ( ac.ADDRESS_FLAG = 1 ) THEN cl.CL_BZIP
									WHEN ( ac.ADDRESS_FLAG = 2 ) THEN dv.DIV_BZIP
									WHEN ( ac.ADDRESS_FLAG = 3 ) THEN dv.DIV_BZIP
									WHEN ( ac.ADDRESS_FLAG = 4 ) THEN dv.DIV_BZIP
				END,
				[Attn] = CASE		
									WHEN ( ac.ADDRESS_FLAG = 1 ) THEN cl.CL_MATTENTION
									WHEN ( ac.ADDRESS_FLAG = 2 ) THEN dv.DIV_ATTENTION
									WHEN ( ac.ADDRESS_FLAG = 3 ) THEN dv.DIV_ATTENTION
									WHEN ( ac.ADDRESS_FLAG = 4 ) THEN dv.DIV_ATTENTION
				END,
				ac.ADDRESS_FLAG,
				[County] = CASE		
									WHEN ( ac.ADDRESS_FLAG = 1 ) THEN cl.CL_BCOUNTY
									WHEN ( ac.ADDRESS_FLAG = 2 ) THEN dv.DIV_BCOUNTY
									WHEN ( ac.ADDRESS_FLAG = 3 ) THEN dv.DIV_BCOUNTY
 			    					WHEN ( ac.ADDRESS_FLAG = 4 ) THEN dv.DIV_BCOUNTY
				END,
				[Country] = CASE		
									WHEN ( ac.ADDRESS_FLAG = 1 ) THEN cl.CL_BCOUNTRY
									WHEN ( ac.ADDRESS_FLAG = 2 ) THEN dv.DIV_BCOUNTRY
									WHEN ( ac.ADDRESS_FLAG = 3 ) THEN dv.DIV_BCOUNTRY
									WHEN ( ac.ADDRESS_FLAG = 4 ) THEN dv.DIV_BCOUNTRY
				END,
				0
	FROM dbo.CLIENT AS cl
		JOIN #ar_client_codes ac
			ON cl.CL_CODE = ac.CL_CODE  
		JOIN dbo.DIVISION AS dv
		   ON ( cl.CL_CODE = dv.CL_CODE )
		JOIN dbo.PRODUCT AS pr
			ON ( dv.DIV_CODE = pr.DIV_CODE )  
			AND ( dv.CL_CODE = pr.CL_CODE )
END

-- Inserts a record into address table for NULL [DIV_CODE] and NULL [PRD_CODE] for @Client
--If @Division IS NULL AND @Product IS NULL
BEGIN
INSERT INTO #Address_Table
	SELECT DISTINCT
			cl.CL_CODE,
			'ZZ' AS [Division],
			'ZZ' AS [Product],
			'ZZ' AS [Product Contact],
			[Cl Name] = CASE ac.NAME_OVERIDE
									WHEN 0 THEN cl.CL_NAME
									WHEN 1 THEN	cl.CL_NAME
									WHEN 2 THEN	dv.DIV_NAME
									WHEN 3 THEN	pr.PRD_DESCRIPTION
				END,
			NULL AS [Dv Name],
			NULL AS [Pr Name],
			cl.CL_BADDRESS1,
			cl.CL_BADDRESS2,
			cl.CL_BCITY,
			cl.CL_BSTATE,
			cl.CL_BZIP,
			cl.CL_MATTENTION,
			ac.ADDRESS_FLAG,
			cl.CL_BCOUNTY,
			cl.CL_BCOUNTRY,
			0
	FROM dbo.CLIENT AS cl
		JOIN #ar_client_codes ac
			ON cl.CL_CODE = ac.CL_CODE 
		JOIN dbo.DIVISION AS dv
			ON ( cl.CL_CODE = dv.CL_CODE )
		JOIN dbo.PRODUCT AS pr
			ON ( dv.DIV_CODE = pr.DIV_CODE )  
			AND ( dv.CL_CODE = pr.CL_CODE ) 
END			

---- Inserts product contact addresses if ac.ADDRESS_FLAG = 4
--Creates CDP contact address temp table
CREATE TABLE #CDP_Address_Table(
	[Client]					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Division]					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Product]					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Product Contact]			varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Cl Name]					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Dv Name]					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Pr Name]					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Address1]					varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Address2]					varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[City]						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[State]						varchar(15) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Zip]						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Attn]						varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Flag]						tinyint null,
	[County]					varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Country]					varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[ContactID]					tinyint null)

-- address routine for contact addresses for custom reports (for linking on CDP and CONT_CODE fields)
-- populates CDP contact address temp table for all possible CDP combinations
IF @std_vs_cus = 1
BEGIN
INSERT INTO #CDP_Address_Table
	SELECT DISTINCT
			ch.CL_CODE,
			dv.DIV_CODE,
			pr.PRD_CODE,
			ch.CONT_CODE,
			cl.CL_NAME, 
			NULL,
			NULL,
			ch.CONT_ADDRESS1,
			ch.CONT_ADDRESS2,
			ch.CONT_CITY,
			ch.CONT_STATE,
			ch.CONT_ZIP,
			ch.CONT_FNAME + ' ' + ch.CONT_LNAME,
			ac.ADDRESS_FLAG,
			ch.CONT_COUNTY,
			ch.CONT_COUNTRY,
			0
	FROM dbo.CDP_CONTACT_HDR ch
		JOIN dbo.CLIENT cl
			on ch.CL_CODE = cl.CL_CODE
		JOIN #ar_client_codes ac
			ON ch.CL_CODE = ac.CL_CODE 
		JOIN dbo.DIVISION AS dv
			ON ( ch.CL_CODE = dv.CL_CODE )
		JOIN dbo.PRODUCT AS pr
			ON ( dv.CL_CODE = pr.CL_CODE )  
			AND ( dv.DIV_CODE = pr.DIV_CODE ) 
	WHERE ac.ADDRESS_FLAG = 4 

-- SELECT * FROM #CDP_Address_Table

-- uses product contact addresses unless PRD_CONT_CODE is NULL, then CDP contact addresses
	INSERT INTO #Address_Table
	SELECT DISTINCT
			at.Client,
			at.Division,
			at.Product,
			COALESCE(pc.CONT_CODE, at.[Product Contact]),
			at.[Cl Name], 
			NULL,
			NULL,
			COALESCE(pc.CONT_ADDRESS1, at.Address1),
			COALESCE(pc.CONT_ADDRESS2, at.Address2),
			COALESCE(pc.CONT_CITY, at.City),
			COALESCE(pc.CONT_STATE, at.State),
			COALESCE(pc.CONT_ZIP, at.Zip),
			CASE pc.CONT_LNAME
				WHEN NULL THEN at.Attn
				ELSE pc.CONT_FNAME + ' ' + pc.CONT_LNAME
			END,
			ISNULL(@address_flag_overide, 3),
			COALESCE(pc.CONT_COUNTY, at.County),
			COALESCE(pc.CONT_COUNTRY, at.Country),
			at.ContactID
	FROM #CDP_Address_Table at
		LEFT JOIN dbo.PRD_CONTACT pc
			ON ( pc.CL_CODE = at.Client )
			AND ( pc.DIV_CODE = at.Division )
			AND ( pc.PRD_CODE = at.Product )
			AND ( pc.CONT_CODE = at.[Product Contact] )
END

-- routine for job contact addresses (for linking on CDP ID)
ELSE
BEGIN	
INSERT INTO #Address_Table
	SELECT DISTINCT
			ch.CL_CODE,
			'ZZ',
			'ZZ',
			NULL,
			cl.CL_NAME, 
			NULL,
			NULL,
			ch.CONT_ADDRESS1,
			ch.CONT_ADDRESS2,
			ch.CONT_CITY,
			ch.CONT_STATE,
			ch.CONT_ZIP,
			ch.CONT_FNAME + ' ' + ch.CONT_LNAME,
			ac.ADDRESS_FLAG,
			ch.CONT_COUNTY,
			ch.CONT_COUNTRY,
			ch.CDP_CONTACT_ID
	FROM dbo.CDP_CONTACT_HDR ch
		JOIN dbo.CLIENT cl
			on ch.CL_CODE = cl.CL_CODE
		JOIN #ar_client_codes ac
			ON ch.CL_CODE = ac.CL_CODE 
	WHERE ac.ADDRESS_FLAG = 4 
END
	
end_Tran:

SELECT * FROM #Address_Table ORDER BY Client, Division, Product

DROP TABLE #Address_Table
GO

IF ( @@ERROR = 0 )
BEGIN
	IF NOT EXISTS( SELECT * FROM dbo.DB_UPDATE WHERE FUNCTION_NAME = 'Create_advsp_address_table_media_090925' )
		INSERT INTO dbo.DB_UPDATE( VERSION_ID, PATCH, DESCRIPTION, FUNCTION_NAME )
			 SELECT COALESCE( VERSION_ID, 'v6.00.09' ), 'Create_advsp_address_table_media.sql', 'Adds stored procedure advsp_address_table_media', 'Create_advsp_address_table_media_090925'
			   FROM dbo.ADVAN_UPDATE

	IF NOT EXISTS( SELECT * FROM dbo.DB_UPDATE WHERE FUNCTION_NAME = 'Create_advsp_address_table_media_110304' )
		INSERT INTO dbo.DB_UPDATE( VERSION_ID, PATCH, DESCRIPTION, FUNCTION_NAME )
			 SELECT COALESCE( VERSION_ID, 'v6.20.18' ), 'Create_advsp_address_table_media.sql', 'Adds stored procedure advsp_address_table_media', 'Create_advsp_address_table_media_110304'
			   FROM dbo.ADVAN_UPDATE

	IF NOT EXISTS( SELECT * FROM dbo.DB_UPDATE WHERE FUNCTION_NAME = 'Create_advsp_address_table_media_110727' )
		INSERT INTO dbo.DB_UPDATE( VERSION_ID, PATCH, DESCRIPTION, FUNCTION_NAME )
			 SELECT COALESCE( VERSION_ID, 'v6.50.00' ), 'Create_advsp_address_table_media.sql', 'Adds stored procedure advsp_address_table_media', 'Create_advsp_address_table_media_110727'
			   FROM dbo.ADVAN_UPDATE

	GRANT EXECUTE ON advsp_address_table_media TO PUBLIC AS dbo
END
GO	



