Public Class VendorQuote_ImportSpecs
    Inherits Webvantage.BaseChildPage

    Private EstNum As Integer
    Private EstCompNum As Integer
    Private QuoteNum As Integer
    Private RevNum As Integer
    Private SeqNum As Integer
    Private JobNum As Integer = 0
    Private JobCompNum As Integer = 0
    Private SpecVer As Integer = 0
    Private SpecRev As Integer = 0
    Private VendorQteNbr As Integer
    Private FuncCode As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsNumeric(Request.QueryString("EstNum")) = True Then
                EstNum = CType(Request.QueryString("EstNum"), Integer)
            Else
                EstNum = 0
            End If
        Catch ex As Exception
            EstNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("EstComp")) = True Then
                EstCompNum = CType(Request.QueryString("EstComp"), Integer)
            Else
                EstCompNum = 0
            End If
        Catch ex As Exception
            EstCompNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("QuoteNum")) = True Then
                QuoteNum = CType(Request.QueryString("QuoteNum"), Integer)
            Else
                QuoteNum = 0
            End If
        Catch ex As Exception
            QuoteNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("RevNum")) = True Then
                RevNum = CType(Request.QueryString("RevNum"), Integer)
            Else
                RevNum = 0
            End If
        Catch ex As Exception
            RevNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("SeqNum")) = True Then
                SeqNum = CType(Request.QueryString("SeqNum"), Integer)
            Else
                SeqNum = 0
            End If
        Catch ex As Exception
            SeqNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("JobNum")) = True Then
                JobNum = CType(Request.QueryString("JobNum"), Integer)
            Else
                JobNum = 0
            End If
        Catch ex As Exception
            JobNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("JobComp")) = True Then
                JobCompNum = CType(Request.QueryString("JobComp"), Integer)
            Else
                JobCompNum = 0
            End If
        Catch ex As Exception
            JobCompNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("SpecVer")) = True Then
                SpecVer = CType(Request.QueryString("SpecVer"), Integer)
            Else
                SpecVer = 0
            End If
        Catch ex As Exception
            SpecVer = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("SpecRev")) = True Then
                SpecRev = CType(Request.QueryString("SpecRev"), Integer)
            Else
                SpecRev = 0
            End If
        Catch ex As Exception
            SpecRev = 0
        End Try
        Try
            VendorQteNbr = CType(Request.QueryString("VendorQteNbr"), Integer)
        Catch ex As Exception
            VendorQteNbr = 0
        End Try
        Try
            FuncCode = Request.QueryString("funccode")
        Catch ex As Exception
            FuncCode = ""
        End Try


        'Me.CancelButton.Attributes.Add("onclick", "window.close();")

        If Not Me.IsPostBack Then
            If Request.QueryString("From") = "header" Then
                Me.rbSelectQuote.Visible = True
                Me.rbSelectCategories.Visible = True
                Me.rbSelectQuote.Checked = True
                Me.lblSpecs.Visible = False
            ElseIf Me.SpecVer = 0 Then
                Me.rbSelectQuote.Visible = True
                Me.rbSelectCategories.Visible = True
                Me.rbSelectQuote.Checked = True
                Me.lblSpecs.Visible = False
            Else
                Me.rbSelectQuote.Visible = False
                Me.rbSelectCategories.Visible = False
            End If
            Me.checkchanged()
            loadSpecCategories()
            Me.txtSpecs.Text = CreateText(Me.JobNum, Me.JobCompNum, Me.SpecVer, Me.SpecRev)
        End If
    End Sub

    Private Sub RadGridSpecs_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridSpecs.ItemDataBound
        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

        End If
    End Sub

    Private Sub RadGridSpecs_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridSpecs.NeedDataSource
        Try
            Dim est As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))
            Dim dt As New DataTable
            dt = est.GetEstimateImportSpecs(Me.EstNum, Me.EstCompNum)
            Me.RadGridSpecs.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CloseAndRefreshCancel()
        Dim FunctionName As String = "HidePopUpWindows"
        Me.LitScript.Text = "<script>javascript:CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
    End Sub

    Private Sub CloseAndRefresh()
        Dim FunctionName As String = "RefreshGrid"
        Me.LitScript.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
    End Sub

    Private Sub rbSelectQuote_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSelectQuote.CheckedChanged
        checkchanged()
    End Sub

    Private Sub rbSelectCategories_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSelectCategories.CheckedChanged
        checkchanged()
    End Sub

    Private Sub checkchanged()
        Try
            If Request.QueryString("From") = "header" Then
                If rbSelectQuote.Checked = True Then
                    Me.pnlSelectQuote.Visible = True
                    Me.pnlSelectCategories.Visible = False
                End If
                If rbSelectCategories.Checked = True Then
                    Me.pnlSelectCategories.Visible = True
                    Me.pnlSelectQuote.Visible = False
                    loadSpecCategories()
                    Dim chk As CheckBox
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridSpecs.MasterTableView.Items
                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        If chk.Checked = True Then
                            Me.SpecVer = CInt(gridDataItem("colSPEC_VER").Text.Replace("&nbsp;", ""))
                            Me.SpecRev = CInt(gridDataItem("colSPEC_REV").Text.Replace("&nbsp;", ""))
                            Session("ImportSpecsSpecVer") = Me.SpecVer
                            Session("ImportSpecsSpecRev") = Me.SpecRev
                        End If
                    Next
                    Me.txtSpecs.Text = CreateText(Me.JobNum, Me.JobCompNum, Me.SpecVer, Me.SpecRev)
                End If
            Else
                Me.pnlSelectCategories.Visible = True
                Me.pnlSelectQuote.Visible = False
                loadSpecCategories()
                Me.txtSpecs.Text = CreateText(Me.JobNum, Me.JobCompNum, Me.SpecVer, Me.SpecRev)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadSpecCategories()
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Dim spectype As String = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
            With lbSpecs
                .DataTextField = "CATEGORY_DESC"
                .DataValueField = "CATEGORY_ID"
                .DataSource = js.GetJobSpecCategories(spectype)
                .DataBind()
            End With

            Dim i As Integer
            For i = 0 To Me.lbSpecs.Items.Count - 1
                Me.lbSpecs.Items(i).Selected = True
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Function CreateText(ByVal jobnum As Integer, ByVal jobcomp As Integer, ByVal specver As Integer, ByVal specrev As Integer)
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Dim catHeader As String = "================================================================"
            Dim catSubHeader As String = "--------------------------------"
            Dim sbSpecs As New System.Text.StringBuilder
            Dim i As Integer
            Dim j As Integer

            Dim ds As DataSet
            ds = js.GetJobSpecsDataSet(jobnum, jobcomp, specver, specrev)

            For i = 0 To Me.lbSpecs.Items.Count - 1
                If lbSpecs.Items(i).Selected = True Then
                    sbSpecs.AppendLine(catHeader)
                    sbSpecs.AppendLine(Me.lbSpecs.Items(i).Text)
                    sbSpecs.AppendLine(catHeader)
                    For j = 0 To ds.Tables(0).Rows.Count - 1
                        If lbSpecs.Items(i).Value = ds.Tables(0).Rows(j)("CATEGORY_ID") Then
                            If ds.Tables(0).Rows(j)("CONTROL_TYPE") = 4 Or ds.Tables(0).Rows(j)("CONTROL_TYPE") = 5 Then
                                sbSpecs.AppendLine(catSubHeader)
                                sbSpecs.AppendLine(ds.Tables(0).Rows(j)("SHORT_DESC"))
                                sbSpecs.AppendLine(catSubHeader)
                                sbSpecs.AppendLine(ds.Tables(0).Rows(j)("FIELD_VALUE"))
                                sbSpecs.AppendLine("")
                            Else
                                sbSpecs.AppendLine(ds.Tables(0).Rows(j)("SHORT_DESC") & ":  " & ds.Tables(0).Rows(j)("FIELD_VALUE"))
                            End If
                        End If
                    Next
                End If
            Next
            Return sbSpecs.ToString
        Catch ex As Exception

        End Try
    End Function

    Private Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim strScript As String
            Dim cScript As String
            Dim SpecText As String
            If Request.QueryString("From") = "quote" Then
                est.UpdateRequestQuote(EstNum, EstCompNum, VendorQteNbr, QuoteNum, RevNum, Me.txtSpecs.Text)
            ElseIf Request.QueryString("From") = "func" Then
                est.UpdateRequestFunction(EstNum, EstCompNum, VendorQteNbr, FuncCode, Me.txtSpecs.Text)
            ElseIf Request.QueryString("From") = "header" Then
                If rbSelectQuote.Checked = True Then
                    Dim chk As CheckBox
                    Dim specv As Integer
                    Dim specr As Integer
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridSpecs.MasterTableView.Items
                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        If chk.Checked Then
                            Try
                                specv = CType(gridDataItem.Item("colSPEC_VER").Text, Integer)
                            Catch ex As Exception
                                specv = 0
                            End Try
                            Try
                                specr = CType(gridDataItem.Item("colSPEC_REV").Text, Integer)
                            Catch ex As Exception
                                specr = 0
                            End Try
                            SpecText = CreateText(Me.JobNum, Me.JobCompNum, specv, specr)
                        End If
                    Next
                End If
                If rbSelectCategories.Checked = True Then
                    SpecText = Me.txtSpecs.Text
                End If
                est.UpdateRequestMemo(EstNum, EstCompNum, VendorQteNbr, SpecText, Session("UserCode"))
            End If
            Me.CloseThisWindowAndRefreshCaller("VendorQuote_Comments.aspx")
            
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lbSpecs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSpecs.SelectedIndexChanged
        Try
            If Request.QueryString("From") = "header" Or Me.SpecVer = 0 Then
                Me.SpecVer = Session("ImportSpecsSpecVer")
                Me.SpecRev = Session("ImportSpecsSpecRev")
            End If
            Me.txtSpecs.Text = Me.CreateText(Me.JobNum, Me.JobCompNum, Me.SpecVer, Me.SpecRev)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CancelButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton2.Click
        Try
            Me.CloseThisWindow()
        Catch ex As Exception

        End Try
    End Sub
End Class