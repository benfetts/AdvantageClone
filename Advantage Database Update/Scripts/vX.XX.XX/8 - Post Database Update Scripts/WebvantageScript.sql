﻿-- CLEAR CHAT LOGGER EVERY UPDATE
DELETE FROM CHAT_ACTIVE_USER;

-- UPDATE VERSION
UPDATE ADVAN_UPDATE SET WEBVAN_VERSION_ID = '6.70.08.00';
