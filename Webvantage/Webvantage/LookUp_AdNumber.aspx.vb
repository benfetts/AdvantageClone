Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.Drawing

Partial Public Class LookUp_AdNumber
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _ClientCode As String = ""
    Private _FromForm As String = ""
    Private _ReturnCodeToControl As String = ""
    Private _ReturnDescriptionToControl As String = ""
    Private _ThumbWidth As Integer = 100

    Public OpenerRadWindowName As String = ""
    Public ControlsToSet As String = ""

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadGridAdNumbers_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridAdNumbers.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Select Case e.CommandName
            Case "SelectAdNumber"
                Dim ar() As String
                ar = e.CommandArgument.ToString().Split("|")
                If ar(2).ToString() = "1" Then
                    Dim sb As New System.Text.StringBuilder
                    With sb
                        .Append("CallingWindowContent.document.getElementById('" & _ReturnCodeToControl & "').value = '" & ar(0).ToString() & "';")
                        If _ReturnDescriptionToControl <> "" Then
                            .Append("CallingWindowContent.document.getElementById('" & _ReturnDescriptionToControl & "').value = '" & ar(1).ToString().Replace("'", "\'") & "';")
                        End If
                    End With
                    Me.ControlsToSet = sb.ToString()
                    Me.HiddenFieldControlsToSet.Value = Me.ControlsToSet

                    Telerik.Web.UI.RadAjaxManager.GetCurrent(Me.Page).ResponseScripts.Add("returnValue();")

                Else
                    'not active
                    Me.ShowMessage("Cannot select an inactive Ad Number")

                End If
            Case "EditAdNumber"
                Me.HfInsertEdit_AdNumber.Value = e.CommandArgument
                ''Me.LblInsertEditAdNumber.Text = e.CommandArgument
                Me.MultiViewAdNumber.ActiveViewIndex = 1
                Me.LoadAdNumber(e.CommandArgument)
            Case "Upload"
                Me.SetUploadRadWindow(e.CommandArgument.ToString())
            Case "Upload2"
                Me.SetUploadRadWindow(e.CommandArgument.ToString())
            Case "Download"
                Try
                    Me.DeliverFile(CType(e.CommandArgument, Integer))
                Catch ex As Exception
                End Try
            Case "ThumbnailClick"
                Dim DocId As Integer = 0
                Try
                    If IsNumeric(e.CommandArgument) = True Then
                        DocId = CType(e.CommandArgument, Integer)
                    Else
                        DocId = 0
                    End If
                Catch ex As Exception
                    DocId = 0
                End Try
                If DocId = 0 Then
                    Try
                        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridAdNumbers.Items(e.Item.ItemIndex), Telerik.Web.UI.GridDataItem)
                        Dim ThisAdNbr As String = ""
                        ThisAdNbr = CurrentGridRow.GetDataKeyValue("AD_NBR")
                        Me.SetUploadRadWindow(ThisAdNbr)
                    Catch ex As Exception
                    End Try
                Else
                    Me.DeliverFile(DocId)
                End If
        End Select
    End Sub
    Private Sub RadGridAdNumbers_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridAdNumbers.ItemDataBound
        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
            Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item

            'SET IMAGE THUMBNAIL COLUMN
            If Me.ChkShowThumbnail.Checked = True Then
                Try
                    Dim IB As System.Web.UI.WebControls.ImageButton = CType(dataItem.FindControl("ImgBtnThumbnail"), ImageButton)
                    Dim DocId As Integer = 0
                    Try
                        If IsNumeric(CType(dataItem.FindControl("HfDocumentId"), HiddenField).Value) = True Then
                            DocId = CType(CType(dataItem.FindControl("HfDocumentId"), HiddenField).Value, Integer)
                        End If
                    Catch ex As Exception
                        DocId = 0
                    End Try
                    If DocId > 0 Then
                        With IB
                            .ImageUrl = "Thumbnail.aspx?docid=" & DocId.ToString() & "&w=" & _ThumbWidth.ToString()
                            Try
                                Dim str As String = CType(dataItem.FindControl("LBtnDownload"), LinkButton).Text 'LBtnDownload
                                .ToolTip = str
                                .AlternateText = str
                            Catch ex As Exception
                                .ToolTip = "Click to open/save"
                                .AlternateText = "Click to open/save"
                            End Try
                        End With
                    Else
                        With IB
                            .ImageUrl = "Images/Ad_Number_Upload.png"
                            .ToolTip = "Click to add a document"
                            .AlternateText = "Click to add a document"
                        End With
                    End If
                Catch ex As Exception
                End Try
            End If

            'SET COLOR
            Try
                Dim c As String = ""
                c = CType(dataItem.FindControl("HfColor"), HiddenField).Value.Trim()
                If c <> "" Then
                    dataItem.Cells(7).BackColor = ColorTranslator.FromHtml(c)
                End If
            Catch ex As Exception
            End Try

            'SET ACTIVE/INACTIVE...?
            Try
                If Me.ChkShowInactive.Checked = True Then
                    Dim c As Integer = 0
                    c = CType(CType(dataItem.FindControl("HfActive"), HiddenField).Value.Trim(), Integer)
                    If c = 0 Then
                        dataItem.Cells(6).Text = dataItem.Cells(6).Text & " (Inactive)"
                    Else
                        dataItem.Cells(6).Text = dataItem.Cells(6).Text & " (Active)"
                    End If
                End If
            Catch ex As Exception

            End Try


        End If
    End Sub
    Private Sub RadGridAdNumbers_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridAdNumbers.NeedDataSource

        Dim oDataTable As DataTable = Nothing
        Dim oDataView As DataView = Nothing

        Dim d As New cDropDowns(Session("ConnString"))
        oDataTable = d.GetAdNumbers(Me._ClientCode, Me.ChkShowInactive.Checked)

        'If txtForm_AdNumber.Text.Trim <> "" Then
        '    oDataView = New DataView(oDataTable)
        '    oDataView.RowFilter = "AD_NBR LIKE '%" & txtForm_AdNumber.Text.Trim & "%'"
        '    oDataTable = oDataView.ToTable
        'End If

        'If txtForm_Description.Text.Trim <> "" Then
        '    oDataView = New DataView(oDataTable)
        '    oDataView.RowFilter = "AD_NBR_DESC LIKE '%" & txtForm_Description.Text.Trim & "%'"
        '    oDataTable = oDataView.ToTable
        'End If

        Me.RadGridAdNumbers.DataSource = oDataTable
        Me.RadGridAdNumbers.MasterTableView.GetColumn("ColThumbNail").Visible = Me.ChkShowThumbnail.Checked
        Me.RadGridAdNumbers.MasterTableView.GetColumn("ColThumbNail").Display = Me.ChkShowThumbnail.Checked

    End Sub

    Private Sub RadToolbarAdNumber_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarAdNumber.ButtonClick
        Select Case e.Item.Value
            Case "NewAdNumber"

                Me.HfInsertEdit_AdNumber.Value = "#INSERT_NEW_AD_NUMBER#"
                Me.MultiViewAdNumber.ActiveViewIndex = 1
                Me.ClearInsertAdd()
                Me.SetBlackplateDDL()
                Me.TxtInsertEdit_AdNumber.ReadOnly = False

            Case "Cancel"

                Me.CloseThisWindow()

        End Select
    End Sub

    Private Sub ChkShowThumbnail_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkShowThumbnail.CheckedChanged

        Me.RadGridAdNumbers.Rebind()

    End Sub
    Private Sub ChkShowInactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkShowInactive.CheckedChanged

        Me.RadGridAdNumbers.Rebind()

    End Sub

