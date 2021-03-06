IF(SELECT COUNT(1) FROM dbo.NIELSEN_DEMO WHERE MEDIA_DEMO_SOURCE_ID = 4) = 0 BEGIN

    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (82,'pp2P','T','Persons 2+','Persons 2+',2,NULL,NULL,4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (83,'pm2P','T','Males 2+','Males 2+',2,NULL,'M',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (84,'pm2-5','T','Males 2-5','Males 2-5',2,5,'M',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (85,'pm6-11','T','Males 6-11','Males 6-11',6,11,'M',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (86,'pm12-14','T','Males 12-14','Males 12-14',12,14,'M',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (87,'pm15-17','T','Males 15-17','Males 15-17',15,17,'M',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (88,'pm18-20','T','Males 18-20','Males 18-20',18,20,'M',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (89,'pm21-24','T','Males 21-24','Males 21-24',21,24,'M',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (90,'pm25-34','T','Males 25-34','Males 25-34',25,34,'M',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (91,'pm35-44','T','Males 35-44','Males 35-44',35,44,'M',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (92,'pm45-49','T','Males 45-49','Males 45-49',45,49,'M',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (93,'pm50-54','T','Males 50-54','Males 50-54',50,54,'M',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (94,'pm55-64','T','Males 55-64','Males 55-64',55,64,'M',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (95,'pm65P','T','Males 65+','Males 65+',65,NULL,'M',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (96,'pf2P','T','Females 2+','Females 2+',2,NULL,'F',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (97,'pf2-5','T','Females 2-5','Females 2-5',2,5,'F',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (98,'pf6-11','T','Females 6-11','Females 6-11',6,11,'F',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (99,'pf12-14','T','Females 12-14','Females 12-14',12,14,'F',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (100,'pf15-17','T','Females 15-17','Females 15-17',15,17,'F',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (101,'pf18-20','T','Females 18-20','Females 18-20',18,20,'F',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (102,'pf21-24','T','Females 21-24','Females 21-24',21,24,'F',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (103,'pf25-34','T','Females 25-34','Females 25-34',25,34,'F',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (104,'pf35-44','T','Females 35-44','Females 35-44',35,44,'F',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (105,'pf45-49','T','Females 45-49','Females 45-49',45,49,'F',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (106,'pf50-54','T','Females 50-54','Females 50-54',50,54,'F',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (107,'pf55-64','T','Females 55-64','Females 55-64',55,64,'F',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (108,'pf65P','T','Females 65+','Females 65+',65,NULL,'F',4)
    INSERT INTO dbo.NIELSEN_DEMO (NIELSEN_DEMO_ID, CODE, [TYPE], SHORT_DESCRIPTION, LONG_DESCRIPTION, AGE_FROM, AGE_TO, GENDER, MEDIA_DEMO_SOURCE_ID) VALUES (109,'pww','T','Working Women','Working Women',NULL,NULL,NULL,4)

END
