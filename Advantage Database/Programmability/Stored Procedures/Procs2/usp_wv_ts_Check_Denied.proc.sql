SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_ts_Check_Denied]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_ts_Check_Denied]
GO
























CREATE PROCEDURE [dbo].[usp_wv_ts_Check_Denied]
@UserID			VARCHAR(100)
 AS

DECLARE @EMP_CODE AS VARCHAR(6)

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)


 SELECT COUNT(*) FROM EMP_TIME AS et WITH (NOLOCK)
		 		 WHERE EMP_CODE = @EMP_CODE AND APPR_PENDING = 2 
   AND EXISTS ( SELECT * FROM AGENCY WHERE TIME_APPR_ACTIVE = 1 )



















GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

