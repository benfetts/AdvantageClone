--This is a template to transfer those rows from NIELSENDATASTORE to NIELSENHOSTED
DECLARE @MAXID bigint

SELECT @MAXID = COALESCE(MAX(NIELSEN_RADIO_AUDIENCE_ID), 0)
FROM NIELSENHOSTED.dbo.NIELSEN_RADIO_AUDIENCE

SELECT *
FROM dbo.NIELSEN_RADIO_AUDIENCE
WHERE NIELSEN_RADIO_AUDIENCE_ID > @MAXID