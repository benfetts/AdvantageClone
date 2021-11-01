CREATE PROCEDURE [dbo].[advsp_bill_select_m_order_line] 
	@bcc_id_in integer, @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @selection TABLE (
	selection_id		integer identity( 1, 1 ) NOT NULL,
	CL_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	ORDER_NUMBER		integer NOT NULL,
	LINE_NUMBER			integer NOT NULL,
	ORDER_DESC			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MEDIA_FROM			varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	UNITS				varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,	
	cc_selected			smallint NULL
)

SELECT @ret_val = 0

IF ( @bcc_id_in IS NOT NULL )
	INSERT INTO @selection ( CL_CODE, ORDER_NUMBER, LINE_NUMBER, ORDER_DESC, MEDIA_FROM, UNITS, cc_selected )
		 SELECT DISTINCT vmh.CL_CODE, bol.ORDER_NBR, bol.LINE_NBR, vmh.ORDER_DESC, vmh.MEDIA_FROM, vmh.UNITS, 1
		   FROM dbo.V_MEDIA_HDR vmh 
	 INNER JOIN dbo.BCC_ORDER_LINE bol
			 ON ( vmh.ORDER_NBR = bol.ORDER_NBR )
		  WHERE bol.BCC_ID = @bcc_id_in
		UNION ALL
		 SELECT DISTINCT vmh.CL_CODE, bob.ORDER_NBR, bob.LINE_NBR, vmh.ORDER_DESC, vmh.MEDIA_FROM, vmh.UNITS, 1
		   FROM dbo.V_MEDIA_HDR vmh 
	 INNER JOIN dbo.BCC_ORDER_BRDCAST bob 
			 ON ( vmh.ORDER_NBR = bob.ORDER_NBR )
		  WHERE bob.BCC_ID = @bcc_id_in
		    AND ( bob.LINE_NBR IS NOT NULL AND bob.LINE_NBR <> 0 )

INSERT INTO @selection ( CL_CODE, ORDER_NUMBER, LINE_NUMBER, ORDER_DESC, MEDIA_FROM, UNITS, cc_selected )
	 SELECT DISTINCT vmh.CL_CODE, vmh.ORDER_NBR, vmomrs.LINE_NBR, vmh.ORDER_DESC, vmh.MEDIA_FROM, vmh.UNITS, 0
	   FROM dbo.V_MEDIA_HDR vmh
 INNER JOIN dbo.V_MEDIA_ORDER_MAX_REV_SEQ vmomrs
		 ON ( vmh.ORDER_NBR = vmomrs.ORDER_NBR ) 
	  WHERE ( vmh.MEDIA_TYPE IS NOT NULL )
	    AND ( vmh.ORD_PROCESS_CONTRL IN ( 1, 5 )) 
		AND ( vmh.MEDIA_FROM NOT IN ( 'Mag', 'News' ))
		AND NOT EXISTS ( SELECT * 
						   FROM @selection 
						  WHERE ORDER_NUMBER = vmh.ORDER_NBR
						    AND LINE_NUMBER = vmomrs.LINE_NBR
							AND cc_selected = 1 )  

/*****************************************************************************************/
  SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
        [OrderNumber] = s.ORDER_NUMBER,
        [LineNumber] = s.LINE_NUMBER,
        [OrderDescription] = s.ORDER_DESC,
        [MediaFrom] = s.MEDIA_FROM,
        [Units] = s.UNITS,
        [IsSelected] = s.cc_selected
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
		INNER JOIN (
					SELECT ORDER_NBR, [STATUS]
					FROM dbo.INTERNET_HEADER
					UNION
					SELECT ORDER_NBR, [STATUS]
					FROM dbo.MAGAZINE_HEADER
					UNION
					SELECT ORDER_NBR, [STATUS]
					FROM dbo.NEWSPAPER_HEADER 
					UNION
					SELECT ORDER_NBR, [STATUS]
					FROM dbo.OUTDOOR_HEADER 
					UNION
					SELECT ORDER_NBR, [STATUS]
					FROM dbo.RADIO_HEADER 
					UNION
					SELECT ORDER_NBR, [STATUS]
					FROM dbo.TV_HEADER
					UNION
					SELECT ORDER_NBR, [STATUS]
					FROM dbo.RADIO_HDR
					UNION
					SELECT ORDER_NBR, [STATUS]
					FROM dbo.TV_HDR
				) orders ON s.ORDER_NUMBER = orders.ORDER_NBR AND COALESCE(orders.[STATUS],0) = 0
ORDER BY s.MEDIA_FROM ASC, s.ORDER_NUMBER DESC, s.LINE_NUMBER ASC 
