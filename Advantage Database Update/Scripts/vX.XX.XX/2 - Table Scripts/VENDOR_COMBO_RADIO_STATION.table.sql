IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'VENDOR_COMBO_RADIO_STATION') BEGIN

    DROP TABLE [dbo].[VENDOR_COMBO_RADIO_STATION]

END
GO

IF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'VENDOR_COMBO_RADIO_STATION') BEGIN

    CREATE TABLE [dbo].[VENDOR_COMBO_RADIO_STATION](
	    [VENDOR_COMBO_RADIO_STATION_ID] int IDENTITY(1,1) NOT NULL, 
        [VN_CODE] varchar(6) NOT NULL, 
        [NIELSEN_RADIO_STATION_COMBO_ID] int NOT NULL,
    CONSTRAINT [PK_VENDOR_COMBO_RADIO_STATION] PRIMARY KEY CLUSTERED 
    (
        [VENDOR_COMBO_RADIO_STATION_ID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]

	ALTER TABLE [dbo].[VENDOR_COMBO_RADIO_STATION]  WITH CHECK ADD  CONSTRAINT [FK_VENDOR_COMBO_RADIO_STATION_VENDOR] FOREIGN KEY([VN_CODE])
	REFERENCES [dbo].[VENDOR] ([VN_CODE])

	ALTER TABLE [dbo].[VENDOR_COMBO_RADIO_STATION] CHECK CONSTRAINT [FK_VENDOR_COMBO_RADIO_STATION_VENDOR]

END
GO
