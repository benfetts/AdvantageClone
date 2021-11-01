CREATE PROCEDURE [dbo].[advsp_load_drpt_GL_chart_of_Accounts]
AS
BEGIN

/*
	06/01/18:  Chart of Accounts dataset 

*/

SET NOCOUNT ON

	


SELECT 
       [GLAccount]=[dbo].[GLACCOUNT].[GLACODE]
      ,[Description]=[GLADESC]
	  ,[Base]=[GLABASE]
	  ,[Dept]=[GLADEPT]
      ,[Office]=[GLAOFFICE]
      ,[Other]=[GLAOTHER]
      ,[AccountGroupCode] = [ACCOUNT_GROUP_DTL].GROUP_CODE
	  ,[AccountGroupDesc] =  [ACCOUNT_GROUP].GROUP_DESC
	  ,[AccountType] = CASE WHEN [GLACCOUNT].[GLATYPE] = 1 THEN 'Non-Current Asset'
			 WHEN [GLACCOUNT].[GLATYPE] = 2 THEN 'Current Asset'
			 WHEN [GLACCOUNT].[GLATYPE] = 3 THEN 'Fixed Asset'
			 WHEN [GLACCOUNT].[GLATYPE] = 4 THEN 'Non-Current Liability'
			 WHEN [GLACCOUNT].[GLATYPE] = 5 THEN 'Current Liability'
			 WHEN [GLACCOUNT].[GLATYPE] = 8 THEN 'Income'
			 WHEN [GLACCOUNT].[GLATYPE] = 9 THEN 'Income - Other'
			 WHEN [GLACCOUNT].[GLATYPE] = 13 THEN 'Expense - COS'
			 WHEN [GLACCOUNT].[GLATYPE] = 14 THEN 'Expense - Operating'
			 WHEN [GLACCOUNT].[GLATYPE] = 15 THEN 'Expense - Other'
			 WHEN [GLACCOUNT].[GLATYPE] = 16 THEN 'Expense - Taxes'
			 WHEN [GLACCOUNT].[GLATYPE] = 20 THEN 'Equity'
			 ELSE '' END
	  ,[BalanceType] = CASE WHEN [GLABALTYPE] = 0 THEN 'Credit' ELSE 'Debit' END
	  ,[PayrollIndicator] = CASE WHEN ISNULL([GLAPAYROLL],0) = 0 THEN 'No' ELSE 'Yes' END
	  ,[POIndicator] = CASE WHEN ISNULL([GLPO],0) = 0 THEN 'No' ELSE 'Yes' END
	  ,[CDPRequired] = CASE WHEN ISNULL([GLACDPREQ],0) = 0 THEN 'No' ELSE 'Yes' END
	  ,[DateEntered] = [GLAENTDATE]
	  ,[ModifiedDate] = [GLAMODDATE]
	  ,[CreateUser] = CASE WHEN ISNULL([GLAENTDATE],'')='' THEN '' ELSE [GLAUSER] END
	  ,[ModifiedbyUser] = CASE WHEN ISNULL([GLAMODDATE],'')='' THEN '' ELSE [GLAUSER] END
	  ,[InactiveFlag] = CASE WHEN [GLAACTIVE] = 'A'  THEN 'Active' ELSE 'Inactive' END

FROM [dbo].[GLACCOUNT]
LEFT OUTER JOIN [dbo].[ACCOUNT_GROUP_DTL] ON ([dbo].[ACCOUNT_GROUP_DTL].[GLACODE] = [dbo].[GLACCOUNT].[GLACODE] OR [dbo].[ACCOUNT_GROUP_DTL].[GLACODE] BETWEEN [GLACODE_FROM] AND [GLACODE_TO])
LEFT OUTER JOIN  [dbo].[ACCOUNT_GROUP] ON  [dbo].[ACCOUNT_GROUP].[GROUP_CODE] =  [dbo].[ACCOUNT_GROUP_DTL].[GROUP_CODE]

END
GO