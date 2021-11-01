--9
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA]

END
GO
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_ESTIMATE_TEMPLATE_VENDOR') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_VENDOR]

END
GO
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_ESTIMATE_TEMPLATE_TACTIC') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_TACTIC]

END
GO
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_ESTIMATE_TEMPLATE_SPOTLENGTH') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_SPOTLENGTH]

END
GO
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_ESTIMATE_TEMPLATE_RATE_TYPE') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_RATE_TYPE]

END
GO
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_ESTIMATE_TEMPLATE_QUARTER') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_QUARTER]

END
GO
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_ESTIMATE_TEMPLATE_PIVOT_FIELD') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_PIVOT_FIELD]

END
GO
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_ESTIMATE_TEMPLATE_OUTDOOR_TYPE') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_OUTDOOR_TYPE]

END
GO
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET]

END
GO
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_ESTIMATE_TEMPLATE_DEMOGRAPHIC') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DEMOGRAPHIC]

END
GO
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART_PERCENT') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART_PERCENT]

END
GO
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART]

END
GO
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_ESTIMATE_TEMPLATE_AD_SIZE') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_AD_SIZE]

END
GO
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_TEMPLATE_DETAIL') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_TEMPLATE_DETAIL]

END
GO
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_TEMPLATE_CLIENT') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_TEMPLATE_CLIENT]

END
GO
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_ESTIMATE_TEMPLATE_PRODUCT') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_PRODUCT]

END
GO
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_TEMPLATE_PRODUCT') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_TEMPLATE_PRODUCT]

END
GO
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_TEMPLATE_HEADER') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_TEMPLATE_HEADER]

END
GO
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_ESTIMATE_TEMPLATE_CLIENT') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_CLIENT]

END
IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_ESTIMATE_TEMPLATE') BEGIN

    DROP TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE]

END
GO
