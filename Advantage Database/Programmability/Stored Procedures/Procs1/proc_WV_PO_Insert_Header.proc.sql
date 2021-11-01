


CREATE PROCEDURE [dbo].[proc_WV_PO_Insert_Header]( @SYS_USER_ID varchar(100), @VN_CODE varchar(6),
 @VN_CONT_CODE varchar(4),
 @EMP_CODE varchar(6), @PO_DATE datetime, @PO_DUE_DATE datetime,
 @PO_DESCRIPTION varchar(40), @PO_COMPLETE smallint, @PO_REVISION smallint,
 @PO_WORK_COMPLETE smallint, @PO_APPR_RULE_CODE varchar(6), @PO_NUM integer OUTPUT) AS

--get next PO Number
declare @po_number integer
exec  proc_WV_PO_GetNextPONumber @po_number OUTPUT
select @PO_NUM=@po_number

if @PO_WORK_COMPLETE = 1
		 insert into PURCHASE_ORDER(WV_FLAG, PO_NUMBER, PO_CREATE_DATE,[USER_ID],
		  VN_CODE, VN_CONT_CODE, EMP_CODE,
		  PO_DATE, PO_DUE_DATE,
		  PO_DESCRIPTION, PO_COMPLETE,
		  PO_WORK_COMPLETE, PO_REVISION, PO_APPR_RULE_CODE, EXCEED)

		values(1, 
		 @po_number, getdate(),@SYS_USER_ID,
		 @VN_CODE, @VN_CONT_CODE, @EMP_CODE,
		 @PO_DATE, @PO_DUE_DATE,
		 @PO_DESCRIPTION, @PO_COMPLETE,
		 @PO_WORK_COMPLETE,0, @PO_APPR_RULE_CODE,0

		)
else
		insert into PURCHASE_ORDER(WV_FLAG, PO_NUMBER, PO_CREATE_DATE,[USER_ID],
		  VN_CODE, VN_CONT_CODE, EMP_CODE,
		  PO_DATE, PO_DUE_DATE,
		  PO_DESCRIPTION, PO_COMPLETE,
		  PO_WORK_COMPLETE, PO_REVISION, PO_APPR_RULE_CODE, EXCEED)

		values(1, 
		 @po_number, getdate(),@SYS_USER_ID,
		 @VN_CODE, @VN_CONT_CODE, @EMP_CODE,
		 @PO_DATE, @PO_DUE_DATE,
		 @PO_DESCRIPTION, NULL,
		 @PO_WORK_COMPLETE,0, @PO_APPR_RULE_CODE,0

		)
 
return @@ERROR




