/* Exceptions to maximize as default on open */
/* logic reversed 2018/10/18 */
function excludeFromMaximize(windowUrl) {
    var excludeIt = true;
    if (windowUrl.indexOf("Desktop_AlertView") > -1) {
        excludeIt = true;
        return excludeIt;
    }
    if (windowUrl.indexOf("Alert_Inbox") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("Calendar_MonthView") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("Desktop_CRMCentral") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("Documents.aspx") > -1 && windowUrl.indexOf("Maintenance_") === -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("Reporting_DynamicReports") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("Reporting_UserDefinedReports") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("SupervisorApproval") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("SuperApprExpense") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("_V2.aspx") > -1) {  //Expense list and expense edit
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("Timesheet.aspx") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("Boards") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("Sprint") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("Campaign.aspx") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("Estimating_Quote.aspx") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("Content.aspx") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("QuoteVsActualSummary") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.toUpperCase().indexOf("MEDIACALENDAR.ASPX") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("Media_ATB.aspx") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("_Search.aspx") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("BillingApproval_View") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("EmployeeTimeForecast_Main") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("EmployeeTimeForecast_Edit") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("JobForecast_Main") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("JobForecast_Edit") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("Maintenance_AlertAssignments") > -1) {
        excludeIt = false;
        return excludeIt;
    }
    if (windowUrl.indexOf("Maintenance_") > -1) {
        if (windowUrl.indexOf("Maintenance_Documents") > -1) {
            excludeIt = true;
            return excludeIt;
        } 
        if (windowUrl.indexOf("Maintenance_MyObjectsDefinition") > -1) {
            excludeIt = true;
            return excludeIt;
        } 
        if (windowUrl.indexOf("Maintenance_SoftwareVersion") > -1) {
            excludeIt = true;
            return excludeIt;
        } 
        if (windowUrl.indexOf("Maintenance_UserDefinedReportCategory") > -1) {
            excludeIt = true;
            return excludeIt;
        } 
        if (windowUrl.indexOf("Maintenance_AlertAssignments.aspx") > -1) { //time zone
            excludeIt = true;
            return excludeIt;
        } 
        excludeIt = false;
        return excludeIt;
        
    }
    return excludeIt;
}

/* Window default sizes */
function GetWindowHeight(PageId, OriginalHeight) {
    return GetWindowSize(PageId, 'h', OriginalHeight);
};
function GetWindowWidth(PageId, OriginalWidth) {
    return GetWindowSize(PageId, 'w', OriginalWidth);
};

