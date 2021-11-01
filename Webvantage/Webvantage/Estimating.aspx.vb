Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports AdvantageFramework.AlertSystem.Classes

Partial Public Class Estimating
    Inherits Webvantage.BaseChildPage

#Region " Variables and Properties "

    Public JobNum As Integer = 0
    Public JobComp As Integer = 0
    Public EstNum As Integer = 0
    Public EstComp As Integer = 0

    Public StartDate As String
    Public DueDate As String
    Public RowCount As Integer
    Private RowIncrement As Integer
    Private ReloadMe As Boolean = False
    Private DelEstimate As Boolean = False
    Private DelQuote As Boolean = False
    Private DelComp As Boolean = False
    Private CameFromJobTemplate As Boolean = False
    Private CameFromPV As Boolean = False

    Protected WithEvents PrintSendAllCheckbox As CheckBox

    Public ReadOnly Property DataSource() As DataTable
        Get
            Try
                Dim res As Object = Me.Session("_ds")
                If res Is Nothing Then
                    Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                    If IsNumeric(Me.TxtJobNum.Text) Then
                        JobNum = CType(Me.TxtJobNum.Text, Integer)
                    End If
                    If IsNumeric(Me.TxtJobCompNum.Text) Then
                        JobComp = CType(Me.TxtJobCompNum.Text, Integer)
                    End If
                    If JobNum > 0 And JobComp > 0 Then
                        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
                        If myVal.ValidateJobCompIsViewable(Session("UserCode"), JobNum, JobComp) = True Then
                            Dim z As Integer = oTrafficSchedule.CheckExistsClosed(Me.TxtJobNum.Text, Me.TxtJobCompNum.Text)
                            Select Case z
                                Case 0, -2 '0=open, -2=completed
                                    'Me.Session("_ds") = oTrafficSchedule.GetScheduleTasks(Me.TxtJobNum.Text, Me.TxtJobCompNum.Text, Me.DropSort.SelectedValue, CStr(Session("UserCode")), "", "", "", True, False, False)
                                Case -1
                                    MiscFN.ResponseRedirect(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Create?JobNumber=" & Me.TxtJobNum.Text & "&JobComponentNumber=" & Me.TxtJobCompNum.Text)
                            End Select
                        End If
                    End If
                End If
                Dim dt As DataTable = DirectCast(Me.Session("_ds"), DataTable)
                RowCount = dt.Rows.Count
                Return dt
            Catch ex As Exception
                BlankDT()
            End Try
        End Get
    End Property
    Private Function BlankDT() As DataTable
        Dim dt As New DataTable
        Return dt
    End Function
#End Region

#Region " Page Functions "

    Private Sub EnableBackToJobTemplate(ByVal IsEnabled As Boolean)

        IsEnabled = False

        Me.TxtClientCode.Enabled = Not IsEnabled
        Me.TxtClientDescription.Enabled = Not IsEnabled
        Me.TxtDivisionCode.Enabled = Not IsEnabled
        Me.TxtDivisionDescription.Enabled = Not IsEnabled
        Me.TxtProductCode.Enabled = Not IsEnabled
        Me.TxtProductDescription.Enabled = Not IsEnabled
        Me.TxtJobNum.Enabled = Not IsEnabled
        Me.TxtJobDescription.Enabled = Not IsEnabled
        Me.TxtJobCompNum.Enabled = Not IsEnabled
        Me.TxtJobCompDescription.Enabled = Not IsEnabled
        Me.TxtEstimate.Enabled = Not IsEnabled
        Me.TxtEstimateDescription.Enabled = Not IsEnabled
        Me.TxtEstimateComponent.Enabled = Not IsEnabled
        Me.TxtEstimateComponentDescription.Enabled = Not IsEnabled

    End Sub

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Estimating)
        Me.PrintSendAllCheckbox = CType(Me.RadToolbarEstimate.FindItemByValue("RadToolBarButtonPrintSendAllComponents").FindControl("CheckBoxPrintSendAllComponents"), CheckBox)
        Me.RadToolbarEstimate.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

        Me.SetOldQuerystringVariables()

        'Clean up old querystring names by letting clean qs class override
        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.JobNumber > 0 Then

            Me.JobNum = qs.JobNumber
            Me.TxtJobNum.Text = Me.JobNum

        End If
        If qs.JobComponentNumber > 0 Then

            Me.JobComp = qs.JobComponentNumber
            Me.TxtJobCompNum.Text = Me.JobComp

        End If
        If Me.JobNum > 0 AndAlso Me.JobComp > 0 Then

            Me.MyUnityContextMenu.JobNumber = Me.JobNum
            Me.MyUnityContextMenu.JobComponentNumber = Me.JobComp

        End If
        If qs.EstimateNumber > 0 Then

            Me.EstNum = qs.EstimateNumber
            Me.TxtEstimate.Text = EstNum

        End If
        If qs.EstimateComponentNumber > 0 Then

            Me.EstComp = qs.EstimateComponentNumber
            Me.TxtEstimateComponent.Text = Me.EstComp

        End If

        If qs.IsJobDashboard = True Then

            Me.RadToolbarEstimate.FindItemByValue("NewEstimate").Visible = False
            Me.RadToolbarEstimate.FindItemByText("Print/Send2").Visible = False
            Me.RadToolbarEstimate.FindItemByValue("PrintSendSeparator").Visible = False
            Me.RadToolbarEstimate.FindItemByValue("Alerts").Visible = False
            Me.RadToolbarEstimate.FindItemByValue("CreateJob").Visible = False
            Me.RadToolbarEstimate.FindItemByValue("SeparatorJob").Visible = False
            Me.RadToolbarEstimate.FindItemByValue("Notify").Visible = False
            Me.RadToolbarEstimate.FindItemByValue("Search").Visible = False
            Me.RadToolbarEstimate.FindItemByValue("SeparatorSearch").Visible = False
            Me.RadToolbarEstimate.FindItemByValue("Bookmark").Visible = False
            Me.RadToolbarEstimate.FindItemByValue("RemoveJob").Visible = False

            AdvantageFramework.Web.Presentation.Controls.DivHide(Me.divCDP)
            AdvantageFramework.Web.Presentation.Controls.DivHide(Me.divJob)
            AdvantageFramework.Web.Presentation.Controls.DivHide(Me.divComponent)

        Else



        End If

        Me.CollapsablePanelComments.Collapsed = True
        Me.CollapsablePanelCommentsFooter.Collapsed = True

        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim ds As DataSet
        Dim approved As Boolean = False
        ds = est.GetEstimateQuotes(Me.EstNum, Me.EstComp)
        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                If ds.Tables(0).Rows(i)(10).ToString() <> "" Or ds.Tables(0).Rows(i)(11).ToString() <> "" Then
                    approved = True
                End If
            Next
        End If
        If approved = True Then
            Me.RadToolbarEstimate.FindItemByValue("RemoveJob").Visible = False
        Else
            Me.RadToolbarEstimate.FindItemByValue("RemoveJob").Visible = True
        End If

    End Sub
    Private Sub SetOldQuerystringVariables()

        Try

            If Not Me.CurrentQuerystring.GetValue("JT") = Nothing Then

                If Me.CurrentQuerystring.GetValue("JT") = "1" And Me.CurrentQuerystring.GetValue("newEst") <> "new" Then

                    CameFromJobTemplate = True

                Else

                    CameFromJobTemplate = False

                End If
            End If
        Catch ex As Exception

            CameFromJobTemplate = False

        End Try

        EnableBackToJobTemplate(CameFromJobTemplate)

        Try
            If Session("FromWindow") = "ProjectView" Then
                CameFromPV = True
            Else
                CameFromPV = False
            End If
        Catch ex As Exception
            CameFromPV = False
        End Try
        EnableBackToJobTemplate(CameFromPV)

        If IsNumeric(Me.TxtJobNum.Text) Then

            JobNum = CType(Me.TxtJobNum.Text, Integer)

        Else
            'querystring override:
            If IsNumeric(Me.CurrentQuerystring.GetValue("JobNum")) Then

                JobNum = Me.CurrentQuerystring.GetValue("JobNum")
                Me.TxtJobNum.Text = JobNum
            Else

                Me.TxtJobNum.Text = ""

            End If
        End If
        If IsNumeric(Me.TxtJobCompNum.Text) Then

            JobComp = CType(Me.TxtJobCompNum.Text, Integer)

        Else
            'querystring override:
            If IsNumeric(Me.CurrentQuerystring.GetValue("JobComp")) Then

                JobComp = Me.CurrentQuerystring.GetValue("JobComp")
                Me.TxtJobCompNum.Text = JobComp

            Else

                Me.TxtJobCompNum.Text = ""

            End If

        End If
        If IsNumeric(Me.TxtEstimate.Text) Then

            EstNum = CType(Me.TxtEstimate.Text, Integer)

        Else
            'querystring override:
            If IsNumeric(Me.CurrentQuerystring.GetValue("EstNum")) Then

                EstNum = Me.CurrentQuerystring.GetValue("EstNum")
                Me.TxtEstimate.Text = EstNum

            Else
                If Session("FromWindow") = "ProjectView" Then

                    Me.RefreshGrid()

                Else

                    Me.TxtEstimate.Text = ""

                End If

            End If

        End If
        If IsNumeric(Me.TxtEstimateComponent.Text) Then

            EstComp = CType(Me.TxtEstimateComponent.Text, Integer)

        Else
            'querystring override:
            If IsNumeric(Me.CurrentQuerystring.GetValue("EstComp")) Then

                EstComp = Me.CurrentQuerystring.GetValue("EstComp")
                Me.TxtEstimateComponent.Text = EstComp

            Else

                Me.TxtEstimateComponent.Text = ""

            End If

        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then

            If (EstNum > 0 And EstComp > 0) OrElse (JobNum > 0 And JobComp > 0) Then

                Me.GetEstimateData(Me.EstNum, Me.EstComp, Me.JobNum, Me.JobComp)

            Else

                Me.Session("_ds") = Nothing

            End If

            LoadLookups()
            EnableToolbarButtons(DataLoaded)

            If Me.CurrentQuerystring.GetValue("From") = "VenQte" Then

                Me.PanelVendorRequest.Visible = True
                Me.PanelEstimateQuote.Visible = False

            Else

                Me.PanelVendorRequest.Visible = False
                Me.PanelEstimateQuote.Visible = True

            End If


        Else
            Select Case Me.EventArgument
                Case "Refresh"

                    Me.GetEstimateData(Me.EstNum, Me.EstComp, Me.JobNum, Me.JobComp)
                    Me.RefreshGrid()

                Case "SpecsEst"

                    Me.SaveAll()
                    Me.RefreshGrid()

                    If Not Session("EstImportSpecText") Is Nothing Then

                        If Session("EstImportSpecText") <> "" Then

                            Me.RadEditorEstimateComment.Text = Session("EstImportSpecText")
                            Me.CollapsablePanelComments.Collapsed = False
                            Session("EstImportSpecText") = Nothing

                        End If

                    End If

                Case "SpecsComp"

                    Me.SaveAll()
                    Me.RefreshGrid()

                    If Not Session("EstImportSpecText") Is Nothing Then

                        If Session("EstImportSpecText") <> "" Then

                            Me.RadEditorComponentComment.Text = Session("EstImportSpecText")
                            Me.CollapsablePanelComments.Collapsed = False
                            Session("EstImportSpecText") = Nothing

                        End If

                    End If

                Case "SaveAll"

                    Try

                        Me.SaveAll()
                        Me.GetEstimateData(Me.EstNum, Me.EstComp, Me.JobNum, Me.JobComp)

                    Catch ex As Exception
                    End Try
            End Select

            'If Me.EventArgument.Contains("RowClick") = True Then

            Me.SetContentPageData()

            'End If

        End If

        'Clear off sessions from quote page
        Try

            If Not Me.IsPostBack Then

                Session("DT_EST_QUOTE_FNC") = Nothing
                Session("EstimateGridSort") = Nothing

            End If
        Catch ex As Exception
        End Try

        Me.CheckUserRights()

        If Not IsPostBack And Not IsCallback Then

            Dim v As New cValidations(Session("ConnString"))
            Dim t As New cTimeSheet(Session("ConnString"))
            Dim c, d, p, s As String

            c = Me.TxtClientCode.Text.Trim()
            d = Me.TxtDivisionCode.Text.Trim()
            p = Me.TxtProductCode.Text.Trim()

            If JobNum > 0 And JobComp > 0 Then

                t.GetJobComponentInfo(JobNum, JobComp, , , , c, d, p)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AdvantageFramework.ProjectManagement.LoadJobTemplateLabelsByJobComponent(DbContext, Me.JobNum, Me.JobComp, Nothing, Nothing, Nothing,
                                                                                              Nothing, Nothing, Me.LabelSalesClass.Text, Nothing, Nothing)

                    Me.LabelSalesClass.Text &= ":"
                    Me.HlSalesClass.Text = Me.LabelSalesClass.Text

                End Using

            End If

            If v.ValidateCDPIsViewable(c, d, p, 0, 0, s) = False Then

                If s.Trim() <> "" Then

                    Me.ShowMessage(s)
                    Me.CloseThisWindow()
                    Exit Sub

                End If

            End If

        End If

        If Me.IsClientPortal = True Then

            Me.RadToolbarEstimate.FindItemByValue("SendAssignment").Visible = False

        End If

        If JobNum <= 0 Then
            Me.Title = "E " & Me.EstNum.ToString().PadLeft(6, "0") & "-" & Me.EstComp.ToString().PadLeft(2, "0") & " - " & Me.TxtEstimateDescription.Text
        End If

    End Sub

    Private Function ResetForm()

        Me.TxtClientCode.Text = ""
        Me.TxtClientDescription.Text = ""
        Me.TxtDivisionCode.Text = ""
        Me.TxtDivisionDescription.Text = ""
        Me.TxtProductCode.Text = ""
        Me.TxtProductDescription.Text = ""
        Me.TxtJobNum.Text = ""
        Me.TxtJobDescription.Text = ""
        Me.TxtJobCompNum.Text = ""
        Me.TxtJobCompDescription.Text = ""
        Me.TxtEstimate.Text = ""
        Me.TxtEstimateComponent.Text = ""
        Me.TxtEstimateDescription.Text = ""
        Me.TxtEstimateComponentDescription.Text = ""
        Me.TxtSalesClassCode.Text = ""
        Me.TxtSalesClassDescription.Text = ""
        Me.TxtCampaignCode.Text = ""
        Me.TxtCampaignDescription.Text = ""
        Me.TxtContactCode.Text = ""
        Me.TxtContactDescription.Text = ""
        Me.txtMarkupPercent.Text = ""
        Me.TxtClientRef.Text = ""
        Me.RadEditorComponentComment.Content = ""
        Me.RadEditorEstimateComment.Content = ""
        'Me.rbEstimate.Visible = True
        'Me.rbJob.Visible = True

        JobNum = 0
        JobComp = 0
        EstNum = 0
        EstComp = 0
        StartDate = ""
        DueDate = ""
        RowCount = 0

        Me.Session("_ds") = Nothing
        Me.TxtEstimate.Focus()
        Me.rbEstimate.Checked = True
        'Me.rbJob.Checked = False
        'If Me.rbEstimate.Checked = True Then
        '    Me.HlJob.Enabled = False
        '    Me.HlComponent.Enabled = False
        '    Me.HlJob.Attributes.Add("onclick", "")
        '    Me.HlComponent.Attributes.Add("onclick", "")
        '    Me.TxtJobNum.Enabled = False
        '    Me.TxtJobCompNum.Enabled = False
        '    Me.HlEstimate.Enabled = True
        '    Me.HlEstimateComponent.Enabled = True
        '    Me.HlEstimate.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatejob&type=estimate&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value);return false;")
        '    Me.HlEstimateComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatejob&type=estimatecomp&control=" & Me.TxtEstimateComponent.ClientID & "&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.TxtEstimate.ClientID & ".value);return false;")
        '    Me.TxtEstimate.Enabled = True
        '    Me.TxtEstimateComponent.Enabled = True
        'End If
        Me.DataLoaded = False
        'Me.RadToolbarEstimate.FindItemByValue("CreateJob").Enabled = False
        'Me.RefreshGrid()
    End Function

    Private Sub LoadLookups()
        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))

        If Me.CameFromJobTemplate = False And CameFromPV = False Then
            If Me.CurrentQuerystring.GetValue("newEst") = "newcomp" And est.CheckJobEstimateNumber(EstNum) = False Then

                Me.HlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatejcsave&type=jobestimatesave&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." &
                                        Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." &
                                        Me.TxtJobNum.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.TxtEstimate.ClientID & ".value + '&estimatecomp=' + document.forms[0]." &
                                        Me.TxtEstimateComponent.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.TxtSalesClassCode.ClientID & ".value);return false;")

                Me.HlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatejcsave&type=jobcompestimatesave&control=" & Me.TxtJobCompNum.ClientID & "&client=' + document.forms[0]." &
                                              Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." &
                                              Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." &
                                              Me.TxtJobCompNum.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.TxtEstimate.ClientID & ".value + '&estimatecomp=' + document.forms[0]." &
                                              Me.TxtEstimateComponent.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.TxtSalesClassCode.ClientID & ".value);return false;")

            ElseIf Me.CurrentQuerystring.GetValue("newEst") = "newcomp" And est.CheckJobEstimateNumber(EstNum) = True Then

                Me.HlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatejcsave&type=jobestimate&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." &
                                        Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.TxtEstimate.ClientID & ".value + '&estimatecomp=' + document.forms[0]." & Me.TxtEstimateComponent.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.TxtSalesClassCode.ClientID & ".value);return false;")
                Me.HlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatejcsave&type=jobcompestimate&control=" & Me.TxtJobCompNum.ClientID & "&client=' + document.forms[0]." & Me.TxtClientCode.ClientID &
                                              ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." &
                                              Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.TxtEstimate.ClientID &
                                              ".value + '&estimatecomp=' + document.forms[0]." & Me.TxtEstimateComponent.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.TxtSalesClassCode.ClientID & ".value);return false;")

            Else
                Me.HlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatejc&type=jobestimate&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." &
                                        Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID &
                                        ".value + '&estimate=' + document.forms[0]." & Me.TxtEstimate.ClientID & ".value + '&estimatecomp=' + document.forms[0]." & Me.TxtEstimateComponent.ClientID &
                                        ".value + '&salesclass=' + document.forms[0]." & Me.TxtSalesClassCode.ClientID & ".value);return false;")
                Me.HlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatejc&type=jobcompestimate&control=" & Me.TxtJobCompNum.ClientID & "&client=' + document.forms[0]." &
                                              Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." &
                                              Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." &
                                              Me.TxtJobCompNum.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.TxtEstimate.ClientID & ".value + '&estimatecomp=' + document.forms[0]." &
                                              Me.TxtEstimateComponent.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.TxtSalesClassCode.ClientID & ".value);return false;")
            End If
        End If
        Me.HlSalesClass.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtSalesClassCode.ClientID & "&type=salesclass');return false;")
        Me.HlContact.Attributes.Add("onclick", "OpenRadWindowLookup('poplookup_contact.aspx?form=estimate&control=" & Me.TxtContactCode.ClientID & "&type=contacts&client=' + document.forms[0]." &
                                    Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." &
                                    Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." &
                                    Me.TxtProductCode.ClientID & ".value);return false;")

        If Me.TxtJobNum.Text <> "" And Me.TxtJobCompNum.Text <> "" Then
            Me.TxtCampaignCode.ReadOnly = True
            Me.HlCampaign.Visible = False
            Me.lblCampaign.Visible = True
        Else
            Me.TxtCampaignCode.ReadOnly = False
            Me.lblCampaign.Visible = False
            Me.HlCampaign.Visible = True
            Me.HlCampaign.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?calledfrom=custom&form=estcampaignsearch&type=estcampaignedit&control=" & Me.TxtCampaignCode.ClientID & "&client=' + document.forms[0]." &
                                         Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value);return false;")
            If Me.TxtCampaignCode.Text <> "" Then
                Me.HlJob.Visible = False
                Me.TxtJobNum.Visible = False
                Me.TxtJobDescription.Visible = False
                Me.HlComponent.Visible = False
                Me.TxtJobCompNum.Visible = False
                Me.TxtJobCompDescription.Visible = False
            Else
                Me.HlJob.Visible = True
                Me.TxtJobNum.Visible = True
                Me.TxtJobDescription.Visible = True
                Me.HlComponent.Visible = True
                Me.TxtJobCompNum.Visible = True
                Me.TxtJobCompDescription.Visible = True
            End If
        End If

    End Sub

