IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_PaymentCenterUpdateBatchHeader]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_PaymentCenterUpdateBatchHeader] 
GO

CREATE PROCEDURE [dbo].[usp_wv_PaymentCenterUpdateBatchHeader]		
	@BATCH_ID INT,
	@USER_CODE VARCHAR(6),
	@FIELD_NAME VARCHAR(255),
	@FIELD_VALUE VARCHAR(255)
AS

DECLARE @SQL VARCHAR(1000)

BEGIN	
	SET @SQL = 'UPDATE PC_BATCH_HEADER WITH (ROWLOCK)'
	SET @SQL = @SQL + 'SET ' + @FIELD_NAME + ' = ''' + @FIELD_VALUE + ''' '
	SET @SQL = @SQL + 'WHERE USER_ID = ''' + @USER_CODE + ''' ';
	SET @SQL = @SQL + 'AND BATCH_ID = ' + CONVERT(VARCHAR(10), @BATCH_ID) + '';

	EXEC(@SQL)
	--PRINT (@SQL);
END