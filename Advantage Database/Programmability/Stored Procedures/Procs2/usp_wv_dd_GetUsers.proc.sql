SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dd_GetUsers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dd_GetUsers]
GO


























CREATE PROCEDURE [dbo].[usp_wv_dd_GetUsers] AS

Set NoCount On

SELECT     USER_CODE as code, USER_NAME as description
FROM         SEC_USER

























GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

