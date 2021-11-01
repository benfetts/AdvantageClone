


/* ============================================================ */
/*   View: CL_DIV_PRD_LIST                                      */
/* ============================================================ */
CREATE VIEW dbo.CL_DIV_PRD_LIST ( CL_CODE, CL_NAME, DIV_CODE, DIV_NAME, PRD_CODE, PRD_DESCRIPTION ) 
AS
 SELECT ALL CLIENT.CL_CODE, 
	CL_NAME, 
	DIVISION.DIV_CODE, 
	DIV_NAME,   
	PRD_CODE, 
	PRD_DESCRIPTION 
   FROM CLIENT, 
	DIVISION, 
	PRODUCT 
  WHERE CLIENT.CL_CODE = DIVISION.CL_CODE 
    AND CLIENT.CL_CODE = PRODUCT.CL_CODE   
    AND DIVISION.CL_CODE = PRODUCT.CL_CODE 
    AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE



