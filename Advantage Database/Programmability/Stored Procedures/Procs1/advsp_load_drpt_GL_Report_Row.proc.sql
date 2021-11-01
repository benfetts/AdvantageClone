CREATE PROCEDURE [dbo].[advsp_load_drpt_GL_Report_Row]
AS
BEGIN

/*
	06/01/18:  GL Report Row dataset 

*/

SET NOCOUNT ON

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT 
[ReportName]=[dbo].[GL_REPORT].[DESCRIPTION],
[Description]= [dbo].[GL_REPORT_ROW].[DESCRIPTION],
[Visible]= CASE WHEN ISNULL([IS_VISIBLE],0) = 0 THEN 'No' ELSE 'Yes' END,
[ReportType]= CASE WHEN [TYPE] = 1 THEN 'Account'
			 WHEN [TYPE] = 2 THEN 'Total'
			 WHEN [TYPE] = 3 THEN 'Other'
			 ELSE '' END,
[DisplayType]=CASE WHEN [DISPLAY_TYPE] = 1 THEN 'Description'
			 WHEN [DISPLAY_TYPE] = 2 THEN 'FullAccount'
			 WHEN [DISPLAY_TYPE] = 3 THEN 'AccountCode'
			 WHEN [DISPLAY_TYPE] = 4 THEN 'AccountDescription'
			 ELSE '' END,
[Balance]=CASE WHEN [BALANCE_TYPE] = 1 THEN 'Credit'
			 WHEN [BALANCE_TYPE] = 2 THEN 'Debit'
			 ELSE '' END,
[IndentSpaces]=[INDENT_SPACES],
[Rollup]=CASE WHEN ISNULL([ROLLUP],0) = 0 THEN 'No' ELSE 'Yes' END,
[Styles]=CASE WHEN IS_BOLD = 1 AND UNDERLINE_AMOUNT = 1 AND DOUBLE_UNDERLINE_AMOUNT = 1 THEN 'Bold, Underlined and Double Underlined' 
			  WHEN IS_BOLD = 1 AND UNDERLINE_AMOUNT = 1 AND DOUBLE_UNDERLINE_AMOUNT = 0 THEN 'Bold and Underlined' 
			  WHEN IS_BOLD = 1 AND UNDERLINE_AMOUNT = 0 AND DOUBLE_UNDERLINE_AMOUNT = 1 THEN 'Bold and Double Underlined' 
			  WHEN IS_BOLD = 0 AND UNDERLINE_AMOUNT = 1 AND DOUBLE_UNDERLINE_AMOUNT = 1 THEN 'Underlined and Double Underlined' 
			  WHEN IS_BOLD = 1 AND UNDERLINE_AMOUNT = 0 AND DOUBLE_UNDERLINE_AMOUNT = 0 THEN 'Bold' 
			  WHEN IS_BOLD = 0 AND UNDERLINE_AMOUNT = 1 AND DOUBLE_UNDERLINE_AMOUNT = 0 THEN 'Underlined' 
			  WHEN IS_BOLD = 0 AND UNDERLINE_AMOUNT = 0 AND DOUBLE_UNDERLINE_AMOUNT = 1 THEN 'Double Underlined' 
			  ELSE '' END,
[SuppressIfAllZeros]=CASE WHEN ISNULL([SUPPRESS_IF_ALL_ZEROS],0) = 0 THEN 'No' ELSE 'Yes' END,
[AccountRowSelection]=[ROW_INDEX],	
[AccountGroupUsed]=[GROUP_CODE],
[AccountTypeSelected]=CASE WHEN [ACCOUNT_TYPE] = 1 THEN 'Non-Current Asset'
			 WHEN [ACCOUNT_TYPE] = 2 THEN 'Current Asset'
			 WHEN [ACCOUNT_TYPE] = 3 THEN 'Fixed Asset'
			 WHEN [ACCOUNT_TYPE] = 4 THEN 'Non-Current Liability'
			 WHEN [ACCOUNT_TYPE] = 5 THEN 'Current Liability'
			 WHEN [ACCOUNT_TYPE] = 8 THEN 'Income'
			 WHEN [ACCOUNT_TYPE] = 9 THEN 'Income - Other'
			 WHEN [ACCOUNT_TYPE] = 13 THEN 'Expense - COS'
			 WHEN [ACCOUNT_TYPE] = 14 THEN 'Expense - Operating'
			 WHEN [ACCOUNT_TYPE] = 15 THEN 'Expense - Other'
			 WHEN [ACCOUNT_TYPE] = 16 THEN 'Expense - Taxes'
			 WHEN [ACCOUNT_TYPE] = 20 THEN 'Equity'
			 ELSE '' END,
[AccountFrom]=[GLACODE_RANGE_START],
[AccountTo]=[GLACODE_RANGE_TO],
[BaseOnly]=CASE WHEN ISNULL([USE_BASE_ACCOUNT],0) = 0 THEN 'No' ELSE 'Yes' END,
[DataCalculation]=CASE WHEN [DATA_CALCULATION] = 1 THEN 'YearToDate'
			 WHEN [DATA_CALCULATION] = 2 THEN 'SelectedPeriod'
			 WHEN [DATA_CALCULATION] = 3 THEN 'All'
			 ELSE '' END,
[DataOption]=CASE WHEN [DATA_OPTION] = 1 THEN 'EndingBalance'
			 WHEN [DATA_OPTION] = 2 THEN 'BeginningBalance'
			 WHEN [DATA_OPTION] = 3 THEN 'PeriodChange'
			 ELSE '' END

  FROM [dbo].[GL_REPORT_ROW]
  JOIN [dbo].[GL_REPORT] ON [dbo].[GL_REPORT].GL_REPORT_ID = [dbo].[GL_REPORT_ROW].GL_REPORT_ID
END
GO