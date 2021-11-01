CREATE PROCEDURE [dbo].[advsp_bill_cmd_ctr_media_order_list] @bcc_id_in integer

AS

SET NOCOUNT ON

DECLARE @order_list TABLE ( 
	ORDER_NUMBER			integer NOT NULL, 
	LINE_NUMBER				integer NULL,
	BRDCAST_MONTH			smallint NULL,
	BRDCAST_YEAR			smallint NULL, 
	MEDIA_FROM				varchar(8) NOT NULL,
	CL_CODE					varchar(6) NOT NULL,
	DIV_CODE				varchar(6) NOT NULL,
	PRD_CODE				varchar(6) NOT NULL )

-- Gather print
INSERT INTO @order_list( ORDER_NUMBER, LINE_NUMBER, MEDIA_FROM, CL_CODE, DIV_CODE, PRD_CODE )
	 SELECT DISTINCT bol.ORDER_NBR, bol.LINE_NBR, vmh.MEDIA_FROM, vmh.CL_CODE, vmh.DIV_CODE, vmh.PRD_CODE  
	   FROM dbo.BCC_ORDER_LINE bol
 INNER JOIN dbo.V_MEDIA_HDR vmh ON ( bol.ORDER_NBR = vmh.ORDER_NBR ) 	   
	  WHERE bol.BCC_ID = @bcc_id_in
	    
-- Gather broadcast	     
INSERT INTO @order_list( ORDER_NUMBER, BRDCAST_YEAR, BRDCAST_MONTH, MEDIA_FROM, CL_CODE, DIV_CODE, PRD_CODE )
	 SELECT DISTINCT bob.ORDER_NBR, bob.BRDCAST_YEAR, bob.BRDCAST_MONTH, vmh.MEDIA_FROM, vmh.CL_CODE, vmh.DIV_CODE, vmh.PRD_CODE  
	   FROM dbo.BCC_ORDER_BRDCAST bob
 INNER JOIN dbo.V_MEDIA_HDR vmh ON ( bob.ORDER_NBR = vmh.ORDER_NBR ) 	   
	  WHERE bob.BCC_ID = @bcc_id_in

	 SELECT ORDER_NUMBER, LINE_NUMBER, BRDCAST_YEAR, BRDCAST_MONTH, MEDIA_FROM, CL_CODE, DIV_CODE, PRD_CODE 
	   FROM @order_list
   ORDER BY 3 ASC, 4 ASC, 5 ASC, 6 ASC, 2 ASC, 1 ASC
