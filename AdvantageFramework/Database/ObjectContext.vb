
<Assembly: System.Data.Objects.DataClasses.EdmSchemaAttribute("a214dc53-dde7-4e0a-9516-11af84bb2a89")> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AlertAlertType", "Alert", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Alert), "AlertType", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AlertType), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AlertAlertAttachment", "Alert", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Alert), "AlertAttachments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AlertAttachment), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AlertAlertComment", "Alert", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Alert), "AlertComments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AlertComment), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AlertAlertRecipient", "Alert", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Alert), "AlertRecipients", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AlertRecipient), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DataGridViewDataGridViewColumn", "DataGridView", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.DataGridView), "DataGridViewColumns", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DataGridViewColumn), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DataGridViewDataGridViewColumnUserSetting", "DataGridView", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.DataGridView), "DataGridViewColumnUserSettings", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DataGridViewColumnUserSetting), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DataGridViewColumnDataGridViewColumnUserSetting", "DataGridViewColumn", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.DataGridViewColumn), "DataGridViewColumnUserSettings", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DataGridViewColumnUserSetting), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobVersionDatabaseTypeJobVersionTemplateDetail", "JobVersionDatabaseType", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobVersionDatabaseType), "JobVersionTemplateDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobVersionTemplateDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobVersionTemplateJobVersionTemplateDetail", "JobVersionTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobVersionTemplate), "JobVersionTemplateDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobVersionTemplateDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "RoleEmployeeRole", "Role", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Role), "EmployeeRoles", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeRole), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FunctionTask", "Function", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.[Function]), "Tasks", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Task), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "RoleTask", "Role", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Role), "Tasks", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Task), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PostPeriodEmployeeTimeForecast", "PostPeriod", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.PostPeriod), "EmployeeTimeForecasts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecast), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientDivision", "Client", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Client), "Divisions", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Division), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientStandardComment", "Client", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Client), "StandardComment", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.StandardComment), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DivisionProduct", "Division", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Division), "Products", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Product), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductOffice", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Product), "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Office), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeNonTaskFunction", "EmployeeNonTask", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeNonTask), "Function", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.[Function]), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeJob", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Office), "Jobs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Job), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductJob", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Product), "Jobs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Job), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobClient", "Job", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Job), "Client", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Client), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobDivision", "Job", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Job), "Division", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Division), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobJobComponent", "Job", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Job), "JobComponents", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentEmployeeNonTask", "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobComponent), "EmployeeNonTask", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeNonTask), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EstimateRevisionEstimateRevisionDetail", "EstimateRevision", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EstimateRevision), "EstimateRevisionDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EstimateRevisionDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FunctionEstimateRevisionDetail", "Function", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.[Function]), "EstimateRevisionDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EstimateRevisionDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductClient", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Product), "Client", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Client), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastEmployeeTimeForecastOfficeDetail", "EmployeeTimeForecast", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecast), "EmployeeTimeForecastOfficeDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeEmployeeTimeForecastOfficeDetail", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Office), "EmployeeTimeForecastOfficeDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "BillingRateLevelBillingRateDetail", "BillingRateLevel", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.BillingRateLevel), "BillingRateDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.BillingRateDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FunctionBillingRateDetail", "Function", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.[Function]), "BillingRateDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.BillingRateDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductBillingRateDetail", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Product), "BillingRateDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.BillingRateDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesClassBillingRateDetail", "SalesClass", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesClass), "BillingRateDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.BillingRateDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTitleBillingRateDetail", "EmployeeTitle", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.EmployeeTitle), "BillingRateDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.BillingRateDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesClassJob", "SalesClass", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesClass), "Jobs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Job), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeBillingRateDetail", "Employee", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Views.Employee), "BillingRateDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.BillingRateDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientBillingRateDetail", "Client", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Client), "BillingRateDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.BillingRateDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DivisionBillingRateDetail", "Division", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Division), "BillingRateDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.BillingRateDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AlertCategoryAlert", "AlertCategory", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AlertCategory), "Alert", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Alert), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AlertTypeAlertCategory", "AlertType", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AlertType), "AlertCategory", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AlertCategory), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastOfficeDetailEmployeeTimeForecastOfficeDetailAlternateEmployee", "EmployeeTimeForecastOfficeDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecastOfficeDetail), "EmployeeTimeForecastOfficeDetailAlternateEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastOfficeDetailEmployeeTimeForecastOfficeDetailEmployee", "EmployeeTimeForecastOfficeDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecastOfficeDetail), "EmployeeTimeForecastOfficeDetailEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastOfficeDetailEmployeeTimeForecastOfficeDetailIndirectCategory", "EmployeeTimeForecastOfficeDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecastOfficeDetail), "EmployeeTimeForecastOfficeDetailIndirectCategory", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastOfficeDetailEmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee", "EmployeeTimeForecastOfficeDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecastOfficeDetail), "EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastOfficeDetailEmployeeTimeForecastOfficeDetailIndirectCategoryEmployee", "EmployeeTimeForecastOfficeDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecastOfficeDetail), "EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastOfficeDetailEmployeeTimeForecastOfficeDetailJobComponent", "EmployeeTimeForecastOfficeDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecastOfficeDetail), "EmployeeTimeForecastOfficeDetailJobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastOfficeDetailEmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee", "EmployeeTimeForecastOfficeDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecastOfficeDetail), "EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastOfficeDetailEmployeeTimeForecastOfficeDetailJobComponentEmployee", "EmployeeTimeForecastOfficeDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecastOfficeDetail), "EmployeeTimeForecastOfficeDetailJobComponentEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastEmployeeTimeForecastOfficeDetailAlternateEmployee", "EmployeeTimeForecast", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecast), "EmployeeTimeForecastOfficeDetailAlternateEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastEmployeeTimeForecastOfficeDetailEmployee", "EmployeeTimeForecast", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecast), "EmployeeTimeForecastOfficeDetailEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastEmployeeTimeForecastOfficeDetailIndirectCategory", "EmployeeTimeForecast", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecast), "EmployeeTimeForecastOfficeDetailIndirectCategory", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastEmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee", "EmployeeTimeForecast", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecast), "EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastEmployeeTimeForecastOfficeDetailIndirectCategoryEmployee", "EmployeeTimeForecast", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecast), "EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastEmployeeTimeForecastOfficeDetailJobComponent", "EmployeeTimeForecast", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecast), "EmployeeTimeForecastOfficeDetailJobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastEmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee", "EmployeeTimeForecast", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecast), "EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastEmployeeTimeForecastOfficeDetailJobComponentEmployee", "EmployeeTimeForecast", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecast), "EmployeeTimeForecastOfficeDetailJobComponentEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "IndirectCategoryEmployeeTimeForecastOfficeDetailIndirectCategory", "IndirectCategory", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.IndirectCategory), "EmployeeTimeForecastOfficeDetailIndirectCategory", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeEmployeeTimeForecastOfficeDetailEmployee", "Employee", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Views.Employee), "EmployeeTimeForecastOfficeDetailEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTitleEmployeeTimeForecastOfficeDetailAlternateEmployee", "EmployeeTitle", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTitle), "EmployeeTimeForecastOfficeDetailAlternateEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeEmployeeTimeForecastOfficeDetailJobComponent", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Office), "EmployeeTimeForecastOfficeDetailJobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientEmployeeTimeForecastOfficeDetailJobComponent", "Client", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Client), "EmployeeTimeForecastOfficeDetailJobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DivisionEmployeeTimeForecastOfficeDetailJobComponent", "Division", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Division), "EmployeeTimeForecastOfficeDetailJobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductEmployeeTimeForecastOfficeDetailJobComponent", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Product), "EmployeeTimeForecastOfficeDetailJobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobEmployeeTimeForecastOfficeDetailJobComponent", "Job", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Job), "EmployeeTimeForecastOfficeDetailJobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentEmployeeTimeForecastOfficeDetailJobComponent", "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobComponent), "EmployeeTimeForecastOfficeDetailJobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastOfficeDetailJobComponentEmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee", "EmployeeTimeForecastOfficeDetailJobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent), "EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastOfficeDetailAlternateEmployeeEmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee", "EmployeeTimeForecastOfficeDetailAlternateEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee), "EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastOfficeDetailJobComponentEmployeeTimeForecastOfficeDetailJobComponentEmployee", "EmployeeTimeForecastOfficeDetailJobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent), "EmployeeTimeForecastOfficeDetailJobComponentEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastOfficeDetailEmployeeEmployeeTimeForecastOfficeDetailJobComponentEmployee", "EmployeeTimeForecastOfficeDetailEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailEmployee), "EmployeeTimeForecastOfficeDetailJobComponentEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastOfficeDetailIndirectCategoryEmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee", "EmployeeTimeForecastOfficeDetailIndirectCategory", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory), "EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastOfficeDetailIndirectCategoryEmployeeTimeForecastOfficeDetailIndirectCategoryEmployee", "EmployeeTimeForecastOfficeDetailIndirectCategory", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory), "EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastOfficeDetailEmployeeEmployeeTimeForecastOfficeDetailIndirectCategoryEmployee", "EmployeeTimeForecastOfficeDetailEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailEmployee), "EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeForecastOfficeDetailAlternateEmployeeEmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee", "EmployeeTimeForecastOfficeDetailAlternateEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee), "EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeEmployeeTimeForecastOfficeDetailAlternateEmployee", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Office), "EmployeeTimeForecastOfficeDetailAlternateEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DepartmentTeamFunction", "DepartmentTeam", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.DepartmentTeam), "Functions", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.[Function]), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DepartmentTeamEmployeeDepartment", "DepartmentTeam", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.DepartmentTeam), "EmployeeDepartments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeDepartment), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeEmployeeDepartment", "Employee", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Views.Employee), "EmployeeDepartment", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeDepartment), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DepartmentTeamEmployee", "DepartmentTeam", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.DepartmentTeam), "Employee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Views.Employee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeEmployee", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Office), "Employee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Views.Employee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentEstimateApproval", "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobComponent), "EstimateApprovals", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Views.EstimateApproval), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EstimateRevisionEstimateApproval", "EstimateRevision", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EstimateRevision), "EstimateApprovals", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Views.EstimateApproval), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FunctionJobComponentTask", "Function", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.[Function]), "JobComponentTasks", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponentTask), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentJobComponentTask", "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobComponent), "JobComponentTasks", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponentTask), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "RoleJobComponentTask", "Role", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Role), "JobComponentTasks", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponentTask), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PhaseJobComponentTask", "Phase", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Phase), "JobComponentTasks", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponentTask), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "TaskJobComponentTask", "Task", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Task), "JobComponentTasks", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponentTask), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ParentTaskJobComponentTask", "ParentTask", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Task), "ParentJobComponentTasks", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponentTask), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeJobComponentTask", "Employee", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Views.Employee), "JobComponentTasks", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponentTask), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeEmployeeOffice", "Employee", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Views.Employee), "EmployeeOffice", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeOffice), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeEmployeeOffice", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Office), "EmployeeOffice", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeOffice), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientCampaign", "Client", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Client), "Campaigns", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Campaign), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DivisionCampaign", "Division", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Division), "Campaigns", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Campaign), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeCampaign", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Office), "Campaigns", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Campaign), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductCampaign", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Product), "Campaigns", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Campaign), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesClassJobType", "SalesClass", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesClass), "JobType", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobType), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientAd", "Client", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Client), "Ads", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Ad), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AdJobComponent", "Ad", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Ad), "JobComponents", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountJobComponent", "Account", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Account), "JobComponents", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FunctionVendor", "Function", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.[Function]), "Vendors", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Vendor), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AlertAlertRecipientDismissed", "Alert", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Alert), "AlertRecipientDismisseds", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AlertRecipientDismissed), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PurchaseOrderApprovalRuleDepartmentTeam", "PurchaseOrderApprovalRule", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.PurchaseOrderApprovalRule), "DepartmentTeams", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DepartmentTeam), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ApprovedEmployeeEmployeeTimeForecastOfficeDetail", "ApprovedByEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Views.Employee), "ApprovedEmployeeTimeForecastOfficeDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AssignedEmployeeEmployeeTimeForecastOfficeDetail", "Employee", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Views.Employee), "EmployeeTimeForecastOfficeDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeForecastOfficeDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductAccountExecutive", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Product), "AccountExecutive", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountExecutive), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeAccountExecutive", "Employee", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Views.Employee), "AccountExecutive", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountExecutive), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeEmployeePicture", "Employee", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Views.Employee), "EmployeePicture", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeePicture), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentTaskJobComponentTaskEmployee", "JobComponentTask", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobComponentTask), "JobComponentTaskEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponentTaskEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DocumentDocumentComment", "Document", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Document), "DocumentComments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DocumentComment), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PostPeriodCheckRegister", "PostPeriod", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.PostPeriod), "CheckRegisters", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.CheckRegister), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VoidPostPeriodCheckRegister", "VoidPostPeriod", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.PostPeriod), "VoidCheckRegisters", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.CheckRegister), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DocumentExecutiveDesktopDocument", "Document", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Document), "ExecutiveDesktopDocuments", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.ExecutiveDesktopDocument), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeExecutiveDesktopDocument", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Office), "ExecutiveDesktopDocuments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ExecutiveDesktopDocument), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesTaxAccountPayableRadio", "SalesTax", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesTax), "AccountPayableRadios", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableRadio), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesTaxAccountPayableTV", "SalesTax", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesTax), "AccountPayableTVs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableTV), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorTermVendor", "VendorTerm", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.VendorTerm), "Vendors", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Vendor), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountAccountPayablePayment", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "AccountPayablePayments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayablePayment), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountCashAccountPayablePayment", "CashGeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "CashAccountPayablePayments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayablePayment), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountAccountPayableRadio", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "AccountPayableRadios", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableRadio), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountAccountPayableTV", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "AccountPayableTVs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableTV), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "NonBillableGeneralLedgerAccountFunction", "NonBillableGeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "NonBillableFunctions", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.[Function]), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OverheadGeneralLedgerAccountFunction", "OverheadGeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "OverheadFunctions", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.[Function]), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountsPayableGeneralLedgerAccountOffice", "AccountsPayableGeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "AccountsPayableOffices", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Office), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountsPayableDiscountGeneralLedgerAccountOffice", "AccountsPayableDiscountGeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "AccountsPayableDiscountOffices", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Office), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountsReceivableGeneralLedgerAccountOffice", "AccountsReceivableGeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "AccountsReceivableOffices", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Office), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CityTaxGeneralLedgerAccountOffice", "CityTaxGeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "CityTaxOffices", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Office), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CountyTaxGeneralLedgerAccountOffice", "CountyTaxGeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "CountyTaxOffices", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Office), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductionAccruedAccountsPayableGeneralLedgerAccountOffice", "ProductionAccruedAccountsPayableGeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "ProductionAccruedAccountsPayableOffices", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Office), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductionAccruedCostOfSalesGeneralLedgerAccountOffice", "ProductionAccruedCostOfSalesGeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "ProductionAccruedCostOfSalesOffices", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Office), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductionCostOfSalesGeneralLedgerAccountOffice", "ProductionCostOfSalesGeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "ProductionCostOfSalesOffices", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Office), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductionDeferredCostOfSalesGeneralLedgerAccountOffice", "ProductionDeferredCostOfSalesGeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "ProductionDeferredCostOfSalesOffices", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Office), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductionDeferredSalesGeneralLedgerAccountOffice", "ProductionDeferredSalesGeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "ProductionDeferredSalesOffices", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Office), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductionSalesGeneralLedgerAccountOffice", "ProductionSalesGeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "ProductionSalesOffices", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Office), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductionWorkInProgressGeneralLedgerAccountOffice", "ProductionWorkInProgressGeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "ProductionWorkInProgressOffices", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Office), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "StateTaxGeneralLedgerAccountOffice", "StateTaxGeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "StateTaxOffices", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Office), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SuspenseGeneralLedgerAccountOffice", "SuspenseGeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "SuspenseOffices", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Office), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountVendor", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "Vendors", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Vendor), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableDiscountGeneralLedgerAccountAccountPayablePayment", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "AccountPayablePayment", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayablePayment), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductProductCategory", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Product), "ProductCategories", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ProductCategory), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientClientSortKey", "Client", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Client), "ClientSortKeys", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientSortKey), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DivisionDivisionSortKey", "Division", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Division), "DivisionSortKeys", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DivisionSortKey), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductProductSortKey", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Product), "ProductSortKeys", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ProductSortKey), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientClientContact", "Client", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Client), "ClientContacts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientContact), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "TaskClientContact", "Task", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Task), "ClientContacts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientContact), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientContactJobComponent", "ClientContact", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.ClientContact), "JobComponents", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientContactDetailClientContact", "ClientContact", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.ClientContact), "ClientContactDetaul", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientContactDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ServiceFeeTypeJobComponent", "ServiceFeeType", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.ServiceFeeType), "JobComponents", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientAgencyClient", "Client", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Client), "AgencyClient", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AgencyClient), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DivisionStandardComment", "Division", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Division), "StandardComment", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.StandardComment), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductStandardComment", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Product), "StandardComment", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.StandardComment), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorStandardComment", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Vendor), "StandardComment", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.StandardComment), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeStandardComment", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Office), "StandardComment", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.StandardComment), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductBillingCoop", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Product), "BillingCoops", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.BillingCoop), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeCategoryEmployeeTitle", "EmployeeCategory", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.EmployeeCategory), "EmployeeTitles", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTitle), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FiscalPeriodJobComponent", "FiscalPeriod", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.FiscalPeriod), "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FunctionHeadingFunction", "FunctionHeading", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.FunctionHeading), "Function", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.[Function]), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesClassInternetOrder", "SalesClass", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesClass), "InternetOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.InternetOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductInternetOrder", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Product), "InternetOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.InternetOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorInternetOrder", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Vendor), "InternetOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.InternetOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesClassMagazineOrder", "SalesClass", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesClass), "MagazineOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MagazineOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductMagazineOrder", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Product), "MagazineOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MagazineOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorMagazineOrder", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Vendor), "MagazineOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MagazineOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesClassNewspaperOrder", "SalesClass", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesClass), "NewspaperOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.NewspaperOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductNewspaperOrder", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Product), "NewspaperOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.NewspaperOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorNewspaperOrder", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Vendor), "NewspaperOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.NewspaperOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesClassOutOfHomeOrder", "SalesClass", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesClass), "OutOfHomeOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OutOfHomeOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductOutOfHomeOrder", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Product), "OutOfHomeOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OutOfHomeOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorOutOfHomeOrder", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Vendor), "OutOfHomeOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OutOfHomeOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductRadioOrder", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Product), "RadioOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductTVOrder", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Product), "TVOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesClassRadioOrder", "SalesClass", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesClass), "RadioOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorRadioOrder", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Vendor), "RadioOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesClassTVOrder", "SalesClass", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesClass), "TVOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorTVOrder", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Vendor), "TVOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorContactVendor", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Vendor), "VendorContacts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.VendorContact), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DefaultVendorContactVendor", "DefaultVendorContact", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.VendorContact), "DefaultVendors", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Vendor), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CampaignCampaignDetail", "Campaign", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Campaign), "CampaignDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.CampaignDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MarketInternetOrder", "Market", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Market), "InternetOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.InternetOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MarketJobComponent", "Market", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Market), "JobComponents", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MarketMagazineOrder", "Market", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Market), "MagazineOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MagazineOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MarketNewspaperOrder", "Market", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Market), "NewspaperOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.NewspaperOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MarketOutOfHomeOrder", "Market", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Market), "OutOfHomeOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OutOfHomeOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MarketRadioOrder", "Market", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Market), "RadioOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MarketTVOrder", "Market", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Market), "TVOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorAccountPayable", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Vendor), "AccountPayables", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayable), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountAccountPayable", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "AccountPayables", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayable), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PostPeriodAccountPayable", "PostPeriod", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.PostPeriod), "AccountPayables", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayable), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorTermAccountPayable", "VendorTerm", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.VendorTerm), "AccountPayables", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayable), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableAccountPayablePayment", "AccountPayable", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AccountPayable), "AccountPayablePayments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayablePayment), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableAccountPayableRadio", "AccountPayable", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AccountPayable), "AccountPayableRadios", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableRadio), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableAccountPayableTV", "AccountPayable", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AccountPayable), "AccountPayableTVs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableTV), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeAgencyDesktopDocument", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Office), "AgencyDesktopDocuments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AgencyDesktopDocument), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DocumentAgencyDesktopDocument", "Document", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Document), "AgencyDesktopDocument", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AgencyDesktopDocument), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DepartmentTeamAgencyDesktopDocument", "DepartmentTeam", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.DepartmentTeam), "AgencyDesktopDocuments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AgencyDesktopDocument), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DocumentOfficeDocument", "Document", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Document), "OfficeDocument", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.OfficeDocument), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeOfficeDocument", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Office), "OfficeDocuments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeDocument), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentDocuments", "Document", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Document), "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobComponent))> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobDocument", "Documents", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Document), "Job", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Job))> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductDocument", "Documents", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Document), "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Product))> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaSpecsHeaderVendor", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Vendor), "MediaSpecsHeader", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaSpecsHeader), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ComplexityJob", "Complexity", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Complexity), "Jobs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Job), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AdBlackplate", "Ad", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Ad), "Blackplates", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Blackplate), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "Ads1Blackplate1", "Blackplate1", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Blackplate), "Ads1", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Ad), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "Ads2Blackplate2", "Blackplate2", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Blackplate), "Ads2", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Ad), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "Blackplate2JobComponent2", "Blackplate2", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Blackplate), "JobComponents2", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "Blackplate1JobComponent1", "Blackplate1", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Blackplate), "JobComponents1", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PromotionTypeJob", "PromotionType", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.PromotionType), "Job", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Job), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CurrencyAccountPayable", "Currency", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Currency), "AccountPayables", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayable), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CurrencyCurrencyDetail", "Currency", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Currency), "CurrencyDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.CurrencyDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CurrencyGeneralLedgerAccount", "Currency", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Currency), "GeneralLedgerAccounts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.GeneralLedgerAccount), True)>
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CurrencyProduct", "Currency", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Currency), "Products", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Product), True)>
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CurrencyVendor", "Currency", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Currency), "Vendors", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Vendor), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PartnersMarket", "Market", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Market), "Partners", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Partner), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PartnersPrintSpecRegion", "PrintSpecRegion", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.PrintSpecRegion), "Partners", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Partner), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientAccountsReceivableStatementsClientContact", "ClientContact", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.ClientContact), "ClientAccountsReceivableStatements", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientAccountsReceivableStatement), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductAccountsReceivableStatementsClientContact", "ClientContact", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.ClientContact), "ProductAccountsReceivableStatements", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ProductAccountsReceivableStatement), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayablePaymentsBank", "Bank", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Bank), "AccountPayablePayments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayablePayment), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "Banks5GeneralLedgerAccount5", "GeneralLedgerAccount5", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "Banks5", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Bank), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "Banks3GeneralLedgerAccount3", "GeneralLedgerAccount3", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "Banks3", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Bank), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "Banks7GeneralLedgerAccount7", "GeneralLedgerAccount7", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "Banks7", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Bank), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "Banks2GeneralLedgerAccount2", "GeneralLedgerAccount2", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "Banks2", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Bank), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "Banks4GeneralLedgerAccount4", "GeneralLedgerAccount4", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "Banks4", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Bank), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "Banks6GeneralLedgerAccount6", "GeneralLedgerAccount6", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "Banks6", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Bank), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "Banks8GeneralLedgerAccount8", "GeneralLedgerAccount8", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "Banks8", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Bank), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "BanksGeneralLedgerAccount", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "Banks", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Bank), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "BankCheckRegisters", "Bank", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Bank), "CheckRegisters", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.CheckRegister), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DepartmentTeamEmployeeTimeDetail", "DepartmentTeam", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.DepartmentTeam), "EmployeeTimeDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeEmployeeTimeDetail", "EmployeeTime", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTime), "EmployeeTimeDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FunctionEmployeeTimeDetail", "Function", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.[Function]), "EmployeeTimeDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentEmployeeTimeDetail", "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobComponent), "EmployeeTimeDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesTaxEmployeeTimeDetail", "SalesTax", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesTax), "EmployeeTimeDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTitleEmployeeTimeDetail", "EmployeeTitle", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.EmployeeTitle), "EmployeeTimeDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentUserDefinedValue1JobComponent", "JobComponentUserDefinedValue1", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobComponentUserDefinedValue1), "JobComponents", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentUserDefinedValue2JobComponent", "JobComponentUserDefinedValue2", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobComponentUserDefinedValue2), "JobComponents", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentUserDefinedValue3JobComponent", "JobComponentUserDefinedValue3", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobComponentUserDefinedValue3), "JobComponents", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentUserDefinedValue4JobComponent", "JobComponentUserDefinedValue4", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobComponentUserDefinedValue4), "JobComponents", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentUserDefinedValue5JobComponent", "JobComponentUserDefinedValue5", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobComponentUserDefinedValue5), "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobUserDefinedValue1Job", "JobUserDefinedValue1", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobUserDefinedValue1), "Jobs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Job), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobUserDefinedValue2Job", "JobUserDefinedValue2", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobUserDefinedValue2), "Jobs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Job), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobUserDefinedValue3Job", "JobUserDefinedValue3", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobUserDefinedValue3), "Jobs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Job), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobUserDefinedValue4Job", "JobUserDefinedValue4", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobUserDefinedValue4), "Job", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Job), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobUserDefinedValue5Job", "JobUserDefinedValue5", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobUserDefinedValue5), "Jobs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Job), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AlertClientPortalAlertRecipient", "Alert", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Alert), "ClientPortalAlertRecipients", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientPortalAlertRecipient), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AlertClientPortalAlertRecipientDismissed", "Alert", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Alert), "ClientPortalAlertRecipientDismisseds", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientPortalAlertRecipientDismissed), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "RoleEmployee", "Role", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Role), "Employees", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Views.Employee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FunctionEmployee", "Function", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.[Function]), "Employees", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Views.Employee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeIndirectsDepartmentTeam", "DepartmentTeam", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.DepartmentTeam), "EmployeeTimeIndirects", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeIndirect), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeIndirectsEmployeeTime", "EmployeeTime", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.EmployeeTime), "EmployeeTimeIndirects", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeIndirect), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTimeIndirectsIndirectCategory", "IndirectCategory", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.IndirectCategory), "EmployeeTimeIndirects", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeIndirect), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "BankBankExportSpec", "Bank", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Bank), "BankExportSpec", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.BankExportSpec), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientClientWebsites", "Client", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Client), "ClientWebsites", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientWebsite), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "WebsiteTypeClientWebsites", "WebsiteType", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.WebsiteType), "ClientWebsites", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientWebsite), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobTrafficJobComponent", "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobComponent), "JobTraffic", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobTraffic), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobTrafficPredecessorsJobTraffic", "JobTraffic", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobTraffic), "JobTrafficPredecessors", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobTrafficPredecessors), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobTrafficTraffic", "Status", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Status), "JobTraffic", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobTraffic), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesClassSalesClassFormat", "SalesClass", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.SalesClass), "SalesClassFormats", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.SalesClassFormat), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountOfficeSalesClassAccount", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "OfficeSalesClassAccounts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeSalesClassAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountOfficeSalesClassAccount2", "GeneralLedgerAccount2", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "OfficeSalesClassAccount2", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeSalesClassAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountOfficeSalesClassAccount3", "GeneralLedgerAccount3", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "OfficeSalesClassAccounts3", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeSalesClassAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountOfficeSalesClassAccount4", "GeneralLedgerAccount4", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "OfficeSalesClassAccounts4", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeSalesClassAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountOfficeSalesTaxAccount", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "OfficeSalesTaxAccounts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeSalesTaxAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountOfficeSalesTaxAccount2", "GeneralLedgerAccount2", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "OfficeSalesTaxAccounts2", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeSalesTaxAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountOfficeSalesTaxAccount3", "GeneralLedgerAccount3", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "OfficeSalesTaxAccounts3", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeSalesTaxAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeOfficeSalesClassAccount", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Office), "OfficeSalesClassAccounts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeSalesClassAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesClassOfficeSalesClassAccount", "SalesClass", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.SalesClass), "OfficeSalesClassAccounts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeSalesClassAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeOfficeSalesTaxAccount", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Office), "OfficeSalesTaxAccounts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeSalesTaxAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesTaxOfficeSalesTaxAccount", "SalesTax", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.SalesTax), "OfficeSalesTaxAccounts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeSalesTaxAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientAssociates", "Client", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Client), "Associates", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Associate), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorAssociates", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Vendor), "Associates", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Associate), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PTORulePTORuleDetail", "PTORule", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.PTORule), "PTORuleDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.PTORuleDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobTypeVendorPricing", "JobType", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobType), "VendorPricings", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.VendorPricing), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorVendorPricing", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Vendor), "VendorPricings", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.VendorPricing), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ResourceTypeResource", "ResourceType", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.ResourceType), "Resources", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Resource), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ResourceResourceTasks", "Resource", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Resource), "ResourceTasks", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ResourceTask), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "TaskResourceTask", "Task", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Task), "ResourceTasks", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ResourceTask), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DocumentExpenseReportDocuments", "Document", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Document), "ExpenseReportDocuments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ExpenseReportDocument), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountOverheadAccount", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "OverheadAccounts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OverheadAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountOverheadAccount2", "GeneralLedgerAccount2", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "OverheadAccounts2", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OverheadAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PurchaseOrderApprovalRulePurchaseOrderRuleDetail", "PurchaseOrderApprovalRule", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.PurchaseOrderApprovalRule), "PurchaseOrderApprovalRuleDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.PurchaseOrderApprovalRuleDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PurchaseOrderApprovalRuleDetailPurchaseOrderApprovalRuleEmployee", "PurchaseOrderRuleDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.PurchaseOrderApprovalRuleDetail), "PurchaseOrderApprovalRuleEmployees", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.PurchaseOrderApprovalRuleEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "POApprovalRuleDetailPOApproval", "POApprovalRuleDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.PurchaseOrderApprovalRuleDetail), "POApprovals", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.POApproval), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "POApprovalRuleEmployeePOApproval", "POApprovalRuleEmployee", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.PurchaseOrderApprovalRuleEmployee), "POApprovals", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.POApproval), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorRateCard", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Vendor), "RateCards", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RateCard), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "RateCardRateCardDetail", "RateCard", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.RateCard), "RateCardDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RateCardDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "RateCardRateCardColorCharge", "RateCard", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.RateCard), "RateCardColorCharges", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RateCardColorCharge), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FunctionOfficeFunctionAccount", "Function", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.[Function]), "OfficeFunctionAccounts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeFunctionAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FunctionOfficeSalesClassFunctionAccount", "Function", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.[Function]), "OfficeSalesClassFunctionAccounts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeSalesClassFunctionAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountOfficeFunctionAccount2", "GeneralLedgerAccount2", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "OfficeFunctionAccounts2", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeFunctionAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountOfficeFunctionAccount", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "OfficeFunctionAccounts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeFunctionAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountOfficeInterCompany", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "OfficeInterCompanies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeInterCompany), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountOfficeInterCompany2", "GeneralLedgerAccount2", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "OfficeInterCompanies2", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeInterCompany), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountOfficeSalesClassFunctionAccount", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "OfficeSalesClassFunctionAccounts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeSalesClassFunctionAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountOfficeSalesClassFunctionAccount2", "GeneralLedgerAccount2", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "OfficeSalesClassFunctionAccounts2", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeSalesClassFunctionAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeGeneralLedgerOfficeCrossReference", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Office), "GeneralLedgerOfficeCrossReferences", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.GeneralLedgerOfficeCrossReference), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeOfficeFunctionAccount", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Office), "OfficeFunctionAccounts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeFunctionAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeOfficeInterCompany", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Office), "OfficeInterCompanies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeInterCompany), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeOfficeInterCompany2", "Office2", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Office), "OfficeInterCompanies2", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeInterCompany), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeSalesClassAccountOfficeSalesClassFunctionAccount", "OfficeSalesClassAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.OfficeSalesClassAccount), "OfficeSalesClassFunctionAccounts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OfficeSalesClassFunctionAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DocumentTypeDocuments", "DocumentType", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.DocumentType), "Documents", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Document), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountGeneralLedgerDetail", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "GeneralLedgerDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.GeneralLedgerDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PostPeriodGeneralLedger", "PostPeriod", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.PostPeriod), "GeneralLedgers", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.GeneralLedger), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductGeneralLedgerDetail", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Product), "GeneralLedgerDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.GeneralLedgerDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorOffice", "Vendors", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Vendor), "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Office), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorMarket", "Vendors", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Vendor), "Market", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Market), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableAccountPayableProduction", "AccountPayable", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AccountPayable), "AccountPayableProduction", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableProduction), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DepartmentTeamAccountPayableProduction", "DepartmentTeam", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.DepartmentTeam), "AccountPayableProduction", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableProduction), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FunctionAccountPayableProduction", "Function", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.[Function]), "AccountPayableProduction", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableProduction), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountAccountPayableProduction", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "AccountPayableProduction", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableProduction), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentAccountPayableProduction", "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobComponent), "AccountPayableProduction", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableProduction), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableProductionSalesTax", "AccountPayableProductions", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableProduction), "SalesTax", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesTax), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableProductionGeneralLedger", "AccountPayableProductions", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableProduction), "GeneralLedger", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedger), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayablePaymentCheckRegister", "AccountPayablePayments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayablePayment), "CheckRegister", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.CheckRegister), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableGeneralLedger", "AccountPayables", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayable), "GeneralLedger", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedger), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableAccountPayableGLDistribution", "AccountPayable", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AccountPayable), "AccountPayableGLDistributions", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableGLDistribution), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountAccountPayableGLDistribution", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "AccountPayableGLDistributions", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableGLDistribution), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorVendorSortKeys", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Vendor), "VendorSortKeys", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.VendorSortKey), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ImportTemplateImportTemplateDetails", "ImportTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.ImportTemplate), "ImportTemplateDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ImportTemplateDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountGeneralLedgerOfficeCrossReference", "GeneralLedgerAccounts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.GeneralLedgerAccount), "GeneralLedgerOfficeCrossReference", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerOfficeCrossReference), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FunctionPurchaseOrderDetail", "Function", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.[Function]), "PurchaseOrderDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.PurchaseOrderDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountPurchaseOrderDetail", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "PurchaseOrderDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.PurchaseOrderDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentPurchaseOrderDetail", "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobComponent), "PurchaseOrderDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.PurchaseOrderDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PurchaseOrderApprovalRulePurchaseOrder", "PurchaseOrderApprovalRule", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.PurchaseOrderApprovalRule), "PurchaseOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.PurchaseOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PurchaseOrderPOApproval", "PurchaseOrder", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.PurchaseOrder), "POApprovals", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.POApproval), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PurchaseOrderPurchaseOrderDetail", "PurchaseOrder", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.PurchaseOrder), "PurchaseOrderDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.PurchaseOrderDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorPurchaseOrder", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Vendor), "PurchaseOrders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.PurchaseOrder), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableAccountPayableInternet", "AccountPayable", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AccountPayable), "AccountPayableInternets", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableInternet), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableAccountPayableMagazine", "AccountPayable", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AccountPayable), "AccountPayableMagazines", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableMagazine), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableAccountPayableOutOfHome", "AccountPayable", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AccountPayable), "AccountPayableOutOfHomes", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableOutOfHome), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FK_AP_INTERNET_GLACODE", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "AP_INTERNET", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableInternet), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FK_AP_INTERNET_OFFICE_CODE", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Office), "AP_INTERNET", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableInternet), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FK_AP_MAG_GL_ACCT", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "AP_MAGAZINE", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableMagazine), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FK_AP_MAG_GL_DUE_FROM", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "AP_MAGAZINE", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableMagazine), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FK_AP_MAG_GL_DUE_TO", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "AP_MAGAZINE", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableMagazine), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesTaxAccountPayableMagazines", "SalesTax", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesTax), "AccountPayableMagazines", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableMagazine), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FK_AP_OUTDOOR_GLACODE", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "AP_OUTDOOR", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableOutOfHome), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FK_AP_OUTDOOR_OFFICE_CODE", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Office), "AP_OUTDOOR", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableOutOfHome), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableInternetGeneralLedgerAccount", "AccountPayableInternets", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableInternet), "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableInternetOffice", "AccountPayableInternets", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableInternet), "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Office), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableOutOfHomeOffice", "AccountPayableOutOfHome", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableOutOfHome), "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Office), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableOutOfHomeGeneralLedgerAccount", "AccountPayableOutOfHome", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableOutOfHome), "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableAccountPayableNewspaper", "AccountPayable", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AccountPayable), "AccountPayableNewspapers", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableNewspaper), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountAccountPayableNewspaper3", "GeneralLedgerAccount3", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "AccountPayableNewspapers3", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableNewspaper), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountAccountPayableNewspaper", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "AccountPayableNewspapers", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableNewspaper), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountAccountPayableNewspaper2", "GeneralLedgerAccount2", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "AccountPayableNewspapers2", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableNewspaper), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesTaxAccountPayableNewspaper", "SalesTax", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesTax), "AccountPayableNewspapers", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableNewspaper), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableMagazineSalesTax", "AccountPayableMagazine", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableMagazine), "SalesTax", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesTax), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableMagazineGeneralLedgerAccount", "AccountPayableMagazine", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableMagazine), "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableMagazineGeneralLedgerAccount1", "AccountPayableMagazine", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableMagazine), "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableMagazineGeneralLedgerAccount2", "AccountPayableMagazine", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableMagazine), "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableProductionJob", "AccountPayableProductions", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableProduction), "Job", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Job), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobTemplateJobComponents", "JobTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobTemplate), "JobComponents", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponent), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobTemplateJobTemplateDetails", "JobTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobTemplate), "JobTemplateDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobTemplateDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobTemplateItemJobTemplateDetails", "JobTemplateItem", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobTemplateItem), "JobTemplateDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobTemplateDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobPurchaseOrderDetail", "Job", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Job), "PurchaseOrderDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.PurchaseOrderDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobSpecificationVendorTabJobSpecificationTypes", "JobSpecificationVendorTab", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobSpecificationVendorTab), "JobSpecificationTypes", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobSpecificationType), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobSpecificationTypeJobSpecificationCategories", "JobSpecificationType", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobSpecificationType), "JobSpecificationCategories", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobSpecificationCategory), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobSpecificationCategoryJobSpecificationFields", "JobSpecificationCategory", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobSpecificationCategory), "JobSpecificationFields", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobSpecificationField), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobSpecificationTypeJobSpecificationFields", "JobSpecificationType", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobSpecificationType), "JobSpecificationFields", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobSpecificationField), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AlertCategoryAlertGroupCategory", "AlertCategory", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AlertCategory), "AlertGroupCategories", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AlertGroupCategory), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorVendorComment", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Vendor), "VendorComment", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.VendorComment), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaSpecsHeaderMediaSpecsDetails", "MediaSpecsHeader", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaSpecsHeader), "MediaSpecsDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaSpecsDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientMediaPlan", "Client", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Client), "MediaPlans", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlan), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanMediaPlanDetail", "MediaPlan", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaPlan), "MediaPlanDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesClassMediaPlanDetail", "SalesClass", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesClass), "MediaPlanDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ManagementLevelAccountExecutive", "ManagementLevel", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.ManagementLevel), "AccountExecutives", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountExecutive), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanMediaPlanDetailLevelLineData", "MediaPlan", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaPlan), "MediaPlanDetailLevelLineDatas", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailLevelLineData), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanMediaPlanDetailLevelLine", "MediaPlan", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaPlan), "MediaPlanDetailLevelLines", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailLevelLine), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanMediaPlanDetailLevel", "MediaPlan", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaPlan), "MediaPlanDetailLevels", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailLevel), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanDetailMediaPlanDetailLevelLineData", "MediaPlanDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaPlanDetail), "MediaPlanDetailLevelLineDatas", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailLevelLineData), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanDetailMediaPlanDetailLevelLine", "MediaPlanDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaPlanDetail), "MediaPlanDetailLevelLines", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailLevelLine), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanDetailMediaPlanDetailLevel", "MediaPlanDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaPlanDetail), "MediaPlanDetailLevels", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailLevel), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanDetailLevelMediaPlanDetailLevelLine", "MediaPlanDetailLevel", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaPlanDetailLevel), "MediaPlanDetailLevelLines", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailLevelLine), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AdSizeMediaPlanDetailLevelLineTag", "AdSize", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AdSize), "MediaPlanDetailLevelLineTags", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailLevelLineTag), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "InternetTypeMediaPlanDetailLevelLineTag", "InternetType", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.InternetType), "MediaPlanDetailLevelLineTags", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailLevelLineTag), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MarketMediaPlanDetailLevelLineTag", "Market", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Market), "MediaPlanDetailLevelLineTags", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailLevelLineTag), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanMediaPlanDetailField", "MediaPlan", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaPlan), "MediaPlanDetailFields", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailField), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanMediaPlanDetailLevelLineTag", "MediaPlan", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaPlan), "MediaPlanDetailLevelLineTags", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailLevelLineTag), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanDetailMediaPlanDetailField", "MediaPlanDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaPlanDetail), "MediaPlanDetailFields", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailField), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanDetailMediaPlanDetailLevelLineTag", "MediaPlanDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaPlanDetail), "MediaPlanDetailLevelLineTags", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailLevelLineTag), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanDetailLevelLineMediaPlanDetailLevelLineTag", "MediaPlanDetailLevelLine", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaPlanDetailLevelLine), "MediaPlanDetailLevelLineTags", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailLevelLineTag), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorMediaPlanDetailLevelLineTag", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Vendor), "MediaPlanDetailLevelLineTags", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailLevelLineTag), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableGLDistributionGeneralLedger", "AccountPayableGLDistributions", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableGLDistribution), "GeneralLedger", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedger), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountAccountPayableRecurGeneralLedger", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "AccountPayableRecurGeneralLedger", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableRecurGeneralLedger), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableRecurAccountPayableRecurGeneralLedger", "AccountPayableRecur", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AccountPayableRecur), "AccountPayableRecurGeneralLedgers", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableRecurGeneralLedger), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountAccountPayableRecur", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "AccountPayableRecurs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableRecur), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PostPeriodAccountPayableRecur", "PostPeriod", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.PostPeriod), "AccountPayableRecurs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableRecur), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PostPeriodAccountPayableRecur2", "PostPeriodCode2", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.PostPeriod), "AccountPayableRecur2", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableRecur), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorTermAccountPayableRecur", "VendorTerm", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.VendorTerm), "AccountPayableRecurs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableRecur), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CycleAccountPayableRecur", "Cycle", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Cycle), "AccountPayableRecurs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableRecur), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobTypeCreativeBriefTemplates", "JobType", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobType), "CreativeBriefTemplates", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.CreativeBriefTemplate), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CreativeBriefTemplateCreativeBriefTemplateLevel1s", "CreativeBriefTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.CreativeBriefTemplate), "CreativeBriefTemplateLevel1s", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.CreativeBriefTemplateLevel1), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CreativeBriefTemplateLevel1CreativeBriefTemplateLevel2s", "CreativeBriefTemplateLevel1", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.CreativeBriefTemplateLevel1), "CreativeBriefTemplateLevel2s", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.CreativeBriefTemplateLevel2), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CreativeBriefTemplateLevel2CreativeBriefTemplateLevel3s", "CreativeBriefTemplateLevel2", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.CreativeBriefTemplateLevel2), "CreativeBriefTemplateLevel3s", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.CreativeBriefTemplateLevel3), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentCreativeBriefDetails", "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobComponent), "CreativeBriefDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.CreativeBriefDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CreativeBriefTemplateLevel3CreativeBriefDetails", "CreativeBriefTemplateLevel3", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.CreativeBriefTemplateLevel3), "CreativeBriefDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.CreativeBriefDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CampaignPartnerAllocations", "Campaign", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Campaign), "PartnerAllocations", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.PartnerAllocation), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductPartnerAllocations", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Product), "PartnerAllocations", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.PartnerAllocation), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DestinationDestinationContacts", "Destination", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Destination), "DestinationContacts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DestinationContact), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductDestinationContacts", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Product), "DestinationContacts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DestinationContact), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CurrencyVendorHistorys", "Currency", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Currency), "VendorHistorys", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.VendorHistory), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "InternetOrderDetailAccountPayableInternets", "InternetOrderDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.InternetOrderDetail), "AccountPayableInternets", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableInternet), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "InternetTypeInternetOrderDetails", "InternetType", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.InternetType), "InternetOrderDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.InternetOrderDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentInternetOrderDetails", "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobComponent), "InternetOrderDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.InternetOrderDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "InternetOrderInternetOrderDetails", "InternetOrder", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.InternetOrder), "InternetOrderDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.InternetOrderDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentNewspaperOrderDetails", "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobComponent), "NewspaperOrderDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.NewspaperOrderDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "NewspaperOrderNewspaperOrderDetails", "NewspaperOrder", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.NewspaperOrder), "NewspaperOrderDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.NewspaperOrderDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OutOfHomeOrderDetailAccountPayableOutOfHomes", "OutOfHomeOrderDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.OutOfHomeOrderDetail), "AccountPayableOutOfHome", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableOutOfHome), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentOutOfHomeOrderDetails", "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobComponent), "OutOfHomeOrderDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OutOfHomeOrderDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OutOfHomeTypeOutOfHomeOrderDetails", "OutOfHomeType", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.OutOfHomeType), "OutOfHomeOrderDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OutOfHomeOrderDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OutOfHomeOrderOutOfHomeOrderDetails", "OutOfHomeOrder", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.OutOfHomeOrder), "OutOfHomeOrderDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OutOfHomeOrderDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GLReportTemplateGLReportTemplateColumn", "GLReportTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GLReportTemplate), "GLReportTemplateColumns", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.GLReportTemplateColumn), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GLReportTemplateGLReportTemplateRow", "GLReportTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GLReportTemplate), "GLReportTemplateRows", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.GLReportTemplateRow), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CampaignRadioOrderLegacies", "Campaign", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Campaign), "RadioOrderLegacies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MarketRadioOrderLegacies", "Market", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Market), "RadioOrderLegacies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductRadioOrderLegacies", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Product), "RadioOrderLegacies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesClassRadioOrderLegacies", "SalesClass", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesClass), "RadioOrderLegacies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesTaxRadioOrderLegacies", "SalesTax", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesTax), "RadioOrderLegacies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorRadioOrderLegacies", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Vendor), "RadioOrderLegacies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentRadioOrderDetailLegacies", "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobComponent), "RadioOrderDetailLegacies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "RadioOrderLegacyRadioOrderDetailLegacies", "RadioOrderLegacy", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.RadioOrderLegacy), "RadioOrderDetailLegacies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CampaignTVOrderLegacies", "Campaign", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Campaign), "TVOrderLegacies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentTVOrderDetailLegacies", "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobComponent), "TVOrderDetailLegacies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MarketTVOrderLegacies", "Market", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Market), "TVOrderLegacies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductTVOrderLegacies", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Product), "TVOrderLegacies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesClassTVOrderLegacies", "SalesClass", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesClass), "TVOrderLegacies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesTaxTVOrderLegacies", "SalesTax", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesTax), "TVOrderLegacies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "TVOrderLegacyTVOrderDetailLegacies", "TVOrderLegacy", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.TVOrderLegacy), "TVOrderDetailLegacies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorTVOrderLegacies", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Vendor), "TVOrderLegacies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DaypartTypeDaypart", "DaypartType", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.DaypartType), "Dayparts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Daypart), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DaypartMediaPlanDetailLevelLineTag", "Daypart", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Daypart), "MediaPlanDetailLevelLineTags", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailLevelLineTag), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DocumentExpenseDetailDocuments", "Document", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Document), "ExpenseDetailDocuments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ExpenseDetailDocument), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ContractContractContacts", "Contract", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Contract), "ContractContacts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ContractContact), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ContractContractDocuments", "Contract", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Contract), "ContractDocuments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ContractDocument), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ContractContractFees", "Contract", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Contract), "ContractFees", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ContractFee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ContractContractValueAddeds", "Contract", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Contract), "ContractValueAddeds", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ContractValueAdded), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DocumentContractDocuments", "Document", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Document), "ContractDocuments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ContractDocument), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ServiceTypeFeeContractFees", "ServiceFeeType", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.ServiceFeeType), "ContractFees", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ContractFee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ActivityActivityCompetitions", "Activity", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Activity), "ActivityCompetitions", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ActivityCompetition), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CompetitionActivityCompetitions", "Competition", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Competition), "ActivityCompetitions", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ActivityCompetition), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AffiliationCompanyProfileAffiliations", "Affiliation", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Affiliation), "CompanyProfileAffiliations", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.CompanyProfileAffiliation), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanMediaPlanDetailSetting", "MediaPlan", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaPlan), "MediaPlanDetailSettings", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailSetting), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanDetailMediaPlanDetailSetting", "MediaPlanDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaPlanDetail), "MediaPlanDetailSettings", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailSetting), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "RatingActivities", "Rating", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Rating), "Activities", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Activity), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SourceActivities", "Source", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Source), "Activities", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Activity), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CompanyProfileCompanyProfileAffiliations", "CompanyProfile", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.CompanyProfile), "CompanyProfileAffiliations", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.CompanyProfileAffiliation), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "IndustryCompanyProfiles", "Industry", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Industry), "CompanyProfiles", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.CompanyProfile), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "RegionCompanyProfiles", "Region", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.PrintSpecRegion), "CompanyProfiles", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.CompanyProfile), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SpecialtyCompanyProfiles", "Specialty", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Specialty), "CompanyProfile", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.CompanyProfile), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableInternetGeneralLedger", "AccountPayableInternet", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableInternet), "GeneralLedger", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedger), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableMagazineGeneralLedger", "AccountPayableMagazine", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableMagazine), "GeneralLedger", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedger), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableNewspaperGeneralLedger", "AccountPayableNewspaper", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableNewspaper), "GeneralLedger", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedger), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableOutOfHomeGeneralLedger", "AccountPayableOutOfHome", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableOutOfHome), "GeneralLedger", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedger), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableTVGeneralLedger", "AccountPayableTV", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableTV), "GeneralLedger", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedger), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableRadioGeneralLedger", "AccountPayableRadio", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableRadio), "GeneralLedger", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedger), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DocumentContractValueAdded", "Document", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Document), "ContractValueAdded", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ContractValueAdded), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GLReportTemplateGLReportTemplateRowRelation", "GLReportTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GLReportTemplate), "GLReportTemplateRowRelations", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.GLReportTemplateRowRelation), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GLReportTemplateRowGLReportTemplateRowRelation", "GLReportTemplateRow", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GLReportTemplateRow), "GLReportTemplateRowRelations", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.GLReportTemplateRowRelation), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ContractContractReports", "Contract", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Contract), "ContractReports", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ContractReport), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CycleContactReports", "Cycle", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Cycle), "ContactReports", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ContractReport), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentMagazineOrderDetails", "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobComponent), "MagazineOrderDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MagazineOrderDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MagazineOrderMagazineOrderDetails", "MagazineOrder", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MagazineOrder), "MagazineOrderDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MagazineOrderDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DocumentContractReport", "Document", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Document), "ContractReport", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ContractReport), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DepartmentTeamGLReportTemplateDepartmentTeamPreset", "DepartmentTeam", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.DepartmentTeam), "GLReportTemplateDepartmentTeamPresets", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.GLReportTemplateDepartmentTeamPreset), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GLReportTemplateGLReportTemplateDepartmentTeamPreset", "GLReportTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GLReportTemplate), "GLReportTemplateDepartmentTeamPresets", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.GLReportTemplateDepartmentTeamPreset), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GLReportTemplateGLReportTemplateOfficePreset", "GLReportTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GLReportTemplate), "GLReportTemplateOfficePresets", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.GLReportTemplateOfficePreset), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeGLReportTemplateOfficePreset", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Office), "GLReportTemplateOfficePresets", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.GLReportTemplateOfficePreset), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GLReportTemplateGLReportTemplatePctOfRowColumnRelation", "GLReportTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GLReportTemplate), "GLReportTemplatePctOfRowColumnRelations", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.GLReportTemplatePctOfRowColumnRelation), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountPayableOffice", "AccountPayable", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayable), "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Office), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DepartmentTeamGeneralLedgerDepartmentTeamCrossReference", "DepartmentTeam", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.DepartmentTeam), "GeneralLedgerDepartmentTeamCrossReferences", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.GeneralLedgerDepartmentTeamCrossReference), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountAccountReceivables", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "AccountReceivables", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountReceivable), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "InvoiceCategoryAccountReceivables", "InvoiceCategory", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.InvoiceCategory), "AccountReceivables", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountReceivable), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobAccountReceivables", "Job", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Job), "AccountReceivables", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountReceivable), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentAccountReceivables", "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobComponent), "AccountReceivables", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountReceivable), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeAccountReceivables", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Office), "AccountReceivables", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountReceivable), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PostPeriodAccountReceivables", "PostPeriod", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.PostPeriod), "AccountReceivables", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountReceivable), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductAccountReceivables", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Product), "AccountReceivables", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountReceivable), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableRadioOrderDetailLegaciesApr", "AccountReceivableApr", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "RadioOrderDetailLegaciesApr", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableRadioOrderDetailLegaciesAug", "AccountReceivableAug", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "RadioOrderDetailLegaciesAug", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableRadioOrderDetailLegaciesDec", "AccountReceivableDec", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "RadioOrderDetailLegaciesDec", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableRadioOrderDetailLegaciesFeb", "AccountReceivableFeb", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "RadioOrderDetailLegaciesFeb", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableRadioOrderDetailLegaciesJan", "AccountReceivableJan", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "RadioOrderDetailLegaciesJan", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableRadioOrderDetailLegaciesJul", "AccountReceivableJul", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "RadioOrderDetailLegaciesJul", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableRadioOrderDetailLegaciesJun", "AccountReceivableJun", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "RadioOrderDetailLegaciesJun", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableRadioOrderDetailLegaciesMar", "AccountReceivableMar", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "RadioOrderDetailLegaciesMar", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableRadioOrderDetailLegaciesMay", "AccountReceivableMay", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "RadioOrderDetailLegaciesMay", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableRadioOrderDetailLegacy", "AccountReceivable", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "RadioOrderDetailLegacies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableRadioOrderDetailLegaciesNov", "AccountReceivableNov", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "RadioOrderDetailLegaciesNov", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableRadioOrderDetailLegaciesOct", "AccountReceivableOct", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "RadioOrderDetailLegaciesOct", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableRadioOrderDetailLegaciesSep", "AccountReceivableSep", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "RadioOrderDetailLegaciesSep", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.RadioOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableTVOrderDetailLegaciesApr", "AccountReceivableApr", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "TVOrderDetailLegaciesApr", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableTVOrderDetailLegaciesAug", "AccountReceivableAug", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "TVOrderDetailLegaciesAug", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableTVOrderDetailLegaciesDec", "AccountReceivableDec", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "TVOrderDetailLegaciesDec", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableTVOrderDetailLegaciesFeb", "AccountReceivableFeb", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "TVOrderDetailLegaciesFeb", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableTVOrderDetailLegaciesJan", "AccountReceivableJan", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "TVOrderDetailLegaciesJan", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableTVOrderDetailLegaciesJul", "AccountReceivableJul", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "TVOrderDetailLegaciesJul", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableTVOrderDetailLegaciesJun", "AccountReceivableJun", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "TVOrderDetailLegaciesJun", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableTVOrderDetailLegaciesMar", "AccountReceivableMar", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "TVOrderDetailLegaciesMar", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableTVOrderDetailLegaciesMay", "AccountReceivableMay", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "TVOrderDetailLegaciesMay", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableTVOrderDetailLegacies", "AccountReceivable", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "TVOrderDetailLegacies", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableTVOrderDetailLegaciesNov", "AccountReceivableNov", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "TVOrderDetailLegaciesNov", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableTVOrderDetailLegaciesOct", "AccountReceivableOct", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "TVOrderDetailLegaciesOct", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableTVOrderDetailLegaciesSep", "AccountReceivableSep", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "TVOrderDetailLegaciesSep", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.TVOrderDetailLegacy), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableClient", "AccountReceivables", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountReceivable), "Client", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Client), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableClientCashReceiptDetails", "AccountReceivable", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "ClientCashReceiptDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientCashReceiptDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "BankClientCashReceipts", "Bank", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Bank), "ClientCashReceipts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientCashReceipt), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientClientCashReceipts", "Client", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Client), "ClientCashReceipts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientCashReceipt), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientCashReceiptClientCashReceiptDetails", "ClientCashReceipt", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.ClientCashReceipt), "ClientCashReceiptDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientCashReceiptDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountClientCashReceipts", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "ClientCashReceipts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientCashReceipt), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PostPeriodClientCashReceipts", "PostPeriod", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.PostPeriod), "ClientCashReceipts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientCashReceipt), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountAdjustmentClientCashReceiptDetails", "GeneralLedgerAccountAdjustment", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "ClientCashReceiptDetailsAdjustment", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientCashReceiptDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountARClientCashReceiptDetails", "GeneralLedgerAccountAR", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.GeneralLedgerAccount), "ClientCashReceiptDetailsAR", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientCashReceiptDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ContractProduct", "Contracts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Contract), "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Product), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "TimeCategoryTypeIndirectCategories", "TimeCategoryType", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.TimeCategoryType), "IndirectCategories", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.IndirectCategory), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableAccountReceivableDocument", "AccountReceivable", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AccountReceivable), "AccountReceivableDocuments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountReceivableDocument), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DocumentAccountReceivableDocument", "Document", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Document), "AccountReceivableDocuments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountReceivableDocument), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ImportAccountPayableImportAccountPayableGL", "ImportAccountPayable", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.ImportAccountPayable), "ImportAccountPayableGLs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ImportAccountPayableGL), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ImportAccountPayableImportAccountPayableJob", "ImportAccountPayable", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.ImportAccountPayable), "ImportAccountPayableJobs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ImportAccountPayableJob), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ImportAccountPayableImportAccountPayableMedia", "ImportAccountPayable", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.ImportAccountPayable), "ImportAccountPayableMedias", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ImportAccountPayableMedia), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ImportAccountPayableImportAccountPayableError", "ImportAccountPayable", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.ImportAccountPayable), "ImportAccountPayableErrors", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ImportAccountPayableError), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ImportAccountPayableGLImportAccountPayableError", "ImportAccountPayableGL", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.ImportAccountPayableGL), "ImportAccountPayableErrors", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ImportAccountPayableError), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ImportAccountPayableJobImportAccountPayableError", "ImportAccountPayableJob", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.ImportAccountPayableJob), "ImportAccountPayableErrors", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ImportAccountPayableError), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ImportAccountPayableMediaImportAccountPayableError", "ImportAccountPayableMedia", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.ImportAccountPayableMedia), "ImportAccountPayableErrors", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ImportAccountPayableError), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AlertStateAlert", "AlertState", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AlertState), "Alerts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Alert), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AlertCategoryAlertState", "AlertCategory", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AlertCategory), "AlertStates", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AlertState), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AlertAssignmentTemplateAlertAssignmentTemplateEmployee", "AlertAssignmentTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AlertAssignmentTemplate), "AlertAssignmentTemplateEmployees", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AlertAssignmentTemplateEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AlertStateAlertAssignmentTemplateEmployee", "AlertState", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AlertState), "AlertAssignmentTemplateEmployees", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AlertAssignmentTemplateEmployee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AlertAssignmentTemplateAlertAssignmentTemplateState", "AlertAssignmentTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AlertAssignmentTemplate), "AlertAssignmentTemplateStates", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AlertAssignmentTemplateState), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AlertStateAlertAssignmentTemplateState", "AlertState", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AlertState), "AlertAssignmentTemplateStates", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AlertAssignmentTemplateState), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentAlertAssignmentTemplate", "JobComponents", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponent), "AlertAssignmentTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AlertAssignmentTemplate), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ExportTemplateExportTemplateDetail", "ExportTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.ExportTemplate), "ExportTemplateDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ExportTemplateDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FunctionEmployeeTimesheetFunctions", "Function", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.[Function]), "EmployeeTimesheetFunctions", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimesheetFunction), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "StatusJobTrafficVersion", "Status", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Status), "JobTrafficVersions", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobTrafficVersion), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OutOfHomeTypeMediaPlanDetailLevelLineTag", "OutOfHomeType", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.OutOfHomeType), "MediaPlanDetailLevelLineTags", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailLevelLineTag), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ImportTemplateClientCrossReferences", "ImportTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.ImportTemplate), "ClientCrossReferences", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientCrossReference), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ImportTemplateGeneralLedgerCrossReferences", "ImportTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.ImportTemplate), "GeneralLedgerCrossReferences", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.GeneralLedgerCrossReference), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ImportTemplateVendorCrossReferences", "ImportTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.ImportTemplate), "VendorCrossReferences", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.VendorCrossReference), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DepartmentTeamEmployeeTimeTemplates", "DepartmentTeam", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.DepartmentTeam), "EmployeeTimeTemplates", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeTemplate), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "UserDefinedTypeUserDefinedTypeValue", "UserDefinedType", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.UserDefinedType), "UserDefinedTypeValues", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.UserDefinedTypeValue), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientCashReceiptClientCashReceiptOnAccounts", "ClientCashReceipt", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.ClientCashReceipt), "ClientCashReceiptOnAccounts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientCashReceiptOnAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountClientCashReceiptOnAccounts", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "ClientCashReceiptOnAccounts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientCashReceiptOnAccount), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "RecordSourceClientCrossReference", "RecordSource", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.RecordSource), "ClientCrossReferences", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ClientCrossReference), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "RecordSourceGeneralLedgerCrossReference", "RecordSource", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.RecordSource), "GeneralLedgerCrossReferences", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.GeneralLedgerCrossReference), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "RecordSourceImportTemplate", "RecordSource", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.RecordSource), "ImportTemplates", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ImportTemplate), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "RecordSourceVendorCrossReference", "RecordSource", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.RecordSource), "VendorCrossReferences", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.VendorCrossReference), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientContactJobComponentTaskClientContacts", "ClientContact", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.ClientContact), "JobComponentTaskClientContacts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponentTaskClientContact), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentTaskJobComponentTaskClientContacts", "JobComponentTask", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobComponentTask), "JobComponentTaskClientContacts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobComponentTaskClientContact), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobTrafficTemplateJobTrafficVersion", "JobTrafficVersion", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobTrafficVersion), "JobTrafficTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobTrafficTemplate), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DaypartAccountPayableRadio", "Daypart", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Daypart), "AccountPayableRadios", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableRadio), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DaypartAccountPayableTV", "Daypart", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Daypart), "AccountPayableTVs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AccountPayableTV), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DepartmentTeamEmployeeRateHistory", "DepartmentTeam", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.DepartmentTeam), "EmployeeRateHistories", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeRateHistory), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeTitleEmployeeRateHistory", "EmployeeTitle", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.EmployeeTitle), "EmployeeRateHistories", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeRateHistory), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "EmployeeRateHistoryEmployee", "EmployeeRateHistories", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeRateHistory), "Employee", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.views.Employee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AlertAssignmentTemplateWorkflowAlertState", "EndAlertAssignmentTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AlertAssignmentTemplate), "EndWorkflowAlertStates", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.WorkflowAlertState), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AlertStateWorkflowAlertState", "EndAlertState", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.AlertState), "EndWorkflowAlertStates", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.WorkflowAlertState), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ImportTemplateAdvantageServiceImport", "ImportTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.ImportTemplate), "AdvantageServiceImports", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AdvantageServiceImport), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientMediaATBs", "Client", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Client), "MediaATBs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaATB), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DivisionMediaATBs", "Division", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Division), "MediaATBs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaATB), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductMediaATBs", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Product), "MediaATBs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaATB), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaATBMediaATBRevisions", "MediaATB", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaATB), "MediaATBRevisions", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaATBRevision), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CampaignMediaATBRevisions", "Campaign", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Campaign), "MediaATBRevisions", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaATBRevision), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaATBRevisionMediaATBRevisionDetails", "MediaATBRevision", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaATBRevision), "MediaATBRevisionDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaATBRevisionDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesClassMediaATBRevisions", "SalesClass", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesClass), "MediaATBRevisions", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaATBRevision), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorMediaATBRevisionDetails", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Vendor), "MediaATBRevisionDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaATBRevisionDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "BudgetBudgetDetails", "Budget", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Budget), "BudgetDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.BudgetDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeBudgetDetails", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Office), "BudgetDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.BudgetDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesClassBudgetDetails", "SalesClass", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesClass), "BudgetDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.BudgetDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "WorkflowAlertStateAlertAssignmentTemplate", "AlertAssignmentTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AlertAssignmentTemplate), "WorkflowAlertState", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.WorkflowAlertState), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "WorkflowAlertStateEndAlertAssignmentTemplate", "EndAlertAssignmentTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AlertAssignmentTemplate), "WorkflowEndAlertState", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.WorkflowAlertState), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "WorkflowAlertStateAlertState", "AlertState", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AlertState), "WorkflowAlertState", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.WorkflowAlertState), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "WorkflowAlertStateEndAlertState", "AlertState", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AlertState), "EndWorkflowAlertState", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.WorkflowAlertState), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "WorkflowAlertStateWorkflow", "Workflow", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Workflow), "WorkflowAlertState", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.WorkflowAlertState), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DaypartImportAccountPayableMedia", "Daypart", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Daypart), "ImportAccountPayableMedias", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.ImportAccountPayableMedia), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanMediaPlanDetailChangeLog", "MediaPlan", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaPlan), "MediaPlanDetailChangeLogs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailChangeLog), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanDetailMediaPlanDetailChangeLog", "MediaPlanDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaPlanDetail), "MediaPlanDetailChangeLogs", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailChangeLog), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AdDigitalResults", "Ad", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Ad), "DigitalResults", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DigitalResult), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AdSizeDigitalResults", "AdSize", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AdSize), "DigitalResults", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DigitalResult), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CampaignDigitalResults", "Campaign", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Campaign), "DigitalResults", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DigitalResult), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ClientDigitalResults", "Client", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Client), "DigitalResults", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DigitalResult), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DivisionDigitalResults", "Division", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Division), "DigitalResults", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DigitalResult), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "InternetTypeDigitalResults", "InternetType", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.InternetType), "DigitalResults", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DigitalResult), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MarketDigitalResults", "Market", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Market), "DigitalResults", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DigitalResult), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanDigitalResults", "MediaPlan", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.MediaPlan), "DigitalResults", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DigitalResult), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanDetailDigitalResults", "MediaPlanDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.MediaPlanDetail), "DigitalResults", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DigitalResult), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanDetailLevelLineDigitalResults", "MediaPlanDetailLevelLine", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.MediaPlanDetailLevelLine), "DigitalResults", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DigitalResult), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ProductDigitalResults", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Product), "DigitalResults", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DigitalResult), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesClassDigitalResults", "SalesClass", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesClass), "DigitalResults", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DigitalResult), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "VendorDigitalResults", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Vendor), "DigitalResults", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.DigitalResult), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AccountReceivableIncomeOnlys", "AccountReceivable", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.AccountReceivable), "IncomeOnlys", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.IncomeOnly), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "DepartmentTeamIncomeOnlys", "DepartmentTeam", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.DepartmentTeam), "IncomeOnlys", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.IncomeOnly), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FunctionIncomeOnlys", "Function", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.[Function]), "IncomeOnlys", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.IncomeOnly), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "FunctionJobServiceFees", "Function", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.[Function]), "JobServiceFees", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobServiceFee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentIncomeOnlys", "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobComponent), "IncomeOnlys", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.IncomeOnly), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "SalesTaxIncomeOnlys", "SalesTax", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.SalesTax), "IncomeOnlys", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.IncomeOnly), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobServiceFeeIncomeOnlys", "JobServiceFee", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobServiceFee), "IncomeOnlys", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.IncomeOnly), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentJobServiceFees", "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.JobComponent), "JobServiceFees", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.JobServiceFee), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "BankOtherCashReceipts", "Bank", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Bank), "OtherCashReceipts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OtherCashReceipt), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OtherCashReceiptOtherCashReceiptDetails", "OtherCashReceipt", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.OtherCashReceipt), "OtherCashReceiptDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OtherCashReceiptDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountOtherCashReceipts", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "OtherCashReceipts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OtherCashReceipt), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "OfficeOtherCashReceipts", "Office", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.Office), "OtherCashReceipts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OtherCashReceipt), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "PostPeriodOtherCashReceipts", "PostPeriod", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.PostPeriod), "OtherCashReceipts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OtherCashReceipt), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "GeneralLedgerAccountOtherCashReceiptDetails", "GeneralLedgerAccount", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.GeneralLedgerAccount), "OtherCashReceiptDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.OtherCashReceiptDetail), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "ExportTemplateAdvantageServiceExports", "ExportTemplate", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.ExportTemplate), "AdvantageServiceExports", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.AdvantageServiceExport), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "AdMediaPlanDetailLevelLineTag", "Ad", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Ad), "MediaPlanDetailLevelLineTags", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailLevelLineTag), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobMediaPlanDetailLevelLineTag", "Job", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Job), "MediaPlanDetailLevelLineTags", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailLevelLineTag), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "JobComponentMediaPlanDetailLevelLineTag", "JobComponent", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.JobComponent), "MediaPlanDetailLevelLineTags", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanDetailLevelLineTag), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanMediaPlanMasterPlanDetail", "MediaPlan", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaPlan), "MediaPlanMasterPlanDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanMasterPlanDetail), True)>
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "MediaPlanMasterPlanMediaPlanMasterPlanDetail", "MediaPlanMasterPlan", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Database.Entities.MediaPlanMasterPlan), "MediaPlanMasterPlanDetails", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.MediaPlanMasterPlanDetail), True)>
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "TaskEmployeeTimeDetails", "Task", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Task), "EmployeeTimeDetail", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.EmployeeTimeDetail), True)>
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ObjectContext", "CurrencyClients", "Currency", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Database.Entities.Currency), "Clients", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Database.Entities.Client), True)>

