CREATE TABLE [dbo].[LicenseKeyHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClientCode] [varchar](6) NOT NULL,
	[UserCode] [varchar](100) NOT NULL,
	[EmployeeCode] [varchar](6) NOT NULL,
	[EmployeeName] [varchar](100) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[DaysUntilFileExpires] [int] NOT NULL,
	[DaysUntilKeyExpires] [int] NOT NULL,
	[PowerLicenseQuantity] [int] NOT NULL,
	[WebvantageOnlyLicenseQuantity] [int] NOT NULL,
	[ClientPortalLicenseQuantity] [int] NOT NULL,
	[EncrpytedLicenseKey] [varchar](MAX) NOT NULL,
 CONSTRAINT [PK_LicenseKeyHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


