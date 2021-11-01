Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports eWorld.UI.CollapsablePanel

Imports Webvantage.cGlobals
Imports Telerik.Web.UI


Partial Public Class Estimating_PrintSettings
    Inherits Webvantage.BasePrintSendPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Private vars: "

    Private EstNum As Integer = 0
    Private EstCompNum As Integer = 0
    Private JobNum As Integer = 0
    Private JobCompNum As Integer = 0
    Private QuoteNum As Integer = 0
    Private RevNum As Integer = 0

    Private _From As String = ""
    Private _SelectedQuoteNumbers As String = ""
    Private _SelectedQuoteDescriptions As String = ""
    Private _PrintSendAll As Boolean = False
    Private Const Delimiter As String = "#"

    Private _EstimatePrintingDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
    Private _EstimatePrintingSetting As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
    Private _EstimatePrintingSettingClass As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
    Private _EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting) = Nothing
    Private _CustomInvoiceSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.CustomInvoiceSetting) = Nothing
    Private _EstimateFormatType As String = ""
    Private _ShowEstimateOptions As Boolean = False
    Private _ClientLevel As String = ""
    Private _ClientCodes As Generic.List(Of String) = Nothing
    Private _ProductCodes As Generic.List(Of String) = Nothing

    Protected WithEvents RadDatePickerEstimate As Telerik.Web.UI.RadDatePicker

#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

#End Region

