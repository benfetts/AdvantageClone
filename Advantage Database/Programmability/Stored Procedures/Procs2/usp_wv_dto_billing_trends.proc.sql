SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dto_billing_trends]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dto_billing_trends]
GO






CREATE PROCEDURE [dbo].[usp_wv_dto_billing_trends] 
@Client VarChar(10),
@RecType VarChar(5),
@Year1 VarChar(4),
@Year2 VarChar(4),
@Sales VarChar(6),
@UserID varchar(100),
@Office VarChar(6),
@Division VarChar(6),
@Product VarChar(6)
AS
Declare @Restrictions Int, @RestrictionsOffice Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000), @EmpCode varchar(6)

Select @Restrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)		
		
Select @EmpCode = EMP_CODE
FROM SEC_USER
WHERE UPPER(USER_CODE) = UPPER(@UserID)	
		
Select @RestrictionsOffice = Count(*) 
FROM EMP_OFFICE
Where EMP_CODE = @EmpCode
		
SELECT @sql = 'SELECT      ISNULL(Sum(ACCT_REC.AR_INV_AMOUNT),0), POSTPERIOD.PPGLMONTH, POSTPERIOD.PPGLYEAR
FROM         ACCT_REC INNER JOIN
                      POSTPERIOD ON ACCT_REC.AR_POST_PERIOD = POSTPERIOD.PPPERIOD'
    If @Restrictions > 0
    Begin
        SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON ACCT_REC.CL_CODE = SEC_CLIENT.CL_CODE AND ACCT_REC.DIV_CODE = SEC_CLIENT.DIV_CODE AND ACCT_REC.PRD_CODE = SEC_CLIENT.PRD_CODE'
    End                  
    If @RestrictionsOffice > 0                 
        Begin
            SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON ACCT_REC.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE'
        End                  
--SELECT @sql = @sql + ' WHERE (ACCT_REC.AR_INV_SEQ <> 99) AND ((POSTPERIOD.PPGLYEAR =@Year1) or (POSTPERIOD.PPGLYEAR =@Year2))'
SELECT @sql = @sql + ' WHERE (ACCT_REC.AR_INV_SEQ <> 99) AND POSTPERIOD.PPGLYEAR BETWEEN @Year1 AND @Year2'
    if @Office <> '%'
		Begin
			SELECT @sql = @sql + ' AND (ACCT_REC.OFFICE_CODE = @Office)'
		End
	if @Client <> '%'
		Begin
			SELECT @sql = @sql + ' AND (ACCT_REC.CL_CODE = @Client)'
		End
	if @Division <> '%'
		Begin
			SELECT @sql = @sql + ' AND (ACCT_REC.DIV_CODE = @Division)'
		End
	if @Product <> '%'
		Begin
			SELECT @sql = @sql + ' AND (ACCT_REC.PRD_CODE = @Product)'
		End		    
	if @RecType = 'P'
		Begin
			SELECT @sql = @sql + ' AND (ACCT_REC.REC_TYPE = @RecType)'
		End  			 
	if @RecType = 'M'
		Begin
		     SELECT @sql = @sql + ' AND (ACCT_REC.REC_TYPE <> ''P'')'			  
		End
	if @Sales <> '%'
		Begin
			SELECT @sql = @sql + ' AND (ACCT_REC.SC_CODE = @Sales)'
		End
	If @Restrictions > 0
    Begin
        SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) '
    End  	
	If @RestrictionsOffice > 0                 
        Begin
            SELECT @sql = @sql + ' AND (EMP_OFFICE.EMP_CODE = @EmpCode)'
        End  		
SELECT @sql = @sql + ' Group By PPGLYEAR, PPGLMONTH
					  Order By PPGLYEAR, PPGLMONTH'

SELECT @paramlist = '@Client VarChar(10), @RecType VarChar(5), @Year1 VarChar(4), @Year2 VarChar(4), @Sales VarChar(6), @Office VarChar(6), @Division VarChar(6), @Product VarChar(6), @EmpCode varchar(6), @UserID varchar(100)'


EXEC sp_executesql @sql, @paramlist, @Client, @RecType, @Year1, @Year2, @Sales, @Office, @Division, @Product, @EmpCode, @UserID
PRINT @sql



















GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

