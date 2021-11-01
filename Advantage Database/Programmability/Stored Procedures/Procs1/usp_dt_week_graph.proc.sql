


























/*****************************************************************
Webvantage Desktop 
Modication Description / Date / Developer
=============================================
This stored procedures get the hours on the desktop for graph.   / 02-04-04 / Steve Moreno

******************************************************************/
CREATE PROCEDURE [dbo].[usp_dt_week_graph] 
@empcode  Char(10),
@startdate SmallDateTime
AS
Declare @Sunday  Numeric (20,2)
Declare @Monday  Numeric (20,2)
Declare @Tuesday  Numeric (20,2)
Declare @Wednesday  Numeric (20,2)
Declare @Thursday  Numeric (20,2)
Declare @Friday  Numeric (20,2)
Declare @Saturday  Numeric (20,2)
--Decimal

SET NOCOUNT ON

SELECT @Sunday = ISNULL(SUM(EMP_TOT_HRS), 0.00)
FROM EMP_TIME
WHERE EMP_CODE= @empcode
AND  EMP_DATE= @startdate

SELECT @Monday = ISNULL(SUM(EMP_TOT_HRS), 0.00)
FROM EMP_TIME
WHERE EMP_CODE= @empcode
AND  EMP_DATE= DateAdd(day, 1, @startdate)

SELECT @Tuesday = ISNULL(SUM(EMP_TOT_HRS), 0.00)
FROM EMP_TIME
WHERE EMP_CODE= @empcode
AND  EMP_DATE= DateAdd(day, 2, @startdate)

SELECT @Wednesday = ISNULL(SUM(EMP_TOT_HRS), 0.00)
FROM EMP_TIME
WHERE EMP_CODE= @empcode
AND  EMP_DATE= DateAdd(day, 3, @startdate)

SELECT @Thursday = ISNULL(SUM(EMP_TOT_HRS), 0.00)
FROM EMP_TIME
WHERE EMP_CODE= @empcode
AND  EMP_DATE= DateAdd(day, 4, @startdate)

SELECT @Friday = ISNULL(SUM(EMP_TOT_HRS), 0.00) 
FROM EMP_TIME
WHERE EMP_CODE= @empcode
AND  EMP_DATE= DateAdd(day, 5, @startdate)

SELECT @Saturday = ISNULL(SUM(EMP_TOT_HRS), 0.00)
FROM EMP_TIME
WHERE EMP_CODE= @empcode
AND  EMP_DATE= DateAdd(day, 6, @startdate)

--Select @Sunday as Su, @Monday as Mo, @Tuesday as Tu, @Wednesday as We, @Thursday as Th, @Friday as Fr, @Saturday as Sa
Select @Saturday as Sat, @Friday as Fri, @Thursday as Thu, @Wednesday as Wed, @Tuesday as Tue, @Monday as Mon, @Sunday as Sun

--PRINT convert(varchar(6),@Sunday)  + ' | ' + convert(varchar(6),@Monday)   + ' | ' + convert(varchar(6),@Tuesday)   + ' | ' + convert(varchar(6),@Wednesday)   + ' | ' + convert(varchar(6),@Thursday)   + ' | ' + convert(varchar(6),@Friday)   + ' | ' + convert(varchar(6),@Saturday)

























