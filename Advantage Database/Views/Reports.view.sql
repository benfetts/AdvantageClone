﻿
CREATE VIEW dbo.Reports ( ReportFile, ReportName, ReportType, ReportActive, ReportCategory, ReportNumber, ReportSub ) 
AS
 SELECT ALL REPORTFILE, REPORTNAME, REPORTTYPE, REPORTACTIVE, REPORTCATEGORY, REPORTNUMBER, REPORTSUB
   FROM REPORTS
