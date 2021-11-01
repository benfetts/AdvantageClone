IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_PaymentCenterGetClients]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[usp_wv_PaymentCenterGetClients]
GO

CREATE PROCEDURE [dbo].[usp_wv_PaymentCenterGetClients]

AS

BEGIN

SELECT CL_CODE AS Code, CL_NAME AS Description FROM CLIENT WITH (NOLOCK) WHERE ACTIVE_FLAG = 1

END


GO
