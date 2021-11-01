CREATE PROCEDURE [dbo].[advsp_bill_cmd_ctr_inv_pp] @billing_user varchar(100)
AS

SET NOCOUNT ON

SELECT
	[PostPeriodCode] = COALESCE( b.POST_PERIOD, p.PPPERIOD ),
	[InvoiceDate] = COALESCE( b.INV_DATE, CAST( CONVERT( varchar(10), GETDATE( ), 101 ) AS smalldatetime )),
	[UseComboBilling] = CAST(COALESCE( b.USE_COMBO_BILLING_OVERRIDE, 0) as bit),
	[ComboAssignInvoicesBy] = CAST(COALESCE( b.COMBO_INV_BY_OVERRIDE, 0) as smallint),
	[ProductionAssignInvoicesBy] = CAST(b.CL_INV_BY_OVERRIDE as varchar),
	[MediaAssignInvoicesBy] = CAST(b.CL_MINV_BY_OVERRIDE as varchar)
FROM dbo.AGENCY a 
	LEFT OUTER JOIN dbo.POSTPERIOD p ON ( p.PPARCURMTH = 'C' ) 
	LEFT OUTER JOIN dbo.BILLING b ON ( b.BILLING_USER = @billing_user ) 
GO
