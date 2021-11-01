
update JOB_TRAFFIC_SETUP_ITEMS set ACTIVE = 1, COLUMN_LONG_DESC = 'Add employees to a task by selecting employees from auto complete textbox. (Code)' where COLUMN_NAME = 'colEMP_CODE_TEXT'
update JOB_TRAFFIC_SETUP_ITEMS set ACTIVE = 1, COLUMN_LONG_DESC = 'Add employees to a task by selecting employees from auto complete textbox. (Name)' where COLUMN_NAME = 'colEMP_CODE_TEXT_AUTO'
update JOB_TRAFFIC_SETUP_ITEMS set ACTIVE = 1, COLUMN_LONG_DESC = 'Add client contacts to a task by selecting contacts from auto complete textbox. (Code)' where COLUMN_NAME = 'colCLI_CONTACT_TEXT'
update JOB_TRAFFIC_SETUP_ITEMS set ACTIVE = 3, COLUMN_LONG_DESC = 'Add client contacts to a task by selecting contacts from auto complete textbox. (Name)' where COLUMN_NAME = 'colCLI_CONTACT'

update JOB_TRAFFIC_SETUP_ITEMS set COLUMN_LONG_DESC = 'Add predecessors by entering into a textbox.',COLUMN_SHORT_DESC='Predecessors' where COLUMN_NAME = 'GridTemplateColumnInputPreds'
delete from JOB_TRAFFIC_SETUP_ITEMS where COLUMN_NAME = 'GridTemplateColumnPreds'

update JOB_TRAFFIC_SETUP_ITEMS set ACTIVE=0 where COLUMN_NAME = 'colCLI_CONTACT_IMGBTN' or COLUMN_NAME = 'colEMP_CODE' or COLUMN_NAME = 'colEMP_CODE_IMGBTN'


