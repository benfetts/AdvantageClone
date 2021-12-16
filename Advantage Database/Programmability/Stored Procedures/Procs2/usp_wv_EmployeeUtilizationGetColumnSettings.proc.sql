﻿IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_EmployeeUtilizationGetColumnSettings]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_EmployeeUtilizationGetColumnSettings]
GO

/****** Object:  StoredProcedure [dbo].[usp_wv_AAMGetColumnSettings]    Script Date: 7/21/2020 4:21:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_wv_EmployeeUtilizationGetColumnSettings]
	@GRID_NAME VARCHAR(100),
	@USER_CODE VARCHAR(100)	
AS

	DECLARE @GRID_ID INTEGER,
	@INSERT_COUNT AS INTEGER	

	BEGIN
		SELECT @GRID_ID = GRID_ID FROM GRID WITH(NOLOCK) WHERE NAME = @GRID_NAME;		
	END

--BEGIN
--WAITFOR DELAY '00:00:03';
--END

	--LOAD ANY MISSING COLUMNS TO THE USERS SETTINGS
	BEGIN	
		INSERT INTO GRID_COLUMN_SETTING WITH(ROWLOCK)
		SELECT @GRID_ID, GRID_COLUMN_ID, @USER_CODE AS USER_CODE,
		--SOME COLUMNS AREN'T VISIBLE BY DEFAULT
		CASE WHEN NAME IN ('JobNumber', 'ComponentNumber', 'JobComponentDetailed', 'JobAndComponentNumber', 'JobDescription', 'ComponentDescription', 'CCEmployeeCodes', 'CCEmployeeNames') THEN 0
		ELSE 1 END AS IS_VISIBLE, 
		DEFAULT_ORDER_ID, DEFAULT_COLUMN_WIDTH
		FROM GRID_COLUMN WHERE GRID_COLUMN_ID NOT IN (SELECT GRID_COLUMN_ID FROM GRID_COLUMN_SETTING WHERE USER_CODE = @USER_CODE AND GRID_ID = @GRID_ID)
		AND GRID_ID = @GRID_ID
	END

	--UPDATE ANY NULL COLUMN WIDTHS IN SETTINGS WITH DEFAULT WIDTHS
	BEGIN
		UPDATE S WITH(ROWLOCK)
		SET S.COLUMN_WIDTH = C.DEFAULT_COLUMN_WIDTH
		FROM GRID_COLUMN_SETTING S INNER JOIN GRID_COLUMN C WITH(NOLOCK) ON S.GRID_COLUMN_ID = C.GRID_COLUMN_ID
		WHERE C.GRID_ID = @GRID_ID
		AND S.USER_CODE = @USER_CODE
		AND S.COLUMN_WIDTH IS NULL 
	END
	--UPDATE ANY NULL COLUMN ORDER ID'S IN SETTINGS WITH DEFAULT COLUMN ORDERS
	BEGIN
		UPDATE S WITH(ROWLOCK)
		SET S.COLUMN_ORDER_ID = C.DEFAULT_ORDER_ID
		FROM GRID_COLUMN_SETTING S INNER JOIN GRID_COLUMN C WITH(NOLOCK) ON S.GRID_COLUMN_ID = C.GRID_COLUMN_ID
		WHERE C.GRID_ID = @GRID_ID
		AND S.USER_CODE = @USER_CODE
		AND S.COLUMN_ORDER_ID IS NULL 
	END

	BEGIN		
		SELECT C.NAME AS ColumnName, S.COLUMN_ORDER_ID AS ColumnOrderId, C.DEFAULT_ORDER_ID AS DefaultOrderID,
		S.COLUMN_WIDTH AS ColumnWidth, S.IS_VISIBLE as IsVisible
		FROM GRID_COLUMN C WITH(NOLOCK) LEFT JOIN GRID_COLUMN_SETTING S WITH(NOLOCK) ON C.GRID_COLUMN_ID = S.GRID_COLUMN_ID
		WHERE S.USER_CODE = @USER_CODE AND C.GRID_ID = @GRID_ID		
		ORDER BY S.COLUMN_ORDER_ID		
	END