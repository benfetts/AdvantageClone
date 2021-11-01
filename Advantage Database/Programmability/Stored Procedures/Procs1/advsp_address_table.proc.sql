
CREATE PROCEDURE [dbo].[advsp_address_table] @one_time tinyint, @address_flag_overide tinyint, 
	@name_overide tinyint, @list_option tinyint, @list varchar(4000), @std_vs_cus tinyint

-- @one_time: 0=No, 1=Yes
-- @address_flag_overide: (overide value if @one_time=1, see below for possible values)
-- @address_flag_overide: 1=Client Address, 2=Division Address, 3=Product Address, 4=Product Contact Address
-- @name_overide: (overide value if @one_time=1) 1=No overide, 2=Client, 3=Division, 4=Product
-- @list_option: 0=AR Invoice List, 1=Billing User List
-- @list: concatenated string of values based on @list_option
-- @std_vs_cus: 0=Standard, 1=Custom

AS
SET NOCOUNT ON

SET @address_flag_overide = ISNULL(@address_flag_overide, 3)	--use one-time address flag, or set to product name just in case
SET @name_overide = ISNULL(@name_overide, 1)					--use one-time name overide, or set to no overide just in case

--Creates a client table with the associated address flag and name overide
CREATE TABLE #ar_Client_Codes(
	CL_CODE 						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ADDRESS_FLAG					tinyint,
	NAME_OVERIDE					tinyint)

IF @list_option = 0		--AR Invoice List-------------------------------------------------------
	IF @one_time = 1	--One time overides
		BEGIN
			INSERT INTO #ar_Client_Codes	
			SELECT DISTINCT 
				ar.CL_CODE,
				@address_flag_overide,	
				@name_overide		
			FROM dbo.ACCT_REC ar
			JOIN fn_intlist_to_table(@list) l 
				ON ar.AR_INV_NBR = l.number
		END
	ELSE				--Not one time, use values in dbo.PROD_INV_DEF
		BEGIN
			INSERT INTO #ar_Client_Codes	
			SELECT DISTINCT 
				ar.CL_CODE,
				dbo.fn_client_code_to_address_flag(ar.CL_CODE),		--selects client, or agency default address flag, if none
				dbo.fn_client_code_to_name_overide(ar.CL_CODE)		--selects client, or agency default name overide, if none
			FROM dbo.ACCT_REC ar
			JOIN fn_intlist_to_table(@list) l 
				ON ar.AR_INV_NBR = l.number
		END

ELSE					--Billing User List------------------------------------------------------
	IF @one_time = 1	---One time overides
		BEGIN
			INSERT INTO #ar_Client_Codes
			SELECT DISTINCT 
				jl.CL_CODE,
				@address_flag_overide,
				@name_overide
			FROM dbo.JOB_LOG jl
			JOIN dbo.JOB_COMPONENT jc
				ON jl.JOB_NUMBER = jc.JOB_NUMBER
			JOIN fn_charlist_to_table2(@list) bu
				ON jc.BILLING_USER COLLATE SQL_Latin1_General_CP1_CS_AS = bu.vstr
		END
	ELSE				--Not one time, use values in dbo.PROD_INV_DEF 
		BEGIN
			INSERT INTO #ar_Client_Codes
			SELECT DISTINCT 
				jl.CL_CODE,
				dbo.fn_client_code_to_address_flag(jl.CL_CODE),
				dbo.fn_client_code_to_name_overide(jl.CL_CODE)
			FROM dbo.JOB_LOG jl
			JOIN dbo.JOB_COMPONENT jc
				ON jl.JOB_NUMBER = jc.JOB_NUMBER
			JOIN fn_charlist_to_table2(@list) bu
				ON jc.BILLING_USER COLLATE SQL_Latin1_General_CP1_CS_AS = bu.vstr
		END

--SELECT * FROM #ar_Client_Codes

--Creates address table
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
									WHEN 1 THEN cl.CL_ATTENTION
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
		JOIN #ar_Client_Codes ac
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
									WHEN ( ac.ADDRESS_FLAG = 1 ) THEN cl.CL_ATTENTION
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
		JOIN #ar_Client_Codes ac
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
			cl.CL_ATTENTION,
			ac.ADDRESS_FLAG,
			cl.CL_BCOUNTY,
			cl.CL_BCOUNTRY,
			0
	FROM dbo.CLIENT AS cl
		JOIN #ar_Client_Codes ac
			ON cl.CL_CODE = ac.CL_CODE 
		JOIN dbo.DIVISION AS dv
			ON ( cl.CL_CODE = dv.CL_CODE )
		JOIN dbo.PRODUCT AS pr
			ON ( dv.DIV_CODE = pr.DIV_CODE )  
			AND ( dv.CL_CODE = pr.CL_CODE ) 
END			

-- Product Contact Addresses==================================================
-- Inserts product contact addresses if ac.ADDRESS_FLAG = 4
-- Creates CDP contact address temp table
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
		JOIN #ar_Client_Codes ac
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
			at.[Dv Name],
			at.[Pr Name],
			COALESCE(pc.CONT_ADDRESS1, at.Address1),
			COALESCE(pc.CONT_ADDRESS2, at.Address2),
			COALESCE(pc.CONT_CITY, at.City),
			COALESCE(pc.CONT_STATE, at.State),
			COALESCE(pc.CONT_ZIP, at.Zip),
			CASE									--06/30/09 JP 
				WHEN pc.CONT_LNAME IS NOT NULL THEN pc.CONT_FNAME + ' ' + pc.CONT_LNAME
				ELSE at.Attn
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

-- address routine for contact addresses for standard reports (for linking on CDP ID)
-- populates CDP contact address temp table for all possible CDP combinations
ELSE
BEGIN	
INSERT INTO #Address_Table
	SELECT DISTINCT
			ch.CL_CODE,
			dv.DIV_CODE,
			pr.PRD_CODE,
			NULL,
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
		JOIN dbo.DIVISION AS dv
			ON ( ch.CL_CODE = dv.CL_CODE )
		JOIN dbo.PRODUCT AS pr
			ON ( dv.DIV_CODE = pr.DIV_CODE )  
			AND ( dv.CL_CODE = pr.CL_CODE )
		JOIN #ar_Client_Codes ac
			ON ch.CL_CODE = ac.CL_CODE 
	WHERE ac.ADDRESS_FLAG = 4 
END
	
end_Tran:

SELECT * FROM #Address_Table ORDER BY Client, Division, Product

DROP TABLE #Address_Table
