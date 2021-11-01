Imports System.Data.SqlClient
Imports Webvantage.cGlobals

Partial Public Class VendorQuote_PrintSetup
    Inherits Webvantage.BaseChildPage
    Private CancelScript As String = "javascript:CallFunctionOnParentPage('HidePopUpWindows');return false;"
    'Private ThisTask_ROWID As Integer = 0
    Private ThisTask_EstNum As Integer = 0
    Private ThisTask_EstComp As Integer = 0
    Private ThisTask_QuoteNum As Integer = 0
    Private ThisTask_RevNum As Integer = 0
    Private ThisTask_SeqNum As Integer = 0
    Private JobNum As Integer = 0
    Private JobComp As Integer = 0
    Private SpecVer As Integer = 0
    Private SpecRev As Integer = 0
    Private StrDetailComments As String = ""
    Private StrSuppliedByNotes As String = ""
    Private VendorQteNbr As Integer
    Private fromgrid As String
    Private VendorCode As String
    Private FuncCode As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            ThisTask_EstNum = CType(Request.QueryString("EstNum"), Integer)
        Catch ex As Exception
            ThisTask_EstNum = 0
        End Try
        Try
            ThisTask_EstComp = CType(Request.QueryString("EstComp"), Integer)
        Catch ex As Exception
            ThisTask_EstComp = 0
        End Try
        Try
            ThisTask_QuoteNum = CType(Request.QueryString("QuoteNum"), Integer)
        Catch ex As Exception
            ThisTask_QuoteNum = 0
        End Try
        Try
            ThisTask_RevNum = CType(Request.QueryString("RevNum"), Integer)
        Catch ex As Exception
            ThisTask_RevNum = 0
        End Try
        Try
            ThisTask_SeqNum = CType(Request.QueryString("SeqNum"), Integer)
        Catch ex As Exception
            ThisTask_SeqNum = 0
        End Try
        Try
            JobNum = CType(Request.QueryString("JobNum"), Integer)
        Catch ex As Exception
            JobNum = 0
        End Try
        Try
            JobComp = CType(Request.QueryString("JobComp"), Integer)
        Catch ex As Exception
            JobComp = 0
        End Try
        Try
            SpecVer = CType(Request.QueryString("SpecVer"), Integer)
        Catch ex As Exception
            SpecVer = 0
        End Try
        Try
            SpecRev = CType(Request.QueryString("SpecRev"), Integer)
        Catch ex As Exception
            SpecRev = 0
        End Try
        Try
            VendorQteNbr = CType(Request.QueryString("reqNum"), Integer)
        Catch ex As Exception
            VendorQteNbr = 0
        End Try
        Try
            VendorCode = Request.QueryString("vncode")
        Catch ex As Exception
            VendorCode = ""
        End Try
        Try
            FuncCode = Request.QueryString("funccode")
        Catch ex As Exception
            FuncCode = ""
        End Try

        Try

        Catch ex As Exception

        End Try


        If Not Me.IsPostBack Then
            Try
                'Me.PO_DATE.Text = Now.Date
                Me.FillLocationDropDown()
                LoadSelections()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim jt As New Job_Template(Session("ConnString"))

            If Me.txtSubject.Text.Trim() = "" Then
                Me.lblMSG.Text = "Please enter a Subject."
                Exit Sub
            End If

            Dim PrintDate As String = ""
            If MiscFN.ValidDate(Me.RadDatePickerPrintDate, True) = False Then
                Me.lblMSG.Text = "Invalid Date"
                Exit Sub
            Else
                PrintDate = Me.RadDatePickerPrintDate.SelectedDate
            End If

            Dim ar() As String
            Try
                ar = ddLocation.SelectedValue.ToString.Split("|")
            Catch ex As Exception

            End Try
            otask.setAppVars(Session("UserCode"), "RequestPrint", "Location", "", Me.ddLocation.SelectedValue)
            otask.setAppVars(Session("UserCode"), "RequestPrint", "cbDate", "", Me.cbUsePrintedDate.Checked)
            otask.setAppVars(Session("UserCode"), "RequestPrint", "PrintDate", "", PrintDate)
            otask.setAppVars(Session("UserCode"), "RequestPrint", "Subject", "", jt.EncodeSQL(Me.txtSubject.Text))
            otask.setAppVars(Session("UserCode"), "RequestPrint", "Body", "", jt.EncodeSQL(Me.Radeditor1.Html.ToString()))
            otask.setAppVars(Session("UserCode"), "RequestPrint", "CC", "", Me.cbAddcc.Checked)
            CloseAndRefresh()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CloseAndRefresh()
        Me.CloseThisWindowAndRefreshCaller("VendorQuote.aspx")
    End Sub

    Private Sub FillLocationDropDown()
        Try
            Me.ddLocation.Items.Clear()
            Dim oReports As cReports = New cReports(CStr(Session("ConnString")))
            Me.ddLocation.DataSource = oReports.GetLocationPO
            Me.ddLocation.DataTextField = "ID"
            Me.ddLocation.DataValueField = "LOGO_PATH"
            Me.ddLocation.DataBind()
            Me.ddLocation.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", ""))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadSelections()
        Try

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim jt As New Job_Template(Session("ConnString"))
            Dim taskVar As String

            taskVar = otask.getAppVars(Session("UserCode"), "RequestPrint", "Location")
            If taskVar <> "" Then
                Me.ddLocation.SelectedValue = taskVar
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "RequestPrint", "cbDate")
            If taskVar <> "" Then
                Me.cbUsePrintedDate.Checked = taskVar
                If Me.cbUsePrintedDate.Checked = True Then
                    Me.pnlDate.Visible = True
                Else
                    Me.pnlDate.Visible = False
                End If
            Else
                Me.cbUsePrintedDate.Checked = False
                Me.pnlDate.Visible = False
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "RequestPrint", "PrintDate")
            If taskVar <> "" Then
                Me.RadDatePickerPrintDate.SelectedDate = CType(taskVar, Date)
            Else
                Me.RadDatePickerPrintDate.SelectedDate = cEmployee.TimeZoneToday
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "RequestPrint", "Subject")
            If taskVar <> "" Then
                Me.txtSubject.Text = jt.DecodeSQL(taskVar)
            Else
                Me.txtSubject.Text = "Request for Quote"
            End If

            Dim ds As DataSet
            Dim dsVendors As DataSet
            Dim vn As String
            Dim sbBody As New System.Text.StringBuilder
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            'dsVendors = est.GetRequestVendors(ThisTask_EstNum, ThisTask_EstComp, VendorQteNbr, Session("ConnString"))
            'ds = est.GetRequestVendorReplies(ThisTask_EstNum, ThisTask_EstComp, VendorQteNbr, Session("ConnString"))
            'sbBody.Append("RFQ - ")
            'sbBody.Append(ThisTask_EstNum.ToString.PadLeft(6, "0"))
            'sbBody.Append("-")
            'sbBody.Append(ThisTask_EstComp.ToString.PadLeft(2, "0"))
            'sbBody.Append("-")
            'sbBody.Append(VendorQteNbr.ToString.PadLeft(2, "0"))

            taskVar = otask.getAppVars(Session("UserCode"), "RequestPrint", "Body")
            If taskVar <> "" Then
                Me.Radeditor1.Html = jt.DecodeSQL(taskVar)
            Else
                Me.Radeditor1.Html = sbBody.ToString
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "RequestPrint", "CC")
            If taskVar <> "" Then
                Me.cbAddcc.Checked = taskVar
            End If


        Catch ex As Exception

        End Try


    End Sub


    Private Sub cbUsePrintedDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbUsePrintedDate.CheckedChanged
        Try
            If Me.cbUsePrintedDate.Checked = True Then
                Me.pnlDate.Visible = True
                Me.RadDatePickerPrintDate.SelectedDate = cEmployee.TimeZoneToday
            Else
                Me.pnlDate.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.CloseThisWindow()
    End Sub
End Class