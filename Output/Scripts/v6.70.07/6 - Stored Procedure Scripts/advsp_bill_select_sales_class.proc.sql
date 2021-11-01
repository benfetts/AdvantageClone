CREATE PROCEDURE [dbo].[advsp_bill_select_sales_class] 
	@bcc_id_in integer, @media_bill_date_from smalldatetime = NULL, @media_bill_date_to smalldatetime = NULL
AS

SET NOCOUNT ON

DECLARE @selection TABLE (
	SC_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	cc_selected			smallint NULL
)	

DECLARE @IncludeMediaBillDates bit

IF @media_bill_date_from IS NOT NULL AND @media_bill_date_to IS NOT NULL
    SET @IncludeMediaBillDates = 1
ELSE
    SET @IncludeMediaBillDates = 0

IF ( @bcc_id_in IS NOT NULL )
	INSERT INTO @selection ( SC_CODE, cc_selected )
		 SELECT DISTINCT SC.SC_CODE, 1
		   FROM dbo.SALES_CLASS SC INNER JOIN dbo.JOB_LOG A
		     ON SC.SC_CODE = A.SC_CODE INNER JOIN dbo.JOB_COMPONENT B
			 ON A.JOB_NUMBER = B.JOB_NUMBER
		  WHERE B.BCC_ID = @bcc_id_in
          AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND B.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))

INSERT INTO @selection ( SC_CODE, cc_selected )
	 SELECT DISTINCT SC.SC_CODE, 0
	   FROM dbo.SALES_CLASS SC INNER JOIN dbo.JOB_LOG A
	     ON SC.SC_CODE = A.SC_CODE INNER JOIN dbo.JOB_COMPONENT B
		 ON A.JOB_NUMBER = B.JOB_NUMBER
	  WHERE ( SC.INACTIVE_FLAG = 0 OR SC.INACTIVE_FLAG IS NULL ) 
	    AND B.BCC_ID IS NULL
		AND NOT EXISTS ( SELECT * 
						   FROM @selection 
						  WHERE SC_CODE = SC.SC_CODE
							AND cc_selected = 1 )
        AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND B.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))

  SELECT
		[SalesClassCode] = s.SC_CODE,
        [SalesClassDescription] = SC.SC_DESCRIPTION,
        [IsSelected] = s.cc_selected
	FROM @selection s
		INNER JOIN dbo.SALES_CLASS SC ON s.SC_CODE = SC.SC_CODE
ORDER BY s.SC_CODE ASC
