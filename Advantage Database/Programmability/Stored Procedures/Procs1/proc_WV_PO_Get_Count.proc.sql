


CREATE PROCEDURE [dbo].[proc_WV_PO_Get_Count](@count_item varchar(20), @ref_id integer, @ref_id2 integer,@UserID as varchar(100), @result integer OUTPUT) AS

/*
declare @return as integer
exec proc_WV_PO_Get_Count 'job_comp', 42, 0, @return OUTPUT
print @return
*/

DECLARE @EMP_CODE AS VARCHAR(6)
DECLARE @OfficeCount AS INTEGER

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

if @count_item ='job_comp'
begin --select component count for specified job number...
   select @result =  count(JOB_COMPONENT_NBR) from JOB_COMPONENT
    where JOB_NUMBER = @ref_id
 end

else if @count_item='po_number' 
 begin --count of matching PO numbers (used to determine if PO exists for redirect to detail..
	if @OfficeCount = 0
	Begin
		select @result = count(PO_NUMBER) from PURCHASE_ORDER where PO_NUMBER = @ref_id AND VN_CODE IS NOT NULL
	End
	Else
	Begin
		select @result = count(A.PO_NUMBER) FROM
			(SELECT PURCHASE_ORDER.PO_NUMBER from PURCHASE_ORDER
				 INNER JOIN PURCHASE_ORDER_DET ON PURCHASE_ORDER.PO_NUMBER = PURCHASE_ORDER_DET.PO_NUMBER
				 INNER JOIN JOB_LOG as j on j.JOB_NUMBER = PURCHASE_ORDER_DET.JOB_NUMBER
				 INNER JOIN EMP_OFFICE as eo ON eo.OFFICE_CODE = j.OFFICE_CODE AND eo.EMP_CODE = @EMP_CODE
			 where PURCHASE_ORDER.PO_NUMBER = @ref_id AND VN_CODE IS NOT NULL
			 UNION
			 SELECT PURCHASE_ORDER.PO_NUMBER from PURCHASE_ORDER
			 where PO_NUMBER = @ref_id AND VN_CODE IS NOT NULL AND PO_NUMBER NOT IN (SELECT PO_NUMBER FROM PURCHASE_ORDER_DET)) AS A

	End   
 end



