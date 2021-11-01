
























CREATE PROCEDURE [dbo].[usp_wv_reports_ar_statements_updateemailed_product] 

@ClientID as varchar(6),
@DivisionID as varchar(6),
@ProductID as varchar(6),
@ContactCode as varchar(6)

AS

Update PRODUCT_AR_STMT SET PRODUCT_AR_STMT.LAST_EMAILED = getdate()
where PRODUCT_AR_STMT.CL_CODE = @ClientID AND
PRODUCT_AR_STMT.DIV_CODE = @DivisionID AND
PRODUCT_AR_STMT.PRD_CODE = @ProductID AND
 PRODUCT_AR_STMT.CONT_CODE = @ContactCode























