




























/*****************************************************************
Webvantage Desktop 
Modication Description / Date / Developer
=============================================
This stored procedures get the hours on the desktop.   / 01-24-04 / Steve Moreno

******************************************************************/
CREATE PROCEDURE [dbo].[usp_dt_week_hours] 
@empcode  Char(10),
@startdate DateTime 

AS

SET NOCOUNT ON

declare @Sunday as Decimal(8,2) 
declare @Monday as Decimal(8,2)
declare @Tuesday as Decimal(8,2)
declare @Wednesday as Decimal(8,2)
declare @Thursday as Decimal(8,2)
declare @Friday as Decimal(8,2)
declare @Saturday as Decimal(8,2)
declare @TotalHours as Decimal(8,2)

SELECT @Monday = ISNULL(SUM(EMP_TOT_HRS), 0)
FROM EMP_TIME
WHERE EMP_CODE= @empcode
AND  EMP_DATE= DateAdd(day, 1, @startdate)

SELECT @Tuesday = ISNULL(SUM(EMP_TOT_HRS), 0)
FROM EMP_TIME
WHERE EMP_CODE= @empcode
AND  EMP_DATE= DateAdd(day, 2, @startdate)

SELECT @Wednesday = ISNULL(SUM(EMP_TOT_HRS), 0)
FROM EMP_TIME
WHERE EMP_CODE= @empcode
AND  EMP_DATE= DateAdd(day, 3, @startdate)

SELECT @Thursday = ISNULL(SUM(EMP_TOT_HRS), 0)
FROM EMP_TIME
WHERE EMP_CODE= @empcode
AND  EMP_DATE= DateAdd(day, 4, @startdate)

SELECT @Friday = ISNULL(SUM(EMP_TOT_HRS), 0) 
FROM EMP_TIME
WHERE EMP_CODE= @empcode
AND  EMP_DATE= DateAdd(day, 5, @startdate)

SELECT @Saturday = ISNULL(SUM(EMP_TOT_HRS), 0)
FROM EMP_TIME
WHERE EMP_CODE= @empcode
AND  EMP_DATE= DateAdd(day, 6, @startdate)

SELECT @Sunday = ISNULL(SUM(EMP_TOT_HRS), 0)
FROM EMP_TIME
WHERE EMP_CODE= @empcode
AND  EMP_DATE= DateAdd(day, 7, @startdate)

Select @TotalHours = @Sunday + @Monday + @Tuesday + @Wednesday + @Thursday + @Friday + @Saturday

--PRINT convert(varchar(6),@Sunday)  + ' | ' + convert(varchar(6),@Monday)   + ' | ' + convert(varchar(6),@Tuesday)   + ' | ' + convert(varchar(6),@Wednesday)   + ' | ' + convert(varchar(6),@Thursday)   + ' | ' + convert(varchar(6),@Friday)   + ' | ' + convert(varchar(6),@Saturday)

Select convert(varchar(6),@TotalHours) as TotalHours, convert(varchar(6),@Monday) as Monday, convert(varchar(6),@Tuesday) as Tuesday, convert(varchar(6),@Wednesday) as Wednesday, convert(varchar(6),@Thursday) as Thursday, convert(varchar(6),@Friday) as Friday, convert(varchar(6),@Saturday) as Saturday, convert(varchar(6),@Sunday) as Sunday
























