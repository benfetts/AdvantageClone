--test

BEGIN
UPDATE GRID_COLUMN
SET IS_EDITABLE = 1
WHERE NAME = 'TaskStatusDescription'
AND GRID_ID = (SELECT GRID_ID FROM GRID WHERE NAME = 'RadGridAlertInbox')
END

BEGIN
UPDATE GRID_COLUMN
SET IS_EDITABLE = 1
WHERE NAME = 'TaskStatusDescription'
AND GRID_ID = (SELECT GRID_ID FROM GRID WHERE NAME = 'AAMTaskViewGrid')
END

BEGIN
UPDATE GRID_COLUMN
SET IS_EDITABLE = 1
WHERE NAME = 'TaskStatusDescription'
AND GRID_ID = (SELECT GRID_ID FROM GRID WHERE NAME = 'RadGridAlertDismissed')
END

BEGIN
UPDATE GRID_COLUMN
SET IS_EDITABLE = 1
WHERE NAME = 'TaskStatusDescription'
AND GRID_ID = (SELECT GRID_ID FROM GRID WHERE NAME = 'RadGridAlertAll')
END

BEGIN
UPDATE GRID_COLUMN
SET IS_EDITABLE = 1
WHERE NAME = 'TaskStatusDescription'
AND GRID_ID = (SELECT GRID_ID FROM GRID WHERE NAME = 'RadGridAlertDrafts')
END
