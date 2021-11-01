Imports System.Data.SqlClient
Imports Webvantage.cGlobals
Imports Webvantage.wvTimeSheet
Partial Public Class Estimating_AddNewComponent
    Inherits Webvantage.BaseChildPage

#Region " Variables and Properties "
    Public JobNum As Integer = 0
    Public JobCompNum As Integer = 0
    Public EstNum As Integer = 0
    Public EstComp As Integer = 0
    Public IsValidEstAndComp As Boolean
#End Region

#Region " Page "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Estimating)
        If Not Page.IsPostBack Then
            IsValidEstAndComp = SetEstAndComp()
            LoadEstimateData()
            LoadLookups()
            'MiscFN.AddCalendarToTB(Me.TxtStartDate)
            'MiscFN.AddCalendarToTB(Me.TxtDueDate)
            'MiscFN.AddCalendarIcon(Me.TxtStartDate, Me.LitStartCal)
            'MiscFN.AddCalendarIcon(Me.TxtDueDate, Me.LitDueCal)
            ' Me.cbRecalculate.Checked = True
        End If
    End Sub

#End Region

#Region " Grid "

    Private Sub RadGridEstCompCopy_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridEstCompCopy.ItemDataBound
        Try
            If TypeOf e.Item Is Telerik.Web.UI.GridGroupHeaderItem Then
                Dim item As Telerik.Web.UI.GridGroupHeaderItem = CType(e.Item, Telerik.Web.UI.GridGroupHeaderItem)
                Dim groupDataRow As DataRowView = CType(e.Item.DataItem, DataRowView)
                item.DataCell.Text = "Component: " + groupDataRow("EST_COMPONENT_NBR").ToString() +
                                     " - " + groupDataRow("EST_COMP_DESC").ToString()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridEstCompCopy_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridEstCompCopy.NeedDataSource
        Try
            Dim est As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))
            Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
            Dim drEst As SqlDataReader = est.CheckJobNumberEstimateDR(Me.TxtEstimateSource.Text)
            If drEst.HasRows Then
                drEst.Read()
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, drEst("JOB_NUMBER"))
                    If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, drEst("JOB_NUMBER")) = False AndAlso
                            AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                        Me.ShowMessage("Access to this Estimate is denied.\n.")
                        Exit Sub
                    End If
                End Using
            End If
            drEst.Close()
            Me.RadGridEstCompCopy.DataSource = est.GetInfoForEstimateCopy(Me.TxtEstimateSource.Text)
            Me.SetGridSort("Comp")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetGridSort(ByVal StrSort As String)
        Try
            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
            Dim gbf As Telerik.Web.UI.GridGroupByField
            Select Case StrSort
                Case "Comp"
                    gbf = New Telerik.Web.UI.GridGroupByField
                    gbf.FieldName = "EST_COMPONENT_NBR"
                    gbf.HeaderText = "Component"
                    GrpExpr.SelectFields.Add(gbf)
                    gbf = New Telerik.Web.UI.GridGroupByField
                    gbf.FieldName = "EST_COMP_DESC"
                    gbf.HeaderText = "Desc"
                    GrpExpr.SelectFields.Add(gbf)
                    gbf = New Telerik.Web.UI.GridGroupByField
                    gbf.FieldName = "EST_COMPONENT_NBR"
                    GrpExpr.GroupByFields.Add(gbf)
                    'GrpExpr = Telerik.Web.UI.GridGroupByExpression.Parse("EST_COMPONENT_NBR Component Group By EST_COMPONENT_NBR")
                    With Me.RadGridEstCompCopy
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True
                        '.MasterTableView.GetColumn("colPHASE_DESC").Display = False
                    End With
                Case Else
                    Me.RadGridEstCompCopy.MasterTableView.GroupByExpressions.Clear()
            End Select
            'Session("EstimateGridSort") = StrSort
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Controls "

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Try
            If IsNumeric(Request.QueryString("EstNum")) = True Then
                EstNum = CType(Request.QueryString("EstNum"), Integer)
            Else
                EstNum = 0
            End If
        Catch ex As Exception
            JobNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("EstComp")) = True Then
                EstComp = CType(Request.QueryString("EstComp"), Integer)
            Else
                EstComp = 0
            End If
        Catch ex As Exception
            EstComp = 0
        End Try

        Dim CameFromJobTemplate As Boolean = False
        Try
            If Not Request.QueryString("JT") = Nothing Then
                If Request.QueryString("JT") = "1" Then
                    CameFromJobTemplate = True
                Else
                    CameFromJobTemplate = False
                End If
            End If
        Catch ex As Exception
            CameFromJobTemplate = False
        End Try
        If Me.CurrentQuerystring.IsJobDashboard = True Then
            MiscFN.ResponseRedirect("Estimating.aspx?EstNum=" & EstNum & "&EstComp=" & EstComp & "&newEst=edit", True)
        Else
            If CameFromJobTemplate = False Then
                Me.CloseThisWindowAndOpenNewWindow("Estimating.aspx?EstNum=" & EstNum & "&EstComp=" & EstComp & "&newEst=edit")
            End If
        End If
    End Sub

    Private Sub BtnCreateEstimateComp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCreateEstimateComp.Click
        Dim ErrMSG As String = ""
        Dim ThisJobNum As Integer = 0
        Dim ThisJobCompNum As Integer = 0
        Dim ThisStartDate As String = ""
        Dim ThisDueDate As String = ""
        Dim ThisSalesClass As String = ""
        Dim ThisPresetCode As String = ""
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim s As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))

        'If Me.TxtClientCode.Text = "" Then
        '    ErrMSG &= "Client Code is required."
        'End If
        'If Me.TxtDivisionCode.Text = "" Then
        '    ErrMSG &= "Division Code is required."
        'End If
        'If Me.TxtProductCode.Text = "" Then
        '    ErrMSG &= "Product Code is required."
        'End If
        'If Me.TxtSalesClass.Text = "" Then
        '    ErrMSG &= "Sales Class is required."
        'End If
        'If Me.TxtEstimateDescription.Text = "" Then
        '    ErrMSG &= "Estimate Description is required."
        'End If
        If Me.txtEstimateCompDescription.Text = "" Then
            ErrMSG &= "Estimate Component Description is required."
        End If

        If Me.TxtJobNum.Text <> "" Then
            If IsNumeric(Me.TxtJobNum.Text) = False Then
                ErrMSG &= "Please enter a valid job number.\n"
            Else
                Try
                    ThisJobNum = CType(Me.TxtJobNum.Text, Integer)
                Catch ex As Exception
                    ThisJobNum = 0
                End Try
            End If
        End If
        If Me.TxtJobCompNum.Text <> "" Then
            If IsNumeric(Me.TxtJobCompNum.Text) = False Then
                ErrMSG &= "Please enter a valid component number.\n"
            Else
                Try
                    ThisJobCompNum = CType(Me.TxtJobCompNum.Text, Integer)
                Catch ex As Exception
                    ThisJobCompNum = 0
                End Try
            End If
        End If

        'If myVal.ValidateCDP(Me.TxtClientCode.Text.Trim, "", "", True) = False Then
        '    ErrMSG &= "Invalid Client!"
        '    'Exit Sub
        'End If
        'If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.TxtClientCode.Text.Trim, "", "") = False Then
        '    ErrMSG &= "Access to this client is denied."
        '    'Exit Sub
        'End If
        'If myVal.ValidateCDP(Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, "", True) = False Then
        '    ErrMSG &= "Invalid Client, Division!"
        '    Exit Sub
        'End If
        'If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, "") = False Then
        '    ErrMSG &= "Access to this division is denied."
        '    Exit Sub
        'End If
        'If myVal.ValidateCDP(Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, Me.TxtProductCode.Text.Trim, True) = False Then
        '    ErrMSG &= "Invalid Client, Division, Product!"
        '    Exit Sub
        'End If
        'If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, Me.TxtProductCode.Text.Trim) = False Then
        '    ErrMSG &= "Access to this product is denied."
        '    Exit Sub
        'End If
        'Some basic job validation:
        If ThisJobNum > 0 And ThisJobCompNum > 0 Then
            If myVal.ValidateJobNumber(ThisJobNum) = False Then
                ErrMSG &= "This job does not exist!\n"
            End If
            If myVal.ValidateJobCompNumber(ThisJobNum, ThisJobCompNum) = False Then
                ErrMSG &= "This is not a valid job/component!\n"
            End If
        End If

        If ErrMSG <> "" Then
            Me.ShowMessage(ErrMSG)
            Exit Sub
        End If

        If ThisJobNum > 0 And ThisJobCompNum > 0 Then
            If myVal.ValidateJobIsOpen(ThisJobNum, ThisJobCompNum) = False Then
                ErrMSG &= "This job/comp is closed.\n"
            End If
            If myVal.ValidateJobCompIsViewable(Session("UserCode"), ThisJobNum, ThisJobCompNum) = False Then
                ErrMSG &= "Access to this job/comp is denied.\n"
            End If
            If myVal.ValidateJobCompIsEditable(ThisJobNum, ThisJobCompNum, True) = False Then
                ErrMSG &= "Job/comp process control does not allow access.\n"
            End If
        End If



        '''Try
        '''    Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        '''    Dim x As Integer = oTrafficSchedule.CheckExistsClosed(Me.TxtJobNum.Text, Me.TxtJobCompNum.Text)
        '''    Select Case x
        '''        Case 0
        '''            ErrMSG &= "Schedule exists.\n"
        '''        Case -2
        '''            ErrMSG &= "Schedule is completed and cannot be viewed.\n"
        '''    End Select
        '''Catch ex As Exception
        '''End Try
        Dim dr As SqlClient.SqlDataReader
        Dim dr2 As SqlClient.SqlDataReader
        If ThisJobNum > 0 And ThisJobCompNum > 0 Then
            dr = s.GetEstJob(ThisJobNum, ThisJobCompNum)
            dr.Read()
            If dr("ESTIMATE_NUMBER") > 0 And dr("EST_COMPONENT_NBR") > 0 Then
                ErrMSG &= "This is not a valid job/component for this new estimate component.\n"
            End If
            dr.Close()
            dr2 = s.CheckJobNumberEstimateDR(CType(Request.QueryString("EstNum"), Integer))
            Do While dr2.Read
                If dr2("JOB_NUMBER") > 0 Then
                    If dr2("JOB_NUMBER") <> ThisJobNum Then
                        ErrMSG &= "This is not a valid job/component for this new estimate component.\n"
                        Exit Do
                    Else
                        If dr2("JOB_COMPONENT_NBR") = ThisJobCompNum Then
                            ErrMSG &= "This is not a valid job/component for this new estimate component.\n"
                            Exit Do
                        End If
                    End If
                End If
            Loop
            dr2.Close()
        End If


        If ErrMSG <> "" Then
            Me.ShowMessage(ErrMSG)
            Exit Sub
        End If


        'If Me.DropPreset.SelectedIndex > 0 Then
        '    ThisPresetCode = Me.DropPreset.SelectedValue
        'End If


        Try
            Dim j As Job = New Job(Session("ConnString"))
            Dim contactID As Integer
            If ThisJobNum > 0 And ThisJobCompNum > 0 Then
                j.GetJob(ThisJobNum, ThisJobCompNum)
                contactID = j.JobComponent.CDP_CONTACT_ID
            Else
                If Request.QueryString("cdpcontact") <> "" Then
                    contactID = Request.QueryString("cdpcontact")
                End If
            End If

            Dim EstCompNumber As Integer = 0
            EstCompNumber = s.AddNewEstimateComponent(Me.txtEstimate.Text, contactID, Me.txtEstimateCompDescription.Text)
            If EstCompNumber > 0 Then
                If ThisJobNum > 0 And ThisJobCompNum > 0 Then
                    s.UpdateJobEstimate(ThisJobNum, ThisJobCompNum, Me.txtEstimate.Text, EstCompNumber)
                End If
            End If
            Dim CameFromJobTemplate As Boolean = False
            'Try
            '    If Not Request.QueryString("JT") = Nothing Then
            '        If Request.QueryString("JT") = "1" Then
            '            CameFromJobTemplate = True
            '        Else
            '            CameFromJobTemplate = False
            '        End If
            '    End If
            'Catch ex As Exception
            '    CameFromJobTemplate = False
            'End Try
            If Me.CurrentQuerystring.IsJobDashboard = True Then
                MiscFN.ResponseRedirect("Estimating.aspx?EstNum=" & Me.txtEstimate.Text & "&EstComp=" & EstCompNumber & "&newEst=newcomp", True)
            Else
                If CameFromJobTemplate = True Then

                Else
                    Me.CloseThisWindowAndOpenNewWindow("Estimating.aspx?EstNum=" & Me.txtEstimate.Text & "&EstComp=" & EstCompNumber & "&newEst=newcomp", True)
                End If
            End If

        Catch ex As Exception
            'Me.ShowMessage("Error creating new schedule."))
        End Try


    End Sub

    Private Sub btnCopyComponent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopyComponent.Click
        Try
            Dim ErrMSG As String = ""
            Dim ThisJobNum As Integer = 0
            Dim ThisJobCompNum As Integer = 0
            Dim recalculate As Integer = 0
            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            If Me.txtEstimateCompDescription.Text = "" Then
                ErrMSG &= "Estimate Component Description is required."
            End If
            If ErrMSG <> "" Then
                Me.ShowMessage(ErrMSG)
                Exit Sub
            End If
            If Me.TxtJobNum.Text <> "" Then
                If IsNumeric(Me.TxtJobNum.Text) = False Then
                    ErrMSG &= "Please enter a valid job number.\n"
                Else
                    Try
                        ThisJobNum = CType(Me.TxtJobNum.Text, Integer)
                    Catch ex As Exception
                        ThisJobNum = 0
                    End Try
                End If
            End If
            If Me.TxtJobCompNum.Text <> "" Then
                If IsNumeric(Me.TxtJobCompNum.Text) = False Then
                    ErrMSG &= "Please enter a valid component number.\n"
                Else
                    Try
                        ThisJobCompNum = CType(Me.TxtJobCompNum.Text, Integer)
                    Catch ex As Exception
                        ThisJobCompNum = 0
                    End Try
                End If
            End If

            If ErrMSG <> "" Then
                Me.ShowMessage(ErrMSG)
                Exit Sub
            End If

            'Some basic job validation:
            If ThisJobNum > 0 And ThisJobCompNum > 0 Then
                If myVal.ValidateJobIsOpen(ThisJobNum, ThisJobCompNum) = False Then
                    ErrMSG &= "This job/comp is closed.\n"
                End If
                If myVal.ValidateJobCompIsViewable(Session("UserCode"), ThisJobNum, ThisJobCompNum) = False Then
                    ErrMSG &= "Access to this job/comp is denied.\n"
                End If
                If myVal.ValidateJobCompIsEditable(ThisJobNum, ThisJobCompNum, True) = False Then
                    ErrMSG &= "Job/comp process control does not allow access.\n"
                End If
            End If

            If ErrMSG <> "" Then
                Me.ShowMessage(ErrMSG)
                Exit Sub
            End If

            Dim est As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))
            Dim chkbox As CheckBox
            Dim items As Boolean = False
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstCompCopy.MasterTableView.Items
                chkbox = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                If chkbox.Checked = True Then
                    items = True
                End If
            Next

            If items = False Then
                Me.ShowMessage("No Components/Quotes Selected for Copy.")
                Exit Sub
            End If

            If Me.cbRecalculate.Checked = True Then
                recalculate = 1
            End If

            Dim j As Job = New Job(Session("ConnString"))
            Dim contactID As Integer
            If ThisJobNum > 0 And ThisJobCompNum > 0 Then
                j.GetJob(ThisJobNum, ThisJobCompNum)
                contactID = j.JobComponent.CDP_CONTACT_ID
            Else
                If Request.QueryString("cdpcontact") <> "" Then
                    contactID = Request.QueryString("cdpcontact")
                End If
            End If

            Dim chk As CheckBox
            Dim comp As Integer = 0
            Dim newComp As Integer = 0
            Dim quoteNum As Integer = 0
            Dim revNum As Integer = 0
            Dim save As Boolean
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstCompCopy.MasterTableView.Items
                chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                If chk.Checked = True Then
                    Try
                        quoteNum = CInt(gridDataItem("colEST_QUOTE_NBR").Text.Replace("&nbsp;", ""))
                    Catch ex As Exception
                        quoteNum = 0
                    End Try
                    If comp <> gridDataItem.GetDataKeyValue("EST_COMPONENT_NBR") Then
                        comp = gridDataItem.GetDataKeyValue("EST_COMPONENT_NBR")
                        newComp = est.AddNewEstimateComponentCopy(Me.txtEstimate.Text, Me.TxtEstimateSource.Text, comp, Me.txtEstimateCompDescription.Text, ThisJobNum, ThisJobCompNum, contactID)
                        revNum = est.GetEstimateQuoteMaxRevision(Me.TxtEstimateSource.Text, comp, quoteNum)
                        save = est.AddNewQuoteCopy(Me.txtEstimate.Text, newComp, Me.TxtEstimateSource.Text, comp, quoteNum, revNum, recalculate)
                    Else
                        revNum = est.GetEstimateQuoteMaxRevision(Me.TxtEstimateSource.Text, comp, quoteNum)
                        save = est.AddNewQuoteCopy(Me.txtEstimate.Text, newComp, Me.TxtEstimateSource.Text, comp, quoteNum, revNum, recalculate)
                    End If

                End If
            Next
            If Me.CurrentQuerystring.IsJobDashboard = True Then
                MiscFN.ResponseRedirect("Estimating.aspx?EstNum=" & Me.txtEstimate.Text & "&EstComp=" & newComp & "&newEst=new", True)
            Else
                Me.CloseThisWindowAndOpenNewWindow("Estimating.aspx?EstNum=" & Me.txtEstimate.Text & "&EstComp=" & newComp & "&newEst=new", False)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCompQuote_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCompQuote.Click
        Try
            Dim DtEstAndComp As DataTable
            Dim est As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))
            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
            If Me.TxtEstimateSource.Text = "" Then
                Me.ShowMessage("Please enter a valid Estimate number.")
                Me.TxtEstimateSource.Focus()
                Exit Sub
            End If
            If myVal.ValidateEstimateNumber(Me.TxtEstimateSource.Text) = False Then
                Me.ShowMessage("This estimate does not exist!")
                Me.TxtEstimateSource.Focus()
                Exit Sub
            End If
            If Me.TxtEstimateSource.Text <> "" Then
                Dim drEst As SqlDataReader = est.CheckJobNumberEstimateDR(Me.TxtEstimateSource.Text)
                If drEst.HasRows Then
                    drEst.Read()
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, drEst("JOB_NUMBER"))
                        If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, drEst("JOB_NUMBER")) = False AndAlso
                            AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                            Me.ShowMessage("Access to this Estimate is denied.\n.")
                            Exit Sub
                        End If
                    End Using
                End If
                drEst.Close()
                If IsNumeric(Me.TxtEstimateSource.Text) Then
                    DtEstAndComp = est.GetInfoForEstimateCopy(CInt(Me.TxtEstimateSource.Text))
                    If DtEstAndComp.Rows.Count > 0 Then
                        If Me.txtEstimateCompDescription.Text = "" Then
                            If IsDBNull(DtEstAndComp.Rows(0)("EST_COMP_DESC")) = False Then
                                Me.txtEstimateCompDescription.Text = DtEstAndComp.Rows(0)("EST_COMP_DESC")
                            Else
                                Me.txtEstimateCompDescription.Text = ""
                            End If
                        End If
                    End If
                End If
            End If
            Me.RadGridEstCompCopy.Rebind()
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Function SetEstAndComp() As Boolean
        Try
            If IsNumeric(Request.QueryString("EstNum")) = True Then
                EstNum = CType(Request.QueryString("EstNum"), Integer)
                Me.TxtEstimateSource.Text = EstNum
            Else
                EstNum = 0
            End If
        Catch ex As Exception
            EstNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("EstComp")) = True Then
                EstComp = CType(Request.QueryString("EstComp"), Integer)
            Else
                EstComp = 0
            End If
        Catch ex As Exception
            EstComp = 0
        End Try

        If EstNum > 0 And EstComp > 0 Then
            'Dim s As cSchedule = New cSchedule(Session("ConnString"), Session("EmpCode"))
            ''Return Not s.HasHeader(JobNum, JobCompNum)
            'Dim i As Integer = s.CheckExistsClosed(JobNum, JobCompNum)
            'If i = -2 Then
            '    Me.LblMSG.Text = "Schedule is completed and cannot be viewed."
            '    Me.PnlAddNewEstimate.Visible = False
            '    Me.PnlDontAddNewSchedule.Visible = True
            '    Return False
            'Else
            Return True
            'End If
        Else
            Return False
        End If

    End Function

    'Private Sub ShowForm()
    '    'Me.PnlAddNewSchedule.Visible = IsValidJobAndComp
    '    'Me.PnlDontAddNewSchedule.Visible = Not IsValidJobAndComp
    '    'If IsValidJobAndComp = True Then
    '    'Else
    '    '    LblMSG.Text = "Invalid job/comp."
    '    'End If
    '    If JobNum > 0 And JobCompNum > 0 Then
    '        Me.TxtJobNum.Text = JobNum
    '        Me.TxtJobCompNum.Text = JobCompNum
    '        Dim s As cSchedule = New cSchedule(Session("ConnString"), Session("EmpCode"))
    '        DtJobAndComp = s.GetBaseJobAndCompInfoDT(JobNum, JobCompNum)
    '        If DtJobAndComp.Rows.Count > 0 Then
    '            If IsDBNull(DtJobAndComp.Rows(0)("CL_CODE")) = False Then
    '                Me.TxtClientCode.Text = DtJobAndComp.Rows(0)("CL_CODE")
    '            Else
    '                Me.TxtClientCode.Text = ""
    '            End If
    '            If IsDBNull(DtJobAndComp.Rows(0)("DIV_CODE")) = False Then
    '                Me.TxtDivisionCode.Text = DtJobAndComp.Rows(0)("DIV_CODE")
    '            Else
    '                Me.TxtDivisionCode.Text = ""
    '            End If
    '            If IsDBNull(DtJobAndComp.Rows(0)("PRD_CODE")) = False Then
    '                Me.TxtProductCode.Text = DtJobAndComp.Rows(0)("PRD_CODE")
    '            Else
    '                Me.TxtProductCode.Text = ""
    '            End If
    '            If IsDBNull(DtJobAndComp.Rows(0)("JOB_DESC")) = False Then
    '                Me.TxtJobDescription.Text = DtJobAndComp.Rows(0)("JOB_DESC")
    '            Else
    '                Me.TxtJobDescription.Text = ""
    '            End If
    '            If IsDBNull(DtJobAndComp.Rows(0)("JOB_COMP_DESC")) = False Then
    '                Me.TxtJobCompDescription.Text = DtJobAndComp.Rows(0)("JOB_COMP_DESC")
    '            Else
    '                Me.TxtJobCompDescription.Text = ""
    '            End If
    '            If IsDBNull(DtJobAndComp.Rows(0)("START_DATE")) = False Then
    '                Me.TxtStartDate.Text = DtJobAndComp.Rows(0)("START_DATE")
    '            Else
    '                Me.TxtStartDate.Text = ""
    '            End If
    '            If IsDBNull(DtJobAndComp.Rows(0)("JOB_FIRST_USE_DATE")) = False Then
    '                Me.TxtDueDate.Text = DtJobAndComp.Rows(0)("JOB_FIRST_USE_DATE")
    '            Else
    '                Me.TxtDueDate.Text = ""
    '            End If

    '            'If IsDBNull(DtJobAndComp.Rows(0)("TRF_SCHEDULE_BY")) = False Then
    '            '    If DtJobAndComp.Rows(0)("TRF_SCHEDULE_BY") = "1" Then
    '            '        Me.chk()
    '            '    End If
    '            'End If


    '        End If

    '    Else
    '        Me.TxtJobNum.Focus()
    '    End If
    'End Sub    

    Private Sub LoadLookups()
        Me.HlClient.Attributes.Add("onclick", "")
        Me.HlDivision.Attributes.Add("onclick", "")
        Me.HlProduct.Attributes.Add("onclick", "")

        Me.HlClientSource.Attributes.Add("onclick", "FocusTB('" & Me.TxtClientSource.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtClientSource.ClientID & "&type=client&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value);return false;")
        Me.HlDivisionSource.Attributes.Add("onclick", "FocusTB('" & Me.TxtDivisionSource.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtDivisionSource.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value);return false;")
        Me.HlProductSource.Attributes.Add("onclick", "FocusTB('" & Me.TxtProductSource.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtProductSource.ClientID & "&type=product&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value);return false;")

        Me.HlJob.Attributes.Add("onclick", "FocusTB('" & Me.TxtJobNum.ClientID & "');clearjob();OpenRadWindowLookup('LookUp.aspx?fromest=jc&form=estimatejcsave&type=jobestimate&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.txtEstimate.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.TxtSalesClass.ClientID & ".value);return false;")
        Me.HlComponent.Attributes.Add("onclick", "Javascript:FocusTB('" & Me.TxtJobCompNum.ClientID & "');clearcomp();OpenRadWindowLookup('LookUp.aspx?fromest=jc&form=estimatejcsave&type=jobcompestimate&control=" & Me.TxtJobCompNum.ClientID & "&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.txtEstimate.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.TxtSalesClass.ClientID & ".value);return false;")
        'Me.HlJob.Attributes.Add("onclick", "FocusTB('" & Me.TxtJobNum.ClientID & "');clearjob();OpenRadWindowLookup('LookUp.aspx?form=schedulenew&type=jobschedulenew&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value);return false;")
        'Me.HlComponent.Attributes.Add("onclick", "FocusTB('" & Me.TxtJobCompNum.ClientID & "');clearcomp();OpenRadWindowLookup('LookUp.aspx?form=schedulenew&type=jobcompschedulenew&control=" & Me.TxtJobCompNum.ClientID & "&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value);return false;")
        Me.HlSalesClass.Attributes.Add("onclick", "")
        Me.hlCampaign.Attributes.Add("onclick", "")
        Me.HlEstimateSource.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatecopy&type=estimatecopy&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value + '&jobtype=' + document.forms[0]." & Me.TxtJobTypeSource.ClientID & ".value);return false;")
        Me.HlJobType.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtJobTypeSource.ClientID & "&type=jobtype');return false;")

    End Sub

    Private Sub ImgBtnGetPresetData_AddNew_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnGetPresetData_AddNew.Click
        If IsNumeric(Me.TxtJobNum.Text) = True And IsNumeric(Me.TxtJobCompNum.Text) = True Then
            Me.JobNum = CType(Me.TxtJobNum.Text, Integer)
            Me.JobCompNum = CType(Me.TxtJobCompNum.Text, Integer)
            'Me.ShowForm()
        End If
    End Sub

    Private Sub LoadEstimateData()
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim dt As New DataTable
            dt = est.GetInfoForEstimate(CInt(Request.QueryString("EstNum")))
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0)("ESTIMATE_NUMBER")) = False Then
                    Me.txtEstimate.Text = dt.Rows(0)("ESTIMATE_NUMBER")
                End If
                If IsDBNull(dt.Rows(0)("EST_LOG_DESC")) = False Then
                    Me.TxtEstimateDescription.Text = dt.Rows(0)("EST_LOG_DESC")
                End If
                If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                    Me.TxtClientCode.Text = dt.Rows(0)("CL_CODE")
                End If
                If IsDBNull(dt.Rows(0)("CL_NAME")) = False Then
                    Me.TxtClientDescription.Text = dt.Rows(0)("CL_NAME")
                End If
                If IsDBNull(dt.Rows(0)("DIV_CODE")) = False Then
                    Me.TxtDivisionCode.Text = dt.Rows(0)("DIV_CODE")
                End If
                If IsDBNull(dt.Rows(0)("DIV_NAME")) = False Then
                    Me.TxtDivisionDescription.Text = dt.Rows(0)("DIV_NAME")
                End If
                If IsDBNull(dt.Rows(0)("PRD_CODE")) = False Then
                    Me.TxtProductCode.Text = dt.Rows(0)("PRD_CODE")
                End If
                If IsDBNull(dt.Rows(0)("PRD_DESCRIPTION")) = False Then
                    Me.TxtProductDescription.Text = dt.Rows(0)("PRD_DESCRIPTION")
                End If
                If IsDBNull(dt.Rows(0)("ESTIMATE_NUMBER")) = False Then
                    Me.txtEstimate.Text = dt.Rows(0)("ESTIMATE_NUMBER")
                End If
                If IsDBNull(dt.Rows(0)("EST_LOG_DESC")) = False Then
                    Me.TxtEstimateDescription.Text = dt.Rows(0)("EST_LOG_DESC")
                End If
                If IsDBNull(dt.Rows(0)("EST_COMP_DESC")) = False Then
                    Me.txtEstimateCompDescription.Text = dt.Rows(0)("EST_COMP_DESC")
                End If
                If IsDBNull(dt.Rows(0)("SC_CODE")) = False Then
                    Me.TxtSalesClass.Text = dt.Rows(0)("SC_CODE")
                End If
                If IsDBNull(dt.Rows(0)("CMP_IDENTIFIER")) = False Then
                    Me.HiddenFieldCampaignID.Value = dt.Rows(0)("CMP_IDENTIFIER")
                End If
                If IsDBNull(dt.Rows(0)("CMP_CODE")) = False Then
                    Me.TxtCampaign.Text = dt.Rows(0)("CMP_CODE")
                End If
                If IsDBNull(dt.Rows(0)("CMP_NAME")) = False Then
                    Me.TxtCampaignDescription.Text = dt.Rows(0)("CMP_NAME")
                End If

                If HiddenFieldCampaignID.Value = "" Or HiddenFieldCampaignID.Value = "0" Then
                    Me.TrCampaign.Visible = False
                Else
                    Me.TrJob.Visible = False
                    Me.TrComponent.Visible = False
                End If

                If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                    Me.TxtClientSource.Text = dt.Rows(0)("CL_CODE")
                Else
                    Me.TxtClientSource.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("DIV_CODE")) = False Then
                    Me.TxtDivisionSource.Text = dt.Rows(0)("DIV_CODE")
                Else
                    Me.TxtDivisionSource.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("PRD_CODE")) = False Then
                    Me.TxtProductSource.Text = dt.Rows(0)("PRD_CODE")
                Else
                    Me.TxtProductSource.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("CL_NAME")) = False Then
                    Me.TxtClientSourceDesc.Text = dt.Rows(0)("CL_NAME")
                Else
                    Me.TxtClientSourceDesc.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("DIV_NAME")) = False Then
                    Me.TxtDivisionSourceDesc.Text = dt.Rows(0)("DIV_NAME")
                Else
                    Me.TxtDivisionSourceDesc.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("PRD_DESCRIPTION")) = False Then
                    Me.TxtProductSourceDesc.Text = dt.Rows(0)("PRD_DESCRIPTION")
                Else
                    Me.TxtProductSourceDesc.Text = ""
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub




End Class