Namespace Database

    Public Class ObjectContext
        Inherits BaseClasses.ObjectContext

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AccountExecutives
            AccountGroupDetails
            AccountGroups
            AccountPayableGLDistributions
            AccountPayableInternets
            AccountPayableMagazines
            AccountPayableMediaApprovals
            AccountPayableNewspapers
            AccountPayableOutOfHomes
            AccountPayablePayments
            AccountPayableProductionComments
            AccountPayableProductions
            AccountPayableRadios
            AccountPayableRecurGeneralLedgers
            AccountPayableRecurLogs
            AccountPayableRecurs
            AccountPayables
            AccountPayableTVs
            AccountPayableViews
            AccountReceivableCollectionNotes
            AccountReceivableDocuments
            AccountReceivableImportStagings
            AccountReceivables
            AccountReceivableSummaries
            AccountReceivableViews
            Accounts
            Activities
            ActivityCompetitions
            Ads
            AdSizeLabels
            AdSizes
            AdvantageServiceExports
            AdvantageServiceImports
            Affiliations
            Agencies
            AgencyClients
            AgencyComments
            AgencyDesktopDocuments
            AlertAssignmentTemplateDepartmentTeams
            AlertAssignmentTemplateEmailGroups
            AlertAssignmentTemplateEmployees
            AlertAssignmentTemplateRoles
            AlertAssignmentTemplates
            AlertAssignmentTemplateStates
            AlertAttachments
            AlertAttachmentViews
            AlertCategories
            AlertComments
            AlertDocumentKeywords
            AlertDocuments
            AlertGroupCategories
            AlertGroups
            AlertRecipientDismisseds
            AlertRecipients
            Alerts
            AlertsReports
            AlertStates
            AlertsWithCommentsReports
            AlertsWithRecipientsReports
            AlertTypes
            AlertViews
            AppVars
            AssignNumbers
            Associates
            BankExportSpecs
            Banks
            BillingCoops
            BillingRateDetails
            BillingRateDetailViews
            BillingRateLevels
            Blackplates
            BroadcastImportCrossReferences
            BudgetDetails
            Budgets
            CampaignDetails
            CampaignReports
            Campaigns
            CampaignViews
            CheckRegisters
            CheckWritingSelections
            ClientAccountsReceivableStatements
            ClientCashReceiptDetails
            ClientCashReceiptOnAccounts
            ClientCashReceipts
            ClientContact
            ClientContactDetails
            ClientContactReports
            ClientCrossReferences
            ClientPortalAlertRecipientDismisseds
            ClientPortalAlertRecipients
            ClientPortalAlertViews
            ClientReports
            Clients
            ClientSortKeys
            ClientWebsites
            CompanyProfileAffiliations
            CompanyProfiles
            Competitions
            Complexities
            ContactTypes
            ContractContacts
            ContractDocuments
            ContractFees
            ContractReports
            Contracts
            ContractValueAddeds
            CoreMediaCheckExports
            CreativeBriefDetails
            CreativeBriefTemplateLevel1s
            CreativeBriefTemplateLevel2s
            CreativeBriefTemplateLevel3s
            CreativeBriefTemplates
            CRMClientContractsReports
            CRMOpportunityDetailReports
            CRMOpportunityToInvestmentReports
            CRMProspectsReports
            Currencies
            CurrencyCodes
            CurrencyDetails
            CurrentJobProcessLogs
            CustomNavigationTabItems
            CustomNavigationTabs
            CustomReports
            Cycles
            Dashboards
            DataGridViewColumns
            DataGridViewColumnUserSettings
            DataGridViews
            Dayparts
            DaypartTypes
            DepartmentTeams
            DestinationContacts
            Destinations
            DigitalResults
            DirectIndirectTimeReports
            DirectIndirectTimeCostReports
            DirectTimeReports
            DirectTimeCostReports
            DivisionReports
            Divisions
            DivisionSortKeys
            DivisionViews
            DocumentComments
            Documents
            DocumentTypes
            DynamicReportColumns
            DynamicReports
            DynamicReportSummaryItems
            DynamicReportUnboundColumns
            EmployeeCategories
            EmployeeDepartments
            EmployeeNonTasks
            EmployeeOffices
            EmployeePictures
            EmployeeRateHistories
            EmployeeReports
            EmployeeRoles
            Employees
            EmployeeStandardHours
            EmployeeStandardHoursDetails
            EmployeeTimeComments
            EmployeeTimeDetails
            EmployeeTimeForecastOfficeDetailAlternateEmployees
            EmployeeTimeForecastOfficeDetailEmployees
            EmployeeTimeForecastOfficeDetailIndirectCategories
            EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees
            EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees
            EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees
            EmployeeTimeForecastOfficeDetailJobComponentEmployees
            EmployeeTimeForecastOfficeDetailJobComponents
            EmployeeTimeForecastOfficeDetails
            EmployeeTimeForecasts
            EmployeeTimeIndirects
            EmployeeTimes
            EmployeeTimesheetFunctions
            EmployeeTimeTemplates
            EmployeeTimeTotalsByOfficeClients
            EmployeeTitles
            EstimateApprovals
            EstimateComments
            EstimateFunctionComments
            EstimatePrintingSettings
            EstimatePrintSettings
            EstimateProcessingOptions
            EstimateRevisionDetails
            EstimateRevisions
            EstimateTemplates
            ETFOfficeDetailIndirectCategories
            ETFOfficeDetailIndirectCategoryAlternateEmployees
            ETFOfficeDetailIndirectCategoryEmployees
            ETFOfficeDetailJobComponentAlternateEmployees
            ETFOfficeDetailJobComponentEmployees
            ETFOfficeDetailJobComponents
            ExecutiveDesktopDocuments
            ExpenseDetailDocuments
            ExpenseReportDetails
            ExpenseReportDocuments
            ExpenseReports
            ExpenseSummarys
            ExportSystems
            ExportTemplateDetails
            ExportTemplates
            FiscalPeriods
            FunctionHeadings
            Functions
            FunctionViews
            GeneralDescriptions
            GeneralLedgerAccounts
            GeneralLedgerCrossReferences
            GeneralLedgerDepartmentTeamCrossReferences
            GeneralLedgerDetails
            GeneralLedgerOfficeCrossReferences
            GeneralLedgers
            GLAllocations
            GLASummaryDatas
            GLATrailers
            GLReportTemplateColumns
            GLReportTemplateDepartmentTeamPresets
            GLReportTemplateOfficePresets
            GLReportTemplatePctOfRowColumnRelations
            GLReportTemplateRowRelations
            GLReportTemplateRows
            GLReportTemplates
            GLReportUserDefReports
            GLTemplates
            IDs
            Images
            ImportAccountPayableErrors
            ImportAccountPayableGLs
            ImportAccountPayableJobs
            ImportAccountPayableMedias
            ImportAccountPayables
            ImportClearedChecksStagings
            ImportClientStagings
            ImportCreditCardStagings
            ImportDigitalResultsStagings
            ImportDivisionStagings
            ImportEmployeeStagings
            ImportFunctionStagings
            ImportGeneralLedgerAccountStagings
            ImportProductStagings
            ImportTemplateDetails
            ImportTemplates
            ImportVendorStagings
            IncomeOnlys
            IndirectCategories
            Industries
            InternetOrderDetails
            InternetOrders
            InternetTypes
            InvoiceCategories
            InvoiceJobComments
            InvoiceJobFunctionComments
            JobComponents
            JobComponentTaskClientContacts
            JobComponentTaskEmployees
            JobComponentTasks
            JobComponentUserDefinedValue1
            JobComponentUserDefinedValue2
            JobComponentUserDefinedValue3
            JobComponentUserDefinedValue4
            JobComponentUserDefinedValue5
            JobComponentViews
            JobDetailItemABs
            JobDetailItemCs
            JobDetailItemEIs
            JobDetailItemEs
            JobDetailItemES1
            JobDetailItemIs
            JobDetailItemNDs
            JobDetailItemPOes
            JobDetailItemVs
            JobProcessLogs
            JobProjectScheduleSummaryReports
            JobPurchaseOrderReports
            Jobs
            JobServiceFees
            JobSpecificationCategories
            JobSpecificationFields
            JobSpecificationTypes
            JobSpecificationVendorTabs
            JobSummaryReports
            JobTemplateDetails
            JobTemplateItems
            JobTemplates
            JobTraffic
            JobTrafficPredecessor
            JobTrafficSetupDetails
            JobTrafficSetupItems
            JobTrafficTemplates
            JobTrafficVersions
            JobTypes
            JobUserDefinedValue1
            JobUserDefinedValue2
            JobUserDefinedValue3
            JobUserDefinedValue4
            JobUserDefinedValue5
            JobVersionDatabaseTypes
            JobVersionTemplateDetails
            JobVersionTemplates
            JobViews
            MagazineDetails
            MagazineOrderDetails
            MagazineOrders
            Magazines
            ManagementLevels
            Markets
            MediaATBRevisionDetails
            MediaATBRevisions
            MediaATBs
            MediaInvoiceDefaults
            MediaOrders
            MediaPlanDatas
            MediaPlanDetailChangeLogs
            MediaPlanDetailFields
            MediaPlanDetailLevelLineDatas
            MediaPlanDetailLevelLines
            MediaPlanDetailLevelLineTags
            MediaPlanDetailLevels
            MediaPlanDetails
            MediaPlanDetailSettings
            MediaPlanMasterPlanDetails
            MediaPlanMasterPlans
            MediaPlanReports
            MediaPlans
            MediaSpecsDetails
            MediaSpecsHeaders
            MyObjectDefinitionAvailableOptions
            MyObjectDefinitionObjects
            MyObjectDefinitionSettings
            MyObjectDefinitionStaticOptions
            NewspaperDetails
            NewspaperHeaders
            NewspaperOrderDetailReports
            NewspaperOrderDetails
            NewspaperOrders
            OfficeDocuments
            OfficeFunctionAccounts
            OfficeInterCompanies
            Offices
            OfficeSalesClassAccounts
            OfficeSalesClassFunctionAccounts
            OfficeSalesTaxAccounts
            OtherCashReceiptDetails
            OtherCashReceipts
            OutOfHomeOrderDetails
            OutOfHomeOrders
            OutOfHomeTypes
            OverheadAccounts
            PartnerAllocationDetails
            PartnerAllocations
            Partners
            Phases
            POApprovals
            PostPeriods
            PrintSpecRegions
            PrintSpecStatuses
            ProductAccountsReceivableStatements
            ProductCategories
            ProductionInvoiceDefaults
            ProductReports
            Products
            ProductSortKeys
            ProductViews
            ProjectHoursUsedReports
            ProjectScheduleReports
            PromotionTypes
            PTORuleDetails
            PTORules
            PurchaseOrderApprovalRuleDetails
            PurchaseOrderApprovalRuleEmployees
            PurchaseOrderApprovalRules
            PurchaseOrderDetails
            PurchaseOrderPrintDefaults
            PurchaseOrders
            RadioOrderDetailLegacies
            RadioOrderDetails
            RadioOrderLegacies
            RadioOrders
            RateCardColorCharges
            RateCardDetails
            RateCards
            Ratings
            RecordSources
            Resources
            ResourceTasks
            ResourceTypes
            Roles
            SalesClasses
            SalesClassFormats
            SalesTaxes
            ServiceFeeReconcileDetails
            ServiceFeeTypes
            Sources
            Specialties
            StandardComments
            Status
            Tasks
            TaskTemplates
            TimeCategoryTypes
            TimeRuleLogs
            TVOrderDetailLegacies
            TVOrderDetails
            TVOrderLegacies
            TVOrders
            UserDefinedLabel
            UserDefinedReportCategories
            UserDefinedReports
            UserDefinedTypes
            UserDefinedTypeValues
            VendorComments
            VendorContacts
            VendorCrossReferences
            VendorHistorys
            VendorInvoiceAlerts
            VendorInvoiceDetails
            VendorInvoices
            VendorPricings
            VendorReports
            Vendors
            VendorSortKeys
            VendorTerms
            WebsiteTypes
            WorkflowAlertStates
            Workflows1
        End Enum

