IF NOT EXISTS(SELECT 1 FROM [dbo].[MEDIA_DEMO_SOURCE] WHERE [MEDIA_DEMO_SOURCE_ID] = 3) BEGIN

	INSERT INTO [dbo].[MEDIA_DEMO_SOURCE]([MEDIA_DEMO_SOURCE_ID], [NAME]) VALUES(3, 'Australia')

END
GO