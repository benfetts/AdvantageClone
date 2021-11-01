SET ANSI_NULLS ON
GO

SET ANSI_PADDING OFF
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_media1_invoice_orders]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_media1_invoice_orders]
GO

CREATE PROCEDURE [dbo].[advsp_media1_invoice_orders] ( @user_code varchar(100), @draft_option tinyint, 
		@ar_inv_list varchar(6000) = '', @bu_inv_list varchar(6000) = '', @bu_order_type varchar(6000) = '')

-- Stored procedure to create a table of invoices to process from a concatenated list
-- #01 06/04/15 - re-dimensioned lists to 6000 chars (326-270) 
-- #02 10/15/16 - v660/v670 removed case sensitivity for [USER_ID] via "SQL_Latin1_General_CP1_CI_AS" (344-1371)

AS
BEGIN
	SET NOCOUNT ON;

-- @draft_option; regular invoices = 0, draft invoices = 1
-- @ar_inv_list; comma delimited string converted to (1) column table
-- @bu_inv_list; comma delimited string converted into (2) column table

-- ==========================================================
-- Delete orders from dbo.MEDIA_RPT_ORDERS for the current user
-- ==========================================================
DELETE FROM dbo.MEDIA_RPT_ORDERS WHERE UPPER([USER_ID]) COLLATE SQL_Latin1_General_CP1_CI_AS = UPPER(@user_code)	--#02

-- ==========================================================
-- Populate dbo.MEDIA_RPT_ORDERS
-- ==========================================================
-- Regular Invoices
IF @draft_option = 0
	BEGIN		
		INSERT INTO dbo.MEDIA_RPT_ORDERS
		SELECT DISTINCT @user_code, o.ORDER_NBR, o.ORDER_TYPE
		FROM dbo.ARINV_MEDIA AS o
		JOIN fn_intlist_to_table(@ar_inv_list) i
		ON o.AR_INV_NBR = i.number
	END

-- Draft Invoices
ELSE
	BEGIN
		--Temp table to hold draft billing user names
		CREATE TABLE #draft_list(BILLING_USER varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS)
		INSERT INTO #draft_list
		SELECT DISTINCT vstr
		FROM dbo.fn_charlist_to_table2(@bu_inv_list)
		--SELECT * FROM #draft_list

		--Temp table to hold draft order types
		CREATE TABLE #order_type(ORDER_TYPE varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS)
		INSERT INTO #order_type
		SELECT vstr
		FROM dbo.fn_charlist_to_table2(@bu_order_type)
		--SELECT * FROM #order_type

		--Magazine
		IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'M')
		BEGIN
			INSERT INTO dbo.MEDIA_RPT_ORDERS
			SELECT DISTINCT @user_code,	d.ORDER_NBR, 'M'
			FROM dbo.MAGAZINE_DETAIL AS d
			JOIN #draft_list i
			ON d.BILLING_USER = i.BILLING_USER
		END

		--Newspaper
		IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'N')
		BEGIN
			INSERT INTO dbo.MEDIA_RPT_ORDERS
			SELECT DISTINCT @user_code, d.ORDER_NBR, 'N'
			FROM dbo.NEWSPAPER_DETAIL AS d
			JOIN #draft_list i
			ON d.BILLING_USER = i.BILLING_USER
		END

		--Internet
		IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'I')
		BEGIN
			INSERT INTO dbo.MEDIA_RPT_ORDERS
			SELECT DISTINCT @user_code, d.ORDER_NBR, 'I'
			FROM dbo.INTERNET_DETAIL AS d
			JOIN #draft_list i
			ON d.BILLING_USER = i.BILLING_USER
		END

		--Outdoor
		IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'O')
		BEGIN
			INSERT INTO dbo.MEDIA_RPT_ORDERS
			SELECT DISTINCT @user_code, d.ORDER_NBR, 'O'
			FROM dbo.OUTDOOR_DETAIL AS d
			JOIN #draft_list i
			ON d.BILLING_USER = i.BILLING_USER
		END

		--Radio
		IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'R')
		BEGIN
			INSERT INTO dbo.MEDIA_RPT_ORDERS
			SELECT DISTINCT @user_code, d.ORDER_NBR, 'R'
			FROM dbo.RADIO_DETAIL1 AS d
			JOIN #draft_list i
			ON d.BILLING_USER = i.BILLING_USER
		END
		
		--Radio (new)
		IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'R')
		BEGIN
			INSERT INTO dbo.MEDIA_RPT_ORDERS
			SELECT DISTINCT @user_code, d.ORDER_NBR, 'R'
			FROM dbo.RADIO_DETAIL AS d
			JOIN #draft_list i
			ON d.BILLING_USER = i.BILLING_USER
		END

		--Television
		IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'T')
		BEGIN
			INSERT INTO dbo.MEDIA_RPT_ORDERS
			SELECT DISTINCT @user_code, d.ORDER_NBR, 'T'
			FROM dbo.TV_DETAIL1 AS d
			JOIN #draft_list i
			ON d.BILLING_USER = i.BILLING_USER
		END

		--Television (new)
		IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'T')
		BEGIN
			INSERT INTO dbo.MEDIA_RPT_ORDERS
			SELECT DISTINCT @user_code, d.ORDER_NBR, 'T'
			FROM dbo.TV_DETAIL AS d
			JOIN #draft_list i
			ON d.BILLING_USER = i.BILLING_USER
		END
	END

END
