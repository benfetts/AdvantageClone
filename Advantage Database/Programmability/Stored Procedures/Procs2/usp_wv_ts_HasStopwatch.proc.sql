SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_ts_HasStopwatch]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_ts_HasStopwatch]
GO
CREATE PROCEDURE [dbo].[usp_wv_ts_HasStopwatch] /*WITH ENCRYPTION*/
@EMP_CODE VARCHAR(6),
@START_DATE SMALLDATETIME,
@END_DATE SMALLDATETIME
AS
/*=========== QUERY ===========*/

		SELECT * FROM [dbo].[fn_ts_has_stopwatch](@EMP_CODE, @START_DATE, @END_DATE);

/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO