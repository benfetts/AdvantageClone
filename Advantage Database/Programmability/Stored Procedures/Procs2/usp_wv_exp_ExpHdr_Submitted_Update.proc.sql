﻿























CREATE PROCEDURE [dbo].[usp_wv_exp_ExpHdr_Submitted_Update] 

@INV_NBR varchar(25)

AS

Update EXPENSE_HEADER set SUBMITTED_FLAG = 1, STATUS = 'PENDING' where INV_NBR = @INV_NBR























