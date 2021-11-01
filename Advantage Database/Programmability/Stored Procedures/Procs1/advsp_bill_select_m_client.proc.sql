CREATE PROCEDURE [dbo].[advsp_bill_select_m_client] 
	@bcc_id_in integer, @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @selection TABLE (
	selection_id		integer identity( 1, 1 ) NOT NULL,
	CL_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	CL_NAME				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	cc_selected			smallint NULL
)	

SELECT @ret_val = 0

IF ( @bcc_id_in IS NOT NULL )
	INSERT INTO @selection ( CL_CODE, CL_NAME, cc_selected )
	 SELECT DISTINCT C.CL_CODE, CL_NAME, 1
	   FROM dbo.CLIENT C 
 INNER JOIN dbo.V_MEDIA_HDR B ON ( C.CL_CODE = B.CL_CODE )
	  WHERE BCC_ID = @bcc_id_in

INSERT INTO @selection ( CL_CODE, CL_NAME, cc_selected )
SELECT DISTINCT C.CL_CODE, CL_NAME, 0
FROM dbo.CLIENT C 
	INNER JOIN dbo.V_MEDIA_HDR B ON C.CL_CODE = B.CL_CODE
WHERE B.MEDIA_TYPE IS NOT NULL
AND B.ORD_PROCESS_CONTRL IN ( 1, 5 )
AND BCC_ID IS NULL 
AND B.MEDIA_FROM NOT IN ( 'Mag', 'News' )
AND C.ACTIVE_FLAG = 1
AND NOT EXISTS (SELECT * 
				FROM @selection 
				WHERE CL_CODE = C.CL_CODE
				AND cc_selected = 1)

  SELECT s.CL_CODE, s.CL_NAME, s.cc_selected
	FROM @selection s
ORDER BY s.CL_CODE, s.CL_NAME