#End Region

#Region " RadGrid Events "

    Private Sub RefreshGrid()

        Me.Session("_ds") = Nothing
        Me.RadGridEstimate.Rebind()

    End Sub

    Private Sub RadGridEstimate_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridEstimate.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Select Case e.CommandName
            Case "EditRow"
                Me.SaveAll()
                Dim j As String = ""
                Dim jc As String = ""

                If IsNumeric(Me.TxtJobNum.Text) = True Then

                    j = Me.TxtJobNum.Text

                End If
                If IsNumeric(Me.TxtJobCompNum.Text) = True Then

                    jc = Me.TxtJobCompNum.Text

                End If

                Dim qs As New AdvantageFramework.Web.QueryString

                qs.Page = "Estimating_Quote.aspx"
                If IsNumeric(Me.TxtJobNum.Text) = True Then qs.JobNumber = Me.TxtJobNum.Text
                If IsNumeric(Me.TxtJobCompNum.Text) = True Then qs.JobComponentNumber = Me.TxtJobCompNum.Text
                qs.EstimateNumber = Me.TxtEstimate.Text
                qs.EstimateComponentNumber = Me.TxtEstimateComponent.Text
                qs.EstimateQuoteNumber = e.CommandArgument
                qs.EstimateRevisionNumber = e.Item.OwnerTableView.DataKeyValues(e.Item.ItemIndex)("EST_REV_NBR")
                If IsNumeric(Me.HiddenfieldCampaignID.Value) = True Then qs.CampaignIdentifier = Me.HiddenfieldCampaignID.Value
                'old
                qs.Add("EstNum", Me.TxtEstimate.Text)
                qs.Add("EstComp", Me.TxtEstimateComponent.Text)
                qs.Add("QuoteNum", e.CommandArgument)
                qs.Add("RevNum", e.Item.OwnerTableView.DataKeyValues(e.Item.ItemIndex)("EST_REV_NBR"))
                qs.Add("cmpid", Me.HiddenfieldCampaignID.Value)


                'If Me.CurrentQuerystring.IsJobDashboard = True Then

                '    qs.IsJobDashboard = True
                '    qs.Go(False, True)

                'Else

                Me.OpenWindow(qs)


                'End If

        End Select
    End Sub

    Private Sub RadGridEstimate_ItemCreated(sender As Object, e As GridItemEventArgs) Handles RadGridEstimate.ItemCreated
        Try
            If e.Item.ItemType = GridItemType.Header Then

                Dim CurrentGridRow As Telerik.Web.UI.GridHeaderItem = e.Item

                Dim SelectCheckBox As CheckBox = CurrentGridRow("ColumnClientSelect").Controls(0)
                If SelectCheckBox IsNot Nothing Then SelectCheckBox.AutoPostBack = True
                'AddHandler SelectCheckBox.CheckedChanged, New EventHandler(AddressOf SelectCheckbox_CheckChanged)

            End If

            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then

                Dim img As ImageButton
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = e.Item
                img = CurrentGridRow("colDetails").FindControl("imgbtnEdit")
                'e.Item.FindControl("imgbtnEdit")

                RadScriptManager.GetCurrent(Page).RegisterPostBackControl(img)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridEstimate_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridEstimate.ItemDataBound
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then

            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = e.Item

            Dim amount As Decimal
            Dim quotewithcontingency As Decimal
            Dim qty As Decimal = 0.0
            Dim CPU As Decimal = 0.0
            Dim str As String = CurrentGridRow("EST_QUOTE_DESC").Text

            'If e.Item.Cells(7).Text <> "&nbsp;" And e.Item.Cells(7).Text <> "" Then
            '    amount = CDec(e.Item.Cells(7).Text)
            'End If
            'If e.Item.Cells(8).Text <> "&nbsp;" And e.Item.Cells(8).Text <> "" Then
            '    qty = CDec(e.Item.Cells(8).Text)
            'End If
            'If e.Item.Cells(9).Text <> "&nbsp;" And e.Item.Cells(9).Text <> "" Then
            '    CPU = CDec(e.Item.Cells(9).Text)
            'End If
            If str = "&nbsp;" Then
                CurrentGridRow("EST_QUOTE_DESC").Text = "Quote " & CurrentGridRow.GetDataKeyValue("EST_QUOTE_NBR").ToString
            End If

            If IsNumeric(CurrentGridRow("SUM_AMOUNT").Text) = True Then

                amount = CDec(CurrentGridRow("SUM_AMOUNT").Text)

            End If
            If IsNumeric(CurrentGridRow("QUOTE_W_CONTINGENCY").Text) = True Then

                quotewithcontingency = CDec(CurrentGridRow("QUOTE_W_CONTINGENCY").Text)

            End If
            If IsNumeric(CurrentGridRow("JOB_QTY").Text) = True Then

                qty = CDec(CurrentGridRow("JOB_QTY").Text)

            End If
            If IsNumeric(CurrentGridRow("CPU").Text) = True Then

                CPU = CDec(CurrentGridRow("CPU").Text)

            End If

            If CPU <> 0.0 And qty <> 0.0 Then

                CPU = CPU / qty

            End If

            CurrentGridRow("SUM_AMOUNT").Text = String.Format("{0:#,##0.00}", amount)
            CurrentGridRow("QUOTE_W_CONTINGENCY").Text = String.Format("{0:#,##0.00}", quotewithcontingency)
            CurrentGridRow("JOB_QTY").Text = String.Format("{0:#,##0}", qty)
            CurrentGridRow("CPU").Text = Math.Round(CPU, 3).ToString
            CurrentGridRow("CPU").Text = String.Format("{0:#,##0.000}", CDec(CurrentGridRow("CPU").Text))

            Dim img As System.Web.UI.WebControls.Image = e.Item.FindControl("ImageClientApproved")
            'Dim ImSpacerApproved As System.Web.UI.WebControls.Image = CType(e.Item.FindControl("ImgSpacerApproved"), System.Web.UI.WebControls.Image)
            Dim approvedby As String = e.Item.Cells(11).Text
            Dim imgInt As System.Web.UI.WebControls.Image = e.Item.FindControl("ImageInternalApproved")
            'Dim ImSpacerApprovedInt As System.Web.UI.WebControls.Image = CType(e.Item.FindControl("ImgSpacerApprovedInternal"), System.Web.UI.WebControls.Image)
            Dim approvedbyint As String = e.Item.Cells(13).Text
            Dim ClientApprovedDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivClientApproved")
            If approvedby <> "" And approvedby <> "&nbsp;" Then
                img.Visible = True
                'ImSpacerApproved.Visible = False
            Else
                AdvantageFramework.Web.Presentation.Controls.DivHide(ClientApprovedDiv)
                'img.Visible = False
                'ImSpacerApproved.Visible = True
            End If
            Dim InternalApprovedDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivInternalApproved")
            If approvedbyint <> "" And approvedbyint <> "&nbsp;" Then
                imgInt.Visible = True
                'ImSpacerApprovedInt.Visible = False
            Else
                'imgInt.Visible = False
                'ImSpacerApprovedInt.Visible = True
                AdvantageFramework.Web.Presentation.Controls.DivHide(InternalApprovedDiv)
            End If

            Dim SelectCheckBox As CheckBox = CurrentGridRow("ColumnClientSelect").Controls(0)
            'If SelectCheckBox IsNot Nothing Then SelectCheckBox.AutoPostBack = True
            SelectCheckBox.Visible = False

        ElseIf e.Item.ItemType = GridItemType.Header Then


        End If
    End Sub

    Private Sub SelectCheckbox_CheckChanged(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Private Sub RadGridEstimate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridEstimate.SelectedIndexChanged
        Try
            Me.SetContentPageData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridEstimate_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridEstimate.NeedDataSource

        Try

            Dim oEstimate As New cEstimating(Session("ConnString"), Session("UserCode"))
            Me.RadGridEstimate.DataSource = oEstimate.GetEstimateQuotes(CInt(Me.TxtEstimate.Text), CInt(Me.TxtEstimateComponent.Text))

        Catch ex As Exception

        End Try

    End Sub

    Dim sum As Decimal()
    Private Sub RadGridQuoteComparison_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridQuoteComparison.ItemDataBound
    End Sub

    Private Sub RadGridQuoteComparison_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridQuoteComparison.NeedDataSource
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim dsQuotes As DataSet = est.GetEstimateQuotes(CInt(Me.TxtEstimate.Text), CInt(Me.TxtEstimateComponent.Text))
            Dim dsQuoteDetails As DataSet = est.GetEstimateQuoteDetailsAll(CInt(Me.TxtEstimate.Text), CInt(Me.TxtEstimateComponent.Text))
            Dim i As Integer
            Dim j As Integer
            Dim m As Integer
            Dim str As String

            Dim dtQC As DataTable
            Dim row As DataRow
            dtQC = New DataTable("Quotes")
            Dim functionCode As DataColumn = New DataColumn("Function Code")
            Dim functionDesc As DataColumn = New DataColumn("Function Description")
            dtQC.Columns.Add(functionCode)
            dtQC.Columns.Add(functionDesc)

            If dsQuotes.Tables(0).Rows.Count > 0 Then
                For i = 0 To dsQuotes.Tables(0).Rows.Count - 1
                    str = dsQuotes.Tables(0).Rows(i)("EST_QUOTE_NBR").ToString
                    dtQC.Columns.Add(New DataColumn(dsQuotes.Tables(0).Rows(i)("EST_QUOTE_NBR").ToString()))
                Next
            End If

            If dsQuoteDetails.Tables(1).Rows.Count > 0 Then
                For i = 0 To dsQuoteDetails.Tables(1).Rows.Count - 1
                    row = dtQC.NewRow
                    row.Item("Function Code") = dsQuoteDetails.Tables(1).Rows(i)("FNC_CODE")
                    row.Item("Function Description") = dsQuoteDetails.Tables(1).Rows(i)("FNC_DESCRIPTION")
                    dtQC.Rows.Add(row)
                Next
            End If

            If dsQuoteDetails.Tables(0).Rows.Count > 0 Then
                For i = 0 To dsQuoteDetails.Tables(0).Rows.Count - 1
                    For j = 0 To dtQC.Rows.Count - 1
                        If dtQC.Rows(j)("Function Code") = dsQuoteDetails.Tables(0).Rows(i)("FNC_CODE") Then
                            For m = 0 To dtQC.Columns.Count - 1
                                If dsQuoteDetails.Tables(0).Rows(i)("EST_QUOTE_NBR").ToString() = dtQC.Columns(m).ColumnName Then
                                    dtQC.Rows(j)(dtQC.Columns(m).ColumnName) = dsQuoteDetails.Tables(0).Rows(i)("LINE_TOTAL")
                                End If
                            Next
                        End If
                    Next
                Next
            End If

            If dtQC.Rows.Count > 0 Then
                Me.RadGridQuoteComparison.DataSource = dtQC
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridVendorRequest_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridVendorRequest.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Select Case e.CommandName
            Case "EditRow"
                Dim j As String = ""
                Dim jc As String = ""
                If IsNumeric(Me.TxtJobNum.Text) = True Then
                    j = Me.TxtJobNum.Text
                End If
                If IsNumeric(Me.TxtJobCompNum.Text) = True Then
                    jc = Me.TxtJobCompNum.Text
                End If
                Dim di As GridDataItem = e.Item
                Dim vrfq As String = di.GetDataKeyValue("VENDOR_QTE_NBR")
                'MiscFN.ResponseRedirect("VendorQuote.aspx?PageMode=edit&EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text & "&j=" & j & "&jc=" & jc & "&vendorreq=" & vrfq)
                Me.OpenWindow("Vendor Quote", "VendorQuote.aspx?tab=0&PageMode=edit&EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text & "&j=" & j & "&jc=" & jc & "&vendorreq=" & vrfq)
        End Select
    End Sub

    Private Sub RadGridVendorRequest_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridVendorRequest.ItemDataBound
        Try
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = e.Item

                Dim str As String = e.Item.Cells(3).Text
                Dim str2 As String = e.Item.Cells(4).Text 'Est num
                Dim str3 As String = e.Item.Cells(5).Text
                Dim str4 As String = e.Item.Cells(6).Text
                Dim str5 As String = e.Item.Cells(11).Text
                Dim str6 As String = e.Item.Cells(8).Text
                Dim di As GridDataItem = e.Item
                If e.Item.Cells(4).Text <> "" Then
                    e.Item.Cells(4).Text = e.Item.Cells(4).Text.PadLeft(6, "0") & "-" & e.Item.DataItem("EST_COMPONENT_NBR").ToString.PadLeft(2, "0") & "-" & e.Item.DataItem("VENDOR_QTE_NBR").ToString.PadLeft(2, "0")
                End If
                If e.Item.Cells(8).Text <> "" Then
                    e.Item.Cells(8).Text = CDate(e.Item.Cells(8).Text).ToShortDateString
                End If
                Dim VendorApprovedDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivVendorApproved")
                'Dim img As System.Web.UI.WebControls.Image = e.Item.FindControl("img_approved_ven")
                'Dim ImSpacerApproved As System.Web.UI.WebControls.Image = CType(e.Item.FindControl("ImgSpacerApproved_ven"), System.Web.UI.WebControls.Image)
                If e.Item.Cells(12).Text <> "" Then
                    If e.Item.Cells(12).Text = "True" Then
                        'img.Visible = True
                        'ImSpacerApproved.Visible = False
                    Else
                        AdvantageFramework.Web.Presentation.Controls.DivHide(VendorApprovedDiv)
                    End If
                End If
                Dim SelectCheckBox As CheckBox = CurrentGridRow("ColumnClientSelect").Controls(0)
                'If SelectCheckBox IsNot Nothing Then SelectCheckBox.AutoPostBack = True
                SelectCheckBox.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridVendorRequest_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridVendorRequest.NeedDataSource
        Try
            Dim oEstimate As New cEstimating(Session("ConnString"), Session("UserCode"))
            If Me.TxtEstimate.Text <> "" And Me.TxtEstimateComponent.Text <> "" Then
                Me.RadGridVendorRequest.DataSource = oEstimate.GetVendorQuotes(CInt(Me.TxtEstimate.Text), CInt(Me.TxtEstimateComponent.Text), Session("UserCode"))
            Else
                Me.RadGridVendorRequest.DataSource = Me.BlankDT
            End If
        Catch ex As Exception

        End Try
    End Sub


#End Region

#Region " Data Functions "

    Private Sub EnableToolbarButtons(ByVal DoIt As Boolean)
        Me.RadToolbarEstimate.FindItemByValue("SaveAll").Enabled = DoIt
        Me.RadToolbarEstimate.FindItemByValue("Copy").Enabled = DoIt
        Me.RadToolbarEstimate.FindItemByValue("NewComp").Enabled = DoIt
        Me.RadToolbarEstimate.FindItemByValue("DelEst").Enabled = DoIt
        Me.RadToolbarEstimate.FindItemByValue("DelComp").Enabled = DoIt
        Me.RadToolbarEstimate.FindItemByValue("Notify").Enabled = DoIt

        Me.RadToolbarEstimateGrid.FindItemByValue("NewQuote").Enabled = DoIt
        Me.RadToolbarEstimateGrid.FindItemByValue("DelQuote").Enabled = DoIt
        Me.RadToolbarEstimateGrid.FindItemByValue("CopyQuote").Enabled = DoIt

        Me.CheckUserRights()
    End Sub

    Private DataLoaded As Boolean
    Private Function GetEstimateData(ByVal EstNumber As Integer, ByVal EstComponentNumber As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As String
        Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim oReports As cReports = New cReports(Session("ConnString"))
        Dim dt As DataTable
        If (EstNumber > 0 And EstComponentNumber > 0) Or (JobNumber > 0 And JobComponentNumber > 0) Then
            If JobNumber > 0 And JobComponentNumber > 0 Then
                If JobNumber <= 0 Then
                    Me.ShowMessage("Please enter a valid job number.")
                    Me.TxtJobNum.Text = ""
                    Me.TxtJobCompNum.Text = ""
                    'ResetForm()
                    Me.TxtJobNum.Focus()
                    Exit Function
                End If
                If MiscFN.NumberInRange(JobNumber, JobComponentNumber) = False Then
                    Me.ShowMessage("Job and/or component number not in valid range!")
                    Me.TxtJobNum.Text = ""
                    Me.TxtJobCompNum.Text = ""
                    'EnableToolbarButtons(False)
                    'ResetForm()
                    Exit Function
                Else
                    If myVal.ValidateJobNumber(JobNumber) = False Then
                        Me.ShowMessage("This job does not exist!")
                        'ResetForm()
                        Me.TxtJobNum.Text = ""
                        Me.TxtJobCompNum.Text = ""
                        Me.TxtJobNum.Focus()
                        Exit Function
                    End If
                    If myVal.ValidateJobCompNumber(JobNumber, JobComponentNumber) = False Then
                        Me.ShowMessage("This is not a valid job/component!")
                        Me.TxtJobNum.Text = ""
                        Me.TxtJobCompNum.Text = ""
                        'EnableToolbarButtons(False)
                        'ResetForm()
                        Exit Function
                    End If
                    'is job open
                    'If myVal.ValidateJobIsOpen(JobNumber, JobComponentNumber) = False Then
                    '    Me.ShowMessage("This job/component is closed!"))
                    '    EnableToolbarButtons(False)
                    '    ResetForm()
                    '    Exit Function
                    'End If
                    'make sure user has access:
                    If myVal.ValidateJobCompIsViewable(Session("UserCode"), JobNumber, JobComponentNumber) = False Then
                        Me.ShowMessage("This job/comp is denied.")
                        'ResetForm()
                        'EnableToolbarButtons(False)
                        Exit Function
                    End If
                End If
                If EstNumber > 0 And EstComponentNumber > 0 Then
                    If myVal.ValidateJobEstimateNumber(JobNumber, JobComponentNumber, EstNumber, EstComponentNumber) = False Then
                        'Me.ShowMessage("This job/comp is not associated with this estimate."))
                        JobNumber = 0
                        JobComponentNumber = 0
                        Me.TxtJobCompNum.Text = ""
                        Me.TxtJobNum.Text = ""
                        'EnableToolbarButtons(False)
                        'ResetForm()
                        'Exit Function
                    End If
                End If
            ElseIf EstNumber > 0 And EstComponentNumber > 0 Then
                If EstNumber <= 0 Then
                    Me.ShowMessage("Please enter a valid Estimate number.")
                    'ResetForm()
                    Me.TxtEstimate.Focus()
                    Exit Function
                End If
                If MiscFN.NumberInRange(EstNumber, EstComponentNumber) = False Then
                    Me.ShowMessage("Estimate and/or component number not in valid range!")
                    'EnableToolbarButtons(False)
                    'ResetForm()
                    Exit Function
                Else
                    If myVal.ValidateEstimateNumber(EstNumber) = False Then

                        Dim IsBookmark As Boolean = False
                        Try

                            If Not Me.CurrentQuerystring.GetValue("bm") Is Nothing Then

                                If Me.CurrentQuerystring.GetValue("bm") = "1" Then

                                    IsBookmark = True

                                End If

                            End If

                        Catch ex As Exception
                        End Try

                        If IsBookmark = True Then

                            Me.ShowMessage("Estimate is no longer available. Please delete your bookmark.")

                        Else

                            Me.ShowMessage("This estimate does not exist!")

                        End If

                        Me.CloseThisWindow()

                    End If
                    If myVal.ValidateEstimateCompNumber(EstNumber, EstComponentNumber) = False Then
                        Me.ShowMessage("This is not a valid Estimate/component!")
                        'EnableToolbarButtons(False)
                        'ResetForm()
                        Exit Function
                    End If
                    If JobNumber = 0 And JobComponentNumber >= 0 Then

                        Me.TxtJobCompNum.Text = ""
                        Me.TxtJobNum.Text = ""

                    End If
                End If
            Else
                Me.TxtJobNum.Text = ""
                Me.TxtJobCompNum.Text = ""
            End If
        End If
        Try
            'ResetForm()
            'Get data:
            dt = oEstimating.GetEstimateData(EstNumber, EstComponentNumber, JobNumber, JobComponentNumber, Session("UserCode"))
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                    Me.TxtClientCode.Text = dt.Rows(0)("CL_CODE")
                Else
                    Me.TxtClientCode.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("CL_NAME")) = False Then
                    Me.TxtClientDescription.Text = dt.Rows(0)("CL_NAME")
                Else
                    Me.TxtClientDescription.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("DIV_CODE")) = False Then
                    Me.TxtDivisionCode.Text = dt.Rows(0)("DIV_CODE")
                Else
                    Me.TxtDivisionCode.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("DIV_NAME")) = False Then
                    Me.TxtDivisionDescription.Text = dt.Rows(0)("DIV_NAME")
                Else
                    Me.TxtDivisionDescription.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("PRD_CODE")) = False Then
                    Me.TxtProductCode.Text = dt.Rows(0)("PRD_CODE")
                Else
                    Me.TxtProductCode.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("PRD_DESCRIPTION")) = False Then
                    Me.TxtProductDescription.Text = dt.Rows(0)("PRD_DESCRIPTION")
                Else
                    Me.TxtProductDescription.Text = ""
                End If

                If Me.TxtClientCode.Text.Trim() <> "" Or Me.TxtDivisionCode.Text.Trim() <> "" Or Me.TxtProductCode.Text.Trim() <> "" Then
                    Dim v As New cValidations(Session("ConnString"))
                    Dim s As String = ""
                    If v.ValidateCDPIsViewable(Me.TxtClientCode.Text.Trim(), Me.TxtDivisionCode.Text.Trim(), Me.TxtProductCode.Text.Trim(), 0, 0, s) = False Then
                        'Server.Transfer("NoAccess.aspx")
                        Me.ShowMessage(s)
                        Me.CloseThisWindow()
                        Exit Function
                    End If
                End If

                If IsDBNull(dt.Rows(0)("JOB_NUMBER")) = False Then
                    Me.TxtJobNum.Text = dt.Rows(0)("JOB_NUMBER")
                    Me.JobNum = dt.Rows(0)("JOB_NUMBER")
                    JobNumber = dt.Rows(0)("JOB_NUMBER")
                Else
                    Me.TxtJobNum.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("JOB_DESC")) = False Then
                    Me.TxtJobDescription.Text = dt.Rows(0)("JOB_DESC")
                Else
                    Me.TxtJobDescription.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                    Me.TxtJobCompNum.Text = dt.Rows(0)("JOB_COMPONENT_NBR")
                    Me.JobComp = dt.Rows(0)("JOB_COMPONENT_NBR")
                    JobComponentNumber = dt.Rows(0)("JOB_COMPONENT_NBR")
                Else
                    Me.TxtJobCompNum.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("JOB_COMP_DESC")) = False Then
                    Me.TxtJobCompDescription.Text = dt.Rows(0)("JOB_COMP_DESC")
                Else
                    Me.TxtJobCompDescription.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("ESTIMATE_NUMBER")) = False Then
                    Me.TxtEstimate.Text = dt.Rows(0)("ESTIMATE_NUMBER")
                Else
                    Me.TxtEstimate.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("EST_LOG_DESC")) = False Then
                    Me.TxtEstimateDescription.Text = dt.Rows(0)("EST_LOG_DESC")
                Else
                    Me.TxtEstimateDescription.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("EST_COMPONENT_NBR")) = False Then
                    Me.TxtEstimateComponent.Text = dt.Rows(0)("EST_COMPONENT_NBR")
                Else
                    Me.TxtEstimateComponent.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("EST_COMP_DESC")) = False Then
                    Me.TxtEstimateComponentDescription.Text = dt.Rows(0)("EST_COMP_DESC")
                Else
                    Me.TxtEstimateComponentDescription.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("EST_LOG_COMMENT_HTML")) = False Then
                    Me.RadEditorEstimateComment.Html = dt.Rows(0)("EST_LOG_COMMENT_HTML")
                ElseIf IsDBNull(dt.Rows(0)("EST_LOG_COMMENT")) = False Then
                    Me.RadEditorEstimateComment.Content = dt.Rows(0)("EST_LOG_COMMENT").Replace(vbLf, "<br />").Replace(vbCrLf, "<br />")
                Else
                    Me.RadEditorEstimateComment.Content = ""
                End If
                If IsDBNull(dt.Rows(0)("EST_COMP_COMMENT_HTML")) = False Then
                    Me.RadEditorComponentComment.Html = dt.Rows(0)("EST_COMP_COMMENT_HTML")
                ElseIf IsDBNull(dt.Rows(0)("EST_COMP_COMMENT")) = False Then
                    Me.RadEditorComponentComment.Content = dt.Rows(0)("EST_COMP_COMMENT").Replace(vbLf, "<br />").Replace(vbCrLf, "<br />")
                Else
                    Me.RadEditorComponentComment.Content = ""
                End If
                If IsDBNull(dt.Rows(0)("SC_CODE")) = False Then
                    Me.TxtSalesClassCode.Text = dt.Rows(0)("SC_CODE")
                Else
                    Me.TxtSalesClassCode.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("SC_DESCRIPTION")) = False Then
                    Me.TxtSalesClassDescription.Text = dt.Rows(0)("SC_DESCRIPTION")
                Else
                    Me.TxtSalesClassDescription.Text = ""
                End If
                If Me.TxtJobNum.Text <> "" And Me.TxtJobCompNum.Text <> "" Then
                    If IsDBNull(dt.Rows(0)("CMP_CODE")) = False Then
                        Me.TxtCampaignCode.Text = dt.Rows(0)("CMP_CODE")
                    Else
                        Me.TxtCampaignCode.Text = ""
                    End If
                    If IsDBNull(dt.Rows(0)("CMP_NAME")) = False Then
                        Me.TxtCampaignDescription.Text = dt.Rows(0)("CMP_NAME")
                    Else
                        Me.TxtCampaignDescription.Text = ""
                    End If
                Else
                    If IsDBNull(dt.Rows(0)("EST_CMP_ID")) = False Then
                        Me.HiddenfieldCampaignID.Value = dt.Rows(0)("EST_CMP_ID")
                        If IsDBNull(dt.Rows(0)("EST_CMP_CODE")) = False Then
                            Me.TxtCampaignCode.Text = dt.Rows(0)("EST_CMP_CODE")
                        Else
                            Me.TxtCampaignCode.Text = ""
                        End If
                        If IsDBNull(dt.Rows(0)("EST_CMP_NAME")) = False Then
                            Me.TxtCampaignDescription.Text = dt.Rows(0)("EST_CMP_NAME")
                        Else
                            Me.TxtCampaignDescription.Text = ""
                        End If
                        Me.RadToolbarEstimate.Items.FindItemByValue("CreateJob").Enabled = False
                    Else
                        Me.RadToolbarEstimate.Items.FindItemByValue("CreateJob").Enabled = True
                        Me.TxtCampaignCode.Text = ""
                        Me.TxtCampaignDescription.Text = ""
                    End If
                End If

                If IsDBNull(dt.Rows(0)("EST_PRD_CONT_CODE")) = False Then
                    Me.TxtContactCode.Text = dt.Rows(0)("EST_PRD_CONT_CODE")
                Else
                    Me.TxtContactCode.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("CONT_FML")) = False Then
                    Me.TxtContactDescription.Text = dt.Rows(0)("CONT_FML")
                Else
                    Me.TxtContactDescription.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("EST_MARKUP_PCT")) = False Then
                    Me.txtMarkupPercent.Text = dt.Rows(0)("EST_MARKUP_PCT")
                Else
                    Me.txtMarkupPercent.Text = "0.000"
                End If
                If IsDBNull(dt.Rows(0)("JOB_CLI_REF")) = False Then
                    Me.TxtClientRef.Text = dt.Rows(0)("JOB_CLI_REF")
                Else
                    Me.TxtClientRef.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("CDP_CONTACT_ID")) = False Then
                    Me.HfContactCodeID.Value = dt.Rows(0)("CDP_CONTACT_ID")
                Else
                    Me.HfContactCodeID.Value = ""
                End If

                EnableToolbarButtons(True)

                If (Me.TxtJobNum.Text <> "" And Me.TxtJobCompNum.Text <> "") Or oEstimating.JobComponentCount(EstNum) > 0 Then

                    Me.TxtSalesClassCode.Enabled = False
                    Me.HlSalesClass.Enabled = False
                    Me.HlSalesClass.Visible = False
                    Me.LabelSalesClass.Visible = True
                    Me.HlSalesClass.Attributes.Add("onclick", "")
                    'Me.RadToolbarEstimate.FindItemByValue("CreateJob").Enabled = False

                Else

                    Me.TxtSalesClassCode.Enabled = True
                    Me.HlSalesClass.Enabled = True
                    Me.HlSalesClass.Visible = True
                    Me.HlSalesClass.Text = "Sales Class"
                    Me.LabelSalesClass.Visible = False
                    Me.HlSalesClass.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtSalesClassCode.ClientID & "&type=salesclass');return false;")

                    If Me.HiddenfieldCampaignID.Value = "" And Me.HiddenfieldCampaignID.Value = "0" Then

                        Me.RadToolbarEstimate.FindItemByValue("CreateJob").Enabled = True

                    End If

                End If
                DataLoaded = True
                Me.rbEstimate.Visible = False
                Me.rbJob.Visible = False
                'Try
                '    Dim csec As New cSecurity(Session("ConnString"))
                '    csec.RecordLocker(Lockable_Applications.Estimating, EstNum, 0, 0, Session("UserCode"))
                'Catch ex As Exception
                'End Try
                Try

                    Dim StandardComment As AdvantageFramework.Database.Entities.StandardComment = Nothing
                    Dim StandardComments As Generic.List(Of AdvantageFramework.Database.Entities.StandardComment) = Nothing

                    Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
                    Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

                    Dim def As String = oReports.GetAgencyEstComment()
                    Dim OfficeCode As String = ""
                    Dim StandardFooterComments As String = Nothing

                    Me.TextBoxFooterCommentDefault.Text = def

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        StandardComments = AdvantageFramework.Database.Procedures.StandardComment.LoadByApplicationCode(DbContext, "Estimates").ToList

                        If StandardComments IsNot Nothing AndAlso StandardComments.Count > 0 Then
                            If Me.JobNum > 0 Then
                                Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Me.JobNum)
                                OfficeCode = Job.OfficeCode
                            Else
                                Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, Me.TxtClientCode.Text, Me.TxtDivisionCode.Text, Me.TxtProductCode.Text)
                                OfficeCode = Product.OfficeCode
                            End If

                            For Each ClientComment In StandardComments
                                If OfficeCode = ClientComment.OfficeCode And Me.TxtClientCode.Text = ClientComment.ClientCode Then
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
                                    If ClientComment.OfficeCode Is Nothing And Me.TxtClientCode.Text = ClientComment.ClientCode Then
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

                        If StandardComment IsNot Nothing Then

                            Me.TextBoxFooterCommentStandard.Text = StandardComment.Comment

                        Else

                            Me.TextBoxFooterCommentStandard.Text = ""

                        End If

                    End Using

                    If IsDBNull(dt.Rows(0)("EST_FTR_COMMENT_HTML")) = False Then

                        If dt.Rows(0)("EST_FTR_COMMENT_HTML").ToString() = "Standard Comment" Then

                            If StandardComment IsNot Nothing Then

                                Me.RadEditorFooterCommentCustom.Html = StandardComment.Comment

                                Me.RadioButtonListFooterComment.Items.FindByValue("standard").Selected = True

                                Me.TextBoxFooterCommentDefault.Visible = False
                                Me.TextBoxFooterCommentStandard.Visible = True
                                Me.RadEditorFooterCommentCustom.Visible = False

                            Else

                                Me.RadEditorFooterCommentCustom.Html = def

                                Me.RadioButtonListFooterComment.Items.FindByValue("default").Selected = True

                                Me.TextBoxFooterCommentDefault.Visible = True
                                Me.TextBoxFooterCommentStandard.Visible = False
                                Me.RadEditorFooterCommentCustom.Visible = False

                            End If

                        ElseIf dt.Rows(0)("EST_FTR_COMMENT_HTML").ToString() = "Agency Defined" Then

                            Me.RadEditorFooterCommentCustom.Html = def

                            Me.RadioButtonListFooterComment.Items.FindByValue("default").Selected = True

                            Me.TextBoxFooterCommentDefault.Visible = True
                            Me.TextBoxFooterCommentStandard.Visible = False
                            Me.RadEditorFooterCommentCustom.Visible = False

                        Else

                            Me.RadEditorFooterCommentCustom.Html = dt.Rows(0)("EST_FTR_COMMENT_HTML")

                            Me.RadioButtonListFooterComment.Items.FindByValue("custom").Selected = True

                            Me.TextBoxFooterCommentDefault.Visible = False
                            Me.TextBoxFooterCommentStandard.Visible = False
                            Me.RadEditorFooterCommentCustom.Visible = True

                        End If

                    ElseIf IsDBNull(dt.Rows(0)("EST_FTR_COMMENT")) = False Then

                        If dt.Rows(0)("EST_FTR_COMMENT").ToString() = "Standard Comment" Then

                            If StandardComment IsNot Nothing Then

                                Me.RadEditorFooterCommentCustom.Content = StandardComment.Comment

                                Me.RadioButtonListFooterComment.Items.FindByValue("standard").Selected = True

                                Me.TextBoxFooterCommentDefault.Visible = False
                                Me.TextBoxFooterCommentStandard.Visible = True
                                Me.RadEditorFooterCommentCustom.Visible = False

                            Else

                                Me.RadEditorFooterCommentCustom.Content = def

                                Me.RadioButtonListFooterComment.Items.FindByValue("default").Selected = True

                                Me.TextBoxFooterCommentDefault.Visible = True
                                Me.TextBoxFooterCommentStandard.Visible = False
                                Me.RadEditorFooterCommentCustom.Visible = False

                            End If

                        ElseIf dt.Rows(0)("EST_FTR_COMMENT").ToString() = "Agency Defined" Then

                            Me.RadEditorFooterCommentCustom.Content = def

                            Me.RadioButtonListFooterComment.Items.FindByValue("default").Selected = True

                            Me.TextBoxFooterCommentDefault.Visible = True
                            Me.TextBoxFooterCommentStandard.Visible = False
                            Me.RadEditorFooterCommentCustom.Visible = False

                        Else

                            Me.RadEditorFooterCommentCustom.Content = dt.Rows(0)("EST_FTR_COMMENT")

                            Me.RadioButtonListFooterComment.Items.FindByValue("custom").Selected = True

                            Me.TextBoxFooterCommentDefault.Visible = False
                            Me.TextBoxFooterCommentStandard.Visible = False
                            Me.RadEditorFooterCommentCustom.Visible = True

                        End If
                    Else

                        If StandardComment IsNot Nothing Then

                            Me.RadEditorFooterCommentCustom.Content = StandardComment.Comment

                            Me.RadioButtonListFooterComment.Items.FindByValue("standard").Selected = True

                            Me.TextBoxFooterCommentDefault.Visible = False
                            Me.TextBoxFooterCommentStandard.Visible = True
                            Me.RadEditorFooterCommentCustom.Visible = False

                        Else

                            Me.RadEditorFooterCommentCustom.Content = def

                            Me.RadioButtonListFooterComment.Items.FindByValue("default").Selected = True

                            Me.TextBoxFooterCommentDefault.Visible = True
                            Me.TextBoxFooterCommentStandard.Visible = False
                            Me.RadEditorFooterCommentCustom.Visible = False

                        End If

                    End If

                Catch ex As Exception
                End Try

                If Me.JobNum > 0 AndAlso Me.JobComp > 0 Then

                    If Me.CurrentQuerystring.IsJobDashboard = False Then
                        Dim qs As New AdvantageFramework.Web.QueryString

                        qs.Page = "Content.aspx"
                        qs.JobNumber = Me.JobNum
                        qs.JobComponentNumber = Me.JobComp

                        qs.IsJobDashboard = True
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates

                        'MiscFN.ResponseRedirect(qs.ToString(True))
                        Me.CloseThisWindowAndOpenNewWindow(qs.ToString(True))
                    End If

                End If

            Else

                If JobNumber > 0 And JobComponentNumber > 0 Then

                    MiscFN.ResponseRedirect("Estimating_AddNew.aspx?newEst=job&JobNum=" & JobNumber & "&JobComp=" & JobComponentNumber)

                End If

                ResetForm()
                DataLoaded = False

            End If

            Dim qsEst As New AdvantageFramework.Web.QueryString()
            With qsEst

                .ClientCode = Me.TxtClientCode.Text
                .DivisionCode = Me.TxtDivisionCode.Text
                .ProductCode = Me.TxtProductCode.Text
                .JobNumber = 0
                .JobComponentNumber = 0
                .EstimateNumber = 0
                .EstimateComponentNumber = 0
                .Add("backsearch", "1")
                .Add("fromest", "1")
                .Page = "Estimating_Search.aspx"

            End With
            Me.LbEstimate.Attributes.Add("onclick", Me.HookUpOpenWindow("Estimating Search", qsEst.ToString(True)))

            Dim qsEstComponent As New AdvantageFramework.Web.QueryString()
            With qsEstComponent

                .ClientCode = Me.TxtClientCode.Text
                .DivisionCode = Me.TxtDivisionCode.Text
                .ProductCode = Me.TxtProductCode.Text
                .JobNumber = 0 'If(IsNumeric(Me.TxtJobNum.Text), CType(Me.TxtJobNum.Text, Integer), 0)
                .JobComponentNumber = 0 'If(IsNumeric(Me.TxtJobCompNum.Text), CType(Me.TxtJobCompNum.Text, Integer), 0)
                .EstimateNumber = If(IsNumeric(Me.TxtEstimate.Text), CType(Me.TxtEstimate.Text, Integer), 0)
                .EstimateComponentNumber = 0
                .Add("backsearch", "1")
                .Add("fromest", "1")
                .Page = "Estimating_Search.aspx"

            End With
            Me.LbEstimateComponent.Attributes.Add("onclick", Me.HookUpOpenWindow("Estimating Search", qsEstComponent.ToString(True)))

            Dim cpd As New AdvantageFramework.Web.Classes.ContentPageData

            If cpd.Load() = True Then

                If IsNumeric(Me.TxtEstimate.Text) = True Then cpd.EstimateNumber = CType(Me.TxtEstimate.Text, Integer)
                If IsNumeric(Me.TxtEstimateComponent.Text) = True Then cpd.EstimateComponentNumber = CType(Me.TxtEstimateComponent.Text, Integer)

                cpd.Save()

            End If

            Return ""

        Catch ex As Exception

            Return ex.Message.ToString

        End Try

    End Function

