CREATE PROCEDURE [dbo].[advsp_bill_select_m_cli_div] 
	@bcc_id_in integer, @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @selection TABLE (
	selection_id		integer identity( 1, 1 ) NOT NULL,	
	CL_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	DIV_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	DIV_NAME			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	cc_selected			smallint NULL
)	

SELECT @ret_val = 0

IF ( @bcc_id_in IS NOT NULL )
	INSERT INTO @selection ( CL_CODE, DIV_CODE, DIV_NAME, cc_selected )
		 SELECT DISTINCT C.CL_CODE, C.DIV_CODE, C.DIV_NAME, 1
		   FROM dbo.DIVISION C 
	 INNER JOIN dbo.V_MEDIA_HDR B ON ( C.CL_CODE = B.CL_CODE ) AND ( C.DIV_CODE = B.DIV_CODE )
		  WHERE BCC_ID = @bcc_id_in
		  
INSERT INTO @selection ( CL_CODE, DIV_CODE, DIV_NAME, cc_selected )
SELECT DISTINCT D.CL_CODE, D.DIV_CODE, D.DIV_NAME, 0
FROM dbo.DIVISION D
	INNER JOIN dbo.CLIENT C ON D.CL_CODE = C.CL_CODE AND C.ACTIVE_FLAG = 1
	INNER JOIN dbo.V_MEDIA_HDR B ON D.CL_CODE = B.CL_CODE AND D.DIV_CODE = B.DIV_CODE
WHERE D.ACTIVE_FLAG = 1 
AND B.MEDIA_TYPE IS NOT NULL
AND B.ORD_PROCESS_CONTRL IN ( 1, 5 )
AND	BCC_ID IS NULL
AND B.MEDIA_FROM NOT IN ( 'Mag', 'News' )
AND NOT EXISTS (SELECT * 
				FROM @selection 
				WHERE CL_CODE = D.CL_CODE
				AND DIV_CODE = D.DIV_CODE
				AND cc_selected = 1)

  SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
        [DivisionCode] = s.DIV_CODE,
        [DivisionName] = s.DIV_NAME,
        [IsSelected] = s.cc_selected
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
ORDER BY s.CL_CODE, s.DIV_CODE, s.DIV_NAME