function GetWindowSize(PageId, ReturnHeightOrWidth, OriginalHeightOrWidth) {
    var ReturnHeight = OriginalHeightOrWidth;
    var ReturnWidth = OriginalHeightOrWidth;
    var isSet = false;
    //console.log("GetWindowSize", PageId)
    PageId = PageId.toUpperCase()
    //page "groups"
    if (PageId.indexOf("Maintenance_".toUpperCase(), 0) > -1) {
        ReturnHeight = 775;
        ReturnWidth = 975;
        isSet = true;
    };
    if (PageId.indexOf("Security_".toUpperCase(), 0) > -1) {
        ReturnHeight = 600;
        ReturnWidth = 900;
        isSet = true;
    };
    //specific pages, will override the above
    //    if (PageId.indexOf("About.aspx".toUpperCase(), 0) > -1) {
    //        ReturnHeight = 285;
    //        ReturnWidth = 525;
    //isSet = true;
    //    }; 
    if (PageId.indexOf("Alert_AddAttachments.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 325;
        ReturnWidth = 525;
        isSet = true;
    };
    if (PageId.indexOf("Alert_Assignment.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 550;
        ReturnWidth = 350;
        isSet = true;
    };
    if (PageId.indexOf("Alert_Comment.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 400;
        ReturnWidth = 550;
        isSet = true;
    };
    if (PageId.indexOf("Alert_Comments.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 500;
        ReturnWidth = 375;
        isSet = true;
    };
    if (PageId.indexOf("Alert_DigitalAssetReview_AddAsset.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 400;
        ReturnWidth = 400;
        isSet = true;
    };
    if (PageId.indexOf("Alert_DigitalAssetReview_AddReviewer.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 675;
        ReturnWidth = 365;
        isSet = true;
    };
    if (PageId.indexOf("Alert_DigitalAssetReview_Comment.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 750;
        ReturnWidth = 570;
        isSet = true;
    };
    if (PageId.indexOf("Alert_Inbox.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 740;
        ReturnWidth = 1235;
        isSet = true;
    };
    if (PageId.indexOf("Alert_List.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 740;
        ReturnWidth = 1235;
        isSet = true;
    };
    if (PageId.indexOf("Alert_New.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 850;
        ReturnWidth = 1145;
        isSet = true;
    };
    if (PageId.indexOf("Alert_Settings.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 250;
        ReturnWidth = 550;
        isSet = true;
    };
    if (PageId.indexOf("Alert_View.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 850;
        ReturnWidth = 1145;
        isSet = true;
    };
    if (PageId.indexOf("AgencySettings.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 750;
        ReturnWidth = 420;
        isSet = true;
    };
    if (PageId.indexOf("AgencySettings_Upload.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 200;
        ReturnWidth = 475;
        isSet = true;
    };
    if (PageId.indexOf("BillingApproval.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 300;
        ReturnWidth = 600;
        isSet = true;
    };
    if (PageId.indexOf("BillingApproval_Alert.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 780;
        ReturnWidth = 780;
        isSet = true;
    };
    if (PageId.indexOf("BillingApproval_Batch.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 600;
        ReturnWidth = 1100;
        isSet = true;
    };
    if (PageId.indexOf("BillingApproval_Approval_Item_Detail.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 800;
        ReturnWidth = 1400;
        isSet = true;
    };
    if (PageId.indexOf("Calendar_NewActivity.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 700;
        ReturnWidth = 800;
        isSet = true;
    };
    if (PageId.indexOf("Calendar_NewItem.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 375;
        ReturnWidth = 730;
        isSet = true;
    };
    if (PageId.indexOf("Calendar_MonthView.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 650;
        ReturnWidth = 1330;
        isSet = true;
    };
    if (PageId.indexOf("Campaign_New.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 370;
        ReturnWidth = 740;
        isSet = true;
    };
    if (PageId.indexOf("Chat.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 500;
        ReturnWidth = 600;
        isSet = true;
    };
    if (PageId.indexOf("Chat_NewRoomCreator.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 625;
        ReturnWidth = 675;
        isSet = true;
    };
    if (PageId.indexOf("Chat_RoomDetails.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 750;
        ReturnWidth = 745;
        isSet = true;
    };
    if (PageId.indexOf("Content.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 835;
        ReturnWidth = 1100;
        isSet = true;
    };
    if (PageId.indexOf("CreativeBrief_New.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 300;
        ReturnWidth = 600;
        isSet = true;
    };
    if (PageId.indexOf("DesktopObjectWindow.aspx".toUpperCase(), 0) > -1) {
        //ReturnHeight = SetDesktopObjectHeight(PageId);
        //ReturnWidth = SetDesktopObjectWidth(PageId);
        if (PageId.indexOf("DESKTOPCARDSMYBOOKMARKS".toUpperCase(), 0) > -1) {
            // This will reduce down to max available size...
            ReturnHeight = 700;
        } else if (PageId.indexOf("DESKTOPCARDS".toUpperCase(), 0) > -1) {
            // This will reduce down to max available size...
            ReturnHeight = 800;
            ReturnWidth = 1200;
        };
        isSet = true;
    };
    if (PageId.indexOf("DirectTime_Settings.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 550;
        ReturnWidth = 730;
        isSet = true;
    };
    if (PageId.indexOf("DashboardClient.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 650;
        ReturnWidth = 1030;
        isSet = true;
    };
    if (PageId.indexOf("DashboardProject.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 800;
        ReturnWidth = 1030;
        isSet = true;
    };
    if (PageId.indexOf("Desktop_AlertView".toUpperCase(), 0) > -1 || PageId.indexOf("Desktop_AddWorkItem".toUpperCase(), 0) > -1) {
        ReturnHeight = 850;
        ReturnWidth = 1145;
        isSet = true;
    };
    if (PageId.indexOf("Desktop_AlertView_CopyTransfer".toUpperCase(), 0) > -1) {
        if (PageId.indexOf("TYPE=3".toUpperCase(), 0) > -1) {
            ReturnHeight = 500;
            ReturnWidth = 440;
            isSet = true;
        } else {
            ReturnHeight = 380;
            ReturnWidth = 440;
            isSet = true;
        }
    };
    if (PageId.indexOf("Document_Edit.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 600;
        ReturnWidth = 375;
        isSet = true;
    };
    if (PageId.indexOf("Document_Label_Tree.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 400;
        ReturnWidth = 250;
        isSet = true;
    };
    if (PageId.indexOf("Documents.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 700;
        ReturnWidth = 1100;
        isSet = true;
    };
    if (PageId.indexOf("Documents_AddComment.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 400;
        ReturnWidth = 600;
        isSet = true;
    };
    if (PageId.indexOf("Documents_JobComponent.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 700;
        ReturnWidth = 1100;
        isSet = true;
    };
    if (PageId.indexOf("Documents_List.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 475;
        ReturnWidth = 1000;
        isSet = true;
    };
    if (PageId.indexOf("Documents_History.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 775;
        ReturnWidth = 830;
        isSet = true;
    };
    if (PageId.indexOf("Documents_Upload.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 700;
        ReturnWidth = 700;
        isSet = true;
    };
    if (PageId.indexOf("EmployeeIndirectTime_Settings.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 710;
        ReturnWidth = 690;
        isSet = true;
    };
    if (PageId.indexOf("Estimating_AddNew.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 800;
        ReturnWidth = 1000;
        isSet = true;
    };
    if (PageId.indexOf("Event_Task_Detail.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 700;
        ReturnWidth = 600;
        isSet = true;
    };
    if (PageId.indexOf("Expense.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 400;
        ReturnWidth = 740;
        isSet = true;
    };
    if (PageId.indexOf("Expense_Edit.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 750;
        ReturnWidth = 1150;
        isSet = true;
    };
    if (PageId.indexOf("Help_FileSelection.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 900;
        ReturnWidth = 690;
        isSet = true;
    };
    isSet = true;
    if (PageId.indexOf("Helper.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 10;
        ReturnWidth = 10;
        isSet = true;
    };
    if (PageId.indexOf("HoursByAlertID".toUpperCase(), 0) > -1) {
        ReturnHeight = 700;
        ReturnWidth = 1000;
        isSet = true;
    };
    if (PageId.indexOf("http://www.youtube.com/embed/dQw4w9WgXcQ".toUpperCase(), 0) > -1) {
        ReturnHeight = 570;
        ReturnWidth = 680;
        isSet = true;
    };
    if (PageId.indexOf("http://www.youtube.com/embed/rog8ou-ZepE".toUpperCase(), 0) > -1) {
        ReturnHeight = 570;
        ReturnWidth = 680;
        isSet = true;
    };
    if (PageId.indexOf("JobTemplate_New.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 800;
        ReturnWidth = 1100;
        isSet = true;
    };
    if (PageId.indexOf("jobVerNew.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 500;
        ReturnWidth = 800;
        isSet = true;
    };
    if (PageId.indexOf("LookUp_AdNumber.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 700;
        ReturnWidth = 900;
        isSet = true;
    };
    if (PageId.indexOf("LookUp_EmailRecipients.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 595;
        ReturnWidth = 875;
        isSet = true;
    };
    //if (PageId.indexOf("Maintenance_AlertAssignments.aspx".toUpperCase(), 0) > -1) {
    //    ReturnHeight = 760;
    //}; 
    //if (PageId.indexOf("Maintenance_AlertAssignments_StateWorkflow.aspx".toUpperCase(), 0) > -1) {
    //    ReturnHeight = 670;
    //    ReturnWidth = 420;
    //}; 
    //if (PageId.indexOf("Maintenance_AlertAssignments_TemplateCopy.aspx".toUpperCase(), 0) > -1) {
    //    ReturnHeight = 200;
    //    ReturnWidth = 670;
    //}; 
    //if (PageId.indexOf("Maintenance_JobVersionTemplateDetailListValue.aspx".toUpperCase(), 0) > -1) {
    //    ReturnHeight = 450;
    //    ReturnWidth = 500;
    //}; 
    if (PageId.indexOf("Maintenance_AlertAssignments_TemplateCopy.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 200;
        ReturnWidth = 400;
        isSet = true;
    };
    if (PageId.indexOf("Maintenance_DesktopCards.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 450;
        ReturnWidth = 500;
        isSet = true;
    };
    if (PageId.indexOf("Maintenance_CalendarTime.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 300;
        ReturnWidth = 800;
        isSet = true;
    };
    if (PageId.indexOf("MediaCalendar_OrderDetail.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 900;
        ReturnWidth = 800;
        isSet = true;
    };
    if (PageId.indexOf("mediavendorinfo.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 600;
        ReturnWidth = 800;
        isSet = true;
    };
    if (PageId.indexOf("MySettings.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 800;
        ReturnWidth = 950;
        isSet = true;
    };
    if (PageId.indexOf("MySettings_Colors.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 420;
        ReturnWidth = 420;
        isSet = true;
    };
    if (PageId.indexOf("PleaseWait.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 150;
        ReturnWidth = 275;
        isSet = true;
    };
    if (PageId.indexOf("popcomments.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 375;
        ReturnWidth = 500;
        isSet = true;
    };
    if (PageId.indexOf("popContacts.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 550;
        ReturnWidth = 850;
        isSet = true;
    };
    if (PageId.indexOf("popup_email_alert.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 675;
        ReturnWidth = 600;
        isSet = true;
    };
    //if (PageId.indexOf("Resources_Report.aspx".toUpperCase(), 0) > -1) {
    //    ReturnHeight = 500;
    //    ReturnWidth = 800;
    //}; 
    if (PageId.indexOf("Reporting_DynamicReportEdit.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 700;
        ReturnWidth = 1100;
        isSet = true;
    };
    if (PageId.indexOf("Reporting_JobDetailAnalysis.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 800;
        ReturnWidth = 1050;
        isSet = true;
    };
    if (PageId.indexOf("Scheduler_Events.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 600;
        ReturnWidth = 1100;
        isSet = true;
    };
    if (PageId.indexOf("Scheduler_EventTasks.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 600;
        ReturnWidth = 1100;
        isSet = true;
    };
    if (PageId.indexOf("Security_ClientPortal_Settings.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 300;
        ReturnWidth = 600;
        isSet = true;
    };
    if (PageId.indexOf("SupervisorApproval_Expense.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 800;
        ReturnWidth = 1160;
        isSet = true;
    };
    if (PageId.indexOf("SupervisorApproval_Timesheet.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 600;
        ReturnWidth = 1160;
        isSet = true;
    };
    if (PageId.indexOf("task.aspx".toUpperCase(), 0) > -1) {
        if (PageId.indexOf("Maintenance_".toUpperCase(), 0) > -1) {
            ReturnHeight = 750;
            ReturnWidth = 950;
        } else {
            ReturnHeight = 650;
            ReturnWidth = 600;
        }
        isSet = true;
    };
    if (PageId.indexOf("taskComments.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 460;
        ReturnWidth = 550;
        isSet = true;
    };
    if (PageId.indexOf("taskEmployees.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 300;
        ReturnWidth = 600;
        isSet = true;
    };
    if (PageId.indexOf("Timesheet.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 725;
        ReturnWidth = 950;
        isSet = true;
    };
    if (PageId.indexOf("Employee/Timesheet/Entry?a=".toUpperCase(), 0) > -1) {
        ReturnHeight = 570;
        ReturnWidth = 680;
        isSet = true;
    };
    if (PageId.indexOf("Timesheet_CommentsView.aspx".toUpperCase(), 0) > -1) {
        if (PageId.indexOf("MainMenu".toUpperCase(), 0) > -1 || PageId.indexOf("single=1".toUpperCase(), 0) > -1) {
            ReturnHeight = 400;
            ReturnWidth = 680;
        } else {
            ReturnHeight = 750;
            ReturnWidth = 675;
        };
        isSet = true;
    };
    if (PageId.indexOf("Timesheet_CopyFrom.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 800;
        ReturnWidth = 1100;
        isSet = true;
    };
    if (PageId.indexOf("Timesheet_DenyTime.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 500;
        ReturnWidth = 700;
        isSet = true;
    };
    if (PageId.indexOf("Timesheet_Details.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 500;
        ReturnWidth = 690;
        isSet = true;
    };
    if (PageId.indexOf("Timesheet_MissingTime.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 500;
        ReturnWidth = 700;
        isSet = true;
    };
    if (PageId.indexOf("Timesheet_QuickAdd.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 810;
        ReturnWidth = 645;
        isSet = true;
    };
    if (PageId.indexOf("Timesheet_QuickPrintSettings.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 375;
        ReturnWidth = 500;
        isSet = true;
    };
    if (PageId.indexOf("Timesheet_Search.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 400;
        ReturnWidth = 600;
        isSet = true;
    };
    if (PageId.indexOf("Timesheet_Stopwatch.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 475;
        ReturnWidth = 575;
        isSet = true;
    };
    if (PageId.indexOf("Timesheet_Template_Add.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 325;
        ReturnWidth = 455;
        isSet = true;
    };
    if (PageId.indexOf("TrafficSchedule.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 635;
        ReturnWidth = 1085;
        isSet = true;
    };
    if (PageId.indexOf("TrafficSchedule_AddNew.aspx".toUpperCase(), 0) > -1 || PageId.indexOf("ProjectManagement/ProjectSchedule/Create".toUpperCase(), 0) > -1) {
        ReturnHeight = 680;
        ReturnWidth = 750;
        isSet = true;
    };
    if (PageId.indexOf("TrafficSchedule_Replace.aspx".toUpperCase(), 0) > -1 || PageId.indexOf("ProjectManagement/ProjectSchedule/FindAndReplace".toUpperCase(), 0) > -1) {
        ReturnHeight = 800;
        ReturnWidth = 800;
        isSet = true;
    };
    if (PageId.indexOf("TrafficSchedule_Setup.aspx".toUpperCase(), 0) > -1 || PageId.indexOf("ProjectManagement/ProjectSchedule/Setup".toUpperCase(), 0) > -1) {
        ReturnHeight = 650;
        ReturnWidth = 675;
        isSet = true;
    };
    if (PageId.indexOf("TrafficSchedule_TaskDetail.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 585;
        ReturnWidth = 875;
        isSet = true;
    };
    if (PageId.indexOf("TrafficSchedule_TaskContacts.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 650;
        ReturnWidth = 650;
        isSet = true;
    };
    if (PageId.indexOf("TrafficSchedule_TaskEmployees.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 650;
        ReturnWidth = 650;
        isSet = true;
    };
    if (PageId.indexOf("TrafficScheduleTemplate_New.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 335;
        ReturnWidth = 600;
        isSet = true;
    };
    if (PageId.indexOf("TrafficScheduleVersion.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 500;
        ReturnWidth = 650;
        isSet = true;
    };
    if (PageId.indexOf("TrafficScheduleVersion_New.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 550;
        ReturnWidth = 450;
        isSet = true;
    };
    if (PageId.indexOf("QuoteVsActualSummaryPopup.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 635;
        ReturnWidth = 1200;
        isSet = true;
    };
    if (PageId.indexOf("UI_Action.aspx".toUpperCase(), 0) > -1) {
        ReturnHeight = 50;
        ReturnWidth = 100;
        isSet = true;
    };
    if (PageId.indexOf("UI_Message.aspx?msgid=1".toUpperCase(), 0) > -1) {
        ReturnHeight = 300;
        ReturnWidth = 550;
        isSet = true;
    };
    if (ReturnHeight == 0) {
        ReturnHeight = 800;
    };
    if (ReturnWidth == 0) {
        ReturnWidth = 1000;
    };
    ReturnHeight = ReturnHeight + 80;
    ReturnWidth = ReturnWidth + 80;
    if (ReturnHeightOrWidth == 'h') {
        return ReturnHeight;
    };
    if (ReturnHeightOrWidth == 'w') {
        return ReturnWidth;
    };
};
function SetDesktopObjectWidth(DesktopObjectName) {
    var DesktopObjectWidth = 0;
    var ShortWidth = 475;
    var MediumWidth = 682;
    var LongWidth = 890;
    var isSet = false;
    if (DesktopObjectName.indexOf("DesktopAgencyGoals.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopAgencyGoalsGraph.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = MediumWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopAgencyLinks.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopAlerts.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopAlertSummary.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopAllProjects.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopARCashForecast.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopARCashForecastProduct.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopBookmarks.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopBillableHoursGoal.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopBillingTrends.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopCardsMyAssignments.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    //if (DesktopObjectName.indexOf("DesktopCardsMyBookmarks.ascx".toUpperCase(), 0) > -1) {
    //    DesktopObjectWidth = ShortWidth;
    //};
    if (DesktopObjectName.indexOf("DesktopCardsMyCalendar.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopCardsMySummary.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopCardsMyTasks.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopCashBalance.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopClientAging.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopCurrentRatio.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopCurrentRatioGraph.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopDirectExpenseAlert.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopEmployeeIndirectTime.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopEmployeeIndirectTimeAll.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopExecutiveLinks.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopGrossIncomeGraph.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopInOutBoard.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopInOutBoardAll.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyARCashForecast.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyClientAging.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyDirectExpenseAlert.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyEmployeeTimeForecast.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = 995;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopEmployeeTimeForecast.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = 995;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyGrossIncomeGraph.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyProjects.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyQvA.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyServiceFee.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyTasks.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopOfficeStatistics.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopOfficeStatisticsV.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopProjectStatistics.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopProjectStatisticsGraph.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopProjectViewpoint.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopProjectViewpoint_Details.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopQOTD.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopQvA.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopRSS.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopServiceFee.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopTaskList.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopTimesheet.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopTrafficStatistics.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopTrafficStatus.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopUSWeather.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopWeeklyTimegraph.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopWOTD.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = ShortWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyJobRequests.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyDirectTime.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopJobRequests.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopDirectTime.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectWidth = LongWidth;
        isSet = true;
    };
    //if (DesktopObjectName.indexOf("InOutBoard.ascx".toUpperCase(), 0) > -1) {
    //    DesktopObjectWidth = ShortWidth;
    //};
    if (DesktopObjectWidth == 0) {
        DesktopObjectWidth = ShortWidth;
    };
    return DesktopObjectWidth + 60;
    //alert(DesktopObjectWidth);
};

function SetDesktopObjectHeight(DesktopObjectName) {
    var DesktopObjectHeight = 600;
    var isSet = false;
    if (DesktopObjectName.indexOf("DesktopAgencyGoals.ascx".toUpperCase(), 0) > -1) {
        //DesktopObjectHeight = 325;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopAgencyGoalsGraph.ascx".toUpperCase(), 0) > -1) {
        //DesktopObjectHeight = 475;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopAgencyLinks.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 450;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopAlerts.ascx".toUpperCase(), 0) > -1) {
        //DesktopObjectHeight = 400;
    };
    isSet = true;
    if (DesktopObjectName.indexOf("DesktopAlertSummary.ascx".toUpperCase(), 0) > -1) {
        //DesktopObjectHeight = 340;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopAllProjects.ascx".toUpperCase(), 0) > -1) {
        //DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopARCashForecast.ascx".toUpperCase(), 0) > -1) {
        //DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopARCashForecastProduct.ascx".toUpperCase(), 0) > -1) {
        //DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopBillableHoursGoal.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 475;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopBillingTrends.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 475;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopBookmarks.ascx".toUpperCase(), 0) > -1) {
        //DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopCardsMyAssignments.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopCardsMyBookmarks.ascx".toUpperCase(), 0) > -1) {
        //DesktopObjectHeight = 400;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopCardsMyCalendar.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopCardsMySummary.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopCardsMyTasks.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopCashBalance.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopClientAging.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopClock.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopCurrentRatio.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 400;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopCurrentRatioGraph.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopDirectExpenseAlert.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 400;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopEmployeeIndirectTime.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 450;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopEmployeeIndirectTimeAll.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 450;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopExecutiveLinks.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 450;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopInOutBoard.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 450;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopInOutBoardAll.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyARCashForecast.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyClientAging.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopClock.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 400;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyDirectExpenseAlert.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyEmployeeTimeForecast.ascx".toUpperCase(), 0) > -1) {
        //DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopEmployeeTimeForecast.ascx".toUpperCase(), 0) > -1) {
        //DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyProjects.ascx".toUpperCase(), 0) > -1) {
        //DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyQvA.ascx".toUpperCase(), 0) > -1) {
        //DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyTasks.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopProjectStatistics.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopProjectStatisticsGraph.ascx".toUpperCase(), 0) > -1) {
        //DesktopObjectHeight = 550;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopProjectViewpoint.ascx".toUpperCase(), 0) > -1) {
        //DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopQOTD.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 350;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopQvA.ascx".toUpperCase(), 0) > -1) {
        //DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopRSS.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopTaskList.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopTimesheet.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 450;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopTrafficStatistics.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopTrafficStatus.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopWeeklyTimegraph.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopWOTD.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 400;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("InOutBoard.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyJobRequests.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopMyDirectTime.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopJobRequests.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectName.indexOf("DesktopDirectTime.ascx".toUpperCase(), 0) > -1) {
        DesktopObjectHeight = 500;
        isSet = true;
    };
    if (DesktopObjectHeight == 0) {
        DesktopObjectHeight = 600;
    };
    return DesktopObjectHeight;
    //alert(DesktopObjectHeight);
};
