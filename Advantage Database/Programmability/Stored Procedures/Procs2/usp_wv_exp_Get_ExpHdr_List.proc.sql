






















/*****************************************************************************************
Webvantage
This Stored Procedure gets a Expense Header List for Expense Main
******************************************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_exp_Get_ExpHdr_List] 
@EmpCode Varchar(6),
@StartingDate datetime,
@EndingDate datetime
AS

declare @CheckNumber as varchar(15)
declare @CheckDate as datetime
declare @CDATES as varchar(10)
declare @T_CHECKPAYMENTS table (T_INV_NBR varchar(25), T_CHKNUMBER int, T_CHKDATE smalldatetime)
declare @T_EXPENSE table (E_INV_NBR varchar(25), E_EXP_DESC varchar(150), E_STATUS varchar(25), E_CHKNUMBER int, E_CHKDATE smalldatetime)

--Per Ellen 12/12/2005    Ignore voids for the time being.

insert into @T_CHECKPAYMENTS
(T_INV_NBR, T_CHKNUMBER, T_CHKDATE)
(select 	
	EXPENSE_HEADER.INV_NBR, 
	AP_PMT_HIST.AP_CHK_NBR, 
	AP_PMT_HIST.AP_CHK_DATE
	from EXPENSE_HEADER 
	inner join AP_HEADER 
	on EXPENSE_HEADER.INV_NBR = AP_HEADER.AP_INV_VCHR
	inner join AP_PMT_HIST on AP_HEADER.AP_ID = AP_PMT_HIST.AP_ID)

set @CDATES = '01/01/1900'

set @CheckNumber = '1234'
set @CheckDate = convert(datetime, @CDATES, 101)

insert into @T_EXPENSE (E_INV_NBR, E_EXP_DESC, E_STATUS, E_CHKNUMBER, E_CHKDATE)
select INV_NBR, EXP_DESC, STATUS, @CheckNumber as CHECKNUMBER,  convert(varchar(10),@CheckDate, 101) as CHECKDATE 
from EXPENSE_HEADER
where EMP_CODE = @EmpCode and
INV_DATE >= @StartingDate and INV_DATE <= @EndingDate

select E_INV_NBR as INV_NBR, E_EXP_DESC as EXP_DESC, E_STATUS as STATUS, isnull(convert(varchar(25),T_CHKNUMBER), '') as CHECKNUMBER,  isnull(convert(varchar(10),T_CHKDATE, 101), '')as CHECKDATE 
from @T_EXPENSE
left outer join @T_CHECKPAYMENTS on E_INV_NBR = T_INV_NBR
order by E_INV_NBR desc






