#Region " Methods "

    Private Function LoadComboboxes()
        Try

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                'Location
                RadComboBoxLocation.Items.Clear()
                RadComboBoxLocation.DataTextField = "Description"
                RadComboBoxLocation.DataValueField = "ID"

                RadComboBoxLocation.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Location.Load(DataContext)
                                                  Select Entity.ID,
                                                            Entity.Name).ToList.Select(Function(Location) New With {.ID = Location.ID,
                                                                                                                    .Description = Location.ID & " - " & Location.Name}).ToList
                RadComboBoxLocation.DataBind()

                RadComboBoxLocation.Items.Add(New Telerik.Web.UI.RadComboBoxItem("None", ""))

            End Using

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                'Custom Estimate
                RadComboBoxCustomEstimate.Items.Clear()
                RadComboBoxCustomEstimate.DataTextField = "Description"
                RadComboBoxCustomEstimate.DataValueField = "ID"

                RadComboBoxCustomEstimate.DataSource = AdvantageFramework.Reporting.Database.Procedures.EstimateReport.Load(ReportingDbContext).ToList
                RadComboBoxCustomEstimate.DataBind()

                RadComboBoxCustomEstimate.Items.Add(New Telerik.Web.UI.RadComboBoxItem("None", ""))

            End Using


            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                'Address Block
                RadComboBoxAddressBlock.DataTextField = "Description"
                RadComboBoxAddressBlock.DataValueField = "Code"
                RadComboBoxAddressBlock.DataSource = (From AddressBlockType In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Estimate.Printing.AddressBlockTypes))
                                                      Select AddressBlockType.Code,
                                                   AddressBlockType.Description).ToList

                RadComboBoxAddressBlock.DataBind()

                'Contact Type
                RadComboBoxContactType.DataTextField = "Description"
                RadComboBoxContactType.DataValueField = "Code"
                RadComboBoxContactType.DataSource = (From ContactType In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Estimate.Printing.ContactType))
                                                     Select ContactType.Code,
                                                   ContactType.Description).ToList

                RadComboBoxContactType.DataBind()


                'Summary Level
                RadComboBoxSummaryLevel.DataTextField = "Description"
                RadComboBoxSummaryLevel.DataValueField = "Code"
                RadComboBoxSummaryLevel.DataSource = (From SummaryOption In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Estimate.Printing.SummaryOptions))
                                                      Select SummaryOption.Code,
                                                   SummaryOption.Description).ToList

                RadComboBoxSummaryLevel.DataBind()

                'Format Type
                RadComboBoxFormatType.DataTextField = "Description"
                RadComboBoxFormatType.DataValueField = "Code"
                RadComboBoxFormatType.DataSource = (From ReportFormat In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Estimate.Printing.ReportFormats))
                                                    Select ReportFormat.Code,
                                           ReportFormat.Description).ToList

                RadComboBoxFormatType.DataBind()



                'Sort Option
                RadComboBoxSortOption.DataTextField = "Description"
                RadComboBoxSortOption.DataValueField = "Code"
                RadComboBoxSortOption.DataSource = (From SortOption In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Estimate.Printing.SortOptions))
                                                    Select SortOption.Code,
                                                   SortOption.Description).ToList

                RadComboBoxSortOption.DataBind()

                'Print Option
                RadComboBoxPrintOption.DataTextField = "Description"
                RadComboBoxPrintOption.DataValueField = "Code"
                RadComboBoxPrintOption.DataSource = (From FunctionOption In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Estimate.Printing.FunctionOptions))
                                                     Select FunctionOption.Code,
                                                   FunctionOption.Description).ToList

                RadComboBoxPrintOption.DataBind()

                'Signature
                'RadComboBoxSignature.DataTextField = "Description"
                'RadComboBoxSignature.DataValueField = "Code"
                'RadComboBoxSignature.DataSource = (From Signature In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Estimate.Printing.Signatures))
                '                                   Select Signature.Code,
                '                                   Signature.Description).ToList

                'RadComboBoxSignature.DataBind()

                'File Formats
                Me.RadComboBoxFileFormat.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("PDF"), CStr("1")))
                Me.RadComboBoxFileFormat.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("RTF"), CStr("5")))

            End Using

        Catch ex As Exception

        End Try
    End Function

    Private Function LoadGroupingOptions()
        'Format Type
        If RadComboBoxFormatType.SelectedValue = "2" Or
           RadComboBoxFormatType.SelectedValue = "3" Or
           RadComboBoxFormatType.SelectedValue = "4" Or
           RadComboBoxFormatType.SelectedValue = "5" Or
           RadComboBoxFormatType.SelectedValue = "6" Or
           RadComboBoxFormatType.SelectedValue = "7" Then
            'Option
            RadComboBoxOption.Items.Clear()
            RadComboBoxOption.DataTextField = "Description"
            RadComboBoxOption.DataValueField = "Code"
            RadComboBoxOption.DataSource = (From GroupOption In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Estimate.Printing.GroupOptions))
                                            Select GroupOption.Code,
                                               GroupOption.Description).ToList.Where(Function(GroupOption) GroupOption.Code <> "4").ToList

            RadComboBoxOption.DataBind()
        Else
            'Option
            RadComboBoxOption.DataTextField = "Description"
            RadComboBoxOption.DataValueField = "Code"
            RadComboBoxOption.DataSource = (From GroupOption In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Estimate.Printing.GroupOptions))
                                            Select GroupOption.Code,
                                               GroupOption.Description).ToList

            RadComboBoxOption.DataBind()
        End If

    End Function

    Private Function LoadSignatureOptions()
        'Format Type
        If RadComboBoxFormatType.SelectedValue = "2" Or
           RadComboBoxFormatType.SelectedValue = "3" Or
           RadComboBoxFormatType.SelectedValue = "4" Or
           RadComboBoxFormatType.SelectedValue = "5" Or
           RadComboBoxFormatType.SelectedValue = "6" Or
           RadComboBoxFormatType.SelectedValue = "7" Then
            'Option
            RadComboBoxSignature.Items.Clear()
            RadComboBoxSignature.DataTextField = "Description"
            RadComboBoxSignature.DataValueField = "Code"
            RadComboBoxSignature.DataSource = (From GroupOption In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Estimate.Printing.Signatures))
                                               Select GroupOption.Code,
                                               GroupOption.Description).ToList.Where(Function(GroupOption) GroupOption.Code <> "9").ToList

            RadComboBoxSignature.DataBind()
        Else
            'Option
            RadComboBoxSignature.DataTextField = "Description"
            RadComboBoxSignature.DataValueField = "Code"
            RadComboBoxSignature.DataSource = (From GroupOption In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Estimate.Printing.Signatures))
                                               Select GroupOption.Code,
                                               GroupOption.Description).ToList

            RadComboBoxSignature.DataBind()
        End If

        Try
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    If RadToolBarButtonClient.Checked = True Then
                        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettingsWebvantage(DbContext, DataContext, RadToolBarButtonClient.Value, Me.LabelClientCode.Text).FirstOrDefault()
                    End If
                    If RadToolBarButtonProduct.Checked = True Then
                        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettingsWebvantage(DbContext, DataContext, RadToolBarButtonProduct.Value, Me.LabelClientCode.Text, Me.LabelClientCode.Text & "|" & Me.LabelDivisionCode.Text & "|" & Me.LabelProductCode.Text).FirstOrDefault()
                    End If
                    If RadToolBarButtonAgency.Checked = True Then
                        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettingsWebvantage(DbContext, DataContext, RadToolBarButtonAgency.Value).FirstOrDefault()
                    End If
                    If RadToolBarButtonUser.Checked = True Then
                        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettingsWebvantage(DbContext, DataContext, RadToolBarButtonUser.Value, "", "", _Session.UserCode).FirstOrDefault()
                    End If
                    If RadToolBarButtonOneTime.Checked = True Then
                        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettingsWebvantage(DbContext, DataContext, RadToolBarButtonOneTime.Value).FirstOrDefault()
                    End If

                    If EstimatePrintingSetting IsNot Nothing Then
                        Me.RadComboBoxSignature.SelectedValue = EstimatePrintingSetting.Signature
                    Else
                        Me.RadComboBoxSignature.SelectedValue = 0
                    End If

                End Using

            End Using

        Catch ex As Exception

        End Try

    End Function

    Private Sub LoadEstimateData()
        Try
            Dim oEstimating As New cEstimating(_Session.ConnectionString, _Session.UserCode)
            Dim dt As DataTable
            dt = oEstimating.GetEstimateData(Me.EstNum, Me.EstCompNum, Me.JobNum, Me.JobCompNum, Session("UserCode"))
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                    Me.LabelClientCode.Text = dt.Rows(0)("CL_CODE")
                    Me.LabelClient.Text = dt.Rows(0)("CL_CODE")
                    Session("EstimateSendClient") = Me.LabelClientCode.Text
                End If
                If IsDBNull(dt.Rows(0)("CL_NAME")) = False Then
                    Me.LabelClientDescription.Text = dt.Rows(0)("CL_NAME")
                    Me.LabelClientName.Text = dt.Rows(0)("CL_NAME")
                End If
                If IsDBNull(dt.Rows(0)("DIV_CODE")) = False Then
                    Me.LabelDivisionCode.Text = dt.Rows(0)("DIV_CODE")
                    Me.LabelDivision.Text = dt.Rows(0)("DIV_CODE")
                    Session("EstimateSendDivision") = Me.LabelDivisionCode.Text
                End If
                If IsDBNull(dt.Rows(0)("DIV_NAME")) = False Then
                    Me.LabelDivisionDescription.Text = dt.Rows(0)("DIV_NAME")
                    Me.LabelDivisionName.Text = dt.Rows(0)("DIV_NAME")
                End If
                If IsDBNull(dt.Rows(0)("PRD_CODE")) = False Then
                    Me.LabelProductCode.Text = dt.Rows(0)("PRD_CODE")
                    Me.LabelProduct.Text = dt.Rows(0)("PRD_CODE")
                    Session("EstimateSendProduct") = Me.LabelProductCode.Text
                End If
                If IsDBNull(dt.Rows(0)("PRD_DESCRIPTION")) = False Then
                    Me.LabelProductDescription.Text = dt.Rows(0)("PRD_DESCRIPTION")
                    Me.LabelProductName.Text = dt.Rows(0)("PRD_DESCRIPTION")
                End If
                If IsDBNull(dt.Rows(0)("JOB_NUMBER")) = False Then
                    Me.LabelJobNumber.Text = dt.Rows(0)("JOB_NUMBER").ToString.PadLeft(6, "0")
                    Me.LabelJob.Text = dt.Rows(0)("JOB_NUMBER").ToString.PadLeft(6, "0")
                    Session("EstimateSendJobNum") = Me.LabelJobNumber.Text
                    If Me.JobNum = 0 Then
                        Me.JobNum = dt.Rows(0)("JOB_NUMBER")
                    End If
                Else
                    Session("EstimateSendJobNum") = ""
                End If
                If IsDBNull(dt.Rows(0)("JOB_DESC")) = False Then
                    Me.LabelJobDescription.Text = dt.Rows(0)("JOB_DESC")
                    Me.LabelJobDesc.Text = dt.Rows(0)("JOB_DESC")
                End If
                If IsDBNull(dt.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                    Me.LabelJobComponentNumber.Text = dt.Rows(0)("JOB_COMPONENT_NBR").ToString.PadLeft(2, "0")
                    Me.LabelJobComp.Text = dt.Rows(0)("JOB_COMPONENT_NBR").ToString.PadLeft(3, "0")
                    Session("EstimateSendJobComp") = Me.LabelJobComponentNumber.Text
                    If Me.JobCompNum = 0 Then
                        Me.JobCompNum = dt.Rows(0)("JOB_COMPONENT_NBR")
                    End If
                Else
                    Session("EstimateSendJobComp") = ""
                End If
                If IsDBNull(dt.Rows(0)("JOB_COMP_DESC")) = False Then
                    Me.LabelJobComponentDescription.Text = dt.Rows(0)("JOB_COMP_DESC")
                    Me.LabelJobCompDesc.Text = dt.Rows(0)("JOB_COMP_DESC")
                End If
                If IsDBNull(dt.Rows(0)("ESTIMATE_NUMBER")) = False Then
                    Me.LabelEstimateNumber.Text = dt.Rows(0)("ESTIMATE_NUMBER").ToString.PadLeft(6, "0")
                    Me.LabelEstimate.Text = dt.Rows(0)("ESTIMATE_NUMBER").ToString.PadLeft(6, "0")
                End If
                If IsDBNull(dt.Rows(0)("EST_LOG_DESC")) = False Then
                    Me.LabelEstimateDescription.Text = dt.Rows(0)("EST_LOG_DESC")
                    Me.LabelEstimateDesc.Text = dt.Rows(0)("EST_LOG_DESC")
                End If
                If IsDBNull(dt.Rows(0)("EST_COMPONENT_NBR")) = False Then
                    Me.LabelEstimateComponentNumber.Text = dt.Rows(0)("EST_COMPONENT_NBR").ToString.PadLeft(2, "0")
                    Me.LabelEstimateComp.Text = dt.Rows(0)("EST_COMPONENT_NBR").ToString.PadLeft(2, "0")
                End If
                If IsDBNull(dt.Rows(0)("EST_COMP_DESC")) = False Then
                    Me.LabelEstimateComponentDescription.Text = dt.Rows(0)("EST_COMP_DESC")
                    Me.LabelEstimateCompDesc.Text = dt.Rows(0)("EST_COMP_DESC")
                End If
                If IsDBNull(dt.Rows(0)("EST_CREATE_DATE")) = False Then
                    Me.LabelEstimateDate.Text = LoGlo.FormatDate(dt.Rows(0)("EST_CREATE_DATE"))
                    Me.hfCreateDate.Value = dt.Rows(0)("EST_CREATE_DATE")
                End If
            End If

            _ClientCodes = New Generic.List(Of String)

            _ClientCodes.Add(Me.LabelClientCode.Text)

            _ProductCodes = New Generic.List(Of String)

            _ProductCodes.Add(Me.LabelClientCode.Text & "|" & Me.LabelDivisionCode.Text & "|" & Me.LabelProductCode.Text)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillLocationDropDown()
        Me.dl_location.Items.Clear()
        Dim oReports As cReports = New cReports(CStr(Session("ConnString")))
        Me.dl_location.DataSource = oReports.GetLocationPO
        Me.dl_location.DataTextField = "ID"
        Me.dl_location.DataValueField = "LOGO_PATH"
        Me.dl_location.DataBind()
        Me.dl_location.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("None"), ""))
    End Sub

    Private Sub LoadPrint()
        Try
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    If RadToolBarButtonClient.Checked = True Then
                        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, DataContext, AdvantageFramework.Estimate.Printing.EstimateFormatTypes.ClientDefault, Me.LabelClientCode.Text).FirstOrDefault()
                    End If
                    If RadToolBarButtonProduct.Checked = True Then
                        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, DataContext, AdvantageFramework.Estimate.Printing.EstimateFormatTypes.ClientDefault, Me.LabelClientCode.Text, Me.LabelClientCode.Text & "|" & Me.LabelDivisionCode.Text & "|" & Me.LabelProductCode.Text).FirstOrDefault()
                    End If
                    If RadToolBarButtonAgency.Checked = True Then
                        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, DataContext, AdvantageFramework.Estimate.Printing.EstimateFormatTypes.Agency).FirstOrDefault()
                    End If
                    If RadToolBarButtonUser.Checked = True Then
                        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, DataContext, AdvantageFramework.Estimate.Printing.EstimateFormatTypes.UserDefault, "", "", _Session.UserCode).FirstOrDefault()
                    End If
                    If RadToolBarButtonOneTime.Checked = True Then
                        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, DataContext, AdvantageFramework.Estimate.Printing.EstimateFormatTypes.OneTime).FirstOrDefault()
                    End If

                    _EstimatePrintingSettings = New Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting)

                    If EstimatePrintingSetting IsNot Nothing Then

                        _EstimatePrintingSettings.Add(New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting(EstimatePrintingSetting))

                    Else

                        _EstimatePrintingSettings.Add(New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting())

                    End If

                End Using

            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadPrintSettings()
        Try
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    If RadToolBarButtonClient.Checked = True Then
                        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettingsWebvantage(DbContext, DataContext, RadToolBarButtonClient.Value, Me.LabelClientCode.Text).FirstOrDefault()
                    End If
                    If RadToolBarButtonProduct.Checked = True Then
                        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettingsWebvantage(DbContext, DataContext, RadToolBarButtonProduct.Value, Me.LabelClientCode.Text, Me.LabelClientCode.Text & "|" & Me.LabelDivisionCode.Text & "|" & Me.LabelProductCode.Text).FirstOrDefault()
                    End If
                    If RadToolBarButtonAgency.Checked = True Then
                        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettingsWebvantage(DbContext, DataContext, RadToolBarButtonAgency.Value).FirstOrDefault()
                    End If
                    If RadToolBarButtonUser.Checked = True Then
                        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettingsWebvantage(DbContext, DataContext, RadToolBarButtonUser.Value, "", "", _Session.UserCode).FirstOrDefault()
                    End If
                    If RadToolBarButtonOneTime.Checked = True Then
                        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettingsWebvantage(DbContext, DataContext, RadToolBarButtonOneTime.Value).FirstOrDefault()
                    End If

                    _EstimatePrintingSettings = New Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting)

                    If EstimatePrintingSetting IsNot Nothing Then
                        Me.RadButtonUseLocationPrintOptions.Checked = EstimatePrintingSetting.UseLocationOptions
                        If Me.RadButtonUseLocationPrintOptions.Checked = False Then
                            Me.RadComboBoxLocation.Enabled = False
                            Me.RadComboBoxLocation.SelectedValue = ""
                        Else
                            If EstimatePrintingSetting.LocationCode <> "" Then
                                Me.RadComboBoxLocation.SelectedValue = EstimatePrintingSetting.LocationCode
                            Else
                                Me.RadComboBoxLocation.SelectedValue = ""
                            End If
                        End If
                        If EstimatePrintingSetting.CustomEstimateID IsNot Nothing Then
                            If EstimatePrintingSetting.CustomEstimateID = 0 Then
                                Me.RadComboBoxCustomEstimate.SelectedValue = ""
                            Else
                                Me.RadComboBoxCustomEstimate.SelectedValue = EstimatePrintingSetting.CustomEstimateID
                            End If
                        Else
                            Me.RadComboBoxCustomEstimate.SelectedValue = ""
                        End If
                        Me.RadTextBoxReportTitle.Text = EstimatePrintingSetting.ReportTitle
                        Me.RadComboBoxAddressBlock.SelectedValue = EstimatePrintingSetting.CDPAddressOption
                        If EstimatePrintingSetting.CDPAddressOption = "1" Then
                            Me.RadComboBoxAddressBlock.SelectedValue = "Client"
                        ElseIf EstimatePrintingSetting.CDPAddressOption = "2" Then
                            Me.RadComboBoxAddressBlock.SelectedValue = "Division"
                        ElseIf EstimatePrintingSetting.CDPAddressOption = "3" Then
                            Me.RadComboBoxAddressBlock.SelectedValue = "Product"
                        ElseIf EstimatePrintingSetting.CDPAddressOption = "4" Then
                            Me.RadComboBoxAddressBlock.SelectedValue = "Contact"
                        Else
                            Me.RadComboBoxAddressBlock.SelectedValue = "Client"
                        End If
                        Me.RadButtonPrintClientName.Checked = EstimatePrintingSetting.PrintClientName
                        Me.RadButtonPrintDivisionName.Checked = EstimatePrintingSetting.PrintDivisionName
                        Me.RadButtonPrintProductName.Checked = EstimatePrintingSetting.PrintProductDescription
                        Me.RadButtonShowCodes.Checked = EstimatePrintingSetting.ShowCodes
                        Me.RadButtonPrintClientName.Checked = EstimatePrintingSetting.PrintClientName
                        Me.RadButtonPrintContactAfterAddress.Checked = EstimatePrintingSetting.PrintContactAfterAddress
                        Me.RadComboBoxContactType.SelectedValue = EstimatePrintingSetting.ContactType
                        Me.RadButtonClientReference.Checked = EstimatePrintingSetting.IncludeClientReference
                        Me.RadButtonAccountExecutive.Checked = EstimatePrintingSetting.IncludeAccountExecutive
                        Me.RadButtonSalesClass.Checked = EstimatePrintingSetting.IncludeSalesClass
                        Me.RadButtonJobDueDate.Checked = EstimatePrintingSetting.IncludeJobDueDate
                        Me.RadButtonIncludeAdNumber.Checked = EstimatePrintingSetting.PrintAdNumber
                        Me.RadButtonEstimateQuantity.Checked = EstimatePrintingSetting.IncludeJobQuantity
                        Me.RadButtonHideRevisionInfo.Checked = EstimatePrintingSetting.HideRevision
                        Me.RadButtonIncludeCostPerUnit.Checked = EstimatePrintingSetting.IncludeCPU
                        Me.RadButtonIncludeCostPerThousand.Checked = EstimatePrintingSetting.IncludeCPM
                        Me.RadButtonEstimateComment.Checked = EstimatePrintingSetting.IncludeEstimateComment
                        Me.RadButtonEstimateComponentComment.Checked = EstimatePrintingSetting.IncludeEstimateComponentComment
                        Me.RadButtonQuoteComment.Checked = EstimatePrintingSetting.IncludeEstimateQuoteComment
                        Me.RadButtonRevisionComment.Checked = EstimatePrintingSetting.IncludeEstimateRevisionComment
                        Me.RadButtonFunctionComment.Checked = EstimatePrintingSetting.IncludeEstimateFunctionComment
                        Me.RadButtonSuppliedByNotes.Checked = EstimatePrintingSetting.IncludeSuppliedByNotes
                        Me.RadButtonHideJobNumberandDescription.Checked = EstimatePrintingSetting.HideJobDescription
                        Me.RadButtonHideComponentNumberandDescription.Checked = EstimatePrintingSetting.HideComponentDescription
                        Me.RadComboBoxFormatType.SelectedValue = EstimatePrintingSetting.ReportFormat

                        If RadComboBoxFormatType.SelectedValue = "2" Or
                           RadComboBoxFormatType.SelectedValue = "3" Or
                           RadComboBoxFormatType.SelectedValue = "4" Or
                           RadComboBoxFormatType.SelectedValue = "5" Or
                           RadComboBoxFormatType.SelectedValue = "6" Or
                           RadComboBoxFormatType.SelectedValue = "7" Then

                            Me.RadComboBoxOption.Items.FindItemByValue("4").Remove()
                            Me.RadComboBoxSignature.Items.FindItemByValue("9").Remove()

                        End If

                        Me.RadButtonIncludeQuantityHours.Checked = EstimatePrintingSetting.IncludeQuantityHours
                        Me.RadButtonIncludeQuantityHoursTotal.Checked = EstimatePrintingSetting.PrintQuantityTotals
                        Me.RadButtonIncludeRate.Checked = EstimatePrintingSetting.IncludeRate
                        Me.RadButtonIncludeNonBillableActuals.Checked = EstimatePrintingSetting.IncludeNonBillable
                        Me.RadButtonIncludeContingency.Checked = EstimatePrintingSetting.TotalsIncludeContingency
                        Me.RadComboBoxSummaryLevel.SelectedValue = EstimatePrintingSetting.SummaryLevel
                        Me.RadComboBoxOption.SelectedValue = EstimatePrintingSetting.GroupingOptionGroupOption
                        'If EstimatePrintingSetting.GroupingOptionGroupOption = "1" Then
                        '    Me.RadComboBoxOption.SelectedValue = "N"
                        'ElseIf EstimatePrintingSetting.GroupingOptionGroupOption = "2" Then
                        '    Me.RadComboBoxOption.SelectedValue = "T"
                        'ElseIf EstimatePrintingSetting.GroupingOptionGroupOption = "3" Then
                        '    Me.RadComboBoxOption.SelectedValue = "H"
                        'ElseIf EstimatePrintingSetting.GroupingOptionGroupOption = "4" Then
                        '    Me.RadComboBoxOption.SelectedValue = "HT"
                        'ElseIf EstimatePrintingSetting.GroupingOptionGroupOption = "5" Then
                        '    Me.RadComboBoxOption.SelectedValue = "I"
                        'ElseIf EstimatePrintingSetting.GroupingOptionGroupOption = "6" Then
                        '    Me.RadComboBoxOption.SelectedValue = "P"
                        'Else
                        '    Me.RadComboBoxOption.SelectedValue = "N"
                        'End If
                        Me.RadTextBoxInsideDescription.Text = EstimatePrintingSetting.GroupingOptionInsideDescription
                        Me.RadTextBoxOutsideDescription.Text = EstimatePrintingSetting.GroupingOptionOutsideDescription
                        If EstimatePrintingSetting.GroupingOptionSortOption = "1" Then
                            Me.RadComboBoxSortOption.SelectedValue = "C"
                        ElseIf EstimatePrintingSetting.GroupingOptionSortOption = "2" Then
                            Me.RadComboBoxSortOption.SelectedValue = "O"
                        Else
                            Me.RadComboBoxSortOption.SelectedValue = "C"
                        End If
                        If EstimatePrintingSetting.GroupingOptionFunctionOption = "1" Then
                            Me.RadComboBoxPrintOption.SelectedValue = "F"
                        ElseIf EstimatePrintingSetting.GroupingOptionFunctionOption = "2" Then
                            Me.RadComboBoxPrintOption.SelectedValue = "C"
                        ElseIf EstimatePrintingSetting.GroupingOptionFunctionOption = "3" Then
                            Me.RadComboBoxPrintOption.SelectedValue = "T"
                        ElseIf EstimatePrintingSetting.GroupingOptionFunctionOption = "4" Then
                            Me.RadComboBoxPrintOption.SelectedValue = "R"
                        ElseIf EstimatePrintingSetting.GroupingOptionFunctionOption = "5" Then
                            Me.RadComboBoxPrintOption.SelectedValue = "N"
                        Else
                            Me.RadComboBoxPrintOption.SelectedValue = "F"
                        End If
                        Me.RadButtonShowZeroFunctionAmounts.Checked = EstimatePrintingSetting.SuppressZeroFunctions
                        Me.RadButtonExcludeEmployeeTimeFunctions.Checked = EstimatePrintingSetting.ExcludeEmployeeTime
                        Me.RadButtonExcludeVendorFunctions.Checked = EstimatePrintingSetting.ExcludeVendor
                        Me.RadButtonExcludeIncomeOnlyFunctions.Checked = EstimatePrintingSetting.ExcludeIncomeOnly
                        Me.RadButtonExcludeNonBillableFunctions.Checked = EstimatePrintingSetting.ExcludeNonbillable
                        Me.RadButtonOverrideConsolidation.Checked = EstimatePrintingSetting.ConsolidationOverride
                        Me.RadButtonShowTaxSeparately.Checked = EstimatePrintingSetting.TotalsShowTaxSeparately
                        Me.RadButtonIndicateTaxableFunctions.Checked = EstimatePrintingSetting.IndicateTaxableFunctions
                        Me.RadButtonShowCommissionSeparately.Checked = EstimatePrintingSetting.TotalsShowCommissionSeparately
                        Me.RadButtonIndicateCommissionSeparately.Checked = EstimatePrintingSetting.IndicateCommissionFunctions
                        Me.RadButtonShowContingencySeparately.Checked = EstimatePrintingSetting.TotalsShowContingencySeparately
                        Me.RadButtonSubtotalsOnly.Checked = EstimatePrintingSetting.SubtotalsOnly
                        Me.RadButtonDefaultFooterComments.Checked = EstimatePrintingSetting.DefaultFooterComment
                        Me.RadComboBoxSignature.SelectedValue = EstimatePrintingSetting.Signature
                        Me.RadButtonExcludeEmployeeSignature.Checked = EstimatePrintingSetting.ExcludeSignatures
                        Me.RadButtonExcludeDateFromSignature.Checked = EstimatePrintingSetting.ExcludeDateFromSignature
                        Me.RadComboBoxFileFormat.SelectedValue = EstimatePrintingSetting.FileFormat

                        If Me.RadComboBoxOption.SelectedValue = "5" Then
                            Me.RadTextBoxInsideDescription.Visible = True
                            Me.RadTextBoxOutsideDescription.Visible = True
                        Else
                            Me.RadTextBoxInsideDescription.Visible = False
                            Me.RadTextBoxOutsideDescription.Visible = False
                        End If

                        If Me.RadComboBoxPrintOption.SelectedValue = "C" Then
                            Me.RadButtonIncludeRate.Checked = False
                            Me.RadButtonIncludeRate.Enabled = False
                            Me.RadButtonIncludeRatewithMarkup.Checked = False
                            Me.RadButtonIncludeRatewithMarkup.Enabled = False
                        ElseIf Me.RadComboBoxPrintOption.SelectedValue = "F" And RadButtonOverrideConsolidation.Checked = False Then
                            Me.RadButtonIncludeRate.Checked = False
                            Me.RadButtonIncludeRate.Enabled = False
                            Me.RadButtonIncludeRatewithMarkup.Checked = False
                            Me.RadButtonIncludeRatewithMarkup.Enabled = False
                        Else
                            'Me.RadButtonIncludeRate.Checked = True
                            Me.RadButtonIncludeRate.Enabled = True
                            Me.RadButtonIncludeRatewithMarkup.Enabled = True
                        End If

                        If RadButtonIncludeContingency.Checked Then
                            Me.RadButtonShowContingencySeparately.Enabled = True
                        Else
                            Me.RadButtonShowContingencySeparately.Enabled = False
                        End If

                        If RadButtonIncludeQuantityHours.Checked Then
                            Me.RadButtonIncludeQuantityHoursTotal.Enabled = True
                        Else
                            Me.RadButtonIncludeQuantityHoursTotal.Enabled = False
                        End If

                        If Me.RadComboBoxAddressBlock.SelectedValue = "Contact" And Me.RadComboBoxContactType.SelectedValue = "1" Then
                            Me.RadComboBoxContactType.SelectedValue = "0"
                        End If
                        Me.RadButtonShowWatermark.Checked = EstimatePrintingSetting.ShowWatermark
                        Me.RadButtonIncludeRatewithMarkup.Checked = EstimatePrintingSetting.IncludeRateMarkup

                        Me.RadButtonDisplayQuantity.Checked = EstimatePrintingSetting.DisplayQuantity
                        Me.RadButtonDisplayHours.Checked = EstimatePrintingSetting.DisplayHours


                        _EstimatePrintingSettings.Add(New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting(EstimatePrintingSetting))

                    Else

                        _EstimatePrintingSettings.Add(New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting())

                    End If

                End Using

            End Using


        Catch ex As Exception

        End Try
    End Sub

    Private Sub SavePrintSettings()
        Try

            Dim EstimatePrintDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim EstimatePrintDefaultNew As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Database.Entities.EstimatePrintingSetting) = Nothing
            Dim ErrorMessage As String = ""
            Dim RowErrorMessage As String = ""

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                'EstimatePrintingSettings = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Load(DataContext).ToList

                'LoadPrint()

                'If _EstimatePrintingSettings IsNot Nothing AndAlso _EstimatePrintingSettings.Count > 0 Then

                'EstimatePrintingSetting = _EstimatePrintingSettings(0)

                'If EstimatePrintingSetting IsNot Nothing Then

                '    If EstimatePrintingSetting.LocationCode Is Nothing Then
                '        EstimatePrintingSetting.LocationCode = ""
                '    End If

                For Each EstimatePrintDefault In LoadEstimatePrintingSettings(DataContext, RadToolBarButtonAgencySave.Checked, RadToolBarButtonClientSave.Checked, RadToolBarButtonProductSave.Checked, RadToolBarButtonUserSave.Checked)

                    ' DataContext.UpdateObject(EstimatePrintDefault)
                    If EstimatePrintDefault.ID = 0 Then
                        'EstimatePrintingSetting.Update(EstimatePrintDefault, EstimatePrintingSetting)
                        EstimatePrintDefault.UseLocationOptions = Convert.ToInt64(Me.RadButtonUseLocationPrintOptions.Checked)
                        EstimatePrintDefault.LocationCode = Me.RadComboBoxLocation.SelectedValue
                        If Me.RadComboBoxCustomEstimate.SelectedValue = "" Then
                            EstimatePrintDefault.CustomEstimateID = Convert.ToInt64(0)
                        Else
                            EstimatePrintDefault.CustomEstimateID = Convert.ToInt64(Me.RadComboBoxCustomEstimate.SelectedValue)
                        End If
                        EstimatePrintDefault.ReportTitle = Me.RadTextBoxReportTitle.Text
                        If Me.RadComboBoxAddressBlock.SelectedValue = "Client" Then
                            EstimatePrintDefault.CDPAddressOption = "1"
                        ElseIf Me.RadComboBoxAddressBlock.SelectedValue = "Division" Then
                            EstimatePrintDefault.CDPAddressOption = "2"
                        ElseIf Me.RadComboBoxAddressBlock.SelectedValue = "Product" Then
                            EstimatePrintDefault.CDPAddressOption = "3"
                        ElseIf Me.RadComboBoxAddressBlock.SelectedValue = "Contact" Then
                            EstimatePrintDefault.CDPAddressOption = "4"
                        Else
                            EstimatePrintDefault.CDPAddressOption = "1"
                        End If
                        EstimatePrintDefault.PrintClientName = Convert.ToInt64(Me.RadButtonPrintClientName.Checked)
                        EstimatePrintDefault.PrintDivisionName = Convert.ToInt64(Me.RadButtonPrintDivisionName.Checked)
                        EstimatePrintDefault.PrintProductDescription = Convert.ToInt64(Me.RadButtonPrintProductName.Checked)
                        EstimatePrintDefault.ShowCodes = Convert.ToInt64(Me.RadButtonShowCodes.Checked)
                        EstimatePrintDefault.PrintClientName = Convert.ToInt64(Me.RadButtonPrintClientName.Checked)
                        EstimatePrintDefault.PrintContactAfterAddress = Convert.ToInt64(Me.RadButtonPrintContactAfterAddress.Checked)
                        EstimatePrintDefault.ContactType = Me.RadComboBoxContactType.SelectedValue
                        EstimatePrintDefault.IncludeClientReference = Convert.ToInt64(Me.RadButtonClientReference.Checked)
                        EstimatePrintDefault.IncludeAccountExecutive = Convert.ToInt64(Me.RadButtonAccountExecutive.Checked)
                        EstimatePrintDefault.IncludeSalesClass = Convert.ToInt64(Me.RadButtonSalesClass.Checked)
                        EstimatePrintDefault.IncludeJobDueDate = Convert.ToInt64(Me.RadButtonJobDueDate.Checked)
                        EstimatePrintDefault.PrintAdNumber = Convert.ToInt64(Me.RadButtonIncludeAdNumber.Checked)
                        EstimatePrintDefault.IncludeJobQuantity = Convert.ToInt64(Me.RadButtonEstimateQuantity.Checked)
                        EstimatePrintDefault.HideRevision = Convert.ToInt64(Me.RadButtonHideRevisionInfo.Checked)
                        EstimatePrintDefault.IncludeCPU = Convert.ToInt64(Me.RadButtonIncludeCostPerUnit.Checked)
                        EstimatePrintDefault.IncludeCPM = Convert.ToInt64(Me.RadButtonIncludeCostPerThousand.Checked)
                        EstimatePrintDefault.IncludeEstimateComment = Convert.ToInt64(Me.RadButtonEstimateComment.Checked)
                        EstimatePrintDefault.IncludeEstimateComponentComment = Convert.ToInt64(Me.RadButtonEstimateComponentComment.Checked)
                        EstimatePrintDefault.IncludeEstimateQuoteComment = Convert.ToInt64(Me.RadButtonQuoteComment.Checked)
                        EstimatePrintDefault.IncludeEstimateRevisionComment = Convert.ToInt64(Me.RadButtonRevisionComment.Checked)
                        EstimatePrintDefault.IncludeEstimateFunctionComment = Convert.ToInt64(Me.RadButtonFunctionComment.Checked)
                        EstimatePrintDefault.IncludeSuppliedByNotes = Convert.ToInt64(Me.RadButtonSuppliedByNotes.Checked)
                        EstimatePrintDefault.HideJobDescription = Convert.ToInt64(Me.RadButtonHideJobNumberandDescription.Checked)
                        EstimatePrintDefault.HideComponentDescription = Convert.ToInt64(Me.RadButtonHideComponentNumberandDescription.Checked)
                        EstimatePrintDefault.ReportFormat = Me.RadComboBoxFormatType.SelectedValue
                        EstimatePrintDefault.IncludeQuantityHours = Convert.ToInt64(Me.RadButtonIncludeQuantityHours.Checked)
                        EstimatePrintDefault.PrintQuantityTotals = Convert.ToInt64(Me.RadButtonIncludeQuantityHoursTotal.Checked)
                        EstimatePrintDefault.IncludeRate = Convert.ToInt64(Me.RadButtonIncludeRate.Checked)
                        EstimatePrintDefault.IncludeNonBillable = Convert.ToInt64(Me.RadButtonIncludeNonBillableActuals.Checked)
                        EstimatePrintDefault.IncludeContingency = Convert.ToInt64(Me.RadButtonIncludeContingency.Checked)
                        EstimatePrintDefault.SummaryLevel = Me.RadComboBoxSummaryLevel.SelectedValue
                        EstimatePrintDefault.GroupOption = Me.RadComboBoxOption.SelectedValue
                        EstimatePrintDefault.ShowWatermark = Convert.ToInt64(Me.RadButtonShowWatermark.Checked)
                        EstimatePrintDefault.IncludeRateMarkup = Convert.ToInt64(Me.RadButtonIncludeRatewithMarkup.Checked)
                        EstimatePrintDefault.DisplayQuantity = Convert.ToInt64(Me.RadButtonDisplayQuantity.Checked)
                        EstimatePrintDefault.DisplayHours = Convert.ToInt64(Me.RadButtonDisplayHours.Checked)


                        'If Me.RadComboBoxOption.SelectedValue = "N" Then
                        '    EstimatePrintDefault.GroupOption = "1"
                        'ElseIf Me.RadComboBoxOption.SelectedValue = "T" Then
                        '    EstimatePrintDefault.GroupOption = "2"
                        'ElseIf Me.RadComboBoxOption.SelectedValue = "H" Then
                        '    EstimatePrintDefault.GroupOption = "3"
                        'ElseIf Me.RadComboBoxOption.SelectedValue = "HT" Then
                        '    EstimatePrintDefault.GroupOption = "4"
                        'ElseIf Me.RadComboBoxOption.SelectedValue = "I" Then
                        '    EstimatePrintDefault.GroupOption = "5"
                        'ElseIf Me.RadComboBoxOption.SelectedValue = "P" Then
                        '    EstimatePrintDefault.GroupOption = "6"
                        'Else
                        '    EstimatePrintDefault.GroupOption = "1"
                        'End If
                        EstimatePrintDefault.InsideDescription = Me.RadTextBoxInsideDescription.Text
                        EstimatePrintDefault.OutsideDescription = Me.RadTextBoxOutsideDescription.Text
                        If Me.RadComboBoxSortOption.SelectedValue = "C" Then
                            EstimatePrintDefault.SortOption = "1"
                        ElseIf Me.RadComboBoxSortOption.SelectedValue = "O" Then
                            EstimatePrintDefault.SortOption = "2"
                        Else
                            EstimatePrintDefault.SortOption = "1"
                        End If
                        If Me.RadComboBoxPrintOption.SelectedValue = "F" Then
                            EstimatePrintDefault.FunctionOption = "1"
                        ElseIf Me.RadComboBoxPrintOption.SelectedValue = "C" Then
                            EstimatePrintDefault.FunctionOption = "2"
                        ElseIf Me.RadComboBoxPrintOption.SelectedValue = "T" Then
                            EstimatePrintDefault.FunctionOption = "3"
                        ElseIf Me.RadComboBoxPrintOption.SelectedValue = "R" Then
                            EstimatePrintDefault.FunctionOption = "4"
                        ElseIf Me.RadComboBoxPrintOption.SelectedValue = "N" Then
                            EstimatePrintDefault.FunctionOption = "5"
                        Else
                            EstimatePrintDefault.FunctionOption = "1"
                        End If
                        EstimatePrintDefault.SuppressZeroFunctions = Convert.ToInt64(Me.RadButtonShowZeroFunctionAmounts.Checked)
                        EstimatePrintDefault.ExcludeEmployeeTime = Convert.ToInt64(Me.RadButtonExcludeEmployeeTimeFunctions.Checked)
                        EstimatePrintDefault.ExcludeVendor = Convert.ToInt64(Me.RadButtonExcludeVendorFunctions.Checked)
                        EstimatePrintDefault.ExcludeIncomeOnly = Convert.ToInt64(Me.RadButtonExcludeIncomeOnlyFunctions.Checked)
                        EstimatePrintDefault.ExcludeNonbillable = Convert.ToInt64(Me.RadButtonExcludeNonBillableFunctions.Checked)
                        EstimatePrintDefault.ConsolidationOverride = Convert.ToInt64(Me.RadButtonOverrideConsolidation.Checked)
                        EstimatePrintDefault.ShowTaxSeparately = Convert.ToInt64(Me.RadButtonShowTaxSeparately.Checked)
                        EstimatePrintDefault.IndicateTaxableFunctions = Convert.ToInt64(Me.RadButtonIndicateTaxableFunctions.Checked)
                        EstimatePrintDefault.ShowCommissionSeparately = Convert.ToInt64(Me.RadButtonShowCommissionSeparately.Checked)
                        EstimatePrintDefault.IndicateCommissionFunctions = Convert.ToInt64(Me.RadButtonIndicateCommissionSeparately.Checked)
                        EstimatePrintDefault.ShowContingencySeparately = Convert.ToInt64(Me.RadButtonShowContingencySeparately.Checked)
                        EstimatePrintDefault.SubtotalsOnly = Convert.ToInt64(Me.RadButtonSubtotalsOnly.Checked)
                        EstimatePrintDefault.DefaultFooterComment = Convert.ToInt64(Me.RadButtonDefaultFooterComments.Checked)
                        EstimatePrintDefault.Signature = Me.RadComboBoxSignature.SelectedValue
                        EstimatePrintDefault.ExcludeSignatures = Convert.ToInt64(Me.RadButtonExcludeEmployeeSignature.Checked)
                        EstimatePrintDefault.ExcludeDateFromSignature = Convert.ToInt64(Me.RadButtonExcludeDateFromSignature.Checked)
                        'EstimatePrintDefault.ClientCode = Me.LabelClient.Text
                        EstimatePrintDefault.FileFormat = Me.RadComboBoxFileFormat.SelectedValue
                        AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Insert(DataContext, EstimatePrintDefault)
                    Else
                        EstimatePrintDefault.UseLocationOptions = Convert.ToInt64(Me.RadButtonUseLocationPrintOptions.Checked)
                        EstimatePrintDefault.LocationCode = Me.RadComboBoxLocation.SelectedValue
                        If Me.RadComboBoxCustomEstimate.SelectedValue = "" Then
                            EstimatePrintDefault.CustomEstimateID = Convert.ToInt64(0)
                        Else
                            EstimatePrintDefault.CustomEstimateID = Convert.ToInt64(Me.RadComboBoxCustomEstimate.SelectedValue)
                        End If
                        EstimatePrintDefault.ReportTitle = Me.RadTextBoxReportTitle.Text
                        If Me.RadComboBoxAddressBlock.SelectedValue = "Client" Then
                            EstimatePrintDefault.CDPAddressOption = "1"
                        ElseIf Me.RadComboBoxAddressBlock.SelectedValue = "Division" Then
                            EstimatePrintDefault.CDPAddressOption = "2"
                        ElseIf Me.RadComboBoxAddressBlock.SelectedValue = "Product" Then
                            EstimatePrintDefault.CDPAddressOption = "3"
                        ElseIf Me.RadComboBoxAddressBlock.SelectedValue = "Contact" Then
                            EstimatePrintDefault.CDPAddressOption = "4"
                        Else
                            EstimatePrintDefault.CDPAddressOption = "1"
                        End If
                        EstimatePrintDefault.PrintClientName = Convert.ToInt64(Me.RadButtonPrintClientName.Checked)
                        EstimatePrintDefault.PrintDivisionName = Convert.ToInt64(Me.RadButtonPrintDivisionName.Checked)
                        EstimatePrintDefault.PrintProductDescription = Convert.ToInt64(Me.RadButtonPrintProductName.Checked)
                        EstimatePrintDefault.ShowCodes = Convert.ToInt64(Me.RadButtonShowCodes.Checked)
                        EstimatePrintDefault.PrintClientName = Convert.ToInt64(Me.RadButtonPrintClientName.Checked)
                        EstimatePrintDefault.PrintContactAfterAddress = Convert.ToInt64(Me.RadButtonPrintContactAfterAddress.Checked)
                        EstimatePrintDefault.ContactType = Me.RadComboBoxContactType.SelectedValue
                        EstimatePrintDefault.IncludeClientReference = Convert.ToInt64(Me.RadButtonClientReference.Checked)
                        EstimatePrintDefault.IncludeAccountExecutive = Convert.ToInt64(Me.RadButtonAccountExecutive.Checked)
                        EstimatePrintDefault.IncludeSalesClass = Convert.ToInt64(Me.RadButtonSalesClass.Checked)
                        EstimatePrintDefault.IncludeJobDueDate = Convert.ToInt64(Me.RadButtonJobDueDate.Checked)
                        EstimatePrintDefault.PrintAdNumber = Convert.ToInt64(Me.RadButtonIncludeAdNumber.Checked)
                        EstimatePrintDefault.IncludeJobQuantity = Convert.ToInt64(Me.RadButtonEstimateQuantity.Checked)
                        EstimatePrintDefault.HideRevision = Convert.ToInt64(Me.RadButtonHideRevisionInfo.Checked)
                        EstimatePrintDefault.IncludeCPU = Convert.ToInt64(Me.RadButtonIncludeCostPerUnit.Checked)
                        EstimatePrintDefault.IncludeCPM = Convert.ToInt64(Me.RadButtonIncludeCostPerThousand.Checked)
                        EstimatePrintDefault.IncludeEstimateComment = Convert.ToInt64(Me.RadButtonEstimateComment.Checked)
                        EstimatePrintDefault.IncludeEstimateComponentComment = Convert.ToInt64(Me.RadButtonEstimateComponentComment.Checked)
                        EstimatePrintDefault.IncludeEstimateQuoteComment = Convert.ToInt64(Me.RadButtonQuoteComment.Checked)
                        EstimatePrintDefault.IncludeEstimateRevisionComment = Convert.ToInt64(Me.RadButtonRevisionComment.Checked)
                        EstimatePrintDefault.IncludeEstimateFunctionComment = Convert.ToInt64(Me.RadButtonFunctionComment.Checked)
                        EstimatePrintDefault.IncludeSuppliedByNotes = Convert.ToInt64(Me.RadButtonSuppliedByNotes.Checked)
                        EstimatePrintDefault.HideJobDescription = Convert.ToInt64(Me.RadButtonHideJobNumberandDescription.Checked)
                        EstimatePrintDefault.HideComponentDescription = Convert.ToInt64(Me.RadButtonHideComponentNumberandDescription.Checked)
                        EstimatePrintDefault.ReportFormat = Me.RadComboBoxFormatType.SelectedValue
                        EstimatePrintDefault.IncludeQuantityHours = Convert.ToInt64(Me.RadButtonIncludeQuantityHours.Checked)
                        EstimatePrintDefault.PrintQuantityTotals = Convert.ToInt64(Me.RadButtonIncludeQuantityHoursTotal.Checked)
                        EstimatePrintDefault.IncludeRate = Convert.ToInt64(Me.RadButtonIncludeRate.Checked)
                        EstimatePrintDefault.IncludeNonBillable = Convert.ToInt64(Me.RadButtonIncludeNonBillableActuals.Checked)
                        EstimatePrintDefault.IncludeContingency = Convert.ToInt64(Me.RadButtonIncludeContingency.Checked)
                        EstimatePrintDefault.SummaryLevel = Me.RadComboBoxSummaryLevel.SelectedValue
                        EstimatePrintDefault.GroupOption = Me.RadComboBoxOption.SelectedValue
                        EstimatePrintDefault.ShowWatermark = Convert.ToInt64(Me.RadButtonShowWatermark.Checked)
                        EstimatePrintDefault.IncludeRateMarkup = Convert.ToInt64(Me.RadButtonIncludeRatewithMarkup.Checked)
                        EstimatePrintDefault.DisplayQuantity = Convert.ToInt64(Me.RadButtonDisplayQuantity.Checked)
                        EstimatePrintDefault.DisplayHours = Convert.ToInt64(Me.RadButtonDisplayHours.Checked)
                        'If Me.RadComboBoxOption.SelectedValue = "N" Then
                        '    EstimatePrintDefault.GroupOption = "1"
                        'ElseIf Me.RadComboBoxOption.SelectedValue = "T" Then
                        '    EstimatePrintDefault.GroupOption = "2"
                        'ElseIf Me.RadComboBoxOption.SelectedValue = "H" Then
                        '    EstimatePrintDefault.GroupOption = "3"
                        'ElseIf Me.RadComboBoxOption.SelectedValue = "HT" Then
                        '    EstimatePrintDefault.GroupOption = "4"
                        'ElseIf Me.RadComboBoxOption.SelectedValue = "I" Then
                        '    EstimatePrintDefault.GroupOption = "5"
                        'ElseIf Me.RadComboBoxOption.SelectedValue = "P" Then
                        '    EstimatePrintDefault.GroupOption = "6"
                        'Else
                        '    EstimatePrintDefault.GroupOption = "1"
                        'End If
                        EstimatePrintDefault.InsideDescription = Me.RadTextBoxInsideDescription.Text
                        EstimatePrintDefault.OutsideDescription = Me.RadTextBoxOutsideDescription.Text
                        If Me.RadComboBoxSortOption.SelectedValue = "C" Then
                            EstimatePrintDefault.SortOption = "1"
                        ElseIf Me.RadComboBoxSortOption.SelectedValue = "O" Then
                            EstimatePrintDefault.SortOption = "2"
                        Else
                            EstimatePrintDefault.SortOption = "1"
                        End If
                        If Me.RadComboBoxPrintOption.SelectedValue = "F" Then
                            EstimatePrintDefault.FunctionOption = "1"
                        ElseIf Me.RadComboBoxPrintOption.SelectedValue = "C" Then
                            EstimatePrintDefault.FunctionOption = "2"
                        ElseIf Me.RadComboBoxPrintOption.SelectedValue = "T" Then
                            EstimatePrintDefault.FunctionOption = "3"
                        ElseIf Me.RadComboBoxPrintOption.SelectedValue = "R" Then
                            EstimatePrintDefault.FunctionOption = "4"
                        ElseIf Me.RadComboBoxPrintOption.SelectedValue = "N" Then
                            EstimatePrintDefault.FunctionOption = "5"
                        Else
                            EstimatePrintDefault.FunctionOption = "1"
                        End If
                        EstimatePrintDefault.SuppressZeroFunctions = Convert.ToInt64(Me.RadButtonShowZeroFunctionAmounts.Checked)
                        EstimatePrintDefault.ExcludeEmployeeTime = Convert.ToInt64(Me.RadButtonExcludeEmployeeTimeFunctions.Checked)
                        EstimatePrintDefault.ExcludeVendor = Convert.ToInt64(Me.RadButtonExcludeVendorFunctions.Checked)
                        EstimatePrintDefault.ExcludeIncomeOnly = Convert.ToInt64(Me.RadButtonExcludeIncomeOnlyFunctions.Checked)
                        EstimatePrintDefault.ExcludeNonbillable = Convert.ToInt64(Me.RadButtonExcludeNonBillableFunctions.Checked)
                        EstimatePrintDefault.ConsolidationOverride = Convert.ToInt64(Me.RadButtonOverrideConsolidation.Checked)
                        EstimatePrintDefault.ShowTaxSeparately = Convert.ToInt64(Me.RadButtonShowTaxSeparately.Checked)
                        EstimatePrintDefault.IndicateTaxableFunctions = Convert.ToInt64(Me.RadButtonIndicateTaxableFunctions.Checked)
                        EstimatePrintDefault.ShowCommissionSeparately = Convert.ToInt64(Me.RadButtonShowCommissionSeparately.Checked)
                        EstimatePrintDefault.IndicateCommissionFunctions = Convert.ToInt64(Me.RadButtonIndicateCommissionSeparately.Checked)
                        EstimatePrintDefault.ShowContingencySeparately = Convert.ToInt64(Me.RadButtonShowContingencySeparately.Checked)
                        EstimatePrintDefault.SubtotalsOnly = Convert.ToInt64(Me.RadButtonSubtotalsOnly.Checked)
                        EstimatePrintDefault.DefaultFooterComment = Convert.ToInt64(Me.RadButtonDefaultFooterComments.Checked)
                        EstimatePrintDefault.Signature = Me.RadComboBoxSignature.SelectedValue
                        EstimatePrintDefault.ExcludeSignatures = Convert.ToInt64(Me.RadButtonExcludeEmployeeSignature.Checked)
                        EstimatePrintDefault.ExcludeDateFromSignature = Convert.ToInt64(Me.RadButtonExcludeDateFromSignature.Checked)
                        EstimatePrintDefault.FileFormat = Me.RadComboBoxFileFormat.SelectedValue
                        AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Update(DataContext, EstimatePrintDefault)
                        'EstimatePrintingSetting.Update(EstimatePrintDefault, EstimatePrintingSetting)
                    End If

                    'EstimatePrintingSetting.Save(EstimatePrintDefault)

                Next

                'If _EstimatePrintingDefault IsNot Nothing Then

                '    EstimatePrintingSetting.Save(_EstimatePrintingDefault)

                'ElseIf _EstimatePrintingSettingClass IsNot Nothing Then

                '    EstimatePrintingSetting.Save(_EstimatePrintingSettingClass)

                'ElseIf EstimatePrintingSettings.Count = 0 Then

                '    _EstimatePrintingDefault = New AdvantageFramework.Database.Entities.EstimatePrintingSetting()
                '    EstimatePrintingSetting.Update(_EstimatePrintingDefault, EstimatePrintingSetting)
                '    _EstimatePrintingDefault.ClientOrDefault = 0
                '    AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Insert(DataContext, _EstimatePrintingDefault)
                '    _EstimatePrintingDefault = New AdvantageFramework.Database.Entities.EstimatePrintingSetting()
                '    EstimatePrintingSetting.Update(_EstimatePrintingDefault, EstimatePrintingSetting)
                '    _EstimatePrintingDefault.ClientOrDefault = 1
                '    AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Insert(DataContext, _EstimatePrintingDefault)

                'End If

                'End If

                'End If

                Try

                    '_EstimatePrintingSettingClass.DatePrint = EstimatePrintingSetting.DatePrint
                    'AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Update(DataContext, EstimatePrintDefault)

                    Dim EstimatePrintSetting As AdvantageFramework.Database.Entities.EstimatePrintSetting = Nothing

                    EstimatePrintSetting = AdvantageFramework.Database.Procedures.EstimatePrintSetting.LoadByEstimatePrintSettingUserID(DataContext, _Session.UserCode)
                    If EstimatePrintSetting IsNot Nothing Then
                        EstimatePrintSetting.PrintCustom = False
                        AdvantageFramework.Database.Procedures.EstimatePrintSetting.Update(DataContext, EstimatePrintSetting)
                    Else
                        EstimatePrintSetting = New AdvantageFramework.Database.Entities.EstimatePrintSetting
                        EstimatePrintSetting.DataContext = DataContext
                        EstimatePrintSetting.UserID = _Session.UserCode
                        EstimatePrintSetting.SelectBy = Nothing
                        EstimatePrintSetting.DateToPrint = Nothing
                        EstimatePrintSetting.ShowTaxSeparately = 0
                        EstimatePrintSetting.IndicateTaxableFunctions = 0
                        EstimatePrintSetting.ShowCommissionSeparately = 0
                        EstimatePrintSetting.IndicateCommissionFunctions = 0
                        EstimatePrintSetting.FunctionOption = "C"
                        EstimatePrintSetting.GroupOption = "F"
                        EstimatePrintSetting.SortOption = "C"
                        EstimatePrintSetting.InsideDescription = ""
                        EstimatePrintSetting.OutsideDescription = ""
                        EstimatePrintSetting.IncludeEstimateComment = 0
                        EstimatePrintSetting.IncludeEstimateComponentComment = 0
                        EstimatePrintSetting.IncludeEstimateQuoteComment = 0
                        EstimatePrintSetting.IncludeEstimateRevisionComment = 0
                        EstimatePrintSetting.IncludeEstimateFunctionComment = 0
                        EstimatePrintSetting.DefaultFooterComment = 0
                        EstimatePrintSetting.IncludeClientReference = 0
                        EstimatePrintSetting.IncludeAccountExecutive = 0
                        EstimatePrintSetting.IncludeSalesClass = 0
                        EstimatePrintSetting.IncludeSpecifications = 0
                        EstimatePrintSetting.IncludeJobQuantity = 0
                        EstimatePrintSetting.IncludeContingency = 0
                        EstimatePrintSetting.SuppressZeroFunctions = 0
                        EstimatePrintSetting.LocationCode = Nothing
                        EstimatePrintSetting.LogoPath = Nothing
                        EstimatePrintSetting.ReportFormat = "001"
                        EstimatePrintSetting.IncludeNonBillable = 0
                        EstimatePrintSetting.PrintDivisionName = 0
                        EstimatePrintSetting.PrintProductDescription = 0
                        EstimatePrintSetting.IncludeQuantityHours = 0
                        EstimatePrintSetting.IncludeQuantityHours = 0
                        EstimatePrintSetting.ConsolidationOverride = 0
                        EstimatePrintSetting.SubtotalsOnly = 0
                        EstimatePrintSetting.IncludeCPU = 0
                        EstimatePrintSetting.IncludeCPM = 0
                        EstimatePrintSetting.ReportTitle = ""
                        EstimatePrintSetting.IncludeSuppliedByNotes = 0
                        EstimatePrintSetting.ShowContingencySeparately = 0
                        EstimatePrintSetting.Signature = 0
                        EstimatePrintSetting.HideComponentDescription = 0
                        EstimatePrintSetting.HideRevision = 0
                        EstimatePrintSetting.IncludeJobDueDate = 0
                        EstimatePrintSetting.UseEmployeeSignature = 0
                        EstimatePrintSetting.ExcludeEmployeeTime = 0
                        EstimatePrintSetting.ExcludeVendor = 0
                        EstimatePrintSetting.ExcludeIncomeOnly = 0
                        EstimatePrintSetting.ExcludeSignatures = 0
                        EstimatePrintSetting.IncludeCampaignSummary = 0
                        EstimatePrintSetting.IncludeVendorDescription = 0
                        EstimatePrintSetting.ExcludeNonbillable = 0
                        EstimatePrintSetting.CDPAddressOption = "Client"
                        EstimatePrintSetting.IncludeRate = 0
                        EstimatePrintSetting.CombineComponents = 0
                        EstimatePrintSetting.PrintClientName = 0
                        EstimatePrintSetting.IncludeFunctionComment = 0
                        EstimatePrintSetting.PrintAdNumber = 0
                        EstimatePrintSetting.FileFormat = Nothing
                        EstimatePrintSetting.PrintCustom = False
                        EstimatePrintDefault.ShowWatermark = 0
                        EstimatePrintDefault.IncludeRateMarkup = 0
                        EstimatePrintDefault.DisplayQuantity = 0
                        EstimatePrintDefault.DisplayHours = 0
                        AdvantageFramework.Database.Procedures.EstimatePrintSetting.Insert(DataContext, EstimatePrintSetting)
                    End If



                Catch ex As Exception

                End Try

            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub StandardPrint()
        Try
            Dim EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuoteList = Nothing
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuoteList) = Nothing
            Dim EstimateFormat As AdvantageFramework.Estimate.Printing.ReportFormats = AdvantageFramework.Estimate.Printing.ReportFormats.OneQuotePerPage
            Dim EstimatePrintingSettings As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim EstimatePrintSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintSetting = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

            Dim chk As CheckBox
            Dim quotes As String = ""
            Dim qtedesc As String = ""
            Dim qtedescs As String = ""
            Dim comps As String = ""
            Dim qte As Integer = 0
            Dim comp As Integer = 0
            Dim count As Integer = 0
            Dim combine As Integer = 0

            Session("EstimatingPrintedDate") = Me.RadDatePickerEstimate.SelectedDate

            If Me.RadComboBoxSummaryLevel.SelectedValue = "2" Then
                If Me.RadComboBoxSummaryLevel.SelectedValue = "2" Then
                    combine = 1
                End If
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridQuotes.MasterTableView.Items
                    chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                    If Me._PrintSendAll = True Then chk.Checked = True
                    If chk.Checked = True Then
                        Try
                            If comp > 0 And comp <> gridDataItem.GetDataKeyValue("EstimateComponentNumber") Then
                                If count > 4 And Me.RadComboBoxFormatType.SelectedValue = "2" Then
                                    Me.ShowMessage("Only 4 quotes may be selected per component for this report format.")
                                    Exit Sub
                                End If
                                If count > 2 And Me.RadComboBoxFormatType.SelectedValue = "314" Then
                                    Me.ShowMessage("Maximum 2 quotes may be selected per component for this report format.")
                                    Exit Sub
                                End If
                                count = 0
                            End If
                            comp = gridDataItem.GetDataKeyValue("EstimateComponentNumber")
                            qte = CInt(gridDataItem("colEST_QUOTE_NBR").Text.Replace("&nbsp;", ""))
                            qtedesc = gridDataItem("colEST_QUOTE_DESC").Text.Replace("&nbsp;", "").Replace(",", "_")
                        Catch ex As Exception
                            qte = 0
                            comp = 0
                            qtedesc = ""
                        End Try
                        quotes &= qte & ","
                        qtedescs &= qtedesc & ","
                        comps &= comp & ","
                        count += 1
                    End If
                Next
                If count = 0 And Me._SelectedQuoteNumbers = "" Then

                    Me.ShowMessage("Please select at least one quote to print/send")
                    Exit Sub

                ElseIf count = 0 And Me._SelectedQuoteNumbers <> "" Then

                    quotes = Me._SelectedQuoteNumbers
                    qtedescs = Me._SelectedQuoteDescriptions
                    Dim arQ() As String
                    arQ = Me._SelectedQuoteNumbers.Split(",")
                    count = arQ.Length

                    For w As Integer = 0 To arQ.Length - 1
                        If arQ(w) <> "" Then
                            comps &= Me.EstCompNum.ToString & ","
                        End If
                    Next

                End If
                If comps.Trim() = "" And Me.EstCompNum > 0 Then
                    comps = Me.EstCompNum.ToString() & ","
                End If
                If count > 4 And Me.RadComboBoxFormatType.SelectedValue = "2" Then
                    Me.ShowMessage("Only 4 quotes may be selected per component for this report format.")
                    Exit Sub
                End If
                If count > 2 And Me.RadComboBoxFormatType.SelectedValue = "314" Then
                    Me.ShowMessage("Maximum 2 quotes may be selected per component for this report format.")
                    Exit Sub
                End If

                Session("EstimatingQteDescs") = qtedescs
                Dim strJC As String


                Dim qs2 As New AdvantageFramework.Web.QueryString()
                With qs2
                    .Page = "Reporting_Output.aspx"
                    .EstimateNumber = Me.EstNum
                    If comp = 0 And (Me._From = "EstQuote" Or Me._From = "Est") Then
                        .EstimateComponentNumber = Me.EstCompNum
                    Else
                        .EstimateComponentNumber = comp
                    End If
                    .Add("Type", Me.RadComboBoxFileFormat.SelectedValue)
                    .Add("caller", "Estimating_Print")
                    '.Add("Report", "Estimating" & Me.ddReportFormat.SelectedValue)
                    .Add("quotes", quotes)
                    .Add("comps", comps)
                    .Add("from", _From)
                    .Add("combine", combine)
                    .JobNumber = Me.JobNum.ToString()
                    .JobComponentNumber = Me.JobCompNum.ToString()
                    .Add("estdate", Session("EstimatingPrintedDate"))
                    .Add("settingType", _EstimateFormatType)
                End With
                Session("EstimatingPrintJobNumber") = Me.JobNum
                Session("EstimatingPrintJobComponentNumber") = Me.JobCompNum
                Session("EstimatingPrintEstimatingNumber") = Me.EstNum
                Session("EstimatingPrintEstimatingComponentNumber") = Me.EstCompNum
                Session("EstimatingPrintType") = Me.RadComboBoxFileFormat.SelectedValue
                Session("EstimatingPrintReport") = "Estimating" & Me.ddReportFormat.SelectedValue
                'Session("EstimatingPrintOption") = addressoption
                Session("EstimatingPrintQuotes") = quotes
                Session("EstimatingPrintComp") = comps
                Session("EstimatingPrintFormatType") = _EstimateFormatType
                Session("EstimatingPrintFrom") = _From
                Session("EstimatingPrintCombine") = combine
                'Session("EstimatingPrintedDate") 

                Dim strBuilder2 As System.Text.StringBuilder = New System.Text.StringBuilder
                strBuilder2.Append("<script language='javascript'>")
                strBuilder2.Append("window.open('" & qs2.
                                   ToString(True) & "', '', 'width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
                strBuilder2.Append("</")
                strBuilder2.Append("script>")
                Page.RegisterStartupScript("JC" & comp, strBuilder2.ToString())

            Else
                Dim MultipleReportPrintCount As Integer = 0
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridQuotes.MasterTableView.Items
                    chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                    If Me._PrintSendAll = True Then chk.Checked = True
                    If chk.Checked = True Then
                        If comp > 0 And comp <> gridDataItem.GetDataKeyValue("EstimateComponentNumber") Then
                            If count > 4 And Me.RadComboBoxFormatType.SelectedValue = "2" Then
                                Me.ShowMessage("Only 4 quotes may be selected per component for this report format.")
                                Exit Sub
                            End If
                            If count > 2 And Me.RadComboBoxFormatType.SelectedValue = "314" Then
                                Me.ShowMessage("Maximum 2 quotes may be selected per component for this report format.")
                                Exit Sub
                            End If
                            'quotes = MiscFN.RemoveTrailingDelimiter(quotes, ",")
                            Dim qs As New AdvantageFramework.Web.QueryString()
                            With qs
                                .Page = "Reporting_Output.aspx"
                                .EstimateNumber = Me.EstNum
                                .EstimateComponentNumber = comp
                                .Add("Type", Me.RadComboBoxFileFormat.SelectedValue)
                                .Add("caller", "Estimating_Print")
                                '.Add("Report", "Estimating" & Me.ddReportFormat.SelectedValue)
                                .Add("quotes", quotes)
                                .Add("from", _From)
                                .Add("combine", combine)
                                .JobNumber = Me.JobNum.ToString()
                                .JobComponentNumber = Me.JobCompNum.ToString()
                                .Add("estdate", Session("EstimatingPrintedDate"))
                                .Add("settingType", _EstimateFormatType)
                            End With
                            Session("EstimatingPrintJobNumber") = Me.JobNum
                            Session("EstimatingPrintJobComponentNumber") = Me.JobCompNum
                            Session("EstimatingPrintEstimatingNumber") = Me.EstNum
                            Session("EstimatingPrintEstimatingComponentNumber") = Me.EstCompNum
                            Session("EstimatingPrintType") = Me.RadComboBoxFileFormat.SelectedValue
                            Session("EstimatingPrintReport") = "Estimating" & Me.ddReportFormat.SelectedValue
                            'Session("EstimatingPrintOption") = addressoption
                            Session("EstimatingPrintQuotes") = quotes
                            Session("EstimatingPrintComp") = comps
                            Session("EstimatingPrintFormatType") = _EstimateFormatType
                            Session("EstimatingPrintFrom") = _From
                            Session("EstimatingPrintCombine") = combine
                            'Session("EstimatingPrintedDate") 

                            Dim strJCBuilder2 As System.Text.StringBuilder = New System.Text.StringBuilder
                            strJCBuilder2.Append("<script language='javascript'>")
                            strJCBuilder2.Append("window.open('" & qs.ToString(True) & "', '', 'width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
                            strJCBuilder2.Append("</")
                            strJCBuilder2.Append("script>")
                            Page.RegisterStartupScript("EC" & comp, strJCBuilder2.ToString())
                            Session("EstimatingQteDescs" & comp.ToString()) = qtedescs
                            MultipleReportPrintCount += 1
                            quotes = ""
                            qtedescs = ""
                            count = 0
                        End If
                        Try
                            comp = gridDataItem.GetDataKeyValue("EstimateComponentNumber")
                            qte = CInt(gridDataItem("colEST_QUOTE_NBR").Text.Replace("&nbsp;", ""))
                            qtedesc = gridDataItem("colEST_QUOTE_DESC").Text.Replace("&nbsp;", "").Replace(",", "_")
                        Catch ex As Exception
                            qte = 0
                            qtedesc = ""
                        End Try
                        quotes &= qte & ","
                        qtedescs &= qtedesc & ","
                        comps &= comp & ","
                        count += 1
                    End If
                Next
                If count = 0 And Me._SelectedQuoteNumbers = "" Then

                    Me.ShowMessage("Please select at least one quote to print/send")
                    Exit Sub

                ElseIf count = 0 And Me._SelectedQuoteNumbers <> "" Then

                    quotes = Me._SelectedQuoteNumbers
                    qtedescs = Me._SelectedQuoteDescriptions
                    Dim arQ() As String
                    arQ = MiscFN.RemoveTrailingDelimiter(Me._SelectedQuoteNumbers, ",").Split(",")
                    count = arQ.Length

                End If
                If count > 4 And Me.RadComboBoxFormatType.SelectedValue = "2" Then
                    Me.ShowMessage("Only 4 quotes may be selected per component for this report format.")
                    Exit Sub
                End If
                If count > 2 And Me.RadComboBoxFormatType.SelectedValue = "314" Then
                    Me.ShowMessage("Maximum 2 quotes may be selected per component for this report format.")
                    Exit Sub
                End If
                If comp = 0 And Me.EstCompNum > 0 Then
                    comp = Me.EstCompNum
                End If
                Session("EstimatingQteDescs" & comp.ToString()) = qtedescs
                Dim qs2 As New AdvantageFramework.Web.QueryString()
                With qs2
                    .Page = "Reporting_Output.aspx"
                    .EstimateNumber = Me.EstNum
                    .EstimateComponentNumber = comp
                    .Add("Type", Me.RadComboBoxFileFormat.SelectedValue)
                    .Add("caller", "Estimating_Print")
                    '.Add("Report", "Estimating" & Me.ddReportFormat.SelectedValue)
                    .Add("quotes", quotes)
                    .Add("from", _From)
                    .Add("combine", combine)
                    .JobNumber = Me.JobNum.ToString()
                    .JobComponentNumber = Me.JobCompNum.ToString()
                    .Add("estdate", Session("EstimatingPrintedDate"))
                    .Add("settingType", _EstimateFormatType)
                End With
                Session("EstimatingPrintJobNumber") = Me.JobNum
                Session("EstimatingPrintJobComponentNumber") = Me.JobCompNum
                Session("EstimatingPrintEstimatingNumber") = Me.EstNum
                Session("EstimatingPrintEstimatingComponentNumber") = Me.EstCompNum
                Session("EstimatingPrintType") = Me.RadComboBoxFileFormat.SelectedValue
                Session("EstimatingPrintReport") = "Estimating" & Me.ddReportFormat.SelectedValue
                'Session("EstimatingPrintOption") = addressoption
                Session("EstimatingPrintQuotes") = quotes
                Session("EstimatingPrintComp") = comps
                Session("EstimatingPrintFormatType") = _EstimateFormatType
                Session("EstimatingPrintFrom") = _From
                Session("EstimatingPrintCombine") = combine
                'Session("EstimatingPrintedDate") 

                Dim strBuilder2 As System.Text.StringBuilder = New System.Text.StringBuilder
                strBuilder2.Append("<script language='javascript'>")
                strBuilder2.Append("window.open('" & qs2.ToString(True) & "', '', 'width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
                strBuilder2.Append("</")
                strBuilder2.Append("script>")

                If MultipleReportPrintCount = 0 Then

                    MiscFN.ResponseRedirect(qs2.ToString(True), True)

                Else

                    Page.RegisterStartupScript("JC" & comp, strBuilder2.ToString())

                End If

            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub StandardSendAlert(Optional ByVal AsEmail As Boolean = False, Optional ByVal IsAssignment As Boolean = False)
        Try
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing
            Dim EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
            SavePrintSettings()

            Dim ar() As String
            Dim addressoption As String = "Client"
            Try
                If Me.dl_location.SelectedItem.Text = "None" Then
                    Session("EstimatingLogoLocation") = ""
                    Session("EstimatingLogoLocationID") = "None"
                    Session("EstimatingLogoLocationName") = ""
                Else
                    ar = dl_location.SelectedValue.ToString.Split("|")
                    Session("EstimatingLogoLocation") = ar(1)
                    Session("EstimatingLogoLocationID") = ar(0)
                    ar = dl_location.SelectedItem.Text.Split("-")
                    Session("EstimatingLogoLocationName") = ar(1)
                End If
            Catch ex As Exception
                Session("JobOrderFormLogoLocation") = ""
            End Try
            Session("EstimatingClientPrint") = Me.LabelClientCode.Text
            Session("EstimatingDivisionPrint") = Me.LabelDivisionCode.Text
            Session("EstimatingProductPrint") = Me.LabelProductCode.Text
            Session("EstimatingDefFooter") = Me.txtDefauldFooterComment.Text
            Session("EstimatingSignature") = 999
            Session("EstimatingJobPrint") = Me.LabelJobNumber.Text
            Session("EstimatingCompPrint") = Me.LabelJobComponentNumber.Text
            addressoption = Me.rbCDPAddress.SelectedValue
            If Me.cbUsePrintedDate.Checked = True Then
                Session("EstimatingPrintedDate") = Me.hfCreateDate.Value
            Else
                If MiscFN.ValidDate(Me.RadDatePickerPrintedDate) = True Then
                    Session("EstimatingPrintedDate") = Me.RadDatePickerPrintedDate.SelectedDate
                Else
                    Session("EstimatingPrintedDate") = ""
                End If
            End If
            Session("EstimatingReport") = "Estimating" & Me.RadComboBoxFormatType.SelectedValue
            Dim empSig As Int16
            If Me.cbExcludeEmpSig.Checked = True Then
                empSig = 1
            Else
                empSig = 0
            End If

            Dim EmailSwitch As String = ""
            If AsEmail = True Then

                EmailSwitch = "eml=1&"

            Else

                EmailSwitch = "eml=0&"

            End If
            If IsAssignment = True Then 'assignment switch overrides email switch

                EmailSwitch = "eml=0&assn=1&"

            End If
            Dim strURL As String = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=estimatingprint&j=" & Me.JobNum & "&jc=" & Me.JobCompNum & "&pagetype=est" & "&UseEmpSig=" & empSig '& "&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.Estimate)

            Dim chk As CheckBox
            Dim quotes As String
            Dim qtedesc As String = ""
            Dim qtedescs As String = ""
            Dim comps As String
            Dim qte As Integer
            Dim comp As Integer = 0
            Dim combine As Integer = 0
            Dim count As Integer = 0

            Dim MultiCounter As Integer = 0

            If Me.RadComboBoxSummaryLevel.SelectedValue = "2" Then
                If Me.RadComboBoxSummaryLevel.SelectedValue = "2" Then
                    combine = 1
                End If
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridQuotes.MasterTableView.Items
                    chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                    If Me._PrintSendAll = True Then chk.Checked = True
                    If gridDataItem.Selected = True Then
                        Try
                            If comp > 0 And comp <> gridDataItem.GetDataKeyValue("EstimateComponentNumber") Then
                                If count > 4 And Me.RadComboBoxFormatType.SelectedValue = "2" Then
                                    Me.ShowMessage("Only 4 quotes may be selected per component for this report format.")
                                    Exit Sub
                                End If
                                If count > 2 And Me.RadComboBoxFormatType.SelectedValue = "314" Then
                                    Me.ShowMessage("Maximum 2 quotes may be selected per component for this report format.")
                                    Exit Sub
                                End If
                                count = 0
                            End If
                            comp = gridDataItem.GetDataKeyValue("EstimateComponentNumber")
                            qte = CInt(gridDataItem("colEST_QUOTE_NBR").Text.Replace("&nbsp;", ""))
                            qtedesc = gridDataItem("colEST_QUOTE_DESC").Text.Replace("&nbsp;", "").Replace(",", "_")
                        Catch ex As Exception
                            qte = 0
                            comp = 0
                            qtedesc = ""
                        End Try
                        quotes &= qte & ","
                        qtedescs &= qtedesc & ","
                        comps &= comp & ","
                        MultiCounter += 1
                        count += 1
                    End If
                Next
                'If Me.ddReportFormat.SelectedValue = "Mars" Then
                '    quotes = MiscFN.RemoveTrailingDelimiter(quotes, ",")
                '    comps = MiscFN.RemoveTrailingDelimiter(comps, ",")
                'End If
                If comps = "" And Me._SelectedQuoteNumbers = "" Then

                    Me.ShowMessage("Please select at least one quote to print/send")
                    Exit Sub

                ElseIf comps = "" And Me._SelectedQuoteNumbers <> "" Then

                    quotes = Me._SelectedQuoteNumbers

                End If
                If comps.Trim() = "" And Me.EstCompNum > 0 Then
                    comps = Me.EstCompNum.ToString() & ","
                End If
                If count > 4 And Me.RadComboBoxFormatType.SelectedValue = "2" Then
                    Me.ShowMessage("Only 4 quotes may be selected per component for this report format.")
                    Exit Sub
                End If
                If count > 2 And Me.RadComboBoxFormatType.SelectedValue = "314" Then
                    Me.ShowMessage("Maximum 2 quotes may be selected per component for this report format.")
                    Exit Sub
                End If
                Session("EstimatingQteDescs") = qtedescs

                strURL = strURL & "&combine=1&e=" & Me.EstNum & "&ec=" & comp & "&Type=" & Me.RadComboBoxFileFormat.SelectedValue & "&settingType=" & _EstimateFormatType & "&option=" & addressoption & "&quotes=" & quotes & "&comps=" & comps

                If IsAssignment Then
                    Session("EstimatingPrintQuotes") = quotes
                End If

                quotes = ""
            Else
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridQuotes.MasterTableView.Items
                    chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                    If Me._PrintSendAll = True Then chk.Checked = True
                    If gridDataItem.Selected = True Then
                        Try
                            If comp > 0 And comp <> gridDataItem.GetDataKeyValue("EstimateComponentNumber") Then
                                If count > 4 And Me.RadComboBoxFormatType.SelectedValue = "2" Then
                                    Me.ShowMessage("Only 4 quotes may be selected per component for this report format.")
                                    Exit Sub
                                End If
                                If count > 2 And Me.RadComboBoxFormatType.SelectedValue = "314" Then
                                    Me.ShowMessage("Maximum 2 quotes may be selected per component for this report format.")
                                    Exit Sub
                                End If
                                count = 0
                            End If
                            comp = gridDataItem.GetDataKeyValue("EstimateComponentNumber")
                            qte = CInt(gridDataItem("colEST_QUOTE_NBR").Text.Replace("&nbsp;", ""))
                            qtedesc = gridDataItem("colEST_QUOTE_DESC").Text.Replace("&nbsp;", "").Replace(",", "_")
                        Catch ex As Exception
                            qte = 0
                            comp = 0
                            qtedesc = ""
                        End Try
                        quotes &= qte & ","
                        qtedescs &= qtedesc & ","
                        comps &= comp & ","
                        MultiCounter += 1
                        count += 1

                    End If
                Next

                If comps = "" And Me._SelectedQuoteNumbers = "" Then

                    Me.ShowMessage("Please select at least one quote to print/send")
                    Exit Sub

                ElseIf comps = "" And Me._SelectedQuoteNumbers <> "" Then

                    quotes = Me._SelectedQuoteNumbers

                End If
                If comps.Trim() = "" And Me.EstCompNum > 0 Then
                    comps = Me.EstCompNum.ToString() & ","
                End If
                If count > 4 And Me.RadComboBoxFormatType.SelectedValue = "2" Then
                    Me.ShowMessage("Only 4 quotes may be selected per component for this report format.")
                    Exit Sub
                End If
                If count > 2 And Me.RadComboBoxFormatType.SelectedValue = "314" Then
                    Me.ShowMessage("Maximum 2 quotes may be selected per component for this report format.")
                    Exit Sub
                End If
                Session("EstimatingQteDescs") = qtedescs
                strURL = strURL & "&e=" & Me.EstNum & "&ec=" & comp & "&Type=" & Me.RadComboBoxFileFormat.SelectedValue & "&settingType=" & _EstimateFormatType &
                    "&option=" & addressoption & "&quotes=" & quotes & "&comps=" & comps
                If IsAssignment Then
                    Session("EstimatingPrintQuotes") = quotes
                End If
                quotes = ""
            End If

            If MultiCounter > 1 Then
                strURL &= "&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.Estimate)
            Else
                strURL &= "&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.EstimateComponent)
            End If

            Dim Label As String = "New Alert"

            If AsEmail Then

                Label = "New Email"

            End If
            If IsAssignment Then

                Session("EstimatingPrintEstimatingNumber") = Me.EstNum
                Session("EstimatingPrintEstimatingComponentNumber") = comp
                Session("EstimatingPrintType") = Me.ddlFormat.SelectedValue
                Session("EstimatingPrintReport") = "Estimating" & Me.ddReportFormat.SelectedValue
                Session("EstimatingPrintOption") = addressoption
                Session("EstimatingPrintComp") = comps

                Label = "New Assignment"
                strURL = strURL.Replace("caller=estimatingprint", "caller=EstimatingPrint")
                strURL = strURL.Replace("Alert_New.aspx", "Desktop_NewAssignment")

            End If

            Me.OpenWindow(Label, strURL)

        Catch ex As Exception
            Me.ShowMessage("err opening print data window")
        End Try

    End Sub

    Private Function UpdateEstimateDate()
        Try
            'objects
            Dim Saved As Boolean = False
            Dim SQL As New System.Text.StringBuilder

            Try

                If Me.EstNum > 0 Then

                    Dim EstimateDate As Date = Me.RadDatePickerEstimate.SelectedDate
                    Dim parameterEST_CREATE_DATE As New SqlParameter("@EST_CREATE_DATE", SqlDbType.DateTime)

                    SQL.Append("UPDATE [dbo].[ESTIMATE_LOG] SET ")
                    SQL.Append(" EST_CREATE_DATE = @EST_CREATE_DATE")

                    If String.IsNullOrWhiteSpace(EstimateDate.ToShortDateString) = False Then
                        parameterEST_CREATE_DATE.Value = EstimateDate
                    Else
                        parameterEST_CREATE_DATE.Value = DBNull.Value
                    End If

                    SQL.Append(" WHERE ESTIMATE_NUMBER = " & Me.EstNum & ";")

                    Dim MyCmd As New SqlCommand()
                    MyCmd.Parameters.Add(parameterEST_CREATE_DATE)

                    Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                        Dim MyTrans As SqlTransaction
                        MyConn.Open()
                        MyTrans = MyConn.BeginTransaction
                        Try
                            With MyCmd
                                .CommandText = SQL.ToString()
                                .CommandType = CommandType.Text
                                .Connection = MyConn
                                .Transaction = MyTrans
                                .ExecuteNonQuery()
                                'ReturnMessage = "OK|" & Qty
                            End With
                            MyTrans.Commit()
                        Catch ex As Exception
                            MyTrans.Rollback()
                        Finally
                            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        End Try
                    End Using

                    'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    '    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ESTIMATE_LOG] SET EST_CREATE_DATE = {1} WHERE [ESTIMATE_NUMBER] = {0}",
                    '                                                Me.EstNum,
                    '                                                If(String.IsNullOrWhiteSpace(EstimateDate.ToShortDateString) = False, "'" & LoGlo.FormatDate(EstimateDate.ToShortDateString) & "'", "NULL")))

                    'End Using


                End If

                Saved = True

            Catch ex As Exception
                Saved = False
            End Try

            Return Saved

        Catch ex As Exception

        End Try
    End Function

    Private Function LoadEstimatePrintingSettings(DataContext As AdvantageFramework.Database.DataContext, SaveToAgency As Boolean, SaveToClients As Boolean, SaveToProducts As Boolean, SaveToUser As Boolean) As Generic.List(Of AdvantageFramework.Database.Entities.EstimatePrintingSetting)

        'objects
        Dim EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Database.Entities.EstimatePrintingSetting) = Nothing

        Try

            If _EstimateFormatType = "Client" Or _EstimateFormatType = "Product" Then

                If SaveToAgency AndAlso SaveToClients AndAlso SaveToProducts AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToAgency = False AndAlso SaveToClients AndAlso SaveToProducts AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToAgency AndAlso SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToAgency = False AndAlso SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToAgency AndAlso SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToAgency = False AndAlso SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToAgency AndAlso SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToAgency = False AndAlso SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToAgency AndAlso SaveToClients AndAlso SaveToProducts AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3).ToList

                ElseIf SaveToAgency = False AndAlso SaveToClients AndAlso SaveToProducts AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3).ToList

                ElseIf SaveToAgency AndAlso SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 3).ToList

                ElseIf SaveToAgency = False AndAlso SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 3).ToList

                ElseIf SaveToAgency AndAlso SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                ElseIf SaveToAgency = False AndAlso SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 2).ToList

                ElseIf SaveToAgency AndAlso SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1).ToList

                ElseIf SaveToAgency = False AndAlso SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0).ToList

                End If

            ElseIf _EstimateFormatType = "Agency" Then

                If SaveToClients AndAlso SaveToProducts AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToClients AndAlso SaveToProducts AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3).ToList

                ElseIf SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 3).ToList

                ElseIf SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                ElseIf SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1).ToList

                End If

            ElseIf _EstimateFormatType = "User" Then

                If SaveToClients AndAlso SaveToProducts AndAlso SaveToAgency Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToClients = False AndAlso SaveToProducts AndAlso SaveToAgency Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToClients AndAlso SaveToProducts = False AndAlso SaveToAgency Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToClients AndAlso SaveToProducts AndAlso SaveToAgency = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToAgency Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToClients = False AndAlso SaveToProducts AndAlso SaveToAgency = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToClients AndAlso SaveToProducts = False AndAlso SaveToAgency = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToAgency = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 4).ToList

                End If

            ElseIf _EstimateFormatType = "OneTime" Then

                If SaveToAgency AndAlso SaveToClients AndAlso SaveToProducts AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToAgency = False AndAlso SaveToClients AndAlso SaveToProducts AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToAgency AndAlso SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToAgency = False AndAlso SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToAgency AndAlso SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToAgency = False AndAlso SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToAgency AndAlso SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToAgency = False AndAlso SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 4).ToList

                ElseIf SaveToAgency AndAlso SaveToClients AndAlso SaveToProducts AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3).ToList

                ElseIf SaveToAgency = False AndAlso SaveToClients AndAlso SaveToProducts AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3).ToList

                ElseIf SaveToAgency AndAlso SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 3).ToList

                ElseIf SaveToAgency = False AndAlso SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 3).ToList

                ElseIf SaveToAgency AndAlso SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                ElseIf SaveToAgency = False AndAlso SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 2).ToList

                ElseIf SaveToAgency AndAlso SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1).ToList

                ElseIf SaveToAgency = False AndAlso SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                    EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0).ToList

                End If

            End If



        Catch ex As Exception
            EstimatePrintingSettings = New Generic.List(Of AdvantageFramework.Database.Entities.EstimatePrintingSetting)
        End Try

        If SaveToClients Then

            For Each EstimatePrintingSetting In EstimatePrintingSettings.Where(Function(Entity) Entity.ClientOrDefault = 2).ToList

                If _ClientCodes IsNot Nothing AndAlso _ClientCodes.Contains(EstimatePrintingSetting.ClientCode) = False Then

                    EstimatePrintingSettings.Remove(EstimatePrintingSetting)

                End If

            Next

        End If

        If SaveToClients Then

            For Each ClientCode In _ClientCodes

                If EstimatePrintingSettings.Any(Function(Entity) Entity.ClientOrDefault = 2 AndAlso Entity.ClientCode = ClientCode) = False Then

                    EstimatePrintingSettings.Add(New AdvantageFramework.Database.Entities.EstimatePrintingSetting() With {.ClientOrDefault = 2,
                                                                                                                            .ClientCode = ClientCode})

                End If

            Next

        End If

        If SaveToProducts Then

            For Each EstimatePrintingSetting In EstimatePrintingSettings.Where(Function(Entity) Entity.ClientOrDefault = 3).ToList

                If _ProductCodes IsNot Nothing AndAlso _ProductCodes.Contains(EstimatePrintingSetting.ClientCode & "|" & EstimatePrintingSetting.DivisionCode & "|" & EstimatePrintingSetting.ProductCode) = False Then

                    EstimatePrintingSettings.Remove(EstimatePrintingSetting)

                End If

            Next

        End If

        If SaveToProducts Then

            For Each ProductCode In _ProductCodes

                Dim cdp() As String = ProductCode.Split("|")

                If EstimatePrintingSettings.Any(Function(Entity) Entity.ClientOrDefault = 3 AndAlso Entity.ClientCode & "|" & Entity.DivisionCode & "|" & Entity.ProductCode = ProductCode) = False Then

                    EstimatePrintingSettings.Add(New AdvantageFramework.Database.Entities.EstimatePrintingSetting() With {.ClientOrDefault = 3,
                                                                                                                            .ClientCode = cdp(0),
                                                                                                                            .DivisionCode = cdp(1),
                                                                                                                            .ProductCode = cdp(2)})

                End If

            Next

        End If

        If SaveToUser Then

            For Each EstimatePrintingSetting In EstimatePrintingSettings.Where(Function(Entity) Entity.ClientOrDefault = 4).ToList

                If _Session.UserCode <> EstimatePrintingSetting.UserID Then

                    EstimatePrintingSettings.Remove(EstimatePrintingSetting)

                End If

            Next

        End If

        If SaveToUser Then

            If EstimatePrintingSettings.Any(Function(Entity) Entity.ClientOrDefault = 4 AndAlso Entity.UserID = _Session.UserCode) = False Then

                EstimatePrintingSettings.Add(New AdvantageFramework.Database.Entities.EstimatePrintingSetting() With {.ClientOrDefault = 4,
                                                                                                                        .UserID = _Session.UserCode})

            End If

        End If

        LoadEstimatePrintingSettings = EstimatePrintingSettings

    End Function

    Private Sub LoadStandardFormat()
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim StandardPrintFormat As String = "User"

            If otask.getAppVars(Session("UserCode"), "EstimatingPrint", "StandardPrintFormat") <> "" Then
                StandardPrintFormat = otask.getAppVars(Session("UserCode"), "EstimatingPrint", "StandardPrintFormat")
                If StandardPrintFormat = "Client" Then

                    _EstimateFormatType = "Client"

                    RadToolBarButtonClient.Checked = True
                    RadToolBarButtonClientSave.Checked = True
                    RadToolBarButtonProductSave.Checked = False
                    RadToolBarButtonUserSave.Checked = False
                    RadToolBarButtonAgencySave.Checked = False
                    RadToolBarButtonClientSave.Visible = False
                    RadToolBarButtonProductSave.Visible = True
                    RadToolBarButtonUserSave.Visible = True
                    RadToolBarButtonAgencySave.Visible = True

                ElseIf StandardPrintFormat = "Product" Then

                    _EstimateFormatType = "Product"

                    RadToolBarButtonProduct.Checked = True
                    RadToolBarButtonProductSave.Checked = True
                    RadToolBarButtonClientSave.Checked = False
                    RadToolBarButtonUserSave.Checked = False
                    RadToolBarButtonAgencySave.Checked = False
                    RadToolBarButtonProductSave.Visible = False
                    RadToolBarButtonClientSave.Visible = True
                    RadToolBarButtonUserSave.Visible = True
                    RadToolBarButtonAgencySave.Visible = True

                ElseIf StandardPrintFormat = "User" Then

                    _EstimateFormatType = "User"

                    RadToolBarButtonUser.Checked = True
                    RadToolBarButtonUserSave.Checked = True
                    RadToolBarButtonProductSave.Checked = False
                    RadToolBarButtonClientSave.Checked = False
                    RadToolBarButtonAgencySave.Checked = False
                    RadToolBarButtonUserSave.Visible = False
                    RadToolBarButtonClientSave.Visible = True
                    RadToolBarButtonProductSave.Visible = True
                    RadToolBarButtonAgencySave.Visible = True

                ElseIf StandardPrintFormat = "Agency" Then

                    _EstimateFormatType = "Agency"

                    RadToolBarButtonAgency.Checked = True
                    RadToolBarButtonAgencySave.Checked = True
                    RadToolBarButtonUserSave.Checked = False
                    RadToolBarButtonProductSave.Checked = False
                    RadToolBarButtonClientSave.Checked = False
                    RadToolBarButtonAgencySave.Visible = False
                    RadToolBarButtonClientSave.Visible = True
                    RadToolBarButtonProductSave.Visible = True
                    RadToolBarButtonUserSave.Visible = True

                ElseIf StandardPrintFormat = "OneTime" Then

                    _EstimateFormatType = "OneTime"

                    RadToolBarButtonOneTime.Checked = True
                    RadToolBarButtonClientSave.Visible = True
                    RadToolBarButtonProductSave.Visible = True
                    RadToolBarButtonUserSave.Visible = True
                    RadToolBarButtonAgencySave.Visible = True
                    RadToolBarButtonAgencySave.Checked = False
                    RadToolBarButtonUserSave.Checked = False
                    RadToolBarButtonProductSave.Checked = False
                    RadToolBarButtonClientSave.Checked = False

                End If
            Else
                RadToolBarButtonUser.Checked = True
                RadToolBarButtonUserSave.Checked = True
                RadToolBarButtonUserSave.Visible = False
            End If

            Session("EstimatingPrintFormatType") = _EstimateFormatType

        Catch ex As Exception

        End Try
    End Sub

