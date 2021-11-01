// NOTE object below must be a valid JSON
window.AdvantageMobile_UI = $.extend(true, window.AdvantageMobile_UI, {
    "config": {
        "endpoints": {
            "db": {
                "local": "",
                "production": ""
            }
        },
        "services": {
            "db": {
                "entities": {
                    "AlertAssignmentTemplates": {
                        "key": "ID",
                        "keyType": "Int32"
                    },
                    "AlertAssignmentStates": {
                        "key": "ID",
                        "keyType": "Int32"
                    },

                    "AlertComments": {
                        "key": "ID",
                        "keyType": "Int32"
                    },
                    "AlertRecipients": {
                        "key": "ID",
                        "keyType": "Int32"
                    },
                    "Alerts": {
                        "key": "ID",
                        "keyType": "Int32"
                    },
                    "Clients": {
                        "key": "Code",
                        "keyType": "String"
                    },
                    "DepartmentTeams": {
                        "key": "Code",
                        "keyType": "String"
                    },
                    "DismissedAlertRecipients": {
                        "key": "ID",
                        "keyType": "Int32"
                    },
                    "Divisions": {
                        "key": [
                                "ClientCode",
                                "Code"
                        ],
                        "keyType": {
                            "ClientCode": "String",
                            "Code": "String"
                        }
                    },
                    "EmployeePictures": {
                        "key": "EmployeeCode",
                        "keyType": "String"
                    },
                    "Employees": {
                        "key": "EmployeeCode",
                        "keyType": "String"
                    },
                    "EmployeeTimes": {
                        "key": "ID",
                        "keyType": "Int32"
                    },
                    "EmployeeTimeComments": {
                        "key": [
                                "DetailID",
                                "EmployeeTimeID",
                                "Source"
                        ],
                        "keyType": {
                            "DetailID": "Int32",
                            "EmployeeTimeID": "Int32",
                            "Source": "String"
                        }
                    },
                    "EmployeeTimeDetails": {
                        "key": [
                                "EmployeeTimeID",
                                "ID"
                        ],
                        "keyType": {
                            "EmployeeTimeID": "Int32",
                            "ID": "Int32"
                        }
                    },
                    "EmployeeTimeIndirects": {
                        "key": [
                                "EmployeeTimeID",
                                "ID"
                        ],
                        "keyType": {
                            "EmployeeTimeID": "Int32",
                            "ID": "Int32"
                        }
                    },
                    "EmployeeTimeTemplates": {
                        "key": "ID",
                        "keyType": "Int32"
                    },
                    "Functions": {
                        "key": "Code",
                        "keyType": "String"
                    },
                    "JobComponents": {
                        "key": [
                                "JobNumber",
                                "JobComponentNumber"
                        ],
                        "keyType": {
                            "JobNumber": "Int32",
                            "JobComponentNumber": "Int32"
                        }
                    },
                    "JobLogs": {
                        "key": "JobNumber",
                        "keyType": "Int32"
                    },
                    "JobTrafficDetailEmployees": {
                        "key": [
                                "JobNumber",
                                "JobComponentNumber",
                                "SequenceNumber",
                                "EmployeeCode"
                        ],
                        "keyType": {
                            "JobNumber": "Int32",
                            "JobComponentNumber": "Int32",
                            "SequenceNumber": "Int32",
                            "EmployeeCode": "String",
                        }
                    },
                    "JobTrafficDetails": {
                        "key": [
                                "JobNumber",
                                "JobComponentNumber",
                                "SequenceNumber"
                        ],
                        "keyType": {
                            "JobNumber": "Int32",
                            "JobComponentNumber": "Int32",
                            "SequenceNumber": "Int32"
                        }
                    },
                    "JobTraffics": {
                        "key": [
                                "JobNumber",
                                "JobComponentNumber"
                        ],
                        "keyType": {
                            "JobNumber": "Int32",
                            "JobComponentNumber": "Int32"
                        }
                    },
                    "Offices": {
                        "key": "Code",
                        "keyType": "String"
                    },
                    "Products": {
                        "key": [
                                "ClientCode",
                                "Code",
                                "DivisionCode"
                        ],
                        "keyType": {
                            "ClientCode": "String",
                            "Code": "String",
                            "DivisionCode": "String"
                        }
                    },
                    "SecurityClients": {
                        "key": [
                                "UserCode",
                                "ClientCode",
                                "DivisionCode",
                                "ProductCode"
                        ],
                        "keyType": {
                            "UserCode": "String",
                            "ClientCode": "String",
                            "DivisionCode": "String",
                            "ProductCode": "String"
                        }
                    },
                    "SecurityGroupPermissions": {
                        "key": "ID",
                        "keyType": "String"
                    },
                    "SecurityPermissions": {
                        "key": "ID",
                        "keyType": "String"
                    },
                    "SecurityUsers": {
                        "key": "ID",
                        "keyType": "Int32"
                    },
                    "TimeCategoryTypes": {
                        "key": "ID",
                        "keyType": "Int32"
                    },
                    "TimeCategories": {
                        "key": "Code",
                        "keyType": "String"
                    }
                }
            }
        }
    }
});