#End Region

#Region " Controls "

    'Main toolbar:
    Private Sub RadToolbarEstimate_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarEstimate.ButtonClick
        Select Case e.Item.Value
            Case "CreateJob"

                If Me.SaveAll() = True Then

                    Dim qs As New AdvantageFramework.Web.QueryString()
                    Dim dr2 As SqlClient.SqlDataReader
                    Dim oEstimating As New cEstimating()
                    Dim WindowOpened As Boolean = False

                    dr2 = oEstimating.CheckJobNumberEstimateDR(Me.EstNum)

                    Do While dr2.Read

                        If IsDBNull(dr2("JOB_NUMBER")) = False AndAlso IsNumeric(dr2("JOB_NUMBER")) = True Then

                            Me.JobNum = CType(dr2("JOB_NUMBER"), Integer)

                            Me.TxtJobNum.Text = Me.JobNum

                            qs.Page = "JobTemplate_NewComponent.aspx"
                            qs.EstimateNumber = Me.EstNum
                            qs.EstimateComponentNumber = Me.EstComp
                            qs.JobNumber = Me.JobNum
                            qs.Add("JobNum", Me.JobNum)
                            qs.Add("from", "estimate")

                            WindowOpened = True

                            Me.CloseThisWindowAndOpenNewWindow(qs.ToString(True))

                        End If

                    Loop

                    dr2.Close()

                    If WindowOpened = False Then

                        If IsNumeric(Me.TxtJobNum.Text) = True Then

                            qs.Page = "JobTemplate_NewComponent.aspx"

                            qs.JobNumber = CType(Me.TxtJobNum.Text, Integer)
                            If IsNumeric(Me.TxtJobCompNum.Text) = True Then qs.JobComponentNumber = CType(Me.TxtJobCompNum.Text, Integer)
                            qs.EstimateNumber = Me.EstNum
                            qs.EstimateComponentNumber = Me.EstComp

                            WindowOpened = True
                            Me.CloseThisWindowAndOpenNewWindow(qs.ToString(True))

                        End If

                    End If

                    If WindowOpened = False Then

                        Me.CloseThisWindowAndOpenNewWindow("JobTemplate_New.aspx?from=estimate&EstNum=" & Me.EstNum & "&EstComp=" & Me.EstComp)

                    End If

                End If

            Case "RefreshAll"
                Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                If EstNum <= 0 And JobNum <= 0 Then
                    Me.ShowMessage("Please enter a valid Estimate number and/or Job Number.")
                    'ResetForm()
                    Me.TxtEstimate.Focus()
                    Exit Sub
                ElseIf EstNum > 0 And EstComp <= 0 Then
                    Me.TxtEstimate.Text = EstNum
                    Dim v As cValidations = New cValidations(CStr(Session("ConnString")))

                    'If EstNum > 0 And EstComp = 0 Then
                    '    If v.ValidateEstNumber(EstNum) = False Then
                    '        Me.ShowMessage("This estimate does not exist."))
                    '        ResetForm()
                    '        Exit Sub
                    '    End If
                    'End If

                    Dim s As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(EstNum)
                    If i = 1 Then
                        Me.TxtEstimateComponent.Text = i
                        Me.EstComp = i
                    Else
                        Me.ShowMessage("Please enter a valid estimate component number.")
                        'ResetForm()
                        Me.TxtEstimateComponent.Focus()
                        Exit Sub

                    End If
                ElseIf JobNum > 0 And JobComp <= 0 Then
                    Me.TxtJobNum.Text = JobNum
                    Dim v As cValidations = New cValidations(CStr(Session("ConnString")))

                    If JobNum > 0 And JobComp = 0 Then
                        If v.ValidateJobNumber(JobNum) = False Then
                            Me.ShowMessage("This job does not exist.")
                            Me.TxtJobNum.Text = ""
                            Me.TxtJobCompNum.Text = ""
                            'ResetForm()
                            Exit Sub
                        End If
                    End If

                    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(JobNum, True)
                    If i = 1 Then
                        Me.TxtJobCompNum.Text = i
                        Me.JobComp = i
                    Else
                        Me.ShowMessage("Please enter a valid job component number.")
                        'ResetForm()
                        Me.TxtJobCompNum.Focus()
                        Exit Sub

                    End If
                End If
                If Me.CameFromJobTemplate = False And CameFromPV = False Then
                    Me.HlJob.Enabled = True
                    Me.HlComponent.Enabled = True
                    Me.TxtJobNum.Enabled = True
                    Me.TxtJobCompNum.Enabled = True
                    'Me.HlEstimate.Enabled = True
                    'Me.HlEstimateComponent.Enabled = True
                    'Me.HlEstimate.Attributes.Add("onclick", "ClearTB('" & Me.TxtEstimateComponent.ClientID & "');ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=estimatejob&type=estimate&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value);return false;")
                    'Me.HlEstimateComponent.Attributes.Add("onclick", "ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=estimatejob&type=estimatecomp&control=" & Me.TxtEstimateComponent.ClientID & "&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.TxtEstimate.ClientID & ".value);return false;")
                    Me.TxtEstimate.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TxtEstimateComponent.ClientID & "');ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');")
                    Me.TxtEstimateComponent.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');")
                    Me.TxtEstimate.Enabled = True
                    Me.TxtEstimateComponent.Enabled = True
                    Me.rbJob.Visible = False
                    Me.rbEstimate.Visible = False
                    'If EstNum <> 0 And EstComp <> 0 Then
                    '    If est.CheckJobEstimateNumber(EstNum) = False Then
                    '        Me.HlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatejcsave&type=jobestimatesave&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.TxtEstimate.ClientID & ".value + '&estimatecomp=' + document.forms[0]." & Me.TxtEstimateComponent.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.TxtSalesClassCode.ClientID & ".value);return false;")
                    '        Me.HlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatejcsave&type=jobcompestimatesave&control=" & Me.TxtJobCompNum.ClientID & "&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.TxtEstimate.ClientID & ".value + '&estimatecomp=' + document.forms[0]." & Me.TxtEstimateComponent.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.TxtSalesClassCode.ClientID & ".value);return false;")
                    '    Else
                    '        Me.HlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatejcsave&type=jobestimate&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.TxtEstimate.ClientID & ".value + '&estimatecomp=' + document.forms[0]." & Me.TxtEstimateComponent.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.TxtSalesClassCode.ClientID & ".value);return false;")
                    '        Me.HlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatejcsave&type=jobcompestimate&control=" & Me.TxtJobCompNum.ClientID & "&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.TxtEstimate.ClientID & ".value + '&estimatecomp=' + document.forms[0]." & Me.TxtEstimateComponent.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.TxtSalesClassCode.ClientID & ".value);return false;")
                    '    End If
                    'End If

                    If Me.EstNum <> 0 And Me.EstComp <> 0 And Me.JobNum = 0 And Me.JobComp = 0 Then
                        Me.GetEstimateData(Me.TxtEstimate.Text, Me.TxtEstimateComponent.Text, Me.JobNum, Me.JobComp)
                    ElseIf Me.EstNum = 0 And Me.EstComp = 0 And Me.JobNum <> 0 And Me.JobComp <> 0 Then
                        Me.GetEstimateData(Me.EstNum, Me.EstComp, Me.TxtJobNum.Text, Me.TxtJobCompNum.Text)
                    Else
                        Me.GetEstimateData(Me.TxtEstimate.Text, Me.TxtEstimateComponent.Text, Me.JobNum, Me.JobComp)
                    End If
                End If
                LoadLookups()
                RadGridEstimate.Rebind()
                RadGridVendorRequest.Rebind()
                ' ''Case "Print"
                ' ''    Me.SaveAll()
                ' ''    If EstNum = 0 Or EstComp = 0 Then
                ' ''        Me.ShowMessage("Please enter an Estimate/Component number.")
                ' ''        Exit Sub
                ' ''    End If
                ' ''    Me.OpenWindow("", "Estimating_Print.aspx?From=Est&EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text & "&JobNum=" & _
                ' ''        Me.TxtJobNum.Text & "&JobComp=" & Me.TxtJobCompNum.Text)

            Case "Print"

                Me.SaveAll()
                If EstNum = 0 Or EstComp = 0 Then

                    Me.ShowMessage("Please enter an Estimate/Component number.")
                    Exit Sub

                End If

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs.Page = "Estimating_PrintSettings.aspx"

                If IsNumeric(Me.TxtEstimate.Text) = True Then qs.EstimateNumber = CType(Me.TxtEstimate.Text, Integer)
                If IsNumeric(Me.TxtEstimateComponent.Text) = True Then qs.EstimateComponentNumber = CType(Me.TxtEstimateComponent.Text, Integer)
                If IsNumeric(Me.TxtJobNum.Text) = True Then qs.JobNumber = CType(Me.TxtJobNum.Text, Integer)
                If IsNumeric(Me.TxtJobCompNum.Text) = True Then qs.JobComponentNumber = CType(Me.TxtJobCompNum.Text, Integer)

                qs.Add("from", "Est")
                qs.Add("sel_quotes", Me.GetSelectedQuoteNumbersAsString())
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Print)
                qs.Add("print_all", Me.PrintSendAllCheckbox.Checked)

                Me.OpenPrintSendSilently(qs)

            Case "SendAlert"

                Me.SaveAll()
                If EstNum = 0 Or EstComp = 0 Then

                    Me.ShowMessage("Please enter an Estimate/Component number.")
                    Exit Sub

                End If

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs.Page = "Estimating_PrintSettings.aspx"

                If IsNumeric(Me.TxtEstimate.Text) = True Then qs.EstimateNumber = CType(Me.TxtEstimate.Text, Integer)
                If IsNumeric(Me.TxtEstimateComponent.Text) = True Then qs.EstimateComponentNumber = CType(Me.TxtEstimateComponent.Text, Integer)
                If IsNumeric(Me.TxtJobNum.Text) = True Then qs.JobNumber = CType(Me.TxtJobNum.Text, Integer)
                If IsNumeric(Me.TxtJobCompNum.Text) = True Then qs.JobComponentNumber = CType(Me.TxtJobCompNum.Text, Integer)

                qs.Add("from", "Est")
                qs.Add("sel_quotes", Me.GetSelectedQuoteNumbersAsString())
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)
                qs.Add("print_all", Me.PrintSendAllCheckbox.Checked)

                Me.OpenPrintSendSilently(qs)

            Case "SendAssignment"

                Me.SaveAll()
                If EstNum = 0 Or EstComp = 0 Then

                    Me.ShowMessage("Please enter an Estimate/Component number.")
                    Exit Sub

                End If

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs.Page = "Estimating_PrintSettings.aspx"

                If IsNumeric(Me.TxtEstimate.Text) = True Then qs.EstimateNumber = CType(Me.TxtEstimate.Text, Integer)
                If IsNumeric(Me.TxtEstimateComponent.Text) = True Then qs.EstimateComponentNumber = CType(Me.TxtEstimateComponent.Text, Integer)
                If IsNumeric(Me.TxtJobNum.Text) = True Then qs.JobNumber = CType(Me.TxtJobNum.Text, Integer)
                If IsNumeric(Me.TxtJobCompNum.Text) = True Then qs.JobComponentNumber = CType(Me.TxtJobCompNum.Text, Integer)

                qs.Add("from", "Est")
                qs.Add("sel_quotes", Me.GetSelectedQuoteNumbersAsString())
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAssignment)
                qs.Add("print_all", Me.PrintSendAllCheckbox.Checked)

                Me.OpenPrintSendSilently(qs)

            Case "SendEmail"

                Me.SaveAll()
                If EstNum = 0 Or EstComp = 0 Then

                    Me.ShowMessage("Please enter an Estimate/Component number.")
                    Exit Sub

                End If

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs.Page = "Estimating_PrintSettings.aspx"

                If IsNumeric(Me.TxtEstimate.Text) = True Then qs.EstimateNumber = CType(Me.TxtEstimate.Text, Integer)
                If IsNumeric(Me.TxtEstimateComponent.Text) = True Then qs.EstimateComponentNumber = CType(Me.TxtEstimateComponent.Text, Integer)
                If IsNumeric(Me.TxtJobNum.Text) = True Then qs.JobNumber = CType(Me.TxtJobNum.Text, Integer)
                If IsNumeric(Me.TxtJobCompNum.Text) = True Then qs.JobComponentNumber = CType(Me.TxtJobCompNum.Text, Integer)

                qs.Add("from", "Est")
                qs.Add("sel_quotes", Me.GetSelectedQuoteNumbersAsString())
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendEmail)
                qs.Add("print_all", Me.PrintSendAllCheckbox.Checked)

                Me.OpenPrintSendSilently(qs)

            Case "PrintSendOptions"

                Me.SaveAll()
                If EstNum = 0 Or EstComp = 0 Then

                    Me.ShowMessage("Please enter an Estimate/Component number.")
                    Exit Sub

                End If

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs.Page = "Estimating_PrintSettings.aspx"

                If IsNumeric(Me.TxtEstimate.Text) = True Then qs.EstimateNumber = CType(Me.TxtEstimate.Text, Integer)
                If IsNumeric(Me.TxtEstimateComponent.Text) = True Then qs.EstimateComponentNumber = CType(Me.TxtEstimateComponent.Text, Integer)
                If IsNumeric(Me.TxtJobNum.Text) = True Then qs.JobNumber = CType(Me.TxtJobNum.Text, Integer)
                If IsNumeric(Me.TxtJobCompNum.Text) = True Then qs.JobComponentNumber = CType(Me.TxtJobCompNum.Text, Integer)

                qs.Add("from", "Est")
                qs.Add("sel_quotes", Me.GetSelectedQuoteNumbersAsString())
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Options)
                'qs.Add("print_all", Me.PrintSendAllCheckbox.Checked)

                Me.OpenWindow(qs, "Options")

            Case "Clear"
                'Dim csec As New cSecurity(Session("ConnString"))
                'csec.RecordLocker(Lockable_Applications.Estimating, EstNum, 0, 0, "")
                Me.Session("_ds") = Nothing
                Me.OpenWindow("Estimating", "Estimating.aspx")
            Case "Notify"
                'If EstNum = 0 Or EstComp = 0 Then
                '    Me.ShowMessage("Invalid est/comp.")
                '    Exit Sub
                'End If
                Me.SaveAll()
                Me.OpenWindow("New Alert", "Alert_New.aspx?caller=estimating&f=" & CInt(MiscFN.Source_App.Estimate).ToString() & "&e=" & Me.EstNum.ToString() & "&ec=" & Me.EstComp.ToString() & "&j=" & Me.JobNum.ToString() & "&jc=" & Me.JobComp.ToString() & "&cli=" & Me.TxtClientCode.Text.Trim() & "&div=" & Me.TxtDivisionCode.Text.Trim() & "&prd=" & Me.TxtProductCode.Text.Trim())
                'MiscFN.ResponseRedirect("Alert_New.aspx?caller=estimating&f=" & CInt(MiscFN.Source_App.Estimate).ToString() & "&e=" & Me.EstNum.ToString() & "&ec=" & Me.EstComp.ToString() & "&j=" & Me.JobNum.ToString() & "&jc=" & Me.JobComp.ToString() & "&cli=" & Me.TxtClientCode.Text.Trim() & "&div=" & Me.TxtDivisionCode.Text.Trim() & "&prd=" & Me.TxtProductCode.Text.Trim())
                'MiscFN.ResponseRedirect("Alert_New.aspx?f=" & CInt(MiscFN.Source_App.Estimate).ToString() & "&e=" & Me.EstNum.ToString() & "&ec=" & Me.EstComp.ToString() & "&j=" & Me.JobNum.ToString() & "&jc=" & Me.JobComp.ToString())
            Case "NewEstimate"
                Me.SaveAll()
                'MiscFN.ResponseRedirect("Estimating_AddNew.aspx")
                If Me.CurrentQuerystring.IsJobDashboard = True Then
                    Me.OpenWindow("New Estimate", "Estimating_AddNew.aspx")
                Else
                    Me.CloseThisWindowAndOpenNewWindow("Estimating_AddNew.aspx")
                End If
            Case "SaveAll" 'why does this not point back to the SaveAll() sub?
                Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
                Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
                Dim ccID As Integer
                Dim JobNumber As Integer
                Dim JobComponentNumber As Integer
                Dim SaveMessage As String = ""
                If EstNum > 0 And EstComp > 0 Then
                    If myVal.ValidateSalesClassCode(Me.TxtSalesClassCode.Text) = False Then
                        Me.ShowMessage("Please enter a valid sales class.")
                        Me.TxtSalesClassCode.Focus()
                        Exit Sub
                    End If
                    If Me.TxtContactCode.Text <> "" Then
                        'If Me.HfContactCodeID.Value = "" Then
                        ccID = oEstimating.GetContactCodeID(Me.TxtContactCode.Text, Me.TxtClientCode.Text, Me.TxtDivisionCode.Text, Me.TxtProductCode.Text)
                        Me.HfContactCodeID.Value = ccID
                        'End If
                        If myVal.ValidateCDPContactEst(Me.HfContactCodeID.Value, Session("UserCode")) = False Then
                            Me.ShowMessage("Please enter a valid contact.")
                            Me.TxtContactCode.Focus()
                            Exit Sub
                        End If
                    Else
                        Me.HfContactCodeID.Value = "0"
                    End If
                    If IsNumeric(Me.txtMarkupPercent.Text) = False Then
                        Me.ShowMessage("Please enter a valid markup percent.")
                        Me.txtMarkupPercent.Focus()
                        Exit Sub
                    End If
                    If Me.TxtCampaignCode.Text <> "" And Me.TxtCampaignCode.ReadOnly = False Then
                        If myVal.ValidateCampaignEstimate(Me.TxtClientCode.Text, Me.TxtDivisionCode.Text, Me.TxtProductCode.Text, Me.TxtCampaignCode.Text) = False Then
                            Me.ShowMessage("Please enter a valid Campaign.")
                        End If
                        If myVal.ValidateCampaignIsViewable(Session("UserCode"), Me.TxtClientCode.Text, Me.TxtDivisionCode.Text, Me.TxtProductCode.Text, Me.TxtCampaignCode.Text) = False Then
                            Me.ShowMessage("Access to this campaign is denied.")
                        End If
                    End If
                    Me.SaveEstimateInformation(SaveMessage)

                    'If SaveMessage <> "" Then
                    '    Me.ShowMessage(SaveMessage)
                    '    Exit Sub
                    'End If

                    If Me.TxtJobNum.Text <> "" And Me.TxtJobCompNum.Text <> "" Then
                        If IsNumeric(Me.TxtJobNum.Text) Then
                            JobNumber = CInt(Me.TxtJobNum.Text)
                        Else
                            Me.ShowMessage("Please enter a valid job number.")
                            Me.TxtJobNum.Focus()
                            Exit Sub
                        End If
                        If IsNumeric(Me.TxtJobCompNum.Text) Then
                            JobComponentNumber = CInt(Me.TxtJobCompNum.Text)
                        Else
                            Me.ShowMessage("Please enter a valid job comp number.")
                            Me.TxtJobCompNum.Focus()
                            Exit Sub
                        End If
                        If JobNumber <= 0 Then
                            Me.ShowMessage("Please enter a valid job number.")
                            Me.TxtJobNum.Focus()
                            Exit Sub
                        End If
                        If MiscFN.NumberInRange(JobNumber, JobComponentNumber) = False Then
                            Me.ShowMessage("Job and/or component number not in valid range!")
                            'EnableToolbarButtons(False)
                            'ResetForm()
                            Exit Sub
                        Else
                            If myVal.ValidateJobNumber(JobNumber) = False Then
                                Me.ShowMessage("This job does not exist!")
                                Me.TxtJobNum.Focus()
                                Exit Sub
                            End If
                            If myVal.ValidateJobCompNumber(JobNumber, JobComponentNumber) = False Then
                                Me.ShowMessage("This is not a valid job/component!")
                                'EnableToolbarButtons(False)
                                'ResetForm()
                                Exit Sub
                            End If
                            'is job open
                            If myVal.ValidateJobIsOpen(JobNumber, JobComponentNumber) = False Then
                                Me.ShowMessage("This job/component is closed!")
                                'EnableToolbarButtons(False)
                                'ResetForm()
                                Exit Sub
                            End If
                            'make sure user has access:
                            If myVal.ValidateJobCompIsViewable(Session("UserCode"), JobNumber, JobComponentNumber) = False Then
                                Me.ShowMessage("This job/comp is denied.")
                                'EnableToolbarButtons(False)
                                Exit Sub
                            End If
                        End If

                    Else
                        JobNumber = 0
                        JobComponentNumber = 0
                    End If
                    Dim dr As SqlClient.SqlDataReader
                    Dim dr2 As SqlClient.SqlDataReader
                    Dim ojob As New Job(Session("ConnString"))
                    Dim currentJobEstNum As Integer = 0
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    If JobNumber > 0 And JobComponentNumber > 0 Then
                        dr = est.GetEstJob(JobNumber, JobComponentNumber)
                        dr.Read()
                        If dr("ESTIMATE_NUMBER") > 0 And dr("EST_COMPONENT_NBR") > 0 Then
                            If (CInt(Me.TxtEstimate.Text) <> dr("ESTIMATE_NUMBER") And CInt(Me.TxtEstimateComponent.Text) <> dr("EST_COMPONENT_NBR")) Or (CInt(Me.TxtEstimate.Text) = dr("ESTIMATE_NUMBER") And CInt(Me.TxtEstimateComponent.Text) <> dr("EST_COMPONENT_NBR")) Then
                                Me.ShowMessage("This is not a valid job/component for this estimate.")
                                Exit Sub
                            End If
                        End If
                        dr.Close()
                        dr2 = est.GetEstimateNumJob(JobNumber)
                        If dr2.HasRows = True Then
                            Do While dr2.Read
                                If dr2("ESTIMATE_NUMBER") > 0 Then
                                    If CInt(Me.TxtEstimate.Text) <> dr2("ESTIMATE_NUMBER") Then
                                        Me.ShowMessage("This is not a valid job/component for this estimate.")
                                        'currentJobEstNum = dr2("ESTIMATE_NUMBER")
                                        Exit Sub
                                    End If
                                End If
                            Loop
                        End If
                        dr2.Close()
                        ojob.GetJob(JobNumber, JobComponentNumber)
                        If Me.TxtSalesClassCode.Text <> ojob.SC_CODE Then
                            Me.ShowMessage("This is not a valid job/component for this estimate.")
                            Exit Sub
                        End If
                    End If
                    Me.SaveJobInformation()
                    'End If     
                    Me.GetEstimateData(Me.EstNum, Me.EstComp, Me.JobNum, Me.JobComp)
                    Me.LoadLookups()
                End If



            Case "NewComp"
                Me.SaveAll()
                'MiscFN.ResponseRedirect("Estimating_AddNewComponent.aspx?EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text & "&cdpcontact=" & Me.HfContactCodeID.Value)
                Me.OpenWindow("New Component", "Estimating_AddNewComponent.aspx?EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text & "&cdpcontact=" & Me.HfContactCodeID.Value)
            Case "Copy"
                Me.SaveAll()
                If EstNum <= 0 Then
                    Me.ShowMessage("Please enter a valid Estimate number.")
                    Me.TxtEstimate.Focus()
                    Exit Sub
                ElseIf EstNum > 0 And EstComp <= 0 Then
                    Me.TxtEstimate.Text = EstNum
                    Dim v As cValidations = New cValidations(CStr(Session("ConnString")))
                    Dim s As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(EstNum)
                    If i = 1 Then
                        Me.TxtEstimateComponent.Text = i
                        Me.EstComp = i
                    Else
                        Me.ShowMessage("Please enter a valid estimate component number.")
                        Me.TxtJobCompNum.Focus()
                        Exit Sub

                    End If
                End If
                Dim j As String = ""
                Dim jc As String = ""
                If IsNumeric(Me.TxtJobNum.Text) = True Then
                    j = Me.TxtJobNum.Text
                End If
                If IsNumeric(Me.TxtJobCompNum.Text) = True Then
                    jc = Me.TxtJobCompNum.Text
                End If
                'MiscFN.ResponseRedirect("Estimating_AddNew.aspx?EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text & "&j=" & j & "&jc=" & jc & "&copy=loaded")
                Me.OpenWindow("Copy", "Estimating_AddNew.aspx?EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text & "&j=" & j & "&jc=" & jc & "&copy=loaded")
            Case "DelEst"
                'SaveAlmostEverything(False)
                Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                Dim ds As DataSet
                Dim approved As Boolean = False
                ds = est.GetEstimateQuotes(Me.EstNum, Me.EstComp)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        If ds.Tables(0).Rows(i)(10).ToString() <> "" Or ds.Tables(0).Rows(i)(11).ToString() <> "" Then
                            approved = True
                        End If
                    Next
                End If
                If approved = True Then
                    Me.ShowMessage("An approved estimate cannot be deleted.")
                End If
                Dim DelSQL As String = ""
                Dim UpdSQL As String = ""
                If EstNum > 0 And EstComp > 0 And approved = False Then
                    'If JobNum > 0 And JobComp > 0 Then
                    'UpdSQL = "UPDATE JOB_COMPONENT SET ESTIMATE_NUMBER = NULL, EST_COMPONENT_NBR = NULL WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobComp & ";"
                    UpdSQL = "UPDATE JOB_COMPONENT SET ESTIMATE_NUMBER = NULL, EST_COMPONENT_NBR = NULL WHERE ESTIMATE_NUMBER = " & EstNum & ";"
                    'End If
                    DelSQL = "DELETE FROM ESTIMATE_REV_DET WHERE ESTIMATE_NUMBER = " & EstNum & ";DELETE FROM ESTIMATE_REV WHERE ESTIMATE_NUMBER = " & EstNum & ";DELETE FROM ESTIMATE_QUOTE WHERE ESTIMATE_NUMBER = " & EstNum & ";DELETE FROM ESTIMATE_COMPONENT WHERE ESTIMATE_NUMBER = " & EstNum & ";DELETE FROM ESTIMATE_LOG WHERE ESTIMATE_NUMBER = " & EstNum & ";"
                    Using MyConn As New SqlConnection(Session("ConnString"))
                        MyConn.Open()
                        Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                        Dim MyCmd As New SqlCommand(UpdSQL & DelSQL, MyConn, MyTrans)
                        Try
                            MyCmd.ExecuteNonQuery()
                            MyTrans.Commit()
                            Me.DelEstimate = True
                        Catch ex As Exception
                            MyTrans.Rollback()
                        Finally
                            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        End Try
                    End Using
                    'Me.ResetForm()
                    Me.RefreshGrid()
                    DataLoaded = False
                    EnableToolbarButtons(DataLoaded)
                End If
                If Me.CurrentQuerystring.IsJobDashboard = True Then
                    Dim qs As New AdvantageFramework.Web.QueryString

                    qs.Page = "Content.aspx"
                    qs.JobNumber = Me.JobNum
                    qs.JobComponentNumber = Me.JobComp

                    qs.IsJobDashboard = True
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates

                    'MiscFN.ResponseRedirect(qs.ToString(True))
                    Me.CloseThisWindowAndOpenNewWindow(qs.ToString(True))

                Else
                    Me.CloseThisWindowAndOpenNewWindow("Estimating_Search.aspx")
                End If
                'Me.OpenWindow("", "Estimating_Search.aspx")
                'Me.ReloadMe = True

            Case "DelComp"
                'SaveAlmostEverything(False)
                Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                Dim ds As DataSet
                Dim approved As Boolean = False
                ds = est.GetEstimateQuotes(Me.EstNum, Me.EstComp)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        If ds.Tables(0).Rows(i)(10).ToString() <> "" Or ds.Tables(0).Rows(i)(11).ToString() <> "" Then
                            approved = True
                        End If
                    Next
                End If
                If approved = True Then
                    Me.ShowMessage("An approved estimate component cannot be deleted.")
                End If
                Dim UpdSQL As String = ""
                Dim DelSQL As String = ""
                If EstNum > 0 And EstComp > 0 And approved = False Then
                    If Me.TxtJobNum.Text <> "" And Me.TxtJobCompNum.Text <> "" Then
                        UpdSQL = "UPDATE JOB_COMPONENT SET ESTIMATE_NUMBER = NULL, EST_COMPONENT_NBR = NULL WHERE JOB_NUMBER = " & Me.TxtJobNum.Text & " AND JOB_COMPONENT_NBR = " & Me.TxtJobCompNum.Text & ";"
                    End If
                    DelSQL = "DELETE FROM ESTIMATE_REV_DET WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstComp & ";DELETE FROM ESTIMATE_REV WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstComp & ";DELETE FROM ESTIMATE_QUOTE WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstComp & ";DELETE FROM ESTIMATE_COMPONENT WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstComp & ";"
                    Using MyConn As New SqlConnection(Session("ConnString"))
                        MyConn.Open()
                        Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                        Dim MyCmd As New SqlCommand(UpdSQL & DelSQL, MyConn, MyTrans)
                        Try
                            MyCmd.ExecuteNonQuery()
                            MyTrans.Commit()
                            Me.DelComp = True
                        Catch ex As Exception
                            MyTrans.Rollback()
                        Finally
                            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        End Try
                    End Using
                    Me.ResetForm()
                    Me.RefreshGrid()
                    DataLoaded = False
                    EnableToolbarButtons(DataLoaded)
                End If
                Me.CloseThisWindowAndOpenNewWindow("Estimating_Search.aspx")
                'Me.OpenWindow("", "Estimating_Search.aspx")
                'Me.ReloadMe = True
            Case "Search"
                Me.SaveAll()
                Session("CurrEstSearchClient") = ""
                Session("CurrEstSearchDivision") = ""
                Session("CurrEstSearchProduct") = ""
                Session("CurrEstSearchJobNum") = ""
                Session("CurrEstSearchJobCompNum") = ""
                Session("CurrEstSearchEstNum") = ""
                Session("CurrEstSearchEstCompNum") = ""
                Me.OpenWindow("Estimating Search", "Estimating_Search.aspx")
                'MiscFN.ResponseRedirect("Estimating_Search.aspx")
            Case "Bookmark"

                Me.SaveAll()

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                Dim qs As New AdvantageFramework.Web.QueryString()

                qs = qs.FromCurrent()
                If Me.JobNum > 0 Then
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates
                    qs.Page = "Content.aspx"
                Else
                    qs.Page = "Estimating.aspx"
                End If

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_Estimating
                    .UserCode = Session("UserCode")
                    .Name = "Est: " & Me.EstNum & "/" & Me.EstComp
                    If Me.JobNum > 0 Then
                        .PageURL = "Content.aspx" & qs.ToString()
                    Else
                        .PageURL = "Estimating.aspx?EstNum=" + Me.EstNum.ToString + "&EstComp=" + Me.EstComp.ToString + "&newEst=edit"
                    End If

                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then
                    Me.ShowMessage(s)
                Else
                    Me.RefreshBookmarksDesktopObject()
                End If

            Case "Alerts"

                Me.SaveAll()

                Dim qs As New AdvantageFramework.Web.QueryString

                qs.Page = "Alert_List.aspx"
                qs.Add("lstlvl", AdvantageFramework.Database.Entities.AlertListLevel.EstimateComponent)
                If IsNumeric(Me.TxtEstimate.Text) = True Then qs.EstimateNumber = CType(Me.TxtEstimate.Text, Integer)
                If IsNumeric(Me.TxtEstimateComponent.Text) = True Then qs.EstimateComponentNumber = CType(Me.TxtEstimateComponent.Text, Integer)
                If IsNumeric(Me.TxtJobNum.Text) = True Then qs.JobNumber = CType(Me.TxtJobNum.Text, Integer)
                If IsNumeric(Me.TxtJobCompNum.Text) = True Then qs.JobComponentNumber = CType(Me.TxtJobCompNum.Text, Integer)

                qs.Add("from", "Est")
                qs.Add("sel_quotes", Me.GetSelectedQuoteNumbersAsString())
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Print)
                qs.Add("print_all", Me.PrintSendAllCheckbox.Checked)

                If qs.JobNumber > 0 AndAlso qs.JobComponentNumber > 0 Then
                    qs.Page = "Alert_Inbox.aspx"
                End If

                Me.OpenWindow(qs)

            Case "RemoveJob"

                Dim jc As AdvantageFramework.Database.Entities.JobComponent = Nothing

                Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                Dim ds As DataSet
                Dim approved As Boolean = False
                ds = est.GetEstimateQuotes(Me.EstNum, Me.EstComp)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        If ds.Tables(0).Rows(i)(10).ToString() <> "" Or ds.Tables(0).Rows(i)(11).ToString() <> "" Then
                            approved = True
                        End If
                    Next
                End If
                If approved = True Then
                    Me.ShowMessage("Estimate quote is approved, Job cannot be removed.")
                    Exit Sub
                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    jc = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me.JobNum, Me.JobComp)

                    If jc IsNot Nothing Then
                        jc.EstimateNumber = Nothing
                        jc.EstimateComponentNumber = Nothing
                        If AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, jc) Then

                            Dim qs As New AdvantageFramework.Web.QueryString
                            qs.Page = "Estimating.aspx"
                            qs.EstimateNumber = Me.EstNum
                            qs.EstimateComponentNumber = Me.EstComp

                            Me.CloseThisWindowAndOpenNewWindow(qs.ToString(True), True)
                        End If
                    End If
                End Using

        End Select

        Me.SetContentPageData()

    End Sub

    Private Sub RadToolbarEstimateGrid_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarEstimateGrid.ButtonClick
        Try
            Select Case e.Item.Value
                Case "NewQuote"
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim save As Boolean
                    Dim max As Integer
                    Me.SaveAll()
                    max = est.GetEstimateQuoteMax(Me.EstNum, Me.EstComp)
                    save = est.AddNewQuote(Me.EstNum, Me.EstComp, max + 1, 0)
                    If save = True Then
                        Me.OpenWindow("New Quote", "Estimating_Quote.aspx?EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text & "&QuoteNum=" & max + 1 & "&cmpid=" & Me.HiddenfieldCampaignID.Value & "&j=" & Me.JobNum.ToString() & "&jc=" & Me.JobComp.ToString())
                        Me.RadGridEstimate.Rebind()
                    Else
                        Me.ShowMessage("Save Failed.")
                        Exit Sub
                    End If
                Case "DelQuote"
                    'SaveAlmostEverything(False)
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim ds As DataSet
                    Dim chk As CheckBox
                    Dim DelString As String = ""
                    Dim count As Integer = 0
                    Dim img As System.Web.UI.WebControls.Image
                    Dim imginternal As System.Web.UI.WebControls.Image
                    Dim approved As Boolean = False
                    Dim rfq As Boolean = False
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstimate.MasterTableView.Items
                        'chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        img = gridDataItem.FindControl("ImageClientApproved")
                        imginternal = gridDataItem.FindControl("ImageInternalApproved")
                        If IsNumeric(gridDataItem.GetDataKeyValue("EST_QUOTE_NBR")) Then
                            ds = est.GetRequestsByQuote(Me.EstNum, Me.EstComp, 0, gridDataItem.GetDataKeyValue("EST_QUOTE_NBR"), Session("UserCode"))
                        End If
                        If gridDataItem.Selected And img.Visible = False And imginternal.Visible = False And ds.Tables(0).Rows.Count = 0 Then
                            If IsNumeric(gridDataItem.GetDataKeyValue("EST_QUOTE_NBR")) Then
                                DelString &= gridDataItem.GetDataKeyValue("EST_QUOTE_NBR") & ","
                            End If
                            count += 1
                        ElseIf gridDataItem.Selected And (img.Visible = True Or imginternal.Visible = True) Then
                            approved = True
                            count += 1
                        ElseIf gridDataItem.Selected And ds.Tables(0).Rows.Count > 0 Then
                            rfq = True
                            count += 1
                        End If
                    Next
                    If approved = True Then
                        Me.ShowMessage("An approved quote cannot be deleted.")
                    End If
                    If rfq = True Then
                        Me.ShowMessage("A quote with a Vendor Quote Request cannot be deleted.")
                    End If
                    If count = 0 Then
                        Me.ShowMessage("No rows were selected for deletion.")
                    End If

                    DelString = MiscFN.RemoveTrailingDelimiter(DelString, ",")
                    Dim DelSQL As String = ""
                    If EstNum > 0 And EstComp > 0 And DelString.Length > 0 Then
                        DelSQL = "DELETE FROM ESTIMATE_REV_DET WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstComp & " AND EST_QUOTE_NBR IN (" & DelString & ");DELETE FROM ESTIMATE_REV WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstComp & " AND EST_QUOTE_NBR IN (" & DelString & ");DELETE FROM EVENT_GEN WHERE EST_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstComp & " AND EST_QUOTE_NUMBER IN (" & DelString & ");DELETE FROM ESTIMATE_QUOTE WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstComp & " AND EST_QUOTE_NBR IN (" & DelString & ");"
                        Using MyConn As New SqlConnection(Session("ConnString"))
                            MyConn.Open()
                            Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                            Dim MyCmd As New SqlCommand(DelSQL, MyConn, MyTrans)
                            Try
                                MyCmd.ExecuteNonQuery()
                                MyTrans.Commit()

                            Catch ex As Exception
                                MyTrans.Rollback()
                            Finally
                                If MyConn.State = ConnectionState.Open Then MyConn.Close()
                            End Try
                        End Using
                    End If
                    Me.GetEstimateData(Me.EstNum, Me.EstComp, Me.JobNum, Me.JobComp)
                    Me.RadGridEstimate.Rebind()
                    'Me.DelQuote = True
                    'Me.ReloadMe = True
                Case "CopyQuote"
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Me.SaveAll()
                    'If EstNum < 0 Then
                    '    Me.ShowMessage("Please enter a valid Estimate number."))
                    '    Exit Sub
                    'End If
                    'If EstComp < 0 Then
                    '    Me.ShowMessage("Please enter a valid Estimate Component number."))
                    '    Exit Sub
                    'End If
                    If EstNum <= 0 Then
                        Me.ShowMessage("Please enter a valid Estimate number.")
                        Me.TxtEstimate.Focus()
                        Exit Sub
                    ElseIf EstNum > 0 And EstComp <= 0 Then
                        Me.TxtEstimate.Text = EstNum
                        Dim v As cValidations = New cValidations(CStr(Session("ConnString")))
                        Dim s As New cEstimating(Session("ConnString"), Session("UserCode"))
                        Dim i As Integer = s.CountHeaderComponentsOneComp(EstNum)
                        If i = 1 Then
                            Me.TxtEstimateComponent.Text = i
                            Me.EstComp = i
                        Else
                            Me.ShowMessage("Please enter a valid estimate component number.")
                            Me.TxtJobCompNum.Focus()
                            Exit Sub
                        End If
                    End If

                    Dim chk As CheckBox
                    Dim quote As String
                    Dim count As Integer = 0
                    Dim max As Integer
                    Dim save As Boolean = False
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstimate.MasterTableView.Items
                        'chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        If gridDataItem.Selected Then
                            If IsNumeric(gridDataItem.GetDataKeyValue("EST_QUOTE_NBR")) Then
                                quote = gridDataItem.GetDataKeyValue("EST_QUOTE_NBR")
                            End If
                            max = est.GetEstimateQuoteMaxRevision(Me.EstNum, Me.EstComp, quote)
                            save = est.AddNewQuoteCopy(Me.EstNum, Me.EstComp, Me.EstNum, Me.EstComp, quote, max, 0)
                            count += 1
                        End If
                    Next
                    If count = 1 Then
                        max = est.GetEstimateQuoteMax(Me.EstNum, Me.EstComp)
                        Me.OpenWindow("Estimating Quote", "Estimating_Quote.aspx?EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text & "&QuoteNum=" & max & "&cmpid=" & Me.HiddenfieldCampaignID.Value)
                        Me.RadGridEstimate.Rebind()
                        'MiscFN.ResponseRedirect("Estimating_Quote.aspx?EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text & "&QuoteNum=" & max & "&cmpid=" & Me.HiddenfieldCampaignID.Value)
                    Else
                        Me.RadGridEstimate.Rebind()
                    End If
                    If count = 0 Then
                        Me.ShowMessage("No rows were selected for copy.")
                    End If
                Case "VendorQuote"
                    Try
                        Me.RadGridVendorRequest.Visible = True
                        Me.PanelVendorRequest.Visible = True
                        Me.RadGridVendorRequest.Rebind()

                        Me.PanelEstimateQuote.Visible = False

                        Me.CheckUserRights()
                        'MiscFN.ResponseRedirect("VendorQuote.aspx?from=estimate&EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text)
                    Catch ex As Exception

                    End Try
            End Select

            Me.SetContentPageData()

        Catch ex As Exception

        End Try
    End Sub

    Private Function GetSelectedQuoteNumbersAsString() As String

        Dim sb As New System.Text.StringBuilder
        Dim chk As CheckBox
        Dim count As Integer = 0

        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstimate.MasterTableView.Items

            'chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)

            If gridDataItem.Selected Then

                sb.Append(gridDataItem.GetDataKeyValue("EST_QUOTE_NBR").ToString())
                sb.Append(",")

            End If

            count += 1

        Next

        Return MiscFN.CleanStringForSplit(sb.ToString(), ",")

    End Function
    Private Function GetSelectedQuoteDescriptionsAsString() As String

        Dim sb As New System.Text.StringBuilder
        Dim chk As CheckBox
        Dim count As Integer = 0

        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstimate.MasterTableView.Items

            'chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)

            If gridDataItem.Selected Then

                sb.Append(gridDataItem.GetDataKeyValue("EST_QUOTE_DESC").ToString())
                sb.Append(",")

            End If

            count += 1

        Next

        Return MiscFN.CleanStringForSplit(sb.ToString(), ",", False, False, True, False, False)

    End Function
    Private Sub RadToolbarVendorGrid_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarVendorGrid.ButtonClick
        Try
            Select Case e.Item.Value

                Case "QuoteDisplay"
                    Try
                        Me.PanelEstimateQuote.Visible = True
                        Me.PanelVendorRequest.Visible = False
                        Me.RadGridEstimate.Rebind()
                        Me.CheckUserRights()
                        'MiscFN.ResponseRedirect("VendorQuote.aspx?from=estimate&EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text)
                    Catch ex As Exception

                    End Try
                Case "NewRequest"
                    Try
                        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))

                        Me.SaveAll()
                        Dim save As Boolean
                        Dim reqNum As Integer
                        reqNum = est.GetRequestNumber(Me.EstNum, Me.EstComp, Session("UserCode"))
                        save = est.AddNewRequest(Me.EstNum, Me.EstComp, reqNum, TxtEstimateDescription.Text, "", Session("UserCode"), Now, Session("UserCode"))
                        If save = True Then
                            Me.OpenWindow("New Request", "VendorQuote.aspx?tab=0&PageMode=new&from=estimate&EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text & "&vendorreq=" & reqNum, 0, 0, False, False, "refreshPage")
                        Else
                            Me.ShowMessage("Save failed")
                        End If
                        Me.RadGridVendorRequest.Rebind()

                    Catch ex As Exception

                    End Try
                Case "DelRequest"
                    Try
                        Dim chk As CheckBox
                        Dim DelString As String = ""
                        Dim count As Integer = 0
                        Dim img As System.Web.UI.WebControls.Image
                        Dim imginternal As System.Web.UI.WebControls.Image
                        Dim approved As Boolean = False
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendorRequest.MasterTableView.Items
                            'chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                            If gridDataItem.Selected Then
                                If IsNumeric(gridDataItem.GetDataKeyValue("VENDOR_QTE_NBR")) Then
                                    DelString &= gridDataItem.GetDataKeyValue("VENDOR_QTE_NBR") & ","
                                End If
                                count += 1
                            End If
                        Next
                        If approved = True Then
                            Me.ShowMessage("An approved quote cannot be deleted.")
                        End If
                        If count = 0 Then
                            Me.ShowMessage("No rows were selected for deletion.")
                        End If
                        DelString = MiscFN.RemoveTrailingDelimiter(DelString, ",")
                        Dim DelSQL As String = ""
                        If EstNum > 0 And EstComp > 0 And DelString.Length > 0 Then
                            DelSQL = "DELETE FROM VENDOR_QTE_DTL WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstComp & " AND VENDOR_QTE_NBR IN (" & DelString & ");DELETE FROM VENDOR_QTE_VEN WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstComp & " AND VENDOR_QTE_NBR IN (" & DelString & ");DELETE FROM VENDOR_QTE_FNC WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstComp & " AND VENDOR_QTE_NBR IN (" & DelString & ");DELETE FROM VENDOR_QTE_SPECS WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstComp & " AND VENDOR_QTE_NBR IN (" & DelString & ");DELETE FROM VENDOR_QTE_HDR WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstComp & " AND VENDOR_QTE_NBR IN (" & DelString & ");"
                            Using MyConn As New SqlConnection(Session("ConnString"))
                                MyConn.Open()
                                Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                                Dim MyCmd As New SqlCommand(DelSQL, MyConn, MyTrans)
                                Try
                                    MyCmd.ExecuteNonQuery()
                                    MyTrans.Commit()

                                Catch ex As Exception
                                    MyTrans.Rollback()
                                Finally
                                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                                End Try
                            End Using
                        End If
                        Me.GetEstimateData(Me.EstNum, Me.EstComp, Me.JobNum, Me.JobComp)
                        Me.RadGridEstimate.Rebind()
                        Me.RadGridVendorRequest.Rebind()
                        'Me.DelQuote = True
                        'Me.ReloadMe = True
                    Catch ex As Exception

                    End Try
                Case "CopyRequest"
                    Try
                        Dim chk As CheckBox
                        Dim rfq As String
                        Dim count As Integer = 0
                        Dim max As Integer
                        Dim save As Boolean = False
                        Dim oEstimate As New cEstimating(Session("ConnString"), Session("UserCode"))
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendorRequest.MasterTableView.Items
                            'chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                            If gridDataItem.Selected Then
                                If IsNumeric(gridDataItem.GetDataKeyValue("VENDOR_QTE_NBR")) Then
                                    rfq = gridDataItem.GetDataKeyValue("VENDOR_QTE_NBR")
                                End If
                                max = oEstimate.GetRequestNumber(Me.EstNum, Me.EstComp, Session("UserCode"))
                                save = oEstimate.CopyNewRequest(Me.EstNum, Me.EstComp, rfq, max, Session("UserCode"), Now, Session("UserCode"))
                                count += 1
                            End If
                        Next
                        If count = 1 Then
                            'max = oEstimate.GetRequestNumber(Me.EstNum, Me.EstComp, Session("UserCode"))
                            Me.OpenWindow("Copy Quote", "VendorQuote.aspx?tab=0&PageMode=edit&EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text & "&vendorreq=" & max)
                        Else
                            Me.RadGridVendorRequest.Rebind()
                        End If
                        If count = 0 Then
                            Me.ShowMessage("No rows were selected for copy.")
                        End If
                    Catch ex As Exception

                    End Try
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Estimating_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Select Case Me.EventArgument
            Case "DelQuote"
                If Me.ReloadMe = True Then
                    Me.reloadForm()
                End If
            Case "DelEst"
                If Me.ReloadMe = True Then
                    ' Me.reloadForm()
                End If
            Case "DelComp"
                If Me.ReloadMe = True Then
                    Me.reloadForm()
                End If
        End Select

        Dim cpd As New AdvantageFramework.Web.Classes.ContentPageData

        If cpd.Load() = True Then

            For Each GridItem In RadGridEstimate.Items
                If cpd.EstimateSelectedQuoteNumbers <> "" Then
                    If cpd.EstimateSelectedQuoteNumbers.Contains(GridItem.GetDataKeyValue("EST_QUOTE_NBR").ToString) Then
                        GridItem.Selected = True
                    End If
                End If
            Next

        End If

        Dim qs As New AdvantageFramework.Web.QueryString()
        Dim Deep As New AdvantageFramework.Web.DeepLink(Me._Session)

        qs = qs.FromCurrent()
        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates
        qs.Page = "Content.aspx"
        Deep.BuildJavascriptFromQueryString(qs, WebvantageLink, ClientPortalLink)
        Me.RadToolbarEstimate.FindItemByValue("CpPermaLink").Visible = False 'Deep.ClientPortalVisible
        If Me.IsClientPortal = True Then

            Me.RadToolbarEstimate.FindItemByValue("WvPermaLink").Visible = False
            Me.RadToolbarEstimate.FindItemByValue("CpPermaLink").Visible = False

        End If

    End Sub

    Private Sub TxtJobCompNum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtJobCompNum.TextChanged
        Try
            Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
            Dim dtComp As New DataTable
            If Me.TxtJobNum.Text <> "" And Me.TxtJobCompNum.Text <> "" Then
                oTS.GetJobComponentInfo(CInt(Me.TxtJobNum.Text), CInt(Me.TxtJobCompNum.Text), , , , , , , , , , , , , , , Me.TxtContactCode.Text, Me.TxtContactDescription.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub LbEstimate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbEstimate.Click
    '    Try
    '        '''Session("CurrEstSearchClient") = Me.TxtClientCode.Text
    '        '''Session("CurrEstSearchDivision") = Me.TxtDivisionCode.Text
    '        '''Session("CurrEstSearchProduct") = Me.TxtProductCode.Text
    '        '''Session("CurrEstSearchJobNum") = ""
    '        '''Session("CurrEstSearchJobCompNum") = ""
    '        '''Session("CurrEstSearchEstNum") = ""
    '        '''Session("CurrEstSearchEstCompNum") = ""

    '        '''MiscFN.ResponseRedirect("Estimating_Search.aspx?back=Est")

    '        Dim qs As New AdvantageFramework.Web.QueryString()

    '        With qs

    '            .ClCode = Me.TxtClientCode.Text
    '            .DivCode = Me.TxtDivisionCode.Text
    '            .PrdCode = Me.TxtProductCode.Text
    '            .JobNumber = 0
    '            .JobComponentNbr = 0
    '            .EstimateNumber = 0
    '            .EstComponentNbr = 0
    '            .Add("backsearch", "1")
    '            .Page = "Estimating_Search.aspx"

    '        End With

    '        Me.OpenWindow("", qs.ToString(True))

    '    Catch ex As Exception

    '        Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

    '    End Try
    'End Sub

    'Private Sub LbEstimateComponent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbEstimateComponent.Click
    '    Try
    '        '''Session("CurrEstSearchClient") = Me.TxtClientCode.Text
    '        '''Session("CurrEstSearchDivision") = Me.TxtDivisionCode.Text
    '        '''Session("CurrEstSearchProduct") = Me.TxtProductCode.Text
    '        '''Session("CurrEstSearchJobNum") = ""
    '        '''Session("CurrEstSearchJobCompNum") = ""
    '        '''Session("CurrEstSearchEstNum") = Me.TxtEstimate.Text
    '        '''Session("CurrEstSearchEstCompNum") = ""

    '        '''MiscFN.ResponseRedirect("Estimating_Search.aspx?back=Est")

    '        Dim qs As New AdvantageFramework.Web.QueryString()

    '        With qs

    '            .ClCode = Me.TxtClientCode.Text
    '            .DivCode = Me.TxtDivisionCode.Text
    '            .PrdCode = Me.TxtProductCode.Text
    '            .JobNumber = 0
    '            .JobComponentNbr = 0
    '            .EstimateNumber = CType(Me.TxtEstimate.Text, Integer)
    '            .EstComponentNbr = 0
    '            .Add("backsearch", "1")
    '            .Page = "Estimating_Search.aspx"

    '        End With

    '        Me.OpenWindow("", qs.ToString(True))

    '    Catch ex As Exception

    '        Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

    '    End Try
    'End Sub

    Private Sub RadioButtonListFooterComment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonListFooterComment.SelectedIndexChanged

        FooterCommentFormatChanged()

    End Sub

    Private Sub imgbtnSpecsEst_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnSpecsEst.Click
        Try
            If Me.JobNum = 0 Then
                Me.ShowMessage("There are no specs associated with this estimate.")
                Exit Sub
            End If
            Dim strUrlSpecs As String
            If Me.CurrentQuerystring.IsJobDashboard = True Then
                strUrlSpecs = "Estimating_ImportSpecs.aspx?jd=1&EstNum=" & EstNum & "&EstComp=" & EstComp & "&JobNum=" & Me.JobNum & "&JobComp=" & Me.JobComp & "&control=" & Me.RadEditorEstimateComment.ClientID
            Else
                strUrlSpecs = "Estimating_ImportSpecs.aspx?EstNum=" & EstNum & "&EstComp=" & EstComp & "&JobNum=" & Me.JobNum & "&JobComp=" & Me.JobComp & "&control=" & Me.RadEditorEstimateComment.ClientID
            End If
            'Me.imgbtnSpecs.Attributes.Add("onclick", "window.open('" & strUrlSpecs & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=700,height=500,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")

            'Dim StrCommentsURL As String = "Estimating_FunctionComments.aspx?EstNum=" & EstNum & "&EstComp=" & EstCompNum & "&QuoteNum=" & QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&SeqNum=&JobNum=" & Me.JobNum & "&JobComp=" & Me.JobCompNum & "&SpecVer=" & Me.TxtVersion.Text & "&SpecRev=" & Me.TxtRevision.Text
            'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManagerEstimate, "ImportSpecsWindow", "", strUrlSpecs, 500, 700, True)
            Me.OpenWindow("Import Specs", strUrlSpecs, 500, 700, False, True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub imgbtnSpecsComp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnSpecsComp.Click
        Try
            If Me.JobNum = 0 Then
                Me.ShowMessage("There are no specs associated with this estimate.")
                Exit Sub
            End If
            Dim strUrlSpecs As String
            If Me.CurrentQuerystring.IsJobDashboard = True Then
                strUrlSpecs = "Estimating_ImportSpecs.aspx?jd=1&EstNum=" & EstNum & "&EstComp=" & EstComp & "&JobNum=" & Me.JobNum & "&JobComp=" & Me.JobComp & "&control=" & Me.RadEditorComponentComment.ClientID
            Else
                strUrlSpecs = "Estimating_ImportSpecs.aspx?EstNum=" & EstNum & "&EstComp=" & EstComp & "&JobNum=" & Me.JobNum & "&JobComp=" & Me.JobComp & "&control=" & Me.RadEditorComponentComment.ClientID
            End If

            'Me.imgbtnSpecs.Attributes.Add("onclick", "window.open('" & strUrlSpecs & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=700,height=500,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")

            'Dim StrCommentsURL As String = "Estimating_FunctionComments.aspx?EstNum=" & EstNum & "&EstComp=" & EstCompNum & "&QuoteNum=" & QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&SeqNum=&JobNum=" & Me.JobNum & "&JobComp=" & Me.JobCompNum & "&SpecVer=" & Me.TxtVersion.Text & "&SpecRev=" & Me.TxtRevision.Text
            'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManagerEstimate, "ImportSpecsWindow", "", strUrlSpecs, 500, 700, True)
            Me.OpenWindow("ImportS pecs", strUrlSpecs, 500, 700, False, True)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Functions "

    Private Sub FooterCommentFormatChanged()

        Try

            Select Case Me.RadioButtonListFooterComment.SelectedValue
                Case "default"

                    Me.TextBoxFooterCommentDefault.Visible = True
                    Me.TextBoxFooterCommentStandard.Visible = False
                    Me.RadEditorFooterCommentCustom.Visible = False

                Case "standard"

                    Me.TextBoxFooterCommentDefault.Visible = False
                    Me.TextBoxFooterCommentStandard.Visible = True
                    Me.RadEditorFooterCommentCustom.Visible = False

                Case "custom"

                    Me.TextBoxFooterCommentDefault.Visible = False
                    Me.TextBoxFooterCommentStandard.Visible = False
                    Me.RadEditorFooterCommentCustom.Visible = True

            End Select

        Catch ex As Exception

        End Try

    End Sub
    Private Sub SaveEstimateInformation(ByRef save As String)

        'objects
        Dim sComment As String = ""
        Dim sCommentHtml As String = ""
        Dim ds As DataSet
        Dim approved As Boolean = False

        Try

            Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))

            Select Case Me.RadioButtonListFooterComment.SelectedValue
                Case "default"

                    sComment = "Agency Defined"
                    sCommentHtml = "Agency Defined"

                Case "standard"

                    sComment = "Standard Comment"
                    sCommentHtml = "Standard Comment"

                Case "custom"

                    If Me.RadEditorFooterCommentCustom.Text.Trim <> Me.TextBoxFooterCommentDefault.Text.Trim AndAlso Me.RadEditorFooterCommentCustom.Text.Trim <> Me.TextBoxFooterCommentStandard.Text.Trim Then

                        sComment = Me.RadEditorFooterCommentCustom.Text.Replace(vbCrLf, "<br />")
                        sCommentHtml = Me.RadEditorFooterCommentCustom.Html

                    Else

                        sComment = ""
                        sCommentHtml = ""

                    End If

            End Select

            If Me.TxtCampaignCode.Text = "" Then
                Me.HiddenfieldCampaignID.Value = "0"
            End If

            If Me.TxtJobNum.Text <> "" And Me.TxtJobCompNum.Text <> "" Then
                oEstimating.UpdateEstimateInfo(Me.EstNum, Me.EstComp, Me.RadEditorComponentComment.Text, Me.RadEditorEstimateComment.Text, 0, Me.TxtSalesClassCode.Text, Me.txtMarkupPercent.Text,
                                           Me.HfContactCodeID.Value, Me.TxtEstimateDescription.Text, Me.TxtEstimateComponentDescription.Text, sComment, Me.RadEditorEstimateComment.Html, sCommentHtml, Me.RadEditorComponentComment.Html)
            Else

                Dim dr2 As SqlDataReader
                Dim dr3 As SqlDataReader
                Dim dt As DataTable
                Dim cmpid As Integer = 0
                Dim cmpcode As String = ""

                dr2 = oEstimating.GetApprovals(Me.EstNum, Me.EstComp, "CMP")
                dr3 = oEstimating.GetInternalApprovals(Me.EstNum, Me.EstComp, "CMP")

                If (dr2.HasRows = True Or dr3.HasRows = True) Then
                    approved = True
                End If

                dt = oEstimating.GetEstimateData(Me.EstNum, Me.EstComp, 0, 0, Session("UserCode"))
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows(0)("EST_CMP_ID")) = False Then
                        cmpid = dt.Rows(0)("EST_CMP_ID")
                    End If
                    If IsDBNull(dt.Rows(0)("EST_CMP_CODE")) = False Then
                        cmpcode = dt.Rows(0)("EST_CMP_CODE")
                    End If
                End If

                If Me.HiddenfieldCampaignID.Value <> cmpid.ToString Then
                    If approved = True Then
                        Me.ShowMessage("Campaign cannot be changed on approved estimate.")
                        Exit Sub
                    End If
                    oEstimating.UpdateEstimateInfo(Me.EstNum, Me.EstComp, Me.RadEditorComponentComment.Text, Me.RadEditorEstimateComment.Text, Me.HiddenfieldCampaignID.Value, Me.TxtSalesClassCode.Text, Me.txtMarkupPercent.Text,
                                               Me.HfContactCodeID.Value, Me.TxtEstimateDescription.Text, Me.TxtEstimateComponentDescription.Text, sComment, Me.RadEditorEstimateComment.Html, sCommentHtml, Me.RadEditorComponentComment.Html)
                    'ElseIf Me.TxtCampaignCode.Text <> cmpcode Then
                    '    If approved = True Then
                    '        Me.ShowMessage("Campaign cannot be changed on approved estimate.")
                    '        Exit Sub
                    '    End If
                    '    oEstimating.UpdateEstimateInfo(Me.EstNum, Me.EstComp, Me.RadEditorComponentComment.Text, Me.RadEditorEstimateComment.Text, Me.HiddenfieldCampaignID.Value, Me.TxtSalesClassCode.Text, Me.txtMarkupPercent.Text, _
                    '                               Me.HfContactCodeID.Value, Me.TxtEstimateDescription.Text, Me.TxtEstimateComponentDescription.Text, sComment, Me.RadEditorEstimateComment.Html, sCommentHtml, Me.RadEditorComponentComment.Html)
                Else
                    oEstimating.UpdateEstimateInfo(Me.EstNum, Me.EstComp, Me.RadEditorComponentComment.Text, Me.RadEditorEstimateComment.Text, Me.HiddenfieldCampaignID.Value, Me.TxtSalesClassCode.Text, Me.txtMarkupPercent.Text,
                                               Me.HfContactCodeID.Value, Me.TxtEstimateDescription.Text, Me.TxtEstimateComponentDescription.Text, sComment, Me.RadEditorEstimateComment.Html, sCommentHtml, Me.RadEditorComponentComment.Html)

                End If

            End If



        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaveJobInformation()
        Try
            Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            Dim JobNumber As Integer
            Dim JobComponentNumber As Integer
            Dim dt As DataTable
            Dim ds As DataSet
            Dim approved As Boolean = False

            Dim dr2 As SqlDataReader
            Dim dr3 As SqlDataReader
            dr2 = oEstimating.GetApprovals(Me.EstNum, Me.EstComp, "")
            dr3 = oEstimating.GetInternalApprovals(Me.EstNum, Me.EstComp, "")

            If (dr2.HasRows = True Or dr3.HasRows = True) Then
                approved = True
            End If


            If Me.TxtJobNum.Text <> "" And Me.TxtJobCompNum.Text <> "" Then
                dt = oEstimating.GetEstimateData(Me.EstNum, Me.EstComp, 0, 0, Session("UserCode"))
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows(0)("JOB_NUMBER")) = False Then
                        JobNumber = dt.Rows(0)("JOB_NUMBER")
                    End If
                    If IsDBNull(dt.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                        JobComponentNumber = dt.Rows(0)("JOB_COMPONENT_NBR")
                    End If
                    oEstimating.UpdateJobEstimate(JobNumber, JobComponentNumber, 0, 0)
                End If
                JobNumber = CInt(Me.TxtJobNum.Text)
                JobComponentNumber = CInt(Me.TxtJobCompNum.Text)
                oEstimating.UpdateJobEstimate(JobNumber, JobComponentNumber, Me.EstNum, Me.EstComp)
            Else
                If approved = True Then
                    Me.ShowMessage("Job and Component cannot be changed on approved estimate.")
                    Exit Sub
                End If
                dt = oEstimating.GetEstimateData(Me.EstNum, Me.EstComp, Me.JobNum, Me.JobComp, Session("UserCode"))
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows(0)("JOB_NUMBER")) = False Then
                        JobNumber = dt.Rows(0)("JOB_NUMBER")
                    End If
                    If IsDBNull(dt.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                        JobComponentNumber = dt.Rows(0)("JOB_COMPONENT_NBR")
                    End If
                End If
                oEstimating.UpdateJobEstimate(JobNumber, JobComponentNumber, 0, 0)
                Dim SessionKey As String = "JobComponentCount" & EstNum.ToString.PadLeft(6, "0")
                HttpContext.Current.Session(SessionKey) = 0
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub reloadForm()
        Try
            If Me.ReloadMe = True Then
                If Me.DelEstimate = True Then
                    Session("EstimateDelEstimate") = 1
                End If
                If Me.DelQuote = True Then
                    Session("EstimateDelQuote") = 1
                End If
                If Me.DelComp = True Then
                    Session("EstimateDelComp") = 1
                End If
                MiscFN.ResponseRedirect("Estimating.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckUserRights()
        Try
            Dim sec As New cSecurity(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim secView As String
            Dim secEdit As String
            Dim secInsert As String

            secView = IIf(Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.ProjectManagement_Estimating), "Y", "N")
            secEdit = IIf(Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.ProjectManagement_Estimating), "Y", "N")
            secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_Estimating), "Y", "N")

            If secView = "N" Then
                Me.RadToolbarEstimate.FindItemByValue("Print").Enabled = False
            End If
            If secEdit = "N" And secInsert = "N" Then
                Me.RadToolbarEstimate.FindItemByValue("SaveAll").Enabled = False
                Me.RadToolbarEstimate.FindItemByValue("Copy").Enabled = False
                Me.RadToolbarEstimate.FindItemByValue("NewEstimate").Enabled = False
                Me.RadToolbarEstimate.FindItemByValue("NewComp").Enabled = False
                Me.RadToolbarEstimate.FindItemByValue("DelEst").Enabled = False
                Me.RadToolbarEstimate.FindItemByValue("DelComp").Enabled = False

                Me.RadToolbarEstimate.FindItemByValue("CreateJob").Enabled = False
                Me.TxtJobNum.ReadOnly = True
                Me.TxtJobCompNum.ReadOnly = True
                Me.HlJob.Attributes.Add("onclick", "")
                Me.HlJob.Enabled = False
                Me.HlComponent.Attributes.Add("onclick", "")
                Me.HlComponent.Enabled = False
                Me.TxtEstimateDescription.ReadOnly = True
                Me.TxtEstimateComponentDescription.ReadOnly = True
                Me.RadEditorEstimateComment.Enabled = False
                Me.RadEditorComponentComment.Enabled = False

                Me.TextBoxFooterCommentDefault.ReadOnly = True
                Me.TextBoxFooterCommentStandard.ReadOnly = True
                Me.RadEditorFooterCommentCustom.Enabled = False
                Me.RadioButtonListFooterComment.Enabled = False

                Me.TxtCampaignCode.ReadOnly = True
                Me.TxtContactCode.ReadOnly = True
                Me.txtMarkupPercent.ReadOnly = True
                Me.TxtSalesClassCode.ReadOnly = True
                Me.HlContact.Attributes.Add("onclick", "")
                Me.HlContact.Enabled = False
                Me.HlSalesClass.Attributes.Add("onclick", "")
                Me.HlSalesClass.Enabled = False
                Me.HlSalesClass.Visible = False
                Me.LabelSalesClass.Visible = True
                If Me.PanelEstimateQuote.Visible = True Then
                    Me.RadToolbarEstimateGrid.FindItemByValue("NewQuote").Enabled = False
                    Me.RadToolbarEstimateGrid.FindItemByValue("DelQuote").Enabled = False
                    Me.RadToolbarEstimateGrid.FindItemByValue("CopyQuote").Enabled = False
                End If
                If Me.PanelVendorRequest.Visible = True Then
                    Me.RadToolbarVendorGrid.FindItemByValue("NewRequest").Enabled = False
                    Me.RadToolbarVendorGrid.FindItemByValue("DelRequest").Enabled = False
                    Me.RadToolbarVendorGrid.FindItemByValue("CopyRequest").Enabled = False
                End If
            ElseIf secEdit = "Y" And secInsert = "N" Then
                Me.RadToolbarEstimate.FindItemByValue("Copy").Enabled = False
                Me.RadToolbarEstimate.FindItemByValue("NewEstimate").Enabled = False
                Me.RadToolbarEstimate.FindItemByValue("NewComp").Enabled = False

                If Me.PanelEstimateQuote.Visible = True Then
                    Me.RadToolbarEstimateGrid.FindItemByValue("NewQuote").Enabled = False
                    Me.RadToolbarEstimateGrid.FindItemByValue("CopyQuote").Enabled = False
                End If
                If Me.PanelVendorRequest.Visible = True Then
                    Me.RadToolbarVendorGrid.FindItemByValue("NewRequest").Enabled = False
                    Me.RadToolbarVendorGrid.FindItemByValue("CopyRequest").Enabled = False
                End If
            ElseIf secEdit = "N" And secInsert = "Y" Then
                Me.RadToolbarEstimate.FindItemByValue("SaveAll").Enabled = False
                Me.RadToolbarEstimate.FindItemByValue("DelEst").Enabled = False
                Me.RadToolbarEstimate.FindItemByValue("DelComp").Enabled = False

                Me.RadToolbarEstimate.FindItemByValue("CreateJob").Enabled = False
                Me.TxtJobNum.ReadOnly = True
                Me.TxtJobCompNum.ReadOnly = True
                Me.HlJob.Attributes.Add("onclick", "")
                Me.HlJob.Enabled = False
                Me.HlComponent.Attributes.Add("onclick", "")
                Me.HlComponent.Enabled = False
                Me.TxtEstimateDescription.ReadOnly = True
                Me.TxtEstimateComponentDescription.ReadOnly = True
                Me.RadEditorEstimateComment.Enabled = False
                Me.RadEditorComponentComment.Enabled = False
                'Me.imgbtnSpecsEst.Enabled = False
                'Me.imgbtnSpecsComp.Enabled = False
                Me.TextBoxFooterCommentDefault.ReadOnly = True
                Me.TextBoxFooterCommentStandard.ReadOnly = True
                Me.RadEditorFooterCommentCustom.Enabled = False
                Me.RadioButtonListFooterComment.Enabled = False
                Me.TxtCampaignCode.ReadOnly = True
                Me.TxtContactCode.ReadOnly = True
                Me.txtMarkupPercent.ReadOnly = True
                Me.TxtSalesClassCode.ReadOnly = True
                Me.HlContact.Attributes.Add("onclick", "")
                Me.HlContact.Enabled = False
                Me.HlSalesClass.Attributes.Add("onclick", "")
                Me.HlSalesClass.Enabled = False
                Me.HlSalesClass.Visible = False
                Me.LabelSalesClass.Visible = True
                If Me.PanelEstimateQuote.Visible = True Then
                    Me.RadToolbarEstimateGrid.FindItemByValue("DelQuote").Enabled = False
                End If
                If Me.PanelVendorRequest.Visible = True Then
                    Me.RadToolbarVendorGrid.FindItemByValue("DelRequest").Enabled = False
                End If

            End If

            secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket), "Y", "N")

            If secInsert = "N" Then

                Me.RadToolbarEstimate.FindItemByValue("CreateJob").Enabled = False
                Me.RadToolbarEstimate.FindItemByValue("CreateJob").Enabled = False

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function SaveAll() As Boolean

        Try
            Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            Dim ccID As Integer
            Dim JobNumber As Integer
            Dim JobComponentNumber As Integer
            Dim dt As DataTable
            Dim SaveMessage As String = ""
            If EstNum > 0 And EstComp > 0 Then
                If myVal.ValidateSalesClassCode(Me.TxtSalesClassCode.Text) = False Then
                    Me.ShowMessage("Please enter a valid sales class.")
                    Me.TxtSalesClassCode.Focus()
                    Return False
                End If
                If Me.TxtContactCode.Text <> "" Then
                    'If Me.HfContactCodeID.Value = "" Then
                    ccID = oEstimating.GetContactCodeID(Me.TxtContactCode.Text, Me.TxtClientCode.Text, Me.TxtDivisionCode.Text, Me.TxtProductCode.Text)
                    Me.HfContactCodeID.Value = ccID
                    dt = oEstimating.GetEstimateData(EstNum, EstComp, JobNum, JobComp, Session("UserCode"))
                    Dim cc As Integer
                    If dt.Rows.Count > 0 Then
                        If IsDBNull(dt.Rows(0)("CDP_CONTACT_ID")) = False Then
                            cc = dt.Rows(0)("CDP_CONTACT_ID")
                        Else
                            cc = -1
                        End If

                    End If
                    'End If
                    If cc <> ccID Then
                        If myVal.ValidateCDPContactEst(Me.HfContactCodeID.Value, Session("UserCode")) = False Then
                            Me.ShowMessage("Please enter a valid contact.")
                            Me.TxtContactCode.Focus()
                            Return False
                        End If
                    End If
                Else
                    Me.HfContactCodeID.Value = "0"
                End If
                If Me.txtMarkupPercent.Text <> "" Then
                    If IsNumeric(Me.txtMarkupPercent.Text) = False Then
                        Me.ShowMessage("Please enter a valid markup percent.")
                        Me.txtMarkupPercent.Focus()
                        Return False
                    End If
                End If
                If Me.TxtCampaignCode.Text <> "" And Me.TxtCampaignCode.ReadOnly = False Then
                    If myVal.ValidateCampaignEstimate(Me.TxtClientCode.Text, Me.TxtDivisionCode.Text, Me.TxtProductCode.Text, Me.TxtCampaignCode.Text) = False Then
                        Me.ShowMessage("Please enter a valid Campaign.")
                    End If
                    If myVal.ValidateCampaignIsViewable(Session("UserCode"), Me.TxtClientCode.Text, Me.TxtDivisionCode.Text, Me.TxtProductCode.Text, Me.TxtCampaignCode.Text) = False Then
                        Me.ShowMessage("Access to this campaign is denied.")
                    End If
                End If

                Me.SaveEstimateInformation(SaveMessage)

                If SaveMessage <> "" Then
                    Me.ShowMessage(SaveMessage)
                    Return False
                End If
                If Me.TxtJobNum.Text <> "" And Me.TxtJobCompNum.Text <> "" Then
                    If IsNumeric(Me.TxtJobNum.Text) Then
                        JobNumber = CInt(Me.TxtJobNum.Text)
                    Else
                        Me.ShowMessage("Please enter a valid job number.")
                        Me.TxtJobNum.Focus()
                        Return False
                    End If
                    If IsNumeric(Me.TxtJobCompNum.Text) Then
                        JobComponentNumber = CInt(Me.TxtJobCompNum.Text)
                    Else
                        Me.ShowMessage("Please enter a valid job comp number.")
                        Me.TxtJobCompNum.Focus()
                        Return False
                    End If
                    If JobNumber <= 0 Then
                        Me.ShowMessage("Please enter a valid job number.")
                        Me.TxtJobNum.Focus()
                        Return False
                    End If
                    If MiscFN.NumberInRange(JobNumber, JobComponentNumber) = False Then

                        Me.ShowMessage("Job and/or component number not in valid range!")
                        Return False

                    Else
                        If myVal.ValidateJobNumber(JobNumber) = False Then
                            Me.ShowMessage("This job does not exist!")
                            Me.TxtJobNum.Focus()
                            Return False
                        End If
                        If myVal.ValidateJobCompNumber(JobNumber, JobComponentNumber) = False Then
                            Me.ShowMessage("This is not a valid job/component!")
                            'EnableToolbarButtons(False)
                            'ResetForm()
                            Return False
                        End If
                        'is job open
                        If myVal.ValidateJobIsOpen(JobNumber, JobComponentNumber) = False Then
                            'Me.ShowMessage("This job/component is closed!")
                            'EnableToolbarButtons(False)
                            'ResetForm()
                            Return False
                        End If
                        'make sure user has access:
                        If myVal.ValidateJobCompIsViewable(Session("UserCode"), JobNumber, JobComponentNumber) = False Then
                            'Me.ShowMessage("This job/comp is denied.")
                            'EnableToolbarButtons(False)
                            Return False
                        End If
                    End If
                Else
                    JobNumber = 0
                    JobComponentNumber = 0
                End If
                Dim dr As SqlClient.SqlDataReader
                Dim dr2 As SqlClient.SqlDataReader
                Dim ojob As New Job(Session("ConnString"))
                Dim currentJobEstNum As Integer = 0
                Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                If JobNumber > 0 And JobComponentNumber > 0 Then
                    dr = est.GetEstJob(JobNumber, JobComponentNumber)
                    dr.Read()
                    If dr("ESTIMATE_NUMBER") > 0 And dr("EST_COMPONENT_NBR") > 0 Then
                        If (CInt(Me.TxtEstimate.Text) <> dr("ESTIMATE_NUMBER") And CInt(Me.TxtEstimateComponent.Text) <> dr("EST_COMPONENT_NBR")) Or (CInt(Me.TxtEstimate.Text) = dr("ESTIMATE_NUMBER") And CInt(Me.TxtEstimateComponent.Text) <> dr("EST_COMPONENT_NBR")) Then
                            Me.ShowMessage("This is not a valid job/component for this estimate.")
                            Return False
                        End If
                    End If
                    dr.Close()
                    dr2 = est.GetEstimateNumJob(JobNumber)
                    If dr2.HasRows = True Then
                        Do While dr2.Read
                            If dr2("ESTIMATE_NUMBER") > 0 Then
                                If CInt(Me.TxtEstimate.Text) <> dr2("ESTIMATE_NUMBER") Then
                                    Me.ShowMessage("This is not a valid job/component for this estimate.")
                                    'currentJobEstNum = dr2("ESTIMATE_NUMBER")
                                    Return False
                                End If
                            End If
                        Loop
                    End If
                    dr2.Close()
                    ojob.GetJob(JobNumber, JobComponentNumber)
                    If Me.TxtSalesClassCode.Text <> ojob.SC_CODE Then
                        Me.ShowMessage("This is not a valid job/component for this estimate.")
                        Return False
                    End If
                End If
                Me.SaveJobInformation()
                'End If      
                Me.GetEstimateData(Me.EstNum, Me.EstComp, Me.JobNum, Me.JobComp)
                Me.LoadLookups()
                Return True
            End If
        Catch ex As Exception
            Me.ShowMessage("Error saving.\n" & ex.Message.ToString())
            Return False
        End Try
    End Function

    Private Sub SetContentPageData()

        Dim cpd As New AdvantageFramework.Web.Classes.ContentPageData

        If cpd.Load() = True Then

            If IsNumeric(Me.TxtEstimate.Text) = True Then cpd.EstimateNumber = CType(Me.TxtEstimate.Text, Integer)
            If IsNumeric(Me.TxtEstimateComponent.Text) = True Then cpd.EstimateComponentNumber = CType(Me.TxtEstimateComponent.Text, Integer)
            cpd.EstimatePrintSendAll = Me.PrintSendAllCheckbox.Checked
            cpd.EstimateSelectedQuoteNumbers = Me.GetSelectedQuoteNumbersAsString()
            cpd.EstimateSelectedQuoteDescriptions = Me.GetSelectedQuoteDescriptionsAsString()

            cpd.Save()

        End If

    End Sub



#End Region


End Class