#Region "Standard"

    Private Sub RadGridQuotes_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridQuotes.ItemDataBound
        Try
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                Dim currentEstComp As Integer
                Dim item As Telerik.Web.UI.GridDataItem
                item = e.Item
                Dim hf As System.Web.UI.WebControls.HiddenField = e.Item.FindControl("hfEstimateComp")
                Dim chk As CheckBox = CType(item("ColumnClientSelect").Controls(0), CheckBox)
                currentEstComp = hf.Value
                If Me._From = "Est" Then
                    If EstCompNum = currentEstComp Then
                        e.Item.Selected = True
                    End If
                ElseIf Me._From = "EstQuote" Then
                    Dim currentquote As Integer = DataBinder.Eval(e.Item.DataItem, "QuoteNumber") 'CInt(e.Item.DataItem("QuoteNumber"))
                    If currentquote = Me.QuoteNum Then
                        e.Item.Selected = True
                    End If
                Else
                    If EstCompNum = currentEstComp Then
                        e.Item.Selected = True
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridQuotes_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridQuotes.NeedDataSource
        Try
            Dim est As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuoteList) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserID"))
                If Me._From = "Est" Then

                    EstimateQuotes = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuoteList)(String.Format("EXEC [dbo].[advsp_estimate_printing_quotes] {0}, {1}", Me.EstNum, 0)).ToList
                    Me.RadGridQuotes.DataSource = EstimateQuotes 'est.GetInfoForEstimateCopy(EstNum)

                ElseIf Me._From = "EstQuote" Then

                    EstimateQuotes = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuoteList)(String.Format("EXEC [dbo].[advsp_estimate_printing_quotes] {0}, {1}", Me.EstNum, EstCompNum)).ToList
                    Me.RadGridQuotes.DataSource = EstimateQuotes 'est.GetEstimateQuotes(EstNum, EstCompNum)

                Else

                    EstimateQuotes = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuoteList)(String.Format("EXEC [dbo].[advsp_estimate_printing_quotes] {0}, {1}", Me.EstNum, 0)).ToList
                    Me.RadGridQuotes.DataSource = EstimateQuotes 'est.GetInfoForEstimateCopy(EstNum)

                End If
            End Using

            Me.SetGridSortStandard("Comp")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetGridSortStandard(ByVal StrSort As String)
        Try
            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression
            Select Case StrSort
                Case "Comp"
                    GrpExpr = Telerik.Web.UI.GridGroupByExpression.Parse("EstimateComponentNumber Component Group By EstimateComponentNumber")
                    With Me.RadGridQuotes
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True
                        '.MasterTableView.GetColumn("colPHASE_DESC").Display = False
                    End With
                Case Else
                    Me.RadGridQuotes.MasterTableView.GroupByExpressions.Clear()
            End Select
            'Session("EstimateGridSort") = StrSort
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Custom"

    Private Sub Print()
        Try
            SaveSettings()

            Dim EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuoteList = Nothing
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuoteList) = Nothing
            Dim EstimateFormat As AdvantageFramework.Estimate.Printing.ReportFormats = AdvantageFramework.Estimate.Printing.ReportFormats.OneQuotePerPage
            Dim EstimatePrintingSettings As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim EstimatePrintSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintSetting = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

            Dim stream As New System.IO.MemoryStream
            Dim filename As String = "Report"
            Dim filetype As String = "pdf"

            Dim ar() As String
            Dim addressoption As String = "Client"
            Try
                If Me.dl_location.SelectedItem.Text = "None" Then
                    Session("EstimatingLogoLocation") = ""
                    Session("EstimatingLogoLocationID") = "None"
                    Session("EstimatingLogoLocationName") = ""
                Else
                    ar = dl_location.SelectedValue.ToString.Split("|")
                    Session("EstimatingLogoLocation") = ar(1)
                    Session("EstimatingLogoLocationID") = ar(0)
                    ar = dl_location.SelectedItem.Text.Split("-")
                    Session("EstimatingLogoLocationName") = ar(1)
                End If
            Catch ex As Exception
                Session("EstimatingLogoLocation") = ""
            End Try
            'Session("EstimatingOfficePrint") = Me.lbOffice.SelectedValue
            Session("EstimatingClientPrint") = Me.LabelClientCode.Text
            Session("EstimatingDivisionPrint") = Me.LabelDivisionCode.Text
            Session("EstimatingProductPrint") = Me.LabelProductCode.Text
            Session("EstimatingDefFooter") = Me.txtDefauldFooterComment.Text
            Session("EstimatingSignature") = 999
            Session("EstimatingJobPrint") = Me.LabelJobNumber.Text
            Session("EstimatingCompPrint") = Me.LabelJobComponentNumber.Text
            addressoption = Me.rbCDPAddress.SelectedValue
            If Me.cbUsePrintedDate.Checked = True Then
                Session("EstimatingPrintedDate") = Me.hfCreateDate.Value
            Else
                If MiscFN.ValidDate(Me.RadDatePickerPrintedDate) = True Then
                    Session("EstimatingPrintedDate") = Me.RadDatePickerPrintedDate.SelectedDate
                Else
                    Session("EstimatingPrintedDate") = ""
                End If
            End If

            Dim chk As CheckBox
            Dim quotes As String = ""
            Dim qtedesc As String = ""
            Dim qtedescs As String = ""
            Dim comps As String = ""
            Dim qte As Integer = 0
            Dim comp As Integer = 0
            Dim count As Integer = 0
            Dim combine As Integer = 0

            Dim empSig As Int16
            If Me.cbExcludeEmpSig.Checked = True Then
                empSig = 1
            Else
                empSig = 0
            End If

            If Me.ddReportFormat.SelectedValue = "SS1" Or Me.ddReportFormat.SelectedValue = "008" Or Me.ddReportFormat.SelectedValue = "009" Or Me.ddReportFormat.SelectedValue = "QUR" Or Me.ddReportFormat.SelectedValue = "TAP" Or Me.ddReportFormat.SelectedValue = "TAP2" Then
                If Me.LabelJobNumber.Text = "" Then
                    Me.ShowMessage("No campaign is associated with this estimate")
                    Exit Sub
                End If
                If Me.LabelJobNumber.Text <> "" Then
                    Dim jt As New Job_Template(Session("ConnString"))
                    Dim dr As SqlDataReader
                    dr = jt.GetThisJob(CInt(Me.LabelJobNumber.Text))
                    If dr.HasRows Then
                        dr.Read()
                        If IsDBNull(dr("CMP_IDENTIFIER")) = False Then
                            If dr("CMP_IDENTIFIER") = 0 Then
                                Me.ShowMessage("No campaign is associated with this estimate")
                                Exit Sub
                            End If
                        Else
                            Me.ShowMessage("No campaign is associated with this estimate")
                            Exit Sub
                        End If
                    End If
                End If
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstQuote.MasterTableView.Items
                    chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                    If Me._PrintSendAll = True Then chk.Checked = True
                    If chk.Checked = True Then
                        Try
                            If comp > 0 And comp <> gridDataItem.GetDataKeyValue("EstimateComponentNumber") Then
                                count = 0
                            End If
                            comp = gridDataItem.GetDataKeyValue("EstimateComponentNumber")
                            qte = CInt(gridDataItem("colEST_QUOTE_NBR").Text.Replace("&nbsp;", ""))
                            qtedesc = gridDataItem("colEST_QUOTE_DESC").Text.Replace("&nbsp;", "").Replace(",", "_")
                        Catch ex As Exception
                            qte = 0
                            comp = 0
                            qtedesc = ""
                        End Try
                        quotes &= qte & ","
                        qtedescs &= qtedesc & ","
                        comps &= comp & ","
                        count += 1
                    End If
                Next
                If count = 0 And Me._SelectedQuoteNumbers = "" Then

                    Me.ShowMessage("Please select at least one quote to print/send")
                    Exit Sub

                ElseIf count = 0 And Me._SelectedQuoteNumbers <> "" Then

                    quotes = Me._SelectedQuoteNumbers

                End If
                If comps.Trim() = "" And Me.EstCompNum > 0 Then
                    comps = Me.EstCompNum.ToString() & ","
                End If

                Session("EstimatingQteDescs") = qtedescs
                Session("EstimatingFncComment") = Me.CheckBoxFunctionComment.Checked

                Dim strJC As String = "popReportViewer.aspx?EstNum=" & Me.EstNum & "&EstCompNum=" & Me.EstCompNum & "&Type=" &
                    Me.ddlFormat.SelectedValue & "&Report=Estimating" & Me.ddReportFormat.SelectedValue & "&option=" & addressoption &
                    "&quotes=" & quotes & "&comps=" & comps & "&UseEmpSig=" & empSig & "&j=" & Me.JobNum.ToString() & "&jc=" & Me.JobCompNum.ToString()

                quotes = ""
                Response.Redirect(strJC)

            Else
                If Me.cbCombineComps.Checked = True Or Me.ddReportFormat.SelectedValue = "Mars" Or Me.ddReportFormat.SelectedValue = "BWD" Or Me.ddReportFormat.SelectedValue = "BWD2" Then
                    If Me.cbCombineComps.Checked = True Then
                        combine = 1
                    End If
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstQuote.MasterTableView.Items
                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        If Me._PrintSendAll = True Then chk.Checked = True
                        If chk.Checked = True Then
                            Try
                                If comp > 0 And comp <> gridDataItem.GetDataKeyValue("EstimateComponentNumber") Then
                                    If count > 4 And Me.ddReportFormat.SelectedValue = "002" Then
                                        Me.ShowMessage("Only 4 quotes may be selected per component for this report format.")
                                        Exit Sub
                                    End If
                                    If count > 2 And Me.ddReportFormat.SelectedValue = "314" Then
                                        Me.ShowMessage("Maximum 2 quotes may be selected per component for this report format.")
                                        Exit Sub
                                    End If
                                    count = 0
                                End If
                                comp = gridDataItem.GetDataKeyValue("EstimateComponentNumber")
                                qte = CInt(gridDataItem("colEST_QUOTE_NBR").Text.Replace("&nbsp;", ""))
                                qtedesc = gridDataItem("colEST_QUOTE_DESC").Text.Replace("&nbsp;", "").Replace(",", "_")
                            Catch ex As Exception
                                qte = 0
                                comp = 0
                                qtedesc = ""
                            End Try
                            quotes &= qte & ","
                            qtedescs &= qtedesc & ","
                            comps &= comp & ","
                            count += 1
                        End If
                    Next
                    If count = 0 And Me._SelectedQuoteNumbers = "" Then

                        Me.ShowMessage("Please select at least one quote to print/send")
                        Exit Sub

                    ElseIf count = 0 And Me._SelectedQuoteNumbers <> "" Then

                        quotes = Me._SelectedQuoteNumbers
                        Dim arQ() As String
                        arQ = Me._SelectedQuoteNumbers.Split(",")
                        count = arQ.Length

                        For w As Integer = 0 To arQ.Length - 1
                            If arQ(w) <> "" Then
                                comps &= Me.EstCompNum.ToString & ","
                            End If
                        Next

                    End If
                    If comps.Trim() = "" And Me.EstCompNum > 0 Then
                        comps = Me.EstCompNum.ToString() & ","
                    End If
                    If count > 4 And Me.ddReportFormat.SelectedValue = "002" Then
                        Me.ShowMessage("Only 4 quotes may be selected per component for this report format.")
                        Exit Sub
                    End If
                    If count > 2 And Me.ddReportFormat.SelectedValue = "314" Then
                        Me.ShowMessage("Maximum 2 quotes may be selected per component for this report format.")
                        Exit Sub
                    End If

                    Session("EstimatingQteDescs") = qtedescs
                    Dim strJC As String
                    If Me.ddReportFormat.SelectedValue = "Mars" Then
                        strJC = "popReportViewer.aspx?EstNum=" & Me.EstNum & "&EstCompNum=" & Me.EstCompNum & "&Type=" & Me.ddlFormat.SelectedValue &
                            "&Report=Estimating" & Me.ddReportFormat.SelectedValue & "&option=" & addressoption & "&quotes=" & quotes &
                            "&comps=" & comps & "&UseEmpSig=" & empSig & "&j=" & Me.JobNum.ToString() & "&jc=" & Me.JobCompNum.ToString()
                    ElseIf Me.ddReportFormat.SelectedValue = "BWD" Or Me.ddReportFormat.SelectedValue = "BWD2" Then
                        strJC = "popReportViewer.aspx?combine=" & combine & "&EstNum=" & Me.EstNum & "&EstCompNum=" & Me.EstCompNum & "&Type=" &
                            Me.ddlFormat.SelectedValue & "&Report=Estimating" & Me.ddReportFormat.SelectedValue & "&option=" & addressoption &
                            "&quotes=" & quotes & "&comps=" & comps & "&UseEmpSig=" & empSig & "&j=" & Me.JobNum.ToString() & "&jc=" & Me.JobCompNum.ToString()
                    Else
                        strJC = "popReportViewer.aspx?combine=1&EstNum=" & Me.EstNum & "&EstCompNum=" & Me.EstCompNum & "&Type=" &
                            Me.ddlFormat.SelectedValue & "&Report=Estimating" & Me.ddReportFormat.SelectedValue & "&option=" &
                            addressoption & "&quotes=" & quotes & "&comps=" & comps & "&UseEmpSig=" & empSig & "&j=" & Me.JobNum.ToString() & "&jc=" & Me.JobCompNum.ToString()
                    End If

                    If Me.ddReportFormat.SelectedValue = "" Or Me.ddReportFormat.SelectedValue = "002" Or Me.ddReportFormat.SelectedValue = "003" Or Me.ddReportFormat.SelectedValue = "004" _
                         Or Me.ddReportFormat.SelectedValue = "005" Or Me.ddReportFormat.SelectedValue = "006" Or Me.ddReportFormat.SelectedValue = "007" Then
                        Dim qs2 As New AdvantageFramework.Web.QueryString()
                        With qs2
                            .Page = "Reporting_Output.aspx"
                            .EstimateNumber = Me.EstNum
                            .EstimateComponentNumber = comp
                            .Add("Type", Me.ddlFormat.SelectedValue)
                            .Add("caller", "Estimating_Print")
                            .Add("Report", "Estimating" & Me.ddReportFormat.SelectedValue)
                            .Add("quotes", quotes)
                            .Add("comps", comps)
                            .Add("from", _From)
                            .Add("combine", combine)
                            .JobNumber = Me.JobNum.ToString()
                            .JobComponentNumber = Me.JobCompNum.ToString()
                            .Add("estdate", Session("EstimatingPrintedDate"))
                        End With

                        Dim strBuilder2 As System.Text.StringBuilder = New System.Text.StringBuilder
                        strBuilder2.Append("<script language='javascript'>")
                        strBuilder2.Append("window.open('" & qs2.ToString(True) & "', '', 'width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
                        strBuilder2.Append("</")
                        strBuilder2.Append("script>")
                        Page.RegisterStartupScript("JC" & comp, strBuilder2.ToString())
                    Else
                        quotes = ""
                        Response.Redirect(strJC)
                    End If
                Else
                    Dim MultipleReportPrintCount As Integer = 0
                    If Me.ddReportFormat.SelectedValue <> "" And Me.ddReportFormat.SelectedValue <> "002" And Me.ddReportFormat.SelectedValue <> "003" And Me.ddReportFormat.SelectedValue <> "004" _
                     And Me.ddReportFormat.SelectedValue <> "005" And Me.ddReportFormat.SelectedValue <> "006" And Me.ddReportFormat.SelectedValue <> "007" And Me.ddReportFormat.SelectedValue <> "SS2" Then
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstQuote.MasterTableView.Items
                            chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                            If Me._PrintSendAll = True Then chk.Checked = True
                            If chk.Checked = True Then
                                If comp > 0 And comp <> gridDataItem.GetDataKeyValue("EstimateComponentNumber") Then
                                    If count > 4 And Me.ddReportFormat.SelectedValue = "002" Then
                                        Me.ShowMessage("Only 4 quotes may be selected per component for this report format.")
                                        Exit Sub
                                    End If
                                    If count > 2 And Me.ddReportFormat.SelectedValue = "314" Then
                                        Me.ShowMessage("Maximum 2 quotes may be selected per component for this report format.")
                                        Exit Sub
                                    End If
                                    'quotes = MiscFN.RemoveTrailingDelimiter(quotes, ",")
                                    Session("EstimatingQteDescs" & comp.ToString()) = qtedescs
                                    Dim strJC As String = "popReportViewer.aspx?EstNum=" & Me.EstNum & "&EstCompNum=" & comp & "&Type=" &
                                        Me.ddlFormat.SelectedValue & "&Report=Estimating" & Me.ddReportFormat.SelectedValue & "&option=" & addressoption &
                                        "&quotes=" & quotes & "&UseEmpSig=" & empSig & "&IncludeRate=" & Me.cbIncludeRate.Checked & "&j=" & Me.JobNum.ToString() & "&jc=" & Me.JobCompNum.ToString()
                                    Dim strJCBuilder2 As System.Text.StringBuilder = New System.Text.StringBuilder
                                    strJCBuilder2.Append("<script language='javascript'>")
                                    strJCBuilder2.Append("window.open('" & strJC & "', '', 'width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
                                    strJCBuilder2.Append("</")
                                    strJCBuilder2.Append("script>")
                                    Page.RegisterStartupScript("JC" & comp, strJCBuilder2.ToString())
                                    MultipleReportPrintCount += 1
                                    'Response.Redirect(strJC)
                                    quotes = ""
                                    qtedescs = ""
                                    count = 0
                                End If
                                Try
                                    comp = gridDataItem.GetDataKeyValue("EstimateComponentNumber")
                                    qte = CInt(gridDataItem("colEST_QUOTE_NBR").Text.Replace("&nbsp;", ""))
                                    qtedesc = gridDataItem("colEST_QUOTE_DESC").Text.Replace("&nbsp;", "").Replace(",", "_")
                                Catch ex As Exception
                                    qte = 0
                                    qtedesc = ""
                                End Try
                                quotes &= qte & ","
                                qtedescs &= qtedesc & ","
                                count += 1
                            End If
                        Next
                        If count = 0 And Me._SelectedQuoteNumbers = "" Then

                            Me.ShowMessage("Please select at least one quote to print/send")
                            Exit Sub

                        ElseIf count = 0 And Me._SelectedQuoteNumbers <> "" Then

                            quotes = Me._SelectedQuoteNumbers
                            Dim arQ() As String
                            arQ = MiscFN.RemoveTrailingDelimiter(Me._SelectedQuoteNumbers, ",").Split(",")
                            count = arQ.Length

                        End If
                        If count > 4 And Me.ddReportFormat.SelectedValue = "002" Then
                            Me.ShowMessage("Only 4 quotes may be selected per component for this report format.")
                            Exit Sub
                        End If
                        If count > 2 And Me.ddReportFormat.SelectedValue = "314" Then
                            Me.ShowMessage("Maximum 2 quotes may be selected per component for this report format.")
                            Exit Sub
                        End If
                        If comp = 0 And Me.EstCompNum > 0 Then
                            comp = Me.EstCompNum
                        End If
                        Session("EstimatingQteDescs" & comp.ToString()) = qtedescs
                        Dim strURL2 As String = "popReportViewer.aspx?EstNum=" & Me.EstNum & "&EstCompNum=" & comp & "&Type=" & Me.ddlFormat.SelectedValue &
                            "&Report=Estimating" & Me.ddReportFormat.SelectedValue & "&option=" & addressoption & "&quotes=" &
                            quotes & "&UseEmpSig=" & empSig & "&IncludeRate=" & Me.cbIncludeRate.Checked & "&j=" & Me.JobNum.ToString() & "&jc=" & Me.JobCompNum.ToString()
                        Dim strBuilder2 As System.Text.StringBuilder = New System.Text.StringBuilder
                        strBuilder2.Append("<script language='javascript'>")
                        strBuilder2.Append("window.open('" & strURL2 & "', '', 'width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
                        strBuilder2.Append("</")
                        strBuilder2.Append("script>")
                        If MultipleReportPrintCount = 0 Then

                            MiscFN.ResponseRedirect(strURL2, True)

                        Else

                            Page.RegisterStartupScript("JC" & comp, strBuilder2.ToString())

                        End If
                    Else
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstQuote.MasterTableView.Items
                            chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                            If Me._PrintSendAll = True Then chk.Checked = True
                            If chk.Checked = True Then
                                If comp > 0 And comp <> gridDataItem.GetDataKeyValue("EstimateComponentNumber") Then
                                    If count > 4 And Me.ddReportFormat.SelectedValue = "002" Then
                                        Me.ShowMessage("Only 4 quotes may be selected per component for this report format.")
                                        Exit Sub
                                    End If
                                    If count > 2 And Me.ddReportFormat.SelectedValue = "314" Then
                                        Me.ShowMessage("Maximum 2 quotes may be selected per component for this report format.")
                                        Exit Sub
                                    End If
                                    'quotes = MiscFN.RemoveTrailingDelimiter(quotes, ",")
                                    Dim qs As New AdvantageFramework.Web.QueryString()
                                    With qs
                                        .Page = "Reporting_Output.aspx"
                                        .EstimateNumber = Me.EstNum
                                        .EstimateComponentNumber = comp
                                        .Add("Type", Me.ddlFormat.SelectedValue)
                                        .Add("caller", "Estimating_Print")
                                        .Add("Report", "Estimating" & Me.ddReportFormat.SelectedValue)
                                        .Add("quotes", quotes)
                                        .Add("from", _From)
                                        .Add("combine", combine)
                                        .JobNumber = Me.JobNum.ToString()
                                        .JobComponentNumber = Me.JobCompNum.ToString()
                                        .Add("estdate", Session("EstimatingPrintedDate"))
                                    End With

                                    Dim strJCBuilder2 As System.Text.StringBuilder = New System.Text.StringBuilder
                                    strJCBuilder2.Append("<script language='javascript'>")
                                    strJCBuilder2.Append("window.open('" & qs.ToString(True) & "', '', 'width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
                                    strJCBuilder2.Append("</")
                                    strJCBuilder2.Append("script>")
                                    Page.RegisterStartupScript("EC" & comp, strJCBuilder2.ToString())
                                    Session("EstimatingQteDescs" & comp.ToString()) = qtedescs
                                    MultipleReportPrintCount += 1
                                    quotes = ""
                                    qtedescs = ""
                                    count = 0
                                End If
                                Try
                                    comp = gridDataItem.GetDataKeyValue("EstimateComponentNumber")
                                    qte = CInt(gridDataItem("colEST_QUOTE_NBR").Text.Replace("&nbsp;", ""))
                                    qtedesc = gridDataItem("colEST_QUOTE_DESC").Text.Replace("&nbsp;", "").Replace(",", "_")
                                Catch ex As Exception
                                    qte = 0
                                    qtedesc = ""
                                End Try
                                quotes &= qte & ","
                                qtedescs &= qtedesc & ","
                                comps &= comp & ","
                                count += 1
                            End If
                        Next
                        If count = 0 And Me._SelectedQuoteNumbers = "" Then

                            Me.ShowMessage("Please select at least one quote to print/send")
                            Exit Sub

                        ElseIf count = 0 And Me._SelectedQuoteNumbers <> "" Then

                            quotes = Me._SelectedQuoteNumbers
                            Dim arQ() As String
                            arQ = MiscFN.RemoveTrailingDelimiter(Me._SelectedQuoteNumbers, ",").Split(",")
                            count = arQ.Length

                        End If
                        If count > 4 And Me.ddReportFormat.SelectedValue = "002" Then
                            Me.ShowMessage("Only 4 quotes may be selected per component for this report format.")
                            Exit Sub
                        End If
                        If count > 2 And Me.ddReportFormat.SelectedValue = "314" Then
                            Me.ShowMessage("Maximum 2 quotes may be selected per component for this report format.")
                            Exit Sub
                        End If
                        If comp = 0 And Me.EstCompNum > 0 Then
                            comp = Me.EstCompNum
                        End If
                        Session("EstimatingQteDescs" & comp.ToString()) = qtedescs
                        Dim qs2 As New AdvantageFramework.Web.QueryString()
                        With qs2
                            .Page = "Reporting_Output.aspx"
                            .EstimateNumber = Me.EstNum
                            .EstimateComponentNumber = comp
                            .Add("Type", Me.ddlFormat.SelectedValue)
                            .Add("caller", "Estimating_Print")
                            .Add("Report", "Estimating" & Me.ddReportFormat.SelectedValue)
                            .Add("quotes", quotes)
                            .Add("from", _From)
                            .Add("combine", combine)
                            .JobNumber = Me.JobNum.ToString()
                            .JobComponentNumber = Me.JobCompNum.ToString()
                            .Add("estdate", Session("EstimatingPrintedDate"))
                        End With

                        Dim strBuilder2 As System.Text.StringBuilder = New System.Text.StringBuilder
                        strBuilder2.Append("<script language='javascript'>")
                        strBuilder2.Append("window.open('" & qs2.ToString(True) & "', '', 'width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
                        strBuilder2.Append("</")
                        strBuilder2.Append("script>")

                        If MultipleReportPrintCount = 0 Then

                            MiscFN.ResponseRedirect(qs2.ToString(True), True)

                        Else

                            Page.RegisterStartupScript("JC" & comp, strBuilder2.ToString())

                        End If
                    End If

                End If
            End If

        Catch ex As Exception
            Me.ShowMessage("err opening print data window")
        End Try


    End Sub

    Private Sub SendAlert(Optional ByVal AsEmail As Boolean = False, Optional ByVal IsAssignment As Boolean = False)
        Try
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing
            Dim EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
            SaveSettings()

            Dim ar() As String
            Dim addressoption As String = "Client"
            Try
                If Me.dl_location.SelectedItem.Text = "None" Then
                    Session("EstimatingLogoLocation") = ""
                    Session("EstimatingLogoLocationID") = "None"
                    Session("EstimatingLogoLocationName") = ""
                Else
                    ar = dl_location.SelectedValue.ToString.Split("|")
                    Session("EstimatingLogoLocation") = ar(1)
                    Session("EstimatingLogoLocationID") = ar(0)
                    ar = dl_location.SelectedItem.Text.Split("-")
                    Session("EstimatingLogoLocationName") = ar(1)
                End If
            Catch ex As Exception
                Session("JobOrderFormLogoLocation") = ""
            End Try
            Session("EstimatingClientPrint") = Me.LabelClientCode.Text
            Session("EstimatingDivisionPrint") = Me.LabelDivisionCode.Text
            Session("EstimatingProductPrint") = Me.LabelProductCode.Text
            Session("EstimatingDefFooter") = Me.txtDefauldFooterComment.Text
            Session("EstimatingSignature") = 999
            Session("EstimatingJobPrint") = Me.LabelJobNumber.Text
            Session("EstimatingCompPrint") = Me.LabelJobComponentNumber.Text
            addressoption = Me.rbCDPAddress.SelectedValue
            If Me.cbUsePrintedDate.Checked = True Then
                Session("EstimatingPrintedDate") = Me.hfCreateDate.Value
            Else
                If MiscFN.ValidDate(Me.RadDatePickerPrintedDate) = True Then
                    Session("EstimatingPrintedDate") = Me.RadDatePickerPrintedDate.SelectedDate
                Else
                    Session("EstimatingPrintedDate") = ""
                End If
            End If
            Session("EstimatingReport") = "Estimating" & Me.ddReportFormat.SelectedValue
            Dim empSig As Int16
            If Me.cbExcludeEmpSig.Checked = True Then
                empSig = 1
            Else
                empSig = 0
            End If

            Dim EmailSwitch As String = ""
            If AsEmail = True Then

                EmailSwitch = "eml=1&"

            Else

                EmailSwitch = "eml=0&"

            End If
            If IsAssignment = True Then 'assignment switch overrides email switch

                EmailSwitch = "eml=0&assn=1&"

            End If
            Dim strURL As String = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=estimatingprint&j=" & Me.JobNum & "&jc=" & Me.JobCompNum & "&pagetype=est" & "&UseEmpSig=" & empSig '& "&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.Estimate)

            Dim chk As CheckBox
            Dim quotes As String
            Dim qtedesc As String = ""
            Dim qtedescs As String = ""
            Dim comps As String
            Dim qte As Integer
            Dim comp As Integer = 0
            Dim combine As Integer = 0
            Dim count As Integer = 0

            Dim MultiCounter As Integer = 0

            If Me.ddReportFormat.SelectedValue = "SS1" Or Me.ddReportFormat.SelectedValue = "008" Or Me.ddReportFormat.SelectedValue = "009" Or Me.ddReportFormat.SelectedValue = "QUR" Or Me.ddReportFormat.SelectedValue = "TAP" Or Me.ddReportFormat.SelectedValue = "TAP2" Then
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstQuote.MasterTableView.Items
                    chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                    If Me._PrintSendAll = True Then chk.Checked = True
                    If gridDataItem.Selected = True Then
                        Try
                            comp = gridDataItem.GetDataKeyValue("EstimateComponentNumber")
                            qte = CInt(gridDataItem("colEST_QUOTE_NBR").Text.Replace("&nbsp;", ""))
                            qtedesc = gridDataItem("colEST_QUOTE_DESC").Text.Replace("&nbsp;", "").Replace(",", "_")
                        Catch ex As Exception
                            qte = 0
                            comp = 0
                            qtedesc = ""
                        End Try
                        quotes &= qte & ","
                        qtedescs &= qtedesc & ","
                        comps &= comp & ","
                        MultiCounter += 1
                    End If
                Next

                If comps = "" And Me._SelectedQuoteNumbers = "" Then

                    Me.ShowMessage("Please select at least one quote to print/send")
                    Exit Sub

                ElseIf comps = "" And Me._SelectedQuoteNumbers <> "" Then

                    quotes = Me._SelectedQuoteNumbers

                End If
                If comps.Trim() = "" And Me.EstCompNum > 0 Then
                    comps = Me.EstCompNum.ToString() & ","
                End If
                Session("EstimatingQteDescs") = qtedescs
                Session("EstimatingFncComment") = Me.CheckBoxFunctionComment.Checked
                strURL = strURL & "&e=" & Me.EstNum & "&ec=" & comp & "&Type=" & Me.ddlFormat.SelectedValue & "&Report=Estimating" & Me.ddReportFormat.SelectedValue & "&option=" & addressoption & "&quotes=" & quotes & "&comps=" & comps
                quotes = ""
            Else
                If Me.cbCombineComps.Checked = True Or Me.ddReportFormat.SelectedValue = "Mars" Or Me.ddReportFormat.SelectedValue = "BWD" Or Me.ddReportFormat.SelectedValue = "BWD2" Then
                    If Me.cbCombineComps.Checked = True Then
                        combine = 1
                    End If
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstQuote.MasterTableView.Items
                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        If Me._PrintSendAll = True Then chk.Checked = True
                        If gridDataItem.Selected = True Then
                            Try
                                If comp > 0 And comp <> gridDataItem.GetDataKeyValue("EstimateComponentNumber") Then
                                    If count > 4 And Me.ddReportFormat.SelectedValue = "002" Then
                                        Me.ShowMessage("Only 4 quotes may be selected per component for this report format.")
                                        Exit Sub
                                    End If
                                    If count > 2 And Me.ddReportFormat.SelectedValue = "314" Then
                                        Me.ShowMessage("Maximum 2 quotes may be selected per component for this report format.")
                                        Exit Sub
                                    End If
                                    count = 0
                                End If
                                comp = gridDataItem.GetDataKeyValue("EstimateComponentNumber")
                                qte = CInt(gridDataItem("colEST_QUOTE_NBR").Text.Replace("&nbsp;", ""))
                                qtedesc = gridDataItem("colEST_QUOTE_DESC").Text.Replace("&nbsp;", "").Replace(",", "_")
                            Catch ex As Exception
                                qte = 0
                                comp = 0
                                qtedesc = ""
                            End Try
                            quotes &= qte & ","
                            qtedescs &= qtedesc & ","
                            comps &= comp & ","
                            MultiCounter += 1
                            count += 1
                        End If
                    Next
                    'If Me.ddReportFormat.SelectedValue = "Mars" Then
                    '    quotes = MiscFN.RemoveTrailingDelimiter(quotes, ",")
                    '    comps = MiscFN.RemoveTrailingDelimiter(comps, ",")
                    'End If
                    If comps = "" And Me._SelectedQuoteNumbers = "" Then

                        Me.ShowMessage("Please select at least one quote to print/send")
                        Exit Sub

                    ElseIf comps = "" And Me._SelectedQuoteNumbers <> "" Then

                        quotes = Me._SelectedQuoteNumbers

                    End If
                    If comps.Trim() = "" And Me.EstCompNum > 0 Then
                        comps = Me.EstCompNum.ToString() & ","
                    End If
                    If count > 4 And Me.ddReportFormat.SelectedValue = "002" Then
                        Me.ShowMessage("Only 4 quotes may be selected per component for this report format.")
                        Exit Sub
                    End If
                    If count > 2 And Me.ddReportFormat.SelectedValue = "314" Then
                        Me.ShowMessage("Maximum 2 quotes may be selected per component for this report format.")
                        Exit Sub
                    End If
                    Session("EstimatingQteDescs") = qtedescs

                    If Me.ddReportFormat.SelectedValue = "Mars" Then
                        strURL = strURL & "&e=" & Me.EstNum & "&ec=" & comp & "&Type=" & Me.ddlFormat.SelectedValue & "&Report=Estimating" & Me.ddReportFormat.SelectedValue & "&option=" & addressoption & "&quotes=" & quotes & "&comps=" & comps & "&combine=1"
                    ElseIf Me.ddReportFormat.SelectedValue = "BWD" Or Me.ddReportFormat.SelectedValue = "BWD2" Then
                        strURL = strURL & "&combine=" & combine & "&e=" & Me.EstNum & "&ec=" & comp & "&Type=" & Me.ddlFormat.SelectedValue & "&Report=Estimating" & Me.ddReportFormat.SelectedValue & "&option=" & addressoption & "&quotes=" & quotes & "&comps=" & comps
                    Else
                        strURL = strURL & "&combine=1&e=" & Me.EstNum & "&ec=" & comp & "&Type=" & Me.ddlFormat.SelectedValue & "&Report=Estimating" & Me.ddReportFormat.SelectedValue & "&option=" & addressoption & "&quotes=" & quotes & "&comps=" & comps
                    End If
                    quotes = ""
                Else
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstQuote.MasterTableView.Items
                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        If Me._PrintSendAll = True Then chk.Checked = True
                        If gridDataItem.Selected = True Then
                            Try
                                If comp > 0 And comp <> gridDataItem.GetDataKeyValue("EstimateComponentNumber") Then
                                    If count > 4 And Me.ddReportFormat.SelectedValue = "002" Then
                                        Me.ShowMessage("Only 4 quotes may be selected per component for this report format.")
                                        Exit Sub
                                    End If
                                    If count > 2 And Me.ddReportFormat.SelectedValue = "314" Then
                                        Me.ShowMessage("Maximum 2 quotes may be selected per component for this report format.")
                                        Exit Sub
                                    End If
                                    count = 0
                                End If
                                comp = gridDataItem.GetDataKeyValue("EstimateComponentNumber")
                                qte = CInt(gridDataItem("colEST_QUOTE_NBR").Text.Replace("&nbsp;", ""))
                                qtedesc = gridDataItem("colEST_QUOTE_DESC").Text.Replace("&nbsp;", "").Replace(",", "_")
                            Catch ex As Exception
                                qte = 0
                                comp = 0
                                qtedesc = ""
                            End Try
                            quotes &= qte & ","
                            qtedescs &= qtedesc & ","
                            comps &= comp & ","
                            MultiCounter += 1
                            count += 1

                        End If
                    Next

                    If comps = "" And Me._SelectedQuoteNumbers = "" Then

                        Me.ShowMessage("Please select at least one quote to print/send")
                        Exit Sub

                    ElseIf comps = "" And Me._SelectedQuoteNumbers <> "" Then

                        quotes = Me._SelectedQuoteNumbers

                    End If
                    If comps.Trim() = "" And Me.EstCompNum > 0 Then
                        comps = Me.EstCompNum.ToString() & ","
                    End If
                    If count > 4 And Me.ddReportFormat.SelectedValue = "002" Then
                        Me.ShowMessage("Only 4 quotes may be selected per component for this report format.")
                        Exit Sub
                    End If
                    If count > 2 And Me.ddReportFormat.SelectedValue = "314" Then
                        Me.ShowMessage("Maximum 2 quotes may be selected per component for this report format.")
                        Exit Sub
                    End If
                    Session("EstimatingQteDescs") = qtedescs
                    strURL = strURL & "&e=" & Me.EstNum & "&ec=" & comp & "&Type=" & Me.ddlFormat.SelectedValue & "&Report=Estimating" & Me.ddReportFormat.SelectedValue & "&option=" & addressoption & "&quotes=" & quotes & "&comps=" & comps
                    quotes = ""
                End If

            End If
            If MultiCounter > 1 Then

                strURL &= "&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.Estimate)

            Else

                strURL &= "&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.EstimateComponent)

            End If
            If IsAssignment = True Then

                Session("EstimatingPrintEstimatingNumber") = Me.EstNum
                Session("EstimatingPrintEstimatingComponentNumber") = comp
                Session("EstimatingPrintType") = Me.ddlFormat.SelectedValue
                Session("EstimatingPrintReport") = "Estimating" & Me.ddReportFormat.SelectedValue
                Session("EstimatingPrintOption") = addressoption
                Session("EstimatingPrintQuotes") = quotes
                Session("EstimatingPrintComp") = comps

                strURL = strURL.Replace("caller=estimatingprint", "caller=EstimatingPrint")
                strURL = strURL.Replace("Alert_New.aspx", "Desktop_NewAssignment")

                Me.OpenWindow("New Assignment", strURL)

            Else

                Me.OpenWindow("New Alert", strURL)

            End If


        Catch ex As Exception
            Me.ShowMessage("err opening print data window")
        End Try

    End Sub

    Private Sub LoadSettings()
        Try
            Dim oEstimating As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim dt As DataTable
            Dim i As Integer
            Dim s As String
            Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
            Dim str As String
            Dim li As New Telerik.Web.UI.RadComboBoxItem
            dr = oEstimating.GetPrintDef(Session("UserCode"))

            Dim EstimatePrint As AdvantageFramework.Database.Entities.EstimatePrintSetting = Nothing
            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                EstimatePrint = AdvantageFramework.Database.Procedures.EstimatePrintSetting.LoadByEstimatePrintSettingUserID(DataContext, _Session.UserCode)
                If EstimatePrint IsNot Nothing Then
                    If EstimatePrint.DateToPrint = 2 Then
                        Me.cbUsePrintedDate.Checked = True
                        Me.pnlDate.Visible = True
                    End If
                    If EstimatePrint.ShowTaxSeparately = 1 Then
                        Me.cbShowTax.Checked = True
                    End If
                    If EstimatePrint.IndicateTaxableFunctions = 1 Then
                        Me.cbIndicateTax.Checked = True
                    End If
                    If EstimatePrint.ShowCommissionSeparately Then
                        Me.cbShowComm.Checked = True
                    End If
                    If EstimatePrint.IndicateCommissionFunctions = 1 Then
                        Me.cbIndicateCommMU.Checked = True
                    End If
                    If EstimatePrint.FunctionOption = "F" Or EstimatePrint.FunctionOption = "" Then
                        Me.rbFunctionCode.Checked = True
                        Me.rbConsolidationCode.Checked = False
                        Me.rbTotalOnly.Checked = False
                        Me.rbRate.Checked = False
                        Me.rbNone.Checked = False
                        Me.cbIndicateTax.Enabled = True
                        Me.cbIndicateCommMU.Enabled = True
                        Me.rbNoneGroupby.Enabled = True
                        Me.rbFunctionType.Enabled = True
                        Me.rbFunctionHeading.Enabled = True
                        Me.rbInsideOutside.Enabled = True
                        Me.lblInsideDesc.Enabled = True
                        Me.lblOutsideDesc.Enabled = True
                        Me.txtInsideDesc.Enabled = True
                        Me.txtOutsideDesc.Enabled = True
                        Me.rbFunctionCodeSort.Enabled = True
                        Me.rbFunctionOrderSort.Enabled = True
                        Me.rbPhase.Enabled = True
                        Me.cbIncludeRate.Enabled = False
                    End If
                    If EstimatePrint.FunctionOption = "C" Then
                        Me.rbConsolidationCode.Checked = True
                        Me.rbFunctionCode.Checked = False
                        Me.rbTotalOnly.Checked = False
                        Me.rbRate.Checked = False
                        Me.rbNone.Checked = False
                        Me.cbIndicateTax.Enabled = True
                        Me.cbIndicateCommMU.Enabled = True
                        Me.rbNoneGroupby.Enabled = True
                        Me.rbFunctionType.Enabled = True
                        Me.rbFunctionHeading.Enabled = True
                        Me.rbInsideOutside.Enabled = True
                        Me.lblInsideDesc.Enabled = True
                        Me.lblOutsideDesc.Enabled = True
                        Me.txtInsideDesc.Enabled = True
                        Me.txtOutsideDesc.Enabled = True
                        Me.rbFunctionCodeSort.Enabled = True
                        Me.rbFunctionOrderSort.Enabled = True
                        Me.rbPhase.Enabled = True
                        Me.cbIncludeRate.Enabled = False
                    End If
                    If EstimatePrint.FunctionOption = "T" Then
                        Me.rbTotalOnly.Checked = True
                        Me.rbFunctionCode.Checked = False
                        Me.rbConsolidationCode.Checked = False
                        Me.rbRate.Checked = False
                        Me.rbNone.Checked = False
                        Me.cbIndicateTax.InputAttributes.Add("disabled", "disabled")
                        Me.cbIndicateCommMU.InputAttributes.Add("disabled", "disabled")
                        Me.rbNoneGroupby.InputAttributes.Add("disabled", "disabled")
                        Me.rbFunctionType.InputAttributes.Add("disabled", "disabled")
                        Me.rbFunctionHeading.InputAttributes.Add("disabled", "disabled")
                        Me.rbInsideOutside.InputAttributes.Add("disabled", "disabled")
                        Me.rbFunctionCodeSort.InputAttributes.Add("disabled", "disabled")
                        Me.rbFunctionOrderSort.InputAttributes.Add("disabled", "disabled")
                        Me.rbPhase.InputAttributes.Add("disabled", "disabled")
                        Me.rbFunctionHeadingTO.InputAttributes.Add("disabled", "disabled")
                        'Me.cbIndicateTax.Enabled = False
                        'Me.cbIndicateCommMU.Enabled = False
                        'Me.rbNoneGroupby.Enabled = False
                        'Me.rbFunctionType.Enabled = False
                        'Me.rbFunctionHeading.Enabled = False
                        'Me.rbInsideOutside.Enabled = False
                        Me.lblInsideDesc.Enabled = False
                        Me.lblOutsideDesc.Enabled = False
                        Me.txtInsideDesc.Enabled = False
                        Me.txtOutsideDesc.Enabled = False
                        'Me.rbFunctionCodeSort.Enabled = False
                        'Me.rbFunctionOrderSort.Enabled = False
                        'Me.rbPhase.Enabled = False
                        Me.cbIncludeRate.Enabled = False
                    End If
                    If EstimatePrint.FunctionOption = "R" Then
                        Me.rbRate.Checked = True
                        Me.rbTotalOnly.Checked = False
                        Me.rbFunctionCode.Checked = False
                        Me.rbConsolidationCode.Checked = False
                        Me.rbNone.Checked = False
                        Me.cbIndicateTax.Enabled = True
                        Me.cbIndicateCommMU.Enabled = True
                        Me.rbNoneGroupby.Enabled = True
                        Me.rbFunctionType.Enabled = True
                        Me.rbFunctionHeading.Enabled = True
                        Me.rbInsideOutside.Enabled = True
                        Me.lblInsideDesc.Enabled = True
                        Me.lblOutsideDesc.Enabled = True
                        Me.txtInsideDesc.Enabled = True
                        Me.txtOutsideDesc.Enabled = True
                        Me.rbFunctionCodeSort.Enabled = True
                        Me.rbFunctionOrderSort.Enabled = True
                        Me.rbPhase.Enabled = True
                        Me.rbFunctionHeadingTO.Checked = False
                        Me.cbIncludeRate.Enabled = False
                    End If
                    If EstimatePrint.FunctionOption = "N" Then
                        Me.rbNone.Checked = True
                        Me.rbTotalOnly.Checked = False
                        Me.rbFunctionCode.Checked = False
                        Me.rbConsolidationCode.Checked = False
                        Me.rbRate.Checked = False
                        Me.cbIndicateTax.Enabled = True
                        Me.cbIndicateCommMU.Enabled = True
                        Me.rbNoneGroupby.Enabled = True
                        Me.rbFunctionType.Enabled = True
                        Me.rbFunctionHeading.Enabled = True
                        Me.rbInsideOutside.Enabled = True
                        Me.lblInsideDesc.Enabled = True
                        Me.lblOutsideDesc.Enabled = True
                        Me.txtInsideDesc.Enabled = True
                        Me.txtOutsideDesc.Enabled = True
                        Me.rbFunctionCodeSort.Enabled = True
                        Me.rbFunctionOrderSort.Enabled = True
                        Me.rbPhase.Enabled = True
                        Me.rbFunctionHeadingTO.Checked = False
                        Me.cbIncludeRate.Enabled = True
                    End If
                    If EstimatePrint.GroupOption = "P" Then
                        Me.rbPhase.Checked = True
                        Me.lblInsideDesc.Enabled = False
                        Me.lblOutsideDesc.Enabled = False
                        Me.txtInsideDesc.Enabled = False
                        Me.txtOutsideDesc.Enabled = False
                        Me.rbFunctionHeadingTO.Checked = False
                    End If
                    If EstimatePrint.GroupOption = "T" Then
                        Me.rbFunctionType.Checked = True
                        Me.lblInsideDesc.Enabled = False
                        Me.lblOutsideDesc.Enabled = False
                        Me.txtInsideDesc.Enabled = False
                        Me.txtOutsideDesc.Enabled = False
                        Me.rbFunctionHeadingTO.Checked = False
                    End If
                    If EstimatePrint.GroupOption = "N" Or EstimatePrint.GroupOption = "" Then
                        Me.rbNoneGroupby.Checked = True
                        Me.lblInsideDesc.Enabled = False
                        Me.lblOutsideDesc.Enabled = False
                        Me.txtInsideDesc.Enabled = False
                        Me.txtOutsideDesc.Enabled = False
                        Me.rbFunctionHeadingTO.Checked = False
                    End If
                    If EstimatePrint.GroupOption = "H" Then
                        Me.rbFunctionHeading.Checked = True
                        Me.lblInsideDesc.Enabled = False
                        Me.lblOutsideDesc.Enabled = False
                        Me.txtInsideDesc.Enabled = False
                        Me.txtOutsideDesc.Enabled = False
                        Me.rbFunctionHeadingTO.Checked = False
                    End If
                    If EstimatePrint.GroupOption = "HT" Then
                        Me.rbFunctionHeadingTO.Checked = True
                        Me.rbFunctionHeading.Checked = False
                        Me.lblInsideDesc.Enabled = False
                        Me.lblOutsideDesc.Enabled = False
                        Me.txtInsideDesc.Enabled = False
                        Me.txtOutsideDesc.Enabled = False
                        Me.cbSubtotalsOnly.Checked = False
                        Me.cbSubtotalsOnly.InputAttributes.Add("disabled", "disabled")
                        Me.rbFunctionCodeSort.Checked = True
                        Me.rbFunctionOrderSort.Checked = False
                        Me.rbFunctionOrderSort.InputAttributes.Add("disabled", "disabled")
                        Me.rbFunctionCodeSort.InputAttributes.Add("disabled", "disabled")
                    End If
                    If EstimatePrint.GroupOption = "I" Then
                        Me.rbInsideOutside.Checked = True
                        Me.txtInsideDesc.Text = EstimatePrint.InsideDescription
                        Me.txtOutsideDesc.Text = EstimatePrint.OutsideDescription
                    End If
                    If EstimatePrint.SortOption = "C" Or EstimatePrint.SortOption = "" Then
                        Me.rbFunctionCodeSort.Checked = True
                    End If
                    If EstimatePrint.SortOption = "O" Then
                        Me.rbFunctionOrderSort.Checked = True
                    End If

                    If EstimatePrint.IncludeEstimateComment = 1 Then
                        Me.cbEstimateComment.Checked = True
                    End If
                    If EstimatePrint.IncludeEstimateComponentComment = 1 Then
                        Me.cbEstimateCompComment.Checked = True
                    End If
                    If EstimatePrint.IncludeEstimateQuoteComment = 1 Then
                        Me.cbQuoteComment.Checked = True
                    End If
                    If EstimatePrint.IncludeEstimateRevisionComment = 1 Then
                        Me.cbRevisionComment.Checked = True
                    End If
                    If EstimatePrint.IncludeEstimateFunctionComment = 1 Then
                        Me.cbFunctionComment.Checked = True
                    End If
                    If EstimatePrint.DefaultFooterComment = 1 Then
                        Me.cbDefaultFooterComment.Checked = True
                    End If
                    If EstimatePrint.IncludeClientReference = 1 Then
                        Me.cbClientReference.Checked = True
                    End If
                    If EstimatePrint.IncludeAccountExecutive = 1 Then
                        Me.cbAEName.Checked = True
                    End If
                    If EstimatePrint.IncludeSalesClass = 1 Then
                        Me.cbSalesClass.Checked = True
                    End If
                    'If dr("SPECS") = 1 Then
                    '    Me.cbSpecs.Checked = True
                    'End If
                    If EstimatePrint.IncludeJobQuantity = 1 Then
                        Me.cbEstimateQuantity.Checked = True
                    End If
                    If EstimatePrint.IncludeContingency = 1 Then
                        Me.cbIncludeCont.Checked = True
                        If EstimatePrint.ShowContingencySeparately = 1 Then
                            Me.cbShowCont.Checked = True
                        End If
                    Else
                        Me.cbShowCont.InputAttributes.Add("disabled", "disabled")
                    End If
                    If EstimatePrint.SuppressZeroFunctions = 1 Then
                        Me.cbSuppresZero.Checked = True
                    End If
                    'If dr("LOCATION_ID") <> "" Then
                    '    Me.dl_location.SelectedValue = dr("LOCATION_ID")
                    'End If
                    Me.dl_location.ClearSelection()
                    Try
                        If EstimatePrint.LocationCode <> "" And EstimatePrint.LocationCode <> "None" Then
                            li = Me.dl_location.FindItemByText(EstimatePrint.LocationCode & " - " & PO.GetPO_PrintDef_LocationName(EstimatePrint.LocationCode))
                            li.Selected = True
                        Else
                            li = Me.dl_location.FindItemByText("None")
                            li.Selected = True
                        End If

                    Catch ex As Exception

                    End Try
                    If EstimatePrint.IncludeNonBillable = 1 Then
                        Me.cbIncludeNonBillable.Checked = True
                    End If
                    If EstimatePrint.PrintDivisionName = 1 Then
                        Me.cbPrintDivisionName.Checked = True
                    End If
                    If EstimatePrint.PrintProductDescription = 1 Then
                        Me.cbPrintProductName.Checked = True
                    End If
                    If EstimatePrint.IncludeQuantityHours = 1 Then
                        Me.cbIncludeQtyHrs.Checked = True
                    End If
                    If EstimatePrint.SubtotalsOnly = 1 Then
                        Me.cbSubtotalsOnly.Checked = True
                    End If
                    If EstimatePrint.ConsolidationOverride = 1 Then
                        Me.cbOverride.Checked = True
                    End If
                    If EstimatePrint.IncludeCPU = 1 Then
                        Me.cbIncludeCPU.Checked = True
                    End If
                    If EstimatePrint.IncludeCPM = 1 Then
                        Me.cbIncludeCPM.Checked = True
                    End If
                    If EstimatePrint.ReportTitle <> "" Then
                        Me.txtReportTitle.Text = EstimatePrint.ReportTitle
                    End If
                    If EstimatePrint.IncludeSuppliedByNotes = 1 Then
                        Me.cbSuppliedByNotes.Checked = True
                    End If
                    If IsNumeric(EstimatePrint.Signature) = True Then
                        Me.ddSignature.SelectedValue = EstimatePrint.Signature
                    End If
                    If EstimatePrint.HideComponentDescription = 1 Then
                        Me.cbHideCompDesc.Checked = True
                    End If
                    If EstimatePrint.HideRevision = 1 Then
                        Me.cbHideRevision.Checked = True
                    End If
                    If EstimatePrint.IncludeJobDueDate = 1 Then
                        Me.cbJobDueDate.Checked = True
                    End If
                    If EstimatePrint.UseEmployeeSignature = 1 Then
                        Me.cbExcludeEmpSig.Checked = True
                    End If
                    Me.ddReportFormat.SelectedValue = EstimatePrint.ReportFormat
                    If EstimatePrint.ExcludeEmployeeTime = 1 Then
                        Me.CheckBoxExcludeEmpTime.Checked = True
                        Me.CheckBoxEmp.Checked = True
                    End If
                    If EstimatePrint.ExcludeVendor = 1 Then
                        Me.CheckBoxExcludeVendor.Checked = True
                        Me.CheckBoxVen.Checked = True
                    End If
                    If EstimatePrint.ExcludeIncomeOnly = 1 Then
                        Me.CheckBoxExcludeIO.Checked = True
                        Me.CheckBoxIO.Checked = True
                    End If
                    If EstimatePrint.ExcludeSignatures = 1 Then
                        Me.CheckBoxExcludeSignatures.Checked = True
                    End If
                    If EstimatePrint.IncludeCampaignSummary = 1 Then
                        Me.CheckBoxCampaignSummary.Checked = True
                    End If
                    If EstimatePrint.IncludeVendorDescription = 1 Then
                        Me.CheckBoxVendor.Checked = True
                    End If
                    If EstimatePrint.ExcludeNonbillable = 1 Then
                        Me.CheckBoxExcludeNonBillableFunctions.Checked = True
                    End If
                    If EstimatePrint.IncludeRate = 1 Then
                        Me.cbIncludeRate.Checked = True
                    End If
                    If EstimatePrint.CombineComponents = 1 Then
                        Me.cbCombineComps.Checked = True
                    End If
                    If EstimatePrint.PrintClientName = 1 Then
                        Me.cbPrintClientName.Checked = True
                    End If
                    If EstimatePrint.IncludeFunctionComment = 1 Then
                        Me.CheckBoxFunctionComment.Checked = True
                    End If
                    If EstimatePrint.PrintAdNumber = 1 Then
                        Me.cbAdNumber.Checked = True
                    End If
                    Me.rbCDPAddress.SelectedValue = EstimatePrint.CDPAddressOption
                    Me.ddlFormat.SelectedValue = EstimatePrint.FileFormat
                Else
                    Me.rbNoneGroupby.Checked = True
                    Me.rbFunctionCodeSort.Checked = True
                    Me.rbFunctionCode.Checked = True
                End If
            End Using


            'If dr.HasRows = True Then
            '    Do While dr.Read
            '        'If dr("SELECT_BY") = "E" Then
            '        '    Me.rbEstimate.Checked = True
            '        'End If
            '        'If dr("SELECT_BY") = "J" Then
            '        '    Me.rbJob.Checked = True
            '        'End If
            '        If dr("DATE_TO_PRINT") = 2 Then
            '            Me.cbUsePrintedDate.Checked = True
            '            Me.pnlDate.Visible = True
            '        End If
            '        If dr("TAX_SEPARATE") = 1 Then
            '            Me.cbShowTax.Checked = True
            '        End If
            '        If dr("TAX_INDICATOR") = 1 Then
            '            Me.cbIndicateTax.Checked = True
            '        End If
            '        If dr("COMM_MU_SEPARATE") = 1 Then
            '            Me.cbShowComm.Checked = True
            '        End If
            '        If dr("COMM_MU_INDICATOR") = 1 Then
            '            Me.cbIndicateCommMU.Checked = True
            '        End If
            '        If dr("FUNCTION_OPTION") = "F" Or dr("FUNCTION_OPTION") = "" Then
            '            Me.rbFunctionCode.Checked = True
            '            Me.rbConsolidationCode.Checked = False
            '            Me.rbTotalOnly.Checked = False
            '            Me.rbRate.Checked = False
            '            Me.rbNone.Checked = False
            '            Me.cbIndicateTax.Enabled = True
            '            Me.cbIndicateCommMU.Enabled = True
            '            Me.rbNoneGroupby.Enabled = True
            '            Me.rbFunctionType.Enabled = True
            '            Me.rbFunctionHeading.Enabled = True
            '            Me.rbInsideOutside.Enabled = True
            '            Me.lblInsideDesc.Enabled = True
            '            Me.lblOutsideDesc.Enabled = True
            '            Me.txtInsideDesc.Enabled = True
            '            Me.txtOutsideDesc.Enabled = True
            '            Me.rbFunctionCodeSort.Enabled = True
            '            Me.rbFunctionOrderSort.Enabled = True
            '            Me.rbPhase.Enabled = True
            '            Me.cbIncludeRate.Enabled = False
            '        End If
            '        If dr("FUNCTION_OPTION") = "C" Then
            '            Me.rbConsolidationCode.Checked = True
            '            Me.rbFunctionCode.Checked = False
            '            Me.rbTotalOnly.Checked = False
            '            Me.rbRate.Checked = False
            '            Me.rbNone.Checked = False
            '            Me.cbIndicateTax.Enabled = True
            '            Me.cbIndicateCommMU.Enabled = True
            '            Me.rbNoneGroupby.Enabled = True
            '            Me.rbFunctionType.Enabled = True
            '            Me.rbFunctionHeading.Enabled = True
            '            Me.rbInsideOutside.Enabled = True
            '            Me.lblInsideDesc.Enabled = True
            '            Me.lblOutsideDesc.Enabled = True
            '            Me.txtInsideDesc.Enabled = True
            '            Me.txtOutsideDesc.Enabled = True
            '            Me.rbFunctionCodeSort.Enabled = True
            '            Me.rbFunctionOrderSort.Enabled = True
            '            Me.rbPhase.Enabled = True
            '            Me.cbIncludeRate.Enabled = False
            '        End If
            '        If dr("FUNCTION_OPTION") = "T" Then
            '            Me.rbTotalOnly.Checked = True
            '            Me.rbFunctionCode.Checked = False
            '            Me.rbConsolidationCode.Checked = False
            '            Me.rbRate.Checked = False
            '            Me.rbNone.Checked = False
            '            Me.cbIndicateTax.InputAttributes.Add("disabled", "disabled")
            '            Me.cbIndicateCommMU.InputAttributes.Add("disabled", "disabled")
            '            Me.rbNoneGroupby.InputAttributes.Add("disabled", "disabled")
            '            Me.rbFunctionType.InputAttributes.Add("disabled", "disabled")
            '            Me.rbFunctionHeading.InputAttributes.Add("disabled", "disabled")
            '            Me.rbInsideOutside.InputAttributes.Add("disabled", "disabled")
            '            Me.rbFunctionCodeSort.InputAttributes.Add("disabled", "disabled")
            '            Me.rbFunctionOrderSort.InputAttributes.Add("disabled", "disabled")
            '            Me.rbPhase.InputAttributes.Add("disabled", "disabled")
            '            Me.rbFunctionHeadingTO.InputAttributes.Add("disabled", "disabled")
            '            'Me.cbIndicateTax.Enabled = False
            '            'Me.cbIndicateCommMU.Enabled = False
            '            'Me.rbNoneGroupby.Enabled = False
            '            'Me.rbFunctionType.Enabled = False
            '            'Me.rbFunctionHeading.Enabled = False
            '            'Me.rbInsideOutside.Enabled = False
            '            Me.lblInsideDesc.Enabled = False
            '            Me.lblOutsideDesc.Enabled = False
            '            Me.txtInsideDesc.Enabled = False
            '            Me.txtOutsideDesc.Enabled = False
            '            'Me.rbFunctionCodeSort.Enabled = False
            '            'Me.rbFunctionOrderSort.Enabled = False
            '            'Me.rbPhase.Enabled = False
            '            Me.cbIncludeRate.Enabled = False
            '        End If
            '        If dr("FUNCTION_OPTION") = "R" Then
            '            Me.rbRate.Checked = True
            '            Me.rbTotalOnly.Checked = False
            '            Me.rbFunctionCode.Checked = False
            '            Me.rbConsolidationCode.Checked = False
            '            Me.rbNone.Checked = False
            '            Me.cbIndicateTax.Enabled = True
            '            Me.cbIndicateCommMU.Enabled = True
            '            Me.rbNoneGroupby.Enabled = True
            '            Me.rbFunctionType.Enabled = True
            '            Me.rbFunctionHeading.Enabled = True
            '            Me.rbInsideOutside.Enabled = True
            '            Me.lblInsideDesc.Enabled = True
            '            Me.lblOutsideDesc.Enabled = True
            '            Me.txtInsideDesc.Enabled = True
            '            Me.txtOutsideDesc.Enabled = True
            '            Me.rbFunctionCodeSort.Enabled = True
            '            Me.rbFunctionOrderSort.Enabled = True
            '            Me.rbPhase.Enabled = True
            '            Me.rbFunctionHeadingTO.Checked = False
            '            Me.cbIncludeRate.Enabled = False
            '        End If
            '        If dr("FUNCTION_OPTION") = "N" Then
            '            Me.rbNone.Checked = True
            '            Me.rbTotalOnly.Checked = False
            '            Me.rbFunctionCode.Checked = False
            '            Me.rbConsolidationCode.Checked = False
            '            Me.rbRate.Checked = False
            '            Me.cbIndicateTax.Enabled = True
            '            Me.cbIndicateCommMU.Enabled = True
            '            Me.rbNoneGroupby.Enabled = True
            '            Me.rbFunctionType.Enabled = True
            '            Me.rbFunctionHeading.Enabled = True
            '            Me.rbInsideOutside.Enabled = True
            '            Me.lblInsideDesc.Enabled = True
            '            Me.lblOutsideDesc.Enabled = True
            '            Me.txtInsideDesc.Enabled = True
            '            Me.txtOutsideDesc.Enabled = True
            '            Me.rbFunctionCodeSort.Enabled = True
            '            Me.rbFunctionOrderSort.Enabled = True
            '            Me.rbPhase.Enabled = True
            '            Me.rbFunctionHeadingTO.Checked = False
            '            Me.cbIncludeRate.Enabled = True
            '        End If
            '        If dr("GROUP_OPTION") = "P" Then
            '            Me.rbPhase.Checked = True
            '            Me.lblInsideDesc.Enabled = False
            '            Me.lblOutsideDesc.Enabled = False
            '            Me.txtInsideDesc.Enabled = False
            '            Me.txtOutsideDesc.Enabled = False
            '            Me.rbFunctionHeadingTO.Checked = False
            '        End If
            '        If dr("GROUP_OPTION") = "T" Then
            '            Me.rbFunctionType.Checked = True
            '            Me.lblInsideDesc.Enabled = False
            '            Me.lblOutsideDesc.Enabled = False
            '            Me.txtInsideDesc.Enabled = False
            '            Me.txtOutsideDesc.Enabled = False
            '            Me.rbFunctionHeadingTO.Checked = False
            '        End If
            '        If dr("GROUP_OPTION") = "N" Or dr("GROUP_OPTION") = "" Then
            '            Me.rbNoneGroupby.Checked = True
            '            Me.lblInsideDesc.Enabled = False
            '            Me.lblOutsideDesc.Enabled = False
            '            Me.txtInsideDesc.Enabled = False
            '            Me.txtOutsideDesc.Enabled = False
            '            Me.rbFunctionHeadingTO.Checked = False
            '        End If
            '        If dr("GROUP_OPTION") = "H" Then
            '            Me.rbFunctionHeading.Checked = True
            '            Me.lblInsideDesc.Enabled = False
            '            Me.lblOutsideDesc.Enabled = False
            '            Me.txtInsideDesc.Enabled = False
            '            Me.txtOutsideDesc.Enabled = False
            '            Me.rbFunctionHeadingTO.Checked = False
            '        End If
            '        If dr("GROUP_OPTION") = "HT" Then
            '            Me.rbFunctionHeadingTO.Checked = True
            '            Me.rbFunctionHeading.Checked = False
            '            Me.lblInsideDesc.Enabled = False
            '            Me.lblOutsideDesc.Enabled = False
            '            Me.txtInsideDesc.Enabled = False
            '            Me.txtOutsideDesc.Enabled = False
            '            Me.cbSubtotalsOnly.Checked = False
            '            Me.cbSubtotalsOnly.InputAttributes.Add("disabled", "disabled")
            '            Me.rbFunctionCodeSort.Checked = True
            '            Me.rbFunctionOrderSort.Checked = False
            '            Me.rbFunctionOrderSort.InputAttributes.Add("disabled", "disabled")
            '            Me.rbFunctionCodeSort.InputAttributes.Add("disabled", "disabled")
            '        End If
            '        If dr("GROUP_OPTION") = "I" Then
            '            Me.rbInsideOutside.Checked = True
            '            Me.txtInsideDesc.Text = dr("INSIDE_CHG_DESC")
            '            Me.txtOutsideDesc.Text = dr("OUTSIDE_CHG_DESC")
            '        End If
            '        If dr("SORT_OPTION") = "C" Or dr("SORT_OPTION") = "" Then
            '            Me.rbFunctionCodeSort.Checked = True
            '        End If
            '        If dr("SORT_OPTION") = "O" Then
            '            Me.rbFunctionOrderSort.Checked = True
            '        End If

            '        If dr("EST_COMMENT") = 1 Then
            '            Me.cbEstimateComment.Checked = True
            '        End If
            '        If dr("EST_COMP_COMMENT") = 1 Then
            '            Me.cbEstimateCompComment.Checked = True
            '        End If
            '        If dr("QTE_COMMENT") = 1 Then
            '            Me.cbQuoteComment.Checked = True
            '        End If
            '        If dr("REV_COMMENT") = 1 Then
            '            Me.cbRevisionComment.Checked = True
            '        End If
            '        If dr("FUNC_COMMENT") = 1 Then
            '            Me.cbFunctionComment.Checked = True
            '        End If
            '        If dr("DEF_FOOTER_COMMENT") = 1 Then
            '            Me.cbDefaultFooterComment.Checked = True
            '        End If
            '        If dr("CLI_REF") = 1 Then
            '            Me.cbClientReference.Checked = True
            '        End If
            '        If dr("AE_NAME") = 1 Then
            '            Me.cbAEName.Checked = True
            '        End If
            '        If dr("PRT_SALES_CLASS") = 1 Then
            '            Me.cbSalesClass.Checked = True
            '        End If
            '        'If dr("SPECS") = 1 Then
            '        '    Me.cbSpecs.Checked = True
            '        'End If
            '        If dr("JOB_QTY") = 1 Then
            '            Me.cbEstimateQuantity.Checked = True
            '        End If
            '        If dr("CONTINGENCY") = 1 Then
            '            Me.cbIncludeCont.Checked = True
            '            If dr("CONT_SEPARATE") = 1 Then
            '                Me.cbShowCont.Checked = True
            '            End If
            '        Else
            '            Me.cbShowCont.InputAttributes.Add("disabled", "disabled")
            '        End If
            '        If dr("SUPPRESS_ZERO") = 1 Then
            '            Me.cbSuppresZero.Checked = True
            '        End If
            '        'If dr("LOCATION_ID") <> "" Then
            '        '    Me.dl_location.SelectedValue = dr("LOCATION_ID")
            '        'End If
            '        Me.dl_location.ClearSelection()
            '        Try
            '            If dr("LOCATION_ID") <> "" And dr("LOCATION_ID") <> "None" Then
            '                li = Me.dl_location.FindItemByText(dr("LOCATION_ID") & " - " & PO.GetPO_PrintDef_LocationName(dr("LOCATION_ID")))
            '                li.Selected = True
            '            Else
            '                li = Me.dl_location.FindItemByText("None")
            '                li.Selected = True
            '            End If

            '        Catch ex As Exception

            '        End Try
            '        If dr("PRT_NONBILL") = 1 Then
            '            Me.cbIncludeNonBillable.Checked = True
            '        End If
            '        If dr("PRT_DIV_NAME") = 1 Then
            '            Me.cbPrintDivisionName.Checked = True
            '        End If
            '        If dr("PRT_PRD_NAME") = 1 Then
            '            Me.cbPrintProductName.Checked = True
            '        End If
            '        If dr("QTY_HRS") = 1 Then
            '            Me.cbIncludeQtyHrs.Checked = True
            '        End If
            '        If dr("SUBTOT_ONLY") = 1 Then
            '            Me.cbSubtotalsOnly.Checked = True
            '        End If
            '        If dr("CONSOL_OVERRIDE") = 1 Then
            '            Me.cbOverride.Checked = True
            '        End If
            '        If dr("PRT_CPU") = 1 Then
            '            Me.cbIncludeCPU.Checked = True
            '        End If
            '        If dr("PRT_CPM") = 1 Then
            '            Me.cbIncludeCPM.Checked = True
            '        End If
            '        If dr("RPT_TITLE") <> "" Then
            '            Me.txtReportTitle.Text = dr("RPT_TITLE")
            '        End If
            '        If dr("SUP_BY_NOTES") = 1 Then
            '            Me.cbSuppliedByNotes.Checked = True
            '        End If
            '        If IsNumeric(dr("SIGNATURE")) = True Then
            '            Me.ddSignature.SelectedValue = dr("SIGNATURE")
            '        End If
            '        If dr("HIDE_COMP_DESC") = 1 Then
            '            Me.cbHideCompDesc.Checked = True
            '        End If
            '        If dr("HIDE_REVISION") = 1 Then
            '            Me.cbHideRevision.Checked = True
            '        End If
            '        If dr("JOB_DUE_DATE") = 1 Then
            '            Me.cbJobDueDate.Checked = True
            '        End If
            '        If dr("USE_EMP_SIG") = 1 Then
            '            Me.cbExcludeEmpSig.Checked = True
            '        End If
            '        Me.ddReportFormat.SelectedValue = dr("REPORT_FORMAT")
            '        If dr("EXCL_EMP_TIME") = 1 Then
            '            Me.CheckBoxExcludeEmpTime.Checked = True
            '            Me.CheckBoxEmp.Checked = True
            '        End If
            '        If dr("EXCL_VENDOR") = 1 Then
            '            Me.CheckBoxExcludeVendor.Checked = True
            '            Me.CheckBoxVen.Checked = True
            '        End If
            '        If dr("EXCL_IO") = 1 Then
            '            Me.CheckBoxExcludeIO.Checked = True
            '            Me.CheckBoxIO.Checked = True
            '        End If
            '        If dr("EXCL_SIGNATURES") = 1 Then
            '            Me.CheckBoxExcludeSignatures.Checked = True
            '        End If
            '        If dr("CMP_SUMMARY") = 1 Then
            '            Me.CheckBoxCampaignSummary.Checked = True
            '        End If
            '        If dr("VENDOR_DESC") = 1 Then
            '            Me.CheckBoxVendor.Checked = True
            '        End If
            '        If dr("EXCL_NONBILL") = 1 Then
            '            Me.CheckBoxExcludeNonBillableFunctions.Checked = True
            '        End If
            '    Loop
            'Else
            '    Me.rbNoneGroupby.Checked = True
            '    Me.rbFunctionCodeSort.Checked = True
            '    Me.rbFunctionCode.Checked = True
            'End If

            'dr.Close()

            If otask.getAppVars(Session("UserCode"), "EstimatingPrint", "CDPAddress") <> "" Then
                Me.rbCDPAddress.SelectedValue = otask.getAppVars(Session("UserCode"), "EstimatingPrint", "CDPAddress")
            End If
            If otask.getAppVars(Session("UserCode"), "EstimatingPrint", "IncludeRate") <> "" Then
                Me.cbIncludeRate.Checked = otask.getAppVars(Session("UserCode"), "EstimatingPrint", "IncludeRate")
            End If
            If otask.getAppVars(Session("UserCode"), "EstimatingPrint", "CombineComps") <> "" Then
                Me.cbCombineComps.Checked = otask.getAppVars(Session("UserCode"), "EstimatingPrint", "CombineComps")
            End If
            If otask.getAppVars(Session("UserCode"), "EstimatingPrint", "FunctionComment") <> "" Then
                Me.CheckBoxFunctionComment.Checked = otask.getAppVars(Session("UserCode"), "EstimatingPrint", "FunctionComment")
            End If
            If otask.getAppVars(Session("UserCode"), "EstimatingPrint", "PrintClientName") <> "" Then
                Me.cbPrintClientName.Checked = otask.getAppVars(Session("UserCode"), "EstimatingPrint", "PrintClientName")
            End If

            dt = oEstimating.GetEstimateData(EstNum, EstCompNum, JobNum, JobCompNum, Session("UserCode"))
            Dim oReports As New cReports(Session("ConnString"))
            Dim StandardComment As AdvantageFramework.Database.Entities.StandardComment = Nothing
            Dim StandardComments As Generic.List(Of AdvantageFramework.Database.Entities.StandardComment) = Nothing

            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Dim def As String = oReports.GetAgencyEstComment()
            Dim OfficeCode As String = ""
            Dim StandardFooterComments As String = Nothing

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0)("EST_FTR_COMMENT")) = False Then

                    If dt.Rows(0)("EST_FTR_COMMENT").ToString() = "Standard Comment" Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            StandardComments = AdvantageFramework.Database.Procedures.StandardComment.LoadByApplicationCode(DbContext, "Estimates").ToList

                            If StandardComments IsNot Nothing AndAlso StandardComments.Count > 0 Then
                                If Me.JobNum > 0 Then
                                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Me.JobNum)
                                    OfficeCode = Job.OfficeCode
                                Else
                                    Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, Me.LabelClientCode.Text, Me.LabelDivisionCode.Text, Me.LabelProductCode.Text)
                                    OfficeCode = Product.OfficeCode
                                End If

                                For Each ClientComment In StandardComments
                                    If OfficeCode = ClientComment.OfficeCode And Me.LabelClientCode.Text = ClientComment.ClientCode Then
                                        StandardFooterComments &= ClientComment.Comment
                                        StandardComment = ClientComment
                                        Exit For
                                    End If
                                Next

                                If StandardComment Is Nothing Then
                                    For Each ClientComment In StandardComments
                                        If OfficeCode = ClientComment.OfficeCode And ClientComment.ClientCode Is Nothing Then
                                            StandardFooterComments &= ClientComment.Comment
                                            StandardComment = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                                If StandardComment Is Nothing Then
                                    For Each ClientComment In StandardComments
                                        If ClientComment.OfficeCode Is Nothing And Me.LabelClientCode.Text = ClientComment.ClientCode Then
                                            StandardFooterComments &= ClientComment.Comment
                                            StandardComment = ClientComment
                                            Exit For
                                        End If
                                    Next
                                End If

                            End If

                            If StandardComment Is Nothing Then
                                For Each ClientComment In StandardComments
                                    If ClientComment.ClientCode Is Nothing And ClientComment.OfficeCode Is Nothing Then
                                        StandardFooterComments &= ClientComment.Comment
                                        StandardComment = ClientComment
                                        Exit For
                                    End If
                                Next
                            End If

                        End Using

                        If StandardComment IsNot Nothing Then

                            Me.txtDefauldFooterComment.Text = StandardComment.Comment
                            Session("EstimatingDefaultFooterFontSize") = StandardComment.FontSize.GetValueOrDefault(0)

                        Else

                            Me.txtDefauldFooterComment.Text = oReports.GetAgencyEstComment()
                            Session("EstimatingDefaultFooterFontSize") = 0

                        End If

                    ElseIf dt.Rows(0)("EST_FTR_COMMENT").ToString() = "Agency Defined" Then
                        Me.txtDefauldFooterComment.Text = oReports.GetAgencyEstComment()
                        Session("EstimatingDefaultFooterFontSize") = 0
                    Else

                        Me.txtDefauldFooterComment.Text = dt.Rows(0)("EST_FTR_COMMENT")
                        Session("EstimatingDefaultFooterFontSize") = 0

                    End If

                Else

                    Me.txtDefauldFooterComment.Text = oReports.GetAgencyEstComment()
                    Session("EstimatingDefaultFooterFontSize") = 0

                End If

            End If

            If Me.ddReportFormat.SelectedValue = "SS1" Or Me.ddReportFormat.SelectedValue = "SS2" Or Me.ddReportFormat.SelectedValue = "008" Or Me.ddReportFormat.SelectedValue = "009" Or Me.ddReportFormat.SelectedValue = "QUR" Or Me.ddReportFormat.SelectedValue = "TAP" Or Me.ddReportFormat.SelectedValue = "TAP2" Then
                Me.cbCombineComps.Checked = False
                Me.pnlOptions.Visible = False
                Me.Label5.Visible = False
                Me.Label7.Visible = False
                'Me.Label1.Visible = False
                Me.Label6.Visible = False
                Me.cbAdNumber.Enabled = False
                If Me.ddReportFormat.SelectedValue = "008" Or Me.ddReportFormat.SelectedValue = "009" Or Me.ddReportFormat.SelectedValue = "TAP" Or Me.ddReportFormat.SelectedValue = "TAP2" Then
                    Me.rbCDPAddress.Visible = True
                Else
                    Me.rbCDPAddress.Visible = False
                End If
                Me.ddSignature.Visible = False
                Me.CheckBoxExcludeSignatures.Visible = False
                'Me.txtReportTitle.Visible = False
                'Me.ddlFormat.Visible = False
                If Me.ddReportFormat.SelectedValue = "QUR" Then
                    Me.pnlExclude.Visible = True
                Else
                    Me.pnlExclude.Visible = False
                End If
                If Me.ddReportFormat.SelectedValue = "TAP" Or Me.ddReportFormat.SelectedValue = "TAP2" Then
                    Me.PanelOtherOptions.Visible = True
                Else
                    Me.PanelOtherOptions.Visible = False
                End If
            ElseIf Me.ddReportFormat.SelectedValue = "Infinity" Then
                Me.PnlCheck.Visible = False
                Me.rbCDPAddress.Visible = False
                Me.ddSignature.Visible = False
                Me.CheckBoxExcludeSignatures.Visible = False
                Me.Label5.Visible = False
                Me.Label7.Visible = False
                Me.PanelOtherOptions.Visible = False
                Me.cbAdNumber.Enabled = False
                Me.ddlFormat.Visible = True
            ElseIf Me.ddReportFormat.SelectedValue = "BWD" Then
                Me.pnlOptions.Visible = True
                Me.PnlCheck.Visible = True
                Me.rbCDPAddress.Visible = True
                Me.ddSignature.Visible = True
                Me.CheckBoxExcludeSignatures.Visible = True
                Me.Label5.Visible = True
                Me.Label7.Visible = True
                Me.rbRate.Enabled = False
                Me.rbNone.Enabled = False
                Me.rbTotalOnly.Enabled = False
                Me.cbPrintClientName.Enabled = False
                Me.cbPrintDivisionName.Enabled = False
                Me.cbPrintProductName.Enabled = False
                Me.cbEstimateCompComment.Enabled = False
                'Me.cbQuoteComment.Enabled = False
                'Me.cbRevisionComment.Enabled = False
                Me.cbFunctionComment.Enabled = True
                Me.cbSuppliedByNotes.Enabled = False
                Me.cbHideCompDesc.Enabled = False
                Me.cbHideRevision.Enabled = False
                Me.cbClientReference.Enabled = False
                Me.cbAEName.Enabled = False
                Me.cbSalesClass.Enabled = False
                Me.cbJobDueDate.Enabled = False
                Me.cbEstimateQuantity.Enabled = False
                Me.cbIncludeNonBillable.Enabled = False
                Me.cbSubtotalsOnly.Enabled = False
                Me.cbIncludeCPU.Enabled = False
                Me.cbIncludeCPM.Enabled = False
                Me.rbFunctionHeadingTO.Enabled = False
                Me.ddSignature.Items(6).Visible = True
                Me.CheckBoxExcludeSignatures.Visible = True
                Me.cbAdNumber.Enabled = False
                Me.ddlFormat.Visible = True
                Me.PanelOtherOptions.Visible = False
            ElseIf Me.ddReportFormat.SelectedValue = "BWD2" Then
                Me.pnlOptions.Visible = True
                Me.PnlCheck.Visible = True
                Me.rbCDPAddress.Visible = True
                Me.ddSignature.Visible = True
                Me.CheckBoxExcludeSignatures.Visible = True
                Me.Label5.Visible = True
                Me.Label7.Visible = True
                Me.rbRate.Enabled = False
                Me.rbNone.Enabled = False
                Me.rbTotalOnly.Enabled = False
                Me.cbPrintClientName.Enabled = False
                Me.cbPrintDivisionName.Enabled = False
                Me.cbPrintProductName.Enabled = False
                Me.cbEstimateCompComment.Enabled = False
                Me.cbQuoteComment.Enabled = True
                Me.cbRevisionComment.Enabled = False
                Me.cbFunctionComment.Enabled = False
                Me.cbSuppliedByNotes.Enabled = False
                Me.cbHideCompDesc.Enabled = False
                Me.cbHideRevision.Enabled = False
                Me.cbClientReference.Enabled = False
                Me.cbAEName.Enabled = False
                Me.cbSalesClass.Enabled = False
                Me.cbJobDueDate.Enabled = False
                Me.cbEstimateQuantity.Enabled = False
                Me.cbIncludeNonBillable.Enabled = False
                Me.cbSubtotalsOnly.Enabled = False
                Me.cbIncludeCPU.Enabled = False
                Me.cbIncludeCPM.Enabled = False
                Me.rbFunctionHeadingTO.Enabled = False
                Me.ddSignature.Items(6).Visible = True
                Me.CheckBoxExcludeSignatures.Visible = True
                Me.PanelOtherOptions.Visible = False
                Me.cbAdNumber.Enabled = False
                Me.ddlFormat.Visible = True
                'Me.rbFunctionHeading.Checked = True
            ElseIf Me.ddReportFormat.SelectedValue = "002" Or Me.ddReportFormat.SelectedValue = "314" Then
                Me.cbIndicateTax.Enabled = False
                Me.cbIndicateTax.Checked = False
                Me.cbIndicateCommMU.Enabled = False
                Me.cbIndicateCommMU.Checked = False
                Me.cbQuoteComment.Enabled = False
                Me.cbQuoteComment.Checked = False
                Me.cbRevisionComment.Checked = False
                Me.cbRevisionComment.Enabled = False
                Me.cbFunctionComment.Enabled = False
                Me.cbFunctionComment.Checked = False
                Me.cbEstimateQuantity.Enabled = False
                Me.cbEstimateQuantity.Checked = False
                Me.cbIncludeQtyHrs.Enabled = False
                Me.cbIncludeRate.Enabled = False
                Me.cbIncludeNonBillable.Checked = False
                Me.cbIncludeNonBillable.Enabled = False
                Me.rbRate.Enabled = False
                Me.rbNone.Enabled = False
                Me.rbRate.Checked = False
                Me.rbNone.Checked = False
                Me.rbFunctionHeadingTO.Enabled = False
                Me.rbFunctionHeadingTO.Checked = False
                Me.rbPhase.Enabled = False
                Me.rbPhase.Checked = False
                Me.pnlExclude.Visible = False
                Me.PanelOtherOptions.Visible = False
                Me.cbPrintClientName.Enabled = True
                Me.cbPrintDivisionName.Enabled = True
                Me.cbPrintProductName.Enabled = True
                Me.cbAdNumber.Enabled = True
                If Me.ddReportFormat.SelectedValue = "314" Then
                    Me.cbClientReference.Enabled = False
                    Me.cbAEName.Enabled = False
                    Me.cbSalesClass.Enabled = False
                    Me.cbJobDueDate.Enabled = False
                    Me.cbEstimateQuantity.Enabled = False
                    Me.cbFunctionComment.Enabled = True
                    Me.cbAdNumber.Enabled = False
                End If
            ElseIf Me.ddReportFormat.SelectedValue = "315" Then
                Me.cbClientReference.Enabled = False
                Me.cbAEName.Enabled = False
                Me.cbSalesClass.Enabled = False
                Me.cbJobDueDate.Enabled = False
                Me.cbEstimateQuantity.Enabled = False
                Me.cbIncludeCPM.Enabled = False
                Me.cbIncludeCPU.Enabled = False
                Me.cbAdNumber.Enabled = False
            Else
                Me.rbCDPAddress.Enabled = True
                Me.pnlOptions.Visible = True
                Me.PnlCheck.Visible = True
                Me.Label5.Visible = True
                Me.Label7.Visible = True
                Me.Label1.Visible = True
                Me.Label6.Visible = True
                Me.rbCDPAddress.Visible = True
                Me.ddSignature.Visible = True
                Me.CheckBoxExcludeSignatures.Visible = True
                Me.txtReportTitle.Visible = True
                Me.ddlFormat.Visible = True
                Me.ddSignature.Items(6).Visible = False
                Me.PanelOtherOptions.Visible = False
                If Me.ddReportFormat.SelectedValue = "001" Then
                    Me.cbAdNumber.Enabled = True
                End If
            End If
            If Me.cbCombineComps.Checked = True Then
                Me.cbHideRevision.InputAttributes.Add("disabled", "disabled")
                Me.cbHideCompDesc.InputAttributes.Add("disabled", "disabled")
                Me.cbIncludeRate.InputAttributes.Add("disabled", "disabled")
            Else
                Me.cbHideRevision.Enabled = True
                Me.cbHideCompDesc.Enabled = True
                If EstimatePrint.FunctionOption = "N" Then
                    Me.cbIncludeRate.Enabled = True
                End If
            End If

            If Me.ddReportFormat.SelectedValue = "" Then
                Me.ddSignature.FindItemByValue("8").Visible = True
            Else
                Me.ddSignature.FindItemByValue("8").Visible = False
            End If
        Catch ex As Exception
            Me.lbl_msg.Text = "LoadSettings err: " & ex.Message.ToString
        End Try
    End Sub

    Private Sub SaveSettings()
        Try
            Dim oEstimating As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim save As Boolean
            Dim dr As SqlDataReader = oEstimating.GetPrintDef(Session("UserCode"))
            Dim selectby As String = ""
            Dim functionoption As String = ""
            Dim groupoption As String = "N"
            Dim sortoption As String = "C"
            Dim ar() As String
            Dim locationid As String = ""
            Dim locationpath As String = ""
            Dim reporttitle As String = ""
            'If Me.rbEstimate.Checked = True Then
            '    selectby = "E"
            'ElseIf Me.rbJob.Checked = True Then
            '    selectby = "J"
            'End If
            If Me.rbFunctionCode.Checked = True Then
                functionoption = "F"
            ElseIf Me.rbConsolidationCode.Checked = True Then
                functionoption = "C"
            ElseIf Me.rbTotalOnly.Checked = True Then
                functionoption = "T"
            ElseIf Me.rbRate.Checked = True Then
                functionoption = "R"
            ElseIf Me.rbNone.Checked = True Then
                functionoption = "N"
            End If
            If Me.rbNoneGroupby.Checked = True Then
                groupoption = "N"
            ElseIf Me.rbFunctionType.Checked = True Then
                groupoption = "T"
            ElseIf Me.rbFunctionHeading.Checked = True Then
                groupoption = "H"
            ElseIf Me.rbInsideOutside.Checked = True Then
                groupoption = "I"
            ElseIf Me.rbPhase.Checked = True Then
                groupoption = "P"
            ElseIf Me.rbFunctionHeadingTO.Checked = True Then
                groupoption = "HT"
            End If
            If Me.rbFunctionCodeSort.Checked = True Then
                sortoption = "C"
            ElseIf Me.rbFunctionOrderSort.Checked = True Then
                sortoption = "O"
            End If
            If Me.dl_location.SelectedItem.Text = "None" Then
                locationpath = ""
                locationid = "None"
            Else
                ar = dl_location.SelectedValue.ToString.Split("|")
                locationpath = ar(1)
                locationid = ar(0)
            End If

            If Me.txtReportTitle.Text <> "" Then
                reporttitle = Me.txtReportTitle.Text
            End If

            Dim printedDate As Integer = 1
            Dim showtax As Integer = 0
            Dim indicatetax As Integer = 0
            Dim showcomm As Integer = 0
            Dim indicatecommmu As Integer = 0
            Dim showcont As Integer = 0
            Dim estimatecomment As Integer = 0
            Dim estimatecompcomment As Integer = 0
            Dim quotecomment As Integer = 0
            Dim revisioncomment As Integer = 0
            Dim functioncomment As Integer = 0
            Dim footercomment As Integer = 0
            Dim clientref As Integer = 0
            Dim aename As Integer = 0
            Dim salesclass As Integer = 0
            Dim specs As Integer = 0
            Dim estimatequantity As Integer = 0
            Dim includecont As Integer = 0
            Dim suppresszero As Integer = 0
            Dim includenonbill As Integer = 0
            Dim printdivname As Integer = 0
            Dim printprdname As Integer = 0
            Dim includeqtyhrs As Integer = 0
            Dim includerate As Integer = 0
            Dim override As Integer = 0
            Dim subtotalsonly As Integer = 0
            Dim includecpu As Integer = 0
            Dim includecpm As Integer = 0
            Dim suppliedbynotes As Integer = 0
            Dim hidecompdesc As Integer = 0
            Dim hiderev As Integer = 0
            Dim jobduedate As Integer = 0
            Dim useempsig As Integer = 0
            Dim excludeemptime As Integer = 0
            Dim excludevendor As Integer = 0
            Dim excludeio As Integer = 0
            Dim excludesignatures As Integer = 0
            Dim cmpsummary As Integer = 0
            Dim vendordesc As Integer = 0
            Dim excludenbfunctions As Integer = 0
            Dim fnccmt As Integer = 0
            Dim combinecomps As Integer = 0
            Dim printclname As Integer = 0
            Dim printadnumber As Integer = 0

            If Me.cbUsePrintedDate.Checked = True Then
                printedDate = 2
            End If
            If Me.cbShowTax.Checked = True Then
                showtax = 1
            End If
            If Me.cbIndicateTax.Checked = True Then
                indicatetax = 1
            End If
            If Me.cbShowComm.Checked = True Then
                showcomm = 1
            End If
            If Me.cbIndicateCommMU.Checked = True Then
                indicatecommmu = 1
            End If
            If Me.cbShowCont.Checked = True Then
                showcont = 1
            End If
            If Me.cbEstimateComment.Checked = True Then
                estimatecomment = 1
            End If
            If Me.cbEstimateCompComment.Checked = True Then
                estimatecompcomment = 1
            End If
            If Me.cbQuoteComment.Checked = True Then
                quotecomment = 1
            End If
            If Me.cbRevisionComment.Checked = True Then
                revisioncomment = 1
            End If
            If Me.cbFunctionComment.Checked = True Then
                functioncomment = 1
            End If
            If Me.cbDefaultFooterComment.Checked = True Then
                footercomment = 1
            End If
            If Me.cbClientReference.Checked = True Then
                clientref = 1
            End If
            If Me.cbAEName.Checked = True Then
                aename = 1
            End If
            If Me.cbSalesClass.Checked = True Then
                salesclass = 1
            End If
            'If Me.cbSpecs.Checked = True Then
            '    specs = 1
            'End If
            If Me.cbEstimateQuantity.Checked = True Then
                estimatequantity = 1
            End If
            If Me.cbIncludeCont.Checked = True Then
                includecont = 1
            End If
            If Me.cbSuppresZero.Checked = True Then
                suppresszero = 1
            End If
            If Me.cbIncludeNonBillable.Checked = True Then
                includenonbill = 1
            End If
            If Me.cbPrintDivisionName.Checked = True Then
                printdivname = 1
            End If
            If Me.cbPrintProductName.Checked = True Then
                printprdname = 1
            End If
            If Me.cbIncludeQtyHrs.Checked = True Then
                includeqtyhrs = 1
            End If
            If Me.cbIncludeRate.Checked = True Then
                includerate = 1
            End If
            If Me.cbOverride.Checked = True Then
                override = 1
            End If
            If Me.cbSubtotalsOnly.Checked = True Then
                subtotalsonly = 1
            End If
            If Me.cbIncludeCPU.Checked = True Then
                includecpu = 1
            End If
            If Me.cbIncludeCPM.Checked = True Then
                includecpm = 1
            End If
            If Me.cbSuppliedByNotes.Checked = True Then
                suppliedbynotes = 1
            End If
            If Me.cbHideCompDesc.Checked = True Then
                hidecompdesc = 1
            End If
            If Me.cbHideRevision.Checked = True Then
                hiderev = 1
            End If
            If Me.cbJobDueDate.Checked = True Then
                jobduedate = 1
            End If
            If Me.cbExcludeEmpSig.Checked = True Then
                useempsig = 1
            End If
            If Me.CheckBoxExcludeSignatures.Checked = True Then
                excludesignatures = 1
            End If
            If Me.CheckBoxExcludeNonBillableFunctions.Checked = True Then
                excludenbfunctions = 1
            End If
            If Me.cbCombineComps.Checked = True Then
                combinecomps = 1
            End If
            If Me.cbPrintClientName.Checked = True Then
                printclname = 1
            End If
            If Me.cbAdNumber.Checked = True Then
                printadnumber = 1
            End If
            If ddReportFormat.SelectedValue = "QUR" Then
                If Me.CheckBoxEmp.Checked = True Then
                    excludeemptime = 1
                End If
                If Me.CheckBoxVen.Checked = True Then
                    excludevendor = 1
                End If
                If Me.CheckBoxIO.Checked = True Then
                    excludeio = 1
                End If
            Else
                If Me.CheckBoxExcludeEmpTime.Checked = True Then
                    excludeemptime = 1
                End If
                If Me.CheckBoxExcludeVendor.Checked = True Then
                    excludevendor = 1
                End If
                If Me.CheckBoxExcludeIO.Checked = True Then
                    excludeio = 1
                End If
            End If
            If Me.ddReportFormat.SelectedValue = "TAP" Or Me.ddReportFormat.SelectedValue = "TAP2" Then
                If Me.CheckBoxCampaignSummary.Checked = True Then
                    cmpsummary = 1
                End If
                If Me.CheckBoxVendor.Checked = True Then
                    vendordesc = 1
                End If
                If Me.CheckBoxFunctionComment.Checked = True Then
                    fnccmt = 1
                End If
            End If

            If Me.ddReportFormat.SelectedValue = "SS1" Or Me.ddReportFormat.SelectedValue = "SS2" Or ddReportFormat.SelectedValue = "008" Or ddReportFormat.SelectedValue = "009" Or Me.ddReportFormat.SelectedValue = "QUR" Or Me.ddReportFormat.SelectedValue = "Infinity" Or Me.ddReportFormat.SelectedValue = "TAP" Or Me.ddReportFormat.SelectedValue = "TAP2" Then
                functionoption = "C"
                groupoption = "N"
                sortoption = "C"
                footercomment = 1
                printedDate = 1
                Me.cbCombineComps.Checked = False
                Me.ddSignature.SelectedValue = 1
            End If

            Dim EstimatePrint As AdvantageFramework.Database.Entities.EstimatePrintSetting = Nothing

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                EstimatePrint = AdvantageFramework.Database.Procedures.EstimatePrintSetting.LoadByEstimatePrintSettingUserID(DataContext, _Session.UserCode)
                If EstimatePrint IsNot Nothing Then
                    EstimatePrint.SelectBy = selectby
                    EstimatePrint.DateToPrint = printedDate
                    EstimatePrint.ShowTaxSeparately = showtax
                    EstimatePrint.IndicateTaxableFunctions = indicatetax
                    EstimatePrint.ShowCommissionSeparately = showcomm
                    EstimatePrint.IndicateCommissionFunctions = indicatecommmu
                    EstimatePrint.FunctionOption = functionoption
                    EstimatePrint.GroupOption = groupoption
                    EstimatePrint.SortOption = sortoption
                    EstimatePrint.InsideDescription = Me.txtInsideDesc.Text
                    EstimatePrint.OutsideDescription = Me.txtOutsideDesc.Text
                    EstimatePrint.IncludeEstimateComment = estimatecomment
                    EstimatePrint.IncludeEstimateComponentComment = estimatecompcomment
                    EstimatePrint.IncludeEstimateQuoteComment = quotecomment
                    EstimatePrint.IncludeEstimateRevisionComment = revisioncomment
                    EstimatePrint.IncludeEstimateFunctionComment = functioncomment
                    EstimatePrint.DefaultFooterComment = footercomment
                    EstimatePrint.IncludeClientReference = clientref
                    EstimatePrint.IncludeAccountExecutive = aename
                    EstimatePrint.IncludeSalesClass = salesclass
                    EstimatePrint.IncludeSpecifications = specs
                    EstimatePrint.IncludeJobQuantity = estimatequantity
                    EstimatePrint.IncludeContingency = includecont
                    EstimatePrint.SuppressZeroFunctions = suppresszero
                    EstimatePrint.LocationCode = locationid
                    EstimatePrint.LogoPath = locationpath
                    EstimatePrint.ReportFormat = Me.ddReportFormat.SelectedValue
                    EstimatePrint.IncludeNonBillable = includenonbill
                    EstimatePrint.PrintDivisionName = printdivname
                    EstimatePrint.PrintProductDescription = printprdname
                    EstimatePrint.IncludeQuantityHours = includeqtyhrs
                    EstimatePrint.ConsolidationOverride = override
                    EstimatePrint.SubtotalsOnly = subtotalsonly
                    EstimatePrint.IncludeCPU = includecpu
                    EstimatePrint.IncludeCPM = includecpm
                    EstimatePrint.ReportTitle = reporttitle
                    EstimatePrint.IncludeSuppliedByNotes = suppliedbynotes
                    EstimatePrint.ShowContingencySeparately = showcont
                    EstimatePrint.Signature = Me.ddSignature.SelectedValue
                    EstimatePrint.HideComponentDescription = hidecompdesc
                    EstimatePrint.HideRevision = hiderev
                    EstimatePrint.IncludeJobDueDate = jobduedate
                    EstimatePrint.UseEmployeeSignature = useempsig
                    EstimatePrint.ExcludeEmployeeTime = excludeemptime
                    EstimatePrint.ExcludeVendor = excludevendor
                    EstimatePrint.ExcludeIncomeOnly = excludeio
                    EstimatePrint.ExcludeSignatures = excludesignatures
                    EstimatePrint.IncludeCampaignSummary = cmpsummary
                    EstimatePrint.IncludeVendorDescription = vendordesc
                    EstimatePrint.ExcludeNonbillable = excludenbfunctions
                    EstimatePrint.CDPAddressOption = Me.rbCDPAddress.SelectedValue
                    EstimatePrint.IncludeRate = includerate
                    EstimatePrint.CombineComponents = combinecomps
                    EstimatePrint.PrintClientName = printclname
                    EstimatePrint.IncludeFunctionComment = fnccmt
                    EstimatePrint.PrintAdNumber = printadnumber
                    EstimatePrint.FileFormat = Me.ddlFormat.SelectedValue
                    EstimatePrint.PrintCustom = True
                    AdvantageFramework.Database.Procedures.EstimatePrintSetting.Update(DataContext, EstimatePrint)
                Else
                    EstimatePrint = New AdvantageFramework.Database.Entities.EstimatePrintSetting
                    EstimatePrint.DataContext = DataContext
                    EstimatePrint.UserID = _Session.UserCode
                    EstimatePrint.SelectBy = selectby
                    EstimatePrint.DateToPrint = printedDate
                    EstimatePrint.ShowTaxSeparately = showtax
                    EstimatePrint.IndicateTaxableFunctions = indicatetax
                    EstimatePrint.ShowCommissionSeparately = showcomm
                    EstimatePrint.IndicateCommissionFunctions = indicatecommmu
                    EstimatePrint.FunctionOption = functionoption
                    EstimatePrint.GroupOption = groupoption
                    EstimatePrint.SortOption = sortoption
                    EstimatePrint.InsideDescription = Me.txtInsideDesc.Text
                    EstimatePrint.OutsideDescription = Me.txtOutsideDesc.Text
                    EstimatePrint.IncludeEstimateComment = estimatecomment
                    EstimatePrint.IncludeEstimateComponentComment = estimatecompcomment
                    EstimatePrint.IncludeEstimateQuoteComment = quotecomment
                    EstimatePrint.IncludeEstimateRevisionComment = revisioncomment
                    EstimatePrint.IncludeEstimateFunctionComment = functioncomment
                    EstimatePrint.DefaultFooterComment = footercomment
                    EstimatePrint.IncludeClientReference = clientref
                    EstimatePrint.IncludeAccountExecutive = aename
                    EstimatePrint.IncludeSalesClass = salesclass
                    EstimatePrint.IncludeSpecifications = specs
                    EstimatePrint.IncludeJobQuantity = estimatequantity
                    EstimatePrint.IncludeContingency = includecont
                    EstimatePrint.SuppressZeroFunctions = suppresszero
                    EstimatePrint.LocationCode = locationid
                    EstimatePrint.LogoPath = locationpath
                    EstimatePrint.ReportFormat = Me.ddReportFormat.SelectedValue
                    EstimatePrint.IncludeNonBillable = includenonbill
                    EstimatePrint.PrintDivisionName = printdivname
                    EstimatePrint.PrintProductDescription = printprdname
                    EstimatePrint.IncludeQuantityHours = includeqtyhrs
                    EstimatePrint.ConsolidationOverride = override
                    EstimatePrint.SubtotalsOnly = subtotalsonly
                    EstimatePrint.IncludeCPU = includecpu
                    EstimatePrint.IncludeCPM = includecpm
                    EstimatePrint.ReportTitle = reporttitle
                    EstimatePrint.IncludeSuppliedByNotes = suppliedbynotes
                    EstimatePrint.ShowContingencySeparately = showcont
                    EstimatePrint.Signature = Me.ddSignature.SelectedValue
                    EstimatePrint.HideComponentDescription = hidecompdesc
                    EstimatePrint.HideRevision = hiderev
                    EstimatePrint.IncludeJobDueDate = jobduedate
                    EstimatePrint.UseEmployeeSignature = useempsig
                    EstimatePrint.ExcludeEmployeeTime = excludeemptime
                    EstimatePrint.ExcludeVendor = excludevendor
                    EstimatePrint.ExcludeIncomeOnly = excludeio
                    EstimatePrint.ExcludeSignatures = excludesignatures
                    EstimatePrint.IncludeCampaignSummary = cmpsummary
                    EstimatePrint.IncludeVendorDescription = vendordesc
                    EstimatePrint.ExcludeNonbillable = excludenbfunctions
                    EstimatePrint.CDPAddressOption = Me.rbCDPAddress.SelectedValue
                    EstimatePrint.IncludeRate = includerate
                    EstimatePrint.CombineComponents = combinecomps
                    EstimatePrint.PrintClientName = printclname
                    EstimatePrint.IncludeFunctionComment = fnccmt
                    EstimatePrint.PrintAdNumber = printadnumber
                    EstimatePrint.FileFormat = Me.ddlFormat.SelectedValue
                    EstimatePrint.PrintCustom = True
                    AdvantageFramework.Database.Procedures.EstimatePrintSetting.Insert(DataContext, EstimatePrint)
                End If

            End Using


            'Dim Errormessage As String = ""
            'If dr.HasRows = True Then
            '    save = oEstimating.UpdatePrintDef(Session("UserCode"), _
            '                                      selectby, printedDate, _
            '                                      showtax, _
            '                                      indicatetax, _
            '                                      showcomm, _
            '                                      indicatecommmu, _
            '                                      functionoption, _
            '                                      groupoption, _
            '                                      sortoption, _
            '                                      Me.txtInsideDesc.Text, _
            '                                      Me.txtOutsideDesc.Text, _
            '                                      estimatecomment, _
            '                                      estimatecompcomment, _
            '                                      quotecomment, _
            '                                      revisioncomment, _
            '                                      functioncomment, _
            '                                      footercomment, _
            '                                      clientref, _
            '                                      aename, _
            '                                      salesclass, _
            '                                      specs, _
            '                                      estimatequantity, _
            '                                      includecont, _
            '                                      suppresszero, _
            '                                      locationid, _
            '                                      locationpath, _
            '                                      Me.ddReportFormat.SelectedValue, _
            '                                      includenonbill, _
            '                                      printdivname, _
            '                                      printprdname, _
            '                                      includeqtyhrs, _
            '                                      override, _
            '                                      subtotalsonly, _
            '                                      includecpu, _
            '                                      includecpm, _
            '                                      reporttitle, _
            '                                      suppliedbynotes, _
            '                                      showcont, _
            '                                      Me.ddSignature.SelectedValue, _
            '                                      hidecompdesc, _
            '                                      hiderev, _
            '                                      jobduedate, _
            '                                      useempsig, _
            '                                      excludeemptime, _
            '                                      excludevendor, _
            '                                      excludeio,
            '                                      excludesignatures,
            '                                      cmpsummary,
            '                                      vendordesc,
            '                                      excludenbfunctions, Errormessage)
            'Else
            '    save = oEstimating.SavePrintDef(Session("UserCode"), _
            '                                      selectby, printedDate, _
            '                                      showtax, _
            '                                      indicatetax, _
            '                                      showcomm, _
            '                                      indicatecommmu, _
            '                                      functionoption, _
            '                                      groupoption, _
            '                                      sortoption, _
            '                                      Me.txtInsideDesc.Text, _
            '                                      Me.txtOutsideDesc.Text, _
            '                                      estimatecomment, _
            '                                      estimatecompcomment, _
            '                                      quotecomment, _
            '                                      revisioncomment, _
            '                                      functioncomment, _
            '                                      footercomment, _
            '                                      clientref, _
            '                                      aename, _
            '                                      salesclass, _
            '                                      specs, _
            '                                      estimatequantity, _
            '                                      includecont, _
            '                                      suppresszero, _
            '                                      locationid, _
            '                                      locationpath, _
            '                                      Me.ddReportFormat.SelectedValue, _
            '                                      includenonbill, _
            '                                      printdivname, _
            '                                      printprdname, _
            '                                      includeqtyhrs, _
            '                                      override, _
            '                                      subtotalsonly, _
            '                                      includecpu, _
            '                                      includecpm, _
            '                                      reporttitle, _
            '                                      suppliedbynotes, _
            '                                      showcont, _
            '                                      Me.ddSignature.SelectedValue, _
            '                                      hidecompdesc, _
            '                                      hiderev, _
            '                                      jobduedate, _
            '                                      useempsig, _
            '                                      excludeemptime, _
            '                                      excludevendor, _
            '                                      excludeio,
            '                                      excludesignatures,
            '                                      cmpsummary,
            '                                      vendordesc,
            '                                      excludenbfunctions, Errormessage)
            'End If

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "EstimatingPrint", "CDPAddress", "", Me.rbCDPAddress.SelectedValue)
            otask.setAppVars(Session("UserCode"), "EstimatingPrint", "IncludeRate", "", Me.cbIncludeRate.Checked)
            otask.setAppVars(Session("UserCode"), "EstimatingPrint", "CombineComps", "", Me.cbCombineComps.Checked)
            otask.setAppVars(Session("UserCode"), "EstimatingPrint", "FunctionComment", "", fnccmt)
            otask.setAppVars(Session("UserCode"), "EstimatingPrint", "PrintClientName", "", Me.cbPrintClientName.Checked)

            'If save = True Then
            Me.LoadSettings()
            'Else
            'Me.ShowMessage(Errormessage)
            'End If
        Catch ex As Exception
            Me.lbl_msg.Text = "SaveSettings err: " & ex.Message.ToString
        End Try
    End Sub

    Private Sub LoadDefaults()
        Try
            If Me.ddReportFormat.SelectedValue = "" Then
                'Me.cbSpecs.Checked = True
                'Me.cbSpecs.Enabled = False
                'Me.cbIncludeNonBillable.Checked = True
                Me.cbIncludeNonBillable.Enabled = False
            End If
            Me.ddlFormat.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("PDF"), CStr("1")))
            Me.ddlFormat.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("RTF"), CStr("5")))
            'Me.ddlFormat.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Excel"), CStr("2")))
            'Me.ddlReportType.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("HTML"), CStr("3")))
            'Me.ddlFormat.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Text"), CStr("4")))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ReportChanges()
        Try
            If Me.ddReportFormat.SelectedValue = "" Then
                'Me.cbSpecs.Checked = True
                'Me.cbSpecs.Enabled = False
                'Me.cbIncludeNonBillable.Checked = True
                Me.cbIncludeNonBillable.Enabled = False
                Me.cbIndicateTax.Enabled = True
                Me.cbIndicateCommMU.Enabled = True
                Me.cbEstimateComment.Enabled = True
                Me.cbEstimateCompComment.Enabled = True
                Me.cbQuoteComment.Enabled = True
                Me.cbRevisionComment.Enabled = True
                Me.cbFunctionComment.Enabled = True
                Me.cbEstimateQuantity.Enabled = True
                Me.cbIncludeQtyHrs.Enabled = True
                Me.rbRate.Enabled = True
                Me.rbNone.Enabled = True
                Me.rbTotalOnly.Enabled = True
                Me.rbFunctionHeadingTO.Enabled = True
                Me.rbPhase.Enabled = True
                Me.pnlExclude.Visible = False
                Me.PanelOtherOptions.Visible = False
                Me.cbPrintClientName.Enabled = True
                Me.cbPrintDivisionName.Enabled = True
                Me.cbPrintProductName.Enabled = True
                Me.cbClientReference.Enabled = True
                Me.cbAEName.Enabled = True
                Me.cbSalesClass.Enabled = True
                Me.cbJobDueDate.Enabled = True
                Me.cbAdNumber.Enabled = True
                Me.cbIncludeCPM.Enabled = True
                Me.cbIncludeCPU.Enabled = True
                If rbNone.Checked = True Then
                    Me.cbIncludeRate.Enabled = True
                End If
            End If
            If Me.ddReportFormat.SelectedValue = "002" Or Me.ddReportFormat.SelectedValue = "314" Then
                Me.cbIndicateTax.Enabled = False
                Me.cbIndicateTax.Checked = False
                Me.cbIndicateCommMU.Enabled = False
                Me.cbIndicateCommMU.Checked = False
                Me.cbQuoteComment.Enabled = False
                Me.cbQuoteComment.Checked = False
                Me.cbRevisionComment.Checked = False
                Me.cbRevisionComment.Enabled = False
                Me.cbFunctionComment.Enabled = False
                Me.cbFunctionComment.Checked = False
                Me.cbEstimateQuantity.Enabled = False
                Me.cbEstimateQuantity.Checked = False
                Me.cbIncludeQtyHrs.Enabled = False
                Me.cbIncludeRate.Enabled = False
                'Me.cbSpecs.Checked = False
                'Me.cbSpecs.Enabled = False
                Me.cbIncludeNonBillable.Checked = False
                Me.cbIncludeNonBillable.Enabled = False
                Me.rbRate.Enabled = False
                Me.rbNone.Enabled = False
                Me.rbRate.Checked = False
                Me.rbNone.Checked = False
                Me.rbFunctionHeadingTO.Enabled = False
                Me.rbFunctionHeadingTO.Checked = False
                Me.rbPhase.Enabled = False
                Me.rbPhase.Checked = False
                Me.pnlExclude.Visible = False
                Me.PanelOtherOptions.Visible = False
                Me.cbPrintClientName.Enabled = True
                Me.cbPrintDivisionName.Enabled = True
                Me.cbPrintProductName.Enabled = True
                Me.cbAdNumber.Enabled = True
                If Me.ddReportFormat.SelectedValue = "314" Then
                    Me.cbClientReference.Enabled = False
                    Me.cbAEName.Enabled = False
                    Me.cbSalesClass.Enabled = False
                    Me.cbJobDueDate.Enabled = False
                    Me.cbEstimateQuantity.Enabled = False
                    Me.rbConsolidationCode.Checked = True
                    Me.cbFunctionComment.Enabled = True
                    Me.cbAdNumber.Enabled = False
                End If
            End If
            If Me.ddReportFormat.SelectedValue = "003" Then
                Me.cbIndicateTax.Enabled = False
                Me.cbIndicateTax.Checked = False
                Me.cbIndicateCommMU.Enabled = False
                Me.cbIndicateCommMU.Checked = False
                Me.cbRevisionComment.Checked = False
                Me.cbRevisionComment.Enabled = False
                Me.cbIncludeQtyHrs.Enabled = False
                Me.cbIncludeRate.Enabled = False
                Me.cbIncludeNonBillable.Enabled = True
                'Me.cbSpecs.Checked = False
                'Me.cbSpecs.Enabled = False
                Me.cbQuoteComment.Enabled = True
                Me.cbFunctionComment.Enabled = True
                Me.cbEstimateQuantity.Enabled = True
                Me.rbRate.Enabled = False
                Me.rbNone.Enabled = False
                Me.rbRate.Checked = False
                Me.rbNone.Checked = False
                Me.rbFunctionHeadingTO.Enabled = False
                Me.rbFunctionHeadingTO.Checked = False
                Me.rbPhase.Enabled = False
                Me.rbPhase.Checked = False
                Me.pnlExclude.Visible = False
                Me.PanelOtherOptions.Visible = False
                Me.cbPrintClientName.Enabled = True
                Me.cbPrintDivisionName.Enabled = True
                Me.cbPrintProductName.Enabled = True
                Me.cbAdNumber.Enabled = False
                Me.cbIncludeCPM.Enabled = True
                Me.cbIncludeCPU.Enabled = True
            End If
            If Me.ddReportFormat.SelectedValue = "004" Then
                Me.cbIndicateTax.Enabled = False
                Me.cbIndicateTax.Checked = False
                Me.cbIndicateCommMU.Enabled = False
                Me.cbIndicateCommMU.Checked = False
                Me.cbRevisionComment.Checked = False
                Me.cbRevisionComment.Enabled = False
                Me.cbIncludeQtyHrs.Enabled = False
                Me.cbIncludeRate.Enabled = False
                Me.cbIncludeNonBillable.Enabled = True
                'Me.cbSpecs.Checked = False
                'Me.cbSpecs.Enabled = False
                Me.cbQuoteComment.Enabled = True
                Me.cbFunctionComment.Enabled = True
                Me.cbEstimateQuantity.Enabled = True
                Me.rbRate.Enabled = False
                Me.rbNone.Enabled = False
                Me.rbRate.Checked = False
                Me.rbNone.Checked = False
                Me.rbFunctionHeadingTO.Enabled = False
                Me.rbFunctionHeadingTO.Checked = False
                Me.rbPhase.Enabled = False
                Me.rbPhase.Checked = False
                Me.pnlExclude.Visible = False
                Me.PanelOtherOptions.Visible = False
                Me.cbPrintClientName.Enabled = True
                Me.cbPrintDivisionName.Enabled = True
                Me.cbPrintProductName.Enabled = True
                Me.cbAdNumber.Enabled = False
                Me.cbIncludeCPM.Enabled = True
                Me.cbIncludeCPU.Enabled = True
            End If
            If Me.ddReportFormat.SelectedValue = "005" Then
                Me.cbIndicateTax.Enabled = False
                Me.cbIndicateTax.Checked = False
                Me.cbIndicateCommMU.Enabled = False
                Me.cbIndicateCommMU.Checked = False
                Me.cbRevisionComment.Checked = False
                Me.cbRevisionComment.Enabled = False
                Me.cbIncludeQtyHrs.Enabled = False
                Me.cbIncludeRate.Enabled = False
                'Me.cbSpecs.Checked = False
                'Me.cbSpecs.Enabled = False
                Me.cbIncludeNonBillable.Checked = False
                Me.cbIncludeNonBillable.Enabled = False
                Me.cbQuoteComment.Enabled = True
                Me.cbFunctionComment.Enabled = True
                Me.cbEstimateQuantity.Enabled = True
                Me.rbRate.Enabled = False
                Me.rbNone.Enabled = False
                Me.rbRate.Checked = False
                Me.rbNone.Checked = False
                Me.rbFunctionHeadingTO.Enabled = False
                Me.rbFunctionHeadingTO.Checked = False
                Me.rbPhase.Enabled = False
                Me.rbPhase.Checked = False
                Me.pnlExclude.Visible = False
                Me.PanelOtherOptions.Visible = False
                Me.cbPrintClientName.Enabled = True
                Me.cbPrintDivisionName.Enabled = True
                Me.cbPrintProductName.Enabled = True
                Me.cbAdNumber.Enabled = False
                Me.cbIncludeCPM.Enabled = True
                Me.cbIncludeCPU.Enabled = True
            End If
            If Me.ddReportFormat.SelectedValue = "006" Then
                Me.cbIndicateTax.Enabled = False
                Me.cbIndicateTax.Checked = False
                Me.cbIndicateCommMU.Enabled = False
                Me.cbIndicateCommMU.Checked = False
                Me.cbRevisionComment.Checked = False
                Me.cbRevisionComment.Enabled = False
                Me.cbIncludeQtyHrs.Enabled = False
                Me.cbIncludeRate.Enabled = False
                'Me.cbSpecs.Checked = False
                'Me.cbSpecs.Enabled = False
                Me.cbIncludeNonBillable.Checked = False
                Me.cbIncludeNonBillable.Enabled = False
                Me.cbQuoteComment.Enabled = True
                Me.cbFunctionComment.Enabled = True
                Me.cbEstimateQuantity.Enabled = True
                Me.rbRate.Enabled = False
                Me.rbNone.Enabled = False
                Me.rbRate.Checked = False
                Me.rbNone.Checked = False
                Me.rbFunctionHeadingTO.Enabled = False
                Me.rbFunctionHeadingTO.Checked = False
                Me.rbPhase.Enabled = False
                Me.rbPhase.Checked = False
                Me.pnlExclude.Visible = False
                Me.PanelOtherOptions.Visible = False
                Me.cbPrintClientName.Enabled = True
                Me.cbPrintDivisionName.Enabled = True
                Me.cbPrintProductName.Enabled = True
                Me.cbAdNumber.Enabled = False
                Me.cbIncludeCPM.Enabled = True
                Me.cbIncludeCPU.Enabled = True
            End If
            If Me.ddReportFormat.SelectedValue = "007" Or Me.ddlFormat.SelectedValue = "313" Then
                Me.cbIndicateTax.Enabled = False
                Me.cbIndicateTax.Checked = False
                Me.cbIndicateCommMU.Enabled = False
                Me.cbIndicateCommMU.Checked = False
                Me.cbRevisionComment.Checked = False
                Me.cbRevisionComment.Enabled = False
                Me.cbIncludeQtyHrs.Enabled = False
                Me.cbIncludeRate.Enabled = False
                'Me.cbSpecs.Checked = False
                'Me.cbSpecs.Enabled = False
                Me.cbIncludeNonBillable.Checked = False
                Me.cbIncludeNonBillable.Enabled = False
                Me.cbQuoteComment.Enabled = True
                Me.cbFunctionComment.Enabled = True
                Me.cbEstimateQuantity.Enabled = True
                Me.rbRate.Enabled = False
                Me.rbNone.Enabled = False
                Me.rbRate.Checked = False
                Me.rbNone.Checked = False
                Me.rbFunctionHeadingTO.Enabled = False
                Me.rbFunctionHeadingTO.Checked = False
                Me.rbPhase.Enabled = False
                Me.pnlExclude.Visible = False
                Me.PanelOtherOptions.Visible = False
                Me.rbPhase.Checked = False
                Me.cbPrintClientName.Enabled = True
                Me.cbPrintDivisionName.Enabled = True
                Me.cbPrintProductName.Enabled = True
                Me.cbAdNumber.Enabled = False
                Me.cbIncludeCPM.Enabled = True
                Me.cbIncludeCPU.Enabled = True
            End If
            If Me.ddReportFormat.SelectedValue = "315" Then
                Me.cbIncludeNonBillable.Enabled = False
                Me.cbIndicateTax.Enabled = True
                Me.cbIndicateCommMU.Enabled = True
                Me.cbEstimateComment.Enabled = True
                Me.cbEstimateCompComment.Enabled = True
                Me.cbQuoteComment.Enabled = True
                Me.cbRevisionComment.Enabled = True
                Me.cbFunctionComment.Enabled = True
                Me.cbEstimateQuantity.Enabled = True
                Me.cbIncludeQtyHrs.Enabled = True
                Me.cbIncludeRate.Enabled = True
                Me.rbRate.Enabled = True
                Me.rbNone.Enabled = True
                Me.rbTotalOnly.Enabled = True
                Me.rbFunctionHeadingTO.Enabled = True
                Me.rbPhase.Enabled = True
                Me.pnlExclude.Visible = False
                Me.PanelOtherOptions.Visible = False
                Me.cbPrintClientName.Enabled = True
                Me.cbPrintDivisionName.Enabled = True
                Me.cbPrintProductName.Enabled = True
                Me.cbClientReference.Enabled = False
                Me.cbAEName.Enabled = False
                Me.cbSalesClass.Enabled = False
                Me.cbJobDueDate.Enabled = False
                Me.cbAdNumber.Enabled = False
                Me.cbIncludeCPM.Enabled = False
                Me.cbIncludeCPU.Enabled = False
            End If
            If Me.ddReportFormat.SelectedValue = "SS1" Or Me.ddReportFormat.SelectedValue = "SS2" Or Me.ddReportFormat.SelectedValue = "008" Or Me.ddReportFormat.SelectedValue = "009" Or Me.ddReportFormat.SelectedValue = "QUR" Or Me.ddReportFormat.SelectedValue = "TAP" Or Me.ddReportFormat.SelectedValue = "TAP2" Then
                Me.cbCombineComps.Checked = False
                Me.pnlOptions.Visible = False
                Me.Label5.Visible = False
                Me.Label7.Visible = False
                'Me.Label1.Visible = False
                Me.Label6.Visible = False
                Me.cbAdNumber.Enabled = False
                If Me.ddReportFormat.SelectedValue = "008" Or Me.ddReportFormat.SelectedValue = "009" Or Me.ddReportFormat.SelectedValue = "TAP" Or Me.ddReportFormat.SelectedValue = "TAP2" Then
                    Me.rbCDPAddress.Visible = True
                Else
                    Me.rbCDPAddress.Visible = False
                End If
                Me.ddSignature.Visible = False
                Me.CheckBoxExcludeSignatures.Visible = False
                'Me.txtReportTitle.Visible = False
                'Me.ddlFormat.SelectedValue = "1"
                'Me.ddlFormat.Visible = False
                If Me.ddReportFormat.SelectedValue = "QUR" Then
                    Me.pnlExclude.Visible = True
                Else
                    Me.pnlExclude.Visible = False
                End If
                If Me.ddReportFormat.SelectedValue = "TAP" Or Me.ddReportFormat.SelectedValue = "TAP2" Then
                    Me.PanelOtherOptions.Visible = True
                Else
                    Me.PanelOtherOptions.Visible = False
                End If
            ElseIf Me.ddReportFormat.SelectedValue = "Infinity" Then
                Me.PnlCheck.Visible = False
                Me.rbCDPAddress.Visible = False
                Me.ddSignature.Visible = False
                Me.CheckBoxExcludeSignatures.Visible = False
                Me.Label5.Visible = False
                Me.Label7.Visible = False
                Me.PanelOtherOptions.Visible = False
                Me.cbAdNumber.Enabled = False
                Me.ddlFormat.Visible = True
            ElseIf Me.ddReportFormat.SelectedValue = "BWD" Then
                Me.pnlOptions.Visible = True
                Me.rbCDPAddress.Visible = True
                Me.rbRate.Enabled = False
                Me.rbNone.Enabled = False
                Me.rbTotalOnly.Enabled = False
                Me.cbPrintClientName.Enabled = False
                Me.cbPrintDivisionName.Enabled = False
                Me.cbPrintProductName.Enabled = False
                Me.cbEstimateCompComment.Enabled = False
                'Me.cbQuoteComment.Enabled = False
                'Me.cbQuoteComment.Checked = False
                Me.cbRevisionComment.Enabled = True
                Me.cbFunctionComment.Enabled = True
                Me.cbSuppliedByNotes.Enabled = False
                Me.cbHideCompDesc.Enabled = False
                Me.cbHideRevision.Enabled = False
                Me.cbClientReference.Enabled = False
                Me.cbAEName.Enabled = False
                Me.cbSalesClass.Enabled = False
                Me.cbJobDueDate.Enabled = False
                Me.cbEstimateQuantity.Enabled = False
                Me.cbIncludeNonBillable.Enabled = False
                Me.cbSubtotalsOnly.Enabled = False
                Me.cbIncludeCPU.Enabled = False
                Me.cbIncludeCPM.Enabled = False
                Me.rbFunctionHeadingTO.Enabled = False
                Me.ddSignature.Items(6).Visible = True
                Me.CheckBoxExcludeSignatures.Visible = True
                Me.PnlCheck.Visible = True
                Me.ddSignature.Visible = True
                Me.CheckBoxExcludeSignatures.Visible = True
                Me.Label5.Visible = True
                Me.Label7.Visible = True
                Me.PanelOtherOptions.Visible = False
                Me.cbAdNumber.Enabled = False
                Me.ddlFormat.Visible = True
            ElseIf Me.ddReportFormat.SelectedValue = "BWD2" Then
                Me.pnlOptions.Visible = True
                Me.rbCDPAddress.Visible = True
                Me.rbRate.Enabled = False
                Me.rbNone.Enabled = False
                Me.rbTotalOnly.Enabled = False
                Me.cbPrintClientName.Enabled = False
                Me.cbPrintDivisionName.Enabled = False
                Me.cbPrintProductName.Enabled = False
                Me.cbEstimateCompComment.Enabled = False
                Me.cbQuoteComment.Enabled = True
                Me.cbRevisionComment.Enabled = False
                Me.cbFunctionComment.Enabled = False
                Me.cbFunctionComment.Checked = False
                Me.cbSuppliedByNotes.Enabled = False
                Me.cbHideCompDesc.Enabled = False
                Me.cbHideRevision.Enabled = False
                Me.cbClientReference.Enabled = False
                Me.cbAEName.Enabled = False
                Me.cbSalesClass.Enabled = False
                Me.cbJobDueDate.Enabled = False
                Me.cbEstimateQuantity.Enabled = False
                Me.cbIncludeNonBillable.Enabled = False
                Me.cbSubtotalsOnly.Enabled = False
                Me.cbIncludeCPU.Enabled = False
                Me.cbIncludeCPM.Enabled = False
                Me.rbFunctionHeadingTO.Enabled = False
                Me.ddSignature.Items(6).Visible = True
                ' Me.rbFunctionHeading.Checked = True
                Me.PnlCheck.Visible = True
                Me.ddSignature.Visible = True
                Me.CheckBoxExcludeSignatures.Visible = True
                Me.Label5.Visible = True
                Me.Label7.Visible = True
                Me.CheckBoxExcludeSignatures.Visible = True
                Me.PanelOtherOptions.Visible = False
                Me.cbAdNumber.Enabled = False
                Me.ddlFormat.Visible = True
            Else
                Me.rbCDPAddress.Enabled = True
                Me.pnlOptions.Visible = True
                Me.PnlCheck.Visible = True
                Me.Label5.Visible = True
                Me.Label7.Visible = True
                Me.Label1.Visible = True
                Me.Label6.Visible = True
                Me.rbCDPAddress.Visible = True
                Me.ddSignature.Visible = True
                'Me.txtReportTitle.Visible = True
                Me.ddlFormat.Visible = True
                Me.pnlExclude.Visible = False
                Me.ddSignature.Items(6).Visible = False
                If ddSignature.SelectedValue = "6" Then
                    Me.ddSignature.SelectedValue = "1"
                End If
                Me.CheckBoxExcludeSignatures.Visible = True
                Me.PanelOtherOptions.Visible = False
                Me.cbPrintClientName.Enabled = True
                Me.cbPrintDivisionName.Enabled = True
                Me.cbPrintProductName.Enabled = True
            End If
            If Me.cbCombineComps.Checked = True Then
                Me.cbHideRevision.InputAttributes.Add("disabled", "disabled")
                Me.cbHideCompDesc.InputAttributes.Add("disabled", "disabled")
                Me.cbIncludeRate.Checked = False
                Me.cbIncludeRate.Enabled = False
            Else
                Me.cbHideRevision.Enabled = True
                Me.cbHideCompDesc.Enabled = True
                If rbNone.Checked = True Then
                    Me.cbIncludeRate.Enabled = True
                End If
            End If

            If Me.ddReportFormat.SelectedValue = "" Then
                Me.ddSignature.FindItemByValue("8").Visible = True
            Else
                Me.ddSignature.FindItemByValue("8").Visible = False
            End If

            Dim EstimatePrint As AdvantageFramework.Database.Entities.EstimatePrintSetting = Nothing
            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                EstimatePrint = AdvantageFramework.Database.Procedures.EstimatePrintSetting.LoadByEstimatePrintSettingUserID(DataContext, _Session.UserCode)
                If EstimatePrint IsNot Nothing Then
                    If EstimatePrint.ExcludeEmployeeTime = 1 Then
                        Me.CheckBoxExcludeEmpTime.Checked = True
                        Me.CheckBoxEmp.Checked = True
                    End If
                    If EstimatePrint.ExcludeVendor Then
                        Me.CheckBoxExcludeVendor.Checked = True
                        Me.CheckBoxVen.Checked = True
                    End If
                    If EstimatePrint.ExcludeIncomeOnly = 1 Then
                        Me.CheckBoxExcludeIO.Checked = True
                        Me.CheckBoxIO.Checked = True
                    End If
                End If
            End Using
            'Dim dr As SqlDataReader
            'Dim oEstimating As New cEstimating(Session("ConnString"), Session("UserCode"))
            'dr = oEstimating.GetPrintDef(Session("UserCode"))
            'If dr.HasRows = True Then
            '    dr.Read()
            '    If dr("EXCL_EMP_TIME") = 1 Then
            '        Me.CheckBoxExcludeEmpTime.Checked = True
            '        Me.CheckBoxEmp.Checked = True
            '    End If
            '    If dr("EXCL_VENDOR") = 1 Then
            '        Me.CheckBoxExcludeVendor.Checked = True
            '        Me.CheckBoxVen.Checked = True
            '    End If
            '    If dr("EXCL_IO") = 1 Then
            '        Me.CheckBoxExcludeIO.Checked = True
            '        Me.CheckBoxIO.Checked = True
            '    End If
            '    dr.Close()
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarEstimatePrintCustom_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarEstimatePrintCustom.ButtonClick
        Select Case e.Item.Value
            Case "Print"

                Me.Print()

            Case "SendAlert"

                Me.SendAlert()

            Case "SendAssignment"

                Me.SendAlert(False, True)

            Case "SendEmail"

                Me.SendAlert(True, False)

            Case "Save"

                SaveSettings()

        End Select
    End Sub

    Private Sub cbUsePrintedDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbUsePrintedDate.CheckedChanged
        Try
            If Me.cbUsePrintedDate.Checked = True Then
                Me.pnlDate.Visible = True
            Else
                Me.pnlDate.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ddReportFormat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddReportFormat.SelectedIndexChanged
        Try
            Me.ReportChanges()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridEstQuote_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridEstQuote.ItemDataBound
        Try
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                Dim currentEstComp As Integer
                Dim item As Telerik.Web.UI.GridDataItem
                item = e.Item
                Dim hf As System.Web.UI.WebControls.HiddenField = e.Item.FindControl("hfEstimateComp")
                Dim chk As CheckBox = CType(item("ColumnClientSelect").Controls(0), CheckBox)
                currentEstComp = hf.Value
                If Me._From = "Est" Then
                    If EstCompNum = currentEstComp Then
                        e.Item.Selected = True
                    End If
                ElseIf Me._From = "EstQuote" Then
                    Dim currentquote As Integer = DataBinder.Eval(e.Item.DataItem, "QuoteNumber") 'CInt(e.Item.DataItem("QuoteNumber"))
                    If currentquote = Me.QuoteNum Then
                        e.Item.Selected = True
                    End If
                Else
                    If EstCompNum = currentEstComp Then
                        e.Item.Selected = True
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridEstQuote_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridEstQuote.NeedDataSource
        Try
            Dim est As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuoteList) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserID"))
                If Me._From = "Est" Then

                    EstimateQuotes = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuoteList)(String.Format("EXEC [dbo].[advsp_estimate_printing_quotes] {0}, {1}", Me.EstNum, 0)).ToList
                    Me.RadGridEstQuote.DataSource = EstimateQuotes 'est.GetInfoForEstimateCopy(EstNum)

                ElseIf Me._From = "EstQuote" Then

                    EstimateQuotes = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuoteList)(String.Format("EXEC [dbo].[advsp_estimate_printing_quotes] {0}, {1}", Me.EstNum, EstCompNum)).ToList
                    Me.RadGridEstQuote.DataSource = EstimateQuotes 'est.GetEstimateQuotes(EstNum, EstCompNum)

                Else

                    EstimateQuotes = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuoteList)(String.Format("EXEC [dbo].[advsp_estimate_printing_quotes] {0}, {1}", Me.EstNum, 0)).ToList
                    Me.RadGridEstQuote.DataSource = EstimateQuotes 'est.GetInfoForEstimateCopy(EstNum)

                End If

            End Using

            Me.SetGridSort("Comp")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetGridSort(ByVal StrSort As String)
        Try
            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression
            Select Case StrSort
                Case "Comp"
                    GrpExpr = Telerik.Web.UI.GridGroupByExpression.Parse("EstimateComponentNumber Component Group By EstimateComponentNumber")
                    With Me.RadGridEstQuote
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True
                        '.MasterTableView.GetColumn("colPHASE_DESC").Display = False
                    End With
                Case Else
                    Me.RadGridEstQuote.MasterTableView.GroupByExpressions.Clear()
            End Select
            'Session("EstimateGridSort") = StrSort
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbCombineComps_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCombineComps.CheckedChanged
        If Me.cbCombineComps.Checked = True Then
            Me.cbHideCompDesc.Enabled = False
            Me.cbHideRevision.Enabled = False
            Me.cbIncludeRate.Checked = False
            Me.cbIncludeRate.Enabled = False
        Else
            Me.cbHideCompDesc.Enabled = True
            Me.cbHideRevision.Enabled = True
            If rbNone.Checked = True Then
                Me.cbIncludeRate.Enabled = True
            End If
        End If
    End Sub

