





CREATE PROCEDURE [dbo].[proc_WV_PO_GetPOApprRules] 
@PORuleCode varchar(6),
@POAmount decimal(15,2)
AS

create table #AppRules
   (PO_APPR_RULE_CODE varchar(6) COLLATE DATABASE_DEFAULT,
	PO_APPR_RULE_DESC varchar(50) COLLATE DATABASE_DEFAULT,
    SEQ_NBR smallint,
    APPR_MIN decimal(15,2),
    APPR_MAX decimal(15,2)
    )
declare @code as varchar(6)

SELECT     @code = PO_APPR_RULE_CODE
FROM       PO_APPR_RULE_HDR
WHERE      PO_APPR_RULE_CODE = @PORuleCode AND (INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0)

if @code <> ''
Begin
	insert into #AppRules(PO_APPR_RULE_CODE,PO_APPR_RULE_DESC,SEQ_NBR,APPR_MIN,APPR_MAX)
	SELECT     PO_APPR_RULE_DTL.PO_APPR_RULE_CODE, PO_APPR_RULE_HDR.PO_APPR_RULE_DESC, PO_APPR_RULE_DTL.SEQ_NBR,
			   PO_APPR_RULE_DTL.APPR_MIN, PO_APPR_RULE_DTL.APPR_MAX
	FROM       PO_APPR_RULE_DTL INNER JOIN
                      PO_APPR_RULE_HDR ON PO_APPR_RULE_HDR.PO_APPR_RULE_CODE = PO_APPR_RULE_DTL.PO_APPR_RULE_CODE
	WHERE      PO_APPR_RULE_DTL.PO_APPR_RULE_CODE = @PORuleCode AND (PO_APPR_RULE_DTL.INACTIVE_FLAG IS NULL OR PO_APPR_RULE_DTL.INACTIVE_FLAG = 0) AND
			   (PO_APPR_RULE_DTL.APPR_MIN <= @POAmount) AND (PO_APPR_RULE_DTL.APPR_MAX >= @POAmount)

	SELECT     #AppRules.PO_APPR_RULE_CODE, #AppRules.PO_APPR_RULE_DESC, #AppRules.SEQ_NBR, PO_APPR_RULE_EMP.PO_APPR_RULE_ID, PO_APPR_RULE_EMP.EMP_CODE,
			   PO_APPR_RULE_EMP.APPR_ORDER, #AppRules.APPR_MIN, #AppRules.APPR_MAX
	FROM       PO_APPR_RULE_EMP INNER JOIN
                      #AppRules ON #AppRules.PO_APPR_RULE_CODE = PO_APPR_RULE_EMP.PO_APPR_RULE_CODE AND 
                      #AppRules.SEQ_NBR = PO_APPR_RULE_EMP.SEQ_NBR
    WHERE     (PO_APPR_RULE_EMP.INACTIVE_FLAG IS NULL OR PO_APPR_RULE_EMP.INACTIVE_FLAG = 0)
	ORDER BY #AppRules.SEQ_NBR, PO_APPR_RULE_EMP.APPR_ORDER
	
End

drop table #AppRules

--SELECT     PO_APPR_RULE_HDR.PO_APPR_RULE_CODE, PO_APPR_RULE_HDR.PO_APPR_RULE_DESC, PO_APPR_RULE_DTL.SEQ_NBR, 
--                      PO_APPR_RULE_EMP.PO_APPR_RULE_ID, PO_APPR_RULE_EMP.EMP_CODE, PO_APPR_RULE_EMP.APPR_ORDER, 
--                      PO_APPR_RULE_DTL.APPR_MIN, PO_APPR_RULE_DTL.APPR_MAX
--FROM         PO_APPR_RULE_HDR INNER JOIN
 --                     PO_APPR_RULE_DTL ON PO_APPR_RULE_HDR.PO_APPR_RULE_CODE = PO_APPR_RULE_DTL.PO_APPR_RULE_CODE INNER JOIN
 --                     PO_APPR_RULE_EMP ON PO_APPR_RULE_DTL.PO_APPR_RULE_CODE = PO_APPR_RULE_EMP.PO_APPR_RULE_CODE AND 
 --                     PO_APPR_RULE_DTL.SEQ_NBR = PO_APPR_RULE_EMP.SEQ_NBR
--WHERE     (PO_APPR_RULE_HDR.PO_APPR_RULE_CODE = @PORuleCode) AND (PO_APPR_RULE_DTL.APPR_MIN < @POAmount) AND 
--                      (PO_APPR_RULE_DTL.APPR_MAX > @POAmount)
--ORDER BY PO_APPR_RULE_EMP.APPR_ORDER























