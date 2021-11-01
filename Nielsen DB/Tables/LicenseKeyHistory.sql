CREATE TABLE [dbo].[LicenseKeyHistory] (
    [ID]                            INT           NOT NULL,
    [ClientCode]                    VARCHAR (6)   NOT NULL,
    [AgencyName]                    VARCHAR (40)  NOT NULL,
    [UserCode]                      VARCHAR (100) NOT NULL,
    [EmployeeCode]                  VARCHAR (6)   NOT NULL,
    [EmployeeName]                  VARCHAR (100) NOT NULL,
    [CreatedDate]                   DATETIME      NOT NULL,
    [DaysUntilFileExpires]          INT           NOT NULL,
    [DaysUntilKeyExpires]           INT           NOT NULL,
    [PowerLicenseQuantity]          INT           NOT NULL,
    [WebvantageOnlyLicenseQuantity] INT           NOT NULL,
    [ClientPortalLicenseQuantity]   INT           NOT NULL,
    [IsActive]                      BIT           NOT NULL,
    [DeactivatedDate]               DATETIME      NOT NULL,
    [Comment]                       VARCHAR (MAX) NOT NULL,
    [EncrpytedLicenseKey]           VARCHAR (MAX) NOT NULL,
    [MediaToolsUsersQuantity]       INT           NOT NULL,
    [APIUsersQuantity]              INT           NOT NULL
);

