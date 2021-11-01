Namespace FinanceAndAccounting

    <HideModuleName()> _
    Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Friend Sub LoadCDPGroupFields(ByVal ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting, _
                                       ByVal GroupHeaderClientDivisionProduct As DevExpress.XtraReports.UI.GroupHeaderBand, _
                                       ByVal LabelClientDivisionProduct_Division As DevExpress.XtraReports.UI.XRLabel, _
                                       ByVal LabelClientDivisionProduct_DivisionData As DevExpress.XtraReports.UI.XRLabel, _
                                       ByVal LabelClientDivisionProduct_Product As DevExpress.XtraReports.UI.XRLabel, _
                                       ByVal LabelClientDivisionProduct_ProductData As DevExpress.XtraReports.UI.XRLabel)

            If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                GroupHeaderClientDivisionProduct.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientCode"))
                GroupHeaderClientDivisionProduct.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientDescription"))

                LabelClientDivisionProduct_Division.Visible = False
                LabelClientDivisionProduct_DivisionData.Visible = False
                LabelClientDivisionProduct_Product.Visible = False
                LabelClientDivisionProduct_ProductData.Visible = False

            ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                GroupHeaderClientDivisionProduct.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientCode"))
                GroupHeaderClientDivisionProduct.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientDescription"))
                GroupHeaderClientDivisionProduct.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionCode"))
                GroupHeaderClientDivisionProduct.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionDescription"))

                LabelClientDivisionProduct_Product.Visible = False
                LabelClientDivisionProduct_ProductData.Visible = False

            ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                GroupHeaderClientDivisionProduct.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientCode"))
                GroupHeaderClientDivisionProduct.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientDescription"))
                GroupHeaderClientDivisionProduct.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionCode"))
                GroupHeaderClientDivisionProduct.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionDescription"))
                GroupHeaderClientDivisionProduct.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ProductCode"))
                GroupHeaderClientDivisionProduct.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ProductDescription"))

            End If

        End Sub
        Friend Sub LoadDetailGroupFields(ByVal ServiceFeeReconciliationGroupByOption As AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions, _
                                          ByVal GroupHeaderDetail As DevExpress.XtraReports.UI.GroupHeaderBand, _
                                          ByVal TableRowHeader_Header As DevExpress.XtraReports.UI.XRTableRow, _
                                          ByVal TableCellHeader_CampaignDescription As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellHeader_JobNumber As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellHeader_JobDescription As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellHeader_ComponentNumber As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellHeader_ComponentDescription As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellHeader_FunctionDescription As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellHeader_FeeQuantity As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellHeader_FeeAmount As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellHeader_TotalHours As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellHeader_TotalAmount As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellHeader_FunctionConsolidation As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellHeader_FunctionHeading As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableRowDetails_Details As DevExpress.XtraReports.UI.XRTableRow, _
                                          ByVal TableCellDetails_CampaignDescription As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellDetails_JobNumber As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellDetails_JobDescription As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellDetails_ComponentNumber As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellDetails_ComponentDescription As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellDetails_FunctionDescription As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellDetails_FeeQuantity As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellDetails_FeeAmount As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellDetails_TotalHours As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellDetails_TotalAmount As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellDetails_FunctionConsolidation As DevExpress.XtraReports.UI.XRTableCell, _
                                          ByVal TableCellDetails_FunctionHeading As DevExpress.XtraReports.UI.XRTableCell)

            If ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job Then

                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobNumber"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ProductCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ProductDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignName"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("SalesClassCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("SalesClassDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobDescription"))

                TableRowHeader_Header.Cells.Remove(TableCellHeader_ComponentNumber)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_ComponentNumber)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_ComponentDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_ComponentDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_CampaignDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_CampaignDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionConsolidation)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionConsolidation)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionHeading)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionHeading)

                TableCellHeader_JobNumber.WidthF = 65

                Do Until TableCellHeader_JobNumber.WidthF >= 65

                    TableCellHeader_JobNumber.WidthF = 65
                    TableCellHeader_JobDescription.WidthF = 510
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_JobDescription.WidthF >= 510

                    TableCellHeader_JobDescription.WidthF = 510
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop
                '<<<<<<<<<<<<<<DETAILS>>>>>>>>>>>>>>>>>>>>>>>>>>

                TableCellDetails_JobNumber.WidthF = 65

                Do Until TableCellDetails_JobNumber.WidthF >= 65

                    TableCellDetails_JobNumber.WidthF = 65
                    TableCellDetails_JobDescription.WidthF = 510
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_JobDescription.WidthF >= 510

                    TableCellDetails_JobDescription.WidthF = 510
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component Then

                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobNumber"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ProductCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ProductDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignName"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("SalesClassCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("SalesClassDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ComponentNumber"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobComponent"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ComponentDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobServiceFeeTypeCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("EmployeeDepartmentTeamServiceFeeTypeCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("IsServiceFeeJob"))

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_CampaignDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_CampaignDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionConsolidation)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionConsolidation)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionHeading)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionHeading)

                TableCellHeader_JobNumber.WidthF = 65

                Do Until TableCellHeader_JobNumber.WidthF >= 65

                    TableCellHeader_JobNumber.WidthF = 65
                    TableCellHeader_JobDescription.WidthF = 222.5
                    TableCellHeader_ComponentNumber.WidthF = 65
                    TableCellHeader_ComponentDescription.WidthF = 222.5
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_JobDescription.WidthF >= 222.5

                    TableCellHeader_JobDescription.WidthF = 222.5
                    TableCellHeader_ComponentNumber.WidthF = 65
                    TableCellHeader_ComponentDescription.WidthF = 222.5
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_ComponentNumber.WidthF >= 65

                    TableCellHeader_ComponentNumber.WidthF = 65
                    TableCellHeader_ComponentDescription.WidthF = 222.5
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_ComponentDescription.WidthF >= 222.5

                    TableCellHeader_ComponentDescription.WidthF = 222.5
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop
                '<<<<<<<<<<<<<<DETAILS>>>>>>>>>>>>>>>>>>>>>>>>>>

                TableCellDetails_JobNumber.WidthF = 65

                Do Until TableCellDetails_JobNumber.WidthF >= 65

                    TableCellDetails_JobNumber.WidthF = 65
                    TableCellDetails_JobDescription.WidthF = 222.5
                    TableCellDetails_ComponentNumber.WidthF = 65
                    TableCellDetails_ComponentDescription.WidthF = 222.5
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_JobDescription.WidthF >= 222.5

                    TableCellDetails_JobDescription.WidthF = 222.5
                    TableCellDetails_ComponentNumber.WidthF = 65
                    TableCellDetails_ComponentDescription.WidthF = 222.5
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_ComponentNumber.WidthF >= 65

                    TableCellDetails_ComponentNumber.WidthF = 65
                    TableCellDetails_ComponentDescription.WidthF = 222.5
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_ComponentDescription.WidthF >= 222.5

                    TableCellDetails_ComponentDescription.WidthF = 222.5
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_Function Then

                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobNumber"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ProductCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ProductDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignName"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("SalesClassCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("SalesClassDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ComponentNumber"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobComponent"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ComponentDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("FunctionCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("FunctionDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobServiceFeeTypeCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("EmployeeDepartmentTeamServiceFeeTypeCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("IsServiceFeeJob"))

                TableRowHeader_Header.Cells.Remove(TableCellHeader_CampaignDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_CampaignDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionConsolidation)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionConsolidation)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionHeading)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionHeading)

                TableCellHeader_JobNumber.WidthF = 65

                Do Until TableCellHeader_JobNumber.WidthF >= 65

                    TableCellHeader_JobNumber.WidthF = 65
                    TableCellHeader_JobDescription.WidthF = 148.3
                    TableCellHeader_ComponentNumber.WidthF = 65
                    TableCellHeader_ComponentDescription.WidthF = 148.3
                    TableCellHeader_FunctionDescription.WidthF = 148.4
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_JobDescription.WidthF >= 148.3

                    TableCellHeader_JobDescription.WidthF = 148.3
                    TableCellHeader_ComponentNumber.WidthF = 65
                    TableCellHeader_ComponentDescription.WidthF = 148.3
                    TableCellHeader_FunctionDescription.WidthF = 148.4
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_ComponentNumber.WidthF >= 65

                    TableCellHeader_ComponentNumber.WidthF = 65
                    TableCellHeader_ComponentDescription.WidthF = 148.3
                    TableCellHeader_FunctionDescription.WidthF = 148.4
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_ComponentDescription.WidthF >= 148.3

                    TableCellHeader_ComponentDescription.WidthF = 148.3
                    TableCellHeader_FunctionDescription.WidthF = 148.4
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_FunctionDescription.WidthF >= 148.3

                    TableCellHeader_FunctionDescription.WidthF = 148.4
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop
                '<<<<<<<<<<<<<<DETAILS>>>>>>>>>>>>>>>>>>>>>>>>>>

                TableCellDetails_JobNumber.WidthF = 65

                Do Until TableCellDetails_JobNumber.WidthF >= 65

                    TableCellDetails_JobNumber.WidthF = 65
                    TableCellDetails_JobDescription.WidthF = 148.3
                    TableCellDetails_ComponentNumber.WidthF = 65
                    TableCellDetails_ComponentDescription.WidthF = 148.3
                    TableCellDetails_FunctionDescription.WidthF = 148.4
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_JobDescription.WidthF >= 148.3

                    TableCellDetails_JobDescription.WidthF = 148.3
                    TableCellDetails_ComponentNumber.WidthF = 65
                    TableCellDetails_ComponentDescription.WidthF = 148.3
                    TableCellDetails_FunctionDescription.WidthF = 148.4
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_ComponentNumber.WidthF >= 65

                    TableCellDetails_ComponentNumber.WidthF = 65
                    TableCellDetails_ComponentDescription.WidthF = 148.3
                    TableCellDetails_FunctionDescription.WidthF = 148.4
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_ComponentDescription.WidthF >= 148.3

                    TableCellDetails_ComponentDescription.WidthF = 148.3
                    TableCellDetails_FunctionDescription.WidthF = 148.4
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_FunctionDescription.WidthF >= 148.3

                    TableCellDetails_FunctionDescription.WidthF = 148.4
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Function Then

                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobNumber"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ProductCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ProductDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignName"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("SalesClassCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("SalesClassDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("FunctionCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("FunctionDescription"))

                TableRowHeader_Header.Cells.Remove(TableCellHeader_ComponentNumber)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_ComponentNumber)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_ComponentDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_ComponentDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_CampaignDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_CampaignDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionConsolidation)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionConsolidation)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionHeading)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionHeading)

                TableCellHeader_JobNumber.WidthF = 65

                Do Until TableCellHeader_JobNumber.WidthF >= 65

                    TableCellHeader_JobNumber.WidthF = 65
                    TableCellHeader_JobDescription.WidthF = 255
                    TableCellHeader_FunctionDescription.WidthF = 255
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_JobDescription.WidthF >= 255

                    TableCellHeader_JobDescription.WidthF = 255
                    TableCellHeader_FunctionDescription.WidthF = 255
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_FunctionDescription.WidthF >= 255

                    TableCellHeader_FunctionDescription.WidthF = 255
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop
                '<<<<<<<<<<<<<<DETAILS>>>>>>>>>>>>>>>>>>>>>>>>>>

                TableCellDetails_JobNumber.WidthF = 65

                Do Until TableCellDetails_JobNumber.WidthF >= 65

                    TableCellDetails_JobNumber.WidthF = 65
                    TableCellDetails_JobDescription.WidthF = 255
                    TableCellDetails_FunctionDescription.WidthF = 255
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_JobDescription.WidthF >= 255

                    TableCellDetails_JobDescription.WidthF = 255
                    TableCellDetails_FunctionDescription.WidthF = 255
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_FunctionDescription.WidthF >= 255

                    TableCellDetails_FunctionDescription.WidthF = 255
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Campaign Then

                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignName"))

                TableRowHeader_Header.Cells.Remove(TableCellHeader_JobNumber)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_JobNumber)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_JobDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_JobDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_ComponentNumber)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_ComponentNumber)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_ComponentDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_ComponentDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionConsolidation)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionConsolidation)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionHeading)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionHeading)

                Do Until TableCellHeader_CampaignDescription.WidthF >= 575

                    TableCellHeader_CampaignDescription.WidthF = 575
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop
                '<<<<<<<<<<<<<<DETAILS>>>>>>>>>>>>>>>>>>>>>>>>>>
                Do Until TableCellDetails_CampaignDescription.WidthF >= 575

                    TableCellDetails_CampaignDescription.WidthF = 575
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.[Function] Then

                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("FunctionCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("FunctionDescription"))

                TableRowHeader_Header.Cells.Remove(TableCellHeader_JobNumber)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_JobNumber)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_JobDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_JobDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_ComponentNumber)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_ComponentNumber)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_ComponentDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_ComponentDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_CampaignDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_CampaignDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionConsolidation)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionConsolidation)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionHeading)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionHeading)

                Do Until TableCellHeader_FunctionDescription.WidthF >= 575

                    TableCellHeader_FunctionDescription.WidthF = 575
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop
                '<<<<<<<<<<<<<<DETAILS>>>>>>>>>>>>>>>>>>>>>>>>>>
                Do Until TableCellDetails_FunctionDescription.WidthF >= 575

                    TableCellDetails_FunctionDescription.WidthF = 575
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_FunctionConsolidation Then

                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobNumber"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ProductCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ProductDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignName"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("SalesClassCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("SalesClassDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("FunctionConsolidation"))

                TableRowHeader_Header.Cells.Remove(TableCellHeader_ComponentNumber)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_ComponentNumber)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_ComponentDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_ComponentDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_CampaignDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_CampaignDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionHeading)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionHeading)

                TableCellHeader_JobNumber.WidthF = 65

                Do Until TableCellHeader_JobNumber.WidthF >= 65

                    TableCellHeader_JobNumber.WidthF = 65
                    TableCellHeader_JobDescription.WidthF = 255
                    TableCellHeader_FunctionConsolidation.WidthF = 255
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_JobDescription.WidthF >= 255

                    TableCellHeader_JobDescription.WidthF = 255
                    TableCellHeader_FunctionConsolidation.WidthF = 255
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_FunctionConsolidation.WidthF >= 255

                    TableCellHeader_FunctionConsolidation.WidthF = 255
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop
                '<<<<<<<<<<<<<<DETAILS>>>>>>>>>>>>>>>>>>>>>>>>>>

                TableCellDetails_JobNumber.WidthF = 65

                Do Until TableCellDetails_JobNumber.WidthF >= 65

                    TableCellDetails_JobNumber.WidthF = 65
                    TableCellDetails_JobDescription.WidthF = 255
                    TableCellDetails_FunctionConsolidation.WidthF = 255
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_JobDescription.WidthF >= 255

                    TableCellDetails_JobDescription.WidthF = 255
                    TableCellDetails_FunctionConsolidation.WidthF = 255
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_FunctionConsolidation.WidthF >= 255

                    TableCellDetails_FunctionConsolidation.WidthF = 255
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_FunctionConsolidation Then

                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobNumber"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ProductCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ProductDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignName"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("SalesClassCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("SalesClassDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ComponentNumber"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobComponent"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ComponentDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("FunctionConsolidation"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobServiceFeeTypeCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("EmployeeDepartmentTeamServiceFeeTypeCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("IsServiceFeeJob"))

                TableRowHeader_Header.Cells.Remove(TableCellHeader_CampaignDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_CampaignDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionHeading)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionHeading)

                TableCellHeader_JobNumber.WidthF = 65

                Do Until TableCellHeader_JobNumber.WidthF >= 65

                    TableCellHeader_JobNumber.WidthF = 65
                    TableCellHeader_JobDescription.WidthF = 148.3
                    TableCellHeader_ComponentNumber.WidthF = 65
                    TableCellHeader_ComponentDescription.WidthF = 148.3
                    TableCellHeader_FunctionConsolidation.WidthF = 148.4
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_JobDescription.WidthF >= 148.3

                    TableCellHeader_JobDescription.WidthF = 148.3
                    TableCellHeader_ComponentNumber.WidthF = 65
                    TableCellHeader_ComponentDescription.WidthF = 148.3
                    TableCellHeader_FunctionConsolidation.WidthF = 148.4
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_ComponentNumber.WidthF >= 65

                    TableCellHeader_ComponentNumber.WidthF = 65
                    TableCellHeader_ComponentDescription.WidthF = 148.3
                    TableCellHeader_FunctionConsolidation.WidthF = 148.4
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_ComponentDescription.WidthF >= 148.3

                    TableCellHeader_ComponentDescription.WidthF = 148.3
                    TableCellHeader_FunctionConsolidation.WidthF = 148.4
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_FunctionConsolidation.WidthF >= 148.3

                    TableCellHeader_FunctionConsolidation.WidthF = 148.4
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop
                '<<<<<<<<<<<<<<DETAILS>>>>>>>>>>>>>>>>>>>>>>>>>>

                TableCellDetails_JobNumber.WidthF = 65

                Do Until TableCellDetails_JobNumber.WidthF >= 65

                    TableCellDetails_JobNumber.WidthF = 65
                    TableCellDetails_JobDescription.WidthF = 148.3
                    TableCellDetails_ComponentNumber.WidthF = 65
                    TableCellDetails_ComponentDescription.WidthF = 148.3
                    TableCellDetails_FunctionConsolidation.WidthF = 148.4
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_JobDescription.WidthF >= 148.3

                    TableCellDetails_JobDescription.WidthF = 148.3
                    TableCellDetails_ComponentNumber.WidthF = 65
                    TableCellDetails_ComponentDescription.WidthF = 148.3
                    TableCellDetails_FunctionConsolidation.WidthF = 148.4
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_ComponentNumber.WidthF >= 65

                    TableCellDetails_ComponentNumber.WidthF = 65
                    TableCellDetails_ComponentDescription.WidthF = 148.3
                    TableCellDetails_FunctionConsolidation.WidthF = 148.4
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_ComponentDescription.WidthF >= 148.3

                    TableCellDetails_ComponentDescription.WidthF = 148.3
                    TableCellDetails_FunctionConsolidation.WidthF = 148.4
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_FunctionConsolidation.WidthF >= 148.3

                    TableCellDetails_FunctionConsolidation.WidthF = 148.4
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.FunctionConsolidation Then

                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("FunctionConsolidation"))

                TableRowHeader_Header.Cells.Remove(TableCellHeader_JobNumber)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_JobNumber)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_JobDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_JobDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_ComponentNumber)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_ComponentNumber)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_ComponentDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_ComponentDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_CampaignDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_CampaignDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionHeading)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionHeading)

                Do Until TableCellHeader_FunctionConsolidation.WidthF >= 575

                    TableCellHeader_FunctionConsolidation.WidthF = 575
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop
                '<<<<<<<<<<<<<<DETAILS>>>>>>>>>>>>>>>>>>>>>>>>>>
                Do Until TableCellDetails_FunctionConsolidation.WidthF >= 575

                    TableCellDetails_FunctionConsolidation.WidthF = 575
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_FunctionHeading Then

                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobNumber"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ProductCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ProductDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignName"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("SalesClassCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("SalesClassDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("FunctionHeading"))

                TableRowHeader_Header.Cells.Remove(TableCellHeader_ComponentNumber)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_ComponentNumber)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_ComponentDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_ComponentDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_CampaignDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_CampaignDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionConsolidation)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionConsolidation)

                TableCellHeader_JobNumber.WidthF = 65

                Do Until TableCellHeader_JobNumber.WidthF >= 65

                    TableCellHeader_JobNumber.WidthF = 65
                    TableCellHeader_JobDescription.WidthF = 255
                    TableCellHeader_FunctionHeading.WidthF = 255
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_JobDescription.WidthF >= 255

                    TableCellHeader_JobDescription.WidthF = 255
                    TableCellHeader_FunctionHeading.WidthF = 255
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_FunctionHeading.WidthF >= 255

                    TableCellHeader_FunctionHeading.WidthF = 255
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop
                '<<<<<<<<<<<<<<DETAILS>>>>>>>>>>>>>>>>>>>>>>>>>>

                TableCellDetails_JobNumber.WidthF = 65

                Do Until TableCellDetails_JobNumber.WidthF >= 65

                    TableCellDetails_JobNumber.WidthF = 65
                    TableCellDetails_JobDescription.WidthF = 255
                    TableCellDetails_FunctionHeading.WidthF = 255
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_JobDescription.WidthF >= 255

                    TableCellDetails_JobDescription.WidthF = 255
                    TableCellDetails_FunctionHeading.WidthF = 255
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_FunctionHeading.WidthF >= 255

                    TableCellDetails_FunctionHeading.WidthF = 255
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_FunctionHeading Then

                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobNumber"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ClientDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("DivisionDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ProductCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ProductDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignName"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("SalesClassCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("SalesClassDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ComponentNumber"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobComponent"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("ComponentDescription"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("FunctionHeading"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("JobServiceFeeTypeCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("EmployeeDepartmentTeamServiceFeeTypeCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode"))
                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("IsServiceFeeJob"))

                TableRowHeader_Header.Cells.Remove(TableCellHeader_CampaignDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_CampaignDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionConsolidation)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionConsolidation)

                TableCellHeader_JobNumber.WidthF = 65

                Do Until TableCellHeader_JobNumber.WidthF >= 65

                    TableCellHeader_JobNumber.WidthF = 65
                    TableCellHeader_JobDescription.WidthF = 148.3
                    TableCellHeader_ComponentNumber.WidthF = 65
                    TableCellHeader_ComponentDescription.WidthF = 148.3
                    TableCellHeader_FunctionHeading.WidthF = 148.4
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_JobDescription.WidthF >= 148.3

                    TableCellHeader_JobDescription.WidthF = 148.3
                    TableCellHeader_ComponentNumber.WidthF = 65
                    TableCellHeader_ComponentDescription.WidthF = 148.3
                    TableCellHeader_FunctionHeading.WidthF = 148.4
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_ComponentNumber.WidthF >= 65

                    TableCellHeader_ComponentNumber.WidthF = 65
                    TableCellHeader_ComponentDescription.WidthF = 148.3
                    TableCellHeader_FunctionHeading.WidthF = 148.4
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_ComponentDescription.WidthF >= 148.3

                    TableCellHeader_ComponentDescription.WidthF = 148.3
                    TableCellHeader_FunctionHeading.WidthF = 148.4
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellHeader_FunctionHeading.WidthF >= 148.3

                    TableCellHeader_FunctionHeading.WidthF = 148.4
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop
                '<<<<<<<<<<<<<<DETAILS>>>>>>>>>>>>>>>>>>>>>>>>>>

                TableCellDetails_JobNumber.WidthF = 65

                Do Until TableCellDetails_JobNumber.WidthF >= 65

                    TableCellDetails_JobNumber.WidthF = 65
                    TableCellDetails_JobDescription.WidthF = 148.3
                    TableCellDetails_ComponentNumber.WidthF = 65
                    TableCellDetails_ComponentDescription.WidthF = 148.3
                    TableCellDetails_FunctionHeading.WidthF = 148.4
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_JobDescription.WidthF >= 148.3

                    TableCellDetails_JobDescription.WidthF = 148.3
                    TableCellDetails_ComponentNumber.WidthF = 65
                    TableCellDetails_ComponentDescription.WidthF = 148.3
                    TableCellDetails_FunctionHeading.WidthF = 148.4
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_ComponentNumber.WidthF >= 65

                    TableCellDetails_ComponentNumber.WidthF = 65
                    TableCellDetails_ComponentDescription.WidthF = 148.3
                    TableCellDetails_FunctionHeading.WidthF = 148.4
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_ComponentDescription.WidthF >= 148.3

                    TableCellDetails_ComponentDescription.WidthF = 148.3
                    TableCellDetails_FunctionHeading.WidthF = 148.4
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

                Do Until TableCellDetails_FunctionHeading.WidthF >= 148.3

                    TableCellDetails_FunctionHeading.WidthF = 148.4
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.FunctionHeading Then

                GroupHeaderDetail.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("FunctionHeading"))

                TableRowHeader_Header.Cells.Remove(TableCellHeader_JobNumber)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_JobNumber)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_JobDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_JobDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_ComponentNumber)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_ComponentNumber)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_ComponentDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_ComponentDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_CampaignDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_CampaignDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionDescription)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionDescription)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FunctionConsolidation)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FunctionConsolidation)

                Do Until TableCellHeader_FunctionHeading.WidthF >= 575

                    TableCellHeader_FunctionHeading.WidthF = 575
                    TableCellHeader_FeeQuantity.WidthF = 75
                    TableCellHeader_FeeAmount.WidthF = 75
                    TableCellHeader_TotalHours.WidthF = 75
                    TableCellHeader_TotalAmount.WidthF = 75

                Loop
                '<<<<<<<<<<<<<<DETAILS>>>>>>>>>>>>>>>>>>>>>>>>>>
                Do Until TableCellDetails_FunctionHeading.WidthF >= 575

                    TableCellDetails_FunctionHeading.WidthF = 575
                    TableCellDetails_FeeQuantity.WidthF = 75
                    TableCellDetails_FeeAmount.WidthF = 75
                    TableCellDetails_TotalHours.WidthF = 75
                    TableCellDetails_TotalAmount.WidthF = 75

                Loop

            End If

        End Sub

#End Region

    End Module

End Namespace