#End Region
#Region " Page "

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init

        'objects
        Dim HasAccessToDocuments As Boolean = False

        HasAccessToDocuments = Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_AdNumber, False))

        Try

            RadGridAdNumbers.Columns.FindByUniqueName("ColUpload").Display = HasAccessToDocuments
            RadGridAdNumbers.Columns.FindByUniqueName("ColFILENAME").Display = HasAccessToDocuments
            RadGridAdNumbers.Columns.FindByUniqueName("ColThumbNail").Display = HasAccessToDocuments

        Catch ex As Exception

        End Try

        Me.AllowFloat = True

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.OpenerRadWindowName = Request.QueryString("opener")
        Catch ex As Exception
            Me.OpenerRadWindowName = ""
        End Try
        Try
            _FromForm = Request.QueryString("form")
        Catch ex As Exception
            _FromForm = ""
        End Try
        Try
            Me._ClientCode = Request.QueryString("cli")
        Catch ex As Exception
            Me._ClientCode = ""
        End Try
        Select Case _FromForm
            Case "evt_gen", "evt_dtl"
                _ReturnCodeToControl = "ctl00_ContentPlaceHolderMain_TxtAdNumber"
                _ReturnDescriptionToControl = "ctl00_ContentPlaceHolderMain_TxtAdNumberDescription"
            Case "jt", "evt_view"
                Try
                    _ReturnCodeToControl = Request.QueryString("ctrl")
                Catch ex As Exception
                    _ReturnCodeToControl = ""
                End Try
                _ReturnDescriptionToControl = "" 'only returning the code

        End Select
        If Not Me.IsCallback And Not Me.IsPostBack Then
            Me.MultiViewAdNumber.ActiveViewIndex = 0
            Me.HlInsertEdit_Client.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=adnumber_lookup&control=" & Me.TxtInsertEdit_ClientCode.ClientID & "&type=client&client=' + document.forms[0]." & Me.TxtInsertEdit_ClientCode.ClientID & ".value, 'PopLookup1','screenX=150,left=150,screenY=150,top=150,width=580,height=425,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
            'With Me.TxtInsertEdit_AdNumberDescription.Attributes
            '    .Add("onkeydown", "Javascript:limitText('" & Me.TxtInsertEdit_AdNumberDescription.ClientID & "',60);")
            '    .Add("onkeyup", "Javascript:limitText('" & Me.TxtInsertEdit_AdNumberDescription.ClientID & "',60);")
            'End With
            MiscFN.LimitTextbox(Me.TxtInsertEdit_AdNumberDescription, 60)
        Else
            Select Case Me.EventArgument.ToString().Replace("onclick#", "")
                Case "Refresh", "HidePopUpRefresh"
                    Me.RadGridAdNumbers.Rebind()
                Case "NewAdNumber"
                    Me.HfInsertEdit_AdNumber.Value = "#INSERT_NEW_AD_NUMBER#"
                    Me.MultiViewAdNumber.ActiveViewIndex = 1
                    Me.ClearInsertAdd()
                    Me.SetBlackplateDDL()
                    Me.TxtInsertEdit_AdNumber.ReadOnly = False
            End Select

        End If

    End Sub

