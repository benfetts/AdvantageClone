
IF NOT EXISTS(SELECT * FROM EXPORT_SYSTEMS WHERE EXPORT_SYSTEM = 'PAYMENT_MANAGER' AND ADV_COL_NAME = 'WFB2') BEGIN

	INSERT INTO dbo.EXPORT_SYSTEMS (EXPORT_SYSTEM, COLUMN_LABEL, ADV_COL_NAME) VALUES ('PAYMENT_MANAGER', 'Wells Fargo Bank FF2', 'WFB2')
		
END

