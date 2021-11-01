-- Creates table MEDIA_ORDER_HEADER (JP 8/20/2012)

SET QUOTED_IDENTIFIER ON 
GO

SET ANSI_NULLS ON 
GO

SET ANSI_PADDING OFF
GO

IF ( OBJECT_ID( N'MEDIA_ORDER_HEADER', 'U' ) IS NOT NULL )
	DROP TABLE dbo.MEDIA_ORDER_HEADER
GO	

CREATE TABLE dbo.MEDIA_ORDER_HEADER (
	MH_ID						integer identity(1, 1) NOT NULL,
	[USER_ID]					varchar(100) NOT NULL,
	[TYPE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,	
	ORDER_NBR					int NOT NULL,
	REV_NBR						smallint NULL,
	OFFICE_CODE					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CL_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRD_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CLIDIVPRD					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_DESC					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_COMMENT				text,
	VN_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	VR_CODE						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	VR_CODE2					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CMP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CMP_IDENTIFIER				smallint NULL,
	CMP_NAME					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MEDIA_TYPE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BILL_TYPE_FLAG				tinyint NULL,
	POST_BILL					tinyint NULL,
	NET_GROSS					tinyint NULL,
	MARKET_CODE					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MARKET_DESC					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_DATE					smalldatetime NULL,
	FLIGHT_FROM					smalldatetime NULL,
	FLIGHT_TO					smalldatetime NULL,
	ORD_PROCESS_CONTRL			tinyint NULL,
	BUYER						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CLIENT_PO					varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS,
	LINK_ID						int NULL,
	ADVAN_TYPE					tinyint NULL,
	ORDER_ACCEPTED				tinyint NULL,
  CONSTRAINT PK_MEDIA_ORDER_HEADER PRIMARY KEY ( MH_ID ))
GO

GRANT ALL ON MEDIA_ORDER_HEADER TO PUBLIC AS dbo
GO