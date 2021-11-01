SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_validate_JobCompNumUserDefined]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_validate_JobCompNumUserDefined]
GO


















CREATE PROCEDURE [dbo].[usp_wv_validate_JobCompNumUserDefined]
@JobCompNum varchar(20),
@UserField varchar(50)

AS

if @UserField = 'JOB_COMPONENT.UDV1_CODE'
	Begin
		SELECT
			COUNT(*)
		FROM
			JOB_CMP_UDV1 WITH (NOLOCK)
		WHERE
			UDV_CODE = @JobCompNum
	End
if @UserField = 'JOB_COMPONENT.UDV2_CODE'
	Begin
		SELECT
			COUNT(*)
		FROM
			JOB_CMP_UDV2 WITH (NOLOCK)
		WHERE
			UDV_CODE = @JobCompNum
	End
if @UserField = 'JOB_COMPONENT.UDV3_CODE'
	Begin
		SELECT
			COUNT(*)
		FROM
			JOB_CMP_UDV3 WITH (NOLOCK)
		WHERE
			UDV_CODE = @JobCompNum
	End
if @UserField = 'JOB_COMPONENT.UDV4_CODE'
	Begin
		SELECT
			COUNT(*)
		FROM
			JOB_CMP_UDV4 WITH (NOLOCK)
		WHERE
			UDV_CODE = @JobCompNum
	End
if @UserField = 'JOB_COMPONENT.UDV5_CODE'
	Begin
		SELECT
			COUNT(*)
		FROM
			JOB_CMP_UDV5 WITH (NOLOCK)
		WHERE
			UDV_CODE = @JobCompNum
	End
















GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

