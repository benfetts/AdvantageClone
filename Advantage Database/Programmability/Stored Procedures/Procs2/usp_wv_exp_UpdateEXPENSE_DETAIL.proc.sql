






















CREATE PROCEDURE [dbo].[usp_wv_exp_UpdateEXPENSE_DETAIL]
	@EXPDETAILID int,
	@ITEM_DATE datetime,
	@ITEM_DESC varchar(200),
	@CC_FLAG bit,
	@QTY int,
	@RATE decimal(9, 3),
	@AMOUNT decimal(14, 2), 
	@MOD_USER_ID varchar(6),
	@MOD_DATE datetime
AS

UPDATE [dbo].[EXPENSE_DETAIL] SET
	[ITEM_DATE] = @ITEM_DATE,
	[ITEM_DESC] = @ITEM_DESC,
	[CC_FLAG] = @CC_FLAG,
	[QTY] = @QTY,
	[RATE] = @RATE,
	[AMOUNT] = @AMOUNT,
	[MOD_USER_ID] = @MOD_USER_ID,
	[MOD_DATE] = @MOD_DATE
WHERE
	[EXPDETAILID] = @EXPDETAILID




