#End Region

#Region " New Filename "

    Private Function GetFilename(ByRef OriginalFilename As String, ByVal EmpCode As String, ByVal ReportType As AdvantageFramework.Reporting.ActiveReports.ReportName, Optional ByRef ErrorMessage As String = "") As Boolean
        Try
            Dim s As String = ""
            Dim ParsingError As Boolean = False

            s = Me.ParseEstimatingFilenameKey(EmpCode, ReportType, ParsingError)

            s = s.Replace(",", "").Replace("/", "").Replace("\", "").Replace(" ", "_")

            s = s.ToUpper()

            If ParsingError = False Then

                If s.Trim() <> "" Then OriginalFilename = s 'Change original to new
                ErrorMessage = ""
                Return True

            Else

                ErrorMessage = s
                Return False

            End If


        Catch ex As Exception

            ErrorMessage = ex.Message.ToString()
            Return False

        End Try
    End Function

    Private Function ParseEstimatingFilenameKey(ByVal EmpCode As String, ByVal ReportType As AdvantageFramework.Reporting.ActiveReports.ReportName, Optional ByRef [Error] As Boolean = False) As String
        'get est
        'if est has j/jc include, if not, use just client
        Dim s As String

        Dim EstString As String = ""
        Dim EstCompString As String = ""

        If Me.EstNum > 0 Then

            EstString = Me.EstNum.ToString().PadLeft(6, "0")

        End If


        If Me.EstCompNum > 0 Then

            EstCompString = "_" & Me.EstCompNum.ToString().PadLeft(2, "0")

        End If

        If Me.JobNum = 0 Or Me.JobCompNum = 0 Then

            Dim ClCode As String = ""
            Dim ClCodeString As String = ""

            If Me.EstNum > 0 Then

                Try

                    ClCode = SqlHelper.ExecuteScalar(Session("ConnString"), CommandType.Text, "SELECT ISNULL(CL_CODE,'') FROM ESTIMATE_LOG WITH(NOLOCK) WHERE ESTIMATE_NUMBER" & Me.EstNum.ToString() & ";").ToString()

                Catch ex As Exception

                    ClCode = ""

                End Try

            End If

            If ClCode <> "" Then

                ClCodeString = "_" & ClCode

            End If

            s = Me.ParseFilenameKey(EmpCode, "ESTIMATE" & ClCodeString & "_EST_" & EstString & EstCompString, ReportType, [Error])

        Else

            s = Me.ParseFilenameKey(EmpCode, "ESTIMATE_#ClientCode#_JOB_#JobNumber#_#ComponentNumber#" & "_EST_" & EstString & EstCompString, ReportType, [Error])

        End If

        Return s

    End Function

    Private Function ParseFilenameKey(ByVal EmpCode As String, ByVal KeyToParse As String, ByVal ReportType As AdvantageFramework.Reporting.ActiveReports.ReportName, Optional ByRef [Error] As Boolean = False) As String
        Try
            Dim Filename As String = ""

            Dim ObjectEmpCode As String = ""

            Dim JobDesc As String = ""
            Dim OfficeCode As String = ""
            Dim ClCode As String = ""
            Dim DivCode As String = ""
            Dim PrdCode As String = ""
            Dim OfficeName As String = ""
            Dim ClDesc As String = ""
            Dim DivDesc As String = ""
            Dim PrdDesc As String = ""
            Dim ScCode As String = ""
            Dim ScDesc As String = ""
            Dim CmpCode As String = ""
            Dim CmpIdentifier As String = ""

            Dim JobCompDesc As String = ""
            Dim CdpContactId As String = ""
            Dim PrdContCode As String = ""
            Dim ContFML As String = ""
            Dim NextAlertSeqNbr As String = ""
            Dim JobComponentEmpCode As String = ""

            Dim sb As New System.Text.StringBuilder
            Dim ar() As String

            ar = KeyToParse.Split(Delimiter)

            Dim t As New wvTimeSheet.cTimeSheet(Session("ConnString"))

            If Me.JobNum > 0 And Me.JobCompNum > 0 Then

                t.GetJobComponentInfo(Me.JobNum, Me.JobCompNum, JobDesc, JobCompDesc, OfficeCode, ClCode, DivCode, PrdCode, OfficeName, ClDesc, DivDesc, PrdDesc,
                                      ScCode, CmpCode, CmpIdentifier, CdpContactId, PrdContCode, ContFML, NextAlertSeqNbr, JobComponentEmpCode)

            ElseIf Me.JobNum > 0 And Me.JobCompNum = 0 Then

                t.GetJobInfo(Me.JobNum, JobDesc, OfficeCode, ClCode, DivCode, PrdCode, OfficeName, ClDesc, DivDesc, PrdDesc, ScCode, ScDesc, CmpCode, CmpIdentifier)

            End If

            For Each s As String In ar

                Select Case s

                    Case "OfficeCode"

                        sb.Append(OfficeCode)

                    Case "OfficeName"

                        sb.Append(OfficeName)

                    Case "ClientCode"

                        sb.Append(ClCode)

                    Case "DivisionCode"

                        sb.Append(DivCode)

                    Case "ProductCode"

                        sb.Append(PrdCode)

                    Case "ClientName"

                        sb.Append(ClDesc)

                    Case "DivisionName"

                        sb.Append(DivDesc)

                    Case "ProductName"

                        sb.Append(PrdDesc)

                    Case "JobNumber"

                        sb.Append(JobNum.ToString().PadLeft(6, "0"))

                    Case "ComponentNumber"

                        sb.Append(JobCompNum.ToString().PadLeft(2, "0"))

                    Case "JobDescription"

                        sb.Append(JobDesc)

                    Case "ComponentDescription"

                        sb.Append(JobCompDesc)

                    Case "CurrentDate"

                        sb.Append(Now.Year.ToString())
                        sb.Append(Now.Month.ToString())
                        sb.Append(Now.Day.ToString())

                    Case "CurrentTime"

                        sb.Append(Now.Hour.ToString())
                        sb.Append(Now.Minute.ToString())
                        sb.Append(Now.Minute.ToString())

                    Case "EmployeeCode"


                    Case Else 'Treat it as a literal

                        sb.Append(s)

                End Select

            Next

            [Error] = False
            Return sb.ToString()

        Catch ex As Exception

            [Error] = True
            Return ex.Message.ToString()

        End Try
    End Function

#End Region

#Region "  Form Event Handlers "

    Private Sub Estimate_PrintSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            If Not Me.IsPostBack And Not Me.IsCallback Then


            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region " Page "

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init

        LoGlo.PageCultureSet(Me.Page)

        If Not Request.QueryString("JobNum") Is Nothing AndAlso IsNumeric(Request.QueryString("JobNum")) Then
            JobNum = Request.QueryString("JobNum")
        End If
        If Not Request.QueryString("JobComp") Is Nothing AndAlso IsNumeric(Request.QueryString("JobComp")) Then
            JobCompNum = Request.QueryString("JobComp")
        End If
        If Not Request.QueryString("EstNum") Is Nothing AndAlso IsNumeric(Request.QueryString("EstNum")) Then
            EstNum = Request.QueryString("EstNum")
        End If
        If Not Request.QueryString("EstComp") Is Nothing AndAlso IsNumeric(Request.QueryString("EstComp")) Then
            EstCompNum = Request.QueryString("EstComp")
        End If
        If Not Request.QueryString("QuoteNum") Is Nothing AndAlso IsNumeric(Request.QueryString("QuoteNum")) Then
            QuoteNum = Request.QueryString("QuoteNum")
        End If
        If Not Request.QueryString("RevNum") Is Nothing AndAlso IsNumeric(Request.QueryString("RevNum")) Then
            RevNum = Request.QueryString("RevNum")
        End If

        If Me.CurrentQuerystring.JobNumber > 0 Then Me.JobNum = Me.CurrentQuerystring.JobNumber
        If Me.CurrentQuerystring.JobComponentNumber > 0 Then Me.JobCompNum = Me.CurrentQuerystring.JobComponentNumber
        If Me.CurrentQuerystring.EstimateNumber > 0 Then Me.EstNum = Me.CurrentQuerystring.EstimateNumber
        If Me.CurrentQuerystring.EstimateComponentNumber > 0 Then Me.EstCompNum = Me.CurrentQuerystring.EstimateComponentNumber
        If Me.CurrentQuerystring.EstimateQuoteNumber > 0 Then Me.QuoteNum = Me.CurrentQuerystring.EstimateQuoteNumber
        If Me.CurrentQuerystring.EstimateRevisionNumber > 0 Then Me.RevNum = Me.CurrentQuerystring.EstimateRevisionNumber

        Me._From = Me.CurrentQuerystring.GetValue("from")
        Me._SelectedQuoteNumbers = Me.CurrentQuerystring.GetValue("sel_quotes")
        Me._SelectedQuoteDescriptions = Me.CurrentQuerystring.GetValue("sel_quotes_desc")
        Me._PrintSendAll = Me.CurrentQuerystring.GetValue("print_all") = "True"

        If Me.CurrentQuerystring.IsJobDashboard = True Then

            Dim cpd As New AdvantageFramework.Web.Classes.ContentPageData

            If cpd.Load() = True Then

                If cpd.JobNumber > 0 Then Me.JobNum = cpd.JobNumber
                If cpd.JobComponentNumber > 0 Then Me.JobCompNum = cpd.JobComponentNumber
                If cpd.EstimateNumber > 0 Then Me.EstNum = cpd.EstimateNumber
                If cpd.EstimateComponentNumber > 0 Then Me.EstCompNum = cpd.EstimateComponentNumber

                Me._SelectedQuoteNumbers = cpd.EstimateSelectedQuoteNumbers
                Me._SelectedQuoteDescriptions = cpd.EstimateSelectedQuoteDescriptions
                'Me._PrintSendAll = cpd.EstimatePrintSendAll

            End If

        End If

        If Me._SelectedQuoteNumbers <> "" AndAlso Me._SelectedQuoteNumbers.EndsWith(",") = False Then

            Me._SelectedQuoteNumbers &= ","

            If Me._SelectedQuoteDescriptions <> "" AndAlso Me._SelectedQuoteDescriptions.EndsWith(",") = False Then
                Me._SelectedQuoteDescriptions &= ","
            End If

        ElseIf Me._SelectedQuoteNumbers = "" Then

            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuoteList) = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserID"))
                EstimateQuotes = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuoteList)(String.Format("EXEC [dbo].[advsp_estimate_printing_quotes] {0}, {1}", Me.EstNum, EstCompNum)).ToList
                If EstimateQuotes IsNot Nothing AndAlso EstimateQuotes.Count = 1 Then
                    Me._SelectedQuoteNumbers = "1,"
                    Me._SelectedQuoteDescriptions = EstimateQuotes(0).QuoteDesc & ","
                End If
            End Using

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim report As New cReports(_Session.ConnectionString)
            Dim drReport As SqlDataReader

            Me.RadDatePickerEstimate = Me.RadToolbarButtonDate.FindControl("RadDatePickerDate")
            Me.LoadEstimateData()

            If Not Me.IsPostBack And Not Me.IsCallback Then
                Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Estimating)
                LoadComboboxes()
                LoadGroupingOptions()
                LoadSignatureOptions()
                LoadStandardFormat()
                LoadPrintSettings()
                Me.FillLocationDropDown()
                Me.RadDatePickerPrintedDate.SelectedDate = cEmployee.TimeZoneToday
                Me.LoadSettings()
                LoadDefaults()
                Me.rbTotalOnly.Attributes.Add("onclick", "disableobject('" & Me.rbTotalOnly.ClientID & "','" & Me.cbIndicateTax.ClientID & "','" & Me.cbIndicateCommMU.ClientID & "','" & Me.rbNoneGroupby.ClientID & "','" & Me.rbFunctionType.ClientID & "','" & Me.rbFunctionHeading.ClientID & "','" & Me.rbInsideOutside.ClientID & "','" & Me.rbPhase.ClientID & "','" & Me.rbFunctionCodeSort.ClientID & "','" & Me.rbFunctionOrderSort.ClientID & "','" & Me.cbIncludeQtyHrs.ClientID & "','" & Me.txtInsideDesc.ClientID & "','" & Me.txtOutsideDesc.ClientID & "','" & Me.rbFunctionHeadingTO.ClientID & "');disableobjectRate('" & Me.rbTotalOnly.ClientID & "','" & Me.cbIncludeRate.ClientID & "');")
                Me.rbFunctionCode.Attributes.Add("onclick", "enableobject('" & Me.rbFunctionCode.ClientID & "','" & Me.cbIndicateTax.ClientID & "','" & Me.cbIndicateCommMU.ClientID & "','" & Me.rbNoneGroupby.ClientID & "','" & Me.rbFunctionType.ClientID & "','" & Me.rbFunctionHeading.ClientID & "','" & Me.rbInsideOutside.ClientID & "','" & Me.rbPhase.ClientID & "','" & Me.rbFunctionCodeSort.ClientID & "','" & Me.rbFunctionOrderSort.ClientID & "','" & Me.cbIncludeQtyHrs.ClientID & "','" & Me.txtInsideDesc.ClientID & "','" & Me.txtOutsideDesc.ClientID & "','" & Me.rbFunctionHeadingTO.ClientID & "');disableobjectRate('" & Me.rbFunctionCode.ClientID & "','" & Me.cbIncludeRate.ClientID & "');")
                Me.rbConsolidationCode.Attributes.Add("onclick", "enableobject('" & Me.rbConsolidationCode.ClientID & "','" & Me.cbIndicateTax.ClientID & "','" & Me.cbIndicateCommMU.ClientID & "','" & Me.rbNoneGroupby.ClientID & "','" & Me.rbFunctionType.ClientID & "','" & Me.rbFunctionHeading.ClientID & "','" & Me.rbInsideOutside.ClientID & "','" & Me.rbPhase.ClientID & "','" & Me.rbFunctionCodeSort.ClientID & "','" & Me.rbFunctionOrderSort.ClientID & "','" & Me.cbIncludeQtyHrs.ClientID & "','" & Me.txtInsideDesc.ClientID & "','" & Me.txtOutsideDesc.ClientID & "','" & Me.rbFunctionHeadingTO.ClientID & "');disableobjectRate('" & Me.rbConsolidationCode.ClientID & "','" & Me.cbIncludeRate.ClientID & "');")
                Me.rbRate.Attributes.Add("onclick", "enableobject('" & Me.rbRate.ClientID & "','" & Me.cbIndicateTax.ClientID & "','" & Me.cbIndicateCommMU.ClientID & "','" & Me.rbNoneGroupby.ClientID & "','" & Me.rbFunctionType.ClientID & "','" & Me.rbFunctionHeading.ClientID & "','" & Me.rbInsideOutside.ClientID & "','" & Me.rbPhase.ClientID & "','" & Me.rbFunctionCodeSort.ClientID & "','" & Me.rbFunctionOrderSort.ClientID & "','" & Me.cbIncludeQtyHrs.ClientID & "','" & Me.txtInsideDesc.ClientID & "','" & Me.txtOutsideDesc.ClientID & "','" & Me.rbFunctionHeadingTO.ClientID & "');disableobjectRate('" & Me.rbRate.ClientID & "','" & Me.cbIncludeRate.ClientID & "');")
                Me.rbNone.Attributes.Add("onclick", "enableobject('" & Me.rbNone.ClientID & "','" & Me.cbIndicateTax.ClientID & "','" & Me.cbIndicateCommMU.ClientID & "','" & Me.rbNoneGroupby.ClientID & "','" & Me.rbFunctionType.ClientID & "','" & Me.rbFunctionHeading.ClientID & "','" & Me.rbInsideOutside.ClientID & "','" & Me.rbPhase.ClientID & "','" & Me.rbFunctionCodeSort.ClientID & "','" & Me.rbFunctionOrderSort.ClientID & "','" & Me.cbIncludeQtyHrs.ClientID & "','" & Me.txtInsideDesc.ClientID & "','" & Me.txtOutsideDesc.ClientID & "','" & Me.rbFunctionHeadingTO.ClientID & "');enableobjectRate('" & Me.rbNone.ClientID & "','" & Me.cbIncludeRate.ClientID & "','" & Me.cbCombineComps.ClientID & "');")
                Me.rbInsideOutside.Attributes.Add("onclick", "enableobjectIO('" & Me.rbInsideOutside.ClientID & "','" & Me.txtInsideDesc.ClientID & "','" & Me.txtOutsideDesc.ClientID & "','" & Me.lblInsideDesc.ClientID & "','" & Me.lblOutsideDesc.ClientID & "','" & Me.cbSubtotalsOnly.ClientID & "','" & Me.rbFunctionOrderSort.ClientID & "','" & Me.rbFunctionCodeSort.ClientID & "');")
                Me.rbNoneGroupby.Attributes.Add("onclick", "enableobjectIO('" & Me.rbInsideOutside.ClientID & "','" & Me.txtInsideDesc.ClientID & "','" & Me.txtOutsideDesc.ClientID & "','" & Me.lblInsideDesc.ClientID & "','" & Me.lblOutsideDesc.ClientID & "','" & Me.cbSubtotalsOnly.ClientID & "','" & Me.rbFunctionOrderSort.ClientID & "','" & Me.rbFunctionCodeSort.ClientID & "');")
                Me.rbFunctionType.Attributes.Add("onclick", "enableobjectIO('" & Me.rbInsideOutside.ClientID & "','" & Me.txtInsideDesc.ClientID & "','" & Me.txtOutsideDesc.ClientID & "','" & Me.lblInsideDesc.ClientID & "','" & Me.lblOutsideDesc.ClientID & "','" & Me.cbSubtotalsOnly.ClientID & "','" & Me.rbFunctionOrderSort.ClientID & "','" & Me.rbFunctionCodeSort.ClientID & "');")
                Me.rbFunctionHeading.Attributes.Add("onclick", "enableobjectIO('" & Me.rbInsideOutside.ClientID & "','" & Me.txtInsideDesc.ClientID & "','" & Me.txtOutsideDesc.ClientID & "','" & Me.lblInsideDesc.ClientID & "','" & Me.lblOutsideDesc.ClientID & "','" & Me.cbSubtotalsOnly.ClientID & "','" & Me.rbFunctionOrderSort.ClientID & "','" & Me.rbFunctionCodeSort.ClientID & "');")
                Me.rbPhase.Attributes.Add("onclick", "enableobjectIO('" & Me.rbInsideOutside.ClientID & "','" & Me.txtInsideDesc.ClientID & "','" & Me.txtOutsideDesc.ClientID & "','" & Me.lblInsideDesc.ClientID & "','" & Me.lblOutsideDesc.ClientID & "','" & Me.cbSubtotalsOnly.ClientID & "','" & Me.rbFunctionOrderSort.ClientID & "','" & Me.rbFunctionCodeSort.ClientID & "');")
                Me.cbIncludeCont.Attributes.Add("onclick", "enableobjectCont('" & Me.cbIncludeCont.ClientID & "','" & Me.cbShowCont.ClientID & "');")
                Me.rbFunctionHeadingTO.Attributes.Add("onclick", "enableobjectIO('" & Me.rbInsideOutside.ClientID & "','" & Me.txtInsideDesc.ClientID & "','" & Me.txtOutsideDesc.ClientID & "','" & Me.lblInsideDesc.ClientID & "','" & Me.lblOutsideDesc.ClientID & "','" & Me.cbSubtotalsOnly.ClientID & "','" & Me.rbFunctionOrderSort.ClientID & "','" & Me.rbFunctionCodeSort.ClientID & "');enableobjectFH('" & Me.rbFunctionHeadingTO.ClientID & "','" & Me.cbSubtotalsOnly.ClientID & "');enableobjectFH('" & Me.rbFunctionHeadingTO.ClientID & "','" & Me.rbFunctionOrderSort.ClientID & "');enableobjectFH('" & Me.rbFunctionHeadingTO.ClientID & "','" & Me.rbFunctionCodeSort.ClientID & "');")
                'Me.cbCombineComps.Attributes.Add("onclick", "enableobjectFH('" & Me.cbCombineComps.ClientID & "','" & Me.cbHideCompDesc.ClientID & "');enableobjectFH('" & Me.cbCombineComps.ClientID & "','" & Me.cbHideRevision.ClientID & "');")
                Me.RadDatePickerEstimate.SelectedDate = cEmployee.TimeZoneToday
            End If

            If RadToolBarButtonClient.Checked Then
                _EstimateFormatType = Me.RadToolBarButtonClient.Value
            ElseIf RadToolBarButtonProduct.Checked Then
                _EstimateFormatType = Me.RadToolBarButtonProduct.Value
            ElseIf RadToolBarButtonAgency.Checked Then
                _EstimateFormatType = Me.RadToolBarButtonAgency.Value
            ElseIf RadToolBarButtonUser.Checked Then
                _EstimateFormatType = Me.RadToolBarButtonUser.Value
            ElseIf RadToolBarButtonOneTime.Checked Then
                _EstimateFormatType = Me.RadToolBarButtonOneTime.Value
            Else
                _EstimateFormatType = Me.RadToolBarButtonUser.Value
            End If
            Session("EstimatingPrintFormatType") = _EstimateFormatType

        Catch ex As Exception
            Me.lbl_msg.Text = "Page_load err: " & ex.Message.ToString
        End Try
        If Me.IsClientPortal = True Then

            Me.RadToolbarEstimatingPrint.FindItemByValue("SendAssignment").Visible = False

        End If

    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Dim EstimatePrint As AdvantageFramework.Database.Entities.EstimatePrintSetting = Nothing
        Dim custom As Boolean = False

        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
            EstimatePrint = AdvantageFramework.Database.Procedures.EstimatePrintSetting.LoadByEstimatePrintSettingUserID(DataContext, _Session.UserCode)
            If EstimatePrint IsNot Nothing Then
                custom = EstimatePrint.PrintCustom
            End If
        End Using

        If Not Me.IsPostBack And Not Me.IsCallback Then
            If custom Then
                Me.RadTabStripTaskEstimatePrint.FindTabByValue("1").Selected = True
                Me.RadPageViewCustom.Selected = True
            Else
                Me.RadTabStripTaskEstimatePrint.FindTabByValue("0").Selected = True
                Me.RadPageViewStandard.Selected = True
            End If
        End If

        Select Case Me.CurrentPageMode
            Case PageMode.Print

                If custom Then
                    Me.Print()
                Else
                    Me.StandardPrint()
                End If

                If Request.QueryString("Content") = "1" Then
                    Me.CloseThisWindowNew()
                Else
                    Me.CloseThisWindow()
                End If

            Case PageMode.SendAlert

                If custom Then
                    Me.SendAlert()
                Else
                    Me.StandardSendAlert()
                End If

                If Request.QueryString("Content") = "1" Or Request.QueryString("from") = "EstQuote" Or Request.QueryString("from") = "Est" Then
                    Me.CloseThisWindowNew()
                Else
                    Me.CloseThisWindow()
                End If

            Case PageMode.SendAssignment

                If custom Then
                    Me.SendAlert(False, True)
                Else
                    Me.StandardSendAlert(False, True)
                End If

                If Request.QueryString("Content") = "1" Or Request.QueryString("from") = "EstQuote" Or Request.QueryString("from") = "Est" Then
                    Me.CloseThisWindowNew()
                Else
                    Me.CloseThisWindow()
                End If

            Case PageMode.SendEmail

                If custom Then
                    Me.SendAlert(True, False)
                Else
                    Me.StandardSendAlert(True, False)
                End If

                If Request.QueryString("Content") = "1" Or Request.QueryString("from") = "EstQuote" Or Request.QueryString("from") = "Est" Then
                    Me.CloseThisWindowNew()
                Else
                    Me.CloseThisWindow()
                End If

            Case Else

        End Select
    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolbarEstimatingPrint_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolbarEstimatingPrint.ButtonClick
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))

            Select Case e.Item.Value
                Case "Print"

                    SavePrintSettings()
                    StandardPrint()

                Case "SendAlert"

                    Me.StandardSendAlert()

                Case "SendAssignment"

                    Me.StandardSendAlert(False, True)

                Case "SendEmail"

                    Me.StandardSendAlert(True, False)

                Case "Save"

                    SavePrintSettings()

                Case "ChangeDate"

                    UpdateEstimateDate()
                    LoadEstimateData()

                Case "Client"

                    _EstimateFormatType = "Client"

                    otask.setAppVars(Session("UserCode"), "EstimatingPrint", "StandardPrintFormat", "", "Client")

                    Me.RadComboBoxFormatType.SelectedIndex = 0
                    LoadGroupingOptions()
                    LoadSignatureOptions()
                    LoadPrintSettings()
                    RadToolBarButtonClientSave.Checked = True
                    RadToolBarButtonProductSave.Checked = False
                    RadToolBarButtonUserSave.Checked = False
                    RadToolBarButtonAgencySave.Checked = False
                    RadToolBarButtonClientSave.Visible = False
                    RadToolBarButtonProductSave.Visible = True
                    RadToolBarButtonUserSave.Visible = True
                    RadToolBarButtonAgencySave.Visible = True

                Case "Product"

                    _EstimateFormatType = "Product"

                    otask.setAppVars(Session("UserCode"), "EstimatingPrint", "StandardPrintFormat", "", "Product")

                    Me.RadComboBoxFormatType.SelectedIndex = 0
                    LoadGroupingOptions()
                    LoadSignatureOptions()
                    LoadPrintSettings()
                    RadToolBarButtonProductSave.Checked = True
                    RadToolBarButtonClientSave.Checked = False
                    RadToolBarButtonUserSave.Checked = False
                    RadToolBarButtonAgencySave.Checked = False
                    RadToolBarButtonProductSave.Visible = False
                    RadToolBarButtonClientSave.Visible = True
                    RadToolBarButtonUserSave.Visible = True
                    RadToolBarButtonAgencySave.Visible = True

                Case "User"

                    _EstimateFormatType = "User"

                    otask.setAppVars(Session("UserCode"), "EstimatingPrint", "StandardPrintFormat", "", "User")

                    Me.RadComboBoxFormatType.SelectedIndex = 0
                    LoadGroupingOptions()
                    LoadSignatureOptions()
                    LoadPrintSettings()
                    RadToolBarButtonUserSave.Checked = True
                    RadToolBarButtonProductSave.Checked = False
                    RadToolBarButtonClientSave.Checked = False
                    RadToolBarButtonAgencySave.Checked = False
                    RadToolBarButtonUserSave.Visible = False
                    RadToolBarButtonClientSave.Visible = True
                    RadToolBarButtonProductSave.Visible = True
                    RadToolBarButtonAgencySave.Visible = True

                Case "Agency"

                    _EstimateFormatType = "Agency"

                    otask.setAppVars(Session("UserCode"), "EstimatingPrint", "StandardPrintFormat", "", "Agency")

                    Me.RadComboBoxFormatType.SelectedIndex = 0
                    LoadGroupingOptions()
                    LoadSignatureOptions()
                    LoadPrintSettings()
                    RadToolBarButtonAgencySave.Checked = True
                    RadToolBarButtonUserSave.Checked = False
                    RadToolBarButtonProductSave.Checked = False
                    RadToolBarButtonClientSave.Checked = False
                    RadToolBarButtonAgencySave.Visible = False
                    RadToolBarButtonClientSave.Visible = True
                    RadToolBarButtonProductSave.Visible = True
                    RadToolBarButtonUserSave.Visible = True

                Case "OneTime"

                    _EstimateFormatType = "OneTime"

                    otask.setAppVars(Session("UserCode"), "EstimatingPrint", "StandardPrintFormat", "", "OneTime")

                    Me.RadComboBoxFormatType.SelectedIndex = 0
                    LoadGroupingOptions()
                    LoadSignatureOptions()
                    LoadPrintSettings()
                    RadToolBarButtonClientSave.Visible = True
                    RadToolBarButtonProductSave.Visible = True
                    RadToolBarButtonUserSave.Visible = True
                    RadToolBarButtonAgencySave.Visible = True
                    RadToolBarButtonAgencySave.Checked = False
                    RadToolBarButtonUserSave.Checked = False
                    RadToolBarButtonProductSave.Checked = False
                    RadToolBarButtonClientSave.Checked = False

            End Select

            Session("EstimatingPrintFormatType") = _EstimateFormatType

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadComboBoxFormatType_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxFormatType.SelectedIndexChanged
        Try
            Select Case e.Value

                Case "1"

                    If RadComboBoxPrintOption.SelectedValue = "F" And RadButtonOverrideConsolidation.Checked = False Then
                        Me.RadButtonIncludeRate.Checked = False
                        Me.RadButtonIncludeRate.Enabled = False
                        Me.RadButtonIncludeRatewithMarkup.Checked = False
                        Me.RadButtonIncludeRatewithMarkup.Enabled = False
                    Else
                        Me.RadButtonIncludeRate.Enabled = True
                        Me.RadButtonIncludeRatewithMarkup.Enabled = True
                    End If
                    Me.RadButtonIncludeQuantityHours.Enabled = True
                    Me.RadButtonIncludeQuantityHoursTotal.Enabled = True
                    Me.RadButtonDisplayHours.Enabled = True
                    Me.RadButtonDisplayQuantity.Enabled = True
                    Me.RadButtonIncludeNonBillableActuals.Enabled = True
                    Me.RadButtonRevisionComment.Enabled = True
                    Me.RadButtonIncludeAdNumber.Enabled = True
                    Me.RadButtonHideRevisionInfo.Enabled = True
                    Me.RadButtonQuoteComment.Enabled = True
                    Me.RadButtonFunctionComment.Enabled = True
                    Me.RadButtonSuppliedByNotes.Enabled = True

                Case "2"

                    Me.RadButtonIncludeRate.Checked = False
                    Me.RadButtonIncludeRate.Enabled = False
                    Me.RadButtonIncludeRatewithMarkup.Checked = False
                    Me.RadButtonIncludeRatewithMarkup.Enabled = False
                    Me.RadButtonIncludeQuantityHours.Checked = False
                    Me.RadButtonIncludeQuantityHours.Enabled = False
                    Me.RadButtonIncludeQuantityHoursTotal.Checked = False
                    Me.RadButtonIncludeQuantityHoursTotal.Enabled = False
                    Me.RadButtonDisplayQuantity.Checked = False
                    Me.RadButtonDisplayQuantity.Enabled = False
                    Me.RadButtonDisplayHours.Checked = False
                    Me.RadButtonDisplayHours.Enabled = False
                    Me.RadButtonIncludeNonBillableActuals.Checked = False
                    Me.RadButtonIncludeNonBillableActuals.Enabled = False
                    Me.RadButtonRevisionComment.Checked = False
                    Me.RadButtonRevisionComment.Enabled = False
                    Me.RadButtonIncludeAdNumber.Enabled = True
                    Me.RadButtonHideRevisionInfo.Checked = False
                    Me.RadButtonHideRevisionInfo.Enabled = False
                    Me.RadButtonQuoteComment.Checked = False
                    Me.RadButtonQuoteComment.Enabled = False
                    Me.RadButtonFunctionComment.Checked = False
                    Me.RadButtonFunctionComment.Enabled = False
                    Me.RadButtonSuppliedByNotes.Checked = False
                    Me.RadButtonSuppliedByNotes.Enabled = False
                    Me.RadComboBoxOption.Items.FindItemByValue("4").Remove()

                Case "3"

                    Me.RadButtonIncludeRate.Checked = False
                    Me.RadButtonIncludeRate.Enabled = False
                    Me.RadButtonIncludeRatewithMarkup.Checked = False
                    Me.RadButtonIncludeRatewithMarkup.Enabled = False
                    Me.RadButtonIncludeQuantityHours.Checked = False
                    Me.RadButtonIncludeQuantityHours.Enabled = False
                    Me.RadButtonIncludeQuantityHoursTotal.Checked = False
                    Me.RadButtonIncludeQuantityHoursTotal.Enabled = False
                    Me.RadButtonDisplayQuantity.Checked = False
                    Me.RadButtonDisplayQuantity.Enabled = False
                    Me.RadButtonDisplayHours.Checked = False
                    Me.RadButtonDisplayHours.Enabled = False
                    Me.RadButtonRevisionComment.Checked = False
                    Me.RadButtonRevisionComment.Enabled = False
                    Me.RadButtonIncludeAdNumber.Checked = False
                    Me.RadButtonIncludeAdNumber.Enabled = False
                    Me.RadButtonHideRevisionInfo.Enabled = True
                    Me.RadButtonQuoteComment.Checked = True
                    Me.RadButtonFunctionComment.Enabled = True
                    Me.RadButtonSuppliedByNotes.Enabled = True
                    Me.RadButtonIncludeNonBillableActuals.Enabled = True

                Case "4"

                    Me.RadButtonIncludeRate.Checked = False
                    Me.RadButtonIncludeRate.Enabled = False
                    Me.RadButtonIncludeRatewithMarkup.Checked = False
                    Me.RadButtonIncludeRatewithMarkup.Enabled = False
                    Me.RadButtonIncludeQuantityHours.Checked = False
                    Me.RadButtonIncludeQuantityHours.Enabled = False
                    Me.RadButtonIncludeQuantityHoursTotal.Checked = False
                    Me.RadButtonIncludeQuantityHoursTotal.Enabled = False
                    Me.RadButtonDisplayQuantity.Checked = False
                    Me.RadButtonDisplayQuantity.Enabled = False
                    Me.RadButtonDisplayHours.Checked = False
                    Me.RadButtonDisplayHours.Enabled = False
                    Me.RadButtonIncludeNonBillableActuals.Enabled = True
                    Me.RadButtonRevisionComment.Checked = False
                    Me.RadButtonRevisionComment.Enabled = False
                    Me.RadButtonIncludeAdNumber.Checked = False
                    Me.RadButtonIncludeAdNumber.Enabled = False
                    Me.RadButtonHideRevisionInfo.Enabled = True
                    Me.RadButtonQuoteComment.Checked = True
                    Me.RadButtonFunctionComment.Enabled = True
                    Me.RadButtonSuppliedByNotes.Enabled = True

                Case "5"

                    Me.RadButtonIncludeRate.Checked = False
                    Me.RadButtonIncludeRate.Enabled = False
                    Me.RadButtonIncludeRatewithMarkup.Checked = False
                    Me.RadButtonIncludeRatewithMarkup.Enabled = False
                    Me.RadButtonIncludeQuantityHours.Checked = False
                    Me.RadButtonIncludeQuantityHours.Enabled = False
                    Me.RadButtonIncludeQuantityHoursTotal.Checked = False
                    Me.RadButtonIncludeQuantityHoursTotal.Enabled = False
                    Me.RadButtonDisplayQuantity.Checked = False
                    Me.RadButtonDisplayQuantity.Enabled = False
                    Me.RadButtonDisplayHours.Checked = False
                    Me.RadButtonDisplayHours.Enabled = False
                    Me.RadButtonIncludeNonBillableActuals.Checked = False
                    Me.RadButtonIncludeNonBillableActuals.Enabled = False
                    Me.RadButtonRevisionComment.Checked = False
                    Me.RadButtonRevisionComment.Enabled = False
                    Me.RadButtonIncludeAdNumber.Checked = False
                    Me.RadButtonIncludeAdNumber.Enabled = False
                    Me.RadButtonHideRevisionInfo.Enabled = True
                    Me.RadButtonQuoteComment.Checked = True
                    Me.RadButtonFunctionComment.Enabled = True
                    Me.RadButtonSuppliedByNotes.Enabled = True

                Case "6"

                    Me.RadButtonIncludeRate.Checked = False
                    Me.RadButtonIncludeRate.Enabled = False
                    Me.RadButtonIncludeRatewithMarkup.Checked = False
                    Me.RadButtonIncludeRatewithMarkup.Enabled = False
                    Me.RadButtonIncludeQuantityHours.Checked = False
                    Me.RadButtonIncludeQuantityHours.Enabled = False
                    Me.RadButtonIncludeQuantityHoursTotal.Checked = False
                    Me.RadButtonIncludeQuantityHoursTotal.Enabled = False
                    Me.RadButtonDisplayQuantity.Checked = False
                    Me.RadButtonDisplayQuantity.Enabled = False
                    Me.RadButtonDisplayHours.Checked = False
                    Me.RadButtonDisplayHours.Enabled = False
                    Me.RadButtonIncludeNonBillableActuals.Checked = False
                    Me.RadButtonIncludeNonBillableActuals.Enabled = False
                    Me.RadButtonRevisionComment.Checked = False
                    Me.RadButtonRevisionComment.Enabled = False
                    Me.RadButtonIncludeAdNumber.Checked = False
                    Me.RadButtonIncludeAdNumber.Enabled = False
                    Me.RadButtonHideRevisionInfo.Enabled = True
                    Me.RadButtonQuoteComment.Checked = True
                    Me.RadButtonFunctionComment.Enabled = True
                    Me.RadButtonSuppliedByNotes.Enabled = True

                Case "7"

                    Me.RadButtonIncludeRate.Checked = False
                    Me.RadButtonIncludeRate.Enabled = False
                    Me.RadButtonIncludeRatewithMarkup.Checked = False
                    Me.RadButtonIncludeRatewithMarkup.Enabled = False
                    Me.RadButtonIncludeQuantityHours.Checked = False
                    Me.RadButtonIncludeQuantityHours.Enabled = False
                    Me.RadButtonIncludeQuantityHoursTotal.Checked = False
                    Me.RadButtonIncludeQuantityHoursTotal.Enabled = False
                    Me.RadButtonDisplayQuantity.Checked = False
                    Me.RadButtonDisplayQuantity.Enabled = False
                    Me.RadButtonDisplayHours.Checked = False
                    Me.RadButtonDisplayHours.Enabled = False
                    Me.RadButtonIncludeNonBillableActuals.Enabled = True
                    Me.RadButtonRevisionComment.Checked = False
                    Me.RadButtonRevisionComment.Enabled = False
                    Me.RadButtonIncludeAdNumber.Checked = False
                    Me.RadButtonIncludeAdNumber.Enabled = False
                    Me.RadButtonHideRevisionInfo.Enabled = True
                    Me.RadButtonQuoteComment.Checked = True
                    Me.RadButtonFunctionComment.Enabled = True
                    Me.RadButtonSuppliedByNotes.Enabled = True

            End Select

            LoadGroupingOptions()
            LoadSignatureOptions()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadComboBoxOption_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxOption.SelectedIndexChanged
        Try
            Select Case e.Value

                Case "1"

                    Me.RadTextBoxInsideDescription.Visible = False
                    Me.RadTextBoxOutsideDescription.Visible = False

                Case "2"

                    Me.RadTextBoxInsideDescription.Visible = False
                    Me.RadTextBoxOutsideDescription.Visible = False

                Case "3"

                    Me.RadTextBoxInsideDescription.Visible = False
                    Me.RadTextBoxOutsideDescription.Visible = False

                Case "4"

                    Me.RadTextBoxInsideDescription.Visible = False
                    Me.RadTextBoxOutsideDescription.Visible = False

                Case "5"

                    Me.RadTextBoxInsideDescription.Visible = True
                    Me.RadTextBoxOutsideDescription.Visible = True

                Case "6"

                    Me.RadTextBoxInsideDescription.Visible = False
                    Me.RadTextBoxOutsideDescription.Visible = False

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadComboBoxSummaryLevel_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxSummaryLevel.SelectedIndexChanged
        Try
            Select Case e.Value

                Case "0"

                    Me.RadButtonIncludeRate.Enabled = True
                    Me.RadButtonIncludeRatewithMarkup.Enabled = True
                    Me.RadButtonHideRevisionInfo.Enabled = True

                Case "2"

                    Me.RadButtonIncludeRate.Checked = False
                    Me.RadButtonIncludeRate.Enabled = False
                    Me.RadButtonIncludeRatewithMarkup.Checked = False
                    Me.RadButtonIncludeRatewithMarkup.Enabled = False
                    Me.RadButtonHideRevisionInfo.Checked = False
                    Me.RadButtonHideRevisionInfo.Enabled = False


            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadButtonIncludeContingency_CheckedChanged(sender As Object, e As EventArgs) Handles RadButtonIncludeContingency.CheckedChanged
        Try
            If RadButtonIncludeContingency.Checked Then
                Me.RadButtonShowContingencySeparately.Enabled = True
            Else
                Me.RadButtonShowContingencySeparately.Checked = False
                Me.RadButtonShowContingencySeparately.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadComboBoxPrintOption_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxPrintOption.SelectedIndexChanged
        Try
            Select Case e.Value

                Case "F"

                    If RadButtonOverrideConsolidation.Checked Then
                        'Me.RadButtonIncludeRate.Checked = True
                        Me.RadButtonIncludeRate.Enabled = True
                        Me.RadButtonIncludeRatewithMarkup.Enabled = True
                    Else
                        Me.RadButtonIncludeRate.Checked = False
                        Me.RadButtonIncludeRate.Enabled = False
                        Me.RadButtonIncludeRatewithMarkup.Checked = False
                        Me.RadButtonIncludeRatewithMarkup.Enabled = False
                    End If
                    

                Case "C"

                    Me.RadButtonIncludeRate.Checked = False
                    Me.RadButtonIncludeRate.Enabled = False
                    Me.RadButtonIncludeRatewithMarkup.Checked = False
                    Me.RadButtonIncludeRatewithMarkup.Enabled = False

                Case "T"

                    'Me.RadButtonIncludeRate.Checked = True
                    Me.RadButtonIncludeRate.Enabled = True
                    Me.RadButtonIncludeRatewithMarkup.Enabled = True

                Case "R"

                    'Me.RadButtonIncludeRate.Checked = True
                    Me.RadButtonIncludeRate.Enabled = True
                    Me.RadButtonIncludeRatewithMarkup.Enabled = True
                    Me.RadButtonIncludeRatewithMarkup.Checked = False

                Case "N"

                    'Me.RadButtonIncludeRate.Checked = True
                    Me.RadButtonIncludeRate.Enabled = True
                    Me.RadButtonIncludeRatewithMarkup.Enabled = True

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadComboBoxAddressBlock_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxAddressBlock.SelectedIndexChanged
        Try
            Select Case e.Value

                Case "Contact"

                    If Me.RadComboBoxContactType.SelectedValue = "1" Then
                        Me.RadComboBoxContactType.SelectedValue = "0"
                    End If

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadButtonOverrideConsolidation_CheckedChanged(sender As Object, e As EventArgs) Handles RadButtonOverrideConsolidation.CheckedChanged
        Try
            If RadComboBoxPrintOption.SelectedValue = "F" And RadButtonOverrideConsolidation.Checked = False Then
                Me.RadButtonIncludeRate.Checked = False
                Me.RadButtonIncludeRate.Enabled = False
                Me.RadButtonIncludeRatewithMarkup.Checked = False
                Me.RadButtonIncludeRatewithMarkup.Enabled = False
            Else
                Me.RadButtonIncludeRate.Enabled = True
                Me.RadButtonIncludeRatewithMarkup.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadButtonUseLocationPrintOptions_CheckedChanged(sender As Object, e As EventArgs) Handles RadButtonUseLocationPrintOptions.CheckedChanged
        If RadButtonUseLocationPrintOptions.Checked = False Then
            Me.RadComboBoxLocation.SelectedValue = ""
            Me.RadComboBoxLocation.Enabled = False
        Else
            Me.RadComboBoxLocation.Enabled = True
        End If
    End Sub

    Private Sub RadButtonIncludeQuantityHours_CheckedChanged(sender As Object, e As EventArgs) Handles RadButtonIncludeQuantityHours.CheckedChanged
        Try
            If RadButtonIncludeQuantityHours.Checked Then
                Me.RadButtonIncludeQuantityHoursTotal.Enabled = True
            Else
                Me.RadButtonIncludeQuantityHoursTotal.Checked = False
                Me.RadButtonIncludeQuantityHoursTotal.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadButtonDisplayHours_CheckedChanged(sender As Object, e As EventArgs) Handles RadButtonDisplayHours.CheckedChanged
        If RadButtonDisplayHours.Checked Then
            RadButtonDisplayQuantity.Checked = False
        End If
    End Sub

    Private Sub RadButtonDisplayQuantity_CheckedChanged(sender As Object, e As EventArgs) Handles RadButtonDisplayQuantity.CheckedChanged
        If RadButtonDisplayQuantity.Checked Then
            RadButtonDisplayHours.Checked = False
        End If
    End Sub

    Private Sub RadButtonIncludeRatewithMarkup_CheckedChanged(sender As Object, e As EventArgs) Handles RadButtonIncludeRatewithMarkup.CheckedChanged
        If RadButtonIncludeRatewithMarkup.Checked Then
            RadButtonIncludeRate.Checked = False
        End If
    End Sub

    Private Sub RadButtonIncludeRate_CheckedChanged(sender As Object, e As EventArgs) Handles RadButtonIncludeRate.CheckedChanged
        If RadButtonIncludeRate.Checked Then
            RadButtonIncludeRatewithMarkup.Checked = False
        End If
    End Sub

#End Region

#End Region

End Class