#End Region

    Private Sub SetUploadRadWindow(ByVal AdNumber As String)

        Session("DocFilterLevel") = "AN"
        Session("DocCaption") = "Ad Number: " & AdNumber
        Me.OpenWindow("Upload a new document", "Documents_Upload.aspx?caller=" & Me.PageFilename & "&Level=AN&FK=&Value=" & AdNumber & "&DOLevel=AN", 550, 575)

    End Sub
    Private Sub ClearInsertAdd()

        Me.TxtInsertEdit_AdNumber.Text = ""
        Me.TxtInsertEdit_AdNumberDescription.Text = ""
        Me.TxtInsertEdit_ClientCode.Text = ""
        Me.TxtInsertEdit_ClientDescription.Text = ""
        Me.ChkInsertEdit_Inactive.Checked = False

    End Sub

#Region " Add/Insert View "

#Region " Controls "

    Private Sub BtnInsertEditSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnInsertEditSave.Click

        Dim v As New cValidations(Session("ConnString"))
        Dim m As New cMaintenanceApps()

        If Me.TxtInsertEdit_AdNumber.Text.Trim() = "" Then
            Me.ShowMessage("Ad Number is required")
            Exit Sub
        End If

        If Regex.IsMatch(Me.TxtInsertEdit_AdNumber.Text.Trim(), Me.HfRegEx.Value) = False Then
            Me.ShowMessage("Ad Number invalid")
            Exit Sub
        End If

        If Me.TxtInsertEdit_AdNumberDescription.Text.Trim() = "" Then
            Me.ShowMessage("Description is required")
            Exit Sub
        End If

        If Me.TxtInsertEdit_AdNumberDescription.Text.Trim().Length > 60 Then
            Me.ShowMessage("Description limited to 60 characters")
            Exit Sub
        End If

        If Me.TxtInsertEdit_ClientCode.Text.Trim() <> "" Then
            If v.ValidateCDP(Me.TxtInsertEdit_ClientCode.Text, "", "", False) = False Then
                'invalid client code
                Me.ShowMessage("Client Code invalid")
                Exit Sub
            End If
        End If

        If Me.HfInsertEdit_AdNumber.Value <> "#INSERT_NEW_AD_NUMBER#" Then 'UPDATE
            'save it
            m.AdNumber_Detail_Update(Me.TxtInsertEdit_AdNumber.Text, Me.TxtInsertEdit_AdNumberDescription.Text, Me.ChkInsertEdit_Inactive.Checked, Me.DropInsertEdit_Blackplate1.SelectedValue, Me.DropInsertEdit_Blackplate2.SelectedValue, Me.TxtInsertEdit_ClientCode.Text, ColorTranslator.ToHtml(Me.RadColorPickerInsertEdit_AdNumberColor.SelectedColor).ToString())
            'clear insert form
            Me.HfInsertEdit_AdNumber.Value = ""
            'if save successful, go back to list and refresh
            Me.ClearInsertAdd()
            Me.MultiViewAdNumber.ActiveViewIndex = 0
            Me.RadGridAdNumbers.Rebind()
        Else 'INSERT
            'insert
            Dim rtn As String = ""
            rtn = m.AdNumber_Detail_Insert(Me.TxtInsertEdit_AdNumber.Text, Me.TxtInsertEdit_AdNumberDescription.Text, Me.ChkInsertEdit_Inactive.Checked, Me.DropInsertEdit_Blackplate1.SelectedValue, Me.DropInsertEdit_Blackplate2.SelectedValue, Me.TxtInsertEdit_ClientCode.Text, ColorTranslator.ToHtml(Me.RadColorPickerInsertEdit_AdNumberColor.SelectedColor).ToString())
            If rtn <> "" Then
                'error:
                Me.ShowMessage(rtn)
                Exit Sub
            Else
                Me.HfInsertEdit_AdNumber.Value = ""
                Me.ClearInsertAdd()
                Me.MultiViewAdNumber.ActiveViewIndex = 0
                Me.RadGridAdNumbers.Rebind()
            End If
        End If
    End Sub
    Private Sub BtnInsertEditCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnInsertEditCancel.Click
        Me.HfInsertEdit_AdNumber.Value = ""
        Me.MultiViewAdNumber.ActiveViewIndex = 0
        Me.CloseThisWindow()
    End Sub

