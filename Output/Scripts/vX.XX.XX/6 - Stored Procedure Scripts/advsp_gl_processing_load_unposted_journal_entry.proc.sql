CREATE PROCEDURE [dbo].[advsp_gl_processing_load_unposted_journal_entry]
	--@START_PERIOD varchar(6),
	--@END_PERIOD varchar(6),
	--@GLSRCODE varchar(2)
AS
BEGIN

SELECT
    [PostPeriodCode] = H.GLEHPP, 
    [PeriodStatus] = CASE P.PPGLCURMTH
                        WHEN 'C' THEN 'Current'
                        ELSE 'Open'
                        END,
    [Transaction] = H.GLEHXACT,
    [HeaderDescription] = G.GLSRDESC,
    [Description] = (SELECT TOP 1 GLETREM FROM dbo.GLENTTRL WHERE GLETXACT = H.GLEHXACT),
    [Source] = H.GLEHSOURCE,
    [DateEntered] = H.GLEHENTDATE,
    [CreatedBy] = H.GLEHUSER
FROM dbo.GLENTHDR H
	INNER JOIN dbo.POSTPERIOD P ON H.GLEHPP = P.PPPERIOD 
    INNER JOIN dbo.GLSOURCE G ON H.GLEHSOURCE = G.GLSRCODE
WHERE 
	H.GLEHPOSTSUM IS NULL
--AND (H.GLEHPP >= @START_PERIOD AND H.GLEHPP <= @END_PERIOD)
AND (H.GLEHVOID = 0 OR H.GLEHVOID IS NULL)
--AND (
--        (@GLSRCODE IS NULL) 
--    OR
--        (H.GLEHSOURCE = @GLSRCODE)
--    )

END
GO