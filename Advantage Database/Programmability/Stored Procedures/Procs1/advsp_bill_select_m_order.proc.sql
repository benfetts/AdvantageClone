CREATE PROCEDURE [dbo].[advsp_bill_select_m_order] 
	@bcc_id_in integer, @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @selection TABLE (
	selection_id		integer identity( 1, 1 ) NOT NULL,
	CL_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	ORDER_NUMBER		integer NOT NULL,
	ORDER_DESC			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MEDIA_FROM			varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	UNITS				varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	cc_selected			smallint NULL
)	

SELECT @ret_val = 0

IF ( @bcc_id_in IS NOT NULL )
	INSERT INTO @selection ( CL_CODE, ORDER_NUMBER, ORDER_DESC, MEDIA_FROM, UNITS, cc_selected )
		 SELECT DISTINCT CL_CODE, ORDER_NBR, ORDER_DESC, MEDIA_FROM, UNITS, 1
		   FROM dbo.V_MEDIA_HDR
		  WHERE BCC_ID = @bcc_id_in

INSERT INTO @selection ( CL_CODE, ORDER_NUMBER, ORDER_DESC, MEDIA_FROM, UNITS, cc_selected )
	 SELECT DISTINCT CL_CODE, ORDER_NBR, ORDER_DESC, MEDIA_FROM, UNITS, 0
	   FROM dbo.V_MEDIA_HDR
	  WHERE ( MEDIA_TYPE IS NOT NULL )
	    AND ( ORD_PROCESS_CONTRL IN ( 1, 5 )) 
		AND ( BCC_ID IS NULL )
		AND ( MEDIA_FROM NOT IN ( 'Mag', 'News' ))
		AND NOT EXISTS ( SELECT * 
						   FROM @selection 
						  WHERE ORDER_NUMBER = dbo.V_MEDIA_HDR.ORDER_NBR
							AND cc_selected = 1 )  

/*****************************************************************************************/
  SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
        [OrderNumber] = s.ORDER_NUMBER,
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
ORDER BY s.MEDIA_FROM ASC, s.ORDER_NUMBER DESC 
