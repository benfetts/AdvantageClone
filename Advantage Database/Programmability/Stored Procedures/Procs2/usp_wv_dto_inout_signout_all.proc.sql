if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dto_inout_signout_all]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dto_inout_signout_all]
GO

CREATE PROCEDURE [dbo].[usp_wv_dto_inout_signout_all]
AS 
BEGIN

DECLARE @emp_code varchar(6), @in_out int

--CREATE TABLE #IO_EMPS(INOUT_REF int, EMP_CDOE VARCHAR(6) NOT NULL, INOUT_STAT)

DECLARE io_col_cursor CURSOR FOR 
		 SELECT A.EMP_CODE, (SELECT INOUT_STAT FROM EMP_INOUTBOARD WHERE A.INOUT_REF = EMP_INOUTBOARD.INOUT_REF) AS IN_OUT FROM
		(SELECT MAX(INOUT_REF) AS INOUT_REF, EMP_CODE
				   FROM dbo.EMP_INOUTBOARD 		  	  
				  GROUP BY EMP_CODE) A
			UNION

			SELECT EMP_CODE,0 AS IN_OUT
			FROM EMPLOYEE
			WHERE EMPLOYEE.EMP_CODE NOT IN (SELECT EMP_CODE FROM EMP_INOUTBOARD)
			AND EMP_TERM_DATE IS NULL
	 
	OPEN io_col_cursor

	FETCH NEXT FROM io_col_cursor INTO @emp_code, @in_out

	WHILE ( @@FETCH_STATUS <> -1 )
	BEGIN
		if @in_out = 0
		BEGIN
			INSERT INTO EMP_INOUTBOARD(EMP_CODE, INOUT_STAT, INOUT_TIME, COMMENT, EXP_RETURN_TIME)
			VALUES	 (@emp_code, 1, getdate(), 'Auto log out.', NULL)		
		END
		
		FETCH NEXT FROM io_col_cursor INTO @emp_code, @in_out
	END

	CLOSE io_col_cursor
	DEALLOCATE io_col_cursor

END

