CREATE PROCEDURE [dbo].[advsp_bill_select_m_cli_div_prd] 
	@bcc_id_in integer, @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @selection TABLE (
	selection_id		integer identity( 1, 1 ) NOT NULL,
	CL_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	DIV_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	PRD_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	PRD_DESC			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	cc_selected			smallint NULL
)	

SELECT @ret_val = 0

IF ( @bcc_id_in IS NOT NULL )
	INSERT INTO @selection ( CL_CODE, DIV_CODE, PRD_CODE, PRD_DESC, cc_selected )
		 SELECT DISTINCT C.CL_CODE, C.DIV_CODE, C.PRD_CODE, PRD_DESCRIPTION, 1
		   FROM dbo.PRODUCT C 
	 INNER JOIN dbo.V_MEDIA_HDR B 
			 ON ( C.CL_CODE = B.CL_CODE ) AND ( C.DIV_CODE = B.DIV_CODE ) AND ( C.PRD_CODE = B.PRD_CODE )
		  WHERE BCC_ID = @bcc_id_in

INSERT INTO @selection ( CL_CODE, DIV_CODE, PRD_CODE, PRD_DESC, cc_selected )
SELECT DISTINCT P.CL_CODE, P.DIV_CODE, P.PRD_CODE, PRD_DESCRIPTION, 0
FROM dbo.PRODUCT P
	INNER JOIN dbo.CLIENT C ON P.CL_CODE = C.CL_CODE AND C.ACTIVE_FLAG = 1
	INNER JOIN dbo.DIVISION D ON P.CL_CODE = D.CL_CODE AND P.DIV_CODE = D.DIV_CODE AND D.ACTIVE_FLAG = 1
	INNER JOIN dbo.V_MEDIA_HDR B ON  P.CL_CODE = B.CL_CODE AND P.DIV_CODE = B.DIV_CODE AND P.PRD_CODE = B.PRD_CODE
WHERE P.ACTIVE_FLAG = 1
AND	B.MEDIA_TYPE IS NOT NULL
AND B.ORD_PROCESS_CONTRL IN ( 1, 5 )
AND BCC_ID IS NULL
AND B.MEDIA_FROM NOT IN ( 'Mag', 'News' )
AND NOT EXISTS (SELECT * 
				FROM @selection 
				WHERE CL_CODE = P.CL_CODE
				AND DIV_CODE = P.DIV_CODE
				AND PRD_CODE = P.PRD_CODE
				AND cc_selected = 1 )  


  SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
        [DivisionCode] = s.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
        [ProductCode] = s.PRD_CODE,
        [ProductDescription] = s.PRD_DESC,
        [IsSelected] = s.cc_selected
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
		INNER JOIN dbo.DIVISION D ON s.CL_CODE = D.CL_CODE AND s.DIV_CODE = D.DIV_CODE
ORDER BY s.CL_CODE ASC, s.DIV_CODE ASC, s.PRD_CODE ASC
