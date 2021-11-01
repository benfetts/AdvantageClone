

CREATE PROCEDURE  [dbo].[proc_WV_PO_Update_Header](@PO_NUMBER integer,
 @SYS_USER_ID varchar(100), @VN_CODE varchar(6),
 @VN_CONT_CODE varchar(4),
 @EMP_CODE varchar(6), @PO_DATE datetime, @PO_DUE_DATE datetime,
 @PO_DESCRIPTION varchar(40), @PO_COMPLETE smallint, @PO_REVISION integer,
 @PO_WORK_COMPLETE smallint,@Exceed smallint) AS

--update Webvantage PO Header.


update PURCHASE_ORDER set --[USER_ID]= @SYS_USER_ID,
 VN_CODE=@VN_CODE, 
 VN_CONT_CODE=@VN_CONT_CODE,
 EMP_CODE=@EMP_CODE,
 PO_DATE=@PO_DATE,
 PO_DUE_DATE=@PO_DUE_DATE,
 PO_DESCRIPTION=@PO_DESCRIPTION,
 --PO_COMPLETE=@PO_COMPLETE,
 PO_WORK_COMPLETE=@PO_WORK_COMPLETE,
 EXCEED=@Exceed
 WHERE PO_NUMBER=@PO_NUMBER

 
return @@ERROR