#End Region

    Private Sub SetBlackplateDDL()
        Dim DtBlackplate As New DataTable
        Dim d As New cDropDowns(Session("ConnString"))
        DtBlackplate = d.GetBlackplate()
        With Me.DropInsertEdit_Blackplate1
            .DataSource = DtBlackplate
            .DataTextField = "description"
            .DataValueField = "code"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", ""))
        End With
        With Me.DropInsertEdit_Blackplate2
            .DataSource = DtBlackplate
            .DataTextField = "description"
            .DataValueField = "code"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", ""))
        End With
    End Sub
    Private Sub LoadAdNumber(ByVal AdNumber As String)
        Dim dt As New DataTable
        Dim m As New cMaintenanceApps()
        Me.TxtInsertEdit_AdNumber.ReadOnly = True
        Me.SetBlackplateDDL()
        dt = m.AdNumber_Detail_Get(AdNumber)
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                Try
                    If IsDBNull(dt.Rows(0)("AD_NBR")) = False Then
                        Me.TxtInsertEdit_AdNumber.Text = dt.Rows(0)("AD_NBR").ToString()
                    Else
                        Me.TxtInsertEdit_AdNumber.Text = ""
                    End If
                Catch ex As Exception
                End Try

                Try
                    If IsDBNull(dt.Rows(0)("AD_NBR_DESC")) = False Then
                        Me.TxtInsertEdit_AdNumberDescription.Text = dt.Rows(0)("AD_NBR_DESC").ToString()
                    Else
                        Me.TxtInsertEdit_AdNumberDescription.Text = ""
                    End If
                Catch ex As Exception
                End Try

                Try
                    If IsDBNull(dt.Rows(0)("ACTIVE")) = False Then
                        Dim i As Integer = CType(dt.Rows(0)("ACTIVE"), Integer)
                        If i = 0 Then
                            Me.ChkInsertEdit_Inactive.Checked = True
                        Else
                            Me.ChkInsertEdit_Inactive.Checked = False
                        End If
                    Else
                        Me.ChkInsertEdit_Inactive.Checked = False
                    End If
                Catch ex As Exception
                End Try

                Try
                    If IsDBNull(dt.Rows(0)("DEF_BLKPLT_VER_CODE")) = False Then
                        MiscFN.RadComboBoxSetIndex(Me.DropInsertEdit_Blackplate1, dt.Rows(0)("DEF_BLKPLT_VER_CODE").ToString(), False, True)
                    Else
                        Me.DropInsertEdit_Blackplate1.SelectedIndex = 0
                    End If
                Catch ex As Exception
                End Try

                Try
                    If IsDBNull(dt.Rows(0)("DEF_BLKPLT_VER2_CODE")) = False Then
                        MiscFN.RadComboBoxSetIndex(Me.DropInsertEdit_Blackplate2, dt.Rows(0)("DEF_BLKPLT_VER2_CODE").ToString(), False, True)
                    Else
                        Me.DropInsertEdit_Blackplate2.SelectedIndex = 0
                    End If
                Catch ex As Exception
                End Try

                Try
                    If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                        Me.TxtInsertEdit_ClientCode.Text = dt.Rows(0)("CL_CODE").ToString()
                    Else
                        Me.TxtInsertEdit_ClientCode.Text = ""
                    End If
                Catch ex As Exception
                End Try

                Try
                    If IsDBNull(dt.Rows(0)("CL_NAME")) = False Then
                        Me.TxtInsertEdit_ClientDescription.Text = dt.Rows(0)("CL_NAME").ToString()
                    Else
                        Me.TxtInsertEdit_ClientDescription.Text = ""
                    End If
                Catch ex As Exception
                End Try

                Try
                    'If IsDBNull(dt.Rows(0)("DOCUMENT_ID")) = False Then
                    '    CurrEventTaskId = CType(dt.Rows(0)("DOCUMENT_ID"), Integer)
                    'Else
                    '    CurrEventTaskId = 0
                    'End If
                Catch ex As Exception
                End Try

                Try
                    If IsDBNull(dt.Rows(0)("COLOR")) = False Then
                        Me.RadColorPickerInsertEdit_AdNumberColor.SelectedColor = ColorTranslator.FromHtml(dt.Rows(0)("COLOR").ToString())
                    Else
                        Me.RadColorPickerInsertEdit_AdNumberColor.SelectedColor = Color.Transparent
                    End If
                Catch ex As Exception
                    Me.RadColorPickerInsertEdit_AdNumberColor.SelectedColor = Color.Transparent
                End Try

            End If
        End If
    End Sub

#End Region

#End Region


End Class