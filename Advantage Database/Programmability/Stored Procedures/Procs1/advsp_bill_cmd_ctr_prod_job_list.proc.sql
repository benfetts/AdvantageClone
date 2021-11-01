CREATE PROCEDURE [dbo].[advsp_bill_cmd_ctr_prod_job_list] @bcc_id_in integer
AS

SET NOCOUNT ON

DECLARE @job_list TABLE ( 
	JOB_NUMBER				integer, 
	JOB_COMPONENT_NBR		smallint, 
	CL_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	DIV_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	PRD_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CC_RECONCILE_STATUS		smallint,
	CC_RECOG_PENDING		decimal(15,2) )

INSERT INTO @job_list( JOB_NUMBER, JOB_COMPONENT_NBR, CL_CODE, DIV_CODE, PRD_CODE )
	 SELECT jc.JOB_NUMBER, jc.JOB_COMPONENT_NBR, jl.CL_CODE, jl.DIV_CODE, jl.PRD_CODE
	   FROM dbo.JOB_COMPONENT jc INNER JOIN dbo.JOB_LOG jl
		 ON jl.JOB_NUMBER = jc.JOB_NUMBER
	  WHERE BCC_ID = @bcc_id_in

 
	UPDATE @job_list
	   SET CC_RECOG_PENDING = ( SELECT SUM( ir.REC_AMT )  
				                  FROM dbo.INCOME_REC ir	
						         WHERE ir.JOB_NUMBER = JOB_NUMBER 
								   AND ir.JOB_COMPONENT_NBR = JOB_COMPONENT_NBR
								   AND ir.AR_INV_NBR IS NULL 
								   AND ir.AB_FLAG <> 3 )

	UPDATE @job_list
	   SET CC_RECONCILE_STATUS = ( SELECT dbo.advfn_adv_bill_reconcile_status ( JOB_NUMBER, JOB_COMPONENT_NBR ))
  
SELECT
	[JobNumber] = JOB_NUMBER,
	[JobComponentNumber] = JOB_COMPONENT_NBR,
	[ClientCode] = CL_CODE,
	[DivisionCode] = DIV_CODE,
	[ProductCode] = PRD_CODE,
	[AdvanceBillingReconcileStatus] = CC_RECONCILE_STATUS,
	[ReconcilePendingAmount] = CC_RECOG_PENDING
FROM @job_list
ORDER BY 1 ASC, 2 ASC

GO