#End Region

#Region " Variables "

        Private _AccountExecutives As System.Data.Objects.ObjectSet(Of Database.Entities.AccountExecutive) = Nothing
        Private _AccountGroupDetails As System.Data.Objects.ObjectSet(Of Database.Entities.AccountGroupDetail) = Nothing
        Private _AccountGroups As System.Data.Objects.ObjectSet(Of Database.Entities.AccountGroup) = Nothing
        Private _AccountPayableGLDistributions As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableGLDistribution) = Nothing
        Private _AccountPayableInternets As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableInternet) = Nothing
        Private _AccountPayableMagazines As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableMagazine) = Nothing
        Private _AccountPayableMediaApprovals As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableMediaApproval) = Nothing
        Private _AccountPayableNewspapers As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableNewspaper) = Nothing
        Private _AccountPayableOutOfHomes As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableOutOfHome) = Nothing
        Private _AccountPayablePayments As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayablePayment) = Nothing
        Private _AccountPayableProductionComments As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableProductionComment) = Nothing
        Private _AccountPayableProductions As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableProduction) = Nothing
        Private _AccountPayableRadios As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableRadio) = Nothing
        Private _AccountPayableRecurGeneralLedgers As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableRecurGeneralLedger) = Nothing
        Private _AccountPayableRecurLogs As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableRecurLog) = Nothing
        Private _AccountPayableRecurs As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableRecur) = Nothing
        Private _AccountPayables As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayable) = Nothing
        Private _AccountPayableTVs As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableTV) = Nothing
        Private _AccountPayableViews As System.Data.Objects.ObjectSet(Of Database.Views.AccountPayableView) = Nothing
        Private _AccountReceivableCollectionNotes As System.Data.Objects.ObjectSet(Of Database.Entities.AccountReceivableCollectionNote) = Nothing
        Private _AccountReceivableDocuments As System.Data.Objects.ObjectSet(Of Database.Entities.AccountReceivableDocument) = Nothing
        Private _AccountReceivableImportStagings As System.Data.Objects.ObjectSet(Of Database.Entities.AccountReceivableImportStaging) = Nothing
        Private _AccountReceivables As System.Data.Objects.ObjectSet(Of Database.Entities.AccountReceivable) = Nothing
        Private _AccountReceivableSummaries As System.Data.Objects.ObjectSet(Of Database.Entities.AccountReceivableSummary) = Nothing
        Private _AccountReceivableViews As System.Data.Objects.ObjectSet(Of Database.Views.AccountReceivableView) = Nothing
        Private _Accounts As System.Data.Objects.ObjectSet(Of Database.Entities.Account) = Nothing
        Private _Activities As System.Data.Objects.ObjectSet(Of Database.Entities.Activity) = Nothing
        Private _ActivityCompetitions As System.Data.Objects.ObjectSet(Of Database.Entities.ActivityCompetition) = Nothing
        Private _Ads As System.Data.Objects.ObjectSet(Of Database.Entities.Ad) = Nothing
        Private _AdSizeLabels As System.Data.Objects.ObjectSet(Of Database.Entities.AdSizeLabel) = Nothing
        Private _AdSizes As System.Data.Objects.ObjectSet(Of Database.Entities.AdSize) = Nothing
        Private _AdvantageServiceExports As System.Data.Objects.ObjectSet(Of Database.Entities.AdvantageServiceExport) = Nothing
        Private _AdvantageServiceImports As System.Data.Objects.ObjectSet(Of Database.Entities.AdvantageServiceImport) = Nothing
        Private _Affiliations As System.Data.Objects.ObjectSet(Of Database.Entities.Affiliation) = Nothing
        Private _Agencies As System.Data.Objects.ObjectSet(Of Database.Entities.Agency) = Nothing
        Private _AgencyClients As System.Data.Objects.ObjectSet(Of Database.Entities.AgencyClient) = Nothing
        Private _AgencyComments As System.Data.Objects.ObjectSet(Of Database.Entities.AgencyComment) = Nothing
        Private _AgencyDesktopDocuments As System.Data.Objects.ObjectSet(Of Database.Entities.AgencyDesktopDocument) = Nothing
        Private _AlertAssignmentTemplateDepartmentTeams As System.Data.Objects.ObjectSet(Of Database.Entities.AlertAssignmentTemplateDepartmentTeam) = Nothing
        Private _AlertAssignmentTemplateEmailGroups As System.Data.Objects.ObjectSet(Of Database.Entities.AlertAssignmentTemplateEmailGroup) = Nothing
        Private _AlertAssignmentTemplateEmployees As System.Data.Objects.ObjectSet(Of Database.Entities.AlertAssignmentTemplateEmployee) = Nothing
        Private _AlertAssignmentTemplateRoles As System.Data.Objects.ObjectSet(Of Database.Entities.AlertAssignmentTemplateRole) = Nothing
        Private _AlertAssignmentTemplates As System.Data.Objects.ObjectSet(Of Database.Entities.AlertAssignmentTemplate) = Nothing
        Private _AlertAssignmentTemplateStates As System.Data.Objects.ObjectSet(Of Database.Entities.AlertAssignmentTemplateState) = Nothing
        Private _AlertAttachments As System.Data.Objects.ObjectSet(Of Database.Entities.AlertAttachment) = Nothing
        Private _AlertAttachmentViews As System.Data.Objects.ObjectSet(Of Database.Views.AlertAttachmentView) = Nothing
        Private _AlertCategories As System.Data.Objects.ObjectSet(Of Database.Entities.AlertCategory) = Nothing
        Private _AlertComments As System.Data.Objects.ObjectSet(Of Database.Entities.AlertComment) = Nothing
        Private _AlertDocumentKeywords As System.Data.Objects.ObjectSet(Of Database.Entities.AlertDocumentKeyword) = Nothing
        Private _AlertDocuments As System.Data.Objects.ObjectSet(Of Database.Entities.AlertDocument) = Nothing
        Private _AlertGroupCategories As System.Data.Objects.ObjectSet(Of Database.Entities.AlertGroupCategory) = Nothing
        Private _AlertGroups As System.Data.Objects.ObjectSet(Of Database.Entities.AlertGroup) = Nothing
        Private _AlertRecipientDismisseds As System.Data.Objects.ObjectSet(Of Database.Entities.AlertRecipientDismissed) = Nothing
        Private _AlertRecipients As System.Data.Objects.ObjectSet(Of Database.Entities.AlertRecipient) = Nothing
        Private _Alerts As System.Data.Objects.ObjectSet(Of Database.Entities.Alert) = Nothing
        Private _AlertStates As System.Data.Objects.ObjectSet(Of Database.Entities.AlertState) = Nothing
        Private _AlertTypes As System.Data.Objects.ObjectSet(Of Database.Entities.AlertType) = Nothing
        Private _AlertViews As System.Data.Objects.ObjectSet(Of Database.Views.AlertView) = Nothing
        Private _AppVars As System.Data.Objects.ObjectSet(Of Database.Entities.AppVars) = Nothing
        Private _AssignNumbers As System.Data.Objects.ObjectSet(Of Database.Entities.AssignNumber) = Nothing
        Private _Associates As System.Data.Objects.ObjectSet(Of Database.Entities.Associate) = Nothing
        Private _BankExportSpecs As System.Data.Objects.ObjectSet(Of Database.Entities.BankExportSpec) = Nothing
        Private _Banks As System.Data.Objects.ObjectSet(Of Database.Entities.Bank) = Nothing
        Private _BillingCoops As System.Data.Objects.ObjectSet(Of Database.Entities.BillingCoop) = Nothing
        Private _BillingRateDetails As System.Data.Objects.ObjectSet(Of Database.Entities.BillingRateDetail) = Nothing
        Private _BillingRateDetailViews As System.Data.Objects.ObjectSet(Of Database.Views.BillingRateDetailView) = Nothing
        Private _BillingRateLevels As System.Data.Objects.ObjectSet(Of Database.Entities.BillingRateLevel) = Nothing
        Private _Blackplates As System.Data.Objects.ObjectSet(Of Database.Entities.Blackplate) = Nothing
        Private _BroadcastImportCrossReferences As System.Data.Objects.ObjectSet(Of Database.Entities.BroadcastImportCrossReference) = Nothing
        Private _BudgetDetails As System.Data.Objects.ObjectSet(Of Database.Entities.BudgetDetail) = Nothing
        Private _Budgets As System.Data.Objects.ObjectSet(Of Database.Entities.Budget) = Nothing
        Private _CampaignDetails As System.Data.Objects.ObjectSet(Of Database.Entities.CampaignDetail) = Nothing
        Private _Campaigns As System.Data.Objects.ObjectSet(Of Database.Entities.Campaign) = Nothing
        Private _CampaignViews As System.Data.Objects.ObjectSet(Of Database.Views.CampaignView) = Nothing
        Private _CheckRegisters As System.Data.Objects.ObjectSet(Of Database.Entities.CheckRegister) = Nothing
        Private _CheckWritingSelections As System.Data.Objects.ObjectSet(Of Database.Entities.CheckWritingSelection) = Nothing
        Private _ClientAccountsReceivableStatements As System.Data.Objects.ObjectSet(Of Database.Entities.ClientAccountsReceivableStatement) = Nothing
        Private _ClientCashReceiptDetails As System.Data.Objects.ObjectSet(Of Database.Entities.ClientCashReceiptDetail) = Nothing
        Private _ClientCashReceiptOnAccounts As System.Data.Objects.ObjectSet(Of Database.Entities.ClientCashReceiptOnAccount) = Nothing
        Private _ClientCashReceipts As System.Data.Objects.ObjectSet(Of Database.Entities.ClientCashReceipt) = Nothing
        Private _ClientContact As System.Data.Objects.ObjectSet(Of Database.Entities.ClientContact) = Nothing
        Private _ClientContactDetails As System.Data.Objects.ObjectSet(Of Database.Entities.ClientContactDetail) = Nothing
        Private _ClientCrossReferences As System.Data.Objects.ObjectSet(Of Database.Entities.ClientCrossReference) = Nothing
        Private _ClientPortalAlertRecipientDismisseds As System.Data.Objects.ObjectSet(Of Database.Entities.ClientPortalAlertRecipientDismissed) = Nothing
        Private _ClientPortalAlertRecipients As System.Data.Objects.ObjectSet(Of Database.Entities.ClientPortalAlertRecipient) = Nothing
        Private _ClientPortalAlertViews As System.Data.Objects.ObjectSet(Of Database.Views.ClientPortalAlertView) = Nothing
        Private _Clients As System.Data.Objects.ObjectSet(Of Database.Entities.Client) = Nothing
        Private _ClientSortKeys As System.Data.Objects.ObjectSet(Of Database.Entities.ClientSortKey) = Nothing
        Private _ClientWebsites As System.Data.Objects.ObjectSet(Of Database.Entities.ClientWebsite) = Nothing
        Private _CompanyProfileAffiliations As System.Data.Objects.ObjectSet(Of Database.Entities.CompanyProfileAffiliation) = Nothing
        Private _CompanyProfiles As System.Data.Objects.ObjectSet(Of Database.Entities.CompanyProfile) = Nothing
        Private _Competitions As System.Data.Objects.ObjectSet(Of Database.Entities.Competition) = Nothing
        Private _Complexities As System.Data.Objects.ObjectSet(Of Database.Entities.Complexity) = Nothing
        Private _ContactTypes As System.Data.Objects.ObjectSet(Of Database.Entities.ContactType) = Nothing
        Private _ContractContacts As System.Data.Objects.ObjectSet(Of Database.Entities.ContractContact) = Nothing
        Private _ContractDocuments As System.Data.Objects.ObjectSet(Of Database.Entities.ContractDocument) = Nothing
        Private _ContractFees As System.Data.Objects.ObjectSet(Of Database.Entities.ContractFee) = Nothing
        Private _ContractReports As System.Data.Objects.ObjectSet(Of Database.Entities.ContractReport) = Nothing
        Private _Contracts As System.Data.Objects.ObjectSet(Of Database.Entities.Contract) = Nothing
        Private _ContractValueAddeds As System.Data.Objects.ObjectSet(Of Database.Entities.ContractValueAdded) = Nothing
        Private _CoreMediaCheckExports As System.Data.Objects.ObjectSet(Of Database.Views.CoreMediaCheckExport) = Nothing
        Private _CreativeBriefDetails As System.Data.Objects.ObjectSet(Of Database.Entities.CreativeBriefDetail) = Nothing
        Private _CreativeBriefTemplates As System.Data.Objects.ObjectSet(Of Database.Entities.CreativeBriefTemplate) = Nothing
        Private _CreativeBriefTemplateLevel1s As System.Data.Objects.ObjectSet(Of Database.Entities.CreativeBriefTemplateLevel1) = Nothing
        Private _CreativeBriefTemplateLevel2s As System.Data.Objects.ObjectSet(Of Database.Entities.CreativeBriefTemplateLevel2) = Nothing
        Private _CreativeBriefTemplateLevel3s As System.Data.Objects.ObjectSet(Of Database.Entities.CreativeBriefTemplateLevel3) = Nothing
        Private _Currencies As System.Data.Objects.ObjectSet(Of Database.Entities.Currency) = Nothing
        Private _CurrencyCodes As System.Data.Objects.ObjectSet(Of Database.Entities.CurrencyCode) = Nothing
        Private _CurrencyDetails As System.Data.Objects.ObjectSet(Of Database.Entities.CurrencyDetail) = Nothing
        Private _CurrentJobProcessLogs As System.Data.Objects.ObjectSet(Of Database.Views.CurrentJobProcessLog) = Nothing
        Private _CustomNavigationTabItems As System.Data.Objects.ObjectSet(Of Database.Entities.CustomNavigationTabItem) = Nothing
        Private _CustomNavigationTabs As System.Data.Objects.ObjectSet(Of Database.Entities.CustomNavigationTab) = Nothing
        Private _CustomReports As System.Data.Objects.ObjectSet(Of Database.Entities.CustomReport) = Nothing
        Private _Cycles As System.Data.Objects.ObjectSet(Of Database.Entities.Cycle) = Nothing
        Private _Dashboards As System.Data.Objects.ObjectSet(Of Database.Entities.Dashboard) = Nothing
        Private _DataGridViewColumns As System.Data.Objects.ObjectSet(Of Database.Entities.DataGridViewColumn) = Nothing
        Private _DataGridViewColumnUserSettings As System.Data.Objects.ObjectSet(Of Database.Entities.DataGridViewColumnUserSetting) = Nothing
        Private _DataGridViews As System.Data.Objects.ObjectSet(Of Database.Entities.DataGridView) = Nothing
        Private _DaypartTypes As System.Data.Objects.ObjectSet(Of Database.Entities.DaypartType) = Nothing
        Private _Dayparts As System.Data.Objects.ObjectSet(Of Database.Entities.Daypart) = Nothing
        Private _DepartmentTeams As System.Data.Objects.ObjectSet(Of Database.Entities.DepartmentTeam) = Nothing
        Private _DestinationContacts As System.Data.Objects.ObjectSet(Of Database.Entities.DestinationContact) = Nothing
        Private _Destinations As System.Data.Objects.ObjectSet(Of Database.Entities.Destination) = Nothing
        Private _DigitalResults As System.Data.Objects.ObjectSet(Of Database.Entities.DigitalResult) = Nothing
        Private _Divisions As System.Data.Objects.ObjectSet(Of Database.Entities.Division) = Nothing
        Private _DivisionSortKeys As System.Data.Objects.ObjectSet(Of Database.Entities.DivisionSortKey) = Nothing
        Private _DivisionViews As System.Data.Objects.ObjectSet(Of Database.Views.DivisionView) = Nothing
        Private _DocumentComments As System.Data.Objects.ObjectSet(Of Database.Entities.DocumentComment) = Nothing
        Private _Documents As System.Data.Objects.ObjectSet(Of Database.Entities.Document) = Nothing
        Private _DocumentTypes As System.Data.Objects.ObjectSet(Of Database.Entities.DocumentType) = Nothing
        Private _EmployeeCategories As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeCategory) = Nothing
        Private _EmployeeDepartments As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeDepartment) = Nothing
        Private _EmployeeNonTasks As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeNonTask) = Nothing
        Private _EmployeeOffices As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeOffice) = Nothing
        Private _EmployeePictures As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeePicture) = Nothing
        Private _EmployeeRateHistories As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeRateHistory) = Nothing
        Private _EmployeeRoles As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeRole) = Nothing
        Private _Employees As System.Data.Objects.ObjectSet(Of Database.Views.Employee) = Nothing
        Private _EmployeeStandardHours As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeStandardHours) = Nothing
        Private _EmployeeStandardHoursDetails As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeStandardHoursDetail) = Nothing
        Private _EmployeeTimeComments As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeComment) = Nothing
        Private _EmployeeTimeDetails As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeDetail) = Nothing
        Private _EmployeeTimeForecastOfficeDetailAlternateEmployees As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee) = Nothing
        Private _EmployeeTimeForecastOfficeDetailEmployees As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailEmployee) = Nothing
        Private _EmployeeTimeForecastOfficeDetailIndirectCategories As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory) = Nothing
        Private _EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee) = Nothing
        Private _EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee) = Nothing
        Private _EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee) = Nothing
        Private _EmployeeTimeForecastOfficeDetailJobComponentEmployees As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee) = Nothing
        Private _EmployeeTimeForecastOfficeDetailJobComponents As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent) = Nothing
        Private _EmployeeTimeForecastOfficeDetails As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetail) = Nothing
        Private _EmployeeTimeForecasts As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecast) = Nothing
        Private _EmployeeTimeIndirects As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeIndirect) = Nothing
        Private _EmployeeTimes As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTime) = Nothing
        Private _EmployeeTimesheetFunctions As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimesheetFunction) = Nothing
        Private _EmployeeTimeTemplates As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeTemplate) = Nothing
        Private _EmployeeTimeTotalsByOfficeClients As System.Data.Objects.ObjectSet(Of Database.Views.EmployeeTimeTotalsByOfficeClient) = Nothing
        Private _EmployeeTitles As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTitle) = Nothing
        Private _EstimateApprovals As System.Data.Objects.ObjectSet(Of Database.Views.EstimateApproval) = Nothing
        Private _EstimateComments As System.Data.Objects.ObjectSet(Of Database.Views.EstimateComment) = Nothing
        Private _EstimateFunctionComments As System.Data.Objects.ObjectSet(Of Database.Views.EstimateFunctionComment) = Nothing
        Private _EstimatePrintingSettings As System.Data.Objects.ObjectSet(Of Database.Entities.EstimatePrintingSetting) = Nothing
        Private _EstimatePrintSettings As System.Data.Objects.ObjectSet(Of Database.Entities.EstimatePrintSetting) = Nothing
        Private _EstimateProcessingOptions As System.Data.Objects.ObjectSet(Of Database.Entities.EstimateProcessingOption) = Nothing
        Private _EstimateRevisionDetails As System.Data.Objects.ObjectSet(Of Database.Entities.EstimateRevisionDetail) = Nothing
        Private _EstimateRevisions As System.Data.Objects.ObjectSet(Of Database.Entities.EstimateRevision) = Nothing
        Private _EstimateTemplates As System.Data.Objects.ObjectSet(Of Database.Entities.EstimateTemplate) = Nothing
        Private _ETFOfficeDetailIndirectCategories As System.Data.Objects.ObjectSet(Of Database.Views.ETFOfficeDetailIndirectCategory) = Nothing
        Private _ETFOfficeDetailIndirectCategoryAlternateEmployees As System.Data.Objects.ObjectSet(Of Database.Views.ETFOfficeDetailIndirectCategoryAlternateEmployee) = Nothing
        Private _ETFOfficeDetailIndirectCategoryEmployees As System.Data.Objects.ObjectSet(Of Database.Views.ETFOfficeDetailIndirectCategoryEmployee) = Nothing
        Private _ETFOfficeDetailJobComponentAlternateEmployees As System.Data.Objects.ObjectSet(Of Database.Views.ETFOfficeDetailJobComponentAlternateEmployee) = Nothing
        Private _ETFOfficeDetailJobComponentEmployees As System.Data.Objects.ObjectSet(Of Database.Views.ETFOfficeDetailJobComponentEmployee) = Nothing
        Private _ETFOfficeDetailJobComponents As System.Data.Objects.ObjectSet(Of Database.Views.ETFOfficeDetailJobComponent) = Nothing
        Private _ExecutiveDesktopDocuments As System.Data.Objects.ObjectSet(Of Database.Entities.ExecutiveDesktopDocument) = Nothing
        Private _ExpenseDetailDocuments As System.Data.Objects.ObjectSet(Of Database.Entities.ExpenseDetailDocument) = Nothing
        Private _ExpenseReportDetails As System.Data.Objects.ObjectSet(Of Database.Entities.ExpenseReportDetail) = Nothing
        Private _ExpenseReportDocuments As System.Data.Objects.ObjectSet(Of Database.Entities.ExpenseReportDocument) = Nothing
        Private _ExpenseReports As System.Data.Objects.ObjectSet(Of Database.Entities.ExpenseReport) = Nothing
        Private _ExpenseSummarys As System.Data.Objects.ObjectSet(Of Database.Views.ExpenseSummary) = Nothing
        Private _ExportSystems As System.Data.Objects.ObjectSet(Of Database.Entities.ExportSystem) = Nothing
        Private _ExportTemplateDetails As System.Data.Objects.ObjectSet(Of Database.Entities.ExportTemplateDetail) = Nothing
        Private _ExportTemplates As System.Data.Objects.ObjectSet(Of Database.Entities.ExportTemplate) = Nothing
        Private _FiscalPeriods As System.Data.Objects.ObjectSet(Of Database.Entities.FiscalPeriod) = Nothing
        Private _FunctionHeadings As System.Data.Objects.ObjectSet(Of Database.Entities.FunctionHeading) = Nothing
        Private _Functions As System.Data.Objects.ObjectSet(Of Database.Entities.[Function]) = Nothing
        Private _FunctionViews As System.Data.Objects.ObjectSet(Of Database.Views.FunctionView) = Nothing
        Private _GeneralDescriptions As System.Data.Objects.ObjectSet(Of Database.Entities.GeneralDescription) = Nothing
        Private _GeneralLedgerAccounts As System.Data.Objects.ObjectSet(Of Database.Entities.GeneralLedgerAccount) = Nothing
        Private _GeneralLedgerCrossReferences As System.Data.Objects.ObjectSet(Of Database.Entities.GeneralLedgerCrossReference) = Nothing
        Private _GeneralLedgerDepartmentTeamCrossReferences As System.Data.Objects.ObjectSet(Of Database.Entities.GeneralLedgerDepartmentTeamCrossReference) = Nothing
        Private _GeneralLedgerDetails As System.Data.Objects.ObjectSet(Of Database.Entities.GeneralLedgerDetail) = Nothing
        Private _GeneralLedgerOfficeCrossReferences As System.Data.Objects.ObjectSet(Of Database.Entities.GeneralLedgerOfficeCrossReference) = Nothing
        Private _GeneralLedgers As System.Data.Objects.ObjectSet(Of Database.Entities.GeneralLedger) = Nothing
        Private _GLAllocations As System.Data.Objects.ObjectSet(Of Database.Entities.GLAllocation) = Nothing
        Private _GLASummaryDatas As System.Data.Objects.ObjectSet(Of Database.Entities.GLASummaryData) = Nothing
        Private _GLATrailers As System.Data.Objects.ObjectSet(Of Database.Entities.GLATrailer) = Nothing
        Private _GLReportTemplateColumns As System.Data.Objects.ObjectSet(Of Database.Entities.GLReportTemplateColumn) = Nothing
        Private _GLReportTemplateDepartmentTeamPresets As System.Data.Objects.ObjectSet(Of Database.Entities.GLReportTemplateDepartmentTeamPreset) = Nothing
        Private _GLReportTemplateOfficePresets As System.Data.Objects.ObjectSet(Of Database.Entities.GLReportTemplateOfficePreset) = Nothing
        Private _GLReportTemplatePctOfRowColumnRelations As System.Data.Objects.ObjectSet(Of Database.Entities.GLReportTemplatePctOfRowColumnRelation) = Nothing
        Private _GLReportTemplateRowRelations As System.Data.Objects.ObjectSet(Of Database.Entities.GLReportTemplateRowRelation) = Nothing
        Private _GLReportTemplateRows As System.Data.Objects.ObjectSet(Of Database.Entities.GLReportTemplateRow) = Nothing
        Private _GLReportTemplates As System.Data.Objects.ObjectSet(Of Database.Entities.GLReportTemplate) = Nothing
        Private _GLReportUserDefReports As System.Data.Objects.ObjectSet(Of Database.Entities.GLReportUserDefReport) = Nothing
        Private _GLTemplates As System.Data.Objects.ObjectSet(Of Database.Entities.GLTemplate) = Nothing
        Private _IDs As System.Data.Objects.ObjectSet(Of Database.Entities.ID) = Nothing
        Private _Images As System.Data.Objects.ObjectSet(Of Database.Entities.Image) = Nothing
        Private _ImportAccountPayableErrors As System.Data.Objects.ObjectSet(Of Database.Entities.ImportAccountPayableError) = Nothing
        Private _ImportAccountPayableGLs As System.Data.Objects.ObjectSet(Of Database.Entities.ImportAccountPayableGL) = Nothing
        Private _ImportAccountPayableJobs As System.Data.Objects.ObjectSet(Of Database.Entities.ImportAccountPayableJob) = Nothing
        Private _ImportAccountPayableMedias As System.Data.Objects.ObjectSet(Of Database.Entities.ImportAccountPayableMedia) = Nothing
        Private _ImportAccountPayables As System.Data.Objects.ObjectSet(Of Database.Entities.ImportAccountPayable) = Nothing
        Private _ImportClearedChecksStagings As System.Data.Objects.ObjectSet(Of Database.Entities.ImportClearedChecksStaging) = Nothing
        Private _ImportDigitalResultsStagings As System.Data.Objects.ObjectSet(Of Database.Entities.ImportDigitalResultsStaging) = Nothing
        Private _ImportClientStagings As System.Data.Objects.ObjectSet(Of Database.Entities.ImportClientStaging) = Nothing
        Private _ImportCreditCardStagings As System.Data.Objects.ObjectSet(Of Database.Entities.ImportCreditCardStaging) = Nothing
        Private _ImportDivisionStagings As System.Data.Objects.ObjectSet(Of Database.Entities.ImportDivisionStaging) = Nothing
        Private _ImportEmployeeStagings As System.Data.Objects.ObjectSet(Of Database.Entities.ImportEmployeeStaging) = Nothing
        Private _ImportFunctionStagings As System.Data.Objects.ObjectSet(Of Database.Entities.ImportFunctionStaging) = Nothing
        Private _ImportGeneralLedgerAccountStagings As System.Data.Objects.ObjectSet(Of Database.Entities.ImportGeneralLedgerAccountStaging) = Nothing
        Private _ImportProductStagings As System.Data.Objects.ObjectSet(Of Database.Entities.ImportProductStaging) = Nothing
        Private _ImportTemplateDetails As System.Data.Objects.ObjectSet(Of Database.Entities.ImportTemplateDetail) = Nothing
        Private _ImportTemplates As System.Data.Objects.ObjectSet(Of Database.Entities.ImportTemplate) = Nothing
        Private _ImportVendorStagings As System.Data.Objects.ObjectSet(Of Database.Entities.ImportVendorStaging) = Nothing
        Private _IncomeOnlys As System.Data.Objects.ObjectSet(Of Database.Entities.IncomeOnly) = Nothing
        Private _IndirectCategories As System.Data.Objects.ObjectSet(Of Database.Entities.IndirectCategory) = Nothing
        Private _Industries As System.Data.Objects.ObjectSet(Of Database.Entities.Industry) = Nothing
        Private _InternetOrderDetails As System.Data.Objects.ObjectSet(Of Database.Entities.InternetOrderDetail) = Nothing
        Private _InternetOrders As System.Data.Objects.ObjectSet(Of Database.Entities.InternetOrder) = Nothing
        Private _InternetTypes As System.Data.Objects.ObjectSet(Of Database.Entities.InternetType) = Nothing
        Private _InvoiceCategories As System.Data.Objects.ObjectSet(Of Database.Entities.InvoiceCategory) = Nothing
        Private _InvoiceJobComments As System.Data.Objects.ObjectSet(Of Database.Views.InvoiceJobComment) = Nothing
        Private _InvoiceJobFunctionComments As System.Data.Objects.ObjectSet(Of Database.Views.InvoiceJobFunctionComment) = Nothing
        Private _JobComponents As System.Data.Objects.ObjectSet(Of Database.Entities.JobComponent) = Nothing
        Private _JobComponentTaskEmployees As System.Data.Objects.ObjectSet(Of Database.Entities.JobComponentTaskEmployee) = Nothing
        Private _JobComponentTasks As System.Data.Objects.ObjectSet(Of Database.Entities.JobComponentTask) = Nothing
        Private _JobComponentTaskClientContacts As System.Data.Objects.ObjectSet(Of Database.Entities.JobComponentTaskClientContact) = Nothing
        Private _JobComponentUserDefinedValue1 As System.Data.Objects.ObjectSet(Of Database.Entities.JobComponentUserDefinedValue1) = Nothing
        Private _JobComponentUserDefinedValue2 As System.Data.Objects.ObjectSet(Of Database.Entities.JobComponentUserDefinedValue2) = Nothing
        Private _JobComponentUserDefinedValue3 As System.Data.Objects.ObjectSet(Of Database.Entities.JobComponentUserDefinedValue3) = Nothing
        Private _JobComponentUserDefinedValue4 As System.Data.Objects.ObjectSet(Of Database.Entities.JobComponentUserDefinedValue4) = Nothing
        Private _JobComponentUserDefinedValue5 As System.Data.Objects.ObjectSet(Of Database.Entities.JobComponentUserDefinedValue5) = Nothing
        Private _JobComponentViews As System.Data.Objects.ObjectSet(Of Database.Views.JobComponentView) = Nothing
        Private _JobProcessLogs As System.Data.Objects.ObjectSet(Of Database.Entities.JobProcessLog) = Nothing
        Private _Jobs As System.Data.Objects.ObjectSet(Of Database.Entities.Job) = Nothing
        Private _JobServiceFees As System.Data.Objects.ObjectSet(Of Database.Entities.JobServiceFee) = Nothing
        Private _JobSpecificationCategories As System.Data.Objects.ObjectSet(Of Database.Entities.JobSpecificationCategory) = Nothing
        Private _JobSpecificationFields As System.Data.Objects.ObjectSet(Of Database.Entities.JobSpecificationField) = Nothing
        Private _JobSpecificationTypes As System.Data.Objects.ObjectSet(Of Database.Entities.JobSpecificationType) = Nothing
        Private _JobSpecificationVendorTabs As System.Data.Objects.ObjectSet(Of Database.Entities.JobSpecificationVendorTab) = Nothing
        Private _JobTemplates As System.Data.Objects.ObjectSet(Of Database.Entities.JobTemplate) = Nothing
        Private _JobTemplateDetails As System.Data.Objects.ObjectSet(Of Database.Entities.JobTemplateDetail) = Nothing
        Private _JobTemplateItems As System.Data.Objects.ObjectSet(Of Database.Entities.JobTemplateItem) = Nothing
        Private _JobTraffic As System.Data.Objects.ObjectSet(Of Database.Entities.JobTraffic) = Nothing
        Private _JobTrafficPredecessor As System.Data.Objects.ObjectSet(Of Database.Entities.JobTrafficPredecessors) = Nothing
        Private _JobTrafficSetupDetails As System.Data.Objects.ObjectSet(Of Database.Entities.JobTrafficSetupDetail) = Nothing
        Private _JobTrafficSetupItems As System.Data.Objects.ObjectSet(Of Database.Entities.JobTrafficSetupItem) = Nothing
        Private _JobTrafficTemplates As System.Data.Objects.ObjectSet(Of Database.Entities.JobTrafficTemplate) = Nothing
        Private _JobTrafficVersions As System.Data.Objects.ObjectSet(Of Database.Entities.JobTrafficVersion) = Nothing
        Private _JobTypes As System.Data.Objects.ObjectSet(Of Database.Entities.JobType) = Nothing
        Private _JobUserDefinedValue1 As System.Data.Objects.ObjectSet(Of Database.Entities.JobUserDefinedValue1) = Nothing
        Private _JobUserDefinedValue2 As System.Data.Objects.ObjectSet(Of Database.Entities.JobUserDefinedValue2) = Nothing
        Private _JobUserDefinedValue3 As System.Data.Objects.ObjectSet(Of Database.Entities.JobUserDefinedValue3) = Nothing
        Private _JobUserDefinedValue4 As System.Data.Objects.ObjectSet(Of Database.Entities.JobUserDefinedValue4) = Nothing
        Private _JobUserDefinedValue5 As System.Data.Objects.ObjectSet(Of Database.Entities.JobUserDefinedValue5) = Nothing
        Private _JobVersionDatabaseTypes As System.Data.Objects.ObjectSet(Of Database.Entities.JobVersionDatabaseType) = Nothing
        Private _JobVersionTemplateDetails As System.Data.Objects.ObjectSet(Of Database.Entities.JobVersionTemplateDetail) = Nothing
        Private _JobVersionTemplates As System.Data.Objects.ObjectSet(Of Database.Entities.JobVersionTemplate) = Nothing
        Private _JobViews As System.Data.Objects.ObjectSet(Of Database.Views.JobView) = Nothing
        Private _MagazineDetails As System.Data.Objects.ObjectSet(Of Database.Views.MagazineDetail) = Nothing
        Private _MagazineOrderDetails As System.Data.Objects.ObjectSet(Of Database.Entities.MagazineOrderDetail) = Nothing
        Private _MagazineOrders As System.Data.Objects.ObjectSet(Of Database.Entities.MagazineOrder) = Nothing
        Private _Magazines As System.Data.Objects.ObjectSet(Of Database.Views.Magazine) = Nothing
        Private _ManagementLevels As System.Data.Objects.ObjectSet(Of Database.Entities.ManagementLevel) = Nothing
        Private _Markets As System.Data.Objects.ObjectSet(Of Database.Entities.Market) = Nothing
        Private _MediaATBRevisionDetails As System.Data.Objects.ObjectSet(Of Database.Entities.MediaATBRevisionDetail) = Nothing
        Private _MediaATBRevisions As System.Data.Objects.ObjectSet(Of Database.Entities.MediaATBRevision) = Nothing
        Private _MediaATBs As System.Data.Objects.ObjectSet(Of Database.Entities.MediaATB) = Nothing
        Private _MediaInvoiceDefaults As System.Data.Objects.ObjectSet(Of Database.Entities.MediaInvoiceDefault) = Nothing
        Private _MediaOrders As System.Data.Objects.ObjectSet(Of Database.Views.MediaOrder) = Nothing
        Private _MediaPlanDatas As System.Data.Objects.ObjectSet(Of Database.Views.MediaPlanData) = Nothing
        Private _MediaPlanDetailChangeLogs As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanDetailChangeLog) = Nothing
        Private _MediaPlanDetailFields As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanDetailField) = Nothing
        Private _MediaPlanDetailLevelLineDatas As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanDetailLevelLineData) = Nothing
        Private _MediaPlanDetailLevelLines As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanDetailLevelLine) = Nothing
        Private _MediaPlanDetailLevelLineTags As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanDetailLevelLineTag) = Nothing
        Private _MediaPlanDetailLevels As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanDetailLevel) = Nothing
        Private _MediaPlanDetails As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanDetail) = Nothing
        Private _MediaPlanDetailSettings As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanDetailSetting) = Nothing
        Private _MediaPlanMasterPlanDetails As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanMasterPlanDetail) = Nothing
        Private _MediaPlanMasterPlans As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanMasterPlan) = Nothing
        Private _MediaPlans As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlan) = Nothing
        Private _MediaSpecsDetails As System.Data.Objects.ObjectSet(Of Database.Entities.MediaSpecsDetail) = Nothing
        Private _MediaSpecsHeaders As System.Data.Objects.ObjectSet(Of Database.Entities.MediaSpecsHeader) = Nothing
        Private _MyObjectDefinitionAvailableOptions As System.Data.Objects.ObjectSet(Of Database.Entities.MyObjectDefinitionAvailableOption) = Nothing
        Private _MyObjectDefinitionObjects As System.Data.Objects.ObjectSet(Of Database.Entities.MyObjectDefinitionObject) = Nothing
        Private _MyObjectDefinitionSettings As System.Data.Objects.ObjectSet(Of Database.Entities.MyObjectDefinitionSetting) = Nothing
        Private _MyObjectDefinitionStaticOptions As System.Data.Objects.ObjectSet(Of Database.Entities.MyObjectDefinitionStaticOption) = Nothing
        Private _NewspaperDetails As System.Data.Objects.ObjectSet(Of Database.Views.NewspaperDetail) = Nothing
        Private _NewspaperHeaders As System.Data.Objects.ObjectSet(Of Database.Views.NewspaperHeader) = Nothing
        Private _NewspaperOrderDetails As System.Data.Objects.ObjectSet(Of Database.Entities.NewspaperOrderDetail) = Nothing
        Private _NewspaperOrders As System.Data.Objects.ObjectSet(Of Database.Entities.NewspaperOrder) = Nothing
        Private _OfficeDocuments As System.Data.Objects.ObjectSet(Of Database.Entities.OfficeDocument) = Nothing
        Private _OfficeFunctionAccounts As System.Data.Objects.ObjectSet(Of Database.Entities.OfficeFunctionAccount) = Nothing
        Private _OfficeInterCompanies As System.Data.Objects.ObjectSet(Of Database.Entities.OfficeInterCompany) = Nothing
        Private _Offices As System.Data.Objects.ObjectSet(Of Database.Entities.Office) = Nothing
        Private _OfficeSalesClassAccounts As System.Data.Objects.ObjectSet(Of Database.Entities.OfficeSalesClassAccount) = Nothing
        Private _OfficeSalesClassFunctionAccounts As System.Data.Objects.ObjectSet(Of Database.Entities.OfficeSalesClassFunctionAccount) = Nothing
        Private _OfficeSalesTaxAccounts As System.Data.Objects.ObjectSet(Of Database.Entities.OfficeSalesTaxAccount) = Nothing
        Private _OtherCashReceiptDetails As System.Data.Objects.ObjectSet(Of Database.Entities.OtherCashReceiptDetail) = Nothing
        Private _OtherCashReceipts As System.Data.Objects.ObjectSet(Of Database.Entities.OtherCashReceipt) = Nothing
        Private _OutOfHomeOrderDetails As System.Data.Objects.ObjectSet(Of Database.Entities.OutOfHomeOrderDetail) = Nothing
        Private _OutOfHomeOrders As System.Data.Objects.ObjectSet(Of Database.Entities.OutOfHomeOrder) = Nothing
        Private _OutOfHomeTypes As System.Data.Objects.ObjectSet(Of Database.Entities.OutOfHomeType) = Nothing
        Private _OverheadAccounts As System.Data.Objects.ObjectSet(Of Database.Entities.OverheadAccount) = Nothing
        Private _PartnerAllocationDetails As System.Data.Objects.ObjectSet(Of Database.Entities.PartnerAllocationDetail) = Nothing
        Private _PartnerAllocations As System.Data.Objects.ObjectSet(Of Database.Entities.PartnerAllocation) = Nothing
        Private _Partners As System.Data.Objects.ObjectSet(Of Database.Entities.Partner) = Nothing
        Private _Phases As System.Data.Objects.ObjectSet(Of Database.Entities.Phase) = Nothing
        Private _POApprovals As System.Data.Objects.ObjectSet(Of Database.Entities.POApproval) = Nothing
        Private _PostPeriods As System.Data.Objects.ObjectSet(Of Database.Entities.PostPeriod) = Nothing
        Private _PrintImportCrossReferences As System.Data.Objects.ObjectSet(Of Database.Entities.PrintImportCrossReference) = Nothing
        Private _PrintSpecRegions As System.Data.Objects.ObjectSet(Of Database.Entities.PrintSpecRegion) = Nothing
        Private _PrintSpecStatuses As System.Data.Objects.ObjectSet(Of Database.Entities.PrintSpecStatus) = Nothing
        Private _ProductAccountsReceivableStatements As System.Data.Objects.ObjectSet(Of Database.Entities.ProductAccountsReceivableStatement) = Nothing
        Private _ProductCategories As System.Data.Objects.ObjectSet(Of Database.Entities.ProductCategory) = Nothing
        Private _ProductionInvoiceDefaults As System.Data.Objects.ObjectSet(Of Database.Entities.ProductionInvoiceDefault) = Nothing
        Private _Products As System.Data.Objects.ObjectSet(Of Database.Entities.Product) = Nothing
        Private _ProductSortKeys As System.Data.Objects.ObjectSet(Of Database.Entities.ProductSortKey) = Nothing
        Private _ProductViews As System.Data.Objects.ObjectSet(Of Database.Views.ProductView) = Nothing
        Private _PromotionTypes As System.Data.Objects.ObjectSet(Of Database.Entities.PromotionType) = Nothing
        Private _PTORuleDetails As System.Data.Objects.ObjectSet(Of Database.Entities.PTORuleDetail) = Nothing
        Private _PTORules As System.Data.Objects.ObjectSet(Of Database.Entities.PTORule) = Nothing
        Private _PurchaseOrderApprovalRuleDetails As System.Data.Objects.ObjectSet(Of Database.Entities.PurchaseOrderApprovalRuleDetail) = Nothing
        Private _PurchaseOrderApprovalRuleEmployees As System.Data.Objects.ObjectSet(Of Database.Entities.PurchaseOrderApprovalRuleEmployee) = Nothing
        Private _PurchaseOrderApprovalRules As System.Data.Objects.ObjectSet(Of Database.Entities.PurchaseOrderApprovalRule) = Nothing
        Private _PurchaseOrderDetails As System.Data.Objects.ObjectSet(Of Database.Entities.PurchaseOrderDetail) = Nothing
        Private _PurchaseOrderPrintDefaults As System.Data.Objects.ObjectSet(Of Database.Entities.PurchaseOrderPrintDefault) = Nothing
        Private _PurchaseOrders As System.Data.Objects.ObjectSet(Of Database.Entities.PurchaseOrder) = Nothing
        Private _RadioOrderDetailLegacies As System.Data.Objects.ObjectSet(Of Database.Entities.RadioOrderDetailLegacy) = Nothing
        Private _RadioOrderDetails As System.Data.Objects.ObjectSet(Of Database.Entities.RadioOrderDetail) = Nothing
        Private _RadioOrderLegacies As System.Data.Objects.ObjectSet(Of Database.Entities.RadioOrderLegacy) = Nothing
        Private _RadioOrders As System.Data.Objects.ObjectSet(Of Database.Entities.RadioOrder) = Nothing
        Private _RateCardColorCharges As System.Data.Objects.ObjectSet(Of Database.Entities.RateCardColorCharge) = Nothing
        Private _RateCardDetails As System.Data.Objects.ObjectSet(Of Database.Entities.RateCardDetail) = Nothing
        Private _RateCards As System.Data.Objects.ObjectSet(Of Database.Entities.RateCard) = Nothing
        Private _Ratings As System.Data.Objects.ObjectSet(Of Database.Entities.Rating) = Nothing
        Private _RecordSources As System.Data.Objects.ObjectSet(Of Database.Entities.RecordSource) = Nothing
        Private _Resources As System.Data.Objects.ObjectSet(Of Database.Entities.Resource) = Nothing
        Private _ResourceTasks As System.Data.Objects.ObjectSet(Of Database.Entities.ResourceTask) = Nothing
        Private _ResourceTypes As System.Data.Objects.ObjectSet(Of Database.Entities.ResourceType) = Nothing
        Private _Roles As System.Data.Objects.ObjectSet(Of Database.Entities.Role) = Nothing
        Private _SalesClasses As System.Data.Objects.ObjectSet(Of Database.Entities.SalesClass) = Nothing
        Private _SalesClassFormats As System.Data.Objects.ObjectSet(Of Database.Entities.SalesClassFormat) = Nothing
        Private _SalesTaxes As System.Data.Objects.ObjectSet(Of Database.Entities.SalesTax) = Nothing
        Private _ServiceFeeReconcileDetails As System.Data.Objects.ObjectSet(Of Database.Views.ServiceFeeReconcileDetail) = Nothing
        Private _ServiceFeeTypes As System.Data.Objects.ObjectSet(Of Database.Entities.ServiceFeeType) = Nothing
        Private _Sources As System.Data.Objects.ObjectSet(Of Database.Entities.Source) = Nothing
        Private _Specialties As System.Data.Objects.ObjectSet(Of Database.Entities.Specialty) = Nothing
        Private _StandardComments As System.Data.Objects.ObjectSet(Of Database.Entities.StandardComment) = Nothing
        Private _Status As System.Data.Objects.ObjectSet(Of Database.Entities.Status) = Nothing
        Private _Tasks As System.Data.Objects.ObjectSet(Of Database.Entities.Task) = Nothing
        Private _TaskTemplates As System.Data.Objects.ObjectSet(Of Database.Entities.TaskTemplate) = Nothing
        Private _TimeCategoryTypes As System.Data.Objects.ObjectSet(Of Database.Entities.TimeCategoryType) = Nothing
        Private _TimeRuleLogs As System.Data.Objects.ObjectSet(Of Database.Entities.TimeRuleLog) = Nothing
        Private _TVOrderDetailLegacies As System.Data.Objects.ObjectSet(Of Database.Entities.TVOrderDetailLegacy) = Nothing
        Private _TVOrderDetails As System.Data.Objects.ObjectSet(Of Database.Entities.TVOrderDetail) = Nothing
        Private _TVOrderLegacies As System.Data.Objects.ObjectSet(Of Database.Entities.TVOrderLegacy) = Nothing
        Private _TVOrders As System.Data.Objects.ObjectSet(Of Database.Entities.TVOrder) = Nothing
        Private _UserDefinedLabel As System.Data.Objects.ObjectSet(Of Database.Entities.UserDefinedLabel) = Nothing
        Private _UserDefinedTypes As System.Data.Objects.ObjectSet(Of Database.Entities.UserDefinedType) = Nothing
        Private _UserDefinedTypeValues As System.Data.Objects.ObjectSet(Of Database.Entities.UserDefinedTypeValue) = Nothing
        Private _VendorComments As System.Data.Objects.ObjectSet(Of Database.Entities.VendorComment) = Nothing
        Private _VendorContacts As System.Data.Objects.ObjectSet(Of Database.Entities.VendorContact) = Nothing
        Private _VendorCrossReferences As System.Data.Objects.ObjectSet(Of Database.Entities.VendorCrossReference) = Nothing
        Private _VendorHistorys As System.Data.Objects.ObjectSet(Of Database.Entities.VendorHistory) = Nothing
        Private _VendorInvoiceAlerts As System.Data.Objects.ObjectSet(Of Database.Views.VendorInvoiceAlert) = Nothing
        Private _VendorInvoiceDetails As System.Data.Objects.ObjectSet(Of Database.Views.VendorInvoiceDetail) = Nothing
        Private _VendorInvoices As System.Data.Objects.ObjectSet(Of Database.Views.VendorInvoice) = Nothing
        Private _VendorPricings As System.Data.Objects.ObjectSet(Of Database.Entities.VendorPricing) = Nothing
        Private _Vendors As System.Data.Objects.ObjectSet(Of Database.Entities.Vendor) = Nothing
        Private _VendorSortKeys As System.Data.Objects.ObjectSet(Of Database.Entities.VendorSortKey) = Nothing
        Private _VendorTerms As System.Data.Objects.ObjectSet(Of Database.Entities.VendorTerm) = Nothing
        Private _WebsiteTypes As System.Data.Objects.ObjectSet(Of Database.Entities.WebsiteType) = Nothing
        Private _WorkflowAlertStates As System.Data.Objects.ObjectSet(Of Database.Entities.WorkflowAlertState) = Nothing
        Private _Workflows1 As System.Data.Objects.ObjectSet(Of Database.Entities.Workflow) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property AccountExecutives() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountExecutive)
            Get

                If _AccountExecutives Is Nothing Then

                    _AccountExecutives = MyBase.CreateObjectSet(Of Database.Entities.AccountExecutive)(Database.ObjectContext.Properties.AccountExecutives.ToString)

                End If

                AccountExecutives = _AccountExecutives

            End Get
        End Property
        Public ReadOnly Property AccountGroupDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountGroupDetail)
            Get

                If _AccountGroupDetails Is Nothing Then

                    _AccountGroupDetails = MyBase.CreateObjectSet(Of Database.Entities.AccountGroupDetail)(Database.ObjectContext.Properties.AccountGroupDetails.ToString)

                End If

                AccountGroupDetails = _AccountGroupDetails

            End Get
        End Property
        Public ReadOnly Property AccountGroups() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountGroup)
            Get

                If _AccountGroups Is Nothing Then

                    _AccountGroups = MyBase.CreateObjectSet(Of Database.Entities.AccountGroup)(Database.ObjectContext.Properties.AccountGroups.ToString)

                End If

                AccountGroups = _AccountGroups

            End Get
        End Property
        Public ReadOnly Property AccountPayableGLDistributions() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableGLDistribution)
            Get

                If _AccountPayableGLDistributions Is Nothing Then

                    _AccountPayableGLDistributions = MyBase.CreateObjectSet(Of Database.Entities.AccountPayableGLDistribution)(Database.ObjectContext.Properties.AccountPayableGLDistributions.ToString)

                End If

                AccountPayableGLDistributions = _AccountPayableGLDistributions

            End Get
        End Property
        Public ReadOnly Property AccountPayableInternets() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableInternet)
            Get

                If _AccountPayableInternets Is Nothing Then

                    _AccountPayableInternets = MyBase.CreateObjectSet(Of Database.Entities.AccountPayableInternet)(Database.ObjectContext.Properties.AccountPayableInternets.ToString)

                End If

                AccountPayableInternets = _AccountPayableInternets

            End Get
        End Property
        Public ReadOnly Property AccountPayableMagazines() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableMagazine)
            Get

                If _AccountPayableMagazines Is Nothing Then

                    _AccountPayableMagazines = MyBase.CreateObjectSet(Of Database.Entities.AccountPayableMagazine)(Database.ObjectContext.Properties.AccountPayableMagazines.ToString)

                End If

                AccountPayableMagazines = _AccountPayableMagazines

            End Get
        End Property
        Public ReadOnly Property AccountPayableMediaApprovals() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableMediaApproval)
            Get

                If _AccountPayableMediaApprovals Is Nothing Then

                    _AccountPayableMediaApprovals = MyBase.CreateObjectSet(Of Database.Entities.AccountPayableMediaApproval)(Database.ObjectContext.Properties.AccountPayableMediaApprovals.ToString)

                End If

                AccountPayableMediaApprovals = _AccountPayableMediaApprovals

            End Get
        End Property
        Public ReadOnly Property AccountPayableNewspapers() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableNewspaper)
            Get

                If _AccountPayableNewspapers Is Nothing Then

                    _AccountPayableNewspapers = MyBase.CreateObjectSet(Of Database.Entities.AccountPayableNewspaper)(Database.ObjectContext.Properties.AccountPayableNewspapers.ToString)

                End If

                AccountPayableNewspapers = _AccountPayableNewspapers

            End Get
        End Property
        Public ReadOnly Property AccountPayableOutOfHomes() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableOutOfHome)
            Get

                If _AccountPayableOutOfHomes Is Nothing Then

                    _AccountPayableOutOfHomes = MyBase.CreateObjectSet(Of Database.Entities.AccountPayableOutOfHome)(Database.ObjectContext.Properties.AccountPayableOutOfHomes.ToString)

                End If

                AccountPayableOutOfHomes = _AccountPayableOutOfHomes

            End Get
        End Property
        Public ReadOnly Property AccountPayablePayments() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayablePayment)
            Get

                If _AccountPayablePayments Is Nothing Then

                    _AccountPayablePayments = MyBase.CreateObjectSet(Of Database.Entities.AccountPayablePayment)(Database.ObjectContext.Properties.AccountPayablePayments.ToString)

                End If

                AccountPayablePayments = _AccountPayablePayments

            End Get
        End Property
        Public ReadOnly Property AccountPayableProductionComments() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableProductionComment)
            Get

                If _AccountPayableProductionComments Is Nothing Then

                    _AccountPayableProductionComments = MyBase.CreateObjectSet(Of Database.Entities.AccountPayableProductionComment)(Database.ObjectContext.Properties.AccountPayableProductionComments.ToString)

                End If

                AccountPayableProductionComments = _AccountPayableProductionComments

            End Get
        End Property
        Public ReadOnly Property AccountPayableProductions() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableProduction)
            Get

                If _AccountPayableProductions Is Nothing Then

                    _AccountPayableProductions = MyBase.CreateObjectSet(Of Database.Entities.AccountPayableProduction)(Database.ObjectContext.Properties.AccountPayableProductions.ToString)

                End If

                AccountPayableProductions = _AccountPayableProductions

            End Get
        End Property
        Public ReadOnly Property AccountPayableRadios() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableRadio)
            Get

                If _AccountPayableRadios Is Nothing Then

                    _AccountPayableRadios = MyBase.CreateObjectSet(Of Database.Entities.AccountPayableRadio)(Database.ObjectContext.Properties.AccountPayableRadios.ToString)

                End If

                AccountPayableRadios = _AccountPayableRadios

            End Get
        End Property
        Public ReadOnly Property AccountPayableRecurGeneralLedgers() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableRecurGeneralLedger)
            Get

                If _AccountPayableRecurGeneralLedgers Is Nothing Then

                    _AccountPayableRecurGeneralLedgers = MyBase.CreateObjectSet(Of Database.Entities.AccountPayableRecurGeneralLedger)(Database.ObjectContext.Properties.AccountPayableRecurGeneralLedgers.ToString)

                End If

                AccountPayableRecurGeneralLedgers = _AccountPayableRecurGeneralLedgers

            End Get
        End Property
        Public ReadOnly Property AccountPayableRecurLogs() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableRecurLog)
            Get

                If _AccountPayableRecurLogs Is Nothing Then

                    _AccountPayableRecurLogs = MyBase.CreateObjectSet(Of Database.Entities.AccountPayableRecurLog)(Database.ObjectContext.Properties.AccountPayableRecurLogs.ToString)

                End If

                AccountPayableRecurLogs = _AccountPayableRecurLogs

            End Get
        End Property
        Public ReadOnly Property AccountPayableRecurs() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableRecur)
            Get

                If _AccountPayableRecurs Is Nothing Then

                    _AccountPayableRecurs = MyBase.CreateObjectSet(Of Database.Entities.AccountPayableRecur)(Database.ObjectContext.Properties.AccountPayableRecurs.ToString)

                End If

                AccountPayableRecurs = _AccountPayableRecurs

            End Get
        End Property
        Public ReadOnly Property AccountPayables() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayable)
            Get

                If _AccountPayables Is Nothing Then

                    _AccountPayables = MyBase.CreateObjectSet(Of Database.Entities.AccountPayable)(Database.ObjectContext.Properties.AccountPayables.ToString)

                End If

                AccountPayables = _AccountPayables

            End Get
        End Property
        Public ReadOnly Property AccountPayableTVs() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountPayableTV)
            Get

                If _AccountPayableTVs Is Nothing Then

                    _AccountPayableTVs = MyBase.CreateObjectSet(Of Database.Entities.AccountPayableTV)(Database.ObjectContext.Properties.AccountPayableTVs.ToString)

                End If

                AccountPayableTVs = _AccountPayableTVs

            End Get
        End Property
        Public ReadOnly Property AccountPayableViews() As System.Data.Objects.ObjectSet(Of Database.Views.AccountPayableView)
            Get

                If _AccountPayableViews Is Nothing Then

                    _AccountPayableViews = MyBase.CreateObjectSet(Of Database.Views.AccountPayableView)(Database.ObjectContext.Properties.AccountPayableViews.ToString)

                End If

                AccountPayableViews = _AccountPayableViews

            End Get
        End Property
        Public ReadOnly Property AccountReceivableCollectionNotes() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountReceivableCollectionNote)
            Get

                If _AccountReceivableCollectionNotes Is Nothing Then

                    _AccountReceivableCollectionNotes = MyBase.CreateObjectSet(Of Database.Entities.AccountReceivableCollectionNote)(Database.ObjectContext.Properties.AccountReceivableCollectionNotes.ToString)

                End If

                AccountReceivableCollectionNotes = _AccountReceivableCollectionNotes

            End Get
        End Property
        Public ReadOnly Property AccountReceivableDocuments() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountReceivableDocument)
            Get

                If _AccountReceivableDocuments Is Nothing Then

                    _AccountReceivableDocuments = MyBase.CreateObjectSet(Of Database.Entities.AccountReceivableDocument)(Database.ObjectContext.Properties.AccountReceivableDocuments.ToString)

                End If

                AccountReceivableDocuments = _AccountReceivableDocuments

            End Get
        End Property
        Public ReadOnly Property AccountReceivableImportStagings() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountReceivableImportStaging)
            Get

                If _AccountReceivableImportStagings Is Nothing Then

                    _AccountReceivableImportStagings = MyBase.CreateObjectSet(Of Database.Entities.AccountReceivableImportStaging)(Database.ObjectContext.Properties.AccountReceivableImportStagings.ToString)

                End If

                AccountReceivableImportStagings = _AccountReceivableImportStagings

            End Get
        End Property
        Public ReadOnly Property AccountReceivables() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountReceivable)
            Get

                If _AccountReceivables Is Nothing Then

                    _AccountReceivables = MyBase.CreateObjectSet(Of Database.Entities.AccountReceivable)(Database.ObjectContext.Properties.AccountReceivables.ToString)

                End If

                AccountReceivables = _AccountReceivables

            End Get
        End Property
        Public ReadOnly Property AccountReceivableSummaries() As System.Data.Objects.ObjectSet(Of Database.Entities.AccountReceivableSummary)
            Get

                If _AccountReceivableSummaries Is Nothing Then

                    _AccountReceivableSummaries = MyBase.CreateObjectSet(Of Database.Entities.AccountReceivableSummary)(Database.ObjectContext.Properties.AccountReceivableSummaries.ToString)

                End If

                AccountReceivableSummaries = _AccountReceivableSummaries

            End Get
        End Property
        Public ReadOnly Property AccountReceivableViews() As System.Data.Objects.ObjectSet(Of Database.Views.AccountReceivableView)
            Get

                If _AccountReceivableViews Is Nothing Then

                    _AccountReceivableViews = MyBase.CreateObjectSet(Of Database.Views.AccountReceivableView)(Database.ObjectContext.Properties.AccountReceivableViews.ToString)

                End If

                AccountReceivableViews = _AccountReceivableViews

            End Get
        End Property
        Public ReadOnly Property Accounts() As System.Data.Objects.ObjectSet(Of Database.Entities.Account)
            Get

                If _Accounts Is Nothing Then

                    _Accounts = MyBase.CreateObjectSet(Of Database.Entities.Account)(Database.ObjectContext.Properties.Accounts.ToString)

                End If

                Accounts = _Accounts

            End Get
        End Property
        Public ReadOnly Property Activities() As System.Data.Objects.ObjectSet(Of Database.Entities.Activity)
            Get

                If _Activities Is Nothing Then

                    _Activities = MyBase.CreateObjectSet(Of Database.Entities.Activity)(Database.ObjectContext.Properties.Activities.ToString)

                End If

                Activities = _Activities

            End Get
        End Property
        Public ReadOnly Property ActivityCompetitions() As System.Data.Objects.ObjectSet(Of Database.Entities.ActivityCompetition)
            Get

                If _ActivityCompetitions Is Nothing Then

                    _ActivityCompetitions = MyBase.CreateObjectSet(Of Database.Entities.ActivityCompetition)(Database.ObjectContext.Properties.ActivityCompetitions.ToString)

                End If

                ActivityCompetitions = _ActivityCompetitions

            End Get
        End Property
        Public ReadOnly Property Ads() As System.Data.Objects.ObjectSet(Of Database.Entities.Ad)
            Get

                If _Ads Is Nothing Then

                    _Ads = MyBase.CreateObjectSet(Of Database.Entities.Ad)(Database.ObjectContext.Properties.Ads.ToString)

                End If

                Ads = _Ads

            End Get
        End Property
        Public ReadOnly Property AdSizeLabels() As System.Data.Objects.ObjectSet(Of Database.Entities.AdSizeLabel)
            Get

                If _AdSizeLabels Is Nothing Then

                    _AdSizeLabels = MyBase.CreateObjectSet(Of Database.Entities.AdSizeLabel)(Database.ObjectContext.Properties.AdSizeLabels.ToString)

                End If

                AdSizeLabels = _AdSizeLabels

            End Get
        End Property
        Public ReadOnly Property AdSizes() As System.Data.Objects.ObjectSet(Of Database.Entities.AdSize)
            Get

                If _AdSizes Is Nothing Then

                    _AdSizes = MyBase.CreateObjectSet(Of Database.Entities.AdSize)(Database.ObjectContext.Properties.AdSizes.ToString)

                End If

                AdSizes = _AdSizes

            End Get
        End Property
        Public ReadOnly Property AdvantageServiceExports() As System.Data.Objects.ObjectSet(Of Database.Entities.AdvantageServiceExport)
            Get

                If _AdvantageServiceExports Is Nothing Then

                    _AdvantageServiceExports = MyBase.CreateObjectSet(Of Database.Entities.AdvantageServiceExport)(Database.ObjectContext.Properties.AdvantageServiceExports.ToString)

                End If

                AdvantageServiceExports = _AdvantageServiceExports

            End Get
        End Property
        Public ReadOnly Property AdvantageServiceImports() As System.Data.Objects.ObjectSet(Of Database.Entities.AdvantageServiceImport)
            Get

                If _AdvantageServiceImports Is Nothing Then

                    _AdvantageServiceImports = MyBase.CreateObjectSet(Of Database.Entities.AdvantageServiceImport)(Database.ObjectContext.Properties.AdvantageServiceImports.ToString)

                End If

                AdvantageServiceImports = _AdvantageServiceImports

            End Get
        End Property
        Public ReadOnly Property Affiliations() As System.Data.Objects.ObjectSet(Of Database.Entities.Affiliation)
            Get

                If _Affiliations Is Nothing Then

                    _Affiliations = MyBase.CreateObjectSet(Of Database.Entities.Affiliation)(Database.ObjectContext.Properties.Affiliations.ToString)

                End If

                Affiliations = _Affiliations

            End Get
        End Property
        Public ReadOnly Property Agencies() As System.Data.Objects.ObjectSet(Of Database.Entities.Agency)
            Get

                If _Agencies Is Nothing Then

                    _Agencies = MyBase.CreateObjectSet(Of Database.Entities.Agency)(Database.ObjectContext.Properties.Agencies.ToString)

                End If

                Agencies = _Agencies

            End Get
        End Property
        Public ReadOnly Property AgencyClients() As System.Data.Objects.ObjectSet(Of Database.Entities.AgencyClient)
            Get

                If _AgencyClients Is Nothing Then

                    _AgencyClients = MyBase.CreateObjectSet(Of Database.Entities.AgencyClient)(Database.ObjectContext.Properties.AgencyClients.ToString)

                End If

                AgencyClients = _AgencyClients

            End Get
        End Property
        Public ReadOnly Property AgencyComments() As System.Data.Objects.ObjectSet(Of Database.Entities.AgencyComment)
            Get

                If _AgencyComments Is Nothing Then

                    _AgencyComments = MyBase.CreateObjectSet(Of Database.Entities.AgencyComment)(Database.ObjectContext.Properties.AgencyComments.ToString)

                End If

                AgencyComments = _AgencyComments

            End Get
        End Property
        Public ReadOnly Property AgencyDesktopDocuments() As System.Data.Objects.ObjectSet(Of Database.Entities.AgencyDesktopDocument)
            Get

                If _AgencyDesktopDocuments Is Nothing Then

                    _AgencyDesktopDocuments = MyBase.CreateObjectSet(Of Database.Entities.AgencyDesktopDocument)(Database.ObjectContext.Properties.AgencyDesktopDocuments.ToString)

                End If

                AgencyDesktopDocuments = _AgencyDesktopDocuments

            End Get
        End Property
        Public ReadOnly Property AlertAssignmentTemplateDepartmentTeams() As System.Data.Objects.ObjectSet(Of Database.Entities.AlertAssignmentTemplateDepartmentTeam)
            Get

                If _AlertAssignmentTemplateDepartmentTeams Is Nothing Then

                    _AlertAssignmentTemplateDepartmentTeams = MyBase.CreateObjectSet(Of Database.Entities.AlertAssignmentTemplateDepartmentTeam)(Database.ObjectContext.Properties.AlertAssignmentTemplateDepartmentTeams.ToString)

                End If

                AlertAssignmentTemplateDepartmentTeams = _AlertAssignmentTemplateDepartmentTeams

            End Get
        End Property
        Public ReadOnly Property AlertAssignmentTemplateEmailGroups() As System.Data.Objects.ObjectSet(Of Database.Entities.AlertAssignmentTemplateEmailGroup)
            Get

                If _AlertAssignmentTemplateEmailGroups Is Nothing Then

                    _AlertAssignmentTemplateEmailGroups = MyBase.CreateObjectSet(Of Database.Entities.AlertAssignmentTemplateEmailGroup)(Database.ObjectContext.Properties.AlertAssignmentTemplateEmailGroups.ToString)

                End If

                AlertAssignmentTemplateEmailGroups = _AlertAssignmentTemplateEmailGroups

            End Get
        End Property
        Public ReadOnly Property AlertAssignmentTemplateEmployees() As System.Data.Objects.ObjectSet(Of Database.Entities.AlertAssignmentTemplateEmployee)
            Get

                If _AlertAssignmentTemplateEmployees Is Nothing Then

                    _AlertAssignmentTemplateEmployees = MyBase.CreateObjectSet(Of Database.Entities.AlertAssignmentTemplateEmployee)(Database.ObjectContext.Properties.AlertAssignmentTemplateEmployees.ToString)

                End If

                AlertAssignmentTemplateEmployees = _AlertAssignmentTemplateEmployees

            End Get
        End Property
        Public ReadOnly Property AlertAssignmentTemplateRoles() As System.Data.Objects.ObjectSet(Of Database.Entities.AlertAssignmentTemplateRole)
            Get

                If _AlertAssignmentTemplateRoles Is Nothing Then

                    _AlertAssignmentTemplateRoles = MyBase.CreateObjectSet(Of Database.Entities.AlertAssignmentTemplateRole)(Database.ObjectContext.Properties.AlertAssignmentTemplateRoles.ToString)

                End If

                AlertAssignmentTemplateRoles = _AlertAssignmentTemplateRoles

            End Get
        End Property
        Public ReadOnly Property AlertAssignmentTemplates() As System.Data.Objects.ObjectSet(Of Database.Entities.AlertAssignmentTemplate)
            Get

                If _AlertAssignmentTemplates Is Nothing Then

                    _AlertAssignmentTemplates = MyBase.CreateObjectSet(Of Database.Entities.AlertAssignmentTemplate)(Database.ObjectContext.Properties.AlertAssignmentTemplates.ToString)

                End If

                AlertAssignmentTemplates = _AlertAssignmentTemplates

            End Get
        End Property
        Public ReadOnly Property AlertAssignmentTemplateStates() As System.Data.Objects.ObjectSet(Of Database.Entities.AlertAssignmentTemplateState)
            Get

                If _AlertAssignmentTemplateStates Is Nothing Then

                    _AlertAssignmentTemplateStates = MyBase.CreateObjectSet(Of Database.Entities.AlertAssignmentTemplateState)(Database.ObjectContext.Properties.AlertAssignmentTemplateStates.ToString)

                End If

                AlertAssignmentTemplateStates = _AlertAssignmentTemplateStates

            End Get
        End Property
        Public ReadOnly Property AlertAttachments() As System.Data.Objects.ObjectSet(Of Database.Entities.AlertAttachment)
            Get

                If _AlertAttachments Is Nothing Then

                    _AlertAttachments = MyBase.CreateObjectSet(Of Database.Entities.AlertAttachment)(Database.ObjectContext.Properties.AlertAttachments.ToString)

                End If

                AlertAttachments = _AlertAttachments

            End Get
        End Property
        Public ReadOnly Property AlertAttachmentViews() As System.Data.Objects.ObjectSet(Of Database.Views.AlertAttachmentView)
            Get

                If _AlertAttachmentViews Is Nothing Then

                    _AlertAttachmentViews = MyBase.CreateObjectSet(Of Database.Views.AlertAttachmentView)(Database.ObjectContext.Properties.AlertAttachmentViews.ToString)

                End If

                AlertAttachmentViews = _AlertAttachmentViews

            End Get
        End Property
        Public ReadOnly Property AlertCategories() As System.Data.Objects.ObjectSet(Of Database.Entities.AlertCategory)
            Get

                If _AlertCategories Is Nothing Then

                    _AlertCategories = MyBase.CreateObjectSet(Of Database.Entities.AlertCategory)(Database.ObjectContext.Properties.AlertCategories.ToString)

                End If

                AlertCategories = _AlertCategories

            End Get
        End Property
        Public ReadOnly Property AlertComments() As System.Data.Objects.ObjectSet(Of Database.Entities.AlertComment)
            Get

                If _AlertComments Is Nothing Then

                    _AlertComments = MyBase.CreateObjectSet(Of Database.Entities.AlertComment)(Database.ObjectContext.Properties.AlertComments.ToString)

                End If

                AlertComments = _AlertComments

            End Get
        End Property
        Public ReadOnly Property AlertDocumentKeywords() As System.Data.Objects.ObjectSet(Of Database.Entities.AlertDocumentKeyword)
            Get

                If _AlertDocumentKeywords Is Nothing Then

                    _AlertDocumentKeywords = MyBase.CreateObjectSet(Of Database.Entities.AlertDocumentKeyword)(Database.ObjectContext.Properties.AlertDocumentKeywords.ToString)

                End If

                AlertDocumentKeywords = _AlertDocumentKeywords

            End Get
        End Property
        Public ReadOnly Property AlertDocuments() As System.Data.Objects.ObjectSet(Of Database.Entities.AlertDocument)
            Get

                If _AlertDocuments Is Nothing Then

                    _AlertDocuments = MyBase.CreateObjectSet(Of Database.Entities.AlertDocument)(Database.ObjectContext.Properties.AlertDocuments.ToString)

                End If

                AlertDocuments = _AlertDocuments

            End Get
        End Property
        Public ReadOnly Property AlertGroupCategories() As System.Data.Objects.ObjectSet(Of Database.Entities.AlertGroupCategory)
            Get

                If _AlertGroupCategories Is Nothing Then

                    _AlertGroupCategories = MyBase.CreateObjectSet(Of Database.Entities.AlertGroupCategory)(Database.ObjectContext.Properties.AlertGroupCategories.ToString)

                End If

                AlertGroupCategories = _AlertGroupCategories

            End Get
        End Property
        Public ReadOnly Property AlertGroups() As System.Data.Objects.ObjectSet(Of Database.Entities.AlertGroup)
            Get

                If _AlertGroups Is Nothing Then

                    _AlertGroups = MyBase.CreateObjectSet(Of Database.Entities.AlertGroup)(Database.ObjectContext.Properties.AlertGroups.ToString)

                End If

                AlertGroups = _AlertGroups

            End Get
        End Property
        Public ReadOnly Property AlertRecipientDismisseds() As System.Data.Objects.ObjectSet(Of Database.Entities.AlertRecipientDismissed)
            Get

                If _AlertRecipientDismisseds Is Nothing Then

                    _AlertRecipientDismisseds = MyBase.CreateObjectSet(Of Database.Entities.AlertRecipientDismissed)(Database.ObjectContext.Properties.AlertRecipientDismisseds.ToString)

                End If

                AlertRecipientDismisseds = _AlertRecipientDismisseds

            End Get
        End Property
        Public ReadOnly Property AlertRecipients() As System.Data.Objects.ObjectSet(Of Database.Entities.AlertRecipient)
            Get

                If _AlertRecipients Is Nothing Then

                    _AlertRecipients = MyBase.CreateObjectSet(Of Database.Entities.AlertRecipient)(Database.ObjectContext.Properties.AlertRecipients.ToString)

                End If

                AlertRecipients = _AlertRecipients

            End Get
        End Property
        Public ReadOnly Property Alerts() As System.Data.Objects.ObjectSet(Of Database.Entities.Alert)
            Get

                If _Alerts Is Nothing Then

                    _Alerts = MyBase.CreateObjectSet(Of Database.Entities.Alert)(Database.ObjectContext.Properties.Alerts.ToString)

                End If

                Alerts = _Alerts

            End Get
        End Property
        Public ReadOnly Property AlertStates() As System.Data.Objects.ObjectSet(Of Database.Entities.AlertState)
            Get

                If _AlertStates Is Nothing Then

                    _AlertStates = MyBase.CreateObjectSet(Of Database.Entities.AlertState)(Database.ObjectContext.Properties.AlertStates.ToString)

                End If

                AlertStates = _AlertStates

            End Get
        End Property
        Public ReadOnly Property AlertTypes() As System.Data.Objects.ObjectSet(Of Database.Entities.AlertType)
            Get

                If _AlertTypes Is Nothing Then

                    _AlertTypes = MyBase.CreateObjectSet(Of Database.Entities.AlertType)(Database.ObjectContext.Properties.AlertTypes.ToString)

                End If

                AlertTypes = _AlertTypes

            End Get
        End Property
        Public ReadOnly Property AlertViews() As System.Data.Objects.ObjectSet(Of Database.Views.AlertView)
            Get

                If _AlertViews Is Nothing Then

                    _AlertViews = MyBase.CreateObjectSet(Of Database.Views.AlertView)(Database.ObjectContext.Properties.AlertViews.ToString)

                End If

                AlertViews = _AlertViews

            End Get
        End Property
        Public ReadOnly Property AppVars() As System.Data.Objects.ObjectSet(Of Database.Entities.AppVars)
            Get

                If _AppVars Is Nothing Then

                    _AppVars = MyBase.CreateObjectSet(Of Database.Entities.AppVars)(Database.ObjectContext.Properties.AppVars.ToString)

                End If

                AppVars = _AppVars

            End Get
        End Property
        Public ReadOnly Property AssignNumbers() As System.Data.Objects.ObjectSet(Of Database.Entities.AssignNumber)
            Get

                If _AssignNumbers Is Nothing Then

                    _AssignNumbers = MyBase.CreateObjectSet(Of Database.Entities.AssignNumber)(Database.ObjectContext.Properties.AssignNumbers.ToString)

                End If

                AssignNumbers = _AssignNumbers

            End Get
        End Property
        Public ReadOnly Property Associates() As System.Data.Objects.ObjectSet(Of Database.Entities.Associate)
            Get

                If _Associates Is Nothing Then

                    _Associates = MyBase.CreateObjectSet(Of Database.Entities.Associate)(Database.ObjectContext.Properties.Associates.ToString)

                End If

                Associates = _Associates

            End Get
        End Property
        Public ReadOnly Property BankExportSpecs() As System.Data.Objects.ObjectSet(Of Database.Entities.BankExportSpec)
            Get

                If _BankExportSpecs Is Nothing Then

                    _BankExportSpecs = MyBase.CreateObjectSet(Of Database.Entities.BankExportSpec)(Database.ObjectContext.Properties.BankExportSpecs.ToString)

                End If

                BankExportSpecs = _BankExportSpecs

            End Get
        End Property
        Public ReadOnly Property Banks() As System.Data.Objects.ObjectSet(Of Database.Entities.Bank)
            Get

                If _Banks Is Nothing Then

                    _Banks = MyBase.CreateObjectSet(Of Database.Entities.Bank)(Database.ObjectContext.Properties.Banks.ToString)

                End If

                Banks = _Banks

            End Get
        End Property
        Public ReadOnly Property BillingCoops() As System.Data.Objects.ObjectSet(Of Database.Entities.BillingCoop)
            Get

                If _BillingCoops Is Nothing Then

                    _BillingCoops = MyBase.CreateObjectSet(Of Database.Entities.BillingCoop)(Database.ObjectContext.Properties.BillingCoops.ToString)

                End If

                BillingCoops = _BillingCoops

            End Get
        End Property
        Public ReadOnly Property BillingRateDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.BillingRateDetail)
            Get

                If _BillingRateDetails Is Nothing Then

                    _BillingRateDetails = MyBase.CreateObjectSet(Of Database.Entities.BillingRateDetail)(Database.ObjectContext.Properties.BillingRateDetails.ToString)

                End If

                BillingRateDetails = _BillingRateDetails

            End Get
        End Property
        Public ReadOnly Property BillingRateDetailViews() As System.Data.Objects.ObjectSet(Of Database.Views.BillingRateDetailView)
            Get

                If _BillingRateDetailViews Is Nothing Then

                    _BillingRateDetailViews = MyBase.CreateObjectSet(Of Database.Views.BillingRateDetailView)(Database.ObjectContext.Properties.BillingRateDetailViews.ToString)

                End If

                BillingRateDetailViews = _BillingRateDetailViews

            End Get
        End Property
        Public ReadOnly Property BillingRateLevels() As System.Data.Objects.ObjectSet(Of Database.Entities.BillingRateLevel)
            Get

                If _BillingRateLevels Is Nothing Then

                    _BillingRateLevels = MyBase.CreateObjectSet(Of Database.Entities.BillingRateLevel)(Database.ObjectContext.Properties.BillingRateLevels.ToString)

                End If

                BillingRateLevels = _BillingRateLevels

            End Get
        End Property
        Public ReadOnly Property Blackplates() As System.Data.Objects.ObjectSet(Of Database.Entities.Blackplate)
            Get

                If _Blackplates Is Nothing Then

                    _Blackplates = MyBase.CreateObjectSet(Of Database.Entities.Blackplate)(Database.ObjectContext.Properties.Blackplates.ToString)

                End If

                Blackplates = _Blackplates

            End Get
        End Property
        Public ReadOnly Property BroadcastImportCrossReferences() As System.Data.Objects.ObjectSet(Of Database.Entities.BroadcastImportCrossReference)
            Get

                If _BroadcastImportCrossReferences Is Nothing Then

                    _BroadcastImportCrossReferences = MyBase.CreateObjectSet(Of Database.Entities.BroadcastImportCrossReference)(Database.ObjectContext.Properties.BroadcastImportCrossReferences.ToString)

                End If

                BroadcastImportCrossReferences = _BroadcastImportCrossReferences

            End Get
        End Property
        Public ReadOnly Property BudgetDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.BudgetDetail)
            Get

                If _BudgetDetails Is Nothing Then

                    _BudgetDetails = MyBase.CreateObjectSet(Of Database.Entities.BudgetDetail)(Database.ObjectContext.Properties.BudgetDetails.ToString)

                End If

                BudgetDetails = _BudgetDetails

            End Get
        End Property
        Public ReadOnly Property Budgets() As System.Data.Objects.ObjectSet(Of Database.Entities.Budget)
            Get

                If _Budgets Is Nothing Then

                    _Budgets = MyBase.CreateObjectSet(Of Database.Entities.Budget)(Database.ObjectContext.Properties.Budgets.ToString)

                End If

                Budgets = _Budgets

            End Get
        End Property
        Public ReadOnly Property CampaignDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.CampaignDetail)
            Get

                If _CampaignDetails Is Nothing Then

                    _CampaignDetails = MyBase.CreateObjectSet(Of Database.Entities.CampaignDetail)(Database.ObjectContext.Properties.CampaignDetails.ToString)

                End If

                CampaignDetails = _CampaignDetails

            End Get
        End Property
        Public ReadOnly Property Campaigns() As System.Data.Objects.ObjectSet(Of Database.Entities.Campaign)
            Get

                If _Campaigns Is Nothing Then

                    _Campaigns = MyBase.CreateObjectSet(Of Database.Entities.Campaign)(Database.ObjectContext.Properties.Campaigns.ToString)

                End If

                Campaigns = _Campaigns

            End Get
        End Property
        Public ReadOnly Property CampaignViews() As System.Data.Objects.ObjectSet(Of Database.Views.CampaignView)
            Get

                If _CampaignViews Is Nothing Then

                    _CampaignViews = MyBase.CreateObjectSet(Of Database.Views.CampaignView)(Database.ObjectContext.Properties.CampaignViews.ToString)

                End If

                CampaignViews = _CampaignViews

            End Get
        End Property
        Public ReadOnly Property CheckRegisters() As System.Data.Objects.ObjectSet(Of Database.Entities.CheckRegister)
            Get

                If _CheckRegisters Is Nothing Then

                    _CheckRegisters = MyBase.CreateObjectSet(Of Database.Entities.CheckRegister)(Database.ObjectContext.Properties.CheckRegisters.ToString)

                End If

                CheckRegisters = _CheckRegisters

            End Get
        End Property
        Public ReadOnly Property CheckWritingSelections() As System.Data.Objects.ObjectSet(Of Database.Entities.CheckWritingSelection)
            Get

                If _CheckWritingSelections Is Nothing Then

                    _CheckWritingSelections = MyBase.CreateObjectSet(Of Database.Entities.CheckWritingSelection)(Database.ObjectContext.Properties.CheckWritingSelections.ToString)

                End If

                CheckWritingSelections = _CheckWritingSelections

            End Get
        End Property
        Public ReadOnly Property ClientAccountsReceivableStatements() As System.Data.Objects.ObjectSet(Of Database.Entities.ClientAccountsReceivableStatement)
            Get

                If _ClientAccountsReceivableStatements Is Nothing Then

                    _ClientAccountsReceivableStatements = MyBase.CreateObjectSet(Of Database.Entities.ClientAccountsReceivableStatement)(Database.ObjectContext.Properties.ClientAccountsReceivableStatements.ToString)

                End If

                ClientAccountsReceivableStatements = _ClientAccountsReceivableStatements

            End Get
        End Property
        Public ReadOnly Property ClientCashReceiptDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.ClientCashReceiptDetail)
            Get

                If _ClientCashReceiptDetails Is Nothing Then

                    _ClientCashReceiptDetails = MyBase.CreateObjectSet(Of Database.Entities.ClientCashReceiptDetail)(Database.ObjectContext.Properties.ClientCashReceiptDetails.ToString)

                End If

                ClientCashReceiptDetails = _ClientCashReceiptDetails

            End Get
        End Property
        Public ReadOnly Property ClientCashReceiptOnAccounts() As System.Data.Objects.ObjectSet(Of Database.Entities.ClientCashReceiptOnAccount)
            Get

                If _ClientCashReceiptOnAccounts Is Nothing Then

                    _ClientCashReceiptOnAccounts = MyBase.CreateObjectSet(Of Database.Entities.ClientCashReceiptOnAccount)(Database.ObjectContext.Properties.ClientCashReceiptOnAccounts.ToString)

                End If

                ClientCashReceiptOnAccounts = _ClientCashReceiptOnAccounts

            End Get
        End Property
        Public ReadOnly Property ClientCashReceipts() As System.Data.Objects.ObjectSet(Of Database.Entities.ClientCashReceipt)
            Get

                If _ClientCashReceipts Is Nothing Then

                    _ClientCashReceipts = MyBase.CreateObjectSet(Of Database.Entities.ClientCashReceipt)(Database.ObjectContext.Properties.ClientCashReceipts.ToString)

                End If

                ClientCashReceipts = _ClientCashReceipts

            End Get
        End Property
        Public ReadOnly Property ClientContact() As System.Data.Objects.ObjectSet(Of Database.Entities.ClientContact)
            Get

                If _ClientContact Is Nothing Then

                    _ClientContact = MyBase.CreateObjectSet(Of Database.Entities.ClientContact)(Database.ObjectContext.Properties.ClientContact.ToString)

                End If

                ClientContact = _ClientContact

            End Get
        End Property
        Public ReadOnly Property ClientContactDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.ClientContactDetail)
            Get

                If _ClientContactDetails Is Nothing Then

                    _ClientContactDetails = MyBase.CreateObjectSet(Of Database.Entities.ClientContactDetail)(Database.ObjectContext.Properties.ClientContactDetails.ToString)

                End If

                ClientContactDetails = _ClientContactDetails

            End Get
        End Property
        Public ReadOnly Property ClientCrossReferences() As System.Data.Objects.ObjectSet(Of Database.Entities.ClientCrossReference)
            Get

                If _ClientCrossReferences Is Nothing Then

                    _ClientCrossReferences = MyBase.CreateObjectSet(Of Database.Entities.ClientCrossReference)(Database.ObjectContext.Properties.ClientCrossReferences.ToString)

                End If

                ClientCrossReferences = _ClientCrossReferences

            End Get
        End Property
        Public ReadOnly Property ClientPortalAlertRecipientDismisseds() As System.Data.Objects.ObjectSet(Of Database.Entities.ClientPortalAlertRecipientDismissed)
            Get

                If _ClientPortalAlertRecipientDismisseds Is Nothing Then

                    _ClientPortalAlertRecipientDismisseds = MyBase.CreateObjectSet(Of Database.Entities.ClientPortalAlertRecipientDismissed)(Database.ObjectContext.Properties.ClientPortalAlertRecipientDismisseds.ToString)

                End If

                ClientPortalAlertRecipientDismisseds = _ClientPortalAlertRecipientDismisseds

            End Get
        End Property
        Public ReadOnly Property ClientPortalAlertRecipients() As System.Data.Objects.ObjectSet(Of Database.Entities.ClientPortalAlertRecipient)
            Get

                If _ClientPortalAlertRecipients Is Nothing Then

                    _ClientPortalAlertRecipients = MyBase.CreateObjectSet(Of Database.Entities.ClientPortalAlertRecipient)(Database.ObjectContext.Properties.ClientPortalAlertRecipients.ToString)

                End If

                ClientPortalAlertRecipients = _ClientPortalAlertRecipients

            End Get
        End Property
        Public ReadOnly Property ClientPortalAlertViews() As System.Data.Objects.ObjectSet(Of Database.Views.ClientPortalAlertView)
            Get

                If _ClientPortalAlertViews Is Nothing Then

                    _ClientPortalAlertViews = MyBase.CreateObjectSet(Of Database.Views.ClientPortalAlertView)(Database.ObjectContext.Properties.ClientPortalAlertViews.ToString)

                End If

                ClientPortalAlertViews = _ClientPortalAlertViews

            End Get
        End Property
        Public ReadOnly Property Clients() As System.Data.Objects.ObjectSet(Of Database.Entities.Client)
            Get

                If _Clients Is Nothing Then

                    _Clients = MyBase.CreateObjectSet(Of Database.Entities.Client)(Database.ObjectContext.Properties.Clients.ToString)

                End If

                Clients = _Clients

            End Get
        End Property
        Public ReadOnly Property ClientSortKeys() As System.Data.Objects.ObjectSet(Of Database.Entities.ClientSortKey)
            Get

                If _ClientSortKeys Is Nothing Then

                    _ClientSortKeys = MyBase.CreateObjectSet(Of Database.Entities.ClientSortKey)(Database.ObjectContext.Properties.ClientSortKeys.ToString)

                End If

                ClientSortKeys = _ClientSortKeys

            End Get
        End Property
        Public ReadOnly Property ClientWebsites() As System.Data.Objects.ObjectSet(Of Database.Entities.ClientWebsite)
            Get

                If _ClientWebsites Is Nothing Then

                    _ClientWebsites = MyBase.CreateObjectSet(Of Database.Entities.ClientWebsite)(Database.ObjectContext.Properties.ClientWebsites.ToString)

                End If

                ClientWebsites = _ClientWebsites

            End Get
        End Property
        Public ReadOnly Property CompanyProfileAffiliations() As System.Data.Objects.ObjectSet(Of Database.Entities.CompanyProfileAffiliation)
            Get

                If _CompanyProfileAffiliations Is Nothing Then

                    _CompanyProfileAffiliations = MyBase.CreateObjectSet(Of Database.Entities.CompanyProfileAffiliation)(Database.ObjectContext.Properties.CompanyProfileAffiliations.ToString)

                End If

                CompanyProfileAffiliations = _CompanyProfileAffiliations

            End Get
        End Property
        Public ReadOnly Property CompanyProfiles() As System.Data.Objects.ObjectSet(Of Database.Entities.CompanyProfile)
            Get

                If _CompanyProfiles Is Nothing Then

                    _CompanyProfiles = MyBase.CreateObjectSet(Of Database.Entities.CompanyProfile)(Database.ObjectContext.Properties.CompanyProfiles.ToString)

                End If

                CompanyProfiles = _CompanyProfiles

            End Get
        End Property
        Public ReadOnly Property Competitions() As System.Data.Objects.ObjectSet(Of Database.Entities.Competition)
            Get

                If _Competitions Is Nothing Then

                    _Competitions = MyBase.CreateObjectSet(Of Database.Entities.Competition)(Database.ObjectContext.Properties.Competitions.ToString)

                End If

                Competitions = _Competitions

            End Get
        End Property
        Public ReadOnly Property Complexities() As System.Data.Objects.ObjectSet(Of Database.Entities.Complexity)
            Get

                If _Complexities Is Nothing Then

                    _Complexities = MyBase.CreateObjectSet(Of Database.Entities.Complexity)(Database.ObjectContext.Properties.Complexities.ToString)

                End If

                Complexities = _Complexities

            End Get
        End Property
        Public ReadOnly Property ContactTypes() As System.Data.Objects.ObjectSet(Of Database.Entities.ContactType)
            Get

                If _ContactTypes Is Nothing Then

                    _ContactTypes = MyBase.CreateObjectSet(Of Database.Entities.ContactType)(Database.ObjectContext.Properties.ContactTypes.ToString)

                End If

                ContactTypes = _ContactTypes

            End Get
        End Property
        Public ReadOnly Property ContractContacts() As System.Data.Objects.ObjectSet(Of Database.Entities.ContractContact)
            Get

                If _ContractContacts Is Nothing Then

                    _ContractContacts = MyBase.CreateObjectSet(Of Database.Entities.ContractContact)(Database.ObjectContext.Properties.ContractContacts.ToString)

                End If

                ContractContacts = _ContractContacts

            End Get
        End Property
        Public ReadOnly Property ContractDocuments() As System.Data.Objects.ObjectSet(Of Database.Entities.ContractDocument)
            Get

                If _ContractDocuments Is Nothing Then

                    _ContractDocuments = MyBase.CreateObjectSet(Of Database.Entities.ContractDocument)(Database.ObjectContext.Properties.ContractDocuments.ToString)

                End If

                ContractDocuments = _ContractDocuments

            End Get
        End Property
        Public ReadOnly Property ContractFees() As System.Data.Objects.ObjectSet(Of Database.Entities.ContractFee)
            Get

                If _ContractFees Is Nothing Then

                    _ContractFees = MyBase.CreateObjectSet(Of Database.Entities.ContractFee)(Database.ObjectContext.Properties.ContractFees.ToString)

                End If

                ContractFees = _ContractFees

            End Get
        End Property
        Public ReadOnly Property ContractReports() As System.Data.Objects.ObjectSet(Of Database.Entities.ContractReport)
            Get

                If _ContractReports Is Nothing Then

                    _ContractReports = MyBase.CreateObjectSet(Of Database.Entities.ContractReport)(Database.ObjectContext.Properties.ContractReports.ToString)

                End If

                ContractReports = _ContractReports

            End Get
        End Property
        Public ReadOnly Property Contracts() As System.Data.Objects.ObjectSet(Of Database.Entities.Contract)
            Get

                If _Contracts Is Nothing Then

                    _Contracts = MyBase.CreateObjectSet(Of Database.Entities.Contract)(Database.ObjectContext.Properties.Contracts.ToString)

                End If

                Contracts = _Contracts

            End Get
        End Property
        Public ReadOnly Property ContractValueAddeds() As System.Data.Objects.ObjectSet(Of Database.Entities.ContractValueAdded)
            Get

                If _ContractValueAddeds Is Nothing Then

                    _ContractValueAddeds = MyBase.CreateObjectSet(Of Database.Entities.ContractValueAdded)(Database.ObjectContext.Properties.ContractValueAddeds.ToString)

                End If

                ContractValueAddeds = _ContractValueAddeds

            End Get
        End Property
        Public ReadOnly Property CoreMediaCheckExports() As System.Data.Objects.ObjectSet(Of Database.Views.CoreMediaCheckExport)
            Get

                If _CoreMediaCheckExports Is Nothing Then

                    _CoreMediaCheckExports = MyBase.CreateObjectSet(Of Database.Views.CoreMediaCheckExport)(Database.ObjectContext.Properties.CoreMediaCheckExports.ToString)

                End If

                CoreMediaCheckExports = _CoreMediaCheckExports

            End Get
        End Property
        Public ReadOnly Property CreativeBriefDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.CreativeBriefDetail)
            Get

                If _CreativeBriefDetails Is Nothing Then

                    _CreativeBriefDetails = MyBase.CreateObjectSet(Of Database.Entities.CreativeBriefDetail)(Database.ObjectContext.Properties.CreativeBriefDetails.ToString)

                End If

                CreativeBriefDetails = _CreativeBriefDetails

            End Get
        End Property
        Public ReadOnly Property CreativeBriefTemplateLevel1s() As System.Data.Objects.ObjectSet(Of Database.Entities.CreativeBriefTemplateLevel1)
            Get

                If _CreativeBriefTemplateLevel1s Is Nothing Then

                    _CreativeBriefTemplateLevel1s = MyBase.CreateObjectSet(Of Database.Entities.CreativeBriefTemplateLevel1)(Database.ObjectContext.Properties.CreativeBriefTemplateLevel1s.ToString)

                End If

                CreativeBriefTemplateLevel1s = _CreativeBriefTemplateLevel1s

            End Get
        End Property
        Public ReadOnly Property CreativeBriefTemplateLevel2s() As System.Data.Objects.ObjectSet(Of Database.Entities.CreativeBriefTemplateLevel2)
            Get

                If _CreativeBriefTemplateLevel2s Is Nothing Then

                    _CreativeBriefTemplateLevel2s = MyBase.CreateObjectSet(Of Database.Entities.CreativeBriefTemplateLevel2)(Database.ObjectContext.Properties.CreativeBriefTemplateLevel2s.ToString)

                End If

                CreativeBriefTemplateLevel2s = _CreativeBriefTemplateLevel2s

            End Get
        End Property
        Public ReadOnly Property CreativeBriefTemplateLevel3s() As System.Data.Objects.ObjectSet(Of Database.Entities.CreativeBriefTemplateLevel3)
            Get

                If _CreativeBriefTemplateLevel3s Is Nothing Then

                    _CreativeBriefTemplateLevel3s = MyBase.CreateObjectSet(Of Database.Entities.CreativeBriefTemplateLevel3)(Database.ObjectContext.Properties.CreativeBriefTemplateLevel3s.ToString)

                End If

                CreativeBriefTemplateLevel3s = _CreativeBriefTemplateLevel3s

            End Get
        End Property
        Public ReadOnly Property CreativeBriefTemplates() As System.Data.Objects.ObjectSet(Of Database.Entities.CreativeBriefTemplate)
            Get

                If _CreativeBriefTemplates Is Nothing Then

                    _CreativeBriefTemplates = MyBase.CreateObjectSet(Of Database.Entities.CreativeBriefTemplate)(Database.ObjectContext.Properties.CreativeBriefTemplates.ToString)

                End If

                CreativeBriefTemplates = _CreativeBriefTemplates

            End Get
        End Property
        Public ReadOnly Property Currencies() As System.Data.Objects.ObjectSet(Of Database.Entities.Currency)
            Get

                If _Currencies Is Nothing Then

                    _Currencies = MyBase.CreateObjectSet(Of Database.Entities.Currency)(Database.ObjectContext.Properties.Currencies.ToString)

                End If

                Currencies = _Currencies

            End Get
        End Property
        Public ReadOnly Property CurrencyCodes() As System.Data.Objects.ObjectSet(Of Database.Entities.CurrencyCode)
            Get

                If _CurrencyCodes Is Nothing Then

                    _CurrencyCodes = MyBase.CreateObjectSet(Of Database.Entities.CurrencyCode)(Database.ObjectContext.Properties.CurrencyCodes.ToString)

                End If

                CurrencyCodes = _CurrencyCodes

            End Get
        End Property
        Public ReadOnly Property CurrencyDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.CurrencyDetail)
            Get

                If _CurrencyDetails Is Nothing Then

                    _CurrencyDetails = MyBase.CreateObjectSet(Of Database.Entities.CurrencyDetail)(Database.ObjectContext.Properties.CurrencyDetails.ToString)

                End If

                CurrencyDetails = _CurrencyDetails

            End Get
        End Property
        Public ReadOnly Property CurrentJobProcessLogs() As System.Data.Objects.ObjectSet(Of Database.Views.CurrentJobProcessLog)
            Get

                If _CurrentJobProcessLogs Is Nothing Then

                    _CurrentJobProcessLogs = MyBase.CreateObjectSet(Of Database.Views.CurrentJobProcessLog)(Database.ObjectContext.Properties.CurrentJobProcessLogs.ToString)

                End If

                CurrentJobProcessLogs = _CurrentJobProcessLogs

            End Get
        End Property
        Public ReadOnly Property CustomNavigationTabItems() As System.Data.Objects.ObjectSet(Of Database.Entities.CustomNavigationTabItem)
            Get

                If _CustomNavigationTabItems Is Nothing Then

                    _CustomNavigationTabItems = MyBase.CreateObjectSet(Of Database.Entities.CustomNavigationTabItem)(Database.ObjectContext.Properties.CustomNavigationTabItems.ToString)

                End If

                CustomNavigationTabItems = _CustomNavigationTabItems

            End Get
        End Property
        Public ReadOnly Property CustomNavigationTabs() As System.Data.Objects.ObjectSet(Of Database.Entities.CustomNavigationTab)
            Get

                If _CustomNavigationTabs Is Nothing Then

                    _CustomNavigationTabs = MyBase.CreateObjectSet(Of Database.Entities.CustomNavigationTab)(Database.ObjectContext.Properties.CustomNavigationTabs.ToString)

                End If

                CustomNavigationTabs = _CustomNavigationTabs

            End Get
        End Property
        Public ReadOnly Property CustomReports() As System.Data.Objects.ObjectSet(Of Database.Entities.CustomReport)
            Get

                If _CustomReports Is Nothing Then

                    _CustomReports = MyBase.CreateObjectSet(Of Database.Entities.CustomReport)(Database.ObjectContext.Properties.CustomReports.ToString)

                End If

                CustomReports = _CustomReports

            End Get
        End Property
        Public ReadOnly Property Cycles() As System.Data.Objects.ObjectSet(Of Database.Entities.Cycle)
            Get

                If _Cycles Is Nothing Then

                    _Cycles = MyBase.CreateObjectSet(Of Database.Entities.Cycle)(Database.ObjectContext.Properties.Cycles.ToString)

                End If

                Cycles = _Cycles

            End Get
        End Property
        Public ReadOnly Property Dashboards() As System.Data.Objects.ObjectSet(Of Database.Entities.Dashboard)
            Get

                If _Dashboards Is Nothing Then

                    _Dashboards = MyBase.CreateObjectSet(Of Database.Entities.Dashboard)(Database.ObjectContext.Properties.Dashboards.ToString)

                End If

                Dashboards = _Dashboards

            End Get
        End Property
        Public ReadOnly Property DataGridViewColumns() As System.Data.Objects.ObjectSet(Of Database.Entities.DataGridViewColumn)
            Get

                If _DataGridViewColumns Is Nothing Then

                    _DataGridViewColumns = MyBase.CreateObjectSet(Of Database.Entities.DataGridViewColumn)(Database.ObjectContext.Properties.DataGridViewColumns.ToString)

                End If

                DataGridViewColumns = _DataGridViewColumns

            End Get
        End Property
        Public ReadOnly Property DataGridViewColumnUserSettings() As System.Data.Objects.ObjectSet(Of Database.Entities.DataGridViewColumnUserSetting)
            Get

                If _DataGridViewColumnUserSettings Is Nothing Then

                    _DataGridViewColumnUserSettings = MyBase.CreateObjectSet(Of Database.Entities.DataGridViewColumnUserSetting)(Database.ObjectContext.Properties.DataGridViewColumnUserSettings.ToString)

                End If

                DataGridViewColumnUserSettings = _DataGridViewColumnUserSettings

            End Get
        End Property
        Public ReadOnly Property DataGridViews() As System.Data.Objects.ObjectSet(Of Database.Entities.DataGridView)
            Get

                If _DataGridViews Is Nothing Then

                    _DataGridViews = MyBase.CreateObjectSet(Of Database.Entities.DataGridView)(Database.ObjectContext.Properties.DataGridViews.ToString)

                End If

                DataGridViews = _DataGridViews

            End Get
        End Property
        Public ReadOnly Property DaypartTypes() As System.Data.Objects.ObjectSet(Of Database.Entities.DaypartType)
            Get

                If _DaypartTypes Is Nothing Then

                    _DaypartTypes = MyBase.CreateObjectSet(Of Database.Entities.DaypartType)(Database.ObjectContext.Properties.DaypartTypes.ToString)

                End If

                DaypartTypes = _DaypartTypes

            End Get
        End Property
        Public ReadOnly Property Dayparts() As System.Data.Objects.ObjectSet(Of Database.Entities.Daypart)
            Get

                If _Dayparts Is Nothing Then

                    _Dayparts = MyBase.CreateObjectSet(Of Database.Entities.Daypart)(Database.ObjectContext.Properties.Dayparts.ToString)

                End If

                Dayparts = _Dayparts

            End Get
        End Property
        Public ReadOnly Property DepartmentTeams() As System.Data.Objects.ObjectSet(Of Database.Entities.DepartmentTeam)
            Get

                If _DepartmentTeams Is Nothing Then

                    _DepartmentTeams = MyBase.CreateObjectSet(Of Database.Entities.DepartmentTeam)(Database.ObjectContext.Properties.DepartmentTeams.ToString)

                End If

                DepartmentTeams = _DepartmentTeams

            End Get
        End Property
        Public ReadOnly Property DestinationContacts() As System.Data.Objects.ObjectSet(Of Database.Entities.DestinationContact)
            Get

                If _DestinationContacts Is Nothing Then

                    _DestinationContacts = MyBase.CreateObjectSet(Of Database.Entities.DestinationContact)(Database.ObjectContext.Properties.DestinationContacts.ToString)

                End If

                DestinationContacts = _DestinationContacts

            End Get
        End Property
        Public ReadOnly Property Destinations() As System.Data.Objects.ObjectSet(Of Database.Entities.Destination)
            Get

                If _Destinations Is Nothing Then

                    _Destinations = MyBase.CreateObjectSet(Of Database.Entities.Destination)(Database.ObjectContext.Properties.Destinations.ToString)

                End If

                Destinations = _Destinations

            End Get
        End Property
        Public ReadOnly Property DigitalResults() As System.Data.Objects.ObjectSet(Of Database.Entities.DigitalResult)
            Get

                If _DigitalResults Is Nothing Then

                    _DigitalResults = MyBase.CreateObjectSet(Of Database.Entities.DigitalResult)(Database.ObjectContext.Properties.DigitalResults.ToString)

                End If

                DigitalResults = _DigitalResults

            End Get
        End Property
        Public ReadOnly Property Divisions() As System.Data.Objects.ObjectSet(Of Database.Entities.Division)
            Get

                If _Divisions Is Nothing Then

                    _Divisions = MyBase.CreateObjectSet(Of Database.Entities.Division)(Database.ObjectContext.Properties.Divisions.ToString)

                End If

                Divisions = _Divisions

            End Get
        End Property
        Public ReadOnly Property DivisionSortKeys() As System.Data.Objects.ObjectSet(Of Database.Entities.DivisionSortKey)
            Get

                If _DivisionSortKeys Is Nothing Then

                    _DivisionSortKeys = MyBase.CreateObjectSet(Of Database.Entities.DivisionSortKey)(Database.ObjectContext.Properties.DivisionSortKeys.ToString)

                End If

                DivisionSortKeys = _DivisionSortKeys

            End Get
        End Property
        Public ReadOnly Property DivisionViews() As System.Data.Objects.ObjectSet(Of Database.Views.DivisionView)
            Get

                If _DivisionViews Is Nothing Then

                    _DivisionViews = MyBase.CreateObjectSet(Of Database.Views.DivisionView)(Database.ObjectContext.Properties.DivisionViews.ToString)

                End If

                DivisionViews = _DivisionViews

            End Get
        End Property
        Public ReadOnly Property DocumentComments() As System.Data.Objects.ObjectSet(Of Database.Entities.DocumentComment)
            Get

                If _DocumentComments Is Nothing Then

                    _DocumentComments = MyBase.CreateObjectSet(Of Database.Entities.DocumentComment)(Database.ObjectContext.Properties.DocumentComments.ToString)

                End If

                DocumentComments = _DocumentComments

            End Get
        End Property
        Public ReadOnly Property Documents() As System.Data.Objects.ObjectSet(Of Database.Entities.Document)
            Get

                If _Documents Is Nothing Then

                    _Documents = MyBase.CreateObjectSet(Of Database.Entities.Document)(Database.ObjectContext.Properties.Documents.ToString)

                End If

                Documents = _Documents

            End Get
        End Property
        Public ReadOnly Property DocumentTypes() As System.Data.Objects.ObjectSet(Of Database.Entities.DocumentType)
            Get

                If _DocumentTypes Is Nothing Then

                    _DocumentTypes = MyBase.CreateObjectSet(Of Database.Entities.DocumentType)(Database.ObjectContext.Properties.DocumentTypes.ToString)

                End If

                DocumentTypes = _DocumentTypes

            End Get
        End Property
        Public ReadOnly Property EmployeeCategories() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeCategory)
            Get

                If _EmployeeCategories Is Nothing Then

                    _EmployeeCategories = MyBase.CreateObjectSet(Of Database.Entities.EmployeeCategory)(Database.ObjectContext.Properties.EmployeeCategories.ToString)

                End If

                EmployeeCategories = _EmployeeCategories

            End Get
        End Property
        Public ReadOnly Property EmployeeDepartments() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeDepartment)
            Get

                If _EmployeeDepartments Is Nothing Then

                    _EmployeeDepartments = MyBase.CreateObjectSet(Of Database.Entities.EmployeeDepartment)(Database.ObjectContext.Properties.EmployeeDepartments.ToString)

                End If

                EmployeeDepartments = _EmployeeDepartments

            End Get
        End Property
        Public ReadOnly Property EmployeeNonTasks() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeNonTask)
            Get

                If _EmployeeNonTasks Is Nothing Then

                    _EmployeeNonTasks = MyBase.CreateObjectSet(Of Database.Entities.EmployeeNonTask)(Database.ObjectContext.Properties.EmployeeNonTasks.ToString)

                End If

                EmployeeNonTasks = _EmployeeNonTasks

            End Get
        End Property
        Public ReadOnly Property EmployeeOffices() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeOffice)
            Get

                If _EmployeeOffices Is Nothing Then

                    _EmployeeOffices = MyBase.CreateObjectSet(Of Database.Entities.EmployeeOffice)(Database.ObjectContext.Properties.EmployeeOffices.ToString)

                End If

                EmployeeOffices = _EmployeeOffices

            End Get
        End Property
        Public ReadOnly Property EmployeePictures() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeePicture)
            Get

                If _EmployeePictures Is Nothing Then

                    _EmployeePictures = MyBase.CreateObjectSet(Of Database.Entities.EmployeePicture)(Database.ObjectContext.Properties.EmployeePictures.ToString)

                End If

                EmployeePictures = _EmployeePictures

            End Get
        End Property
        Public ReadOnly Property EmployeeRateHistories() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeRateHistory)
            Get

                If _EmployeeRateHistories Is Nothing Then

                    _EmployeeRateHistories = MyBase.CreateObjectSet(Of Database.Entities.EmployeeRateHistory)(Database.ObjectContext.Properties.EmployeeRateHistories.ToString)

                End If

                EmployeeRateHistories = _EmployeeRateHistories

            End Get
        End Property
        Public ReadOnly Property EmployeeRoles() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeRole)
            Get

                If _EmployeeRoles Is Nothing Then

                    _EmployeeRoles = MyBase.CreateObjectSet(Of Database.Entities.EmployeeRole)(Database.ObjectContext.Properties.EmployeeRoles.ToString)

                End If

                EmployeeRoles = _EmployeeRoles

            End Get
        End Property
        Public ReadOnly Property Employees() As System.Data.Objects.ObjectSet(Of Database.Views.Employee)
            Get

                If _Employees Is Nothing Then

                    _Employees = MyBase.CreateObjectSet(Of Database.Views.Employee)(Database.ObjectContext.Properties.Employees.ToString)

                End If

                Employees = _Employees

            End Get
        End Property
        Public ReadOnly Property EmployeeStandardHours() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeStandardHours)
            Get

                If _EmployeeStandardHours Is Nothing Then

                    _EmployeeStandardHours = MyBase.CreateObjectSet(Of Database.Entities.EmployeeStandardHours)(Database.ObjectContext.Properties.EmployeeStandardHours.ToString)

                End If

                EmployeeStandardHours = _EmployeeStandardHours

            End Get
        End Property
        Public ReadOnly Property EmployeeStandardHoursDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeStandardHoursDetail)
            Get

                If _EmployeeStandardHoursDetails Is Nothing Then

                    _EmployeeStandardHoursDetails = MyBase.CreateObjectSet(Of Database.Entities.EmployeeStandardHoursDetail)(Database.ObjectContext.Properties.EmployeeStandardHoursDetails.ToString)

                End If

                EmployeeStandardHoursDetails = _EmployeeStandardHoursDetails

            End Get
        End Property
        Public ReadOnly Property EmployeeTimeComments() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeComment)
            Get

                If _EmployeeTimeComments Is Nothing Then

                    _EmployeeTimeComments = MyBase.CreateObjectSet(Of Database.Entities.EmployeeTimeComment)(Database.ObjectContext.Properties.EmployeeTimeComments.ToString)

                End If

                EmployeeTimeComments = _EmployeeTimeComments

            End Get
        End Property
        Public ReadOnly Property EmployeeTimeDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeDetail)
            Get

                If _EmployeeTimeDetails Is Nothing Then

                    _EmployeeTimeDetails = MyBase.CreateObjectSet(Of Database.Entities.EmployeeTimeDetail)(Database.ObjectContext.Properties.EmployeeTimeDetails.ToString)

                End If

                EmployeeTimeDetails = _EmployeeTimeDetails

            End Get
        End Property
        Public ReadOnly Property EmployeeTimeForecastOfficeDetailAlternateEmployees() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee)
            Get

                If _EmployeeTimeForecastOfficeDetailAlternateEmployees Is Nothing Then

                    _EmployeeTimeForecastOfficeDetailAlternateEmployees = MyBase.CreateObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee)(Database.ObjectContext.Properties.EmployeeTimeForecastOfficeDetailAlternateEmployees.ToString)

                End If

                EmployeeTimeForecastOfficeDetailAlternateEmployees = _EmployeeTimeForecastOfficeDetailAlternateEmployees

            End Get
        End Property
        Public ReadOnly Property EmployeeTimeForecastOfficeDetailEmployees() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailEmployee)
            Get

                If _EmployeeTimeForecastOfficeDetailEmployees Is Nothing Then

                    _EmployeeTimeForecastOfficeDetailEmployees = MyBase.CreateObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailEmployee)(Database.ObjectContext.Properties.EmployeeTimeForecastOfficeDetailEmployees.ToString)

                End If

                EmployeeTimeForecastOfficeDetailEmployees = _EmployeeTimeForecastOfficeDetailEmployees

            End Get
        End Property
        Public ReadOnly Property EmployeeTimeForecastOfficeDetailIndirectCategories() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory)
            Get

                If _EmployeeTimeForecastOfficeDetailIndirectCategories Is Nothing Then

                    _EmployeeTimeForecastOfficeDetailIndirectCategories = MyBase.CreateObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory)(Database.ObjectContext.Properties.EmployeeTimeForecastOfficeDetailIndirectCategories.ToString)

                End If

                EmployeeTimeForecastOfficeDetailIndirectCategories = _EmployeeTimeForecastOfficeDetailIndirectCategories

            End Get
        End Property
        Public ReadOnly Property EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)
            Get

                If _EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees Is Nothing Then

                    _EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees = MyBase.CreateObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)(Database.ObjectContext.Properties.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees.ToString)

                End If

                EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees = _EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees

            End Get
        End Property
        Public ReadOnly Property EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)
            Get

                If _EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees Is Nothing Then

                    _EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees = MyBase.CreateObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)(Database.ObjectContext.Properties.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees.ToString)

                End If

                EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees = _EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees

            End Get
        End Property
        Public ReadOnly Property EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)
            Get

                If _EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees Is Nothing Then

                    _EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees = MyBase.CreateObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)(Database.ObjectContext.Properties.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees.ToString)

                End If

                EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees = _EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees

            End Get
        End Property
        Public ReadOnly Property EmployeeTimeForecastOfficeDetailJobComponentEmployees() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee)
            Get

                If _EmployeeTimeForecastOfficeDetailJobComponentEmployees Is Nothing Then

                    _EmployeeTimeForecastOfficeDetailJobComponentEmployees = MyBase.CreateObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee)(Database.ObjectContext.Properties.EmployeeTimeForecastOfficeDetailJobComponentEmployees.ToString)

                End If

                EmployeeTimeForecastOfficeDetailJobComponentEmployees = _EmployeeTimeForecastOfficeDetailJobComponentEmployees

            End Get
        End Property
        Public ReadOnly Property EmployeeTimeForecastOfficeDetailJobComponents() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent)
            Get

                If _EmployeeTimeForecastOfficeDetailJobComponents Is Nothing Then

                    _EmployeeTimeForecastOfficeDetailJobComponents = MyBase.CreateObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent)(Database.ObjectContext.Properties.EmployeeTimeForecastOfficeDetailJobComponents.ToString)

                End If

                EmployeeTimeForecastOfficeDetailJobComponents = _EmployeeTimeForecastOfficeDetailJobComponents

            End Get
        End Property
        Public ReadOnly Property EmployeeTimeForecastOfficeDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetail)
            Get

                If _EmployeeTimeForecastOfficeDetails Is Nothing Then

                    _EmployeeTimeForecastOfficeDetails = MyBase.CreateObjectSet(Of Database.Entities.EmployeeTimeForecastOfficeDetail)(Database.ObjectContext.Properties.EmployeeTimeForecastOfficeDetails.ToString)

                End If

                EmployeeTimeForecastOfficeDetails = _EmployeeTimeForecastOfficeDetails

            End Get
        End Property
        Public ReadOnly Property EmployeeTimeForecasts() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeForecast)
            Get

                If _EmployeeTimeForecasts Is Nothing Then

                    _EmployeeTimeForecasts = MyBase.CreateObjectSet(Of Database.Entities.EmployeeTimeForecast)(Database.ObjectContext.Properties.EmployeeTimeForecasts.ToString)

                End If

                EmployeeTimeForecasts = _EmployeeTimeForecasts

            End Get
        End Property
        Public ReadOnly Property EmployeeTimeIndirects() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeIndirect)
            Get

                If _EmployeeTimeIndirects Is Nothing Then

                    _EmployeeTimeIndirects = MyBase.CreateObjectSet(Of Database.Entities.EmployeeTimeIndirect)(Database.ObjectContext.Properties.EmployeeTimeIndirects.ToString)

                End If

                EmployeeTimeIndirects = _EmployeeTimeIndirects

            End Get
        End Property
        Public ReadOnly Property EmployeeTimes() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTime)
            Get

                If _EmployeeTimes Is Nothing Then

                    _EmployeeTimes = MyBase.CreateObjectSet(Of Database.Entities.EmployeeTime)(Database.ObjectContext.Properties.EmployeeTimes.ToString)

                End If

                EmployeeTimes = _EmployeeTimes

            End Get
        End Property
        Public ReadOnly Property EmployeeTimesheetFunctions() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimesheetFunction)
            Get

                If _EmployeeTimesheetFunctions Is Nothing Then

                    _EmployeeTimesheetFunctions = MyBase.CreateObjectSet(Of Database.Entities.EmployeeTimesheetFunction)(Database.ObjectContext.Properties.EmployeeTimesheetFunctions.ToString)

                End If

                EmployeeTimesheetFunctions = _EmployeeTimesheetFunctions

            End Get
        End Property
        Public ReadOnly Property EmployeeTimeTemplates() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTimeTemplate)
            Get

                If _EmployeeTimeTemplates Is Nothing Then

                    _EmployeeTimeTemplates = MyBase.CreateObjectSet(Of Database.Entities.EmployeeTimeTemplate)(Database.ObjectContext.Properties.EmployeeTimeTemplates.ToString)

                End If

                EmployeeTimeTemplates = _EmployeeTimeTemplates

            End Get
        End Property
        Public ReadOnly Property EmployeeTimeTotalsByOfficeClients() As System.Data.Objects.ObjectSet(Of Database.Views.EmployeeTimeTotalsByOfficeClient)
            Get

                If _EmployeeTimeTotalsByOfficeClients Is Nothing Then

                    _EmployeeTimeTotalsByOfficeClients = MyBase.CreateObjectSet(Of Database.Views.EmployeeTimeTotalsByOfficeClient)(Database.ObjectContext.Properties.EmployeeTimeTotalsByOfficeClients.ToString)

                End If

                EmployeeTimeTotalsByOfficeClients = _EmployeeTimeTotalsByOfficeClients

            End Get
        End Property
        Public ReadOnly Property EmployeeTitles() As System.Data.Objects.ObjectSet(Of Database.Entities.EmployeeTitle)
            Get

                If _EmployeeTitles Is Nothing Then

                    _EmployeeTitles = MyBase.CreateObjectSet(Of Database.Entities.EmployeeTitle)(Database.ObjectContext.Properties.EmployeeTitles.ToString)

                End If

                EmployeeTitles = _EmployeeTitles

            End Get
        End Property
        Public ReadOnly Property EstimateApprovals() As System.Data.Objects.ObjectSet(Of Database.Views.EstimateApproval)
            Get

                If _EstimateApprovals Is Nothing Then

                    _EstimateApprovals = MyBase.CreateObjectSet(Of Database.Views.EstimateApproval)(Database.ObjectContext.Properties.EstimateApprovals.ToString)

                End If

                EstimateApprovals = _EstimateApprovals

            End Get
        End Property
        Public ReadOnly Property EstimateComments() As System.Data.Objects.ObjectSet(Of Database.Views.EstimateComment)
            Get

                If _EstimateComments Is Nothing Then

                    _EstimateComments = MyBase.CreateObjectSet(Of Database.Views.EstimateComment)(Database.ObjectContext.Properties.EstimateComments.ToString)

                End If

                EstimateComments = _EstimateComments

            End Get
        End Property
        Public ReadOnly Property EstimateFunctionComments() As System.Data.Objects.ObjectSet(Of Database.Views.EstimateFunctionComment)
            Get

                If _EstimateFunctionComments Is Nothing Then

                    _EstimateFunctionComments = MyBase.CreateObjectSet(Of Database.Views.EstimateFunctionComment)(Database.ObjectContext.Properties.EstimateFunctionComments.ToString)

                End If

                EstimateFunctionComments = _EstimateFunctionComments

            End Get
        End Property
        Public ReadOnly Property EstimatePrintingSettings() As System.Data.Objects.ObjectSet(Of Database.Entities.EstimatePrintingSetting)
            Get

                If _EstimatePrintingSettings Is Nothing Then

                    _EstimatePrintingSettings = MyBase.CreateObjectSet(Of Database.Entities.EstimatePrintingSetting)(Database.ObjectContext.Properties.EstimatePrintingSettings.ToString)

                End If

                EstimatePrintingSettings = _EstimatePrintingSettings

            End Get
        End Property
        Public ReadOnly Property EstimatePrintSettings() As System.Data.Objects.ObjectSet(Of Database.Entities.EstimatePrintSetting)
            Get

                If _EstimatePrintSettings Is Nothing Then

                    _EstimatePrintSettings = MyBase.CreateObjectSet(Of Database.Entities.EstimatePrintSetting)(Database.ObjectContext.Properties.EstimatePrintSettings.ToString)

                End If

                EstimatePrintSettings = _EstimatePrintSettings

            End Get
        End Property
        Public ReadOnly Property EstimateProcessingOptions() As System.Data.Objects.ObjectSet(Of Database.Entities.EstimateProcessingOption)
            Get

                If _EstimateProcessingOptions Is Nothing Then

                    _EstimateProcessingOptions = MyBase.CreateObjectSet(Of Database.Entities.EstimateProcessingOption)(Database.ObjectContext.Properties.EstimateProcessingOptions.ToString)

                End If

                EstimateProcessingOptions = _EstimateProcessingOptions

            End Get
        End Property
        Public ReadOnly Property EstimateRevisionDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.EstimateRevisionDetail)
            Get

                If _EstimateRevisionDetails Is Nothing Then

                    _EstimateRevisionDetails = MyBase.CreateObjectSet(Of Database.Entities.EstimateRevisionDetail)(Database.ObjectContext.Properties.EstimateRevisionDetails.ToString)

                End If

                EstimateRevisionDetails = _EstimateRevisionDetails

            End Get
        End Property
        Public ReadOnly Property EstimateRevisions() As System.Data.Objects.ObjectSet(Of Database.Entities.EstimateRevision)
            Get

                If _EstimateRevisions Is Nothing Then

                    _EstimateRevisions = MyBase.CreateObjectSet(Of Database.Entities.EstimateRevision)(Database.ObjectContext.Properties.EstimateRevisions.ToString)

                End If

                EstimateRevisions = _EstimateRevisions

            End Get
        End Property
        Public ReadOnly Property EstimateTemplates() As System.Data.Objects.ObjectSet(Of Database.Entities.EstimateTemplate)
            Get

                If _EstimateTemplates Is Nothing Then

                    _EstimateTemplates = MyBase.CreateObjectSet(Of Database.Entities.EstimateTemplate)(Database.ObjectContext.Properties.EstimateTemplates.ToString)

                End If

                EstimateTemplates = _EstimateTemplates

            End Get
        End Property
        Public ReadOnly Property ETFOfficeDetailIndirectCategories() As System.Data.Objects.ObjectSet(Of Database.Views.ETFOfficeDetailIndirectCategory)
            Get

                If _ETFOfficeDetailIndirectCategories Is Nothing Then

                    _ETFOfficeDetailIndirectCategories = MyBase.CreateObjectSet(Of Database.Views.ETFOfficeDetailIndirectCategory)(Database.ObjectContext.Properties.ETFOfficeDetailIndirectCategories.ToString)

                End If

                ETFOfficeDetailIndirectCategories = _ETFOfficeDetailIndirectCategories

            End Get
        End Property
        Public ReadOnly Property ETFOfficeDetailIndirectCategoryAlternateEmployees() As System.Data.Objects.ObjectSet(Of Database.Views.ETFOfficeDetailIndirectCategoryAlternateEmployee)
            Get

                If _ETFOfficeDetailIndirectCategoryAlternateEmployees Is Nothing Then

                    _ETFOfficeDetailIndirectCategoryAlternateEmployees = MyBase.CreateObjectSet(Of Database.Views.ETFOfficeDetailIndirectCategoryAlternateEmployee)(Database.ObjectContext.Properties.ETFOfficeDetailIndirectCategoryAlternateEmployees.ToString)

                End If

                ETFOfficeDetailIndirectCategoryAlternateEmployees = _ETFOfficeDetailIndirectCategoryAlternateEmployees

            End Get
        End Property
        Public ReadOnly Property ETFOfficeDetailIndirectCategoryEmployees() As System.Data.Objects.ObjectSet(Of Database.Views.ETFOfficeDetailIndirectCategoryEmployee)
            Get

                If _ETFOfficeDetailIndirectCategoryEmployees Is Nothing Then

                    _ETFOfficeDetailIndirectCategoryEmployees = MyBase.CreateObjectSet(Of Database.Views.ETFOfficeDetailIndirectCategoryEmployee)(Database.ObjectContext.Properties.ETFOfficeDetailIndirectCategoryEmployees.ToString)

                End If

                ETFOfficeDetailIndirectCategoryEmployees = _ETFOfficeDetailIndirectCategoryEmployees

            End Get
        End Property
        Public ReadOnly Property ETFOfficeDetailJobComponentAlternateEmployees() As System.Data.Objects.ObjectSet(Of Database.Views.ETFOfficeDetailJobComponentAlternateEmployee)
            Get

                If _ETFOfficeDetailJobComponentAlternateEmployees Is Nothing Then

                    _ETFOfficeDetailJobComponentAlternateEmployees = MyBase.CreateObjectSet(Of Database.Views.ETFOfficeDetailJobComponentAlternateEmployee)(Database.ObjectContext.Properties.ETFOfficeDetailJobComponentAlternateEmployees.ToString)

                End If

                ETFOfficeDetailJobComponentAlternateEmployees = _ETFOfficeDetailJobComponentAlternateEmployees

            End Get
        End Property
        Public ReadOnly Property ETFOfficeDetailJobComponentEmployees() As System.Data.Objects.ObjectSet(Of Database.Views.ETFOfficeDetailJobComponentEmployee)
            Get

                If _ETFOfficeDetailJobComponentEmployees Is Nothing Then

                    _ETFOfficeDetailJobComponentEmployees = MyBase.CreateObjectSet(Of Database.Views.ETFOfficeDetailJobComponentEmployee)(Database.ObjectContext.Properties.ETFOfficeDetailJobComponentEmployees.ToString)

                End If

                ETFOfficeDetailJobComponentEmployees = _ETFOfficeDetailJobComponentEmployees

            End Get
        End Property
        Public ReadOnly Property ETFOfficeDetailJobComponents() As System.Data.Objects.ObjectSet(Of Database.Views.ETFOfficeDetailJobComponent)
            Get

                If _ETFOfficeDetailJobComponents Is Nothing Then

                    _ETFOfficeDetailJobComponents = MyBase.CreateObjectSet(Of Database.Views.ETFOfficeDetailJobComponent)(Database.ObjectContext.Properties.ETFOfficeDetailJobComponents.ToString)

                End If

                ETFOfficeDetailJobComponents = _ETFOfficeDetailJobComponents

            End Get
        End Property
        Public ReadOnly Property ExecutiveDesktopDocuments() As System.Data.Objects.ObjectSet(Of Database.Entities.ExecutiveDesktopDocument)
            Get

                If _ExecutiveDesktopDocuments Is Nothing Then

                    _ExecutiveDesktopDocuments = MyBase.CreateObjectSet(Of Database.Entities.ExecutiveDesktopDocument)(Database.ObjectContext.Properties.ExecutiveDesktopDocuments.ToString)

                End If

                ExecutiveDesktopDocuments = _ExecutiveDesktopDocuments

            End Get
        End Property
        Public ReadOnly Property ExpenseDetailDocuments() As System.Data.Objects.ObjectSet(Of Database.Entities.ExpenseDetailDocument)
            Get

                If _ExpenseDetailDocuments Is Nothing Then

                    _ExpenseDetailDocuments = MyBase.CreateObjectSet(Of Database.Entities.ExpenseDetailDocument)(Database.ObjectContext.Properties.ExpenseDetailDocuments.ToString)

                End If

                ExpenseDetailDocuments = _ExpenseDetailDocuments

            End Get
        End Property
        Public ReadOnly Property ExpenseReportDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.ExpenseReportDetail)
            Get

                If _ExpenseReportDetails Is Nothing Then

                    _ExpenseReportDetails = MyBase.CreateObjectSet(Of Database.Entities.ExpenseReportDetail)(Database.ObjectContext.Properties.ExpenseReportDetails.ToString)

                End If

                ExpenseReportDetails = _ExpenseReportDetails

            End Get
        End Property
        Public ReadOnly Property ExpenseReportDocuments() As System.Data.Objects.ObjectSet(Of Database.Entities.ExpenseReportDocument)
            Get

                If _ExpenseReportDocuments Is Nothing Then

                    _ExpenseReportDocuments = MyBase.CreateObjectSet(Of Database.Entities.ExpenseReportDocument)(Database.ObjectContext.Properties.ExpenseReportDocuments.ToString)

                End If

                ExpenseReportDocuments = _ExpenseReportDocuments

            End Get
        End Property
        Public ReadOnly Property ExpenseReports() As System.Data.Objects.ObjectSet(Of Database.Entities.ExpenseReport)
            Get

                If _ExpenseReports Is Nothing Then

                    _ExpenseReports = MyBase.CreateObjectSet(Of Database.Entities.ExpenseReport)(Database.ObjectContext.Properties.ExpenseReports.ToString)

                End If

                ExpenseReports = _ExpenseReports

            End Get
        End Property
        Public ReadOnly Property ExpenseSummarys() As System.Data.Objects.ObjectSet(Of Database.Views.ExpenseSummary)
            Get

                If _ExpenseSummarys Is Nothing Then

                    _ExpenseSummarys = MyBase.CreateObjectSet(Of Database.Views.ExpenseSummary)(Database.ObjectContext.Properties.ExpenseSummarys.ToString)

                End If

                ExpenseSummarys = _ExpenseSummarys

            End Get
        End Property
        Public ReadOnly Property ExportSystems() As System.Data.Objects.ObjectSet(Of Database.Entities.ExportSystem)
            Get

                If _ExportSystems Is Nothing Then

                    _ExportSystems = MyBase.CreateObjectSet(Of Database.Entities.ExportSystem)(Database.ObjectContext.Properties.ExportSystems.ToString)

                End If

                ExportSystems = _ExportSystems

            End Get
        End Property
        Public ReadOnly Property ExportTemplateDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.ExportTemplateDetail)
            Get

                If _ExportTemplateDetails Is Nothing Then

                    _ExportTemplateDetails = MyBase.CreateObjectSet(Of Database.Entities.ExportTemplateDetail)(Database.ObjectContext.Properties.ExportTemplateDetails.ToString)

                End If

                ExportTemplateDetails = _ExportTemplateDetails

            End Get
        End Property
        Public ReadOnly Property ExportTemplates() As System.Data.Objects.ObjectSet(Of Database.Entities.ExportTemplate)
            Get

                If _ExportTemplates Is Nothing Then

                    _ExportTemplates = MyBase.CreateObjectSet(Of Database.Entities.ExportTemplate)(Database.ObjectContext.Properties.ExportTemplates.ToString)

                End If

                ExportTemplates = _ExportTemplates

            End Get
        End Property
        Public ReadOnly Property FiscalPeriods() As System.Data.Objects.ObjectSet(Of Database.Entities.FiscalPeriod)
            Get

                If _FiscalPeriods Is Nothing Then

                    _FiscalPeriods = MyBase.CreateObjectSet(Of Database.Entities.FiscalPeriod)(Database.ObjectContext.Properties.FiscalPeriods.ToString)

                End If

                FiscalPeriods = _FiscalPeriods

            End Get
        End Property
        Public ReadOnly Property FunctionHeadings() As System.Data.Objects.ObjectSet(Of Database.Entities.FunctionHeading)
            Get

                If _FunctionHeadings Is Nothing Then

                    _FunctionHeadings = MyBase.CreateObjectSet(Of Database.Entities.FunctionHeading)(Database.ObjectContext.Properties.FunctionHeadings.ToString)

                End If

                FunctionHeadings = _FunctionHeadings

            End Get
        End Property
        Public ReadOnly Property Functions() As System.Data.Objects.ObjectSet(Of Database.Entities.[Function])
            Get

                If _Functions Is Nothing Then

                    _Functions = MyBase.CreateObjectSet(Of Database.Entities.[Function])(Database.ObjectContext.Properties.Functions.ToString)

                End If

                Functions = _Functions

            End Get
        End Property
        Public ReadOnly Property FunctionViews() As System.Data.Objects.ObjectSet(Of Database.Views.FunctionView)
            Get

                If _FunctionViews Is Nothing Then

                    _FunctionViews = MyBase.CreateObjectSet(Of Database.Views.FunctionView)(Database.ObjectContext.Properties.FunctionViews.ToString)

                End If

                FunctionViews = _FunctionViews

            End Get
        End Property
        Public ReadOnly Property GeneralDescriptions() As System.Data.Objects.ObjectSet(Of Database.Entities.GeneralDescription)
            Get

                If _GeneralDescriptions Is Nothing Then

                    _GeneralDescriptions = MyBase.CreateObjectSet(Of Database.Entities.GeneralDescription)(Database.ObjectContext.Properties.GeneralDescriptions.ToString)

                End If

                GeneralDescriptions = _GeneralDescriptions

            End Get
        End Property
        Public ReadOnly Property GeneralLedgerAccounts() As System.Data.Objects.ObjectSet(Of Database.Entities.GeneralLedgerAccount)
            Get

                If _GeneralLedgerAccounts Is Nothing Then

                    _GeneralLedgerAccounts = MyBase.CreateObjectSet(Of Database.Entities.GeneralLedgerAccount)(Database.ObjectContext.Properties.GeneralLedgerAccounts.ToString)

                End If

                GeneralLedgerAccounts = _GeneralLedgerAccounts

            End Get
        End Property
        Public ReadOnly Property GeneralLedgerCrossReferences() As System.Data.Objects.ObjectSet(Of Database.Entities.GeneralLedgerCrossReference)
            Get

                If _GeneralLedgerCrossReferences Is Nothing Then

                    _GeneralLedgerCrossReferences = MyBase.CreateObjectSet(Of Database.Entities.GeneralLedgerCrossReference)(Database.ObjectContext.Properties.GeneralLedgerCrossReferences.ToString)

                End If

                GeneralLedgerCrossReferences = _GeneralLedgerCrossReferences

            End Get
        End Property
        Public ReadOnly Property GeneralLedgerDepartmentTeamCrossReferences() As System.Data.Objects.ObjectSet(Of Database.Entities.GeneralLedgerDepartmentTeamCrossReference)
            Get

                If _GeneralLedgerDepartmentTeamCrossReferences Is Nothing Then

                    _GeneralLedgerDepartmentTeamCrossReferences = MyBase.CreateObjectSet(Of Database.Entities.GeneralLedgerDepartmentTeamCrossReference)(Database.ObjectContext.Properties.GeneralLedgerDepartmentTeamCrossReferences.ToString)

                End If

                GeneralLedgerDepartmentTeamCrossReferences = _GeneralLedgerDepartmentTeamCrossReferences

            End Get
        End Property
        Public ReadOnly Property GeneralLedgerDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.GeneralLedgerDetail)
            Get

                If _GeneralLedgerDetails Is Nothing Then

                    _GeneralLedgerDetails = MyBase.CreateObjectSet(Of Database.Entities.GeneralLedgerDetail)(Database.ObjectContext.Properties.GeneralLedgerDetails.ToString)

                End If

                GeneralLedgerDetails = _GeneralLedgerDetails

            End Get
        End Property
        Public ReadOnly Property GeneralLedgerOfficeCrossReferences() As System.Data.Objects.ObjectSet(Of Database.Entities.GeneralLedgerOfficeCrossReference)
            Get

                If _GeneralLedgerOfficeCrossReferences Is Nothing Then

                    _GeneralLedgerOfficeCrossReferences = MyBase.CreateObjectSet(Of Database.Entities.GeneralLedgerOfficeCrossReference)(Database.ObjectContext.Properties.GeneralLedgerOfficeCrossReferences.ToString)

                End If

                GeneralLedgerOfficeCrossReferences = _GeneralLedgerOfficeCrossReferences

            End Get
        End Property
        Public ReadOnly Property GeneralLedgers() As System.Data.Objects.ObjectSet(Of Database.Entities.GeneralLedger)
            Get

                If _GeneralLedgers Is Nothing Then

                    _GeneralLedgers = MyBase.CreateObjectSet(Of Database.Entities.GeneralLedger)(Database.ObjectContext.Properties.GeneralLedgers.ToString)

                End If

                GeneralLedgers = _GeneralLedgers

            End Get
        End Property
        Public ReadOnly Property GLAllocations() As System.Data.Objects.ObjectSet(Of Database.Entities.GLAllocation)
            Get

                If _GLAllocations Is Nothing Then

                    _GLAllocations = MyBase.CreateObjectSet(Of Database.Entities.GLAllocation)(Database.ObjectContext.Properties.GLAllocations.ToString)

                End If

                GLAllocations = _GLAllocations

            End Get
        End Property
        Public ReadOnly Property GLASummaryDatas() As System.Data.Objects.ObjectSet(Of Database.Entities.GLASummaryData)
            Get

                If _GLASummaryDatas Is Nothing Then

                    _GLASummaryDatas = MyBase.CreateObjectSet(Of Database.Entities.GLASummaryData)(Database.ObjectContext.Properties.GLASummaryDatas.ToString)

                End If

                GLASummaryDatas = _GLASummaryDatas

            End Get
        End Property
        Public ReadOnly Property GLATrailers() As System.Data.Objects.ObjectSet(Of Database.Entities.GLATrailer)
            Get

                If _GLATrailers Is Nothing Then

                    _GLATrailers = MyBase.CreateObjectSet(Of Database.Entities.GLATrailer)(Database.ObjectContext.Properties.GLATrailers.ToString)

                End If

                GLATrailers = _GLATrailers

            End Get
        End Property
        Public ReadOnly Property GLReportTemplateColumns() As System.Data.Objects.ObjectSet(Of Database.Entities.GLReportTemplateColumn)
            Get

                If _GLReportTemplateColumns Is Nothing Then

                    _GLReportTemplateColumns = MyBase.CreateObjectSet(Of Database.Entities.GLReportTemplateColumn)(Database.ObjectContext.Properties.GLReportTemplateColumns.ToString)

                End If

                GLReportTemplateColumns = _GLReportTemplateColumns

            End Get
        End Property
        Public ReadOnly Property GLReportTemplateDepartmentTeamPresets() As System.Data.Objects.ObjectSet(Of Database.Entities.GLReportTemplateDepartmentTeamPreset)
            Get

                If _GLReportTemplateDepartmentTeamPresets Is Nothing Then

                    _GLReportTemplateDepartmentTeamPresets = MyBase.CreateObjectSet(Of Database.Entities.GLReportTemplateDepartmentTeamPreset)(Database.ObjectContext.Properties.GLReportTemplateDepartmentTeamPresets.ToString)

                End If

                GLReportTemplateDepartmentTeamPresets = _GLReportTemplateDepartmentTeamPresets

            End Get
        End Property
        Public ReadOnly Property GLReportTemplateOfficePresets() As System.Data.Objects.ObjectSet(Of Database.Entities.GLReportTemplateOfficePreset)
            Get

                If _GLReportTemplateOfficePresets Is Nothing Then

                    _GLReportTemplateOfficePresets = MyBase.CreateObjectSet(Of Database.Entities.GLReportTemplateOfficePreset)(Database.ObjectContext.Properties.GLReportTemplateOfficePresets.ToString)

                End If

                GLReportTemplateOfficePresets = _GLReportTemplateOfficePresets

            End Get
        End Property
        Public ReadOnly Property GLReportTemplatePctOfRowColumnRelations() As System.Data.Objects.ObjectSet(Of Database.Entities.GLReportTemplatePctOfRowColumnRelation)
            Get

                If _GLReportTemplatePctOfRowColumnRelations Is Nothing Then

                    _GLReportTemplatePctOfRowColumnRelations = MyBase.CreateObjectSet(Of Database.Entities.GLReportTemplatePctOfRowColumnRelation)(Database.ObjectContext.Properties.GLReportTemplatePctOfRowColumnRelations.ToString)

                End If

                GLReportTemplatePctOfRowColumnRelations = _GLReportTemplatePctOfRowColumnRelations

            End Get
        End Property
        Public ReadOnly Property GLReportTemplateRowRelations() As System.Data.Objects.ObjectSet(Of Database.Entities.GLReportTemplateRowRelation)
            Get

                If _GLReportTemplateRowRelations Is Nothing Then

                    _GLReportTemplateRowRelations = MyBase.CreateObjectSet(Of Database.Entities.GLReportTemplateRowRelation)(Database.ObjectContext.Properties.GLReportTemplateRowRelations.ToString)

                End If

                GLReportTemplateRowRelations = _GLReportTemplateRowRelations

            End Get
        End Property
        Public ReadOnly Property GLReportTemplateRows() As System.Data.Objects.ObjectSet(Of Database.Entities.GLReportTemplateRow)
            Get

                If _GLReportTemplateRows Is Nothing Then

                    _GLReportTemplateRows = MyBase.CreateObjectSet(Of Database.Entities.GLReportTemplateRow)(Database.ObjectContext.Properties.GLReportTemplateRows.ToString)

                End If

                GLReportTemplateRows = _GLReportTemplateRows

            End Get
        End Property
        Public ReadOnly Property GLReportTemplates() As System.Data.Objects.ObjectSet(Of Database.Entities.GLReportTemplate)
            Get

                If _GLReportTemplates Is Nothing Then

                    _GLReportTemplates = MyBase.CreateObjectSet(Of Database.Entities.GLReportTemplate)(Database.ObjectContext.Properties.GLReportTemplates.ToString)

                End If

                GLReportTemplates = _GLReportTemplates

            End Get
        End Property
        Public ReadOnly Property GLReportUserDefReports() As System.Data.Objects.ObjectSet(Of Database.Entities.GLReportUserDefReport)
            Get

                If _GLReportUserDefReports Is Nothing Then

                    _GLReportUserDefReports = MyBase.CreateObjectSet(Of Database.Entities.GLReportUserDefReport)(Database.ObjectContext.Properties.GLReportUserDefReports.ToString)

                End If

                GLReportUserDefReports = _GLReportUserDefReports

            End Get
        End Property
        Public ReadOnly Property GLTemplates() As System.Data.Objects.ObjectSet(Of Database.Entities.GLTemplate)
            Get

                If _GLTemplates Is Nothing Then

                    _GLTemplates = MyBase.CreateObjectSet(Of Database.Entities.GLTemplate)(Database.ObjectContext.Properties.GLTemplates.ToString)

                End If

                GLTemplates = _GLTemplates

            End Get
        End Property
        Public ReadOnly Property IDs() As System.Data.Objects.ObjectSet(Of Database.Entities.ID)
            Get

                If _IDs Is Nothing Then

                    _IDs = MyBase.CreateObjectSet(Of Database.Entities.ID)(Database.ObjectContext.Properties.IDs.ToString)

                End If

                IDs = _IDs

            End Get
        End Property
        Public ReadOnly Property Images() As System.Data.Objects.ObjectSet(Of Database.Entities.Image)
            Get

                If _Images Is Nothing Then

                    _Images = MyBase.CreateObjectSet(Of Database.Entities.Image)(Database.ObjectContext.Properties.Images.ToString)

                End If

                Images = _Images

            End Get
        End Property
        Public ReadOnly Property ImportAccountPayableErrors() As System.Data.Objects.ObjectSet(Of Database.Entities.ImportAccountPayableError)
            Get

                If _ImportAccountPayableErrors Is Nothing Then

                    _ImportAccountPayableErrors = MyBase.CreateObjectSet(Of Database.Entities.ImportAccountPayableError)(Database.ObjectContext.Properties.ImportAccountPayableErrors.ToString)

                End If

                ImportAccountPayableErrors = _ImportAccountPayableErrors

            End Get
        End Property
        Public ReadOnly Property ImportAccountPayableGLs() As System.Data.Objects.ObjectSet(Of Database.Entities.ImportAccountPayableGL)
            Get

                If _ImportAccountPayableGLs Is Nothing Then

                    _ImportAccountPayableGLs = MyBase.CreateObjectSet(Of Database.Entities.ImportAccountPayableGL)(Database.ObjectContext.Properties.ImportAccountPayableGLs.ToString)

                End If

                ImportAccountPayableGLs = _ImportAccountPayableGLs

            End Get
        End Property
        Public ReadOnly Property ImportAccountPayableJobs() As System.Data.Objects.ObjectSet(Of Database.Entities.ImportAccountPayableJob)
            Get

                If _ImportAccountPayableJobs Is Nothing Then

                    _ImportAccountPayableJobs = MyBase.CreateObjectSet(Of Database.Entities.ImportAccountPayableJob)(Database.ObjectContext.Properties.ImportAccountPayableJobs.ToString)

                End If

                ImportAccountPayableJobs = _ImportAccountPayableJobs

            End Get
        End Property
        Public ReadOnly Property ImportAccountPayableMedias() As System.Data.Objects.ObjectSet(Of Database.Entities.ImportAccountPayableMedia)
            Get

                If _ImportAccountPayableMedias Is Nothing Then

                    _ImportAccountPayableMedias = MyBase.CreateObjectSet(Of Database.Entities.ImportAccountPayableMedia)(Database.ObjectContext.Properties.ImportAccountPayableMedias.ToString)

                End If

                ImportAccountPayableMedias = _ImportAccountPayableMedias

            End Get
        End Property
        Public ReadOnly Property ImportAccountPayables() As System.Data.Objects.ObjectSet(Of Database.Entities.ImportAccountPayable)
            Get

                If _ImportAccountPayables Is Nothing Then

                    _ImportAccountPayables = MyBase.CreateObjectSet(Of Database.Entities.ImportAccountPayable)(Database.ObjectContext.Properties.ImportAccountPayables.ToString)

                End If

                ImportAccountPayables = _ImportAccountPayables

            End Get
        End Property
        Public ReadOnly Property ImportClearedChecksStagings() As System.Data.Objects.ObjectSet(Of Database.Entities.ImportClearedChecksStaging)
            Get

                If _ImportClearedChecksStagings Is Nothing Then

                    _ImportClearedChecksStagings = MyBase.CreateObjectSet(Of Database.Entities.ImportClearedChecksStaging)(Database.ObjectContext.Properties.ImportClearedChecksStagings.ToString)

                End If

                ImportClearedChecksStagings = _ImportClearedChecksStagings

            End Get
        End Property
        Public ReadOnly Property ImportClientStagings() As System.Data.Objects.ObjectSet(Of Database.Entities.ImportClientStaging)
            Get

                If _ImportClientStagings Is Nothing Then

                    _ImportClientStagings = MyBase.CreateObjectSet(Of Database.Entities.ImportClientStaging)(Database.ObjectContext.Properties.ImportClientStagings.ToString)

                End If

                ImportClientStagings = _ImportClientStagings

            End Get
        End Property
        Public ReadOnly Property ImportCreditCardStagings() As System.Data.Objects.ObjectSet(Of Database.Entities.ImportCreditCardStaging)
            Get

                If _ImportCreditCardStagings Is Nothing Then

                    _ImportCreditCardStagings = MyBase.CreateObjectSet(Of Database.Entities.ImportCreditCardStaging)(Database.ObjectContext.Properties.ImportCreditCardStagings.ToString)

                End If

                ImportCreditCardStagings = _ImportCreditCardStagings

            End Get
        End Property
        Public ReadOnly Property ImportDigitalResultsStagings() As System.Data.Objects.ObjectSet(Of Database.Entities.ImportDigitalResultsStaging)
            Get

                If _ImportDigitalResultsStagings Is Nothing Then

                    _ImportDigitalResultsStagings = MyBase.CreateObjectSet(Of Database.Entities.ImportDigitalResultsStaging)(Database.ObjectContext.Properties.ImportDigitalResultsStagings.ToString)

                End If

                ImportDigitalResultsStagings = _ImportDigitalResultsStagings

            End Get
        End Property
        Public ReadOnly Property ImportDivisionStagings() As System.Data.Objects.ObjectSet(Of Database.Entities.ImportDivisionStaging)
            Get

                If _ImportDivisionStagings Is Nothing Then

                    _ImportDivisionStagings = MyBase.CreateObjectSet(Of Database.Entities.ImportDivisionStaging)(Database.ObjectContext.Properties.ImportDivisionStagings.ToString)

                End If

                ImportDivisionStagings = _ImportDivisionStagings

            End Get
        End Property
        Public ReadOnly Property ImportEmployeeStagings() As System.Data.Objects.ObjectSet(Of Database.Entities.ImportEmployeeStaging)
            Get

                If _ImportEmployeeStagings Is Nothing Then

                    _ImportEmployeeStagings = MyBase.CreateObjectSet(Of Database.Entities.ImportEmployeeStaging)(Database.ObjectContext.Properties.ImportEmployeeStagings.ToString)

                End If

                ImportEmployeeStagings = _ImportEmployeeStagings

            End Get
        End Property
        Public ReadOnly Property ImportFunctionStagings() As System.Data.Objects.ObjectSet(Of Database.Entities.ImportFunctionStaging)
            Get

                If _ImportFunctionStagings Is Nothing Then

                    _ImportFunctionStagings = MyBase.CreateObjectSet(Of Database.Entities.ImportFunctionStaging)(Database.ObjectContext.Properties.ImportFunctionStagings.ToString)

                End If

                ImportFunctionStagings = _ImportFunctionStagings

            End Get
        End Property
        Public ReadOnly Property ImportGeneralLedgerAccountStagings() As System.Data.Objects.ObjectSet(Of Database.Entities.ImportGeneralLedgerAccountStaging)
            Get

                If _ImportGeneralLedgerAccountStagings Is Nothing Then

                    _ImportGeneralLedgerAccountStagings = MyBase.CreateObjectSet(Of Database.Entities.ImportGeneralLedgerAccountStaging)(Database.ObjectContext.Properties.ImportGeneralLedgerAccountStagings.ToString)

                End If

                ImportGeneralLedgerAccountStagings = _ImportGeneralLedgerAccountStagings

            End Get
        End Property
        Public ReadOnly Property ImportProductStagings() As System.Data.Objects.ObjectSet(Of Database.Entities.ImportProductStaging)
            Get

                If _ImportProductStagings Is Nothing Then

                    _ImportProductStagings = MyBase.CreateObjectSet(Of Database.Entities.ImportProductStaging)(Database.ObjectContext.Properties.ImportProductStagings.ToString)

                End If

                ImportProductStagings = _ImportProductStagings

            End Get
        End Property
        Public ReadOnly Property ImportTemplateDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.ImportTemplateDetail)
            Get

                If _ImportTemplateDetails Is Nothing Then

                    _ImportTemplateDetails = MyBase.CreateObjectSet(Of Database.Entities.ImportTemplateDetail)(Database.ObjectContext.Properties.ImportTemplateDetails.ToString)

                End If

                ImportTemplateDetails = _ImportTemplateDetails

            End Get
        End Property
        Public ReadOnly Property ImportTemplates() As System.Data.Objects.ObjectSet(Of Database.Entities.ImportTemplate)
            Get

                If _ImportTemplates Is Nothing Then

                    _ImportTemplates = MyBase.CreateObjectSet(Of Database.Entities.ImportTemplate)(Database.ObjectContext.Properties.ImportTemplates.ToString)

                End If

                ImportTemplates = _ImportTemplates

            End Get
        End Property
        Public ReadOnly Property ImportVendorStagings() As System.Data.Objects.ObjectSet(Of Database.Entities.ImportVendorStaging)
            Get

                If _ImportVendorStagings Is Nothing Then

                    _ImportVendorStagings = MyBase.CreateObjectSet(Of Database.Entities.ImportVendorStaging)(Database.ObjectContext.Properties.ImportVendorStagings.ToString)

                End If

                ImportVendorStagings = _ImportVendorStagings

            End Get
        End Property
        Public ReadOnly Property IncomeOnlys() As System.Data.Objects.ObjectSet(Of Database.Entities.IncomeOnly)
            Get

                If _IncomeOnlys Is Nothing Then

                    _IncomeOnlys = MyBase.CreateObjectSet(Of Database.Entities.IncomeOnly)(Database.ObjectContext.Properties.IncomeOnlys.ToString)

                End If

                IncomeOnlys = _IncomeOnlys

            End Get
        End Property
        Public ReadOnly Property IndirectCategories() As System.Data.Objects.ObjectSet(Of Database.Entities.IndirectCategory)
            Get

                If _IndirectCategories Is Nothing Then

                    _IndirectCategories = MyBase.CreateObjectSet(Of Database.Entities.IndirectCategory)(Database.ObjectContext.Properties.IndirectCategories.ToString)

                End If

                IndirectCategories = _IndirectCategories

            End Get
        End Property
        Public ReadOnly Property Industries() As System.Data.Objects.ObjectSet(Of Database.Entities.Industry)
            Get

                If _Industries Is Nothing Then

                    _Industries = MyBase.CreateObjectSet(Of Database.Entities.Industry)(Database.ObjectContext.Properties.Industries.ToString)

                End If

                Industries = _Industries

            End Get
        End Property
        Public ReadOnly Property InternetOrderDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.InternetOrderDetail)
            Get

                If _InternetOrderDetails Is Nothing Then

                    _InternetOrderDetails = MyBase.CreateObjectSet(Of Database.Entities.InternetOrderDetail)(Database.ObjectContext.Properties.InternetOrderDetails.ToString)

                End If

                InternetOrderDetails = _InternetOrderDetails

            End Get
        End Property
        Public ReadOnly Property InternetOrders() As System.Data.Objects.ObjectSet(Of Database.Entities.InternetOrder)
            Get

                If _InternetOrders Is Nothing Then

                    _InternetOrders = MyBase.CreateObjectSet(Of Database.Entities.InternetOrder)(Database.ObjectContext.Properties.InternetOrders.ToString)

                End If

                InternetOrders = _InternetOrders

            End Get
        End Property
        Public ReadOnly Property InternetTypes() As System.Data.Objects.ObjectSet(Of Database.Entities.InternetType)
            Get

                If _InternetTypes Is Nothing Then

                    _InternetTypes = MyBase.CreateObjectSet(Of Database.Entities.InternetType)(Database.ObjectContext.Properties.InternetTypes.ToString)

                End If

                InternetTypes = _InternetTypes

            End Get
        End Property
        Public ReadOnly Property InvoiceCategories() As System.Data.Objects.ObjectSet(Of Database.Entities.InvoiceCategory)
            Get

                If _InvoiceCategories Is Nothing Then

                    _InvoiceCategories = MyBase.CreateObjectSet(Of Database.Entities.InvoiceCategory)(Database.ObjectContext.Properties.InvoiceCategories.ToString)

                End If

                InvoiceCategories = _InvoiceCategories

            End Get
        End Property
        Public ReadOnly Property InvoiceJobComments() As System.Data.Objects.ObjectSet(Of Database.Views.InvoiceJobComment)
            Get

                If _InvoiceJobComments Is Nothing Then

                    _InvoiceJobComments = MyBase.CreateObjectSet(Of Database.Views.InvoiceJobComment)(Database.ObjectContext.Properties.InvoiceJobComments.ToString)

                End If

                InvoiceJobComments = _InvoiceJobComments

            End Get
        End Property
        Public ReadOnly Property InvoiceJobFunctionComments() As System.Data.Objects.ObjectSet(Of Database.Views.InvoiceJobFunctionComment)
            Get

                If _InvoiceJobFunctionComments Is Nothing Then

                    _InvoiceJobFunctionComments = MyBase.CreateObjectSet(Of Database.Views.InvoiceJobFunctionComment)(Database.ObjectContext.Properties.InvoiceJobFunctionComments.ToString)

                End If

                InvoiceJobFunctionComments = _InvoiceJobFunctionComments

            End Get
        End Property
        Public ReadOnly Property JobComponents() As System.Data.Objects.ObjectSet(Of Database.Entities.JobComponent)
            Get

                If _JobComponents Is Nothing Then

                    _JobComponents = MyBase.CreateObjectSet(Of Database.Entities.JobComponent)(Database.ObjectContext.Properties.JobComponents.ToString)

                End If

                JobComponents = _JobComponents

            End Get
        End Property
        Public ReadOnly Property JobComponentTaskClientContacts() As System.Data.Objects.ObjectSet(Of Database.Entities.JobComponentTaskClientContact)
            Get

                If _JobComponentTaskClientContacts Is Nothing Then

                    _JobComponentTaskClientContacts = MyBase.CreateObjectSet(Of Database.Entities.JobComponentTaskClientContact)(Database.ObjectContext.Properties.JobComponentTaskClientContacts.ToString)

                End If

                JobComponentTaskClientContacts = _JobComponentTaskClientContacts

            End Get
        End Property
        Public ReadOnly Property JobComponentTaskEmployees() As System.Data.Objects.ObjectSet(Of Database.Entities.JobComponentTaskEmployee)
            Get

                If _JobComponentTaskEmployees Is Nothing Then

                    _JobComponentTaskEmployees = MyBase.CreateObjectSet(Of Database.Entities.JobComponentTaskEmployee)(Database.ObjectContext.Properties.JobComponentTaskEmployees.ToString)

                End If

                JobComponentTaskEmployees = _JobComponentTaskEmployees

            End Get
        End Property
        Public ReadOnly Property JobComponentTasks() As System.Data.Objects.ObjectSet(Of Database.Entities.JobComponentTask)
            Get

                If _JobComponentTasks Is Nothing Then

                    _JobComponentTasks = MyBase.CreateObjectSet(Of Database.Entities.JobComponentTask)(Database.ObjectContext.Properties.JobComponentTasks.ToString)

                End If

                JobComponentTasks = _JobComponentTasks

            End Get
        End Property
        Public ReadOnly Property JobComponentUserDefinedValue1() As System.Data.Objects.ObjectSet(Of Database.Entities.JobComponentUserDefinedValue1)
            Get

                If _JobComponentUserDefinedValue1 Is Nothing Then

                    _JobComponentUserDefinedValue1 = MyBase.CreateObjectSet(Of Database.Entities.JobComponentUserDefinedValue1)(Database.ObjectContext.Properties.JobComponentUserDefinedValue1.ToString)

                End If

                JobComponentUserDefinedValue1 = _JobComponentUserDefinedValue1

            End Get
        End Property
        Public ReadOnly Property JobComponentUserDefinedValue2() As System.Data.Objects.ObjectSet(Of Database.Entities.JobComponentUserDefinedValue2)
            Get

                If _JobComponentUserDefinedValue2 Is Nothing Then

                    _JobComponentUserDefinedValue2 = MyBase.CreateObjectSet(Of Database.Entities.JobComponentUserDefinedValue2)(Database.ObjectContext.Properties.JobComponentUserDefinedValue2.ToString)

                End If

                JobComponentUserDefinedValue2 = _JobComponentUserDefinedValue2

            End Get
        End Property
        Public ReadOnly Property JobComponentUserDefinedValue3() As System.Data.Objects.ObjectSet(Of Database.Entities.JobComponentUserDefinedValue3)
            Get

                If _JobComponentUserDefinedValue3 Is Nothing Then

                    _JobComponentUserDefinedValue3 = MyBase.CreateObjectSet(Of Database.Entities.JobComponentUserDefinedValue3)(Database.ObjectContext.Properties.JobComponentUserDefinedValue3.ToString)

                End If

                JobComponentUserDefinedValue3 = _JobComponentUserDefinedValue3

            End Get
        End Property
        Public ReadOnly Property JobComponentUserDefinedValue4() As System.Data.Objects.ObjectSet(Of Database.Entities.JobComponentUserDefinedValue4)
            Get

                If _JobComponentUserDefinedValue4 Is Nothing Then

                    _JobComponentUserDefinedValue4 = MyBase.CreateObjectSet(Of Database.Entities.JobComponentUserDefinedValue4)(Database.ObjectContext.Properties.JobComponentUserDefinedValue4.ToString)

                End If

                JobComponentUserDefinedValue4 = _JobComponentUserDefinedValue4

            End Get
        End Property
        Public ReadOnly Property JobComponentUserDefinedValue5() As System.Data.Objects.ObjectSet(Of Database.Entities.JobComponentUserDefinedValue5)
            Get

                If _JobComponentUserDefinedValue5 Is Nothing Then

                    _JobComponentUserDefinedValue5 = MyBase.CreateObjectSet(Of Database.Entities.JobComponentUserDefinedValue5)(Database.ObjectContext.Properties.JobComponentUserDefinedValue5.ToString)

                End If

                JobComponentUserDefinedValue5 = _JobComponentUserDefinedValue5

            End Get
        End Property
        Public ReadOnly Property JobComponentViews() As System.Data.Objects.ObjectSet(Of Database.Views.JobComponentView)
            Get

                If _JobComponentViews Is Nothing Then

                    _JobComponentViews = MyBase.CreateObjectSet(Of Database.Views.JobComponentView)(Database.ObjectContext.Properties.JobComponentViews.ToString)

                End If

                JobComponentViews = _JobComponentViews

            End Get
        End Property
        Public ReadOnly Property JobProcessLogs() As System.Data.Objects.ObjectSet(Of Database.Entities.JobProcessLog)
            Get

                If _JobProcessLogs Is Nothing Then

                    _JobProcessLogs = MyBase.CreateObjectSet(Of Database.Entities.JobProcessLog)(Database.ObjectContext.Properties.JobProcessLogs.ToString)

                End If

                JobProcessLogs = _JobProcessLogs

            End Get
        End Property
        Public ReadOnly Property Jobs() As System.Data.Objects.ObjectSet(Of Database.Entities.Job)
            Get

                If _Jobs Is Nothing Then

                    _Jobs = MyBase.CreateObjectSet(Of Database.Entities.Job)(Database.ObjectContext.Properties.Jobs.ToString)

                End If

                Jobs = _Jobs

            End Get
        End Property
        Public ReadOnly Property JobServiceFees() As System.Data.Objects.ObjectSet(Of Database.Entities.JobServiceFee)
            Get

                If _JobServiceFees Is Nothing Then

                    _JobServiceFees = MyBase.CreateObjectSet(Of Database.Entities.JobServiceFee)(Database.ObjectContext.Properties.JobServiceFees.ToString)

                End If

                JobServiceFees = _JobServiceFees

            End Get
        End Property
        Public ReadOnly Property JobSpecificationCategories() As System.Data.Objects.ObjectSet(Of Database.Entities.JobSpecificationCategory)
            Get

                If _JobSpecificationCategories Is Nothing Then

                    _JobSpecificationCategories = MyBase.CreateObjectSet(Of Database.Entities.JobSpecificationCategory)(Database.ObjectContext.Properties.JobSpecificationCategories.ToString)

                End If

                JobSpecificationCategories = _JobSpecificationCategories

            End Get
        End Property
        Public ReadOnly Property JobSpecificationFields() As System.Data.Objects.ObjectSet(Of Database.Entities.JobSpecificationField)
            Get

                If _JobSpecificationFields Is Nothing Then

                    _JobSpecificationFields = MyBase.CreateObjectSet(Of Database.Entities.JobSpecificationField)(Database.ObjectContext.Properties.JobSpecificationFields.ToString)

                End If

                JobSpecificationFields = _JobSpecificationFields

            End Get
        End Property
        Public ReadOnly Property JobSpecificationTypes() As System.Data.Objects.ObjectSet(Of Database.Entities.JobSpecificationType)
            Get

                If _JobSpecificationTypes Is Nothing Then

                    _JobSpecificationTypes = MyBase.CreateObjectSet(Of Database.Entities.JobSpecificationType)(Database.ObjectContext.Properties.JobSpecificationTypes.ToString)

                End If

                JobSpecificationTypes = _JobSpecificationTypes

            End Get
        End Property
        Public ReadOnly Property JobSpecificationVendorTabs() As System.Data.Objects.ObjectSet(Of Database.Entities.JobSpecificationVendorTab)
            Get

                If _JobSpecificationVendorTabs Is Nothing Then

                    _JobSpecificationVendorTabs = MyBase.CreateObjectSet(Of Database.Entities.JobSpecificationVendorTab)(Database.ObjectContext.Properties.JobSpecificationVendorTabs.ToString)

                End If

                JobSpecificationVendorTabs = _JobSpecificationVendorTabs

            End Get
        End Property
        Public ReadOnly Property JobTemplates() As System.Data.Objects.ObjectSet(Of Database.Entities.JobTemplate)
            Get

                If _JobTemplates Is Nothing Then

                    _JobTemplates = MyBase.CreateObjectSet(Of Database.Entities.JobTemplate)(Database.ObjectContext.Properties.JobTemplates.ToString)

                End If

                JobTemplates = _JobTemplates

            End Get
        End Property
        Public ReadOnly Property JobTemplateDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.JobTemplateDetail)
            Get

                If _JobTemplateDetails Is Nothing Then

                    _JobTemplateDetails = MyBase.CreateObjectSet(Of Database.Entities.JobTemplateDetail)(Database.ObjectContext.Properties.JobTemplateDetails.ToString)

                End If

                JobTemplateDetails = _JobTemplateDetails

            End Get
        End Property
        Public ReadOnly Property JobTemplateItems() As System.Data.Objects.ObjectSet(Of Database.Entities.JobTemplateItem)
            Get

                If _JobTemplateItems Is Nothing Then

                    _JobTemplateItems = MyBase.CreateObjectSet(Of Database.Entities.JobTemplateItem)(Database.ObjectContext.Properties.JobTemplateItems.ToString)

                End If

                JobTemplateItems = _JobTemplateItems

            End Get
        End Property
        Public ReadOnly Property JobTraffic() As System.Data.Objects.ObjectSet(Of Database.Entities.JobTraffic)
            Get

                If _JobTraffic Is Nothing Then

                    _JobTraffic = MyBase.CreateObjectSet(Of Database.Entities.JobTraffic)(Database.ObjectContext.Properties.JobTraffic.ToString)

                End If

                JobTraffic = _JobTraffic

            End Get
        End Property
        Public ReadOnly Property JobTrafficPredecessor() As System.Data.Objects.ObjectSet(Of Database.Entities.JobTrafficPredecessors)
            Get

                If _JobTrafficPredecessor Is Nothing Then

                    _JobTrafficPredecessor = MyBase.CreateObjectSet(Of Database.Entities.JobTrafficPredecessors)(Database.ObjectContext.Properties.JobTrafficPredecessor.ToString)

                End If

                JobTrafficPredecessor = _JobTrafficPredecessor

            End Get
        End Property
        Public ReadOnly Property JobTrafficSetupDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.JobTrafficSetupDetail)
            Get

                If _JobTrafficSetupDetails Is Nothing Then

                    _JobTrafficSetupDetails = MyBase.CreateObjectSet(Of Database.Entities.JobTrafficSetupDetail)(Database.ObjectContext.Properties.JobTrafficSetupDetails.ToString)

                End If

                JobTrafficSetupDetails = _JobTrafficSetupDetails

            End Get
        End Property
        Public ReadOnly Property JobTrafficSetupItems() As System.Data.Objects.ObjectSet(Of Database.Entities.JobTrafficSetupItem)
            Get

                If _JobTrafficSetupItems Is Nothing Then

                    _JobTrafficSetupItems = MyBase.CreateObjectSet(Of Database.Entities.JobTrafficSetupItem)(Database.ObjectContext.Properties.JobTrafficSetupItems.ToString)

                End If

                JobTrafficSetupItems = _JobTrafficSetupItems

            End Get
        End Property
        Public ReadOnly Property JobTrafficTemplates() As System.Data.Objects.ObjectSet(Of Database.Entities.JobTrafficTemplate)
            Get

                If _JobTrafficTemplates Is Nothing Then

                    _JobTrafficTemplates = MyBase.CreateObjectSet(Of Database.Entities.JobTrafficTemplate)(Database.ObjectContext.Properties.JobTrafficTemplates.ToString)

                End If

                JobTrafficTemplates = _JobTrafficTemplates

            End Get
        End Property
        Public ReadOnly Property JobTrafficVersions() As System.Data.Objects.ObjectSet(Of Database.Entities.JobTrafficVersion)
            Get

                If _JobTrafficVersions Is Nothing Then

                    _JobTrafficVersions = MyBase.CreateObjectSet(Of Database.Entities.JobTrafficVersion)(Database.ObjectContext.Properties.JobTrafficVersions.ToString)

                End If

                JobTrafficVersions = _JobTrafficVersions

            End Get
        End Property
        Public ReadOnly Property JobTypes() As System.Data.Objects.ObjectSet(Of Database.Entities.JobType)
            Get

                If _JobTypes Is Nothing Then

                    _JobTypes = MyBase.CreateObjectSet(Of Database.Entities.JobType)(Database.ObjectContext.Properties.JobTypes.ToString)

                End If

                JobTypes = _JobTypes

            End Get
        End Property
        Public ReadOnly Property JobUserDefinedValue1() As System.Data.Objects.ObjectSet(Of Database.Entities.JobUserDefinedValue1)
            Get

                If _JobUserDefinedValue1 Is Nothing Then

                    _JobUserDefinedValue1 = MyBase.CreateObjectSet(Of Database.Entities.JobUserDefinedValue1)(Database.ObjectContext.Properties.JobUserDefinedValue1.ToString)

                End If

                JobUserDefinedValue1 = _JobUserDefinedValue1

            End Get
        End Property
        Public ReadOnly Property JobUserDefinedValue2() As System.Data.Objects.ObjectSet(Of Database.Entities.JobUserDefinedValue2)
            Get

                If _JobUserDefinedValue2 Is Nothing Then

                    _JobUserDefinedValue2 = MyBase.CreateObjectSet(Of Database.Entities.JobUserDefinedValue2)(Database.ObjectContext.Properties.JobUserDefinedValue2.ToString)

                End If

                JobUserDefinedValue2 = _JobUserDefinedValue2

            End Get
        End Property
        Public ReadOnly Property JobUserDefinedValue3() As System.Data.Objects.ObjectSet(Of Database.Entities.JobUserDefinedValue3)
            Get

                If _JobUserDefinedValue3 Is Nothing Then

                    _JobUserDefinedValue3 = MyBase.CreateObjectSet(Of Database.Entities.JobUserDefinedValue3)(Database.ObjectContext.Properties.JobUserDefinedValue3.ToString)

                End If

                JobUserDefinedValue3 = _JobUserDefinedValue3

            End Get
        End Property
        Public ReadOnly Property JobUserDefinedValue4() As System.Data.Objects.ObjectSet(Of Database.Entities.JobUserDefinedValue4)
            Get

                If _JobUserDefinedValue4 Is Nothing Then

                    _JobUserDefinedValue4 = MyBase.CreateObjectSet(Of Database.Entities.JobUserDefinedValue4)(Database.ObjectContext.Properties.JobUserDefinedValue4.ToString)

                End If

                JobUserDefinedValue4 = _JobUserDefinedValue4

            End Get
        End Property
        Public ReadOnly Property JobUserDefinedValue5() As System.Data.Objects.ObjectSet(Of Database.Entities.JobUserDefinedValue5)
            Get

                If _JobUserDefinedValue5 Is Nothing Then

                    _JobUserDefinedValue5 = MyBase.CreateObjectSet(Of Database.Entities.JobUserDefinedValue5)(Database.ObjectContext.Properties.JobUserDefinedValue5.ToString)

                End If

                JobUserDefinedValue5 = _JobUserDefinedValue5

            End Get
        End Property
        Public ReadOnly Property JobVersionDatabaseTypes() As System.Data.Objects.ObjectSet(Of Database.Entities.JobVersionDatabaseType)
            Get

                If _JobVersionDatabaseTypes Is Nothing Then

                    _JobVersionDatabaseTypes = MyBase.CreateObjectSet(Of Database.Entities.JobVersionDatabaseType)(Database.ObjectContext.Properties.JobVersionDatabaseTypes.ToString)

                End If

                JobVersionDatabaseTypes = _JobVersionDatabaseTypes

            End Get
        End Property
        Public ReadOnly Property JobVersionTemplateDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.JobVersionTemplateDetail)
            Get

                If _JobVersionTemplateDetails Is Nothing Then

                    _JobVersionTemplateDetails = MyBase.CreateObjectSet(Of Database.Entities.JobVersionTemplateDetail)(Database.ObjectContext.Properties.JobVersionTemplateDetails.ToString)

                End If

                JobVersionTemplateDetails = _JobVersionTemplateDetails

            End Get
        End Property
        Public ReadOnly Property JobVersionTemplates() As System.Data.Objects.ObjectSet(Of Database.Entities.JobVersionTemplate)
            Get

                If _JobVersionTemplates Is Nothing Then

                    _JobVersionTemplates = MyBase.CreateObjectSet(Of Database.Entities.JobVersionTemplate)(Database.ObjectContext.Properties.JobVersionTemplates.ToString)

                End If

                JobVersionTemplates = _JobVersionTemplates

            End Get
        End Property
        Public ReadOnly Property JobViews() As System.Data.Objects.ObjectSet(Of Database.Views.JobView)
            Get

                If _JobViews Is Nothing Then

                    _JobViews = MyBase.CreateObjectSet(Of Database.Views.JobView)(Database.ObjectContext.Properties.JobViews.ToString)

                End If

                JobViews = _JobViews

            End Get
        End Property
        Public ReadOnly Property MagazineDetails() As System.Data.Objects.ObjectSet(Of Database.Views.MagazineDetail)
            Get

                If _MagazineDetails Is Nothing Then

                    _MagazineDetails = MyBase.CreateObjectSet(Of Database.Views.MagazineDetail)(Database.ObjectContext.Properties.MagazineDetails.ToString)

                End If

                MagazineDetails = _MagazineDetails

            End Get
        End Property
        Public ReadOnly Property MagazineOrderDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.MagazineOrderDetail)
            Get

                If _MagazineOrderDetails Is Nothing Then

                    _MagazineOrderDetails = MyBase.CreateObjectSet(Of Database.Entities.MagazineOrderDetail)(Database.ObjectContext.Properties.MagazineOrderDetails.ToString)

                End If

                MagazineOrderDetails = _MagazineOrderDetails

            End Get
        End Property
        Public ReadOnly Property MagazineOrders() As System.Data.Objects.ObjectSet(Of Database.Entities.MagazineOrder)
            Get

                If _MagazineOrders Is Nothing Then

                    _MagazineOrders = MyBase.CreateObjectSet(Of Database.Entities.MagazineOrder)(Database.ObjectContext.Properties.MagazineOrders.ToString)

                End If

                MagazineOrders = _MagazineOrders

            End Get
        End Property
        Public ReadOnly Property Magazines() As System.Data.Objects.ObjectSet(Of Database.Views.Magazine)
            Get

                If _Magazines Is Nothing Then

                    _Magazines = MyBase.CreateObjectSet(Of Database.Views.Magazine)(Database.ObjectContext.Properties.Magazines.ToString)

                End If

                Magazines = _Magazines

            End Get
        End Property
        Public ReadOnly Property ManagementLevels() As System.Data.Objects.ObjectSet(Of Database.Entities.ManagementLevel)
            Get

                If _ManagementLevels Is Nothing Then

                    _ManagementLevels = MyBase.CreateObjectSet(Of Database.Entities.ManagementLevel)(Database.ObjectContext.Properties.ManagementLevels.ToString)

                End If

                ManagementLevels = _ManagementLevels

            End Get
        End Property
        Public ReadOnly Property Markets() As System.Data.Objects.ObjectSet(Of Database.Entities.Market)
            Get

                If _Markets Is Nothing Then

                    _Markets = MyBase.CreateObjectSet(Of Database.Entities.Market)(Database.ObjectContext.Properties.Markets.ToString)

                End If

                Markets = _Markets

            End Get
        End Property
        Public ReadOnly Property MediaATBRevisionDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.MediaATBRevisionDetail)
            Get

                If _MediaATBRevisionDetails Is Nothing Then

                    _MediaATBRevisionDetails = MyBase.CreateObjectSet(Of Database.Entities.MediaATBRevisionDetail)(Database.ObjectContext.Properties.MediaATBRevisionDetails.ToString)

                End If

                MediaATBRevisionDetails = _MediaATBRevisionDetails

            End Get
        End Property
        Public ReadOnly Property MediaATBRevisions() As System.Data.Objects.ObjectSet(Of Database.Entities.MediaATBRevision)
            Get

                If _MediaATBRevisions Is Nothing Then

                    _MediaATBRevisions = MyBase.CreateObjectSet(Of Database.Entities.MediaATBRevision)(Database.ObjectContext.Properties.MediaATBRevisions.ToString)

                End If

                MediaATBRevisions = _MediaATBRevisions

            End Get
        End Property
        Public ReadOnly Property MediaATBs() As System.Data.Objects.ObjectSet(Of Database.Entities.MediaATB)
            Get

                If _MediaATBs Is Nothing Then

                    _MediaATBs = MyBase.CreateObjectSet(Of Database.Entities.MediaATB)(Database.ObjectContext.Properties.MediaATBs.ToString)

                End If

                MediaATBs = _MediaATBs

            End Get
        End Property
        Public ReadOnly Property MediaInvoiceDefaults() As System.Data.Objects.ObjectSet(Of Database.Entities.MediaInvoiceDefault)
            Get

                If _MediaInvoiceDefaults Is Nothing Then

                    _MediaInvoiceDefaults = MyBase.CreateObjectSet(Of Database.Entities.MediaInvoiceDefault)(Database.ObjectContext.Properties.MediaInvoiceDefaults.ToString)

                End If

                MediaInvoiceDefaults = _MediaInvoiceDefaults

            End Get
        End Property
        Public ReadOnly Property MediaOrders() As System.Data.Objects.ObjectSet(Of Database.Views.MediaOrder)
            Get

                If _MediaOrders Is Nothing Then

                    _MediaOrders = MyBase.CreateObjectSet(Of Database.Views.MediaOrder)(Database.ObjectContext.Properties.MediaOrders.ToString)

                End If

                MediaOrders = _MediaOrders

            End Get
        End Property
        Public ReadOnly Property MediaPlanDatas() As System.Data.Objects.ObjectSet(Of Database.Views.MediaPlanData)
            Get

                If _MediaPlanDatas Is Nothing Then

                    _MediaPlanDatas = MyBase.CreateObjectSet(Of Database.Views.MediaPlanData)(Database.ObjectContext.Properties.MediaPlanDatas.ToString)

                End If

                MediaPlanDatas = _MediaPlanDatas

            End Get
        End Property
        Public ReadOnly Property MediaPlanDetailChangeLogs() As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanDetailChangeLog)
            Get

                If _MediaPlanDetailChangeLogs Is Nothing Then

                    _MediaPlanDetailChangeLogs = MyBase.CreateObjectSet(Of Database.Entities.MediaPlanDetailChangeLog)(Database.ObjectContext.Properties.MediaPlanDetailChangeLogs.ToString)

                End If

                MediaPlanDetailChangeLogs = _MediaPlanDetailChangeLogs

            End Get
        End Property
        Public ReadOnly Property MediaPlanDetailFields() As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanDetailField)
            Get

                If _MediaPlanDetailFields Is Nothing Then

                    _MediaPlanDetailFields = MyBase.CreateObjectSet(Of Database.Entities.MediaPlanDetailField)(Database.ObjectContext.Properties.MediaPlanDetailFields.ToString)

                End If

                MediaPlanDetailFields = _MediaPlanDetailFields

            End Get
        End Property
        Public ReadOnly Property MediaPlanDetailLevelLineDatas() As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanDetailLevelLineData)
            Get

                If _MediaPlanDetailLevelLineDatas Is Nothing Then

                    _MediaPlanDetailLevelLineDatas = MyBase.CreateObjectSet(Of Database.Entities.MediaPlanDetailLevelLineData)(Database.ObjectContext.Properties.MediaPlanDetailLevelLineDatas.ToString)

                End If

                MediaPlanDetailLevelLineDatas = _MediaPlanDetailLevelLineDatas

            End Get
        End Property
        Public ReadOnly Property MediaPlanDetailLevelLines() As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanDetailLevelLine)
            Get

                If _MediaPlanDetailLevelLines Is Nothing Then

                    _MediaPlanDetailLevelLines = MyBase.CreateObjectSet(Of Database.Entities.MediaPlanDetailLevelLine)(Database.ObjectContext.Properties.MediaPlanDetailLevelLines.ToString)

                End If

                MediaPlanDetailLevelLines = _MediaPlanDetailLevelLines

            End Get
        End Property
        Public ReadOnly Property MediaPlanDetailLevelLineTags() As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanDetailLevelLineTag)
            Get

                If _MediaPlanDetailLevelLineTags Is Nothing Then

                    _MediaPlanDetailLevelLineTags = MyBase.CreateObjectSet(Of Database.Entities.MediaPlanDetailLevelLineTag)(Database.ObjectContext.Properties.MediaPlanDetailLevelLineTags.ToString)

                End If

                MediaPlanDetailLevelLineTags = _MediaPlanDetailLevelLineTags

            End Get
        End Property
        Public ReadOnly Property MediaPlanDetailLevels() As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanDetailLevel)
            Get

                If _MediaPlanDetailLevels Is Nothing Then

                    _MediaPlanDetailLevels = MyBase.CreateObjectSet(Of Database.Entities.MediaPlanDetailLevel)(Database.ObjectContext.Properties.MediaPlanDetailLevels.ToString)

                End If

                MediaPlanDetailLevels = _MediaPlanDetailLevels

            End Get
        End Property
        Public ReadOnly Property MediaPlanDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanDetail)
            Get

                If _MediaPlanDetails Is Nothing Then

                    _MediaPlanDetails = MyBase.CreateObjectSet(Of Database.Entities.MediaPlanDetail)(Database.ObjectContext.Properties.MediaPlanDetails.ToString)

                End If

                MediaPlanDetails = _MediaPlanDetails

            End Get
        End Property
        Public ReadOnly Property MediaPlanDetailSettings() As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanDetailSetting)
            Get

                If _MediaPlanDetailSettings Is Nothing Then

                    _MediaPlanDetailSettings = MyBase.CreateObjectSet(Of Database.Entities.MediaPlanDetailSetting)(Database.ObjectContext.Properties.MediaPlanDetailSettings.ToString)

                End If

                MediaPlanDetailSettings = _MediaPlanDetailSettings

            End Get
        End Property
        Public ReadOnly Property MediaPlanMasterPlanDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanMasterPlanDetail)
            Get

                If _MediaPlanMasterPlanDetails Is Nothing Then

                    _MediaPlanMasterPlanDetails = MyBase.CreateObjectSet(Of Database.Entities.MediaPlanMasterPlanDetail)(Database.ObjectContext.Properties.MediaPlanMasterPlanDetails.ToString)

                End If

                MediaPlanMasterPlanDetails = _MediaPlanMasterPlanDetails

            End Get
        End Property
        Public ReadOnly Property MediaPlanMasterPlans() As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlanMasterPlan)
            Get

                If _MediaPlanMasterPlans Is Nothing Then

                    _MediaPlanMasterPlans = MyBase.CreateObjectSet(Of Database.Entities.MediaPlanMasterPlan)(Database.ObjectContext.Properties.MediaPlanMasterPlans.ToString)

                End If

                MediaPlanMasterPlans = _MediaPlanMasterPlans

            End Get
        End Property
        Public ReadOnly Property MediaPlans() As System.Data.Objects.ObjectSet(Of Database.Entities.MediaPlan)
            Get

                If _MediaPlans Is Nothing Then

                    _MediaPlans = MyBase.CreateObjectSet(Of Database.Entities.MediaPlan)(Database.ObjectContext.Properties.MediaPlans.ToString)

                End If

                MediaPlans = _MediaPlans

            End Get
        End Property
        Public ReadOnly Property MediaSpecsDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.MediaSpecsDetail)
            Get

                If _MediaSpecsDetails Is Nothing Then

                    _MediaSpecsDetails = MyBase.CreateObjectSet(Of Database.Entities.MediaSpecsDetail)(Database.ObjectContext.Properties.MediaSpecsDetails.ToString)

                End If

                MediaSpecsDetails = _MediaSpecsDetails

            End Get
        End Property
        Public ReadOnly Property MediaSpecsHeaders() As System.Data.Objects.ObjectSet(Of Database.Entities.MediaSpecsHeader)
            Get

                If _MediaSpecsHeaders Is Nothing Then

                    _MediaSpecsHeaders = MyBase.CreateObjectSet(Of Database.Entities.MediaSpecsHeader)(Database.ObjectContext.Properties.MediaSpecsHeaders.ToString)

                End If

                MediaSpecsHeaders = _MediaSpecsHeaders

            End Get
        End Property
        Public ReadOnly Property MyObjectDefinitionAvailableOptions() As System.Data.Objects.ObjectSet(Of Database.Entities.MyObjectDefinitionAvailableOption)
            Get

                If _MyObjectDefinitionAvailableOptions Is Nothing Then

                    _MyObjectDefinitionAvailableOptions = MyBase.CreateObjectSet(Of Database.Entities.MyObjectDefinitionAvailableOption)(Database.ObjectContext.Properties.MyObjectDefinitionAvailableOptions.ToString)

                End If

                MyObjectDefinitionAvailableOptions = _MyObjectDefinitionAvailableOptions

            End Get
        End Property
        Public ReadOnly Property MyObjectDefinitionObjects() As System.Data.Objects.ObjectSet(Of Database.Entities.MyObjectDefinitionObject)
            Get

                If _MyObjectDefinitionObjects Is Nothing Then

                    _MyObjectDefinitionObjects = MyBase.CreateObjectSet(Of Database.Entities.MyObjectDefinitionObject)(Database.ObjectContext.Properties.MyObjectDefinitionObjects.ToString)

                End If

                MyObjectDefinitionObjects = _MyObjectDefinitionObjects

            End Get
        End Property
        Public ReadOnly Property MyObjectDefinitionSettings() As System.Data.Objects.ObjectSet(Of Database.Entities.MyObjectDefinitionSetting)
            Get

                If _MyObjectDefinitionSettings Is Nothing Then

                    _MyObjectDefinitionSettings = MyBase.CreateObjectSet(Of Database.Entities.MyObjectDefinitionSetting)(Database.ObjectContext.Properties.MyObjectDefinitionSettings.ToString)

                End If

                MyObjectDefinitionSettings = _MyObjectDefinitionSettings

            End Get
        End Property
        Public ReadOnly Property MyObjectDefinitionStaticOptions() As System.Data.Objects.ObjectSet(Of Database.Entities.MyObjectDefinitionStaticOption)
            Get

                If _MyObjectDefinitionStaticOptions Is Nothing Then

                    _MyObjectDefinitionStaticOptions = MyBase.CreateObjectSet(Of Database.Entities.MyObjectDefinitionStaticOption)(Database.ObjectContext.Properties.MyObjectDefinitionStaticOptions.ToString)

                End If

                MyObjectDefinitionStaticOptions = _MyObjectDefinitionStaticOptions

            End Get
        End Property
        Public ReadOnly Property NewspaperDetails() As System.Data.Objects.ObjectSet(Of Database.Views.NewspaperDetail)
            Get

                If _NewspaperDetails Is Nothing Then

                    _NewspaperDetails = MyBase.CreateObjectSet(Of Database.Views.NewspaperDetail)(Database.ObjectContext.Properties.NewspaperDetails.ToString)

                End If

                NewspaperDetails = _NewspaperDetails

            End Get
        End Property
        Public ReadOnly Property NewspaperHeaders() As System.Data.Objects.ObjectSet(Of Database.Views.NewspaperHeader)
            Get

                If _NewspaperHeaders Is Nothing Then

                    _NewspaperHeaders = MyBase.CreateObjectSet(Of Database.Views.NewspaperHeader)(Database.ObjectContext.Properties.NewspaperHeaders.ToString)

                End If

                NewspaperHeaders = _NewspaperHeaders

            End Get
        End Property
        Public ReadOnly Property NewspaperOrderDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.NewspaperOrderDetail)
            Get

                If _NewspaperOrderDetails Is Nothing Then

                    _NewspaperOrderDetails = MyBase.CreateObjectSet(Of Database.Entities.NewspaperOrderDetail)(Database.ObjectContext.Properties.NewspaperOrderDetails.ToString)

                End If

                NewspaperOrderDetails = _NewspaperOrderDetails

            End Get
        End Property
        Public ReadOnly Property NewspaperOrders() As System.Data.Objects.ObjectSet(Of Database.Entities.NewspaperOrder)
            Get

                If _NewspaperOrders Is Nothing Then

                    _NewspaperOrders = MyBase.CreateObjectSet(Of Database.Entities.NewspaperOrder)(Database.ObjectContext.Properties.NewspaperOrders.ToString)

                End If

                NewspaperOrders = _NewspaperOrders

            End Get
        End Property
        Public ReadOnly Property OfficeDocuments() As System.Data.Objects.ObjectSet(Of Database.Entities.OfficeDocument)
            Get

                If _OfficeDocuments Is Nothing Then

                    _OfficeDocuments = MyBase.CreateObjectSet(Of Database.Entities.OfficeDocument)(Database.ObjectContext.Properties.OfficeDocuments.ToString)

                End If

                OfficeDocuments = _OfficeDocuments

            End Get
        End Property
        Public ReadOnly Property OfficeFunctionAccounts() As System.Data.Objects.ObjectSet(Of Database.Entities.OfficeFunctionAccount)
            Get

                If _OfficeFunctionAccounts Is Nothing Then

                    _OfficeFunctionAccounts = MyBase.CreateObjectSet(Of Database.Entities.OfficeFunctionAccount)(Database.ObjectContext.Properties.OfficeFunctionAccounts.ToString)

                End If

                OfficeFunctionAccounts = _OfficeFunctionAccounts

            End Get
        End Property
        Public ReadOnly Property OfficeInterCompanies() As System.Data.Objects.ObjectSet(Of Database.Entities.OfficeInterCompany)
            Get

                If _OfficeInterCompanies Is Nothing Then

                    _OfficeInterCompanies = MyBase.CreateObjectSet(Of Database.Entities.OfficeInterCompany)(Database.ObjectContext.Properties.OfficeInterCompanies.ToString)

                End If

                OfficeInterCompanies = _OfficeInterCompanies

            End Get
        End Property
        Public ReadOnly Property Offices() As System.Data.Objects.ObjectSet(Of Database.Entities.Office)
            Get

                If _Offices Is Nothing Then

                    _Offices = MyBase.CreateObjectSet(Of Database.Entities.Office)(Database.ObjectContext.Properties.Offices.ToString)

                End If

                Offices = _Offices

            End Get
        End Property
        Public ReadOnly Property OfficeSalesClassAccounts() As System.Data.Objects.ObjectSet(Of Database.Entities.OfficeSalesClassAccount)
            Get

                If _OfficeSalesClassAccounts Is Nothing Then

                    _OfficeSalesClassAccounts = MyBase.CreateObjectSet(Of Database.Entities.OfficeSalesClassAccount)(Database.ObjectContext.Properties.OfficeSalesClassAccounts.ToString)

                End If

                OfficeSalesClassAccounts = _OfficeSalesClassAccounts

            End Get
        End Property
        Public ReadOnly Property OfficeSalesClassFunctionAccounts() As System.Data.Objects.ObjectSet(Of Database.Entities.OfficeSalesClassFunctionAccount)
            Get

                If _OfficeSalesClassFunctionAccounts Is Nothing Then

                    _OfficeSalesClassFunctionAccounts = MyBase.CreateObjectSet(Of Database.Entities.OfficeSalesClassFunctionAccount)(Database.ObjectContext.Properties.OfficeSalesClassFunctionAccounts.ToString)

                End If

                OfficeSalesClassFunctionAccounts = _OfficeSalesClassFunctionAccounts

            End Get
        End Property
        Public ReadOnly Property OfficeSalesTaxAccounts() As System.Data.Objects.ObjectSet(Of Database.Entities.OfficeSalesTaxAccount)
            Get

                If _OfficeSalesTaxAccounts Is Nothing Then

                    _OfficeSalesTaxAccounts = MyBase.CreateObjectSet(Of Database.Entities.OfficeSalesTaxAccount)(Database.ObjectContext.Properties.OfficeSalesTaxAccounts.ToString)

                End If

                OfficeSalesTaxAccounts = _OfficeSalesTaxAccounts

            End Get
        End Property
        Public ReadOnly Property OtherCashReceiptDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.OtherCashReceiptDetail)
            Get

                If _OtherCashReceiptDetails Is Nothing Then

                    _OtherCashReceiptDetails = MyBase.CreateObjectSet(Of Database.Entities.OtherCashReceiptDetail)(Database.ObjectContext.Properties.OtherCashReceiptDetails.ToString)

                End If

                OtherCashReceiptDetails = _OtherCashReceiptDetails

            End Get
        End Property
        Public ReadOnly Property OtherCashReceipts() As System.Data.Objects.ObjectSet(Of Database.Entities.OtherCashReceipt)
            Get

                If _OtherCashReceipts Is Nothing Then

                    _OtherCashReceipts = MyBase.CreateObjectSet(Of Database.Entities.OtherCashReceipt)(Database.ObjectContext.Properties.OtherCashReceipts.ToString)

                End If

                OtherCashReceipts = _OtherCashReceipts

            End Get
        End Property
        Public ReadOnly Property OutOfHomeOrderDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.OutOfHomeOrderDetail)
            Get

                If _OutOfHomeOrderDetails Is Nothing Then

                    _OutOfHomeOrderDetails = MyBase.CreateObjectSet(Of Database.Entities.OutOfHomeOrderDetail)(Database.ObjectContext.Properties.OutOfHomeOrderDetails.ToString)

                End If

                OutOfHomeOrderDetails = _OutOfHomeOrderDetails

            End Get
        End Property
        Public ReadOnly Property OutOfHomeOrders() As System.Data.Objects.ObjectSet(Of Database.Entities.OutOfHomeOrder)
            Get

                If _OutOfHomeOrders Is Nothing Then

                    _OutOfHomeOrders = MyBase.CreateObjectSet(Of Database.Entities.OutOfHomeOrder)(Database.ObjectContext.Properties.OutOfHomeOrders.ToString)

                End If

                OutOfHomeOrders = _OutOfHomeOrders

            End Get
        End Property
        Public ReadOnly Property OutOfHomeTypes() As System.Data.Objects.ObjectSet(Of Database.Entities.OutOfHomeType)
            Get

                If _OutOfHomeTypes Is Nothing Then

                    _OutOfHomeTypes = MyBase.CreateObjectSet(Of Database.Entities.OutOfHomeType)(Database.ObjectContext.Properties.OutOfHomeTypes.ToString)

                End If

                OutOfHomeTypes = _OutOfHomeTypes

            End Get
        End Property
        Public ReadOnly Property OverheadAccounts() As System.Data.Objects.ObjectSet(Of Database.Entities.OverheadAccount)
            Get

                If _OverheadAccounts Is Nothing Then

                    _OverheadAccounts = MyBase.CreateObjectSet(Of Database.Entities.OverheadAccount)(Database.ObjectContext.Properties.OverheadAccounts.ToString)

                End If

                OverheadAccounts = _OverheadAccounts

            End Get
        End Property
        Public ReadOnly Property PartnerAllocationDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.PartnerAllocationDetail)
            Get

                If _PartnerAllocationDetails Is Nothing Then

                    _PartnerAllocationDetails = MyBase.CreateObjectSet(Of Database.Entities.PartnerAllocationDetail)(Database.ObjectContext.Properties.PartnerAllocationDetails.ToString)

                End If

                PartnerAllocationDetails = _PartnerAllocationDetails

            End Get
        End Property
        Public ReadOnly Property PartnerAllocations() As System.Data.Objects.ObjectSet(Of Database.Entities.PartnerAllocation)
            Get

                If _PartnerAllocations Is Nothing Then

                    _PartnerAllocations = MyBase.CreateObjectSet(Of Database.Entities.PartnerAllocation)(Database.ObjectContext.Properties.PartnerAllocations.ToString)

                End If

                PartnerAllocations = _PartnerAllocations

            End Get
        End Property
        Public ReadOnly Property Partners() As System.Data.Objects.ObjectSet(Of Database.Entities.Partner)
            Get

                If _Partners Is Nothing Then

                    _Partners = MyBase.CreateObjectSet(Of Database.Entities.Partner)(Database.ObjectContext.Properties.Partners.ToString)

                End If

                Partners = _Partners

            End Get
        End Property
        Public ReadOnly Property Phases() As System.Data.Objects.ObjectSet(Of Database.Entities.Phase)
            Get

                If _Phases Is Nothing Then

                    _Phases = MyBase.CreateObjectSet(Of Database.Entities.Phase)(Database.ObjectContext.Properties.Phases.ToString)

                End If

                Phases = _Phases

            End Get
        End Property
        Public ReadOnly Property POApprovals() As System.Data.Objects.ObjectSet(Of Database.Entities.POApproval)
            Get

                If _POApprovals Is Nothing Then

                    _POApprovals = MyBase.CreateObjectSet(Of Database.Entities.POApproval)(Database.ObjectContext.Properties.POApprovals.ToString)

                End If

                POApprovals = _POApprovals

            End Get
        End Property
        Public ReadOnly Property PostPeriods() As System.Data.Objects.ObjectSet(Of Database.Entities.PostPeriod)
            Get

                If _PostPeriods Is Nothing Then

                    _PostPeriods = MyBase.CreateObjectSet(Of Database.Entities.PostPeriod)(Database.ObjectContext.Properties.PostPeriods.ToString)

                End If

                PostPeriods = _PostPeriods

            End Get
        End Property
        Public ReadOnly Property PrintSpecRegions() As System.Data.Objects.ObjectSet(Of Database.Entities.PrintSpecRegion)
            Get

                If _PrintSpecRegions Is Nothing Then

                    _PrintSpecRegions = MyBase.CreateObjectSet(Of Database.Entities.PrintSpecRegion)(Database.ObjectContext.Properties.PrintSpecRegions.ToString)

                End If

                PrintSpecRegions = _PrintSpecRegions

            End Get
        End Property
        Public ReadOnly Property PrintSpecStatuses() As System.Data.Objects.ObjectSet(Of Database.Entities.PrintSpecStatus)
            Get

                If _PrintSpecStatuses Is Nothing Then

                    _PrintSpecStatuses = MyBase.CreateObjectSet(Of Database.Entities.PrintSpecStatus)(Database.ObjectContext.Properties.PrintSpecStatuses.ToString)

                End If

                PrintSpecStatuses = _PrintSpecStatuses

            End Get
        End Property
        Public ReadOnly Property ProductAccountsReceivableStatements() As System.Data.Objects.ObjectSet(Of Database.Entities.ProductAccountsReceivableStatement)
            Get

                If _ProductAccountsReceivableStatements Is Nothing Then

                    _ProductAccountsReceivableStatements = MyBase.CreateObjectSet(Of Database.Entities.ProductAccountsReceivableStatement)(Database.ObjectContext.Properties.ProductAccountsReceivableStatements.ToString)

                End If

                ProductAccountsReceivableStatements = _ProductAccountsReceivableStatements

            End Get
        End Property
        Public ReadOnly Property ProductCategories() As System.Data.Objects.ObjectSet(Of Database.Entities.ProductCategory)
            Get

                If _ProductCategories Is Nothing Then

                    _ProductCategories = MyBase.CreateObjectSet(Of Database.Entities.ProductCategory)(Database.ObjectContext.Properties.ProductCategories.ToString)

                End If

                ProductCategories = _ProductCategories

            End Get
        End Property
        Public ReadOnly Property ProductionInvoiceDefaults() As System.Data.Objects.ObjectSet(Of Database.Entities.ProductionInvoiceDefault)
            Get

                If _ProductionInvoiceDefaults Is Nothing Then

                    _ProductionInvoiceDefaults = MyBase.CreateObjectSet(Of Database.Entities.ProductionInvoiceDefault)(Database.ObjectContext.Properties.ProductionInvoiceDefaults.ToString)

                End If

                ProductionInvoiceDefaults = _ProductionInvoiceDefaults

            End Get
        End Property
        Public ReadOnly Property Products() As System.Data.Objects.ObjectSet(Of Database.Entities.Product)
            Get

                If _Products Is Nothing Then

                    _Products = MyBase.CreateObjectSet(Of Database.Entities.Product)(Database.ObjectContext.Properties.Products.ToString)

                End If

                Products = _Products

            End Get
        End Property
        Public ReadOnly Property ProductSortKeys() As System.Data.Objects.ObjectSet(Of Database.Entities.ProductSortKey)
            Get

                If _ProductSortKeys Is Nothing Then

                    _ProductSortKeys = MyBase.CreateObjectSet(Of Database.Entities.ProductSortKey)(Database.ObjectContext.Properties.ProductSortKeys.ToString)

                End If

                ProductSortKeys = _ProductSortKeys

            End Get
        End Property
        Public ReadOnly Property ProductViews() As System.Data.Objects.ObjectSet(Of Database.Views.ProductView)
            Get

                If _ProductViews Is Nothing Then

                    _ProductViews = MyBase.CreateObjectSet(Of Database.Views.ProductView)(Database.ObjectContext.Properties.ProductViews.ToString)

                End If

                ProductViews = _ProductViews

            End Get
        End Property
        Public ReadOnly Property PromotionTypes() As System.Data.Objects.ObjectSet(Of Database.Entities.PromotionType)
            Get

                If _PromotionTypes Is Nothing Then

                    _PromotionTypes = MyBase.CreateObjectSet(Of Database.Entities.PromotionType)(Database.ObjectContext.Properties.PromotionTypes.ToString)

                End If

                PromotionTypes = _PromotionTypes

            End Get
        End Property
        Public ReadOnly Property PTORuleDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.PTORuleDetail)
            Get

                If _PTORuleDetails Is Nothing Then

                    _PTORuleDetails = MyBase.CreateObjectSet(Of Database.Entities.PTORuleDetail)(Database.ObjectContext.Properties.PTORuleDetails.ToString)

                End If

                PTORuleDetails = _PTORuleDetails

            End Get
        End Property
        Public ReadOnly Property PTORules() As System.Data.Objects.ObjectSet(Of Database.Entities.PTORule)
            Get

                If _PTORules Is Nothing Then

                    _PTORules = MyBase.CreateObjectSet(Of Database.Entities.PTORule)(Database.ObjectContext.Properties.PTORules.ToString)

                End If

                PTORules = _PTORules

            End Get
        End Property
        Public ReadOnly Property PurchaseOrderApprovalRuleDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.PurchaseOrderApprovalRuleDetail)
            Get

                If _PurchaseOrderApprovalRuleDetails Is Nothing Then

                    _PurchaseOrderApprovalRuleDetails = MyBase.CreateObjectSet(Of Database.Entities.PurchaseOrderApprovalRuleDetail)(Database.ObjectContext.Properties.PurchaseOrderApprovalRuleDetails.ToString)

                End If

                PurchaseOrderApprovalRuleDetails = _PurchaseOrderApprovalRuleDetails

            End Get
        End Property
        Public ReadOnly Property PurchaseOrderApprovalRuleEmployees() As System.Data.Objects.ObjectSet(Of Database.Entities.PurchaseOrderApprovalRuleEmployee)
            Get

                If _PurchaseOrderApprovalRuleEmployees Is Nothing Then

                    _PurchaseOrderApprovalRuleEmployees = MyBase.CreateObjectSet(Of Database.Entities.PurchaseOrderApprovalRuleEmployee)(Database.ObjectContext.Properties.PurchaseOrderApprovalRuleEmployees.ToString)

                End If

                PurchaseOrderApprovalRuleEmployees = _PurchaseOrderApprovalRuleEmployees

            End Get
        End Property
        Public ReadOnly Property PurchaseOrderApprovalRules() As System.Data.Objects.ObjectSet(Of Database.Entities.PurchaseOrderApprovalRule)
            Get

                If _PurchaseOrderApprovalRules Is Nothing Then

                    _PurchaseOrderApprovalRules = MyBase.CreateObjectSet(Of Database.Entities.PurchaseOrderApprovalRule)(Database.ObjectContext.Properties.PurchaseOrderApprovalRules.ToString)

                End If

                PurchaseOrderApprovalRules = _PurchaseOrderApprovalRules

            End Get
        End Property
        Public ReadOnly Property PurchaseOrderDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.PurchaseOrderDetail)
            Get

                If _PurchaseOrderDetails Is Nothing Then

                    _PurchaseOrderDetails = MyBase.CreateObjectSet(Of Database.Entities.PurchaseOrderDetail)(Database.ObjectContext.Properties.PurchaseOrderDetails.ToString)

                End If

                PurchaseOrderDetails = _PurchaseOrderDetails

            End Get
        End Property
        Public ReadOnly Property PurchaseOrderPrintDefaults() As System.Data.Objects.ObjectSet(Of Database.Entities.PurchaseOrderPrintDefault)
            Get

                If _PurchaseOrderPrintDefaults Is Nothing Then

                    _PurchaseOrderPrintDefaults = MyBase.CreateObjectSet(Of Database.Entities.PurchaseOrderPrintDefault)(Database.ObjectContext.Properties.PurchaseOrderPrintDefaults.ToString)

                End If

                PurchaseOrderPrintDefaults = _PurchaseOrderPrintDefaults

            End Get
        End Property
        Public ReadOnly Property PurchaseOrders() As System.Data.Objects.ObjectSet(Of Database.Entities.PurchaseOrder)
            Get

                If _PurchaseOrders Is Nothing Then

                    _PurchaseOrders = MyBase.CreateObjectSet(Of Database.Entities.PurchaseOrder)(Database.ObjectContext.Properties.PurchaseOrders.ToString)

                End If

                PurchaseOrders = _PurchaseOrders

            End Get
        End Property
        Public ReadOnly Property RadioOrderDetailLegacies() As System.Data.Objects.ObjectSet(Of Database.Entities.RadioOrderDetailLegacy)
            Get

                If _RadioOrderDetailLegacies Is Nothing Then

                    _RadioOrderDetailLegacies = MyBase.CreateObjectSet(Of Database.Entities.RadioOrderDetailLegacy)(Database.ObjectContext.Properties.RadioOrderDetailLegacies.ToString)

                End If

                RadioOrderDetailLegacies = _RadioOrderDetailLegacies

            End Get
        End Property
        Public ReadOnly Property RadioOrderDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.RadioOrderDetail)
            Get

                If _RadioOrderDetails Is Nothing Then

                    _RadioOrderDetails = MyBase.CreateObjectSet(Of Database.Entities.RadioOrderDetail)(Database.ObjectContext.Properties.RadioOrderDetails.ToString)

                End If

                RadioOrderDetails = _RadioOrderDetails

            End Get
        End Property
        Public ReadOnly Property RadioOrderLegacies() As System.Data.Objects.ObjectSet(Of Database.Entities.RadioOrderLegacy)
            Get

                If _RadioOrderLegacies Is Nothing Then

                    _RadioOrderLegacies = MyBase.CreateObjectSet(Of Database.Entities.RadioOrderLegacy)(Database.ObjectContext.Properties.RadioOrderLegacies.ToString)

                End If

                RadioOrderLegacies = _RadioOrderLegacies

            End Get
        End Property
        Public ReadOnly Property RadioOrders() As System.Data.Objects.ObjectSet(Of Database.Entities.RadioOrder)
            Get

                If _RadioOrders Is Nothing Then

                    _RadioOrders = MyBase.CreateObjectSet(Of Database.Entities.RadioOrder)(Database.ObjectContext.Properties.RadioOrders.ToString)

                End If

                RadioOrders = _RadioOrders

            End Get
        End Property
        Public ReadOnly Property RateCardColorCharges() As System.Data.Objects.ObjectSet(Of Database.Entities.RateCardColorCharge)
            Get

                If _RateCardColorCharges Is Nothing Then

                    _RateCardColorCharges = MyBase.CreateObjectSet(Of Database.Entities.RateCardColorCharge)(Database.ObjectContext.Properties.RateCardColorCharges.ToString)

                End If

                RateCardColorCharges = _RateCardColorCharges

            End Get
        End Property
        Public ReadOnly Property RateCardDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.RateCardDetail)
            Get

                If _RateCardDetails Is Nothing Then

                    _RateCardDetails = MyBase.CreateObjectSet(Of Database.Entities.RateCardDetail)(Database.ObjectContext.Properties.RateCardDetails.ToString)

                End If

                RateCardDetails = _RateCardDetails

            End Get
        End Property
        Public ReadOnly Property RateCards() As System.Data.Objects.ObjectSet(Of Database.Entities.RateCard)
            Get

                If _RateCards Is Nothing Then

                    _RateCards = MyBase.CreateObjectSet(Of Database.Entities.RateCard)(Database.ObjectContext.Properties.RateCards.ToString)

                End If

                RateCards = _RateCards

            End Get
        End Property
        Public ReadOnly Property Ratings() As System.Data.Objects.ObjectSet(Of Database.Entities.Rating)
            Get

                If _Ratings Is Nothing Then

                    _Ratings = MyBase.CreateObjectSet(Of Database.Entities.Rating)(Database.ObjectContext.Properties.Ratings.ToString)

                End If

                Ratings = _Ratings

            End Get
        End Property
        Public ReadOnly Property RecordSources() As System.Data.Objects.ObjectSet(Of Database.Entities.RecordSource)
            Get

                If _RecordSources Is Nothing Then

                    _RecordSources = MyBase.CreateObjectSet(Of Database.Entities.RecordSource)(Database.ObjectContext.Properties.RecordSources.ToString)

                End If

                RecordSources = _RecordSources

            End Get
        End Property
        Public ReadOnly Property Resources() As System.Data.Objects.ObjectSet(Of Database.Entities.Resource)
            Get

                If _Resources Is Nothing Then

                    _Resources = MyBase.CreateObjectSet(Of Database.Entities.Resource)(Database.ObjectContext.Properties.Resources.ToString)

                End If

                Resources = _Resources

            End Get
        End Property
        Public ReadOnly Property ResourceTasks() As System.Data.Objects.ObjectSet(Of Database.Entities.ResourceTask)
            Get

                If _ResourceTasks Is Nothing Then

                    _ResourceTasks = MyBase.CreateObjectSet(Of Database.Entities.ResourceTask)(Database.ObjectContext.Properties.ResourceTasks.ToString)

                End If

                ResourceTasks = _ResourceTasks

            End Get
        End Property
        Public ReadOnly Property ResourceTypes() As System.Data.Objects.ObjectSet(Of Database.Entities.ResourceType)
            Get

                If _ResourceTypes Is Nothing Then

                    _ResourceTypes = MyBase.CreateObjectSet(Of Database.Entities.ResourceType)(Database.ObjectContext.Properties.ResourceTypes.ToString)

                End If

                ResourceTypes = _ResourceTypes

            End Get
        End Property
        Public ReadOnly Property Roles() As System.Data.Objects.ObjectSet(Of Database.Entities.Role)
            Get

                If _Roles Is Nothing Then

                    _Roles = MyBase.CreateObjectSet(Of Database.Entities.Role)(Database.ObjectContext.Properties.Roles.ToString)

                End If

                Roles = _Roles

            End Get
        End Property
        Public ReadOnly Property SalesClasses() As System.Data.Objects.ObjectSet(Of Database.Entities.SalesClass)
            Get

                If _SalesClasses Is Nothing Then

                    _SalesClasses = MyBase.CreateObjectSet(Of Database.Entities.SalesClass)(Database.ObjectContext.Properties.SalesClasses.ToString)

                End If

                SalesClasses = _SalesClasses

            End Get
        End Property
        Public ReadOnly Property SalesClassFormats() As System.Data.Objects.ObjectSet(Of Database.Entities.SalesClassFormat)
            Get

                If _SalesClassFormats Is Nothing Then

                    _SalesClassFormats = MyBase.CreateObjectSet(Of Database.Entities.SalesClassFormat)(Database.ObjectContext.Properties.SalesClassFormats.ToString)

                End If

                SalesClassFormats = _SalesClassFormats

            End Get
        End Property
        Public ReadOnly Property SalesTaxes() As System.Data.Objects.ObjectSet(Of Database.Entities.SalesTax)
            Get

                If _SalesTaxes Is Nothing Then

                    _SalesTaxes = MyBase.CreateObjectSet(Of Database.Entities.SalesTax)(Database.ObjectContext.Properties.SalesTaxes.ToString)

                End If

                SalesTaxes = _SalesTaxes

            End Get
        End Property
        Public ReadOnly Property ServiceFeeReconcileDetails() As System.Data.Objects.ObjectSet(Of Database.Views.ServiceFeeReconcileDetail)
            Get

                If _ServiceFeeReconcileDetails Is Nothing Then

                    _ServiceFeeReconcileDetails = MyBase.CreateObjectSet(Of Database.Views.ServiceFeeReconcileDetail)(Database.ObjectContext.Properties.ServiceFeeReconcileDetails.ToString)

                End If

                ServiceFeeReconcileDetails = _ServiceFeeReconcileDetails

            End Get
        End Property
        Public ReadOnly Property ServiceFeeTypes() As System.Data.Objects.ObjectSet(Of Database.Entities.ServiceFeeType)
            Get

                If _ServiceFeeTypes Is Nothing Then

                    _ServiceFeeTypes = MyBase.CreateObjectSet(Of Database.Entities.ServiceFeeType)(Database.ObjectContext.Properties.ServiceFeeTypes.ToString)

                End If

                ServiceFeeTypes = _ServiceFeeTypes

            End Get
        End Property
        Public ReadOnly Property Sources() As System.Data.Objects.ObjectSet(Of Database.Entities.Source)
            Get

                If _Sources Is Nothing Then

                    _Sources = MyBase.CreateObjectSet(Of Database.Entities.Source)(Database.ObjectContext.Properties.Sources.ToString)

                End If

                Sources = _Sources

            End Get
        End Property
        Public ReadOnly Property Specialties() As System.Data.Objects.ObjectSet(Of Database.Entities.Specialty)
            Get

                If _Specialties Is Nothing Then

                    _Specialties = MyBase.CreateObjectSet(Of Database.Entities.Specialty)(Database.ObjectContext.Properties.Specialties.ToString)

                End If

                Specialties = _Specialties

            End Get
        End Property
        Public ReadOnly Property StandardComments() As System.Data.Objects.ObjectSet(Of Database.Entities.StandardComment)
            Get

                If _StandardComments Is Nothing Then

                    _StandardComments = MyBase.CreateObjectSet(Of Database.Entities.StandardComment)(Database.ObjectContext.Properties.StandardComments.ToString)

                End If

                StandardComments = _StandardComments

            End Get
        End Property
        Public ReadOnly Property Status() As System.Data.Objects.ObjectSet(Of Database.Entities.Status)
            Get

                If _Status Is Nothing Then

                    _Status = MyBase.CreateObjectSet(Of Database.Entities.Status)(Database.ObjectContext.Properties.Status.ToString)

                End If

                Status = _Status

            End Get
        End Property
        Public ReadOnly Property Tasks() As System.Data.Objects.ObjectSet(Of Database.Entities.Task)
            Get

                If _Tasks Is Nothing Then

                    _Tasks = MyBase.CreateObjectSet(Of Database.Entities.Task)(Database.ObjectContext.Properties.Tasks.ToString)

                End If

                Tasks = _Tasks

            End Get
        End Property
        Public ReadOnly Property TaskTemplates() As System.Data.Objects.ObjectSet(Of Database.Entities.TaskTemplate)
            Get

                If _TaskTemplates Is Nothing Then

                    _TaskTemplates = MyBase.CreateObjectSet(Of Database.Entities.TaskTemplate)(Database.ObjectContext.Properties.TaskTemplates.ToString)

                End If

                TaskTemplates = _TaskTemplates

            End Get
        End Property
        Public ReadOnly Property TimeCategoryTypes() As System.Data.Objects.ObjectSet(Of Database.Entities.TimeCategoryType)
            Get

                If _TimeCategoryTypes Is Nothing Then

                    _TimeCategoryTypes = MyBase.CreateObjectSet(Of Database.Entities.TimeCategoryType)(Database.ObjectContext.Properties.TimeCategoryTypes.ToString)

                End If

                TimeCategoryTypes = _TimeCategoryTypes

            End Get
        End Property
        Public ReadOnly Property TimeRuleLogs() As System.Data.Objects.ObjectSet(Of Database.Entities.TimeRuleLog)
            Get

                If _TimeRuleLogs Is Nothing Then

                    _TimeRuleLogs = MyBase.CreateObjectSet(Of Database.Entities.TimeRuleLog)(Database.ObjectContext.Properties.TimeRuleLogs.ToString)

                End If

                TimeRuleLogs = _TimeRuleLogs

            End Get
        End Property
        Public ReadOnly Property TVOrderDetailLegacies() As System.Data.Objects.ObjectSet(Of Database.Entities.TVOrderDetailLegacy)
            Get

                If _TVOrderDetailLegacies Is Nothing Then

                    _TVOrderDetailLegacies = MyBase.CreateObjectSet(Of Database.Entities.TVOrderDetailLegacy)(Database.ObjectContext.Properties.TVOrderDetailLegacies.ToString)

                End If

                TVOrderDetailLegacies = _TVOrderDetailLegacies

            End Get
        End Property
        Public ReadOnly Property TVOrderDetails() As System.Data.Objects.ObjectSet(Of Database.Entities.TVOrderDetail)
            Get

                If _TVOrderDetails Is Nothing Then

                    _TVOrderDetails = MyBase.CreateObjectSet(Of Database.Entities.TVOrderDetail)(Database.ObjectContext.Properties.TVOrderDetails.ToString)

                End If

                TVOrderDetails = _TVOrderDetails

            End Get
        End Property
        Public ReadOnly Property TVOrderLegacies() As System.Data.Objects.ObjectSet(Of Database.Entities.TVOrderLegacy)
            Get

                If _TVOrderLegacies Is Nothing Then

                    _TVOrderLegacies = MyBase.CreateObjectSet(Of Database.Entities.TVOrderLegacy)(Database.ObjectContext.Properties.TVOrderLegacies.ToString)

                End If

                TVOrderLegacies = _TVOrderLegacies

            End Get
        End Property
        Public ReadOnly Property TVOrders() As System.Data.Objects.ObjectSet(Of Database.Entities.TVOrder)
            Get

                If _TVOrders Is Nothing Then

                    _TVOrders = MyBase.CreateObjectSet(Of Database.Entities.TVOrder)(Database.ObjectContext.Properties.TVOrders.ToString)

                End If

                TVOrders = _TVOrders

            End Get
        End Property
        Public ReadOnly Property UserDefinedLabel() As System.Data.Objects.ObjectSet(Of Database.Entities.UserDefinedLabel)
            Get

                If _UserDefinedLabel Is Nothing Then

                    _UserDefinedLabel = MyBase.CreateObjectSet(Of Database.Entities.UserDefinedLabel)(Database.ObjectContext.Properties.UserDefinedLabel.ToString)

                End If

                UserDefinedLabel = _UserDefinedLabel

            End Get
        End Property
        Public ReadOnly Property UserDefinedTypes() As System.Data.Objects.ObjectSet(Of Database.Entities.UserDefinedType)
            Get

                If _UserDefinedTypes Is Nothing Then

                    _UserDefinedTypes = MyBase.CreateObjectSet(Of Database.Entities.UserDefinedType)(Database.ObjectContext.Properties.UserDefinedTypes.ToString)

                End If

                UserDefinedTypes = _UserDefinedTypes

            End Get
        End Property
        Public ReadOnly Property UserDefinedTypeValues() As System.Data.Objects.ObjectSet(Of Database.Entities.UserDefinedTypeValue)
            Get

                If _UserDefinedTypeValues Is Nothing Then

                    _UserDefinedTypeValues = MyBase.CreateObjectSet(Of Database.Entities.UserDefinedTypeValue)(Database.ObjectContext.Properties.UserDefinedTypeValues.ToString)

                End If

                UserDefinedTypeValues = _UserDefinedTypeValues

            End Get
        End Property
        Public ReadOnly Property VendorComments() As System.Data.Objects.ObjectSet(Of Database.Entities.VendorComment)
            Get

                If _VendorComments Is Nothing Then

                    _VendorComments = MyBase.CreateObjectSet(Of Database.Entities.VendorComment)(Database.ObjectContext.Properties.VendorComments.ToString)

                End If

                VendorComments = _VendorComments

            End Get
        End Property
        Public ReadOnly Property VendorContacts() As System.Data.Objects.ObjectSet(Of Database.Entities.VendorContact)
            Get

                If _VendorContacts Is Nothing Then

                    _VendorContacts = MyBase.CreateObjectSet(Of Database.Entities.VendorContact)(Database.ObjectContext.Properties.VendorContacts.ToString)

                End If

                VendorContacts = _VendorContacts

            End Get
        End Property
        Public ReadOnly Property VendorCrossReferences() As System.Data.Objects.ObjectSet(Of Database.Entities.VendorCrossReference)
            Get

                If _VendorCrossReferences Is Nothing Then

                    _VendorCrossReferences = MyBase.CreateObjectSet(Of Database.Entities.VendorCrossReference)(Database.ObjectContext.Properties.VendorCrossReferences.ToString)

                End If

                VendorCrossReferences = _VendorCrossReferences

            End Get
        End Property
        Public ReadOnly Property VendorHistorys() As System.Data.Objects.ObjectSet(Of Database.Entities.VendorHistory)
            Get

                If _VendorHistorys Is Nothing Then

                    _VendorHistorys = MyBase.CreateObjectSet(Of Database.Entities.VendorHistory)(Database.ObjectContext.Properties.VendorHistorys.ToString)

                End If

                VendorHistorys = _VendorHistorys

            End Get
        End Property
        Public ReadOnly Property VendorInvoiceAlerts() As System.Data.Objects.ObjectSet(Of Database.Views.VendorInvoiceAlert)
            Get

                If _VendorInvoiceAlerts Is Nothing Then

                    _VendorInvoiceAlerts = MyBase.CreateObjectSet(Of Database.Views.VendorInvoiceAlert)(Database.ObjectContext.Properties.VendorInvoiceAlerts.ToString)

                End If

                VendorInvoiceAlerts = _VendorInvoiceAlerts

            End Get
        End Property
        Public ReadOnly Property VendorInvoiceDetails() As System.Data.Objects.ObjectSet(Of Database.Views.VendorInvoiceDetail)
            Get

                If _VendorInvoiceDetails Is Nothing Then

                    _VendorInvoiceDetails = MyBase.CreateObjectSet(Of Database.Views.VendorInvoiceDetail)(Database.ObjectContext.Properties.VendorInvoiceDetails.ToString)

                End If

                VendorInvoiceDetails = _VendorInvoiceDetails

            End Get
        End Property
        Public ReadOnly Property VendorInvoices() As System.Data.Objects.ObjectSet(Of Database.Views.VendorInvoice)
            Get

                If _VendorInvoices Is Nothing Then

                    _VendorInvoices = MyBase.CreateObjectSet(Of Database.Views.VendorInvoice)(Database.ObjectContext.Properties.VendorInvoices.ToString)

                End If

                VendorInvoices = _VendorInvoices

            End Get
        End Property
        Public ReadOnly Property VendorPricings() As System.Data.Objects.ObjectSet(Of Database.Entities.VendorPricing)
            Get

                If _VendorPricings Is Nothing Then

                    _VendorPricings = MyBase.CreateObjectSet(Of Database.Entities.VendorPricing)(Database.ObjectContext.Properties.VendorPricings.ToString)

                End If

                VendorPricings = _VendorPricings

            End Get
        End Property
        Public ReadOnly Property Vendors() As System.Data.Objects.ObjectSet(Of Database.Entities.Vendor)
            Get

                If _Vendors Is Nothing Then

                    _Vendors = MyBase.CreateObjectSet(Of Database.Entities.Vendor)(Database.ObjectContext.Properties.Vendors.ToString)

                End If

                Vendors = _Vendors

            End Get
        End Property
        Public ReadOnly Property VendorSortKeys() As System.Data.Objects.ObjectSet(Of Database.Entities.VendorSortKey)
            Get

                If _VendorSortKeys Is Nothing Then

                    _VendorSortKeys = MyBase.CreateObjectSet(Of Database.Entities.VendorSortKey)(Database.ObjectContext.Properties.VendorSortKeys.ToString)

                End If

                VendorSortKeys = _VendorSortKeys

            End Get
        End Property
        Public ReadOnly Property VendorTerms() As System.Data.Objects.ObjectSet(Of Database.Entities.VendorTerm)
            Get

                If _VendorTerms Is Nothing Then

                    _VendorTerms = MyBase.CreateObjectSet(Of Database.Entities.VendorTerm)(Database.ObjectContext.Properties.VendorTerms.ToString)

                End If

                VendorTerms = _VendorTerms

            End Get
        End Property
        Public ReadOnly Property WebsiteTypes() As System.Data.Objects.ObjectSet(Of Database.Entities.WebsiteType)
            Get

                If _WebsiteTypes Is Nothing Then

                    _WebsiteTypes = MyBase.CreateObjectSet(Of Database.Entities.WebsiteType)(Database.ObjectContext.Properties.WebsiteTypes.ToString)

                End If

                WebsiteTypes = _WebsiteTypes

            End Get
        End Property
        Public ReadOnly Property WorkflowAlertStates() As System.Data.Objects.ObjectSet(Of Database.Entities.WorkflowAlertState)
            Get

                If _WorkflowAlertStates Is Nothing Then

                    _WorkflowAlertStates = MyBase.CreateObjectSet(Of Database.Entities.WorkflowAlertState)(Database.ObjectContext.Properties.WorkflowAlertStates.ToString)

                End If

                WorkflowAlertStates = _WorkflowAlertStates

            End Get
        End Property
        Public ReadOnly Property Workflows1() As System.Data.Objects.ObjectSet(Of Database.Entities.Workflow)
            Get

                If _Workflows1 Is Nothing Then

                    _Workflows1 = MyBase.CreateObjectSet(Of Database.Entities.Workflow)(Database.ObjectContext.Properties.Workflows1.ToString)

                End If

                Workflows1 = _Workflows1

            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

            MyBase.New(ConnectionString, UserCode, ObjectContextType.Default)

        End Sub
        Public Shadows Sub AttachToOrGet(Of T As AdvantageFramework.BaseClasses.Entity)(ByVal EntitySetName As AdvantageFramework.Database.ObjectContext.Properties, ByRef Entity As T)

            MyBase.AttachToOrGet(EntitySetName.ToString, Entity)

        End Sub

#End Region

    End Class

End Namespace

